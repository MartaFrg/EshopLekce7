using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopLekce7
{
    internal class Kalhoty : Obleceni
    {
        public string strih;
        public DelkaNohavic delkaNohavic;
        public Kalhoty(int cenaNakup, string barva, string strih, DelkaNohavic delkaNohavic) : base(cenaNakup, barva)
        {
            this.strih = strih;
            this.delkaNohavic = delkaNohavic;
        }
public enum DelkaNohavic
        {
            standard,dlouhe,kratke
            }

    }        
}
