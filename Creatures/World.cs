namespace Creatures;

public class World
{
    public List<Location> Locations { get; } = new();

    public World()
    {
        Locations.Add(
            new Location(
                "Forest",
                "A calm green forest filled with soft sounds and quiet paths.",
                ConsoleColor.DarkGreen,
                ConsoleColor.Black,
                new List<Creature>
                {
                    new Cat("Max", "Orange", 25, HealthStatus.Healthy),
                    new Unicorn("Sparkle", "White", 80, HealthStatus.NotHealthy)
                }
            )
        );

        Locations.Add(
            new Location(
                "Mountain",
                "A rocky mountain with strong winds and dangerous cliffs.",
                ConsoleColor.Gray,
                ConsoleColor.Black,
                new List<Creature>
                {
                    new Dragon("Blaze", "Red", 95, HealthStatus.VeryHealthy),
                    new Creature("Martin", "Brown", 30, HealthStatus.Healthy)
                }
            )
        );

        Locations.Add(
            new Location(
                "Ocean",
                "A deep blue ocean with waves, coral, and hidden life.",
                ConsoleColor.Cyan,
                ConsoleColor.Black,
                new List<Creature>
                {
                    new Mermaid("Coral", "Blue", 55, HealthStatus.Healthy)
                }
            )
        );
    }

    public void Initialize()
    {
        bool running = true;

        while (running)
        {
            Console.ResetColor();
            Console.Clear();

            Console.WriteLine("Creatures (Inheritance and Enums)");
            Console.WriteLine();
            Console.WriteLine("Choose a location to visit:");
            Console.WriteLine();

            for (int i = 0; i < Locations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Locations[i].Name}");
            }

            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Selection: ");

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                ShowMessage("Please enter a valid number.");
                continue;
            }

            if (choice == 0)
            {
                running = false;
                continue;
            }

            if (choice < 1 || choice > Locations.Count)
            {
                ShowMessage("That location does not exist.");
                continue;
            }

            VisitLocation(Locations[choice - 1]);
        }

        Console.ResetColor();
        Console.Clear();
        Console.WriteLine("Goodbye.");
    }

    private void VisitLocation(Location location)
    {
        bool inLocation = true;

        while (inLocation)
        {
            ApplyLocationTheme(location);

            Console.Clear();
            Console.WriteLine($"Location: {location.Name}");
            Console.WriteLine(location.Description);
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. View all creatures in this location");
            Console.WriteLine("2. Interact with a creature");
            Console.WriteLine("3. Travel back to the main menu");
            Console.WriteLine();
            Console.Write("Selection: ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ShowCreatures(location);
                    break;
                case "2":
                    InteractWithCreature(location);
                    break;
                case "3":
                    inLocation = false;
                    break;
                default:
                    ShowMessage("Please choose 1, 2, or 3.");
                    break;
            }
        }

        Console.ResetColor();
    }

    private void ShowCreatures(Location location)
    {
        ApplyLocationTheme(location);
        Console.Clear();

        Console.WriteLine($"Creatures in {location.Name}");
        Console.WriteLine();

        for (int i = 0; i < location.Creatures.Count; i++)
        {
            Creature creature = location.Creatures[i];
            Console.WriteLine($"{i + 1}. {creature.GetInformation()}");
            Console.WriteLine($"   {creature.ShowCreatureState()}");
            Console.WriteLine();
        }

        Pause();
    }

    private void InteractWithCreature(Location location)
    {
        while (true)
        {
            ApplyLocationTheme(location);
            Console.Clear();

            Console.WriteLine($"Interact with a creature in {location.Name}");
            Console.WriteLine();

            for (int i = 0; i < location.Creatures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {location.Creatures[i].Name}");
            }

            Console.WriteLine("0. Back");
            Console.WriteLine();
            Console.Write("Selection: ");

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                ShowMessage("Please enter a valid number.");
                continue;
            }

            if (choice == 0)
            {
                return;
            }

            if (choice < 1 || choice > location.Creatures.Count)
            {
                ShowMessage("That creature does not exist.");
                continue;
            }

            Creature selectedCreature = location.Creatures[choice - 1];
            ShowCreatureInteractionMenu(location, selectedCreature);
        }
    }

    private void ShowCreatureInteractionMenu(Location location, Creature creature)
    {
        bool interacting = true;

        while (interacting)
        {
            ApplyLocationTheme(location);
            Console.Clear();

            Console.WriteLine($"Creature: {creature.Name}");
            Console.WriteLine();
            Console.WriteLine("1. Show information");
            Console.WriteLine("2. Check health/state");
            Console.WriteLine("3. Move");
            Console.WriteLine("4. Eat");
            Console.WriteLine("5. Communicate");
            Console.WriteLine("0. Back");
            Console.WriteLine();
            Console.Write("Selection: ");

            string? input = Console.ReadLine();

            Console.WriteLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine(creature.GetInformation());
                    Pause();
                    break;
                case "2":
                    Console.WriteLine(creature.ShowCreatureState());
                    Pause();
                    break;
                case "3":
                    Console.WriteLine(creature.Move());
                    Pause();
                    break;
                case "4":
                    Console.WriteLine(creature.Eat());
                    Pause();
                    break;
                case "5":
                    Console.WriteLine(creature.Communicate());
                    Pause();
                    break;
                case "0":
                    interacting = false;
                    break;
                default:
                    ShowMessage("Please choose a valid menu option.");
                    break;
            }
        }
    }

    private void ApplyLocationTheme(Location location)
    {
        Console.ForegroundColor = location.ForegroundColor;
        Console.BackgroundColor = location.BackgroundColor;
    }

    private void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    private void ShowMessage(string message)
    {
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine(message);
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}