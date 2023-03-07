using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            feladat f = new feladat();
        }
    }

    class feladat
    {
        List<adatok> viragok=new List<adatok>();
        public feladat()
        {
            f1();
            f2();
            f3();
            f4();
          //  f_5();
            //f_6();
            f5();
            f6();
        }
        void f6()
        {
            StreamWriter ir = new StreamWriter("szinek.txt");

            for (int i = 0; i < szinek.Length; i++)
            {
                ir.WriteLine("{0} {1}", szinek[i], sorszam[i]);
            }

            ir.Close();
        }

        string[] szinek;
        int[] sorszam;
        void f5()
        {
            Console.WriteLine("5. feladat");
            szinek = new string[agyasDarab];
            sorszam = new int[agyasDarab];

            for (int i = 0; i < agyasDarab; i++)
            {
                szinek[i] = "#";
                sorszam[i] = 0;
                for (int k = 0; k < viragok.Count; k++)
                {
                    if(viragok[k].bennVanE(i))
                    {
                        szinek[i] = viragok[k].szin;
                        sorszam[i] = k + 1;
                    }
                }
            }

            int db = 0;
            for (int i = 0; i < szinek.Length; i++)
            {
                if(szinek[i]=="#")
                {
                    db++;
                }
            }

            int osszeg = 0;
            for (int i = 0; i < viragok.Count; i++)
            {
                osszeg += viragok[i].darab;
            }



            //Console.WriteLine(db);
            if(db==0)
            {
                Console.WriteLine("Minden ágyás beültetésére van jelentkező.");
            }
            else if(osszeg>=agyasDarab)
            {
                Console.WriteLine("Átszervezéssel megoldható a beültetés.");
            }
            else
            {
                Console.WriteLine("A beültetés nem oldható meg.");
            }
        }



        void f_6()
        {
            string[] szinek = new string[viragok[0].osszes];
            for (int i = 0; i < szinek.Length; i++)
            {
                szinek[i] = "# 0";
                for (int k = 0; k < viragok.Count; k++)
                {
                    if (viragok[k].bennVanE(i + 1))
                    {
                        szinek[i] = viragok[k].szin+" "+ (i+1);
                        break;
                    }
                }
            }

            File.WriteAllLines("szinek.txt", szinek);

        }
        void f_5()
        {
            int osszes = 0;
            for (int k = 0; k < viragok.Count; k++)
            {
                osszes += viragok[k].osszes;
            }

            string[] szinek=new string[viragok[0].osszes];
            for (int i = 0; i < szinek.Length; i++)
            {
                szinek[i] = "#";
                for (int k = 0; k < viragok.Count; k++)
                {
                    if (viragok[k].bennVanE(i+1))
                    {
                        szinek[i] = viragok[k].szin;
                        break;
                    }
                }
            }

            int db = 0;

            for (int i = 0; i < szinek.Length; i++)
            {
                if(szinek[i]=="#")
                {
                    db++;
                }
            }

            if (db == 0)
            {
                Console.WriteLine("Minden ágyás beültetésére van jelentkező.");
            }
            else if (osszes >= viragok[0].osszes)
            {
                Console.WriteLine("Átszervezéssel megoldható a beültetés.");
            }
            else
            {
                Console.WriteLine("A beültetés nem oldható meg."); 
            }

        }

        void f4()
        {
            Console.WriteLine("4. feladat");
            Console.Write("Adja meg az ágyás sorszámát! ");
            int szam = Convert.ToInt32(Console.ReadLine());
            /*A felajánlók száma: 8
A virágágyás színe, ha csak az első ültet: Z
A virágágyás színei: O Z S K 
             */
            int db = 0;
            for (int i = 0; i < viragok.Count; i++)
            {
                if (viragok[i].bennVanE(szam))
                {
                    db++;
                }
            }
            Console.WriteLine("A felajánlók száma: {0}",db);

            string szin = "";
            for (int i = 0; i < viragok.Count; i++)
            {
                if (viragok[i].bennVanE(szam))
                {
                    szin = viragok[i].szin;
                    break;
                }
            }
            
            if(szin!="")
            {
                Console.WriteLine("A virágágyás színe, ha csak az első ültet: ",szin);
            }
            else
            {
                Console.WriteLine("Ezt az ágyást nem ültetik be.");
            }

            string szinek = "";
            for (int i = 0; i < viragok.Count; i++)
            {
                if (viragok[i].bennVanE(szam))
                {
                    if(szinek.IndexOf(viragok[i].szin)==-1)
                    {
                        szinek += " " + viragok[i].szin;
                    }
                }
            }
            
            if(szinek!="")
            {
                Console.WriteLine("A virágágyás színei:{0}",szinek);
            }
        }
        int agyasDarab = 0;
        void f1()
        {
            string[] sorok = File.ReadAllLines("felajanlas.txt");
            agyasDarab = Convert.ToInt32(sorok[0]);

            for (int i = 1; i < sorok.Length; i++)
            {
                viragok.Add(new adatok(sorok[i], sorok[0]));
            }
        }
        void f2()

        {
            Console.WriteLine("2. feladat: \nA felajánlások száma: {0}",viragok.Count);
        }

        void f3()
        {
            Console.WriteLine("3. feladat");
            Console.Write("A bejárat mindkét oldalán ültetők: ");
            for (int i = 0; i < viragok.Count; i++)
            {
                if (viragok[i].kapu())
                {
                    Console.Write(" {0}", i + 1);
                }
            }


            Console.WriteLine();
        
        }
    }
    class adatok
    {
        public int kezdo, veg;
        public string szin;
        public adatok(string sor)
        {
            //716 751 P
            string[] vag = sor.Split(' ');
            kezdo = Convert.ToInt32(vag[0]);
            veg = Convert.ToInt32(vag[1]);
            szin = vag[2];
        }

        //5. feladathoz
        public int osszes;
        public int darab;
        public adatok(string sor, string ossz)
        {
            osszes = Convert.ToInt32(ossz);
            string[] vag = sor.Split(' ');
            kezdo = Convert.ToInt32(vag[0]);
            veg = Convert.ToInt32(vag[1]);
            szin = vag[2];

            if(!kapu())
            {
                darab = veg - kezdo + 1;
            }
            else
            {
                darab = osszes - kezdo + 1 + veg;
            }

        }
        public bool kapu()
        {
            return kezdo > veg;
        }

        public bool bennVanE(int szam)
        {
            if(!kapu())
            {
                return kezdo<=szam && szam<=veg;
            }
            else
            {
                return kezdo<= szam || szam <= veg;
            }

        }



        //5. feladathoz
        public int db()
        {
            if (!kapu())
            {
                return veg-kezdo+1;
            }
            else
            {
                return osszes-kezdo + 1 + veg;
            }
        }
    }
}
