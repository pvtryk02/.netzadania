using System;

class Program
{
    static void Main(string[] args)
    {
        // Tworzenie samochodów
        Samochod s1 = new Samochod("Fiat", "126p", 2, 650, 6.0);
        Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6);
        
        // Tworzenie garaży
        Garaz g1 = new Garaz();
        g1.Adres = "ul. Garażowa 1";
        g1.Pojemnosc = 1;  // Garaż na jeden samochód

        Garaz g2 = new Garaz("ul. Garażowa 2", 2); // Garaż na dwa samochody

        // Wprowadzanie samochodów do garażu g1
        g1.WprowadzSamochod(s1);
        g1.WypiszInfo();  // Wyświetla informacje o garażu g1 i samochodach w nim

        // Próba wprowadzenia drugiego samochodu do garażu g1, który jest już pełny
        g1.WprowadzSamochod(s2);
        g1.WypiszInfo();

        // Wprowadzanie samochodów do garażu g2
        g2.WprowadzSamochod(s2);
        g2.WprowadzSamochod(s1);
        g2.WypiszInfo();  // Wyświetla informacje o garażu g2 i samochodach w nim

        // Wyprowadzanie samochodów z garażu g2
        Samochod wyprowadzony = g2.WyprowadzSamochod();
        if (wyprowadzony != null)
        {
            Console.WriteLine("Wyprowadzono samochód:");
            wyprowadzony.WypiszInfo();
        }
        g2.WypiszInfo();

        // Próba wyprowadzenia więcej samochodów niż jest w garażu
        g2.WyprowadzSamochod();
        g2.WyprowadzSamochod();

        // Wyświetlanie liczby utworzonych samochodów
        Samochod.WypiszIloscSamochodow();

        Console.ReadKey();
    }
}

