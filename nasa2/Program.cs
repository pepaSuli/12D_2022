using System;
using System.Collections.Generic;
using System.IO;

namespace nasa2
{
    class Program
    {
        static void Main(string[] args)
        {
            Keres proba = new Keres("rn3.swc.com*20/Jul/1995:00:02:14*GET /history/apollo/apollo-13/apollo-13-patch.jpg*200 90112");


            string[] sorok = File.ReadAllLines("NASAlog.txt");
            List<Keres> naplo = new List<Keres>();

            for (int i = 0; i < sorok.Length; i++)
            {
                naplo.Add(new Keres(sorok[i]));
            }


            Console.WriteLine("5. feladat: Kérések száma: {0}",naplo.Count);

            int ossz = 0;
            for (int i = 0; i < naplo.Count; i++)
            {
                ossz += naplo[i].ByteMeret();
            }
            Console.WriteLine("6. feladat: Válaszok összes mérete: {0} byte",ossz);


            int darab = 0;
            for (int i = 0; i < naplo.Count; i++)
            {
                if(naplo[i].Domain())
                {
                    darab++;
                }
            }

            Console.WriteLine("8. feladat: Domain-es kérések: {0:0.00%}",(double)darab/naplo.Count);

            Dictionary<string, int> kodok = new Dictionary<string, int>();
            for (int i = 0; i < naplo.Count; i++)
            {
                //kodok["200"]++;
                if(kodok.ContainsKey(naplo[i].kod))
                {
                    kodok[naplo[i].kod]++;
                }
                else
                {
                    kodok.Add(naplo[i].kod, 1);
                }
            }

        }
    }

    class Keres
    {
        public string url, ido, filenev, kod, meret;
        public Keres(string sor)
        {
            string[] vag = sor.Split("*");
            url = vag[0];
            ido = vag[1];
            filenev = vag[2];

            string[] vag2 = vag[3].Split(" ");
            kod = vag2[0];
            meret = vag2[1];

        }
        public int ByteMeret()
        {
            if(meret=="-")
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(meret);
            }
        }

        public bool Domain()
        {
            return !"1234567890".Contains(url[url.Length - 1]);
            return url[url.Length - 1] < '0' || url[url.Length - 1] > '9';
        }
    }
}
