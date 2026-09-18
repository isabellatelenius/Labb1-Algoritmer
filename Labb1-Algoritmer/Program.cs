Console.Write("Skriv in en text med siffror: ");
string text = Console.ReadLine() ?? "";  //Om Console.ReadLine() av någon anledning blir null, använd en tom string istället.

long total = 0; // Skapar en variabel som ska hålla reda på summan av de tal programmet hittar

for (int startIndex = 0; startIndex < text.Length; startIndex++)
{
    char startChar = text[startIndex];

    // Börjar med att kolla om tecknet är en siffra
    if (!char.IsDigit(startChar))
    {
        continue;
    }

    for (int endIndex = startIndex + 1; endIndex < text.Length; endIndex++)
    {
        char currentChar = text[endIndex];

        // Om programmet stöter på något som inte är en siffra, ska tecknet inte fortsätta
        if (!char.IsDigit(currentChar))
        {
            break;
        }

        // Om programmet hittar samma siffra som vi började med
        if (currentChar == startChar)
        {
            int length = endIndex - startIndex + 1;

            string foundNumber = text.Substring(startIndex, length);

            // Skriver ut delen före träffen
            Console.Write(text.Substring(0, startIndex));

            // Byter färg på den hittade delen
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(foundNumber);

            // Byter tillbaka till vanlig färg
            Console.ResetColor();

            // Skriver ut resten av strängen
            Console.WriteLine(text.Substring(endIndex + 1));

            // Gör om den hittade strängen till ett tal
            long number = long.Parse(foundNumber);

            // Lägg till talet i totalen
            total += number;

            // Programmet slutar söka från startsiffran, eftersom nästa likadana siffra redan har hittats
            break;
        }
    }
}

Console.WriteLine();
Console.WriteLine($"Total = {total}");