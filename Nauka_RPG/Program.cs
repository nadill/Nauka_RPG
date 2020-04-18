//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Nauka_RPG.Utility;


namespace Nauka_RPG
{
    
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.Write("Witaj użytkowniku. Czy chcesz wczytać postać (W), czy stworzyć nową (N)?: ");
            string decyzja = Console.ReadLine().ToUpper();
            
            if (decyzja == "N")
            {
                

                //Character postac = new Character();

                

            }




            Console.ReadKey();
        }
    }
}