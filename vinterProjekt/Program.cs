using buildingClass;

float money = 0;
float totalMoney = 0;

List<Building> allBuildings = [];
allBuildings.Add(new Building("Employee", 10, 0.1f));
allBuildings.Add(new Building("Employees", 10, 0.1f));

static float HavestingResorces(List<Building> allBuildings)
{
    return (100f);
}
static void Hub(float money, List<Building> allBuildings, float totalMoney)
{
    Thread workThread = new Thread(() => MoneyGenerator(allBuildings, ref money, ref totalMoney));
    workThread.Start();
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Press [U] for upgrade, [B] for building shop, [I] for information, [Space] to get money");
        Console.WriteLine($"You have ${(int)money}"); // Int for i don´t want to have menny decimal numbers
        ConsoleKey pressedKey = Console.ReadKey(true).Key;
        if (pressedKey == ConsoleKey.U)
        {
            UpgradeShop(allBuildings, money);
        }
        else if (pressedKey == ConsoleKey.B)
        {
            money = BuildingShop(ref money, allBuildings);
        }
        else if (pressedKey == ConsoleKey.Spacebar)
        {
            money += HavestingResorces(allBuildings);
            totalMoney += HavestingResorces(allBuildings);
        }
    }
}
static void UpgradeShop(List<Building> allBuildings, float money)
{
    int whichUpgrade = 0;
    printUpgrade(allBuildings, whichUpgrade);
    while (true)
    {
        printUpgrade(allBuildings, whichUpgrade);
    }
}
static void printUpgrade(List<Building> allBuildings, int whichUpgrade)
{
    Console.WriteLine("    Name\tPrice\tEffect");
    for (int i = 0; i < allBuildings.Count; i++)
    {
        if (whichUpgrade == i)
        {
            Console.WriteLine($">{allBuildings[i].name}<");
        }
        else
        {
            Console.WriteLine($"{allBuildings[i].name}");
        }
    }
}
static float BuildingShop(ref float money, List<Building> allBuildings)
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
        Console.WriteLine("Press [down arrow] to go down and [Up arrow] to go up");
        Console.WriteLine("Press [esc] to exit to main meny");
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
    Console.WriteLine("    Name\tPrice\tAmount\tMPS");
    for (int i = 0; i < allBuildings.Count; i++)
    {
        if (whichBuilding == i)
        {
            Console.WriteLine($">{allBuildings[i].name}<\t${allBuildings[i].price}\t{allBuildings[i].amount}\t{allBuildings[i].MPS}");
        }
        else
        {
            Console.WriteLine($" {allBuildings[i].name}\t${allBuildings[i].price}\t{allBuildings[i].amount}\t{allBuildings[i].MPS}");
        }
    }
}
static float AfordeChecker(float money, List<Building> allBuildings, int whichBuilding)
{
    if (allBuildings[whichBuilding].price <= money)
    {
        allBuildings[whichBuilding].amount += 1;
        money -= allBuildings[whichBuilding].price;
        Console.WriteLine($"You spent ${(int)allBuildings[whichBuilding].price} now you have {allBuildings[whichBuilding].amount} {allBuildings[whichBuilding].name}");
        //incresing the price
        allBuildings[whichBuilding].price = (int)(10 * Math.Pow(1.1f, allBuildings[whichBuilding].amount));
    }
    else
    {
        Console.WriteLine($"{(int)allBuildings[whichBuilding].price - money} less then what you need");
    }
    return (money);
}
static void MoneyGenerator(List<Building> allBuildings, ref float money, ref float totalMoney)
{
    while (true)
    {
        for (int i = 0; i < allBuildings.Count; i++)
        {
            money += (allBuildings[i].MPS * allBuildings[i].amount * 0.1f);
            totalMoney += (allBuildings[i].MPS * allBuildings[i].amount * 0.1f);
        }
        Thread.Sleep(100); // 100ms beacuse I Think that you don´t need to update more often.
    }
}
Hub(money, allBuildings, totalMoney);