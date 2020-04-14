using System;
using System.Collections;
using System.Collections.Generic;

namespace Nauka_RPG
{
    public class Przedmiot
    {
        public string nazwa;
        public float waga;
        //public Type typPrzedmiotu;
        public float wartosc;
        public int ilosc;


        public Przedmiot(string _nazwa, float _waga, float _wartosc=0, int _ilosc=1)
        {
            nazwa = _nazwa;
            //typPrzedmiotu = _typ;
            waga = _waga;
            wartosc = _wartosc;
            ilosc = _ilosc;

        }


    }
}
