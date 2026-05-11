using Orlde;

namespace Orlde;

public class OrldeGame
{
    private const int Rows = 6;
    private const int Cols = 5;

    private readonly Random random = new();
    private readonly List<GuessResult> history = new();
    private readonly Dictionary<char, LetterState> keyboard = new();

    private string answer = string.Empty;
    private bool won;

    public OrldeGame()
    {
        Reset();
    }

    public void Play()
    {
        bool finished = false;

        while (!finished)
        {
            DrawScreen();

            string guess = ReadGuess();

            GuessResult result = EvaluateGuess(guess);
            history.Add(result);
            UpdateKeyboard(result);

            if (guess.Equals(answer, StringComparison.OrdinalIgnoreCase))
            {
                won = true;
                finished = true;
            }
            else if (history.Count >= Rows)
            {
                finished = true;
            }
        }

        DrawScreen();
        PrintSummary();
    }

    private void Reset()
    {
        answer = WordRepository.GetRandomAnswer(random);
        history.Clear();
        keyboard.Clear();
        won = false;
    }

    private void DrawScreen()
    {
        Console.Clear();
        Console.ResetColor();

        Console.WriteLine("Orlde");
        Console.WriteLine();
        Console.WriteLine("Guess the 5-letter word in 6 tries.");
        Console.WriteLine("Green = correct spot, Yellow = in the word, Dark Gray = not in the word.");
        Console.WriteLine();

        DrawBoard();
        Console.WriteLine();
        DrawKeyboard();
        Console.WriteLine();
    }

    private void DrawBoard()
    {
        for (int row = 0; row < Rows; row++)
        {
            if (row < history.Count)
            {
                DrawGuessRow(history[row]);
            }
            else
            {
                DrawEmptyRow();
            }
        }
    }

    private void DrawGuessRow(GuessResult result)
    {
        for (int i = 0; i < Cols; i++)
        {
            char letter = result.Guess[i];
            LetterState state = result.States[i];
            WriteTile(letter, state);
            Console.Write(" ");
        }

        Console.WriteLine();
    }

    private void DrawEmptyRow()
    {
        for (int i = 0; i < Cols; i++)
        {
            WriteTile(' ', LetterState.Unknown);
            Console.Write(" ");
        }

        Console.WriteLine();
    }

    private void DrawKeyboard()
    {
        string[] rows =
        {
            "QWERTYUIOP",
            "ASDFGHJKL",
            "ZCXVBNM"
        };

        Console.WriteLine("Keyboard");

        foreach (string row in rows)
        {
            foreach (char letter in row)
            {
                LetterState state = keyboard.GetValueOrDefault(letter, LetterState.Unknown);
                WriteTile(letter, state);
                Console.Write(" ");
            }

            Console.WriteLine();
        }
    }

    private void WriteTile(char letter, LetterState state)
    {
        ConsoleColor previousForeground = Console.ForegroundColor;
        ConsoleColor previousBackground = Console.BackgroundColor;

        switch (state)
        {
            case LetterState.Correct:
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            case LetterState.Present:
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            case LetterState.Absent:
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            default:
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }

        Console.Write($"[{char.ToUpper(letter)}]");

        Console.BackgroundColor = previousBackground;
        Console.BackgroundColor = previousForeground;
    }

    private string ReadGuess()
    {
        while (true)
        {
            Console.Write($"Round {history.Count + 1} of {Rows}. Enter a 5-letter word:");
            string input = (Console.ReadLine() ?? string.Empty).Trim().ToUpperInvariant();

            if (input.Length != Cols)
            {
                Console.WriteLine("The word must be exactly 5 letters.");
                continue;
            }

            if (!input.All(char.IsLetter))
            {
                Console.WriteLine("Use letters only.");
                continue;
            }

            if (!WordRepository.IsValidWords(input))
            {
                Console.WriteLine("That is not in the word list.");
                continue;
            }

            return input;
        }
    }

    private GuessResult EvaluateGuess(string guess)
    {
        LetterState[] states = new LetterState[Cols];
        char[] answerChars = answer.ToCharArray();
        bool[] used = new bool[Cols];

        for (int i = 0; i < Cols; i++)
        {
            if (guess[i] == answerChars[i])
            {
                states[i] = LetterState.Correct;
                used[i] = true;
            }
        }

        for (int i = 0; i < Cols; i++)
        {
            if (states[i] == LetterState.Correct)
            {
                continue;
            }

            bool found = false;

            for (int j = 0; j < Cols; j++)
            {
                if (!used[j] && guess[i] == answerChars[j])
                {
                    found = true;
                    used[j] = true;
                    break;
                }
            }

            states[i] = found ? LetterState.Present : LetterState.Absent;
        }

        return new GuessResult(guess, states);
    }

    private void UpdateKeyboard(GuessResult result)
    {
        for (int i = 0; i < result.Guess.Length; i++)
        {
            char letter = result.Guess[i];
            LetterState newState = result.States[i];
            LetterState oldState = keyboard.GetValueOrDefault(letter, LetterState.Unknown);

            if ((int)newState > (int)oldState)
            {
                keyboard[letter] = newState;
            }
        }
    }

    private void PrintSummary()
    {
        Console.WriteLine();

        if (won)
        {
            Console.WriteLine($"You won in {history.Count} round(s).");
        }
        else
        {
            Console.WriteLine($"You lost. The word was {answer}");
        }

        Console.WriteLine();
        Console.WriteLine("Share Result");
        Console.WriteLine(BuildShareText());
    }

    private string BuildShareText()
    {
        List<string> lines = new();
        string header = won
            ? $"Orlde {history.Count}/ {Rows}"
            : $"Orlde X/{Rows}";

        lines.Add(header);

        foreach (GuessResult result in history)
        {
            char[] symbols = new char[Cols];

            for (int i = 0; i < Cols; i++)
            {
                symbols[i] = result.States[i] switch
                {
                    LetterState.Correct => 'G',
                    LetterState.Present => 'Y',
                    LetterState.Absent => 'X',
                    _ => '-'
                };
            }

            lines.Add(new string(symbols));
        }

        return string.Join(Environment.NewLine, lines);
    }

}