using System;



string consoleOutput = "Hello adventurer, what should I call you by?";
writing(consoleOutput);


string name = nameP();
consoleOutput = $"Greetings {name}!";
writing(consoleOutput);
Thread.Sleep(500);
Console.Clear();

List<string> weapons = new List<string> {};
List<int> weaponsDmg = new List<int> {30, 50, 40, 20};
List<int> weaponsHit = new List<int> {70, 50, 60, 100};
string w1 = bWeaponPick();
weapons.Add(w1);

consoleOutput = $"{weapons[0]}";
writing(consoleOutput);

Console.ReadLine();


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




static string bWeaponPick()
{
    while(true)
    {
    Console.Clear();
    string consoleOutput = "Please choose your starter weapon.";
    writing(consoleOutput);

    List<int> weaponsDmg = new List<int> {30, 50, 40, 20};
    List<int> weaponsHit = new List<int> {70, 50, 60, 100};
    List<string> bWeapons = new List<string> { "Sword", "Axe", "Dagger", "Bow" };
    for (int e = 0; e < bWeapons.Count; e++)
    {
        consoleOutput = $"{e + 1}: " + $"{bWeapons[e]}";
        writing(consoleOutput);
    }

        string pick = Console.ReadLine();
        

            if(int.TryParse(pick, out int pickOut) && pickOut <= 5 && pickOut >=1)
            {
                Console.Clear();

                if(pickOut == 1)
                {
                    consoleOutput = "Sword stats";
                    writing(consoleOutput);
                    consoleOutput = $"Damage: {weaponsDmg[0]}";
                    writing(consoleOutput);
                    consoleOutput = $"Hit chance: {weaponsHit[0]}";
                    writing(consoleOutput);
                    consoleOutput = "Are you sure? (y/n)";
                    writing(consoleOutput);
                    string bWeaponsPickCheck = Console.ReadLine();
                    if(bWeaponsPickCheck.ToLower() == "y")
                        {
                        return bWeapons[pickOut - 1];
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


//slut på lektion commit