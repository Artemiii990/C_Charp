using System;
using System.Collections.Generic;
using System.Linq;

public class Firma
{
    public string Nazva { get; set; }
    public DateTime DataZasnuvannya { get; set; }
    public string ProfilBiznesu { get; set; }
    public string PIBDirektora { get; set; }
    public int KilkistSpivrobitnikiv { get; set; }
    public string Adresa { get; set; }

    public override string ToString()
    {
        return $"Название: {Nazva}, Дата появления: {DataZasnuvannya.ToShortDateString()}, Профиль: {ProfilBiznesu}, Директор: {PIBDirektora}, Количество рабочих: {KilkistSpivrobitnikiv}, Адрес: {Adresa}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Firma> firmi = new List<Firma>()
        {
            new Firma { Nazva = "Food Inc.", DataZasnuvannya = new DateTime(2021, 2, 25), ProfilBiznesu = "Food", PIBDirektora = "John Doe", KilkistSpivrobitnikiv = 210, Adresa = "New York" },
            new Firma { Nazva = "White Food", DataZasnuvannya = new DateTime(2024, 5, 6), ProfilBiznesu = "Food", PIBDirektora = "Jane Black", KilkistSpivrobitnikiv = 80, Adresa = "London" },
            new Firma { Nazva = "Marketing Pro", DataZasnuvannya = new DateTime(2020, 3, 15), ProfilBiznesu = "Marketing", PIBDirektora = "Peter White", KilkistSpivrobitnikiv = 120, Adresa = "London" },
            new Firma { Nazva = "IT Solutions", DataZasnuvannya = new DateTime(2019, 11, 22), ProfilBiznesu = "IT", PIBDirektora = "Ann Smith", KilkistSpivrobitnikiv = 648, Adresa = "Kyiv" },
            new Firma { Nazva = "Black and White", DataZasnuvannya = DateTime.Now.AddDays(-14), ProfilBiznesu = "IT", PIBDirektora = "David Black", KilkistSpivrobitnikiv = 532, Adresa = "London" }

        };

        
        PrintFirmi(firmi, "Все фирмы:");
        PrintFirmi(firmi.Where(f => f.Nazva.Contains("Food")), "Фирмы с 'Food' в названии:");
        PrintFirmi(firmi.Where(f => f.ProfilBiznesu == "Marketing"), "Фирмы с профилем 'Marketing':");
        PrintFirmi(firmi.Where(f => f.ProfilBiznesu == "Marketing" &&  f.ProfilBiznesu == "IT"), "Фирмы с профилем 'Marketing' или 'IT':");
        PrintFirmi(firmi.Where(f => f.KilkistSpivrobitnikiv > 100), "Фирмы с количеством рабочих привышает 100 человек:");
        PrintFirmi(firmi.Where(f => f.KilkistSpivrobitnikiv >= 100 && f.KilkistSpivrobitnikiv <= 300), "Фирмы с количеством рабочих от 100 до 300:");
        PrintFirmi(firmi.Where(f => f.Adresa == "London"), "Фирмы с адресом  'London':");
        PrintFirmi(firmi.Where(f => f.PIBDirektora.EndsWith("White")), "Фирмы с директором 'White':");
        PrintFirmi(firmi.Where(f => f.DataZasnuvannya < DateTime.Now.AddYears(-2)), "Фирмы созданы больше 2 лет назад:");
        PrintFirmi(firmi.Where(f => (DateTime.Now - f.DataZasnuvannya).Days == 14), "Фирмы, созданы две недели назад:");
        PrintFirmi(firmi.Where(f => f.PIBDirektora.EndsWith("Black") && f.Nazva.Contains("White")), "Фирмы с директором 'Black' и 'White' в названии:");


    }

    static void PrintFirmi(IEnumerable<Firma> firmi, string message)
    {
        Console.WriteLine("\n" + message);
        foreach (var firma in firmi)
        {
            Console.WriteLine(firma);
        }
    }


}
