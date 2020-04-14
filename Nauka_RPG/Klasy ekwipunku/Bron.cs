using System;
namespace Nauka_RPG
{
    public class Bron : Przedmiot
    {
        public int obrazenia;
        private bool dwureczna;
        public string rodzajBroni;
        //public List<Efekty> dodatkoweEfekty = new List<Efekty>();


        public Bron (string _nazwa, string _rodzajBroni, int _obrazenia, bool _dwureczna, float _waga, float _wartosc = 0, int _ilosc = 1) : base(_nazwa, _waga, _wartosc, _ilosc)
        {
            obrazenia = _obrazenia;
            dwureczna = _dwureczna;
            rodzajBroni = _rodzajBroni;

        }
    }
}
