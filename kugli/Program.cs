using System;
using System.Collections.Generic;
using System.IO;

namespace kugli
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("eredm1.txt");

            List<adatok> eredmeny = new List<adatok>();
            for (int i = 0; i < sorok.Length; i+=2)
            {
                eredmeny.Add(new adatok(sorok[i], sorok[i + 1]));
            }

            Console.WriteLine("2. feladat");
            for (int i = 1; i < eredmeny.Count; i++)
            {
                if(eredmeny[i-1].pont>eredmeny[i].pont)
                {
                    Console.WriteLine(eredmeny[i].nev);
                }
            }

            List<List<adatok>> meccs = new List<List<adatok>>();
            meccs.Add(eredmeny);

            for (int k  = 2; k < 5; k++)
            {
                sorok = File.ReadAllLines("eredm"+k+".txt");

                eredmeny = new List<adatok>();
                for (int i = 0; i < sorok.Length; i += 2)
                {
                    eredmeny.Add(new adatok(sorok[i], sorok[i + 1]));
                }
                meccs.Add(eredmeny);
            }

            Dictionary<string, int> stat = new Dictionary<string, int>();
            for (int i = 0; i < meccs.Count; i++)
            {
                for (int k = 0; k < meccs[i].Count; k++)
                {
                    if(stat.ContainsKey(meccs[i][k].nev))
                    {
                        if(meccs[i][k].pont<10)
                        {
                            stat[meccs[i][k].nev] += meccs[i][k].pont;
                        }
                    }
                    else
                    {
                        stat.Add(meccs[i][k].nev, meccs[i][k].pont);
                    }
                }
            }

            Console.WriteLine("4. feladat");
            foreach (KeyValuePair<string,int> item in stat)
            {
                Console.WriteLine("{0}\t{1}",item.Key,item.Value);
            }


            KeyValuePair<string, int> max = new KeyValuePair<string, int>("",0);
            foreach (var item in stat)
            {
                if(item.Value>max.Value)
                {
                    max = item;
                }
            }
 
            Console.WriteLine("5. feladat");
            Console.WriteLine("A nyertes: {0}, {1} pont",max.Key,max.Value);

            Console.WriteLine("6. feladat");
            List<string> kiesettNev = new List<string>();
            List<int> kiesettPont = new List<int>();

            for (int i = 0; i < meccs.Count; i++)
            {
                for (int k = 0; k < meccs[i].Count; k++)
                {
                    if(meccs[i][k].pont==10)
                    {
                        if(!kiesettNev.Contains(meccs[i][k].nev))
                        {
                            kiesettNev.Add(meccs[i][k].nev);
                            kiesettPont.Add(i);
                        }
                        //Console.WriteLine("{0}, {1}. kör", meccs[i][k].nev,i);
                    }
                }
            }

            for (int i = 0; i < kiesettNev.Count; i++)
            {
                Console.WriteLine("{0}, {1}. kör", kiesettNev[i], kiesettPont[i]);
            }

            Console.WriteLine("7. feladat");
            kiesettNev = new List<string>();
            kiesettPont = new List<int>();

            for (int i = 0; i < meccs.Count; i++)
            {
                for (int k = 0; k < meccs[i].Count; k++)
                {
                    if (meccs[i][k].pont == 9)
                    {
                        if (!kiesettNev.Contains(meccs[i][k].nev))
                        {
                            kiesettNev.Add(meccs[i][k].nev);
                            kiesettPont.Add(i+1);
                        }
                        //Console.WriteLine("{0}, {1}. kör", meccs[i][k].nev,i);
                    }
                }
            }

            for (int i = 0; i < kiesettNev.Count; i++)
            {
                Console.WriteLine("{0}, {1}. kör", kiesettNev[i], kiesettPont[i]);
            }

        }
    }

    class adatok
    {
        public string nev;
        public int pont;
        public adatok(string nev, string szam)
        {
            this.nev = nev;
            pont = Convert.ToInt32(szam);
        }
    }
}
