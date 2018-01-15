using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    class Kierownik : Pracownik
    {
        public Kierownik(string imie, DateTime dataZatrudnienia, double pensja)
            : base(imie, dataZatrudnienia, pensja)
        {

        }

        public override double Dodatek(int nadgodziny)
        {
            return base.Dodatek(nadgodziny) + 400;
        }

        public override string ToString(int nadgodziny)
        {
            return base.ToString(nadgodziny) + "*Kierownik*";
        }
    }
}
