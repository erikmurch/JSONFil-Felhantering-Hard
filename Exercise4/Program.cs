// 4. Säker Läsning
// Bygg en metod som försöker läsa en JSON-fil med try/catch.
//  Om läsningen misslyckas ska metoden returnera en tom lista istället för att krascha.
// 💡 Träna på att “rädda” programmet när något går fel.

using System.Text.Json;


// Anropar metoden som läser listan students.
List<Student> students = ReadStudents("student.json");

Console.WriteLine($"Antal studenter: {students.Count}");

// Metoden försöker läsa filen och returnerar en studentlista.
// fileName får värdet "students.json".
static List<Student> ReadStudents(string fileName)
{

    try
    {
    string json = File.ReadAllText(fileName);

    // Gör om JSON-texten till en lista med Student objekt.
    // Om resultatet är null returneras en tom lista.
    return JsonSerializer.Deserialize<List<Student>>(json)?? new List<Student>();
    }
    
    catch (IOException)
    {
    // om filen saknas eller inte går att läsa.
    return new List<Student>();
    }

    catch (JsonException)
    {
    // Om filen är tom eller innehåller ogiltig JSON.
    return new List<Student>();
    }
}