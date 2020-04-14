//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nauka_RPG
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Postac etienne = new Postac("elvan", "Etienne", "Shael");
            Postac vroq = new Postac("borak'ai", "Vroq", "Sol");
            

            
            etienne.GenerujBron("Elficki srebrny miecz", "Miecze", 2.5F, 3, 10, 1);
            etienne.GenerujBron("Drewniany kij", "Drzewce", 2.5F, 1, 10, 1);
            etienne.GenerujBron("Sztylet", "Miecze", 2.5F, 1, 10, 1);

            etienne.GenerujOdziez("Elvanska suknia", 2.0f, 50f, 1, 0, "tlow");
            etienne.Wyposaz("Elvanska suknia");
            etienne.Wyposaz("Sztylet");
            etienne.Wyposaz("Drewniany kij");
            etienne.Wyposaz("Elficki srebrny miecz");
            etienne.Schowaj("Sztylet");

            etienne.SprawdzEkwipunek();




            Console.ReadKey();
        }
    }
}