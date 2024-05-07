using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "ścieżka_do_pliku.txt";  // Zastąp ścieżką do Twojego pliku tekstowego

        try
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd podczas czytania pliku: " + ex.Message);
        }

        Console.ReadKey();
    }
}
