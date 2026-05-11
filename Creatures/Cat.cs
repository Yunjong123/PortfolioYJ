namespace Creatures;

public class Cat : Creature
{
    public Cat(string name, string color, int strength, HealthStatus health)
        : base(name, color, strength, health)
    {
    }

    public override string Move()
    {
        return $"{Name} walks quietly.";
    }

    public override string Eat()
    {
        return $"{Name} eats fish.";
    }

    public override string Communicate()
    {
        return $"{Name} meows.";
    }
}