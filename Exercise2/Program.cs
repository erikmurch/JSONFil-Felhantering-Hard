// 2. Budget Tracker
// Låt användaren lägga till utgifter (Kategori, Belopp, Datum) och spara till budget.json.
//  Vid start ska programmet läsa in filen om den finns, annars skapa en ny.
//  💡 Hantera fel om filen inte finns eller är tom.
using System.Text.Json;

// Skapar en lista.
var utgifter = new List<Utgift>();

try
{
    string json = File.ReadAllText("budget.json");

    // Läs bara in innehållet om filen inte är tom.
    if (!string.IsNullOrWhiteSpace(json))utgifter = JsonSerializer.Deserialize<List<Utgift>>(json)?? new List<Utgift>();
}

catch (JsonException)
{
    // Filen innehåller JSON som inte går att läsa.
    Console.WriteLine("Filen innehåller ogiltig JSON. Börjar med en tom lista.");
}

// Frågar efter utgifter tills användaren lämnar kategorin tom.
while (true)
{
    Console.Write("Kategori (Enter avslutar): ");
    string kategori = Console.ReadLine() ?? "";

    if (string.IsNullOrWhiteSpace(kategori))
        break;

    Console.Write("Belopp: ");
    decimal belopp = decimal.Parse(Console.ReadLine()!);

    Console.Write("Datum: ");
    DateOnly datum = DateOnly.Parse(Console.ReadLine()!);

    // Lägger till utgiften i listan.
    utgifter.Add(new Utgift
    {
        Kategori = kategori,
        Belopp = belopp,
        Datum = datum
    });
}

// Omvandlar hela listan till JSON och spara den i budget.json.
File.WriteAllText("budget.json",JsonSerializer.Serialize(utgifter, new JsonSerializerOptions{WriteIndented = true}));