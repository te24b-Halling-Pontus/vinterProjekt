

Dictionary<string, int> resorces = new Dictionary<string, int>();

resorces.Add("Money", 0);
resorces.Add("Stone", 0);
resorces.Add("Iron", 0);
resorces.Add("Coal", 0);
resorces.Add("Diamond", 0);


static void HavestingResorces(Dictionary<string, int> resources)
{
    ConsoleKey pressedKey = Console.ReadKey(true).Key;
    if (pressedKey == ConsoleKey.Spacebar)
    {
        int i = Random.Shared.Next(101);
        if (i >= 50)
        {
            resources["Stone"] += 1;
        }
        else if (i < 50 && i >= 20)
        {
            resources["Coal"] += 1;
        }
        else if (i < 20 && i > 1)
        {
            resources["Iron"] += 1;
        }
        else if (i == 1)
        {
            resources["Diamond"] += 1;
        }
        Console.Clear();
        Console.WriteLine("Type [H] for hub");
        Console.WriteLine("Stone\tCoal\tIron\tDiamond");
        Console.WriteLine($"{resources["Stone"]}\t{resources["Coal"]}\t{resources["Iron"]}\t{resources["Diamond"]}\t");
        HavestingResorces(resources);
    }
    else if (pressedKey == ConsoleKey.H)
    {
        Hub(resources);
    }
    else
    {
        HavestingResorces(resources);
    }
}
static void Hub(Dictionary<string, int> resources)
{
    Console.WriteLine($"${resources["Money"]}");
    Console.ReadLine();
    HavestingResorces(resources);
}

HavestingResorces(resorces);
Console.ReadLine();