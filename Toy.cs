
using System;

// En leksak
class Toy : Product
{
    public Toy(string name, int price) : base(name, price) { }

    // Att använda en leksak returnerar ett kort meddelande
    public override string Use()
    {
        return $"You play with {Name}.";
    }
}