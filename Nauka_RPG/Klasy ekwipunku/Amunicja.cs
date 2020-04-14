using System;
namespace Nauka_RPG
{
    public class Amunicja : Przedmiot
    {
        public string przeznaczenie;
        
        public Amunicja(string _nazwa, string _przeznaczenie, float _waga, float _wartosc, int _ilosc) : base(_nazwa, _waga, _wartosc, _ilosc)
        {
            przeznaczenie = _przeznaczenie;
        }
    }
}
