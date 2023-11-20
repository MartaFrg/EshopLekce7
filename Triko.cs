using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopLekce7
{
    internal class Triko : Obleceni
    {
        public Triko(int cenaNakup, Velikost velikost, string barva) : base(cenaNakup, velikost, barva)
        {
        }
    }
}
