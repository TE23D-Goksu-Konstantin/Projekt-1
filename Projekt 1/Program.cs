﻿List<string> weapons = new List<string> { };
List<int> weaponsDmg = new List<int> { };
List<double> weaponsHit = new List<double> { };
List<string> eWeapons = new List<string> { };
List<int> eWeaponsDmg = new List<int> { };
List<double> eWeaponsHit = new List<double> { };
List<int> enemyWeaponsDmg = new List<int> { };
List<int> statBweaponsDmg = new List<int> { 30, 50, 40, 20 };
List<double> statBweaponsHit = new List<double> { .7, .5, .6, 1.0 };

Main();



void Main()
{

    (string eWeapon, int eWeaponDmg, double eWeaponHit) = eWeaponPick();
    eWeapons.Add(eWeapon);                                                 //inputs the enemies randomly chosen weapons + stats for that weapon
    eWeaponsDmg.Add(eWeaponDmg);
    eWeaponsHit.Add(eWeaponHit);


    string name = MainMenu();
    Player p1 = new(100, weaponsDmg[0], weaponsHit[0], weapons[0]);                    //defines a new player to input into the battle method
    MainGame.Battle(p1, name, 100, eWeaponsDmg[0], eWeaponsHit[0], 100);

}

string MainMenu()
{


    string consoleOutput = "Hello adventurer, what should I call you by?";
    Utility.writing(consoleOutput);


    string name = nameP();                      //where the method calls the player names to be chosen
    consoleOutput = $"Greetings {name}!";
    Utility.writing(consoleOutput);
    Thread.Sleep(500);
    Console.Clear();


    (string bWeapon, int bWeaponDmg, double bWeaponHit) = bWeaponPick();
    weapons.Add(bWeapon);                                                     //assigns the chosen weapon + their stats for the player
    weaponsDmg.Add(bWeaponDmg);
    weaponsHit.Add(bWeaponHit);

    consoleOutput = $"{name} chose " + $"{weapons[0]}" + ", now it's time to begin your journey.";   
    Utility.writing(consoleOutput);
    Thread.Sleep(1000);

    return name;             //returns the player chosen name for logistics purposes
}

static string nameP()
{
    while (true)
    {
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name) || int.TryParse(name, out int t))
        {
            string consoleOutput = "Error";                                   //where the player gets to pick their name
            Utility.writing(consoleOutput);
            continue;
        }
        else
        {

            return name;
        }
    }
}

static (string, int, double) bWeaponPick()
{
    while (true)
    {
        List<int> weaponsDmg = new List<int> { Random.Shared.Next(25, 36), Random.Shared.Next(45, 56), Random.Shared.Next(35, 46), Random.Shared.Next(15, 26) };
        List<double> weaponsHit = new List<double> { .7, .5, .6, 1 };
        List<string> bWeapons = new List<string> { "Sword", "Axe", "Bow", "Dagger" };         //all the stats for the player beginner weapons
        
        Console.Clear();
        string consoleOutput = $"Please choose your starter weapon. (1-{bWeapons.Count()})";
        Utility.writing(consoleOutput);


        for (int e = 0; e < bWeapons.Count; e++)
        {
            consoleOutput = $"{e + 1}: " + $"{bWeapons[e]}";          //writes the players weapons
            Utility.writing(consoleOutput);
        }

        string pick = Console.ReadLine();


        if (int.TryParse(pick, out int pickOut) && pickOut <= bWeapons.Count && pickOut >= 1)
        {
            Console.Clear();
            for (int e = 0; e < bWeapons.Count; e++)
                if (pickOut == e + 1)
                {
                    consoleOutput = $"{bWeapons[e]}" + " stats";             //prints all the stats for the weapons
                    Utility.writing(consoleOutput);
                    consoleOutput = $"Damage: {weaponsDmg[e]}";
                    Utility.writing(consoleOutput);
                    consoleOutput = $"Hit chance: {weaponsHit[e] * 100}%";
                    Utility.writing(consoleOutput);
                    consoleOutput = "Are you sure? (y/n)";
                    Utility.writing(consoleOutput);
                    string bWeaponsPickCheck = Console.ReadLine();
                    if (bWeaponsPickCheck.ToLower() == "y")
                    {
                        ;
                        return (bWeapons[e], weaponsDmg[e], weaponsHit[e]);
                    }
                    else if (bWeaponsPickCheck.ToLower() == "n")
                    {
                        continue;
                    }
                    else
                    {
                        consoleOutput = "Error";
                        Utility.writing(consoleOutput);
                        continue;
                    }
                }
        }
        else
        {
            consoleOutput = "Error";
            Utility.writing(consoleOutput);
            continue;
        }
    }
}

static (string, int, double) eWeaponPick()       //same for the players weapons "bWeaponPick" but it is randomly chosen and assigned to the enemy
{
    while (true)
    {

        List<int> weaponsDmg = new List<int> { Random.Shared.Next(25, 36), Random.Shared.Next(45, 56), Random.Shared.Next(35, 46), Random.Shared.Next(15, 26) };
        List<double> weaponsHit = new List<double> { 0.7, 0.5, 0.6, 1.0 };
        List<string> eWeapons = new List<string> { "Sword", "Axe", "Bow", "Dagger" }; 
 
        int randomPick = Random.Shared.Next(0, eWeapons.Count);

        if (randomPick == 1)
        {
            return (eWeapons[0], weaponsDmg[0], weaponsHit[0]);
        }
        else if (randomPick == 2)
        {
            return (eWeapons[1], weaponsDmg[1], weaponsHit[1]);
        }
        else if (randomPick == 3)
        {
            return (eWeapons[2], weaponsDmg[2], weaponsHit[2]);
        }
        else if (randomPick == 3)
        {
            return (eWeapons[3], weaponsDmg[3], weaponsHit[3]);
        }
    }
}

public class Player
{
    public int playerhealth { get; set; }
    public int playerdamage { get; set; }             //all these variables have two properties, get returns the value that set recieves which means that if the weapons has 50dmg set recieves that value which in Main is later assigned to the players stats
    public double playerhitChance { get; set; }       
    public string playerweapon { get; set; }


    public Player(int playerHealth, int playerDamage, double playerHitChance, string playerWeapon)  //same for the class Player goes for this 
    {
        playerhealth = playerHealth;
        playerdamage = playerDamage;
        playerhitChance = playerHitChance;
        playerweapon = playerWeapon;
    }
}

public class EnemyPlayer
{
    public int enemyPlayerhealth { get; set; }
    public int enemyPlayerdamage { get; set; }
    public double enemyPlayerhitChance { get; set; }


    public EnemyPlayer(int enemyPlayerHealth, int enemyPlayerDamage, double enemyPlayerHitChance)
    {
        enemyPlayerhealth = enemyPlayerHealth;
        enemyPlayerdamage = enemyPlayerDamage;
        enemyPlayerhitChance = enemyPlayerHitChance;
    }
}

public class MainGame
{

    static string eNamePicker()
    {
        List<string> eNames = new List<string> {
    "Venom Reaper",
    "Doom Fang Jacob",
    "Goonie Howler Anton",
    "Brainrot Brute Richard",
    "Cursed Stalker",
    "Inferno Wraith Calle",
    "Iron Specter",
    "Night Titan Ludvig",
    "Rotting Ghoul Konstantin",
    "Obsidian Warlock"};
        int eNameRan = Random.Shared.Next(0, eNames.Count+1);      //randomizes an int that later picks one from the list and returns it
        return eNames[eNameRan];
    }


    public static void Battle(Player player, string pName, int hpP, int eWeaponDmg, double eWeaponHit, int hpE)
    {

        EnemyPlayer enemyPlayer = new EnemyPlayer(hpE, eWeaponDmg, eWeaponHit);    //defines enemy players stats
        Utility.Proceed(true);
        Console.Clear();

        string eName = eNamePicker();          //each time this method is played the enemies name is randomized

        string consoleOutput = $"A new foe has appeared, their name's {eName} and they approach you with malicious intent";
        Utility.writing(consoleOutput);
        Thread.Sleep(1000);
        Console.Clear();

        while (hpP > 0 && hpE > 0)
        {
            Console.Clear();

            int maxHP = 100;
            int hpBarsP = (10*hpP)/maxHP;            //calculates remaining health bar(s)
            int hpBarsE = (10*hpE)/maxHP;            

            string hpBarP = new string('█',hpBarsP);           //creates a class that will print out the hpbars depending on the users health
            string hpBarE = new string('█',hpBarsE);           


            consoleOutput = $"{pName}'s HP: " + $"{hpBarP}" + "\n----------------" + "\nWrite Atk to view your attacks"
            + "\nWrite Inv to view your inventory" + "\n----------------";
            Utility.writing(consoleOutput);

            consoleOutput = $"\n\n\n{eName}'s HP: " + $"{hpBarE}" + "\n----------------";            //player and enemies hp + instructions for attacks + viewing inv
            Utility.writing(consoleOutput);


            string battleChoice = Console.ReadLine();
            if (battleChoice.ToLower() == "atk")                //if-statement checking what the user inputs
            {
                Console.Clear();
                consoleOutput = $"{player.playerweapon}: {player.playerdamage} dmg, {player.playerhitChance * 100}% hitchance \n ";
                Utility.writing(consoleOutput);

                consoleOutput = $"\nPick your attack (1)" + /*{player.playerweapon.Count()}, will be used if i decide to add multiple weapons/attacks, therefore it will be a list too*/ "\nWrite 'back' to return ";
                Utility.writing(consoleOutput);
                string checkPick = Console.ReadLine();
                if (checkPick.ToLower() == "back")
                {
                    continue;
                }
                else if (int.TryParse(checkPick, out int e))          //recieves return value of health from both "players" aswell as sending arguments to fightscene
                {
                    (hpE, hpP) = FightScene(player.playerdamage, player.playerhitChance, hpE, hpP, enemyPlayer.enemyPlayerdamage, enemyPlayer.enemyPlayerhitChance, eName);
                }

            }
            else if (battleChoice.ToLower() == "inv")
            {
                Console.Clear();
                consoleOutput = $"{player.playerweapon}"+"\nWrite 'back' to return";       //prints all weapons 
                Utility.writing(consoleOutput);
                string checkPick = Console.ReadLine();
                if (checkPick.ToLower() == "back")
                {
                    continue;
                }
            }
            else
            {
                consoleOutput = "Error";
                Utility.writing(consoleOutput);
            }
            continue;


        }

        if(hpE <= 0)
        {
            consoleOutput = $"{pName}" + " has won the battle!";
            Utility.writing(consoleOutput);
        }
        else if(hpP <= 0)
        {
            consoleOutput = $"{eName}" + " has won the battle!";          //checks who or if both lost
            Utility.writing(consoleOutput);
        }
        else
        {
            consoleOutput = "Draw, both of you ended up killing eachother";
            Utility.writing(consoleOutput);
        }
Console.ReadLine();

    }


    static (int, int) FightScene(int pAttack, double pAttackHit, int hpEnemy, int hpPlayer, int eAttack, double eAttackHit, string EnemyName)
    {
        int Chance = Random.Shared.Next(1, 101);

        if (Chance <= pAttackHit * 100)           //checks whether the users hitchance is bigger, if it is it hits
        {

            hpEnemy -= pAttack;
            string consoleOutput = $"You hit and dealt {pAttack} damage!";
            Utility.writing(consoleOutput);
            Thread.Sleep(1000);
        }
        else
        {
            string consoleOutput = "You missed!";
            Utility.writing(consoleOutput);
            Thread.Sleep(1000);

        }

        Chance = Random.Shared.Next(1, 101);          //randomizes once again so it doesn't repeat itself

        if (Chance <= eAttackHit * 100)
        {
            hpPlayer -= eAttack;
            string consoleOutput = $"{EnemyName} hit and dealt {eAttack} damage!";
            Utility.writing(consoleOutput);
            Thread.Sleep(1000);
        }
        else
        {
            string consoleOutput = $"{EnemyName} missed!";
            Utility.writing(consoleOutput);
            Thread.Sleep(1000);

        }
        Console.Clear();
        return (hpEnemy, hpPlayer);         //returns the health points for both to later be checked if one has lost the game or just change the amount of hpbars

    }
}
class Utility
{

    public static bool Proceed(bool check)
    {

        while (true)
        {
            Console.Clear();
            string consoleOutput = "Are you ready? (y/n)";        //checks user input, if y continue, if n redo the loop
            Utility.writing(consoleOutput);


            string checkC = Console.ReadLine();
            if (checkC.ToLower() == "y")
            {
                return true;
            }
            else if (checkC.ToLower() == "n")
            {
                consoleOutput = "Whenever you're ready.";
                Utility.writing(consoleOutput);
                continue;
            }
            else
            {
                consoleOutput = "Error";
                Utility.writing(consoleOutput);
                continue;
            }
        }
    }

    public static void writing(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);              //prints each word in the string singularily
            Thread.Sleep(30);
        }
        Console.WriteLine();
    }
}


