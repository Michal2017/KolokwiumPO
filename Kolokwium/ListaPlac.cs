using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    class ListaPlac : IPlace
    {
        private List<Pracownik> pracownicy = new List<Pracownik>();

        public void DodajKierownika(string imie, DateTime dataZatrudnienia, double pensja)
        {
            pracownicy.Add(new Kierownik(imie, dataZatrudnienia, pensja));
        }

        public void DodajPracownika(string imie, DateTime dataZatrudnienia, double pensja)
        {
            pracownicy.Insert(0, new Pracownik(imie, dataZatrudnienia, pensja));
        }

        public void OdwrocKolejnosc()
        {
            pracownicy.Sort();
            pracownicy.Reverse();
        }

        public void Sortuj()
        {
            pracownicy.Sort();
        }

        public void UsunPracownika(int numer)
        {
            try
            {
                Console.WriteLine("Usuwam " + pracownicy[numer].ToString(0));
                pracownicy.RemoveAt(numer);
            }
            catch
            {
                Console.WriteLine("Nie ma pracownika o podanym indeksie.");
            }
            
        }

        public string ToString(int nadgodziny)
        {
            string zwrot = "";

            foreach(var el in pracownicy)
            {
                zwrot += el.ToString(nadgodziny) + Environment.NewLine;
            }

            return zwrot;
        }
    }
}
