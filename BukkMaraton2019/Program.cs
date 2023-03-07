using System;
using System.Collections.Generic;
using System.IO;

namespace BukkMaraton2019
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
        List<adatok> verseny = new List<adatok>();

        public feladat()
        {
            f3();
            f4();
        }
        void f4()
        {
            Console.WriteLine("4. feladat: Versenytávot nem teljesítők: {0:.0000000000%}",(691-verseny.Count)/691.0);
        }
        void f3()
        {
            string[] sorok = File.ReadAllLines("bukkm2019.txt");

            for (int i = 1; i < sorok.Length; i++)
            {
                verseny.Add(new adatok(sorok[i]));
            }

        }
    }
    class adatok
    {
        public string rajtszam, kategoria, nev, egyesulet, ido;

        public adatok(string sor)
        {
            string[] vag = sor.Split(";");
            rajtszam = vag[0];
            kategoria = vag[1];
            nev = vag[2];
            egyesulet = vag[3];
            ido = vag[4];
  
        }
    }

    class Versenytav
    {
        private string Rajtszam;
        public string Tav
        {
            get
            {
                switch (Rajtszam[0])
                {
                    case 'M': return "Mini";
                    case 'R': return "Rövid";
                    case 'K': return "Közép";
                    case 'H': return "Hosszú";
                    case 'E': return "Pedelec";
                }
                return "Hibás rajtszám";
            }
        }
        public Versenytav(string rajtszam)
        {
            Rajtszam = rajtszam;
        }
    }

}
