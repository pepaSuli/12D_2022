using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace rovid2006majus
{
    class Program
    {
        static void Main(string[] args)
        {
            List<adatok> tozsde = new List<adatok>();

            StreamReader olvas = new StreamReader("ECegArf.txt");
            while(!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                tozsde.Add(new adatok(sor));
            }

            olvas.Close();

            adatok legstabilabb = tozsde[0];
            for (int i = 1; i < tozsde.Count; i++)
            {
                if(tozsde[i].stabilitas()<legstabilabb.stabilitas())
                {
                    legstabilabb = tozsde[i];
                }
            }
            Console.WriteLine("{0} {1}",legstabilabb.nev,legstabilabb.stabilitas());

            for (int i = 0; i < tozsde.Count; i++)
            {
                Console.WriteLine(tozsde[i].nev);
            }

            //tozsde.Sort();
            List<adatok> SortedList = tozsde.OrderBy(o => o.stabilitas()).ToList();
            tozsde.Sort((x, y) => x.stabilitas().CompareTo(y.stabilitas()));


            for (int i = 0; i < SortedList.Count; i++)
            {
                Console.WriteLine(SortedList[i].nev);
            }
        }
    }

    class adatok
    {
        public string nev;
        public int[] arfolyamok = new int[7];
        public adatok(string sor)
        {
            //1500 1709 1839 1948 1923 1930 1944 Alfa Bt.
            string[] vag = sor.Split(' ');
            for (int i = 0; i < 7; i++)
            {
                arfolyamok[i] = Convert.ToInt32(vag[i]);
            }

            nev = "";
            for (int i = 7; i < vag.Length; i++)
            {
                if (nev != "")
                {
                    nev += " ";
                }

                nev+=vag[i];
            }
        }

        public double stabilitas()
        {
            double stabil = 0;
            for (int i = 1; i < arfolyamok.Length; i++)
            {
                stabil += Math.Abs(arfolyamok[i - 1] - arfolyamok[i]);
            }

            return stabil / (arfolyamok.Length - 1);
        }
    }
}
