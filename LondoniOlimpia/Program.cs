using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LondoniOlimpia
{
    class Program
    {
        static List<adatok> sportok = new List<adatok>();
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("London2012.txt");

            for (int i = 0; i < sorok.Length; i++)
            {
                sportok.Add(new adatok(sorok[i]));
            }

            for (int i = 0; i < sportok.Count; i++)
            {
                if (sportok[i].nev == "Atlétika")
                {
                    Console.WriteLine("Atlétikai döntős napok száma: {0}", sportok[i].dontosNap());
                }
            }
            //Linq
            Console.WriteLine("Atlétikai döntők száma: {0}",
                    sportok.Find(e => e.nev == "Atlétika").dontosNap());
           
            
            for (int i = 0; i < sportok.Count; i++)
            {
                if (sportok[i].nev == "Úszás")
                {
                    Console.WriteLine("Úszás döntők száma: {0}", sportok[i].dontoDb());
                }
            }
            //Linq
            Console.WriteLine("Úszás döntők száma: {0}",
                    sportok.Find(e => e.nev == "Úszás").dontoDb());



            List<int> napiDonto = new List<int>();
            int max = 0, maxindex = 0;
            for (int i = 0; i < sportok[0].dontok.Count; i++)
            {
                int db = 0;
                for (int k = 0; k < sportok.Count; k++)
                {
                    db += sportok[k].dontok[i];
                }
                napiDonto.Add(db);
                if(db>max)
                {
                    max = db;
                    maxindex = i;
                }
            }
            int nap= maxindex + 28;
            if(nap>32)
            {
                nap -= 31;
            }
            Console.WriteLine("legtöbb döntő: {0}, {1}.",max,nap);


            Console.WriteLine("össz döntő: {0}", sportok.Sum(e=>e.dontoDb()));


            Console.WriteLine("29. döntő: {0}", napiDonto[29-28]);

        }
    }

    class adatok
    {
        public string nev;
        public List<int> dontok = new List<int>();
        public adatok(string sor)
        {
            string[] vag = sor.Split(";");
            nev = vag[0];
            for (int i = 1; i < vag.Length; i++)
            {
                dontok.Add(Convert.ToInt32(vag[i]));
            }
        }

        public int dontosNap()
        {
            int db = 0;
            for (int i = 0; i < dontok.Count; i++)
            {
                if (dontok[i] > 0)
                {
                    db++;
                }
            }
            //Linq
            //return dontok.Count(i => i > 0);
            return db;

        }
        public int dontoDb()
        {
            int db = 0;
            for (int i = 0; i < dontok.Count; i++)
            {
                db+= dontok[i];
            }

            //Linq
            //return dontok.Sum();
            //Console.WriteLine(dontok.Sum());
            return db;

        }
    }
}
