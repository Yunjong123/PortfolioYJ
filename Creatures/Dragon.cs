namespace Creatures;

public class Dragon : Creature
{
    public Dragon(string name, string color, int strength, HealthStatus health)
        : base(name, color, strength, health)
    {
    }

    public override string Move()
    {
        return $"{Name} flies across the sky.";
    }

    public override string Eat()
    {
        return $"{Name} eats a giant meal.";
    }

    public override string Communicate()
    {
        return $"{Name} roars with fire.";
    }
}