using buildingClass;



static float HavestingResorces(List<Building> allBuildings, int multi, int clickValue)
{
    return (clickValue * multi);
}
static void Hub()
{
    bool wanttorebirth = false;
    int upgradeUnlocked = 1;
    int multi = 1;
    int clickValue = 1;
    int upgradeqouta = 1000;
    int nextRebirthCount = 1;
    int curentRebirthCount = 1;
    float rebirthQuota = 1000000;
    float money = 0;
    float totalMoney = 0;

    List<int> upgradeReached = [1, 1, 1, 1, 1, 1, 1];
    List<int> upgradePrice = [100, 1000, 10000, 20000, 80000, 100000, 1000000];

    List<Building> allBuildings = [];
    allBuildings.Add(new Building("Employee", 10, 0.1f));
    allBuildings.Add(new Building("Farm", 60, 0.5f));
    allBuildings.Add(new Building("Mine", 250, 10f));
    allBuildings.Add(new Building("Factory", 1000, 20f));
    allBuildings.Add(new Building("Bank", 100000, 50f));

    Thread workThread = new Thread(() => MoneyGenerator(allBuildings, ref money, ref totalMoney, curentRebirthCount));
    workThread.Start();
    while (true)
    {
        if (totalMoney >= upgradeqouta)
        {
            upgradeUnlocked++;
            upgradeqouta *= 15 * upgradeUnlocked;
            Console.WriteLine($"you have unlocked level {upgradeUnlocked}");
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
        }
        if (totalMoney >= rebirthQuota)
        {
            nextRebirthCount++;
            rebirthQuota = 1.1f * rebirthQuota + rebirthQuota;
            Console.WriteLine($"You can now rebirth and earn {nextRebirthCount - curentRebirthCount} rebirth score.");
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
        }
        Console.Clear();
        Console.WriteLine("Press [U] for upgrade, [B] for building shop, [I] for information, [Space] to get money, [R] for rebirth meny");
        Console.WriteLine($"You have ${(int)money}"); // Int for i don´t want to have menny decimal numbers
        ConsoleKey pressedKey = Console.ReadKey(true).Key;
        if (pressedKey == ConsoleKey.U)
        {
            UpgradeShop(allBuildings, money, ref upgradePrice, ref upgradeReached, upgradeUnlocked, ref multi, ref clickValue);
        }
        else if (pressedKey == ConsoleKey.B)
        {
            money = BuildingShop(ref money, allBuildings);
        }
        else if (pressedKey == ConsoleKey.Spacebar)
        {
            money += HavestingResorces(allBuildings, multi, clickValue) * (curentRebirthCount / 4 + 1);
            totalMoney += HavestingResorces(allBuildings, multi, clickValue) * (curentRebirthCount / 4 + 1);
        }
        else if (pressedKey == ConsoleKey.I)
        {
            Info();
        }
        else if (pressedKey == ConsoleKey.R)
        {
            wanttorebirth = Rebirth(nextRebirthCount, rebirthQuota, totalMoney, curentRebirthCount);
            if (wanttorebirth == true)
            {
                wanttorebirth = false;
                Reseter(ref clickValue, ref multi, ref upgradeUnlocked, ref upgradeqouta, ref totalMoney, ref money, ref upgradePrice, ref upgradeReached, allBuildings);
            }
        }
    }
}
static float UpgradeShop(List<Building> allBuildings, float money, ref List<int> upgradePrice, ref List<int> upgradeReached, int upgradeUnlocked, ref int multi, ref int clickValue)
{
    int whichUpgrade = -2;
    Console.Clear();
    Console.WriteLine("Press [down arrow] to go down and [Up arrow] to go up");
    Console.WriteLine("Press [esc] to exit to main meny");
    printUpgrade(allBuildings, whichUpgrade, upgradePrice, upgradeReached);
    while (true)
    {
        ConsoleKey pressedKey = Console.ReadKey(true).Key;
        Console.Clear();
        Console.WriteLine("Press [down arrow] to go down and [Up arrow] to go up");
        Console.WriteLine("Press [esc] to exit to main meny");
        if (pressedKey == ConsoleKey.UpArrow)
        {
            if (whichUpgrade == -2) // det är -2 på många ställen för att jag ville ha så Building listan skulle kunna användas på ett enkelt och bra sät.
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
            if (whichUpgrade == upgradePrice.Count - 3)
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
            UpgradeAfordChecker(whichUpgrade, money, ref upgradePrice, allBuildings, ref upgradeReached, upgradeUnlocked, ref multi, ref clickValue);
        }
        else if (pressedKey == ConsoleKey.Escape)
        {
            return (money);
        }
        printUpgrade(allBuildings, whichUpgrade, upgradePrice, upgradeReached);
    }
}
static void printUpgrade(List<Building> allBuildings, int whichUpgrade, List<int> upgradePrice, List<int> upgradeReached)
{
    Console.WriteLine($"     {"Name",-16}{"Price",-15}{"Effect",-18}Upgreaded times"); //man kan göra så effekten är en variabel/ string och dra ner på rader men känns som att de försämrar läsligheten.
    for (int i = -2; i < allBuildings.Count; i++)
    {
        if (i == -2)
        {
            if (whichUpgrade == i)
            {
                Console.WriteLine($">{"Click upgrade<",-20}{upgradePrice[i + 2],-15}{"+$1 click reward",-25}{upgradeReached[i + 2] - 1}");
            }
            else
            {
                Console.WriteLine($" {"Click upgrade",-20}{upgradePrice[i + 2],-15}{"+$1 click reward",-25}{upgradeReached[i + 2] - 1}");
            }
        }
        else if (i == -1)
        {
            if (whichUpgrade == i)
            {
                Console.WriteLine($">{"Click upgrade<",-20}{upgradePrice[i + 2],-15}{"2x click multi",-25}{upgradeReached[i + 2] - 1}");
            }
            else
            {
                Console.WriteLine($" {"Click upgrade",-20}{upgradePrice[i + 2],-15}{"2x click multi",-25}{upgradeReached[i + 2] - 1}");
            }
        }
        else if (whichUpgrade == i)
        {
            Console.WriteLine($">{allBuildings[i].name + "upgrade<",-20}{upgradePrice[i + 2],-15}{"2x MPS",-25}{upgradeReached[i + 2] - 1}");
        }
        else
        {
            Console.WriteLine($" {allBuildings[i].name + "upgrade",-20}{upgradePrice[i + 2],-15}{"2x MPS",-25}{upgradeReached[i + 2] - 1}");
        }
    }
}
static void UpgradeAfordChecker(int whichUpgrade, float money, ref List<int> upgradePrice, List<Building> allBuildings, ref List<int> upgradeReached, int upgradeUnlocked, ref int multi, ref int clickValue)
{
    if (whichUpgrade == -2)// jag hårdkodade in den här delen för jag tror att det skulle vara det enklaste då den inte ska fungera som vanliga upgrades då den ska kunna köpas hella tiden.
    {
        if (upgradePrice[0] <= money)
        {
            clickValue++;
            money -= upgradePrice[0];
            Console.WriteLine($"You spent ${upgradePrice[0]} to get a +$1 for every click, you have ${(int)money} left");
            upgradePrice[0] = (int)(100 * Math.Pow(1.1, upgradeReached[0]));
            upgradeReached[0]++;
        }
        else
        {
            Console.WriteLine($"{(int)(upgradePrice[whichUpgrade + 2] - money)} less then what you need");
        }
    }
    else if (upgradeReached[whichUpgrade + 2] <= upgradeUnlocked)
    {
        if (upgradePrice[whichUpgrade + 2] <= money)
        {
            if (whichUpgrade == -1)
            {
                multi *= 2;
                money -= upgradePrice[whichUpgrade + 2];
                Console.WriteLine($"You spent ${upgradePrice[whichUpgrade + 2]} to get a two times more money for every click, you have ${(int)money} left");
                upgradePrice[whichUpgrade + 2] *= (10);
            }
            else if (whichUpgrade >= 0)
            {
                money -= upgradePrice[whichUpgrade + 2];
                allBuildings[whichUpgrade].MPS *= 2;
                Console.WriteLine($"You spent ${upgradePrice[whichUpgrade + 2]} to get a 2x multiplayer, you have ${(int)money} left");
                upgradePrice[whichUpgrade + 2] *= (10);
            }
            upgradeReached[whichUpgrade + 2]++;
        }
        else
        {
            Console.WriteLine($"{(int)(upgradePrice[whichUpgrade + 2] - money)} less then what you need");
        }
    }
    else
    {
        Console.WriteLine("You can´t upgrade this upgrade more right now");
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
    Console.WriteLine($" {"Name"}{"Price",16}{"Amount",14}{"MPS",14}");
    for (int i = 0; i < allBuildings.Count; i++)
    {
        if (whichBuilding == i)
        {
            Console.WriteLine($">{allBuildings[i].name + "<",-15}{"$" + allBuildings[i].price,-15}{allBuildings[i].amount,-15}{allBuildings[i].MPS}");
        }
        else
        {
            Console.WriteLine($" {allBuildings[i].name,-15}{"$" + allBuildings[i].price,-15}{allBuildings[i].amount,-15}{allBuildings[i].MPS}");
        }
    }
}
static float BuildingAfordeChecker(float money, List<Building> allBuildings, int whichBuilding)
{
    if (allBuildings[whichBuilding].price <= money)
    {
        allBuildings[whichBuilding].amount += 1;
        money -= allBuildings[whichBuilding].price;
        Console.WriteLine($"You spent ${allBuildings[whichBuilding].price} now you have {allBuildings[whichBuilding].amount} {allBuildings[whichBuilding].name} and ${(int)money} left");
        //incresing the price
        allBuildings[whichBuilding].price = (int)(allBuildings[whichBuilding].startPrice * Math.Pow(1.1f, allBuildings[whichBuilding].amount));
    }
    else
    {
        Console.WriteLine($"{(int)(allBuildings[whichBuilding].price - money)} less then what you need");
    }
    return (money);
}
static void MoneyGenerator(List<Building> allBuildings, ref float money, ref float totalMoney, int curentRebirthCount)
{
    while (true)
    {
        for (int i = 0; i < allBuildings.Count; i++)
        {
            money += (allBuildings[i].MPS * allBuildings[i].amount * 0.1f * (curentRebirthCount / 4 + 1));
            totalMoney += (allBuildings[i].MPS * allBuildings[i].amount * 0.1f * (curentRebirthCount / 4 + 1));
        }
        Thread.Sleep(100); // 100ms beacuse I Think that you don´t need to update more often.
    }
}
static void Info()
{
    Console.Clear();
    Console.WriteLine("Earing money:");
    Console.WriteLine("You can earn money buy two ways, you can tap space and pasivly with buildings");
    Console.WriteLine("You buy buildings in the bulding shop, press [B]");
    Console.WriteLine("The money you earn buy pressing space i determen buy your click upgrade its click value*multi\n");
    Console.WriteLine("Upgrades:");
    Console.WriteLine("There are two difrent upgrade types, Building and click upgrades");
    Console.WriteLine("Building upgrades make you earn 2 time more money/ dubles your MPS");
    Console.WriteLine("Click upgrades make you space click earn more money, either multi or click value");
    Console.WriteLine("You need to reatch a new upgrade level to be abel to buy a new upgrade exept for the first click upgrade");
    Console.WriteLine("You can upgrade the first click upgrade how menny times you want without needing to reatch a new upgrade level");
    Console.WriteLine("You upgrade level i determen buy total money earn (like xp), when you go up in level you can upgrade all upgrades one more time\n");
    Console.WriteLine("Meny:");
    Console.WriteLine("You go up on arow up and down on arow down and contine on enter\n");
    Console.WriteLine("Rebirth:");
    Console.WriteLine("Det funkar som ett vanligt rebirth system du blir av med all progres gemtimot att du får enklare pengar på din nya run");
    Console.WriteLine("You don`t need to rebirth as soon as yoiu get the chanse beacuse you can earn more rebirth score (one rebirth score = one rebirth)\n");
    Console.WriteLine("Press enter to go back to the game");
    Console.ReadLine();

}
static bool Rebirth(int nextRebirthCount, float rebirthQuota, float totalMoney, int curentRebirthCount)
{
    bool wanttorebirth;
    Console.WriteLine($"If you rebirth now you will get {nextRebirthCount - curentRebirthCount} rebirth score");
    Console.WriteLine($"you have {curentRebirthCount - 1} rebirth score, and next rebirth is in {(int)rebirthQuota - totalMoney}$ left to rebirth");
    if (curentRebirthCount < nextRebirthCount)
    {
        while (true)
        {
            Console.WriteLine("You can rebirth, press enter enter to rebirth or escape to exit");
            Console.WriteLine($"you will lose all money, upgrades, upgradelevels and anny progress on next rebirth but you will get 1,25 bonus money genegetion");
            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            if (pressedKey == ConsoleKey.Enter)
            {
                curentRebirthCount = nextRebirthCount;
                wanttorebirth = true;
                break;
            }
            else if (pressedKey == ConsoleKey.Escape)
            {
                wanttorebirth = false;
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You need to press enter or escape");
            }
        }
    }
    else
    {
        while (true)
        {

            Console.WriteLine("press Escape to exit");
            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            if (pressedKey == ConsoleKey.Escape)
            {
                wanttorebirth = false;

                break;
            }
            Console.Clear();
        }
    }
    return (wanttorebirth);
}
static void Reseter(ref int clickValue, ref int multi, ref int upgradeUnlocked, ref int upgradeqouta, ref float totalMoney, ref float money, ref List<int> upgradePrice, ref List<int> upgradeReached, List<Building> allBuildings)
{
    clickValue = 1;
    multi = 1;
    upgradeUnlocked = 1;
    upgradeqouta = 1000;
    totalMoney = 0;
    money = 0;
    upgradePrice = [100, 1000, 10000, 20000, 80000, 100000, 1000000];
    upgradeReached = [1, 1, 1, 1, 1, 1, 1];
    for (int i = 0; i < allBuildings.Count; i++)
    {
        allBuildings[i].MPS = allBuildings[i].startMPS;
        allBuildings[i].price = allBuildings[i].startPrice;
        allBuildings[i].amount = 0;
    }
}
Hub();
