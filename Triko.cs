using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EshopLekce7.Kalhoty;

namespace EshopLekce7
{
    internal class Triko : Obleceni
    {
        internal bool dlouhyRukav;
        internal bool obrazekNaTriku;
        public override void PridejObleceni()
        {
            Console.Write("Nová položka triko, zadej nákupní cenu: ".PadLeft(40));
            while (!int.TryParse(Console.ReadLine(), out cenaNakup) || (cenaNakup < 0)) Console.WriteLine("Zadej cenu nákupu v celém kladném čísle.");
            Console.Write("zadej barvu: ".PadLeft(40));
            barva = Console.ReadLine();
            Console.Write("Má triko dlouhý rukáv? (a/n): ".PadLeft(40));
            dlouhyRukav = ReakceAnoNe();
            Console.Write("Má triko obrázek? (a/n): ".PadLeft(40));
            obrazekNaTriku = ReakceAnoNe();
        }
        public static bool ReakceAnoNe()
        {
            string reakce;
            while (!(reakce = Console.ReadLine()).Equals("a") && !reakce.Equals("n")) Console.WriteLine("Zadej \"a\"=ano anebo \"n\"=ne.");
            if (reakce.Equals("a")) return true; else return false;
        }

        public override string Vypis()
        {
            return base.Vypis()+$", {VratMaNema(dlouhyRukav)} dlouhý rukáv, {VratMaNema(obrazekNaTriku)} obrázek";
        }
        public static string VratMaNema(bool test)
        {
            if (test) return "má"; else return "nemá";
        }
    }
}
