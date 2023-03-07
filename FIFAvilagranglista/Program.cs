using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FIFAvilagranglista
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("fifa.txt");
            List<adatok> ranglista = new List<adatok>();
            for (int i = 1; i < sorok.Length; i++)
            {
                ranglista.Add(new adatok(sorok[i]));
            }

            List<adatok> ranglista2 = new List<adatok>();
            Console.WriteLine("3. feladat: {0}", ranglista.Count);

            Console.WriteLine(ranglista.Average(a => a.pontszam));

            double osszeg = 0;
            for (int i = 0; i < ranglista.Count; i++)
            {
                osszeg += ranglista[i].pontszam;
            }
            Console.WriteLine("{0:0.00}",osszeg/ranglista.Count);


            int maxIndex = 0;
            for (int i = 0; i < ranglista.Count; i++)
            {
                if(ranglista[i].valtozas>ranglista[maxIndex].valtozas)
                {
                    maxIndex = i;
                }
            }

            Console.WriteLine("{0} {1} {2}", ranglista[maxIndex].csapat, ranglista[maxIndex].valtozas, ranglista[maxIndex].pontszam);


            bool van = false;
            for (int i = 0; i < ranglista.Count; i++)
            {
                if(ranglista[i].csapat=="Magyarország")
                {
                    van = true;
                }
            }

            if(van)
            {
                Console.WriteLine("van");
            }
            else
            {
                Console.WriteLine("nincs");
            }

            Dictionary<int, int> stat = new Dictionary<int, int>();
            for (int i = 0; i < ranglista.Count; i++)
            {
                int k = ranglista[i].valtozas;
                if (stat.ContainsKey(k))
                {
                    stat[k]++;
                }
                else
                {
                    stat.Add(k, 1);
                }
            }

            foreach(var e in stat)
            {
                if(e.Value>1)
                {
                    Console.WriteLine("{0} {1}",e.Key,e.Value);
                }
            }

            //ranglista.Select(a=>a.valtozas,cou)
            var stat2 =
                    from a in ranglista
                    group a by a.valtozas into valt
                    orderby valt.Key
                    select valt;

            var stat3 = ranglista.GroupBy(a=>a.valtozas)
                        .Select(cs => new { valtozas=cs.Key,darab=cs.Count()});
            foreach (var e in stat2)
            {
                Console.WriteLine("{0} {1}", e.Key,e.Count());
            }
        }


    }
    class adatok
    {
        public string csapat;
        public int helyezes, valtozas, pontszam;
        public adatok(string sor)
        {
            string[] vag = sor.Split(";");
            csapat = vag[0];
            helyezes = Convert.ToInt32(vag[1]);
            valtozas = Convert.ToInt32(vag[2]);
            pontszam = Convert.ToInt32(vag[3]);
        }
    }
}
