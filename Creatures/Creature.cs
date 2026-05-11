namespace Creatures;

public enum HealthStatus
{
    NotHealthy,
    Healthy,
    VeryHealthy
}

public class Creature
{
    public string Name { get; }
    public string Color { get; }
    public int Strength { get; }
    public HealthStatus Health { get; protected set; }

    public Creature(string name, string color, int strength, HealthStatus health)
    {
        Name = name;
        Color = color;
        Strength = strength;
        Health = health;
    }

    public virtual string Move()
    {
        return $"{Name} moves forward.";
    }

    public virtual string Eat()
    {
        return $"{Name} eats.";
    }

    public virtual string Communicate()
    {
        return $"{Name} makes a sound.";
    }

    public string ShowCreatureState()
    {
        if (Health == HealthStatus.NotHealthy)
        {
            return $"{Name} is not doing well right now.";
        }

        if (Health == HealthStatus.VeryHealthy)
        {
            return $"{Name} looks extremely energetic.";
        }

        return $"{Name} is doing okay.";
    }

    public virtual string GetInformation()
    {
        return $"{GetType().Name}: {Name} is {Color}, has {Strength} strength, and is {Health}.";
    }
}