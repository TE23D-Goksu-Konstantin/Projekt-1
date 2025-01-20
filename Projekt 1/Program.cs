

    

    string consoleOutput = "Hello adventurer, what should I call you by?";
    writing(consoleOutput);

    string name = Console.ReadLine();
    consoleOutput = $"Greetings {name}!";
    writing(consoleOutput);

Console.ReadLine();




static void writing(string text)
{

        
    for(int i = 0; i < text.Length; i++)
    {
        Console.Write(text[i]);
        Thread.Sleep(75);
    }

    Console.WriteLine();
   
}





