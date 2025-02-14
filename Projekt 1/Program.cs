List<string> weapons = new List<string> { };
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

    // while()
    (string eWeapon, int eWeaponDmg, double eWeaponHit) = eWeaponPick();
    eWeapons.Add(eWeapon);
    eWeaponsDmg.Add(eWeaponDmg);
    eWeaponsHit.Add(eWeaponHit);


    string name = MainMenu();
    Player p1 = new(100, weaponsDmg[0], weaponsHit[0], weapons[0]);
    MainGame.Battle(p1, name, 100, eWeaponsDmg[0], eWeaponsHit[0], 100);
    // int hp = 100;
    // Player player = new Player(hp, weaponsDmg[0], weaponsHit[0]);
    // EnemyPlayer enemyPlayer = new EnemyPlayer(hp, eWeaponsDmg[0], eWeaponsHit[0]); 


    // Console.WriteLine($"Your health: {enemyPlayer.enemyPlayerhealth}, Your damage: {enemyPlayer.enemyPlayerdamage}, Your hitchance: {enemyPlayer.enemyPlayerhitChance}");
    // Console.WriteLine($"Your health: {player.playerhealth}, Your damage: {player.playerdamage}, Your hitchance: {player.playerhitChance}");
    // Console.ReadLine();

}




string MainMenu()
{


    string consoleOutput = "Hello adventurer, what should I call you by?";
    Utility.writing(consoleOutput);


    string name = nameP();
    consoleOutput = $"Greetings {name}!";
    Utility.writing(consoleOutput);
    Thread.Sleep(500);
    Console.Clear();


    (string bWeapon, int bWeaponDmg, double bWeaponHit) = bWeaponPick();
    weapons.Add(bWeapon);
    weaponsDmg.Add(bWeaponDmg);
    weaponsHit.Add(bWeaponHit);

    consoleOutput = $"{name} chose " + $"{weapons[0]}" + ", now it's time to begin your journey.";
    Utility.writing(consoleOutput);
    Thread.Sleep(1000);

    return name;
}

static string nameP()
{
    while (true)
    {
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name) || int.TryParse(name, out int t))
        {
            string consoleOutput = "Error";
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
        Console.Clear();
        string consoleOutput = "Please choose your starter weapon.";
        Utility.writing(consoleOutput);


        List<int> weaponsDmg = new List<int> { Random.Shared.Next(25, 36), Random.Shared.Next(45, 56), Random.Shared.Next(35, 46), Random.Shared.Next(15, 26) };
        List<double> weaponsHit = new List<double> { .7, .5, .6, 1 };
        List<string> bWeapons = new List<string> { "Sword", "Axe", "Bow", "Dagger" };
        for (int e = 0; e < bWeapons.Count; e++)
        {
            consoleOutput = $"{e + 1}: " + $"{bWeapons[e]}";
            Utility.writing(consoleOutput);
        }

        string pick = Console.ReadLine();


        if (int.TryParse(pick, out int pickOut) && pickOut <= bWeapons.Count && pickOut >= 1)
        {
            Console.Clear();
            for (int e = 0; e < bWeapons.Count; e++)
                if (pickOut == e + 1)
                {
                    consoleOutput = $"{bWeapons[e]}" + " stats";
                    Utility.writing(consoleOutput);
                    consoleOutput = $"Damage: {weaponsDmg[e]}";
                    Utility.writing(consoleOutput);
                    consoleOutput = $"Hit chance: {weaponsHit[e] * 100}";
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

static (string, int, double) eWeaponPick()
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
    public int playerdamage { get; set; }
    public double playerhitChance { get; set; }
    public string playerweapon { get; set; }


    public Player(int playerHealth, int playerDamage, double playerHitChance, string playerWeapon)
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
    "Shadow Brute Richard",
    "Cursed Stalker",
    "Inferno Wraith Calle",
    "Iron Specter",
    "Night Titan Ludvig",
    "Rotting Ghoul Konstantin",
    "Obsidian Warlock"};
        int eNameRan = Random.Shared.Next(0, eNames.Count);
        return eNames[eNameRan];
    }


    public static void Battle(Player player, string pName, int hpP, int eWeaponDmg, double eWeaponHit, int hpE)
    {
        EnemyPlayer enemyPlayer = new EnemyPlayer(hpE, eWeaponDmg, eWeaponHit);
        Utility.Proceed(true);
        Console.Clear();

        string eName = eNamePicker();

        string consoleOutput = $"A new foe has appeared, their name's {eName} and they approach you with malicious intent";
        Utility.writing(consoleOutput);
        Thread.Sleep(1000);
        Console.Clear();

        while (hpP <= 100 && hpP > 0)
        {


            consoleOutput = $"{pName}'s HP: " + """██████████""" + "\n----------------" + "\nWrite Atk to view your attacks"
            + "\nWrite Inv to view your inventory" + "\n----------------";
            Utility.writing(consoleOutput);

            consoleOutput = $"\n\n\n{eName}'s HP: " + """██████████""";
            Utility.writing(consoleOutput);


            string battleChoice = Console.ReadLine();
            if (battleChoice.ToLower() == "atk")
            {
                consoleOutput = $"{player.playerweapon}: {player.playerdamage} dmg, {player.playerhitChance * 100}% hitchance \n ";
                Utility.writing(consoleOutput);

                consoleOutput = $"\nPick your attack (1-{player.playerweapon.Count()})\nWrite 'back' to return ";
                Utility.writing(consoleOutput);
                string checkPick = Console.ReadLine();
                if (checkPick.ToLower() == "back")
                {
                    Console.Clear();
                    continue;
                }
                else if (int.TryParse(checkPick, out int e))
                {
                    FightScene(player.playerdamage, player.playerhitChance, hpE, hpP, enemyPlayer.enemyPlayerdamage, enemyPlayer.enemyPlayerhitChance, eName);
                }

            }
            else if (battleChoice.ToLower() == "inv")
            {
                consoleOutput = $"{player.playerweapon} \n ";
                Utility.writing(consoleOutput);
            }
            else
            {
                consoleOutput = "Error";
                Utility.writing(consoleOutput);
            }
            battleChoice = Console.ReadLine();


        }
    }


    static void FightScene(int pAttack, double pAttackHit, int hpEnemy, int hpPlayer, int eAttack, double eAttackHit, string EnemyName)
    {
        int Chance = Random.Shared.Next(1, 101);

        if (Chance <= pAttackHit * 100)
        {

            hpEnemy = -pAttack;
            string consoleOutput = $"You hit and dealt {pAttack} damage!";
            Utility.writing(consoleOutput);
            Thread.Sleep(1000);
            Console.Clear();
        }
        else
        {
            string consoleOutput = "You missed!";
            Utility.writing(consoleOutput);
            Thread.Sleep(1000);
            Console.Clear();
        }

        if (Chance <= eAttackHit * 100)
        {
            hpPlayer = eAttack;
            string consoleOutput = $"{EnemyName} hit and dealt {eAttack} damage!";
            Utility.writing(consoleOutput);
            Thread.Sleep(1000);
            Console.Clear();
        }
        else
        {
            string consoleOutput = $"{EnemyName} missed!";
            Utility.writing(consoleOutput);
            Thread.Sleep(1000);
            Console.Clear();
        }

    }
}
class Utility
{

    public static bool Proceed(bool check)
    {

        while (true)
        {
            Console.Clear();
            string consoleOutput = "Are you ready? (y/n)";
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
            Console.Write(text[i]);
            Thread.Sleep(60);
        }
        Console.WriteLine();
    }
}



//slut på lektion commit

// █▒▒▒▒▒▒▒▒▒10%

// ████▒▒▒▒▒▒30%

// █████▒▒▒▒▒50%

// ████████▒▒80%

// ██████████100%