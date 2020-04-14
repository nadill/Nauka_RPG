using System;
using System.Collections.Generic;
using System.Text;

namespace Nauka_RPG
{
    public class Plecak : Przedmiot
    {
        private int pojemnosc;


        public Plecak(string _nazwa, float _waga, float _wartosc, int _ilosc, int _pojemnosc) : base (_nazwa, _waga, _wartosc, _ilosc)
        {
            pojemnosc = _pojemnosc;
            List<Przedmiot> dodatkowyPlecak = new List<Przedmiot>(pojemnosc);

        }
    }
}
