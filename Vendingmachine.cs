using System;
using System.Collections.Generic;

class VendingMachine
{
    // Produkter tillgängliga i automaten
    public List<Product> Products { get; private set; }

    // Hur mycket pengar som man har sättit in i automaten
    public int MoneyPool { get; private set; }

    // Accepterade olika mynt i kronor
    private readonly int[] validCoins = new[] { 5, 10, 20, 50 };

    public VendingMachine(List<Product> products)
    {
        Products = products ?? new List<Product>();
        MoneyPool = 0;
    }

    // Försök att sätta in pengar och de returnerar true om beloppet är tillgängligt.
    public bool InsertMoney(int amount)
    {
        // Ogiltigt belopp (negativt eller noll) 
        if (amount <= 0)
        {
            return false;
        }

        // Gå igenom godkända mynt och jämför med insatt belopp
        foreach (int coin in validCoins)
        {
            if (coin == amount)
            {
                MoneyPool += amount; // Lägg till pengarna i poolen
                return true;         // Returnera true om myntet är godkänt
            }
        }

        // Om inget match hittades är valören ogiltig
        return false;
    }

    // Visa produktlista och nuvarande saldo
    public void ShowProducts()
    {
        Console.WriteLine("\nProducts:");
        for (int i = 0; i < Products.Count; i++)
        {
            var p = Products[i];
            Console.WriteLine($"{i + 1}: {p.Examine()}");
        }
        Console.WriteLine($"Balance: {MoneyPool} kr");
    }

    // Köper en produkt via det visade numret. Returnerar produkten vid lyckad köp, annars visar de inget.
    public Product Purchase(int productNumber)
    {
        int index = productNumber - 1;
        if (index < 0 || index >= Products.Count)
        {
            Console.WriteLine("Invalid product number.");
            return null;
        }

        var product = Products[index];
        if (MoneyPool < product.Price)
        {
            Console.WriteLine($"Not enough money. Product costs {product.Price} kr, you have {MoneyPool} kr.");
            return null;
        }

        MoneyPool -= product.Price;
        Console.WriteLine($"You bought: {product.Name} for {product.Price} kr. Remaining balance: {MoneyPool} kr");
        return product;
    }

    // Avslutar transaktion och returnera växel
    public int EndTransaction()
    {
        int change = MoneyPool;
        MoneyPool = 0;
        return change;
    }
}