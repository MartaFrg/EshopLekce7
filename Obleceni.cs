using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EshopLekce7
{

    internal class Obleceni
    {
        static public double marze;
        static internal int kod = 1;
        public int kodObleceni;
        public string barva;
        internal int cenaNakup;
        public int sleva;
        public Dictionary<Obleceni.Velikost, int> naskladnenoKusu;
        public double cenaProdej;
        public Obleceni(int cenaNakup, string barva) 
        { 
            this.cenaNakup = cenaNakup;
            this.barva = barva;
            kodObleceni = kod++;
            cenaProdej = cenaNakup * marze;
            this.naskladnenoKusu = new Dictionary<Velikost, int>();
        }
        public void Naskladni()
        {
            int pocet;
            foreach (Velikost velikost in Enum.GetValues(typeof(Velikost)))
            {
                Console.Write("Zadej počet kusů velikosti {0}: ", velikost);
                while (!int.TryParse(Console.ReadLine(), out pocet)) Console.WriteLine("Zadej počet kusů v celém čísle.");
                this.naskladnenoKusu.Add(velikost, pocet);
            }
        }
        public enum Velikost
        {
            XS,S,M,L,XL,XXL,XXXL
        }
    }
}
