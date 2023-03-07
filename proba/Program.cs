using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace proba
{
    class Program
    {
        static void Main(string[] args)
        {

            List<jatekos> jatekosok = new List<jatekos>();

            //1. feladat és 3. feladat
            jatekosok = belerak(olvas("eredm1.txt"), jatekosok, 1);
            jatekosok = belerak(olvas("eredm2.txt"), jatekosok, 2);
            jatekosok = belerak(olvas("eredm3.txt"), jatekosok, 3);
            jatekosok = belerak(olvas("eredm4.txt"), jatekosok, 4);

            //2. feladat
            Console.WriteLine("\n2. feladat");

            for (int i = 1; i < jatekosok.Count; i++)
            {

                if (jatekosok[i].pont < jatekosok[i - 1].pont && jatekosok[i].kor == 1)
                {
                    Console.WriteLine(jatekosok[i].nev);
                }
            }

            //4. feladat
            Console.WriteLine("\n4. feladat");

            Dictionary<string, int> osszpontok = new Dictionary<string, int>();

            for (int i = 0; i < jatekosok.Count; i++)
            {
                if (osszpontok.ContainsKey(jatekosok[i].nev))
                {
                    osszpontok[jatekosok[i].nev] += jatekosok[i].pont;
                }
                else
                {
                    osszpontok.Add(jatekosok[i].nev, jatekosok[i].pont);
                }
            }

            foreach (var x in osszpontok)
            {

                Console.WriteLine(x.Key + " " + x.Value);

            }

            //5. feladat
            Console.WriteLine("\n5. feladat");

            var max = osszpontok.Where(y => y.Value == osszpontok.Max(x => x.Value));
            foreach (var x in max)
            {
                Console.WriteLine(x.Key + " " + x.Value);
            }

            //6. feladat
            Console.WriteLine("\n6. feladat");
            List<string> hibazott = new List<string>();
            for (int i = 1; i < jatekosok.Count; i++)
            {
                if (jatekosok[i].pont < jatekosok[i - 1].pont && jatekosok[i].kor == jatekosok[i - 1].kor)
                {
                    if (hibazott.Contains(jatekosok[i].nev))
                    {
                        Console.WriteLine(jatekosok[i].nev + " " + jatekosok[i].kor);
                    }
                    else
                    {
                        hibazott.Add(jatekosok[i].nev);
                    }
                }
            }

            //7. feladat
            Console.WriteLine("\n7. feladat");
            var kilenc = jatekosok.Where(x => x.pont == 9);
            Dictionary<string, List<int>> kilences_jatekosok = new Dictionary<string, List<int>>();
            foreach (var x in kilenc)
            {
                if (kilences_jatekosok.ContainsKey(x.nev))
                {
                    kilences_jatekosok[x.nev].Add(x.kor);
                }
                else
                {
                    kilences_jatekosok.Add(x.nev, new List<int>());
                    kilences_jatekosok[x.nev].Add(x.kor);
                }
            }

            foreach (var x in kilences_jatekosok)
            {
                Console.Write(x.Key + ' ');
                for (int i = 0; i < x.Value.Count; i++)
                {
                    Console.Write(x.Value[i] + " ");
                }
                Console.WriteLine();
            }

        }

        static string[] olvas(string file)
        {
            var olvas = new StreamReader(file);

            return olvas.ReadToEnd().Split("\n");
        }
        static List<jatekos> belerak(string[] sorok, List<jatekos> meglevo, int kor)
        {
            for (int i = 0; i < sorok.Length; i++)
            {
                if (i % 2 == 1)
                {
                    meglevo.Add(new jatekos(sorok[i - 1], int.Parse(sorok[i]), kor));
                }
            }

            return meglevo;

        }

    }

    public class jatekos
    {
        public string nev;
        public int pont;
        public int kor;


        public jatekos(string _nev, int _pont, int _kor)
        {
            nev = _nev;
            pont = _pont;
            kor = _kor;

        }
    }
}
