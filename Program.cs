ShoppingList list = new ShoppingList("items.txt");
list.Load();

while (true)
{
    Console.WriteLine();
    list.Print();
    Console.WriteLine();
    Console.WriteLine("1. Lägg till vara");
    Console.WriteLine("2. Ta bort vara");
    Console.WriteLine("3. Spara");
    Console.WriteLine("4. Sök vara");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj: ");

    string input = Console.ReadLine();

    if (!int.TryParse(input, out int choice))
    {
        Console.WriteLine("Vänligen mata in en siffra.");
        Console.ReadKey();
        continue;
    }

    if (choice == 1)
    {
        Console.Write("Namn: ");
        string name = Console.ReadLine();
        Console.Write("Pris: ");

        int price;
        while(true)
        {
            string priceInput = Console.ReadLine();
            if (int.TryParse(priceInput, out price))
            {
                break;
            }
            Console.Write("Ange priset i siffror: ");
        }

        list.Add(new Item(name, price));
    }
    else if (choice == 2)
    {
        Console.Write("Nummer: ");
        int number;
        while (true)
        {
            string numberInput = Console.ReadLine();
            if (int.TryParse(numberInput, out number))
            {
                break;
            }
            Console.Write("Ange ett nummer i siffror: ");
        }
        list.RemoveAt(number);
    }
    else if (choice == 3)
    {
        list.Save();
    }
    else if (choice == 4)
    {
        Console.Write("Namn att söka efter: ");
        string wanted = Console.ReadLine();
        Item found = list.Find(wanted);

        if (found == null)
        {
            Console.WriteLine("Varan finns inte i listan.");
        }
        else
        {
            Console.WriteLine($"Hittade: {found}");
        }
    }
    else if (choice == 5)
    {
        break;
    }
}
