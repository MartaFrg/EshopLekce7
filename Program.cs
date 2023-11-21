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
            sklad.Add(new Triko(150, "modrá", true, true));
            sklad.Last().naskladnenoKusu.Add(Obleceni.Velikost.XS, 0);
            sklad.Last().naskladnenoKusu.Add(Obleceni.Velikost.S, 0);
            sklad.Last().naskladnenoKusu.Add(Obleceni.Velikost.M, 0);
            sklad.Last().naskladnenoKusu.Add(Obleceni.Velikost.L, 0);
            sklad.Last().naskladnenoKusu.Add(Obleceni.Velikost.XL, 0);
            sklad.Last().naskladnenoKusu.Add(Obleceni.Velikost.XXL, 0);
            sklad.Last().naskladnenoKusu.Add(Obleceni.Velikost.XXXL, 0);
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
                    Console.WriteLine("Zadej nové zboží:\n");
                    PridejObleceni();
                    sklad.Last().Naskladni();
                    break;
                case 2:
                    Console.WriteLine("Zboží v databázi:\n");
                    Console.WriteLine(sklad[0].kodObleceni);
                    String druhObleceni;
                    foreach (Obleceni obleceni in sklad)
                    {
                        druhObleceni = obleceni.GetType().Name;
                        Console.Write("{0:D6} - {1}, prodejní cena: {2} Kč, barva: {3}, ", obleceni.kodObleceni, druhObleceni, obleceni.cenaProdej, obleceni.barva);
                        switch (druhObleceni)
                        {
                            case "Bunda":
                                Console.WriteLine("typ bundy: {0}, zapínání na {1}", ((Bunda)obleceni).typBundy, ((Bunda)obleceni).zapinani);
                                break;
                            case "Triko":
                                Console.WriteLine("{0} dlouhý rukáv, {1} obrázek", VratMaNema(((Triko)obleceni).dlouhyRukav), VratMaNema(((Triko)obleceni).obrazekNaTriku));
                                break;
                            case "Kalhoty":
                                Console.WriteLine("střih kalhot: {0}, délka nohavic je {1}", ((Kalhoty)obleceni).strih, ((Kalhoty)obleceni).delkaNohavic);
                                break;
                        }
                        Console.Write("Počet kusů: ");
                        foreach (KeyValuePair<Obleceni.Velikost, int> pocet in obleceni.naskladnenoKusu) { Console.Write(pocet.Key + " " + pocet.Value + "ks, "); }
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
        public static void PridejObleceni()
        {
            int volba;
            string barva;
            int cena;
            string reakce;
            Console.WriteLine("Zadej druh oblečení: \n 1) Bunda \n 2) Kalhoty \n 3) Triko \n 4) Zpět");
            while (!int.TryParse(Console.ReadLine(), out volba) || (volba < 1) || (volba > 4)) Console.WriteLine("Zadej číslo od 1 do 4.");
            switch (volba)
            {
                case 1:
                    string typBundy;
                    Bunda.Zapinani zapinani;
                    Console.Write("Nová položka bunda, zadej nákupní cenu: ".PadLeft(40));
                    while (!int.TryParse(Console.ReadLine(), out cena) || (cena < 0)) Console.WriteLine("Zadej cenu nákupu v celém kladném čísle.");
                    Console.Write("zadej barvu: ".PadLeft(40));
                    barva = Console.ReadLine();
                    Console.Write("zadej typ bundy: ".PadLeft(40));
                    typBundy = (Console.ReadLine());
                    Console.Write("Zadej typ zapínání z=zip, k=knoflíky: ".PadLeft(40));
                    while (!(reakce = Console.ReadLine()).Equals("k") && !reakce.Equals("z")) Console.WriteLine("Zadej \"k\" nebo \"z\".");
                    if (reakce.Equals("k")) zapinani = Bunda.Zapinani.knofliky; else zapinani = Bunda.Zapinani.zip;
                    sklad.Add(new Bunda(cena,barva,typBundy, zapinani));
                    break;
                case 2:
                    string strih;
                    Kalhoty.DelkaNohavic delkaNohavic;
                    Console.Write("Nová položka kalhoty, zadej nákupní cenu: ".PadLeft(55));
                    while (!int.TryParse(Console.ReadLine(), out cena) || (cena < 0)) Console.WriteLine("Zadej cenu nákupu v celém kladném čísle.");
                    Console.Write("zadej barvu: ".PadLeft(55));
                    barva = Console.ReadLine();
                    Console.Write("zadej střih kalhot: ".PadLeft(55));
                    strih = Console.ReadLine();
                    Console.Write("Zadej délku nohavic s=standartní, k=krátké, d=dlouhé: ".PadLeft(55));
                    while (!(reakce = Console.ReadLine()).Equals("s") && !reakce.Equals("k") && !reakce.Equals("d")) Console.WriteLine("Zadej \"s\" nebo \"k\" nebo \"d\".");
                    if (reakce.Equals("s")) delkaNohavic = Kalhoty.DelkaNohavic.standard; else if (reakce.Equals("k")) delkaNohavic = Kalhoty.DelkaNohavic.kratke; else delkaNohavic = Kalhoty.DelkaNohavic.dlouhe;
                    sklad.Add(new Kalhoty(cena, barva, strih, delkaNohavic));
                    break;
                case 3:
                    bool dlouhyRukav;
                    bool obrazekNaTriku;
                    Console.Write("Nová položka triko, zadej nákupní cenu: ".PadLeft(40));
                    while (!int.TryParse(Console.ReadLine(), out cena) || (cena < 0)) Console.WriteLine("Zadej cenu nákupu v celém kladném čísle.");
                    Console.Write("zadej barvu: ".PadLeft(40));
                    barva = Console.ReadLine();
                    Console.Write("Má triko dlouhý rukáv? (a/n): ".PadLeft(40));
                    dlouhyRukav = ReakceAnoNe();
                    Console.Write("Má triko obrázek? (a/n): ".PadLeft(40));
                    obrazekNaTriku = ReakceAnoNe();
                    sklad.Add(new Triko(cena, barva, dlouhyRukav, obrazekNaTriku));
                    break;
                case 4:
                    break;
            }
        }
        public static string VratMaNema(bool test) {
            if (test) return "má"; else return "nemá";
                    }
        public static bool ReakceAnoNe()
        {
            string reakce;
            while (!(reakce = Console.ReadLine()).Equals("a") && !reakce.Equals("n")) Console.WriteLine("Zadej \"a\"=ano anebo \"n\"=ne.");
            if (reakce.Equals("a")) return true; else return false;
        }
    }
}
