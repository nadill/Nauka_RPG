using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nauka_RPG
{
    public class Atrybut
    {

        public string nazwaAtrybutu;
        public int wartoscAtrybutu;
        public string kategoriaAtrybutu;
        public int premia;
       

        /*public string p1Nazwa;
        public int p1Wartosc;

        public string p2Nazwa;
        public int p2Wartosc; */

        public Atrybut(string _nazwaAtr, int _wartoscAtr, string _kategoriaAtr)
        {
            nazwaAtrybutu = _nazwaAtr;
            wartoscAtrybutu = _wartoscAtr;
            kategoriaAtrybutu = _kategoriaAtr;
            premia = wartoscAtrybutu / 10;

            /*p1Nazwa = _p1Nazwa;
            p1Wartosc = _p1Wartosc;

            p2Nazwa = _p2Nazwa;
            p2Wartosc = _p2Wartosc;*/
        }

        


    }
}
