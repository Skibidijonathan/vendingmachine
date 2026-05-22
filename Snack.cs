
using System;

// SNack
class Snack : Product
{
    public Snack(string name, int price) : base(name, price) { }

    // Att använda ett snacks returnerar ett kort meddelande
    public override string Use()
    {
        return $"You ate {Name}.";
    }
}