using System;
using System.Collections.Generic;
using System.IO;

namespace vb2018
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] adatok = new string[50];
            adatok = File.ReadAllLines("vb2018.txt");


            string[] adatok2 = new string[50];
            StreamReader olvas = new StreamReader("vb2018.txt");
            int i = 0;

            List<string> varos = new List<string>();
            List<string> nev1 = new List<string>();
            List<string> nev2 = new List<string>();
            List<int> ferohely = new List<int>();

            //olvas.ReadLine();
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                adatok2[i] = sor;
                string[] vag = sor.Split(";");
                if(i==0)
                {
                }
                else
                {

                    //Moszkva
                    //Luzsnyiki Stadion
                    //n.a.
                    //78011
                    varos.Add(vag[0]);
                    nev1.Add(vag[1]);
                    nev2.Add(vag[2]);
                    //Console.WriteLine(vag[3]);
                    ferohely.Add(Convert.ToInt32(vag[3]));
                }

                i++;
            }
            olvas.Close();



            int db = 0;
            for ( i = 0; i < nev1.Count; i++)
            {
                db++;
            }
            Console.WriteLine("3. feladat: Stadionok száma: {0}", db);
            Console.WriteLine("3. feladat: Stadionok száma: {0}", nev1.Count);

            int min = ferohely[0];
            int minIndex = 0;
            for (i = 0; i < ferohely.Count; i++)
            {
                if(min>ferohely[i])
                {
                    min = ferohely[i];
                    minIndex = i;
                }
            }
            Console.WriteLine("4. feladat: A legkevesebb férőhely:");
            Console.WriteLine("\tVáros: {0}", varos[minIndex]);
            Console.WriteLine("\tStadion neve: {0}", nev1[minIndex]);
            Console.WriteLine("\tFérőhely: {0}", ferohely[minIndex]);

            double eredmeny = 0;
            for (i = 0; i < ferohely.Count; i++)
            {
                eredmeny += ferohely[i];
            }

            Console.WriteLine("5. feladat: Átlagos férőhelyszám: {0:0.0}",eredmeny/ferohely.Count);

            db = 0;
            for (i = 0; i < nev2.Count; i++)
            {
                if(nev2[i]!= "n.a.")
                {
                    db++;
                }
            }
            Console.WriteLine("6. feladat: Két néven is ismert stadionok száma: {0}",db);


            Console.Write("7. feladat: Kérem a város nevét: ");
            string varosnev = Console.ReadLine();
            while(varosnev.Length<3)
            {
                Console.Write("7. feladat: Kérem a város nevét: ");
                varosnev = Console.ReadLine();
            }

            bool volt = false;
            //moszkva
            //moSZkva Moszkva
            for (i = 0; i < varos.Count; i++)
            {
                if(varosnev.ToLower()==varos[i].ToLower())
                {
                    volt = true;
                    Console.WriteLine("8. feladat: A megadott város VB helyszin.");
                    break;
                }
            }
            
            if(!volt)
            {
                Console.WriteLine("8. feladat: A megadott város nem VB helyszin.");
            }

            List<string> egyediVaros = new List<string>();
            HashSet<string> l = new HashSet<string>();
            for (i = 0; i < varos.Count; i++)
            {
                l.Add(varos[i]);
                if (!egyediVaros.Contains(varos[i]))
                {
                    egyediVaros.Add(varos[i]);
                }
            }

            Console.WriteLine("9.feladat: {0} különböző város voltak mérkőzések.", egyediVaros.Count);
            Console.WriteLine("9.feladat: {0} különböző város voltak mérkőzések.", l.Count);


            File.WriteAllLines("varosok.txt", egyediVaros);

        }
    }
}
