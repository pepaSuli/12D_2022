using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace polorendeles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            feladat f = new feladat();
        }
    }

    class feladat
    {
        List<adatok> rendelesek = new List<adatok>();
        public feladat()
        {
            f1();
            f5();
            f6();
            f7();
            f8();
            f8();
        }
        void f9()
        {
            List<adatok> rendelesek9a = new List<adatok>();
            for (int i = 0; i < rendelesek.Count; i++)
            {
                if (rendelesek[i].osztaly == "9.b")
                {
                    rendelesek9a.Add(rendelesek[i]);
                }
            }

            //rendelesek9a.Sort()
            List<adatok> SortedList = rendelesek9a
                                        .OrderBy(o => o.nev)
                                        .ToList();

            for (int i = 0; i < SortedList.Count; i++)
            {
                Console.WriteLine(SortedList[i].nev);
            }

        }
        void f8()
        {
            List<adatok> rendelesek9a = new List<adatok>();
            for (int i = 0; i < rendelesek.Count; i++)
            {
                if(rendelesek[i].osztaly=="9.a")
                {
                    rendelesek9a.Add(rendelesek[i]);
                }
            }

            //rendelesek9a.Sort()
            List<adatok> SortedList = rendelesek9a
                                        .OrderBy(o => o.nev)
                                        .ToList();

            StreamWriter ir = new StreamWriter("9b.txt");
            for (int i = 0; i < SortedList.Count; i++)
            {
                ir.Write("{0}  ", SortedList[i].nev);
                ir.Write(" S: {0} M: {1} L: {2} XL: {3}", SortedList[i].meretek[0], rendelesek[i].meretek[1], rendelesek[i].meretek[2], rendelesek[i].meretek[3]);
                ir.Write(" {0} darab", SortedList[i].db);
                ir.WriteLine(" {0} Ft", SortedList[i].fizetendo());
            }
            ir.Close();
        }
        void f7()
        {
            Console.Write("Kérek egy nevet (pl. Müszi Mátyás): ");
            string nev = Console.ReadLine();

            int id = -1;
            for (int i = 0; i < rendelesek.Count; i++)
            {
                if(rendelesek[i].nev==nev)
                {
                    id = i;
                    break;
                }
            }

            if(id==-1)
            {
                Console.WriteLine("Nincs ilyen.");
            }
            else
            {
                Console.WriteLine("osztálya: {0}",rendelesek[id].osztaly);
                Console.WriteLine("Pólók: S: {0} M: {1} L: {2} XL: {3}", rendelesek[id].meretek[0], rendelesek[id].meretek[1], rendelesek[id].meretek[2], rendelesek[id].meretek[3]);
                Console.WriteLine("összesen: {0} darab", rendelesek[id].db);
                Console.WriteLine("fizetendő: {0} Ft",rendelesek[id].fizetendo());
            }
        }
        void f6()
        {
            Dictionary<string, int[]> darabok = new Dictionary<string, int[]>();
            for (int i = 0; i < rendelesek.Count; i++)
            {
                if(darabok.ContainsKey(rendelesek[i].osztaly))
                {
                    //rendelesek[i].meretek
                    for (int k = 0; k < rendelesek[i].meretek.Length; k++)
                    {
                        darabok[rendelesek[i].osztaly][k] += rendelesek[i].meretek[k];
                    }
                }
                else
                {
                    darabok.Add(rendelesek[i].osztaly, rendelesek[i].meretek);
                }

            }

            foreach(var e in darabok)
            {
                Console.WriteLine("{0}: {1} {2} {3} {4}",e.Key, e.Value[0], e.Value[1], e.Value[2], e.Value[3]);
            }
        }
        void f5()
        {
            int[] osszes = new int[4];
            for (int i = 0; i < rendelesek.Count; i++)
            {
                for (int k = 0; k < osszes.Length; k++)
                {
                    osszes[k]+=rendelesek[i].meretek[k];
                }
            }

            int darab = 0;
            for (int k = 0; k < osszes.Length; k++)
            {
                darab+=osszes[k];
            }

            Console.WriteLine("összes poló: {0} db",darab);
            Console.WriteLine("Ennyibe kerül: {0} Ft",darab*1500);

        }
        void f1()
        {
            string[] sorok = File.ReadAllLines("poloadat.txt");

            for (int i = 7; i < sorok.Length; i++)
            {
                rendelesek.Add(new adatok(sorok[i]));
            }

        }
    }

    class adatok
    {
        public string nev, osztaly;
        public int[] meretek = new int[4];
        public int db;
        public int egysegar = 1500;
        public adatok(string sor)
        {
            string[] vag = sor.Split('\t');

            nev = vag[0];
            osztaly = vag[1];

            for (int i = 0; i < 4; i++)
            {
                if (vag[2+i] != "")
                {
                    meretek[0+i] = Convert.ToInt32(vag[2+i]);
                }
            }

            db = 0;
            for (int i = 0; i < meretek.Length; i++)
            {
                db += meretek[i];
            }
        }
        public int fizetendo()
        {
            return db * egysegar;
        }
    }

}
