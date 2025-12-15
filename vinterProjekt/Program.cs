using System.Runtime;
using buildingClass;
int money = 0;
Building empolye = new Building("Empolye", 10, 0.1f);

// Dictionary<int, (string name, int amount, int price, float OPS)> building = new Dictionary<int, (string, int, int, float)>(); //OPS = Ores per second of course. 

// building.Add(1, ("Employe", 0, 10, 0.1f));
// building.Add(2, ("Employew", 0, 10, 0.1f));


static void HavestingResorces(int money, Dictionary<int, (string name, int amount, int price, float OPS)> buildings)
{
    ConsoleKey pressedKey = Console.ReadKey(true).Key;
    if (pressedKey == ConsoleKey.Spacebar)
    {
        money++;
        Console.Clear();
        Console.WriteLine(money);
        Console.WriteLine("Press [H] for hub");
        HavestingResorces(money, buildings);
    }
    else if (pressedKey == ConsoleKey.H)
    {
        Hub(money, buildings);
    }
    else
    {
        HavestingResorces(money, buildings);
    }
}
static void Hub(int money, Dictionary<int, (string name, int amount, int price, float OPS)> buildings)
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
        BuildingShop(money, buildings);
    }
    else if (pressedKey == ConsoleKey.Spacebar)
    {
        HavestingResorces(money, buildings);
    }
    else
    {
        Hub(money, buildings);
    }
}
static void UpgradeShop(int money)
{
    Console.WriteLine(money);

}
// ska nog sätta i hop dem om jag någonsin gör raylib
static void BuildingShop(int money)
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
            if (witchBuilding == buildings.Count)
            {
                Console.WriteLine("You are at the lowest point alredy");
            }
            else
            {
                witchBuilding++;
            }
        }
        else if (pressedKey == ConsoleKey.Enter)
        {
            AfordeChecker(money, buildings, witchBuilding);
        }
        for (int i = 1; i < buildings.Count + 1; i++)
        {
            if (witchBuilding == i)
            {
                Console.WriteLine($">{buildings[i].name}<");
            }
            else
            {
                Console.WriteLine(buildings[i].name);
            }
        }
    }
}
void AfordeChecker(int money, int witchBuilding)
{
    if (buildings[witchBuilding].price <= money)
    {
        empolye.amount += 1;
    }
}
HavestingResorces(money, buildings);
Console.ReadLine();