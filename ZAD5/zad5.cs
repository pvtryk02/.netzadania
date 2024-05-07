using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Wybierz opcję: [1] Zapisz dane, [2] Odczytaj dane");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                SaveData();
                break;
            case "2":
                ReadData();
                break;
            default:
                Console.WriteLine("Nieprawidłowa opcja.");
                break;
        }

        Console.ReadKey();
    }

    static void SaveData()
    {
        Console.Write("Podaj imię: ");
        string name = Console.ReadLine();
        Console.Write("Podaj wiek: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Podaj adres: ");
        string address = Console.ReadLine();

        using (FileStream fs = new FileStream("userdata.bin", FileMode.Create, FileAccess.Write))
        {
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(name);
                writer.Write(age);
                writer.Write(address);
            }
        }

        Console.WriteLine("Dane zostały zapisane.");
    }

    static void ReadData()
    {
        using (FileStream fs = new FileStream("userdata.bin", FileMode.Open, FileAccess.Read))
        {
            using (BinaryReader reader = new BinaryReader(fs))
            {
                string name = reader.ReadString();
                int age = reader.ReadInt32();
                string address = reader.ReadString();

                Console.WriteLine("Odczytane dane:");
                Console.WriteLine($"Imię: {name}");
                Console.WriteLine($"Wiek: {age}");
                Console.WriteLine($"Adres: {address}");
            }
        }
    }
}

