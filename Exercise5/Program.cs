// 5. Mini-Projekt: Användarhanterare
// Skapa ett konsolprogram där användaren kan:
// Registrera nya användare (Namn, Email, Ålder)
// Spara användarna till en JSON-fil
// Läsa in och visa alla användare
//  💡 Använd try/catch för att hantera:
// Filfel
// Felaktig input
// Tomma värden

using System.Text.Json;         // Gör JSON-funktionerna tillgängliga.

// Bestämmer vad JSON-filen ska heta.
string jsonfile = "users.json";

// Skapar en lista.
var registrerade = new List<Registrera>();

// Kontrollerar om filen finns innan vi försöker läsa den.
if (File.Exists(jsonfile))
{
    try
    {
        // Läser hela filen som text.
        string json = File.ReadAllText(jsonfile);

        // Läser inte filen om den är tom.
        if (!string.IsNullOrWhiteSpace(json))
        {
            // Omvandlar JSON-texten till en lista med Registrera objekt.
            // Om JSON-texten motsvarar null används en tom lista.
            // .Deserialize metoden som omvandlar JSON-text till C#-objekt.
            // <List<Registrera>> – talar om att resultatet ska vara en lista med Registrera-objekt.
            // json – variabeln som innehåller JSON-texten som ska omvandlas.
            // ?? – betyder ”om resultatet till vänster är null, använd värdet till höger”.
            registrerade = JsonSerializer.Deserialize<List<Registrera>>(json)?? new List<Registrera>();
        }
    }

    catch (IOException)
    {
        // Körs om filen finns men inte går att läsa.
        Console.WriteLine("Filen kunde inte läsas. Börjar med en tom lista.");
    }

    catch (JsonException)
    {
        // Körs om filen innehåller JSON som inte går att tolka.
        Console.WriteLine("Filen innehåller ogiltig JSON. Börjar med en tom lista.");
    }
}

while (true)
{
    Console.Write("Namn (tomt avslutar): ");


    string namn = Console.ReadLine() ?? "";

    // Ett tomt namn avslutar registreringen.
    if (string.IsNullOrWhiteSpace(namn))
        break;

    Console.Write("Email: ");
    string email = Console.ReadLine() ?? "";

    // Email får inte vara tom. continue börjar om loopen från namnfrågan.
    if (string.IsNullOrWhiteSpace(email))
    {
        Console.WriteLine("Email får inte vara tom.");
        continue;
    }

    Console.Write("Ålder: ");

    try
    {
        int alder = int.Parse(Console.ReadLine() ?? "");

        // Skapar ett Registrera-objekt och lägger till det i listan.
        registrerade.Add(new Registrera
        {
            Name = namn,
            Email = email,
            Age = alder
        });
    }
    catch (FormatException)
    {
        // Körs om åldern inte kan omvandlas till ett heltal.
        Console.WriteLine("Åldern måste skrivas med siffror.");
    }
}

// Försöker omvandla hela listan till JSON och spara den i filen.
try
{
    // Hela raden betyder omvandla listan registrerade till JSON-text och spara texten i variabeln json.
    // JsonSerializer.Serialize omvandlar C#-data till JSON-text.
    // registrerade – listan med användare som ska omvandlas.
    string json = JsonSerializer.Serialize(registrerade);

    // Skriver JSON-texten till filen. Befintligt innehåll ersätts.
    // detta betyder skriv texten i variabeln json till filen vars namn som finns i jsonfile.
    File.WriteAllText(jsonfile, json);

    Console.WriteLine("\nAnvändarna har sparats.");
}
catch (IOException)
{
    // Körs om filen inte går att skriva till.
    Console.WriteLine("Filen kunde inte sparas.");
}

// Går igenom listan och skriver ut varje användares uppgifter.
Console.WriteLine("\nAlla användare:");

foreach (var användare in registrerade)
{
    Console.WriteLine($"{användare.Name}");
    Console.WriteLine($"{användare.Email}");
    Console.WriteLine($"{användare.Age}");
}