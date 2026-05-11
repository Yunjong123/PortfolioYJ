namespace Creatures;

public class Location
{
    public string Name { get; }
    public string Description { get; }
    public ConsoleColor ForegroundColor { get; }
    public ConsoleColor BackgroundColor { get; }
    public List<Creature> Creatures { get; }

    public Location(
        string name,
        string description,
        ConsoleColor foregroundColor,
        ConsoleColor backgroundColor,
        List<Creature> creatures)
    {
        Name = name;
        Description = description;
        ForegroundColor = foregroundColor;
        BackgroundColor = backgroundColor;
        Creatures = creatures;
    }
}