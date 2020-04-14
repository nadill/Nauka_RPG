using System;
namespace Nauka_RPG
{
    public class BronDystansowa : Przedmiot
    {

        public int obrazenia;
        public bool dwureczna;
        public bool doWyposazenia = true;

        public BronDystansowa(string _nazwa, Type _typ, float _waga, float _wartosc, int _ilosc) : base(_nazwa, _typ, _waga, _wartosc, _ilosc)
        {

        }
    }
}
