using System.Runtime;
using buildingClass;
int money = 0;
Building empolye = new Building("Employee", 10, 0.1f);
Building empolyes = new Building("Employees", 10, 0.1f);
List <Building> allBuildings = [empolye, empolyes];

static void HavestingResorces(int money, List<Building> allBuildings)
{
    ConsoleKey pressedKey = Console.ReadKey(true).Key;
    if (pressedKey == ConsoleKey.Spacebar)
    {
        money++;
        Console.Clear();
        Console.WriteLine(money);
        Console.WriteLine("Press [H] for hub");
        HavestingResorces(money, allBuildings);
    }
    else if (pressedKey == ConsoleKey.H)
    {
        Hub(money, allBuildings);
    }
    else
    {
        HavestingResorces(money, allBuildings);
    }
}
static void Hub(int money, List<Building> allBuildings)
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
        BuildingShop(money, allBuildings);
    }
    else if (pressedKey == ConsoleKey.Spacebar)
    {
        HavestingResorces(money, allBuildings);
    }
    else
    {
        Hub(money, allBuildings);
    }
}
static void UpgradeShop(int money)
{
    Console.WriteLine(money);

}
// ska nog sätta i hop dem om jag någonsin gör raylib
static void BuildingShop(int money, List<Building> allBuildings)
{
    int witchBuilding = 0;
    
    while (true)
    {
        ConsoleKey pressedKey = Console.ReadKey(true).Key;
        Console.Clear();
        if (pressedKey == ConsoleKey.UpArrow)
        {
            if (witchBuilding == 0)
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
            if (witchBuilding == allBuildings.Count - 1)
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
            AfordeChecker(money, allBuildings, witchBuilding);
        }
        for (int i = 0; i < allBuildings.Count; i++)
        {
            if (witchBuilding == i)
            {
                Console.WriteLine($">{allBuildings[i].name}<");
            }
            else
            {
                Console.WriteLine(allBuildings[i].name);
            }
        }
    }
}
static void AfordeChecker(int money, List<Building> allBuildings, int witchBuilding)
{
    if (allBuildings[witchBuilding].price <= money)
    {
        allBuildings[witchBuilding].amount += 1;
        Console.WriteLine(allBuildings[witchBuilding].amount);
    }
}
HavestingResorces(money, allBuildings);
Console.ReadLine();