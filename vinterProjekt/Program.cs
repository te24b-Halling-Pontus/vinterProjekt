using buildingClass;

float money = 0;
Building empolye = new Building("Employee", 10, 0.1f);
Building empolyes = new Building("Employees", 10, 0.1f);
List<Building> allBuildings = [empolye, empolyes];


static float HavestingResorces(List<Building> allBuildings)
{
    return (100f);
}
static void Hub(float money, List<Building> allBuildings)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Press [U] for upgrade, [B] for bildning shop, [I] for information, [Space] to go back to clicker");
        Console.WriteLine($"You have ${(int)money}");
        ConsoleKey pressedKey = Console.ReadKey(true).Key;
        if (pressedKey == ConsoleKey.U)
        {
            UpgradeShop(money);
        }
        else if (pressedKey == ConsoleKey.B)
        {
            money = BuildingShop(money, allBuildings);
        }
        else if (pressedKey == ConsoleKey.Spacebar)
        {
            money += HavestingResorces(allBuildings);
        }
    }
}
static void UpgradeShop(float money)
{
    Console.WriteLine(money);
}
// ska nog sätta i hop dem om jag någonsin gör raylib
static float BuildingShop(float money, List<Building> allBuildings)
{
    int witchBuilding = 0;
    while (true)
    {
        Console.WriteLine("Press [esc] to exit to main meny");
        Console.WriteLine(money);
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
            money = AfordeChecker(money, allBuildings, witchBuilding);
        }
        else if (pressedKey == ConsoleKey.Escape)
        {
            return (money);
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
static float AfordeChecker(float money, List<Building> allBuildings, int witchBuilding)
{
    if (allBuildings[witchBuilding].price <= money)
    {
        allBuildings[witchBuilding].amount += 1;
        money -= allBuildings[witchBuilding].price;
        Console.WriteLine(money);
        Console.WriteLine($"You spent ${allBuildings[witchBuilding].price} now you have {allBuildings[witchBuilding].amount} {allBuildings[witchBuilding].name}");
    }
    else
    {
        Console.WriteLine($"{allBuildings[witchBuilding].price - money} less then what you need");
    }
    return(money);
}
static void MoneyGenerator(List<Building> allBuildings)
{
    while (true)
    {

    }
}
Hub(money, allBuildings);