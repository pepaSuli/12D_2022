using System;
using System.Collections.Generic;
using System.IO;

namespace Uzemanyag
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
        List<adatok> arvaltozasok = new List<adatok>();
        public feladat()
        {
            f2();
            f3();
            f4();
            f5();
            f6();
            f7();
        }
        void f7()
        {
            const double euro = 307.7;
            StreamWriter ir = new StreamWriter("euro.txt");
            for (int i = 0; i < arvaltozasok.Count; i++)
            {

            }
            ir.Close();
        }

        void f6()
        {
            int almafa = 0;
            for (int i = 0; i < arvaltozasok.Count; i++)
            {
                if(arvaltozasok[i].szokoNap())
                {
                    almafa = 1;
                    Console.WriteLine("6. feladat: Volt.");
                }
            }

            if(almafa==0)
            {
                Console.WriteLine("6. feladat: Nem volt.");
            }

        }

        void f5()
        {
            int db = 0;
            for (int i = 0; i < arvaltozasok.Count; i++)
            {
                if(arvaltozasok[i].kulonbseg()==min)
                {
                    db++;
                }
            }

            Console.WriteLine("5. feladat: {0}",db);
        }
        int min;
        void f4()
        {
            min = 1000000;
            for (int i = 0; i < arvaltozasok.Count; i++)
            {
                if(arvaltozasok[i].kulonbseg()<min)
                {
                    min = arvaltozasok[i].kulonbseg();
                }
            }
            Console.WriteLine("4. feladat: Legkisebb különbség {0}",min);
        }
        void f3()
        {
            Console.WriteLine("3. feladat: Változások száma: {0}",arvaltozasok.Count);
        }

        void f2()
        {
            string[] sorok = File.ReadAllLines("uzemanyag.txt");

            for (int i = 0; i < sorok.Length; i++)
            {
                arvaltozasok.Add(new adatok(sorok[i]));
            }
        }
    }
    class adatok
    {
        public string datum;
        public int benzin, gazolaj;
        public adatok(string sor)
        {
            string[] vag = sor.Split(";");

            datum = vag[0];
            benzin = Convert.ToInt32(vag[1]);
            gazolaj = Convert.ToInt32(vag[2]);
        }
        public int kulonbseg()
        {
            if(benzin>gazolaj)
            {
                return benzin - gazolaj;
            }
            else
            {
                return gazolaj - benzin;
            }

            return Math.Abs(benzin - gazolaj);
        }

        public bool szokoNap()
        {
            //"2011.01.12"
            //"2011"
            //"01"
            //"12"

            string[] vag = datum.Split(".");

            if (Convert.ToInt32(vag[0]) % 4 == 0)
            {
                return vag[1] == "02" && vag[2] == "24";
            }
            else
            {
                return false;
            }

        }
    }
}
