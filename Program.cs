using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    // Lista på alla produkter som finns
    static void Main()
    {
        var products = new List<Product>
        {
            new Drink("Cola", 15),
            new Snack("Chips", 20),
            new Drink("Fanta Exotic", 15),
            new Snack("Chocolate", 20),
            new Toy("Toy car", 67),
            new Toy("Rubber duck", 30),
            new Drink("Water", 10),
            new Snack("Gummy bears", 15),
            new Toy("Talking ben", 50)
        };

        var vm = new VendingMachine(products);

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nWelcome to Jonathans Vending Machine");
            Console.WriteLine("1: Show all the products");
            Console.WriteLine("2: Insert money");
            Console.WriteLine("3: Purchase a product");
            Console.WriteLine("4: Exit the program");
            Console.ResetColor();
            Console.Write("Choose an option: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    vm.ShowProducts();
                    break;

                case 2:
                    Console.Write("Insert coin (5, 10, 20, 50): ");
                    if (int.TryParse(Console.ReadLine(), out int coin))
                    {
                        if (vm.InsertMoney(coin))
                        {
                            Console.WriteLine($"Inserted {coin} kr. Balance: {vm.MoneyPool} kr");
                        }
                        else
                        {
                            Console.WriteLine("Invalid. Only accepts 5, 10, 20, 50 kr.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                    break;

                case 3:
                    vm.ShowProducts();
                    Console.Write("Enter product number to buy: ");
                    if (int.TryParse(Console.ReadLine(), out int productNumber))
                    {
                        var bought = vm.Purchase(productNumber);
                        if (bought != null)
                        {
                            Console.WriteLine(bought.Use());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid number.");
                    }
                    break;

                case 4:
                    int change = vm.EndTransaction();
                    Console.WriteLine($"Transaction ended. Your change: {change} kr. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Choose a valid option (1-4).");
                    break;
            }
        }
    }
}