using System;
using System.Collections.Generic;
using System.IO;

namespace sms2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //1. feladat
            Console.WriteLine("1. feladat:");
            Console.Write("Kérek 1 bötüt: ");
            string botu = Console.ReadLine().ToUpper();

            string[] kodok = { "ABC","DEF","GHI","JKL","MNO","PQRS","TUV","WXYZ" };

            for (int i = 0; i < kodok.Length; i++)
            {
                if(kodok[i].Contains(botu))
                {
                    Console.WriteLine("Ez a {0}",i+2);
                }
            }

            //2. feladat
            Console.WriteLine("2. feladat:");
            Console.Write("Kérek 1 szó: ");
            string szo = Console.ReadLine().ToUpper();

            string szamkod = "";
            for (int i = 0; i < szo.Length; i++)
            {
                szamkod += elkodol(szo[i].ToString());
            }

            Console.WriteLine("A kódja {0}", szamkod);


            //3. feladat
            string[] szavak = File.ReadAllLines("szavak.txt");
            //4. feladat
            string leghosszabb = "";

            for (int i = 0; i < szavak.Length; i++)
            {
                if(szavak[i].Length>leghosszabb.Length)
                {
                    leghosszabb = szavak[i];
                }
            }
            Console.WriteLine("4. feladat");
            Console.WriteLine("A leghosszabb szó: {0}, a hossza: {1}",
                                    leghosszabb,
                                    leghosszabb.Length);



            //5. adatok
            int db = 0;
            foreach (var item in szavak)
            {
                switch(item.Length)
                {
                    case 1: db++; break;
                    case 2: db++; break;
                    case 3: db++; break;
                    case 4: db++; break;
                    case 5: db++; break;
                }
            }
            Console.WriteLine("5. feladat: Ennyi rövid szó van: {0}",db);


            StreamWriter ir = new StreamWriter("kodok.txt");
            foreach (var item in szavak)
            {

                szamkod = "";
                for (int i = 0; i < item.Length; i++)
                {
                    //alma
                    szamkod += elkodol(item[i].ToString().ToUpper());
                }
                ir.WriteLine(szamkod);
            }
            ir.Close();

            string[] elkodolt = File.ReadAllLines("kodok.txt");

            Console.WriteLine("7. feladat");
            Console.Write("Kérek egy számsort: ");
            string szamsor = Console.ReadLine();

            for (int i = 0; i < elkodolt.Length; i++)
            {
                if(elkodolt[i]==szamsor)
                {
                    Console.WriteLine(szavak[i]);
                }
            }

            //8.feladat

            Dictionary<string, List<string>> stat = new Dictionary<string, List<string>>();
            for (int i = 0; i < elkodolt.Length; i++)
            {
                try
                {
                    stat[elkodolt[i]].Add(szavak[i]);
                }
                catch (Exception e)
                {
                    stat.Add(elkodolt[i], new List<string>{szavak[i]});
                }
            }

            string maxKod = "";
            foreach (var item in stat)
            {
                if(item.Value.Count>1)
                {
                    for (int i = 0; i < item.Value.Count; i++)
                    {
                        Console.Write("{0} : {1}; ", item.Value[i],item.Key);
                    }
                    
                }

                if(maxKod!="" && item.Value.Count>stat[maxKod].Count)
                {
                    maxKod = item.Key;
                }
                else if(maxKod=="")
                {
                    maxKod = item.Key;
                }

            }

            Console.WriteLine();

            Console.WriteLine("8.feladat");
            Console.WriteLine("legtöbb kód: {0}",maxKod);
            for (int i = 0; i < stat[maxKod].Count; i++)
            {
                Console.WriteLine(stat[maxKod][i]);
            }

        }

        static int elkodol(string b)
        {
            string[] kodok = { "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ" };

            for (int i = 0; i < kodok.Length; i++)
            {
                if (kodok[i].Contains(b))
                {
                    return i + 2;
                }
            }

            return 0;
        }

    }
}
