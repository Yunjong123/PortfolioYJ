namespace Creatures;

public class Mermaid : Creature
{
    public Mermaid(string name, string color, int strength, HealthStatus health)
        : base(name, color, strength, health)
    {
    }

    public override string Move()
    {
        return $"{Name} swims through the water.";
    }

    public override string Eat()
    {
        return $"{Name} eats seaweed and shellfish.";
    }

    public override string Communicate()
    {
        return $"{Name} sings a sea melody.";
    }
}