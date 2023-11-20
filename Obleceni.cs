using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopLekce7
{

    internal class Obleceni
    {
        static public double marze;
        internal String barva;
        internal Velikost velikost;
        internal int cenaNakup;
        public int sleva;
        public int naskladnenoKusu;
        public Obleceni(int cenaNakup, Velikost velikost, String barva) 
        { 
            this.cenaNakup = cenaNakup;
            this.velikost = velikost; 
            this.barva = barva;
        }
        public int naskladni(int pocetKusu)
        {
            naskladnenoKusu = naskladnenoKusu + pocetKusu;
            penezVKase = 
            return naskladnenoKusu;
        }
        public enum Velikost
        {
            XS,S,M,L,XL,XXL,XXXL
        }
    }
}
