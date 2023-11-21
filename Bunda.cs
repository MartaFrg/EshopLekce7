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
        public Bunda(int cenaNakup, string barva, string typBundy, Zapinani zapinani) : base(cenaNakup, barva)
        {
            this.typBundy = typBundy;
            this.zapinani = zapinani;
        }
        public enum Zapinani
        {
            zip,
            knofliky
        }
    }
}
