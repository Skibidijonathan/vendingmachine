using System;

// Basklass för alla produkter
abstract class Product
{
    // Produktnamn
    public string Name { get; set; }

    // pris i kronor
    public int Price { get; set; }

    protected Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    // uträkning för hur mycket de kostar
    public virtual string Examine()
    {
        return $"{Name} - {Price} kr";
    }

    public abstract string Use();
}