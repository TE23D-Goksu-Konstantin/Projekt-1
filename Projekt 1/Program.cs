using System;



string consoleOutput = "Hello adventurer, what should I call you by?";
writing(consoleOutput);


string name = nameP();
consoleOutput = $"Greetings {name}! Choose your starter weapon.";
writing(consoleOutput);
Console.Clear();

List<string> weapons = new List<string> {};
string w1 = bWeaponPick();
weapons.Add($"{bWeaponPick}");

Console.WriteLine(weapons[0]);



static string nameP()
{
    while(true)
    {
    string name = Console.ReadLine();
        if(string.IsNullOrWhiteSpace(name) || int.TryParse(name, out int t))
        {
            Console.Clear();
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

    List<string> bWeapons = new List<string> { "Sword", "Axe", "Dagger", "Bow" };
    for (int e = 0; e < bWeapons.Count; e++)
    {
        string consoleOutput = $"{e + 1}: " + $"{bWeapons[e]}";
        writing(consoleOutput);
    }

    string pick = Console.ReadLine();
    int.TryParse(pick, out int pickOut);
    for (int e = 0; e < bWeapons.Count; e++)
    {
        if(pickOut == bWeapons[e])
        {
            
        }
    }

}


//slut på lektion commit