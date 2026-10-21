//  1. Studentregister med JSON
// Skapa en klass Student med Name och Grade.
// Låt användaren lägga till studenter i en lista
// Spara listan till students.json
// Läs tillbaka och visa alla studenter
//  💡 Använd try/catch när du läser filen.
using System.Text.Json;

// Gör en lista av klassen Student
List<Student> students = new List<Student>();

    Console.Write("Namn: ");
    string name = Console.ReadLine();

    Console.Write("Betyg: ");

    // Skapar en student och lägger till den i listan.
    students.Add(new Student
    {
        Name = name,Grade = Console.ReadLine() ?? ""
    });


// Omvandlar listan till JSON-text och sparar den i students.json.
File.WriteAllText("students.json", JsonSerializer.Serialize(students));

// Försöker läsa filen och visa studenterna.
try
{
    // Läser filen och omvandlar JSON-texten tillbaka till en lista.
    var saved = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText("students.json")) ?? new List<Student>();

    // Går igenom listan och skriver ut varje student.
    foreach (var student in saved)
        Console.WriteLine($"{student.Name}: {student.Grade}");
}
catch (IOException)
{
    // Visas om filen inte går att läsa.
    Console.WriteLine("Kunde inte läsa filen.");
}
