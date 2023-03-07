using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meccsek
{
    internal class Program
    {
        static List<jatekos> jatekosok=new List<jatekos>();
        static List<meccs>  meccsek=new List<meccs>();
        static void Main(string[] args)
        {
            StreamReader olvas = new StreamReader("input.txt");

            string sor= olvas.ReadLine();
            while(sor!="*")
            {
                string[] vag = sor.Split(' ');
                int mezszam = Convert.ToInt32(vag[1]);

                bool vanBenne = false;
                for (int i = 0; i < jatekosok.Count; i++)
                {
                    if(jatekosok[i]==mezszam)
                    {
                        vanBenne = true;
                    }
                }

                if (!vanBenne)
                {
                    jatekosok.Add(new jatekos(sor));
                }

                sor = olvas.ReadLine();
            }


            while (!olvas.EndOfStream)
            {

                sor = olvas.ReadLine();
                string szoveg = "";
                while (sor != "*")
                {
                    if (szoveg != "")
                    {
                        szoveg += "\n";
                    }

                    szoveg += sor;

                    sor = olvas.ReadLine();
                }
                if(szoveg!="")
                {
                    meccsek.Add(new meccs(szoveg));
                }
            }

            olvas.Close();


            for (int i = 0; i < jatekosok.Count; i++)
            {
                Console.WriteLine(jatekosok[i]);
            }

            for (int i = 0; i < meccsek.Count; i++)
            {
                Console.WriteLine(meccsek[i]);
            }
        }
    }


    class jatekos   {
        string nev;
        int mezszam;
        string poszt;

        public jatekos(string sor)
        {
            string[] vag = sor.Split(' ');
            nev= vag[0];
            mezszam=Convert.ToInt32(vag[1]);
            poszt= vag[2];
        }

        //j2==2
        public static bool operator ==(jatekos j,int mez)
        {
            return j.mezszam == mez;
        }
        public static bool operator !=(jatekos j, int mez)
        {
            return j.mezszam != mez;
        }
        //2==j2
        public static bool operator ==(int mez, jatekos j)
        {
            return j.mezszam == mez;
        }
        public static bool operator !=(int mez, jatekos j)
        {
            return j.mezszam != mez;
        }
        public static bool operator ==(jatekos j1, jatekos j2)
        {/*
            if (ReferenceEquals(obj1, obj2))
                return true;
            if (ReferenceEquals(obj1, null))
                return false;
            if (ReferenceEquals(obj2, null))
                return false;
            return obj1.Equals(obj2);*/
            return false;
        }
        public static bool operator !=(jatekos j1, jatekos j2)
        {
            return false;
        }

        public  string Equals(int mez)
        {
            return base.ToString();
        }

        public override string ToString()
        {
            return mezszam + " " + nev + " " + poszt; 
        }
    }


    class meccs
    {
        string ellenfel;
        string datum;
        int[,] resztvevok;

        public meccs(string sor)
        {
            /*
                Dabas
                2019.08.23.
                1 1
                16 0
                2 3
                5 3
                15 2
                18 3
                24 6
                25 1
                26 6
                30 0
                31 2
                35 4
                51 2
                66 3
             * */

            string[] vag = sor.Split('\n');
            ellenfel= vag[0];
            datum= vag[1];
            resztvevok = new int[vag.Length-2, 2];
            for (int i = 2; i < vag.Length; i++)
            {
                //"1 1"
                string[] darabol = vag[i].Split(' ');

                resztvevok[i - 2, 0] = Convert.ToInt32(darabol[0]);
                resztvevok[i - 2, 1] = Convert.ToInt32(darabol[1]);
            }

        }
        int golokSzama()
        {
            int db = 0;
            for (int i = 0; i < resztvevok.GetLength(0); i++)
            {
                db += resztvevok[i, 1];
            }

            return db;
        }
        public override string ToString()
        {
            return ellenfel+" ("+datum+") "+ resztvevok.GetLength(0)+" játékos, "
                    + golokSzama() + " gól";
        }
    }
}
