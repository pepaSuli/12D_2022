using System;
using System.IO;

namespace Kiralynok
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("4. feladat: Az üres tábla:");


            Tabla tabla = new Tabla('o');
            tabla.Megjelenít();

            tabla.Elhelyez(8);
            Console.WriteLine("6. feladat: A feltöltött tábla:");
            tabla.Megjelenít();

            Console.WriteLine("9. feladat: üres sorok és oszlopok száma:");
            Console.WriteLine("Oszlopok: {0}", tabla.ÜresOszlopokSzáma);
            Console.WriteLine("Sorok: {0}", tabla.ÜresSorokSzáma);
        
            if(File.Exists("tablak64.txt"))
            {
                File.Delete("tablak64.txt");
            }

            StreamWriter ir = new StreamWriter("tablak.txt");
            for (int i = 0; i < 64; i++)
            {
                Tabla valami = new Tabla('*');
                valami.Elhelyez(i+1);
                ir.WriteLine(valami);
            }

            ir.Close();
        }
    }

    class Tabla
    {
        char[,] T;
        char ÜresCella;
        public Tabla(char ertek)
        {
            T = new char[8, 8];
            ÜresCella = ertek;

            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    T[i, k] = ÜresCella;
                }
            }
        }

        public void Megjelenít()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    Console.Write(T[i,k]);
                }
                Console.WriteLine();
            }
        }

        Random rand = new Random();
        public void Elhelyez(int N)
        {
            for (int i = 0; i < N; i++)
            {
                int oszlop = rand.Next(8);
                int sor = rand.Next(8);
                if(T[oszlop,sor]=='K')
                {
                    i--;
                }
                else
                {
                    T[oszlop, sor] = 'K';
                }
            }
        }

        public bool ÜresOszlop(int oszlop)
        {
            bool volt = false;
            for (int i = 0; i < 8; i++)
            {
                if(T[oszlop,i]==ÜresCella)
                {
                }
                else
                {
                    volt = true;
                }
            }

            return !volt;
        }
        public bool ÜresSor(int sor)
        {
            bool volt = false;
            for (int i = 0; i < 8; i++)
            {
                if (T[i, sor] == ÜresCella)
                {
                }
                else
                {
                    volt = true;
                }
            }

            return !volt;
        }

        public int ÜresOszlopokSzáma
        {
            get
            {
                int db=0;
                for (int i = 0; i < 8; i++)
                {
                    if(ÜresOszlop(i))
                    {
                        db++;
                    }
                }
                return db;
            }
        }
        public int ÜresSorokSzáma
        {
            get
            {
                int db = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (ÜresSor(i))
                    {
                        db++;
                    }
                }
                return db;
            }
        }

        public override string ToString()
        {
            string vissza = "";
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < 8; k++)
                {
                    vissza+=T[i, k];
                }
//                vissza += System.Environment.NewLine;
                vissza +="\n";
            }

            return vissza;
        }
    }
}
