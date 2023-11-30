using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopLekce7
{
    internal class Program
    {
        static public int penezVKase;
        static public List<Obleceni> sklad;
        static void Main(string[] args)
        {
            penezVKase = 10000;
            Obleceni.marze = 1.5;
            sklad = new List<Obleceni>(); 
            //sklad.Add(new Triko());
            VyberMenu();
        }
        static void VyberMenu()
        {
            int volba;
            Console.WriteLine();
            Console.WriteLine("Vyber číselnou volbu: \n 1) Zadat nové zboží \n 2) Vypsat všechno zboží z databáze \n 3) Naskladni zboží \n 4) Prodej zboží \n 5) Ukonči \n");
            while (!int.TryParse(Console.ReadLine(), out volba) || (volba < 1) || (volba > 5)) Console.WriteLine("Zadej číslo od 1 do 5.");
            switch (volba)
            {
                case 1:
                    Obleceni obleceni;
                    Console.WriteLine("Zadej nové zboží:\n");
                    Console.WriteLine("Zadej druh oblečení: \n 1) Bunda \n 2) Kalhoty \n 3) Triko \n 4) Zpět");
                    while (!int.TryParse(Console.ReadLine(), out volba) || (volba < 1) || (volba > 4)) Console.WriteLine("Zadej číslo od 1 do 4.");
                    switch (volba)
                    {
                        case 1:
                            obleceni = new Bunda();
                            obleceni.PridejObleceni();
                            sklad.Add(obleceni);
                            break;
                        case 2:
                            obleceni = new Kalhoty();
                            obleceni.PridejObleceni();
                            sklad.Add(obleceni);
                            break;
                        case 3:
                            obleceni = new Triko();
                            obleceni.PridejObleceni();
                            sklad.Add(obleceni);
                            break;
                        case 4:
                            break;
                    }
                    break;

                case 2:
                    Console.WriteLine("Zboží v databázi:\n");
                    Console.WriteLine(sklad[0].kodObleceni);
                    String druhObleceni;
                    foreach (Obleceni item in sklad)
                    {
                        druhObleceni = item.GetType().Name;
                        Console.WriteLine(item.Vypis());
                        Console.Write("Počet kusů: ");
                        foreach (KeyValuePair<Obleceni.Velikost, int> pocet in item.naskladnenoKusu) { Console.Write(pocet.Key + " " + pocet.Value + "ks, "); }
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    Console.WriteLine("Zadej kód zboží k naskladnění:\n");
                    while (!int.TryParse(Console.ReadLine(), out volba) || (volba < 1) || (volba > sklad.Count)) Console.WriteLine("Zadej číslo položky.");
                    sklad[volba - 1].Naskladni();
                    break;
                case 4:
                    Obleceni.Velikost velikost;
                    Console.Write("Zadej kód zboží k prodeji:");
                    while (!int.TryParse(Console.ReadLine(), out volba) || (volba < 1) || (volba > sklad.Count)) Console.WriteLine("Zadej číslo položky.");
                    Console.Write("Zadej velikost: ");
                    while (!Enum.TryParse(Console.ReadLine().ToUpper(), out velikost)) Console.WriteLine("Napiš požadovanou velikost.");
                    if (sklad[volba - 1].naskladnenoKusu[velikost] > 0) sklad[volba - 1].naskladnenoKusu[velikost]--; else Console.WriteLine("Nedostatek zboží k prodeji.");
                    break;
                case 5:
                    Console.WriteLine("ukončit.\n");
                    Environment.Exit(0);
                    break;
            }
            VyberMenu();
        }


    }
}
