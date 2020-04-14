//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



namespace Nauka_RPG
{
    public class Postac
    {
        //string[] tabAtrybuty = new string[] { "Budowa", "Refleks", "Umysł", "Osobowość", "Magia" };
        //public Atrybut atrybuty = new Atrybut();
        
        public List<Atrybut> atrybuty = new List<Atrybut>();
        public List<Umiejetnosc> umiejetnosci = new List<Umiejetnosc>();
        //public List<Umiejetnosc> inkantacje = new List<Umiejetnosc>();
        
        public List<Przedmiot> plecak = new List<Przedmiot>(10);
        private uint limitPlecaka = 10;
        public Dictionary<string,Odziez> uzbrojenie = new Dictionary<string, Odziez>() { 
            {"glowa", null },
            { "lReka", null }, 
            { "pReka", null },
            { "tlow", null },
            { "lNoga", null },
            {"pNoga", null } };

        readonly private ushort limitRak = 2;
        public List<Bron> wyposazenie = new List<Bron>(2);
        readonly private ushort limitUbrania = 6;
        
        private float udzwig;
        private float maxUdzwig;

        private int maxZdrowie;
        private int aktualneZdrowie;
        private int progSmierci;

        private int dusza;
        private int poczytalność;
        
        private int odpornosc;
        private Hashtable ochrona = new Hashtable() {
            { "glowa", 0},
            { "lreka", 0},
            { "preka", 0},
            { "tlow", 0},
            { "lnoga", 0},
            { "pnoga", 0} };
        private int ciezkieRany = 0;
        private bool przeciazenie = false;

        
        private string rasa;
        private string imie;
        private string imieRodowe;



        public Postac(string rasaA, string imieA, string imieRodoweA)
        {
            Random rzutK10 = new Random();
            rasa = rasaA;
            imie = imieA;
            imieRodowe = imieRodoweA;

            // Stworzenie atrybutów
            atrybuty.Add(new Atrybut("Siła", 0, "Ciało"));
            atrybuty.Add(new Atrybut("Kondycja", 0, "Ciało"));
            atrybuty.Add(new Atrybut("Precyzja", 0, "Ciało"));
            atrybuty.Add(new Atrybut("Szybkość", 0, "Ciało"));
            atrybuty.Add(new Atrybut("Intelekt", 0, "Umysł"));
            atrybuty.Add(new Atrybut("Zmysł", 0, "Umysł"));
            atrybuty.Add(new Atrybut("Charyzma", 0, "Umysł"));
            atrybuty.Add(new Atrybut("Wola", 0, "Umysł"));
            atrybuty.Add(new Atrybut("Magia", 0, "Dar"));

            // Losowanie atrybutów

            for (int x = 0; x < 8; x++)
            {
                atrybuty[x].wartoscAtrybutu += rzutK10.Next(1, 11);
                atrybuty[x].wartoscAtrybutu += rzutK10.Next(1, 11);
                atrybuty[x].wartoscAtrybutu += rzutK10.Next(1, 11);
                atrybuty[x].wartoscAtrybutu += rzutK10.Next(1, 11);
                atrybuty[x].wartoscAtrybutu += rzutK10.Next(1, 11);
            }



            switch (rasaA)
            {
                case "człowiek":
                    atrybuty[rzutK10.Next(1, 8)].wartoscAtrybutu += rzutK10.Next(1, 11);

                    if (rzutK10.Next(1, 101) <= 10) {
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        

                    }
                    break;

                case "elvan":
                    atrybuty[2].wartoscAtrybutu += rzutK10.Next(1, 11);
                    atrybuty[3].wartoscAtrybutu += rzutK10.Next(1, 11);
                    atrybuty[5].wartoscAtrybutu += rzutK10.Next(1, 11);

                    if (rzutK10.Next(1, 101) <= 20)
                    {
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        
                    }

                    break;

                case "alboros":
                    atrybuty[1].wartoscAtrybutu += rzutK10.Next(1, 11);
                    atrybuty[6].wartoscAtrybutu += rzutK10.Next(1, 11);
                    atrybuty[7].wartoscAtrybutu += rzutK10.Next(1, 11);
                    break;

                case "borak'ai":
                    atrybuty[0].wartoscAtrybutu += rzutK10.Next(1, 11);
                    atrybuty[1].wartoscAtrybutu += rzutK10.Next(1, 11);
                    atrybuty[7].wartoscAtrybutu += rzutK10.Next(1, 11);

                    if (rzutK10.Next(1, 101) <= 15)
                    {
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        

                    }

                    break;

                case "yutri":
                    atrybuty[4].wartoscAtrybutu += rzutK10.Next(1, 11);
                    atrybuty[5].wartoscAtrybutu += rzutK10.Next(1, 11);
                    atrybuty[6].wartoscAtrybutu += rzutK10.Next(1, 11);

                    if (rzutK10.Next(1, 101) <= 20)
                    {
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        atrybuty[8].wartoscAtrybutu += rzutK10.Next(1, 11);
                        

                    }

                    break;
            }

            // Przypisywanie premii

            for (int x = 0; x < 8; x++)
            {
                atrybuty[x].premia = atrybuty[x].wartoscAtrybutu / 10;
            }


            maxZdrowie = 10 + rzutK10.Next(1, 11) * (atrybuty[1].premia);
            aktualneZdrowie = maxZdrowie;
            progSmierci = maxZdrowie / 2 * -1;
            odpornosc = atrybuty[1].premia;

            maxUdzwig = (atrybuty[0].premia + atrybuty[1].premia) * 10;

            // Stworzenie puli umiejętności

            // Umiejętności bojowe
            umiejetnosci.Add(new Umiejetnosc("Baty", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Bijatyka", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Miecze", "Precyzja", 1, true));
            umiejetnosci.Add(new Umiejetnosc("Topory", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Obuchy", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Drzewcowe", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Przedramienne", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Łuki", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Kusze", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Miotane", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Strzelby", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Improwizowane", "Precyzja", 0, true));

            // Umiejętności fizyczne
            umiejetnosci.Add(new Umiejetnosc("Akrobatyka", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Atletyka", "Szybkość", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Skradanie", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Jeździectwo", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Kradzież", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Percepcja", "Zmysł", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Prowadzenie", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Przetrwanie", "Zmysł", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Tropienie", "Zmysł", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Wyswobodzenie", "Precyzja", 0, true));
            umiejetnosci.Add(new Umiejetnosc("Zabezpieczenia", "Precyzja", 0, true));

            // Umiejętności umysłowe
            umiejetnosci.Add(new Umiejetnosc("Alchemia", "Intelekt", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Fałszerstwo", "Precyzja", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Kowalstwo", "Intelekt", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Medycyna", "Intelekt", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Pierwsza pomoc", "Zmysł", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Historia", "Intelekt", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Fauna", "Intelekt", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Flora", "Intelekt", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Wierzenia", "Intelekt", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Okultyzm", "Intelekt", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Inżynieria", "Intelekt", 0, false));

            // Umiejętności społeczne
            umiejetnosci.Add(new Umiejetnosc("Etykieta", "Osobowość", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Handel", "Osobowość", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Manipulacja", "Osobowość", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Perswazja", "Osobowość", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Przywództwo", "Osobowość", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Zastraszanie", "Siła", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Empatia", "Osobowość", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Uwodzenie", "Osobowość", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Przesłuchiwanie", "Osobowość", 0, false));
            umiejetnosci.Add(new Umiejetnosc("Mentorstwo", "Osobowość", 0, false));

            // Umiejętności magiczne
            if(atrybuty[4].wartoscAtrybutu >= 10)
            {
                umiejetnosci.Add(new Umiejetnosc("Pieczęcie", "Precyzja", 0, true));
                umiejetnosci.Add(new Umiejetnosc("Inkantacje", "Magia", 0, false));
                umiejetnosci.Add(new Umiejetnosc("Magiczna percepcja", "Zmysł", 0, false));
                umiejetnosci.Add(new Umiejetnosc("Pakty", "Wola", 0, false));
                umiejetnosci.Add(new Umiejetnosc("Przeciwzaklęcia", "Magia", 0, false));
                umiejetnosci.Add(new Umiejetnosc("Rytuały", "Magia", 0, false));
                umiejetnosci.Add(new Umiejetnosc("Stabilizacja", "Magia", 0, false));

            }

            opisPostaci();
        }

        private void ObliczObciazenie() 
        {
            float obciazenie=0;
            foreach (var przedmiot in plecak)
            {
                obciazenie += przedmiot.waga;
            }
            udzwig = obciazenie;
            przeciazenie = (udzwig > maxUdzwig) ? true : false;
        }
        public void opisPostaci()
        {
            Console.WriteLine("\nImie: " + imie);
            Console.WriteLine("Imie rodowe: " + imieRodowe);
            Console.WriteLine("Rasa: " + rasa);
            Console.WriteLine("\nAtrybuty");
            Console.WriteLine($"Siła: {atrybuty[0].wartoscAtrybutu} /+{atrybuty[0].premia}, Kondycja: {atrybuty[1].wartoscAtrybutu} /+{atrybuty[1].premia}");
            Console.WriteLine($"Precyzja: {atrybuty[2].wartoscAtrybutu} /+{atrybuty[2].premia}, Mobilność: {atrybuty[3].wartoscAtrybutu} /+{atrybuty[3].premia}");
            Console.WriteLine($"Intelekt: {atrybuty[4].wartoscAtrybutu} /+{atrybuty[4].premia}, Zmysł: {atrybuty[5].wartoscAtrybutu} /+{atrybuty[5].premia}");
            Console.WriteLine($"Osobowość: {atrybuty[6].wartoscAtrybutu} /+{atrybuty[6].premia}, Wola: {atrybuty[7].wartoscAtrybutu} /+{atrybuty[7].premia}");
            Console.WriteLine($"Magia: {atrybuty[8].wartoscAtrybutu} / Moc: {atrybuty[8].premia}, Przepływ: {atrybuty[8].premia}");


        }

        public void Wyposaz(string _nazwa)
        {
            char decyzja;
            int wybor;
            int miejsce = plecak.FindIndex(_x => _x.nazwa == _nazwa);
            Przedmiot znalezionyP = plecak[miejsce];

            if (znalezionyP is Bron)
            {
                if (wyposazenie.Count()<limitRak)
                {
                    wyposazenie.Add((Bron)znalezionyP);
                    plecak.Remove(znalezionyP);

                    Console.WriteLine(" Broń: {0} została wyposażona!", znalezionyP.nazwa);

                }
                else
                {
                    Console.Write("Wszystkie ręce masz zajęte. Czy chcesz wymienić trzymany predmiot? T/N: ");
                    decyzja = Convert.ToChar(Console.ReadLine());
                    if (decyzja == 'T' || decyzja == 't')
                    {
                        Console.WriteLine("Wskaż który trzymany przedimot wymienic:");
                        int x=0;
                        foreach (Bron bron in wyposazenie)
                        {
                            x++;
                            Console.WriteLine("{0}. {1}", x, bron.nazwa);
                        }
                        wybor = Convert.ToInt32(Console.ReadLine());

                        plecak.Add(wyposazenie[wybor - 1]);
                        wyposazenie.RemoveAt(wybor - 1);

                        wyposazenie.Add((Bron)znalezionyP);
                        plecak.Remove(znalezionyP);

                        Console.WriteLine("{0} został wyposażony", znalezionyP.nazwa);
                    }
                }
            }
            else if (znalezionyP is Odziez)
            {
                Odziez znalezionyPancerz = (Odziez)znalezionyP;
                ochrona[znalezionyPancerz.lokalizacja] = (int)ochrona[znalezionyPancerz.lokalizacja] + znalezionyPancerz.pancerz;

                uzbrojenie.Add(znalezionyPancerz.lokalizacja, znalezionyPancerz);
                plecak.Remove(znalezionyP);
                Console.WriteLine(ochrona);
                Console.WriteLine();


                Console.WriteLine(" Odzienie: {0} została wyposażona!", znalezionyP.nazwa);

                //
                foreach (var ubranie in uzbrojenie)
                {
                    Console.WriteLine(ubranie);
                }
                

            }
            else
            {
                Console.WriteLine("Nie można posażyć {0}", znalezionyP.nazwa);
            }
        }

        public void Schowaj(string _nazwa)
        {
            // wybor przedmiotu do schowania

            Console.WriteLine("Który przedmiot chcesz schować?");
            for (int i = 0; i < wyposazenie.Count; i++)
            {
                Console.WriteLine($"{i}. {wyposazenie[i].nazwa}");
            }
            for (int i = wyposazenie.Count; i < uzbrojenie.Count+i; i++)
            {
                Console.WriteLine($"{i}. {wyposazenie[i].nazwa}");
            }
            int wybor = Convert.ToInt32(Console.ReadLine()); // dodac potem walidacje

            if (wybor < wyposazenie.Count) // wybrana bron z listy
            {
                if (plecak.Count >= limitPlecaka) // Jeśli nie ma miejsca w plecaku, zaproponuj zamiane broni na inna
                {
                    Console.Write($"Nie ma miejsca w ekwipunku, aby schować {wyposazenie[wybor].nazwa}. \nCzy chcesz go zamienić na inną broń z ekwipunku? (T/N)");
                    string decyzja = Console.ReadLine().ToUpper();

                    switch (decyzja)
                    {
                        case "T":
                            Console.WriteLine("Na którą broń zamienić {0}?", wyposazenie[wybor].nazwa);
                            int x = 1;

                            foreach (Bron bron in plecak)
                            {
                                Console.WriteLine($"{x}. {bron.nazwa}");
                            }
                            decyzja = Console.ReadLine().ToLower();
                            int wybor2;
                            if (Int32.TryParse(decyzja, out wybor2))
                            {

                            }
                            else if (plecak.Exists(_a => _a.nazwa == decyzja))
                            {
                                int miejsce = plecak.FindIndex(_a => _a.nazwa == decyzja);

                                wyposazenie.Add((Bron)plecak[miejsce]);
                                plecak.RemoveAt(miejsce);

                                plecak.Add(wyposazenie[wybor]);
                                wyposazenie.RemoveAt(wybor);

                            }
                            else {
                                Console.WriteLine("Nie schowano przedmiotu.");

                            }
                            break;
                        case "N":
                            Console.WriteLine("Nie schowano przedmiotu.");
                            break;

                        default:
                            Console.WriteLine("Nie schowano przedmiotu.");

                            break;
                    }
                }
                else // W innym przypadku schowaj do ekwipunku
                {

                }
            }
            else if (wybor >= wyposazenie.Count && wybor < uzbrojenie.Count) // wybrano pancerz z listy
            {
                if (plecak.Count >= limitPlecaka) // Jeśli nie ma miejsca w plecaku, zaproponuj zamiane pancerza na inny
                {

                }
                else // W innym przypadku schowaj do ekwipunku
                {

                }

            }
            else
            {
                Console.WriteLine("Nie ma takiego przedmiotu na liscie");
            }


        }


        public void GenerujBron(string _nazwa, string _typ, float _waga, int _obrazenia, float _wartosc, int _ilosc, bool _dwureczna=false, int _zasieg=0)
        {
            Bron bron = new Bron(_nazwa, _typ, _obrazenia, _dwureczna, _waga, _wartosc, _ilosc);
            plecak.Add(bron);
            ObliczObciazenie();
        }

        public void GenerujPrzedmiot(string _nazwa, float _waga, float _wartosc = 0, int _ilosc = 1)
        {
            Przedmiot przedmiot = new Przedmiot(_nazwa, _waga, _wartosc, _ilosc);
            plecak.Add(przedmiot);
            ObliczObciazenie();
        }

        public void GenerujOdziez(string _nazwa, float _waga, float _wartosc, int _ilosc, int _pancerz, string _czesc, string _opis = "")
        {
            Odziez przedmiot = new Odziez( _nazwa, _waga, _wartosc, _ilosc, _pancerz, _czesc, _opis);
            plecak.Add(przedmiot);
            ObliczObciazenie();
        }

        public void GenerujAmunicje(string _nazwa, string _przeznaczenie, float _waga, float _wartosc, int _ilosc)
        {
            Amunicja amunicja = new Amunicja(_nazwa, _przeznaczenie, _waga, _wartosc, _ilosc);
            plecak.Add(amunicja);
            ObliczObciazenie();
        }

        public void GenerujPlecak(string _nazwa, float _waga, float _wartosc, int _ilosc, int _pojemnosc)
        {
            Plecak dodPlecak = new Plecak(_nazwa, _waga, _wartosc, _ilosc, _pojemnosc);
            plecak.Add(dodPlecak);
            ObliczObciazenie();
        }

        public void GenerujZuzywalne()
        {

        }

        public void SprawdzEkwipunek()
        {
            Console.WriteLine($"\nSprawdźmy co mamy w ekwipunku ...");
            for (int x = 0;  x < plecak.Count(); x++)
            {
                Console.WriteLine($"{x}. {plecak[x].nazwa} | Ilość: {plecak[x].ilosc} | Waga całkowita: {plecak[x].waga * plecak[x].ilosc} kg");
            }
            Console.WriteLine($"\nŁącznna waga przemiotów: {udzwig}/{maxUdzwig} kg");


        }

        public bool TestAtrybutu(string _atrybut, int _dodMod=0)
        {
            Random rzutK100 = new Random();
            int wynikK100 = rzutK100.Next(1,101);
            Console.WriteLine(wynikK100);

            int indexA = atrybuty.FindIndex(atr => atr.nazwaAtrybutu == _atrybut);

            if (wynikK100 <= atrybuty[indexA].wartoscAtrybutu)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        public bool TestUmiejetnosci(string _umiejetnosc, int _dodMod=0)
        {
            Random rzutK100 = new Random();
            int wynikK100 = rzutK100.Next(1,101);
            Console.WriteLine("Wynik rzutu na test: " + wynikK100);

            int indexU = umiejetnosci.FindIndex(skill => skill.nazwa == _umiejetnosc);
            int indexA = atrybuty.FindIndex(atr => atr.nazwaAtrybutu == umiejetnosci[indexU].powiazanyAtrybut);

            if (wynikK100 <= (umiejetnosci[indexU].punkty * 10) + atrybuty[indexA].wartoscAtrybutu)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        
        public void AkcjaAtaku(string _bron, Postac _cel)
        {
            // Załadowanie broni z plecaka
            int bron = plecak.FindIndex(bron => bron.nazwa == _bron);

            if (bron < 0)
            {
                Console.WriteLine("Nie ma takiej broni... ");
            }
            else
            {

                // Inicjacja metody testu umiejętności
                

                
            }
                    
        } 

        public void WezPrzedmiot(Postac _martwyCel, Przedmiot _przedmiot)
        {

        }




    }
}