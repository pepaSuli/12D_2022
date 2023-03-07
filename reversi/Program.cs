using System;
using System.IO;

namespace reversi
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabla t = new Tabla("allas.txt");

            Console.WriteLine("5. feladat: A betöltött tábla");
            t.Megjelenit();

            Console.WriteLine("6. feladat: Összegzés");
            Console.WriteLine("\tKék korongok száma: {0}", t.Darab('K'));
            Console.WriteLine("\tFehér korongok száma: {0}", t.Darab('F'));
            Console.WriteLine("\tÜres mezők száma: {0}", t.Darab('#'));

            Console.WriteLine("8. feladat");
            string lepes = "F;4;1;0;1";
        }
    }


    class Tabla
    {
        public char[,] t = new char[8, 8];
        public int Darab(char keres)
        {
            int db = 0;
            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int k = 0; k < t.GetLength(1); k++)
                {
                    if(t[i, k]==keres)
                    {
                        db++;
                    }
                }
            }

            return db;
        }

        public void Megjelenit()
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {
                Console.Write("\t");
                for (int k = 0; k < t.GetLength(1); k++)
                {
                    Console.Write(t[i, k]);
                }
                Console.WriteLine();
            }
        }

        public Tabla(string fileNev)
        {
            string[] sorok = File.ReadAllLines(fileNev);

            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int k = 0; k < t.GetLength(1); k++)
                {
                    t[i, k] = sorok[i][k];
                }
            }
        }

        public bool VanForditas(char jatekos,int sor,int oszlop,int iranySor,int iranyOszlop)
        {
            int aktSor, aktOszlop;
            char ellenfel;
            bool nincsEllenfel;
            aktSor = sor + iranySor;
            aktOszlop = oszlop + iranyOszlop;
            ellenfel = 'K';
            if(jatekos=='K')
            {
                ellenfel = 'F';
            }
            nincsEllenfel = true;
            while (aktSor > 0 && aktSor < 8 && aktOszlop > 0 && aktOszlop < 8 && t[aktSor, aktOszlop] == ellenfel)
            {
                aktSor = aktSor + iranySor;
                aktOszlop = aktOszlop + iranyOszlop;
                nincsEllenfel = false;
            }

            if(nincsEllenfel || aktSor<0 || aktSor>7 || aktOszlop<0 || aktOszlop>7 || t[aktSor, aktOszlop] != jatekos)
            {
                return false;
            }
            return true;
        }


    }
}
