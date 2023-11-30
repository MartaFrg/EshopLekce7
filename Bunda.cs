using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopLekce7
{
    internal class Bunda : Obleceni
    {
        public string typBundy;
        public Zapinani zapinani;

        public override void PridejObleceni()
        {
            string reakce;
            Console.Write("Nová položka bunda, zadej nákupní cenu: ".PadLeft(40));
            while (!int.TryParse(Console.ReadLine(), out cenaNakup) || (cenaNakup < 0)) Console.WriteLine("Zadej cenu nákupu v celém kladném čísle.");
            Console.Write("zadej barvu: ".PadLeft(40));
            barva = Console.ReadLine();
            Console.Write("zadej typ bundy: ".PadLeft(40));
            typBundy = Console.ReadLine();
            Console.Write("Zadej typ zapínání z=zip, k=knoflíky: ".PadLeft(40));
            while (!(reakce = Console.ReadLine()).Equals("k") && !reakce.Equals("z")) Console.WriteLine("Zadej \"k\" nebo \"z\".");
            if (reakce.Equals("k")) zapinani = Bunda.Zapinani.knofliky; else zapinani = Bunda.Zapinani.zip;
        }

        public override string Vypis()
        {
            return $"{kodObleceni:D6} - {GetType().Name}, prodejní cena: {CenaProdej()} Kč, barva: {barva}, typ bundy: {typBundy}, zapínání na {zapinani}";
        }

        public enum Zapinani
        {
            zip,
            knofliky
        }
    }
}
