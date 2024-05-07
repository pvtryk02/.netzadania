public class Garaz
{
    private string adres;
    private int pojemnosc;
    private int liczbaSamochodow = 0;
    private Samochod[] samochody;

    public string Adres
    {
        get { return adres; }
        set { adres = value; }
    }

    public int Pojemnosc
    {
        get { return pojemnosc; }
        set
        {
            pojemnosc = value;
            samochody = new Samochod[pojemnosc];
        }
    }

    public Garaz()
    {
        adres = "nieznany";
        pojemnosc = 0;
    }

    public Garaz(string adres_, int pojemnosc_)
    {
        adres = adres_;
        pojemnosc = pojemnosc_;
        samochody = new Samochod[pojemnosc];
    }

    public void WprowadzSamochod(Samochod samochod)
    {
        if (liczbaSamochodow < pojemnosc)
        {
            samochody[liczbaSamochodow++] = samochod;
        }
        else
        {
            Console.WriteLine("Garaz jest pełny, nie można dodać nowego samochodu.");
        }
    }

    public Samochod WyprowadzSamochod()
    {
        if (liczbaSamochodow > 0)
        {
            Samochod samochod = samochody[--liczbaSamochodow];
            samochody[liczbaSamochodow] = null;
            return samochod;
        }
        else
        {
            Console.WriteLine("Garaz jest pusty, nie ma samochodu do wyprowadzenia.");
            return null;
        }
    }

    public void WpiszInf()
    {
        Console.WriteLine("Adres tego garażu: " + adres);
        Console.WriteLine("Pojemność tego garażu: " + pojemnosc);
        Console.WriteLine("Liczba samochodów w garażu: " + liczbaSamochodow);
        foreach (Samochod samochod in samochody)
        {
            if (samochod != null)
            {
                samochod.WpiszInf();
                Console.WriteLine();
            }
        }
    }
}

   


