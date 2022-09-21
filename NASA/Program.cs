using System;
using System.Collections.Generic;
using System.IO;

namespace NASA
{
    class Program
    {
        static void Main(string[] args)
        {
            feladat f = new feladat();
        }
    }
    class feladat
    {
        public feladat()
        {
            f4();
            f5();
            f6();
            f7();
        }

        List<adatok> log = new List<adatok>();
        void f7()
        {
            int db = 0;
            for (int i = 0; i < log.Count; i++)
            {
                if (log[i].Domain())
                {
                    db++;
                }
            }
            Console.WriteLine("8. feladat: Domain-es kérések: {0:0.00%}", (double)db/log.Count);

        }
        void f4()
        {
            string[] sorok = File.ReadAllLines("NASAlog.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                log.Add(new adatok(sorok[i]));
            }
        }
        void f5()
        {
            Console.WriteLine("5. feladat: Kérések száma: {0}", log.Count);
        }
        void f6()
        {
            for (int i = 0; i < log.Count; i++)
            {
                Console.WriteLine(log[i].ByteMeret());
            }
            /*
            Console.WriteLine("------------");
            Console.WriteLine(log[0].domain);
            Console.WriteLine(log[0].Domain());
            Console.WriteLine(log[6].domain);
            Console.WriteLine(log[6].Domain());
            Console.WriteLine(Convert.ToInt32('9'));
        }*/
        }
        class adatok
        {
            public string domain;
            public string datum;
            public string kep;
            public int kod;
            public int meret;
            public adatok(string sor)
            {
                //rn3.swc.com*20/Jul/1995:12:55:04*GET /images/small.jpg*200 46573
                string[] vag = sor.Split("*");
                /*
                 * rn3.swc.com
                 * 20/Jul/1995:12:55:04
                 * GET /images/small.jpg
                 * 200 46573
                 * */
                domain = vag[0];
                datum = vag[1];
                kep = vag[2];
                string[] vag2 = vag[3].Split(" ");

                kod = Convert.ToInt32(vag2[0]);
                if (vag2[1] == "-")
                {
                    meret = 0;
                }
                else
                {
                    meret = Convert.ToInt32(vag2[1]);
                }

            }

            public int ByteMeret()
            {
                return meret;
            }

            public bool Domain()
            {/*
            try
            {
                Console.WriteLine(Convert.ToInt32(domain[domain.Length - 1]));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            */

                return domain[domain.Length - 1] > '9' || domain[domain.Length - 1] < '0';
            }
        }
    }
}
