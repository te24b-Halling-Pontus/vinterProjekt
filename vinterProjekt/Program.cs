// Dictionary<string, int> resources = new Dictionary<string, int>();

// resources.Add("Money", 0);
// resources.Add("Stone", 0);
// resources.Add("Iron", 0);
// resources.Add("Coal", 0);
// resources.Add("Diamond", 0);
// Hard to do, maybe later.
int money = 0;

Dictionary<string, (int Amount, int price, float OPS)> building = new Dictionary<string, (int, int, float)>(); //OPS = Ores per second of course. 

building.Add("Mining drill lv1", (0, 10, 0.1f));

static void HavestingResorces(int money, Dictionary<string, (int Amount, int price, float OPS)> buldings)
{
    ConsoleKey pressedKey = Console.ReadKey(true).Key;
    if (pressedKey == ConsoleKey.Spacebar)
    {
        money++;
        Console.Clear();
        Console.WriteLine("Type [H] for hub");
        HavestingResorces(money, buldings);
    }
    else if (pressedKey == ConsoleKey.H)
    {
        Hub(money, buldings);
    }
    else
    {
        HavestingResorces(money, buldings);
    }
}
static void Hub(int money, Dictionary<string, (int Amount, int price, float OPS)> buldings)
{
    ConsoleKey pressedKey = Console.ReadKey(true).Key;
    if (pressedKey == ConsoleKey.U)
    {
        UpgradeShop(money);
    }
    else if (pressedKey == ConsoleKey.B)
    {
        BuildingShop(money, buldings);
    }
    Hub(money, buldings);
}
static void UpgradeShop(int money)
{
    Console.WriteLine(money);

}
// ska nog sätta i hop dem om jag någonsin gör raylib
static void BuildingShop(int money, Dictionary<string, (int Amount, int price, float OPS)> buldings)
{
    ConsoleKey pressedKey = Console.ReadKey(true).Key;
    int witchBuilding = 1;
    if (pressedKey == ConsoleKey.UpArrow)
    {
        if (witchBuilding >= 5)
        {
            Console.WriteLine("You are at the higest point alredy");
        }
        else
        {
            witchBuilding++;
        }
    }
    else if (pressedKey == ConsoleKey.DownArrow)
    {
        if(witchBuilding >= 1)
        {
            Console.WriteLine("You are at the lowest point alredy");
        }
        else
        {
            witchBuilding--;
        }
    }
}
HavestingResorces(money, building);
Console.ReadLine();