using System;
using System.Collections.Generic;
using System.Text;

namespace Nauka_RPG
{
    static class Mechanika
    {

        static int RzutKoscia(int _kosc = 100)
        {
            Random rzutKoscia = new Random();
            int wynikRzutu = rzutKoscia.Next(1, _kosc + 1);

            return wynikRzutu;
        }

        static int RzutKoscia(bool _przewaga, int _kosc = 100)
        {
            Random rzutKoscia = new Random();
            int wynikRzutu1 = rzutKoscia.Next(1, _kosc + 1);
            int wynikRzutu2 = rzutKoscia.Next(1, _kosc + 1);
            int wynik;
            if (_przewaga)
            {
                wynik = Math.Max(wynikRzutu1, wynikRzutu2);
            } else {
                wynik = Math.Min(wynikRzutu1, wynikRzutu2);
            }

            return wynik;
        }


    }
}
