using System;
using System.Collections;
using System.Collections.Generic;

namespace Nauka_RPG
{
    public class Umiejetnosc
    {


        public string nazwa;
        public string powiazanyAtrybut;
        public int punkty;
        public bool fizyczny;

        public Umiejetnosc(string _nazwa, string _powiazanyAtrybut, int _punkty, bool _fizyczny)
        {
            nazwa = _nazwa;
            powiazanyAtrybut = _powiazanyAtrybut;
            punkty = _punkty;
            fizyczny = _fizyczny;
        }

        

       


    }
}
