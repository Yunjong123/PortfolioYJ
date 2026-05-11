namespace Creatures;

public class Unicorn : Creature
{
    public Unicorn(string name, string color, int strength, HealthStatus health)
        : base(name, color, strength, health)
    {
    }

    public override string Move()
    {
        return $"{Name} gallops gracefully.";
    }

    public override string Eat()
    {
        return $"{Name} eats magical grass.";
    }

    public override string Communicate()
    {
        return $"{Name} sparkles and sings.";
    }
}