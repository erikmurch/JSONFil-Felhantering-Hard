// 3. Try/Catch Challenge
// Skapa ett program med flera catch-block:
// Ett för FormatException
// Ett för FileNotFoundException
// Ett generellt Exception för alla andra fel
//  Testa att framkalla olika typer av fel för att se vilket block som körs.

try
{
    Console.Write("Skriv ett heltal: ");
    // int.Parse gör om string till int.
    int tal = int.Parse(Console.ReadLine()!); // Text ger FormatException.

    string innehåll = File.ReadAllText("test.txt"); // Saknad fil ger FileNotFoundException.

    Console.WriteLine($"Du skrev {tal}. Filinnehåll: {innehåll}");
}
catch (FormatException)
{
    Console.WriteLine("Fel: Du måste skriva ett heltal.");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Fel: test.txt kunde inte hittas.");
}
catch (Exception fel)
{
    Console.WriteLine($"Ett annat fel inträffade: {fel.Message}");
}