﻿using System;



List<string> weapons = new List<string> {};
List<int> weaponsDmg = new List<int> {};
List<int> weaponsHit = new List<int> {};
List<int> statBweaponsDmg = new List<int> {30, 50, 40, 20};
List<int> statBweaponsHit = new List<int> {70, 50, 60, 100};


Main();


void Main()
{
    int hp = 100;
    mainMeny();
    Player player = new Player(hp, weaponsDmg[0], weaponsHit[0]); 
    Console.WriteLine($"Your health: {player.playerhealth}, Your damage: {player.playerdamage}, Your hitchance: {player.playerhitChance}");
    Console.ReadLine();
    
}


void mainMeny()
{


string consoleOutput = "Hello adventurer, what should I call you by?";
writing(consoleOutput);


string name = nameP();
consoleOutput = $"Greetings {name}!";
writing(consoleOutput);
Thread.Sleep(500);
Console.Clear();


(string bWeapon, int bWeaponDmg, int bWeaponHit)= bWeaponPick();
weapons.Add(bWeapon);
weaponsHit.Add(bWeaponDmg);
weaponsDmg.Add(bWeaponHit);

consoleOutput = "You chose " + $"{weapons[0]}" + ", now it's time to begin your journey.";
writing(consoleOutput);
Thread.Sleep(1000);

}


static string nameP()
{
    while(true)
    {
    string name = Console.ReadLine();
        if(string.IsNullOrWhiteSpace(name) || int.TryParse(name, out int t))
        {
            string consoleOutput = "Error";
            writing(consoleOutput);
            continue;
        }
        else
        {
            return name;
        }
    }
}


static void writing(string text)
{
    for (int i = 0; i < text.Length; i++)
    {
        Console.Write(text[i]);
        Thread.Sleep(60);
    }
    Console.WriteLine();
}


static (string, int, int) bWeaponPick()
{
    while(true)
    {
    Console.Clear();
    string consoleOutput = "Please choose your starter weapon.";
    writing(consoleOutput);

    List<int> weaponsDmg = new List<int> {30, 50, 40, 20};
    List<int> weaponsHit = new List<int> {70, 50, 60, 100};
    List<string> bWeapons = new List<string> { "Sword", "Axe", "Bow", "Dagger" };
    for (int e = 0; e < bWeapons.Count; e++)
    {
        consoleOutput = $"{e + 1}: " + $"{bWeapons[e]}";
        writing(consoleOutput);
    }

        string pick = Console.ReadLine();
        

            if(int.TryParse(pick, out int pickOut) && pickOut <= bWeapons.Count && pickOut >=1)
            {
                Console.Clear();
            for(int e = 0; e<bWeapons.Count; e++)
                if(pickOut == e + 1)
                {
                    consoleOutput = $"{bWeapons[e]}" + " stats";
                    writing(consoleOutput);
                    consoleOutput = $"Damage: {weaponsDmg[e]}";
                    writing(consoleOutput);
                    consoleOutput = $"Hit chance: {weaponsHit[e]}";
                    writing(consoleOutput);
                    consoleOutput = "Are you sure? (y/n)";
                    writing(consoleOutput);
                    string bWeaponsPickCheck = Console.ReadLine();
                    if(bWeaponsPickCheck.ToLower() == "y")
                        {;
                        return (bWeapons[e], weaponsDmg[e], weaponsHit[e]);
                        }
                    else if(bWeaponsPickCheck.ToLower() == "n")
                        {
                        continue;
                        }
                    else
                    {
                        consoleOutput = "Error";
                        writing(consoleOutput);
                        continue;
                    }
                }
            }
            else
            {
                consoleOutput = "Error";
                writing(consoleOutput);
                continue;
        }
    }
}


static bool Proceed(bool check)
{
    
    while(true)
    {
        Console.Clear();
        string consoleOutput = "Are you ready? (y/n)";
        writing(consoleOutput); 

        string checkC = Console.ReadLine();
        if(checkC.ToLower() == "y")
        {
            return true;
        }
        else if(checkC.ToLower() == "n")
        {
            consoleOutput = "Whenever you're ready.";
            writing(consoleOutput); 
            continue; 
        }
        else
        {
            consoleOutput = "Error";
            writing(consoleOutput); 
            continue; 
        }
    }
}






class Player
{
    public int playerhealth{get; set;}
    public int playerdamage{get; set;}
    public double playerhitChance{get; set;}


    public Player(int playerHealth, int playerDamage, double playerHitChance)
    {
        playerhealth = playerHealth;
        playerdamage = playerDamage;
        playerhitChance = playerHitChance;
    }
}
//slut på lektion commit