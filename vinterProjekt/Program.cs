using buildingClass;

float money = 0;
Building empolye = new Building("Employee", 10, 0.1f);
Building empolyes = new Building("Employees", 10, 0.1f);
List<Building> allBuildings = [empolye, empolyes];


static float HavestingResorces(List<Building> allBuildings)
{
    return(1.5f);
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
            BuildingShop(money, allBuildings);
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
static void BuildingShop(float money, List<Building> allBuildings)
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
        else if (pressedKey == ConsoleKey.Enter) {AfordeChecker(money, allBuildings, witchBuilding);}
        else if (pressedKey == ConsoleKey.Escape) { break; }
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
static void AfordeChecker(float money, List<Building> allBuildings, int witchBuilding)
{
    if (allBuildings[witchBuilding].price <= money)
    {
        allBuildings[witchBuilding].amount += 1;
        Console.WriteLine(allBuildings[witchBuilding].amount);
    }
    else
    {
        Console.WriteLine($"allBuilding");
    }
}
static void MoneyGenerator(List<Building> allBuildings)
{    
    while (true)
    {

    }
}
Hub(money, allBuildings);