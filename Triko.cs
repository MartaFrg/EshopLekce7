using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopLekce7
{
    internal class Triko : Obleceni
    {
        internal bool dlouhyRukav;
        internal bool obrazekNaTriku;
        public Triko(int cenaNakup, string barva, bool dlouhyRukav, bool obrazekNaTriku) : base(cenaNakup, barva)
        {
            this.dlouhyRukav = dlouhyRukav;
            this.obrazekNaTriku = obrazekNaTriku;
        }
    }
}
