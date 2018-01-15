using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    class Pracownik : IComparable<Pracownik>
    {
        private DateTime dataZatrudnienia;
        private string imie;
        private double pensja;
        private int staz;

        public Pracownik(string imie, DateTime dataZatrudnienia, double pensja)
        {
            this.imie = imie;
            this.dataZatrudnienia = dataZatrudnienia;
            this.pensja = pensja;
            this.staz = DateTime.Today.Year - dataZatrudnienia.Year;
        }

        public virtual double Dodatek(int nadgodziny)
        {
            return nadgodziny * 40 + staz * 100;
        }

        public virtual string ToString(int nadgodziny)
        {
            return "Pracownik " + imie + ", staż: " + staz.ToString() + ", pensja z dodadatkiem: " + (Dodatek(nadgodziny) + pensja).ToString() + ".";
        }

        public int CompareTo(Pracownik other)
        {
            if(!(this.staz == other.staz))
            {
                return other.staz.CompareTo(this.staz);
            }
            else
            {
                return this.imie.CompareTo(other.imie);
            }
        }
    }
}
