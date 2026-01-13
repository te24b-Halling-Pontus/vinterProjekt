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
static float UpgradeShop(List<Building> allBuildings, float money)
{
    List<int> upgardePrice = [100, 1000, 10000, 10000, 10000];
    int whichUpgrade = -1;
    Console.Clear();
    Console.WriteLine("Press [down arrow] to go down and [Up arrow] to go up");
    Console.WriteLine("Press [esc] to exit to main meny");
    printUpgrade(allBuildings, whichUpgrade, upgardePrice);
    while (true)
    {
        ConsoleKey pressedKey = Console.ReadKey(true).Key;
        Console.Clear();
        Console.WriteLine("Press [down arrow] to go down and [Up arrow] to go up");
        Console.WriteLine("Press [esc] to exit to main meny");
        if (pressedKey == ConsoleKey.UpArrow)
        {
            if (whichUpgrade == -1)
            {
                Console.WriteLine("You are at the higest point alredy");
            }
            else
            {
                whichUpgrade--;
            }
        }
        else if (pressedKey == ConsoleKey.DownArrow)
        {
            if (whichUpgrade == allBuildings.Count - 1)
            {
                Console.WriteLine("You are at the lowest point alredy");
            }
            else
            {
                whichUpgrade++;
            }
        }
        else if (pressedKey == ConsoleKey.Enter)
        {
            UpgradeAfordChecker(whichUpgrade, money, ref upgardePrice, allBuildings);
        }
        else if (pressedKey == ConsoleKey.Escape)
        {
            return (money);
        }
        printUpgrade(allBuildings, whichUpgrade, upgardePrice);
    }
}
static void printUpgrade(List<Building> allBuildings, int whichUpgrade, List<int> upgradePrice)
{
    Console.WriteLine("    Name\tPrice\tEffect");
    for (int i = -1; i < allBuildings.Count; i++)
    {
        if (i == -1)
        {
            if (whichUpgrade == i)
            {
                Console.WriteLine($">Click upgrade<\t{upgradePrice[i + 1]}\t2x click reward");
            }
            else
            {
                Console.WriteLine($"Click upgrade\t{upgradePrice[i + 1]}\t2x click reward");
            }
        }
        else if (whichUpgrade == i)
        {
            Console.WriteLine($">{allBuildings[i].name} upgrade<\t{upgradePrice[i]}\t2x MPS");
        }
        else
        {
            Console.WriteLine($"{allBuildings[i].name} upgrade\t{upgradePrice[i]}\t2x MPS");
        }
    }
}
static void UpgradeAfordChecker(int whichUpgrade, float money, ref List<int> upgradePrice, List<Building> allBuildings)
{
    if (upgradePrice[whichUpgrade + 1] <= money)
    {
        allBuildings[whichUpgrade].MPS *= 2;
        money -= upgradePrice[whichUpgrade + 1];
        Console.WriteLine($"You spent ${upgradePrice[whichUpgrade]} to get a 2x muiltiplayer, you have ${money} left");
        upgradePrice[whichUpgrade + 1] *= (int)();
    }
    else
    {
        Console.WriteLine($"{(int)(upgradePrice[whichUpgrade] - money)} less then what you need");
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
            money = BuildingAfordeChecker(money, allBuildings, whichBuilding);
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
static float BuildingAfordeChecker(float money, List<Building> allBuildings, int whichBuilding)
{
    if (allBuildings[whichBuilding].price <= money)
    {
        allBuildings[whichBuilding].amount += 1;
        money -= allBuildings[whichBuilding].price;
        Console.WriteLine($"You spent ${allBuildings[whichBuilding].price} now you have {allBuildings[whichBuilding].amount} {allBuildings[whichBuilding].name}");
        //incresing the price
        allBuildings[whichBuilding].price *= (int)(10 * Math.Pow(1.1f, allBuildings[whichBuilding].amount));
    }
    else
    {
        Console.WriteLine($"{(int)(allBuildings[whichBuilding].price - money)} less then what you need");
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