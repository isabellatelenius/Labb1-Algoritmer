Console.Write("Skriv in en text med siffror: ");
string text = Console.ReadLine() ?? "";  //Om Console.ReadLine() av någon anledning blir null, använd en tom string istället.

long total = 0;

for (int startIndex = 0; startIndex < text.Length; startIndex++)
{
    char startChar = text[startIndex];

    // Vi börjar med att söka om tecknet är en siffra
    if (!char.IsDigit(startChar))
    {
        continue;
    }

    for (int endIndex = startIndex + 1; endIndex < text.Length; endIndex++)
    {
        char currentChar = text[endIndex];

        // Om vi stöter på något som inte är en siffra
        // kan detta tal inte fortsätta längre
        if (!char.IsDigit(currentChar))
        {
            break;
        }

        // Om vi hittar samma siffra som vi började på
        if (currentChar == startChar)
        {
            int length = endIndex - startIndex + 1;

            string foundNumber = text.Substring(startIndex, length);

            // Skriv ut delen före träffen
            Console.Write(text.Substring(0, startIndex));

            // Byt färg på den hittade delen
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(foundNumber);

            // Byt tillbaka till vanlig färg
            Console.ResetColor();

            // Skriv ut resten av strängen
            Console.WriteLine(text.Substring(endIndex + 1));

            // Gör om den hittade strängen till ett tal
            long number = long.Parse(foundNumber);

            // Lägg till talet i totalen
            total += number;

            // Vi slutar söka från startsiffran
            // eftersom nästa likadana siffra redan har hittats
            break;
        }
    }
}

Console.WriteLine();
Console.WriteLine($"Total = {total}");