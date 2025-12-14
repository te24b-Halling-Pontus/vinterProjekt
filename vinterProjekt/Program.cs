// Dictionary<string, int> resources = new Dictionary<string, int>();

// resources.Add("Money", 0);
// resources.Add("Stone", 0);
// resources.Add("Iron", 0);
// resources.Add("Coal", 0);
// resources.Add("Diamond", 0);
// Hard to do, maybe later.
int money = 0;

Dictionary<int, (string Name, int Amount, int price, float OPS)> building = new Dictionary<int, (string, int, int, float)>(); //OPS = Ores per second of course. 

building.Add(1, ("Employe", 0, 10, 0.1f));
building.Add(2, ("Employew", 0, 10, 0.1f));

static void HavestingResorces(int money, Dictionary<int, (string Name, int Amount, int price, float OPS)> building)
{
    ConsoleKey pressedKey = Console.ReadKey(true).Key;
    if (pressedKey == ConsoleKey.Spacebar)
    {
        money++;
        Console.Clear();
        Console.WriteLine(money);
        Console.WriteLine("Press [H] for hub");
        HavestingResorces(money, building);
    }
    else if (pressedKey == ConsoleKey.H)
    {
        Hub(money, building);
    }
    else
    {
        HavestingResorces(money, building);
    }
}
static void Hub(int money, Dictionary<int, (string Name, int Amount, int price, float OPS)> building)
{
    Console.Clear();
    Console.WriteLine("Press [U] for upgrade, [B] for bildning shop, [I] for information, [Space] to go back to clicker");
    ConsoleKey pressedKey = Console.ReadKey(true).Key;
    if (pressedKey == ConsoleKey.U)
    {
        UpgradeShop(money);
    }
    else if (pressedKey == ConsoleKey.B)
    {
        BuildingShop(money, building);
    }
    else if (pressedKey == ConsoleKey.Spacebar)
    {
        HavestingResorces(money, building);
    }
    else
    {
        Hub(money, building);
    }
}
static void UpgradeShop(int money)
{
    Console.WriteLine(money);

}
// ska nog sätta i hop dem om jag någonsin gör raylib
static void BuildingShop(int money, Dictionary<int, (string Name, int Amount, int price, float OPS)> building)
{
    int witchBuilding = 1;
    while (true)
    {
        ConsoleKey pressedKey = Console.ReadKey(true).Key;
        Console.Clear();
        if (pressedKey == ConsoleKey.UpArrow)
        {
            if (witchBuilding == 1)
            {
                Console.WriteLine("You are at the higest point alredy");
            }
            else
            {
                witchBuilding--;
            }
        }
        else if (pressedKey == ConsoleKey.DownArrow)
        {
            if (witchBuilding == building.Count)
            {
                Console.WriteLine("You are at the lowest point alredy");
            }
            else
            {
                witchBuilding++;
            }
        }
        for (int i = 1; i < building.Count + 1; i++)
        {
            if (witchBuilding == i)
            {
                Console.WriteLine($">{building[i].Name}<");
            }
            else
            {
                Console.WriteLine(building[i].Name);
            }
        }
    }
}
HavestingResorces(money, building);
Console.ReadLine();