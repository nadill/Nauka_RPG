using System;
using System.Collections.Generic;
using System.Text;

namespace Nauka_RPG
{
    public class Odziez : Przedmiot
    {
        public int pancerz;
        public string lokalizacja;
        public string opis;



        public Odziez(string _nazwa, float _waga, float _wartosc, int _ilosc, int _pancerz, string _czesc, string _opis="") : base(_nazwa, _waga, _wartosc, _ilosc)
        {
            pancerz = _pancerz;
            lokalizacja = _czesc;
            opis = _opis;
        }
    }
}
