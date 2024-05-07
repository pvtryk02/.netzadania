using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        ManagerZadań manager = new ManagerZadań();
        bool działa = true;
        while (działa)
        {
            Console.WriteLine("\n1. Dodaj zadanie 2. Usuń zadanie 3. Wyświetl zadania 4. Zapisz 5. Wczytaj 6. Wyjście");
            switch (Console.ReadLine())
            {
                case "1":
                    manager.DodajZadanie();
                    break;
                case "2":
                    manager.UsuńZadanie();
                    break;
                case "3":
                    manager.WyświetlZadania();
                    break;
                case "4":
                    manager.ZapiszZadania();
                    break;
                case "5":
                    manager.WczytajZadania();
                    break;
                case "6":
                    działa = false;
                    break;
                default:
                    Console.WriteLine("Nieprawidłowe polecenie.");
                    break;
            }
        }
    }
}

public class Zadanie
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public string Opis { get; set; }
    public DateTime DataZakończenia { get; set; }
    public bool CzyZakończone { get; set; }
}

public class ManagerZadań
{
    private List<Zadanie> zadania = new List<Zadanie>();

    public void DodajZadanie()
    {
        var zadanie = new Zadanie();

        Console.WriteLine("Podaj nazwę zadania:");
        zadanie.Nazwa = Console.ReadLine();

        Console.WriteLine("Podaj opis zadania:");
        zadanie.Opis = Console.ReadLine();

        Console.WriteLine("Podaj datę zakończenia zadania (rrrr-mm-dd):");
        zadanie.DataZakończenia = DateTime.Parse(Console.ReadLine());

        zadanie.CzyZakończone = false;
        zadanie.Id = zadania.Count + 1;
        zadania.Add(zadanie);
    }

    public void UsuńZadanie()
    {
        Console.WriteLine("Podaj ID zadania do usunięcia:");
        int id = int.Parse(Console.ReadLine());
        zadania.RemoveAll(z => z.Id == id);
    }

    public void WyświetlZadania()
    {
        foreach (var zadanie in zadania)
        {
            Console.WriteLine($"ID: {zadanie.Id}, Nazwa: {zadanie.Nazwa}, Data zakończenia: {zadanie.DataZakończenia.ToShortDateString()}, Czy zakończone: {zadanie.CzyZakończone}");
        }
    }

    public void ZapiszZadania()
    {
        var json = JsonSerializer.Serialize(zadania);
        File.WriteAllText("zadania.json", json);
        Console.WriteLine("Zadania zostały zapisane.");
    }

    public void WczytajZadania()
    {
        try
        {
            var json = File.ReadAllText("zadania.json");
            zadania = JsonSerializer.Deserialize<List<Zadanie>>(json);
            Console.WriteLine("Zadania zostały wczytane.");
        }
        catch (Exception)
        {
            Console.WriteLine("Błąd podczas wczytywania zadań.");
        }
    }
}
