using System;

// En dryck
class Drink : Product
{
    public Drink(string name, int price) : base(name, price) { }

    // Att använda en dryck returnerar ett kort meddelande
    public override string Use()
    {
        return $"You drank {Name}.";
    }
}