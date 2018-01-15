using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    interface IPlace
    {
        void DodajKierownika(string imie, DateTime dataZatrudnienia, double pensja);
        void DodajPracownika(string imie, DateTime dataZatrudnienia, double pensja);
        void OdwrocKolejnosc();
        void Sortuj();
        void UsunPracownika(int numer);
    }
}
