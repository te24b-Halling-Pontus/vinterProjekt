Dictionary<string, int> resources = new Dictionary<string, int>();

resources.Add("Money", 0);
resources.Add("Stone", 0);
resources.Add("Iron", 0);
resources.Add("Coal", 0);
resources.Add("Diamond", 0);

Dictionary<string, (int Amount, int price, float OPS)> building = new Dictionary<string, (int, int, float)>(); //OPS = Ores per second of course. 


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
    ConsoleKey pressedKey = Console.ReadKey(true).Key;
    if (pressedKey == ConsoleKey.U)
    {
        UpgradeShop(resources);
    }
    else if (pressedKey == ConsoleKey.B)
    {
        BuildingShop(resources);
    }
    Hub(resources);
}
static void UpgradeShop(Dictionary<string, int> resources)
{
    Console.WriteLine($"${resources["Money"]}");

}
// ska nog sätta i hop dem om jag någonsin gör raylib
static void BuildingShop(Dictionary<string, int> resources)
{
    ConsoleKey pressedKey = Console.ReadKey(true).Key;
    Console.WriteLine("");
    int witchBuilding = 1;
    if (pressedKey == ConsoleKey.UpArrow)
    {
        if (witchBuilding)
        witchBuilding++;
    }
    else if (pressedKey == ConsoleKey.DownArrow)
    {
        witchBuilding--;
    }
}
HavestingResorces(resources);
Console.ReadLine();