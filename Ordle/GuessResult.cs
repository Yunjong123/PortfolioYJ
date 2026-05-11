namespace Orlde;

public class GuessResult
{
    public string Guess { get; }
    public LetterState[] States { get; }
    public GuessResult(string guess, LetterState[] states)
    {
        Guess = guess;
        States = states;
    }
}