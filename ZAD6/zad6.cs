using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Określenie ścieżek dla pliku źródłowego i pliku docelowego
        string sciezkaPlikuZrodlowego = @"C:\sciezka\do\pliku\zrodlowego\plik.txt";
        string sciezkaPlikuDocelowego = @"C:\sciezka\do\pliku\docelowego\plik.txt";

        try
        {
            // Utworzenie FileStream do odczytu z pliku źródłowego
            using (FileStream strumienZrodlowy = new FileStream(sciezkaPlikuZrodlowego, FileMode.Open, FileAccess.Read))
            {
                // Utworzenie FileStream do zapisu do pliku docelowego
                using (FileStream strumienDocelowy = new FileStream(sciezkaPlikuDocelowego, FileMode.Create, FileAccess.Write))
                {
                    // Bufor do odczytu danych
                    byte[] bufor = new byte[1024];
                    int liczbaOdczytanychBajtow;

                    // Odczyt z pliku źródłowego i zapis do pliku docelowego
                    while ((liczbaOdczytanychBajtow = strumienZrodlowy.Read(bufor, 0, bufor.Length)) > 0)
                    {
                        strumienDocelowy.Write(bufor, 0, liczbaOdczytanychBajtow);
                    }
                }
            }

            Console.WriteLine("Plik został skopiowany pomyślnie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd podczas kopiowania pliku:");
            Console.WriteLine(ex.Message);
        }
    }
}

