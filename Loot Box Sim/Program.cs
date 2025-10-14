//Floats and Strings
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
int Balance = 100;
int LootRandomizer = 1;
int BaseRarityChance = 1;
int LoopCount = 0;
string RolledLoot = "";
int RolledValue = 1;
string RolledItemRarityAndName = "";
string Rolledrarity = "";
int RolledMultiplier = 1;
string Choice = "";
string FirstChoice = "";

List<string> Inventory = new List<string>();
List<int> BalanceList = new List<int>();
List<int> Inventory_Value = new List<int>();
List<string> Empty = new List<string>();

//Save Creating
if (!File.Exists(@"SavedItems.txt"))
{
    var a = File.Create(@"SavedItems.txt");
    a.Close();
}
if (!File.Exists(@"SavedValues.txt"))
{
    var a = File.Create(@"SavedValues.txt");
    a.Close();
}
if (!File.Exists(@"SavedBalance.txt"))
{
    var a = File.Create(@"SavedBalance.txt");
    a.Close();
    File.WriteAllText(@"SavedBalance.txt", "100");
    a.Close();
}

//Save Loading
Inventory = File.ReadAllLines(@"SavedItems.txt").ToList();
Inventory_Value = File.ReadAllLines(@"SavedValues.txt").Select(x => Convert.ToInt32(x)).ToList();
BalanceList = File.ReadAllLines(@"SavedBalance.txt").Select(x => Convert.ToInt32(x)).ToList();
Balance = BalanceList[0];



//Possible Weapons
Weapon Sword = new Weapon()
{
    Name = "Sword",
    BaseValue = 10
};
Weapon Bow = new Weapon()
{
    Name = "Bow",
    BaseValue = 15
};
Weapon Axe = new Weapon()
{
    Name = "Axe",
    BaseValue = 20
};
Weapon Wand = new Weapon()
{
    Name = "Magic Wand",
    BaseValue = 25
};

String[] Weapons = { Sword.Name, Bow.Name, Axe.Name, Wand.Name };




//Possible Rarities
Rarity Common = new Rarity()
{
    Name = "Common",
    ValueMultiplier = 1
};
Rarity Rare = new Rarity()
{
    Name = "Rare",
    ValueMultiplier = 2
};
Rarity Epic = new Rarity()
{
    Name = "Epic",
    ValueMultiplier = 5
};
Rarity Legendary = new Rarity()
{
    Name = "Legendary",
    ValueMultiplier = 10
};
Rarity Mythic = new Rarity()
{
    Name = "Mythic",
    ValueMultiplier = 100
};

string[] Rarities = { Common.Name, Rare.Name, Epic.Name, Mythic.Name };




Console.WriteLine("Welcome to OVERWATCH GAMBLING SIM 2025");
Console.WriteLine("In this game you start with 100 dollars and play to win it big");
Thread.Sleep(100);

while (Balance >= 20 || Inventory.Count > 0)
{
    Console.WriteLine($"You have {Balance} dollars");
    Console.WriteLine(
    @"Do you wish to: 
    1.Open a lootbox
    2.Open Inventory
    ");
    FirstChoice = Console.ReadLine();
    while (FirstChoice != "1" && FirstChoice != "2")
    {
        Console.WriteLine("Invalid choice, please try again");
        FirstChoice = Console.ReadLine();
    }
    if (FirstChoice == "1")
    {
        Console.WriteLine("Which type of lootbox do you wish to open?");
        Console.WriteLine("1. Weapon lootbox (20$)");
        Console.WriteLine("2. Armor lootbox (150$) (Not Implemented)");
        Console.WriteLine("3. Go back");
        Choice = Console.ReadLine();
        while (Choice != "1" && Choice != "2" && Choice != "3")
        {
            Console.WriteLine("Invalid choice, please try again");
            Choice = Console.ReadLine();
        }

        while (Choice == "1" && Balance <= 20)
        {
            Console.WriteLine("You could not afford this lootbox");
        }

        //Loot Rarity
        int RarityRandomizer = Random.Shared.Next(BaseRarityChance, 850);

        if (RarityRandomizer <= 500)
        {
            Rolledrarity = Common.Name;
            RolledMultiplier = Common.ValueMultiplier;
        }
        if (RarityRandomizer >= 501 && RarityRandomizer <= 700)
        {
            Rolledrarity = Rare.Name;
            RolledMultiplier = Rare.ValueMultiplier;
        }
        if (RarityRandomizer >= 701 && RarityRandomizer <= 800)
        {
            Rolledrarity = Epic.Name;
            RolledMultiplier = Epic.ValueMultiplier;
        }
        if (RarityRandomizer >= 801 && RarityRandomizer <= 849)
        {
            Rolledrarity = Legendary.Name;
            RolledMultiplier = Legendary.ValueMultiplier;
        }
        if (RarityRandomizer == 850)
        {
            Rolledrarity = Mythic.Name;
            RolledMultiplier = Mythic.ValueMultiplier;
        }

        //Weapon Lootbox
        if (Choice == "1")
        {
            //Weapon Randomizer
            Balance -= 20;
            LootRandomizer = Random.Shared.Next(1, 1000);
            if (LootRandomizer <= 400)
            {
                RolledLoot = Sword.Name;
                RolledValue = Sword.BaseValue;
            }
            if (LootRandomizer > 400 && LootRandomizer < 700)
            {
                RolledLoot = Bow.Name;
                RolledValue = Bow.BaseValue;
            }
            if (LootRandomizer >= 700 && LootRandomizer < 900)
            {
                RolledLoot = Axe.Name;
                RolledValue = Axe.BaseValue;
            }
            if (LootRandomizer >= 900 && LootRandomizer <= 1000)
            {
                RolledLoot = Wand.Name;
                RolledValue = Wand.BaseValue;
            }
            //Logic
            RolledValue = RolledValue * RolledMultiplier;
            RolledItemRarityAndName = $"{Rolledrarity} {RolledLoot}";

            //Rolling Animation
            Console.Clear();
            while (LoopCount < 15)
            {
                string RandomRarity;
                RandomRarity = Rarities[Random.Shared.Next(0, Rarities.Length)];
                Console.WriteLine(RandomRarity);
                // if (RandomRarity == Common.Name)
                // {
                //     Console.BackgroundColor = ConsoleColor.DarkGray;
                // }
                // if (RandomRarity == Rare.Name)
                // {
                //     Console.BackgroundColor = ConsoleColor.Blue;
                // }
                // if (RandomRarity == Epic.Name)
                // {
                //     Console.BackgroundColor = ConsoleColor.Magenta;
                // }
                // if (RandomRarity == Legendary.Name)
                // {
                //     Console.BackgroundColor = ConsoleColor.Yellow;
                // }
                // if (RandomRarity == Mythic.Name)
                // {
                //     Console.BackgroundColor = ConsoleColor.Red;
                // }
                Thread.Sleep(300);
                Console.Clear();
                LoopCount++;
            }
            Thread.Sleep(400);
            // if (Rolledrarity == Common.Name)
            // {
            //     Console.BackgroundColor = ConsoleColor.DarkGray;
            // }
            // if (Rolledrarity == Rare.Name)
            // {
            //     Console.BackgroundColor = ConsoleColor.Blue;
            // }
            // if (Rolledrarity == Epic.Name)
            // {
            //     Console.BackgroundColor = ConsoleColor.Magenta;
            // }
            // if (Rolledrarity == Legendary.Name)
            // {
            //     Console.BackgroundColor = ConsoleColor.Yellow;
            // }
            // if (Rolledrarity == Mythic.Name)
            // {
            //     Console.BackgroundColor = ConsoleColor.Red;
            // }
            Console.WriteLine(Rolledrarity);
            
            Thread.Sleep(1000);
            LoopCount = 0;
            Console.Clear();

            while (LoopCount < 15)
            {
                Console.WriteLine($"{Rolledrarity} {Weapons[Random.Shared.Next(0, Weapons.Length)]}");
                Thread.Sleep(300);
                Console.Clear();
                LoopCount++;
            }
            Console.WriteLine($"{Rolledrarity} {RolledLoot}");
            Thread.Sleep(1000);
            Console.Clear();
            LoopCount = 0;
            Thread.Sleep(1000);
            Console.BackgroundColor = ConsoleColor.Black;

            //Restart
            Console.WriteLine($"You got a {RolledItemRarityAndName} which is worth {RolledValue}");
            Console.WriteLine(@"Do you wish to: 
            1. Sell it
            2. Keep it
            ");
            Choice = Console.ReadLine();
            if (Choice == "1")
            {
                Balance += RolledValue;
            }
            if (Choice == "2")
            {
                Inventory.Add(RolledItemRarityAndName);
                Inventory_Value.Add(RolledValue);
            }
            Thread.Sleep(1000);
            Console.Clear();
        }
    }


    if (FirstChoice == "2")
    {
        Console.Clear();
        for (int i = 0; i < Inventory.Count; i++)
        {
            Console.WriteLine($"{i}. {Inventory[i]} worth {Inventory_Value[i]}$");
        }
        Console.WriteLine("Which item do you wish to sell?");
        Console.WriteLine("If you do not wish to sell any item, type exit");
        if (int.TryParse(Console.ReadLine(), out int InventorySlot))
        {
            if (InventorySlot <= Inventory.Count)
            {
                Console.WriteLine($"You sold {Inventory[InventorySlot]} for {Inventory_Value[InventorySlot]}$");
                Balance += Inventory_Value[InventorySlot];
                Inventory.RemoveAt(InventorySlot);
                Inventory_Value.RemoveAt(InventorySlot);
                Thread.Sleep(1000);

            }
        }
        Console.Clear();
    }

    Thread.Sleep(200);
    File.WriteAllLines(@"SavedItems.txt", Inventory);
    File.WriteAllLines(@"SavedValues.txt", Inventory_Value.ConvertAll<string>(delegate (int i) { return i.ToString(); }));
    File.WriteAllText(@"SavedBalance.txt", Balance.ToString());
    
    
    
}
Console.WriteLine("You are out of items and monney");
Console.WriteLine("Type RESET to reset account or Exit to leave");
Choice = Console.ReadLine();
if (Choice == "RESET")
{
    File.WriteAllLines("@SavedItems.txt", Empty);
    File.WriteAllLines("SavedValues.txt", Empty);
}