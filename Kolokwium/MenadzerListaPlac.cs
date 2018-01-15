using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    class MenadzerListaPlac
    {
        private ListaPlac listaPlac = new ListaPlac();
        private bool czyKoniec = false;
        private char przycisk;

        public MenadzerListaPlac()
        {

        }

        public void Uruchom()
        {
            while(!czyKoniec)
            {
                Console.Clear();
                Console.WriteLine("Wciśnij odpowiedni przycisk, aby wybrać opcję.");
                Console.WriteLine("[1] - dodaj pracownika");
                Console.WriteLine("[2] - dodaj kierownika");
                Console.WriteLine("[3] - sortuj listę pracowników");
                Console.WriteLine("[4] - odwrotnie sortuj listę pracowników");
                Console.WriteLine("[5] - usuń pracownika");
                Console.WriteLine("[6] - wyświetl listę pracowników");
                Console.WriteLine("[7] - zakończ");

                przycisk = Console.ReadKey(true).KeyChar;

                switch(przycisk)
                {
                    case '1':
                        DodajPracownika(false);
                        break;

                    case '2':
                        DodajPracownika(true);
                        break;

                    case '3':
                        Sortuj();
                        break;

                    case '4':
                        OdwrotnieSortuj();
                        break;

                    case '5':
                        UsunPracownika();
                        break;

                    case '6':
                        WyswietlListe();
                        break;

                    case '7':
                        czyKoniec = true;
                        break;
                }
            }
        }

        private void DodajPracownika(bool czyKierownik)
        {
            bool wystapilBlad = false;
            string imie = "";
            DateTime dataZatrudnienia = new DateTime();
            double pensja = new double();

            Console.Clear();

            Console.WriteLine("Podaj imię pracownika:");
            try
            {
                imie = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Nie podano poprawnego imienia.");
                wystapilBlad = true;
            }

            if(!wystapilBlad)
            {
                Console.WriteLine("Podaj datę zatrudnienia pracownika (w postaci dd.mm.rrrr):");
                try
                {
                    dataZatrudnienia = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    Console.WriteLine("Nie podano poprawnej daty.");
                    wystapilBlad = true;
                }
            }

            if (!wystapilBlad)
            {
                Console.WriteLine("Podaj pensję pracownika (użyj przecinka):");
                try
                {
                    pensja = Convert.ToDouble(Console.ReadLine());
                    
                    if(pensja < 0.0)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Nie podano poprawnej liczby.");
                    wystapilBlad = true;
                }
            }

            if(!wystapilBlad)
            {
                if(!czyKierownik)
                {
                    listaPlac.DodajPracownika(imie, dataZatrudnienia, pensja);
                    Console.WriteLine("Dodano nowego pracownika.");
                }
                else
                {
                    listaPlac.DodajKierownika(imie, dataZatrudnienia, pensja);
                    Console.WriteLine("Dodano nowego kierownika.");
                }
            }

            Console.WriteLine("Wciśnij przycisk, aby wrócić do menu.");
            Console.ReadKey();
        }

        private void Sortuj()
        {
            Console.Clear();

            listaPlac.Sortuj();

            Console.WriteLine("Posortowano listę.");

            Console.WriteLine("Wciśnij przycisk, aby wrócić do menu.");
            Console.ReadKey();
        }

        private void OdwrotnieSortuj()
        {
            Console.Clear();

            listaPlac.OdwrocKolejnosc();

            Console.WriteLine("Posortowano listę i odwrócono kolejność.");

            Console.WriteLine("Wciśnij przycisk, aby wrócić do menu.");
            Console.ReadKey();
        }

        private void UsunPracownika()
        {
            int indeks;

            Console.Clear();

            Console.WriteLine("Podaj indeks pracownika, którego chcesz usunąć:");

            try
            {
                indeks = Convert.ToInt32(Console.ReadLine());

                listaPlac.UsunPracownika(indeks);
            }
            catch
            {
                Console.WriteLine("Nie podano poprawnego indeksu.");
            }

            Console.WriteLine("Wciśnij przycisk, aby wrócić do menu.");
            Console.ReadKey();
        }

        private void WyswietlListe()
        {
            int nadgodziny = new int();

            Console.Clear();

            Console.WriteLine("Podaj liczbę nadgodzin pracowników z zakresu <0, 40>:");

            try
            {
                nadgodziny = Convert.ToInt32(Console.ReadLine());

                if(nadgodziny < 0 || nadgodziny > 40)
                {
                    throw new Exception();
                }

                Console.WriteLine("Lista pracowników:");
                Console.WriteLine(listaPlac.ToString(nadgodziny));
            }
            catch
            {
                Console.WriteLine("Nie podano poprawnej liczby całkowitej.");
            }

            Console.WriteLine("Wciśnij przycisk, aby wrócić do menu.");
            Console.ReadKey();
        }
    }
}
