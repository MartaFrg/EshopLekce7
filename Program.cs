using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopLekce7
{
    internal class Program
    {
        static public int penezVKase;
        static void Main(string[] args)
        {
            penezVKase = 10000;
            Obleceni.marze = 1.5;
            Obleceni obleceni = new Obleceni(200, Obleceni.Velikost.S, "červená");
            Triko triko = new Triko(150, Obleceni.Velikost.XS, "modrá");
            triko.naskladni(10);
        }
    }
}
