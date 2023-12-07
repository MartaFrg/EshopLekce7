using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static EshopLekce7.Bunda;

namespace EshopLekce7
{

    internal abstract class Obleceni
    {
        static public double marze;
        static internal int kod = 1;
        public int kodObleceni;
        public string barva;
        internal int cenaNakup;
        public int sleva;
        public Dictionary<Obleceni.Velikost, int> naskladnenoKusu;
        public Obleceni()
        {
            this.cenaNakup = 0;
            this.barva = "";
            kodObleceni = kod++;
            this.naskladnenoKusu = new Dictionary<Velikost, int>() {
                { Obleceni.Velikost.XS, 0 } ,{Obleceni.Velikost.S, 0 },{Obleceni.Velikost.M, 0 }, {Obleceni.Velikost.L, 0 }, {Obleceni.Velikost.XL, 0 }, {Obleceni.Velikost.XXL, 0 }, {Obleceni.Velikost.XXXL, 0 }
                };
        }
        public abstract void PridejObleceni();

        public void Naskladni()
        {
            int pocet;
            foreach (Velikost velikost in Enum.GetValues(typeof(Velikost)))
            {
                Console.Write("Zadej počet kusů velikosti {0}: ", velikost);
                while (!int.TryParse(Console.ReadLine(), out pocet)) Console.WriteLine("Zadej počet kusů v celém čísle.");
                naskladnenoKusu[velikost]+= pocet;
            }
        }
        public double CenaProdej()
        {
            return cenaNakup*marze;
        }
        public virtual string Vypis()
        {
            return $"{kodObleceni:D6} - {GetType().Name}, prodejní cena: {CenaProdej()} Kč, barva: {barva}";
        }

        public enum Velikost
        {
            XS,S,M,L,XL,XXL,XXXL
        }
    }
}
