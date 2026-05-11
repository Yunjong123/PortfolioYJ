namespace Orlde;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        bool running = true;

        while (running)
        {
            OrldeGame game = new OrldeGame();
            game.Play();

            Console.WriteLine();
            Console.Write("Press X to exit or any other key to play again: ");
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.X)
            {
                running = false;
            }
        }

        Console.ResetColor();
        Console.Clear();
        Console.WriteLine("GoodBye.");
    }
}