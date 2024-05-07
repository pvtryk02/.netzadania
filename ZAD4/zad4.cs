using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "ścieżka_do_pliku.txt";  // Zastąp ścieżką do Twojego pliku tekstowego

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string reversedLine = ReverseString(line);
                    Console.WriteLine(reversedLine);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd podczas czytania pliku: " + ex.Message);
        }

        Console.ReadKey();
    }

    static string ReverseString(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
