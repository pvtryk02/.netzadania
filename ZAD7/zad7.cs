using System;
using System.Diagnostics;
using System.IO;

class AplikacjaKopiowania
{
    static void Main(string[] args)
    {
        // Tworzenie pliku testowego o wielkości 300MB
        Console.WriteLine("Tworzenie pliku testowego...");
        string plikZrodlo = "zrodlo.bin";
        string plikCel = "cel.bin";
        UtworzPlik(plikZrodlo, 300);

        // Pomiar czasu dla kopiowania pliku przy użyciu FileStream
        Stopwatch zegar = new Stopwatch();
        zegar.Start();
        KopiujDane(plikZrodlo, plikCel);
        zegar.Stop();
        Console.WriteLine($"Czas kopiowania (FileStream): {zegar.Elapsed}");

        // Pomiar czasu dla kopiowania pliku przy użyciu File.Copy
        zegar.Restart();
        File.Copy(plikZrodlo, plikCel, true);
        zegar.Stop();
        Console.WriteLine($"Czas kopiowania (File.Copy): {zegar.Elapsed}");
    }

    static void UtworzPlik(string nazwaPliku, int rozmiarWMB)
    {
        using (FileStream fs = new FileStream(nazwaPliku, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            byte[] bufor = new byte[1024 * 1024]; // bufor 1MB
            Random rng = new Random();
            for (int i = 0; i < rozmiarWMB; i++)
            {
                rng.NextBytes(bufor);
                writer.Write(bufor);
            }
        }
    }

    static void KopiujDane(string sciezkaZrodlowa, string sciezkaDocelowa)
    {
        using (FileStream strumienZrodlowy = new FileStream(sciezkaZrodlowa, FileMode.Open, FileAccess.Read))
        using (FileStream strumienDocelowy = new FileStream(sciezkaDocelowa, FileMode.Create, FileAccess.Write))
        {
            byte[] bufor = new byte[4096]; // Zwiększono rozmiar bufora
            int liczbaOdczytanychBajtow;
            while ((liczbaOdczytanychBajtow = strumienZrodlowy.Read(bufor, 0, bufor.Length)) > 0)
            {
                strumienDocelowy.Write(bufor, 0, liczbaOdczytanychBajtow);
            }
        }
    }
}
