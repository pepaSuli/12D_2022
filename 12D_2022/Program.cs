using System;
using System.Collections.Generic;
using System.IO;

namespace _12D_2022
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nevek = new List<string>();
            string[] sorok = File.ReadAllLines("nevsor.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                nevek.Add(sorok[i]);
            }

            List<int> tetelek = new List<int>();
            for (int i = 1; i < 21; i++)
            {
                tetelek.Add(i);
            }

            Random rand = new Random();

            StreamWriter ir = new StreamWriter("sorsolas.txt");
            for (int i = 0; i < nevek.Count; i++)
            {
                int szam = rand.Next(0, tetelek.Count);
                Console.WriteLine("{0}: {1}. témakör", nevek[i], tetelek[szam]);
                ir.WriteLine("{0}: {1}. témakör", nevek[i], tetelek[szam]);

                tetelek.RemoveAt(szam);
            }

            for (int i = 0; i < tetelek.Count; i++)
            {
                int szam = rand.Next(0, nevek.Count);
                Console.WriteLine("{0}: {1}. témakör", nevek[szam], tetelek[i]);
                ir.WriteLine("{0}: {1}. témakör", nevek[szam], tetelek[i]);
                nevek.RemoveAt(szam);
            }

            ir.Close();
        }
    }
}
