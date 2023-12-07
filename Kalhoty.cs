using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EshopLekce7.Bunda;

namespace EshopLekce7
{
    internal class Kalhoty : Obleceni
    {
        public string strih;
        public DelkaNohavic delkaNohavic;
        public override void PridejObleceni()
        {
            Console.Write("Nová položka kalhoty, zadej nákupní cenu: ".PadLeft(42));
            while (!int.TryParse(Console.ReadLine(), out cenaNakup) || (cenaNakup < 0)) Console.WriteLine("Zadej cenu nákupu v celém kladném čísle.");
            Console.Write("zadej barvu: ".PadLeft(42));
            barva = Console.ReadLine();
            Console.Write("zadej střih kalhot: ".PadLeft(42));
            strih = Console.ReadLine();
            string reakce;
            Console.Write("Zadej délku nohavic:\n"+"s=standartní, k=krátké, d=dlouhé: ".PadLeft(42));
            while (!(reakce = Console.ReadLine()).Equals("s") && !reakce.Equals("k") && !reakce.Equals("d")) Console.WriteLine("Zadej \"s\" nebo \"k\" nebo \"d\".");
            if (reakce.Equals("s")) delkaNohavic = Kalhoty.DelkaNohavic.standard; else if (reakce.Equals("k")) delkaNohavic = Kalhoty.DelkaNohavic.kratke; else delkaNohavic = Kalhoty.DelkaNohavic.dlouhe;
            strih = reakce;
        }

        public override string Vypis()
        {
            return base.Vypis()+$", délka nohavic: {delkaNohavic}, střih: {strih}";
        }

        public enum DelkaNohavic
        {
            standard,dlouhe,kratke
            }

    }        
}
