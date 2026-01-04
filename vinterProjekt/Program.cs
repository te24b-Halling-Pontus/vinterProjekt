using buildingClass;
using Raylib_cs;

float money = 0;
List<Building> allBuildings = [];
allBuildings.Add(new Building("Employee", 10, 0.1f));
allBuildings.Add(new Building("Employees", 10, 0.1f));

static float HavestingResorces(List<Building> allBuildings)
{
    return (100f);
}
static void Hub(float money, List<Building> allBuildings)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine(MoneyGenerator(allBuildings));
        Console.WriteLine("Press [U] for upgrade, [B] for building shop, [I] for information, [Space] to get money");
        Console.WriteLine($"You have ${(int)money}"); // Int for i don´t want to have menny decimal numbers
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
        // money += MoneyGenerator(allBuildings);
    }
}
static void UpgradeShop(float money)
{
    Console.WriteLine(money);
}
// ska nog sätta i hop dem om jag någonsin gör raylib
static float BuildingShop(float money, List<Building> allBuildings)
{
    int whichBuilding = 0;
    Console.Clear();
    Console.WriteLine("Press [down arrow] to go down and [Up arrow] to go up");
    Console.WriteLine("Press [esc] to exit to main meny");
    PrintBuilding(whichBuilding, allBuildings);
    while (true)
    {
        ConsoleKey pressedKey = Console.ReadKey(true).Key;
        Console.Clear();
        if (pressedKey == ConsoleKey.UpArrow)
        {
            if (whichBuilding == 0)
            {
                Console.WriteLine("You are at the higest point alredy");
            }
            else
            {
                whichBuilding--;
            }
        }
        else if (pressedKey == ConsoleKey.DownArrow)
        {
            if (whichBuilding == allBuildings.Count - 1)
            {
                Console.WriteLine("You are at the lowest point alredy");
            }
            else
            {
                whichBuilding++;
            }
        }
        else if (pressedKey == ConsoleKey.Enter)
        {
            money = AfordeChecker(money, allBuildings, whichBuilding);
        }
        else if (pressedKey == ConsoleKey.Escape)
        {
            return (money);
        }
        PrintBuilding(whichBuilding, allBuildings);
    }
}
static void PrintBuilding(int whichBuilding, List<Building> allBuildings)
{
    for (int i = 0; i < allBuildings.Count; i++)
    {
        if (whichBuilding == i)
        {
            Console.WriteLine($">{allBuildings[i].name}<");
        }
        else
        {
            Console.WriteLine($" {allBuildings[i].name} ");
        }
    }
}
static float AfordeChecker(float money, List<Building> allBuildings, int whichBuilding)
{
    if (allBuildings[whichBuilding].price <= money)
    {
        allBuildings[whichBuilding].amount += 1;
        money -= allBuildings[whichBuilding].price;
        Console.WriteLine($"You spent ${allBuildings[whichBuilding].price} now you have {allBuildings[whichBuilding].amount} {allBuildings[whichBuilding].name}");
    }
    else
    {
        Console.WriteLine($"{allBuildings[whichBuilding].price - money} less then what you need");
    }
    return (money);
}
static float MoneyGenerator(List<Building> allBuildings )
{
    while (true)
    {
        float timewaited =+ Raylib.GetFrameTime();
        Console.WriteLine(timewaited);
        if (timewaited <= 0.1f)
        {
            for (int i = 0; i < allBuildings.Count; i++)
            {
                timewaited = 0;
                Console.WriteLine(allBuildings[i].OPS * allBuildings[i].amount * 0.1f);
                return (allBuildings[i].OPS * allBuildings[i].amount * 0.1f);
            }
        }
    }
}
Hub(money, allBuildings);