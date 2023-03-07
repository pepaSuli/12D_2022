using System;
using System.IO;

namespace labirintus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string szoveg = File.ReadAllText("labirintus01.txt");
            terkep lab1 = new terkep(szoveg);
            Console.WriteLine(lab1.map[49,49]);

            bool nincsKint = true;
            lab1.mutat();

            while (nincsKint)
            {
                bool vanBenneRosszKarakter = true;
                string kod="";
                while (vanBenneRosszKarakter)
                {
                    Console.Write("Kérem a programkódot (e,h,j,b):");
                    kod = Console.ReadLine();

                    vanBenneRosszKarakter = false;
                    for (int i = 0; i < kod.Length; i++)
                    {
                        if(kod[i] != 'j' && kod[i] != 'b' && kod[i] != 'e' && kod[i] != 'h')
                        {
                            vanBenneRosszKarakter = true;
                        }
                    }
                    //vanBenneRosszKarakter = 0 < kod.ToLower().Replace("e", "").Replace("h", "").Replace("j", "").Replace("b", "").Length;0
                    {

                        /*if (vanBenneRosszKarakter)
                        {
                            Console.WriteLine("rossz");
                        }
                        else
                        {
                            Console.WriteLine("jó");
                        }*/
                    }
                }

                lab1.utvonalBe(kod);
                lab1.mutat();
                nincsKint = !lab1.robotKint();
            }

        }
    }

    class terkep
    {
        public string[,] map;
        public int[] robotXY = new int[2];

        public terkep(string map)
        {
            string[] vag = map.Split('\n');
            this.map = new string[vag.Length, vag[0].Length];

            for (int i = 0; i < vag.Length; i++)
            {
                //00001100000000000000000000000000000000000000000000 vag[i]

                for (int k = 0; k < vag[i].Length; k++)
                {
                    this.map[i,k]=vag[i][k].ToString();
                    if(this.map[i, k] == "¤")
                    {
                        robotXY[0] = i;
                        robotXY[1] = k;
                    }
                    


                }
            }
        }

        public void mutat()
        {
            for (int sor = 0; sor < map.GetLength(0); sor++)
            {
                for (int oszlop = 0; oszlop < map.GetLength(1); oszlop++)
                {
                    szin(map[sor, oszlop]);
                    Console.Write(map[sor,oszlop]);
                }

                szin("");
                Console.WriteLine();
            }
        }
        void szin(string elem)
        {
            switch(elem)
            {
                case "0":
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    break;
                case "1":
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "¤":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;

                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                    break;

            }
        }
        public int robotHP = 10;
        string utvonal;
        public void utvonalBe(string kod)
        {
            utvonal = kod;

            for (int i = 0; i < utvonal.Length; i++)
            {
                if (utvonal[i] == 'e')
                {
                    if (robotXY[0] - 1 > -1)
                    {
                        if (map[robotXY[0] - 1, robotXY[1]] == "0")
                        {
                            robotHP--;
                        }
                        else
                        {
                            map[robotXY[0] - 1, robotXY[1]] = "¤";
                            robotXY[0]--;
                        }
                    }
                    else
                    {
                        robotHP = 0;
                    }
                }
                if (utvonal[i] == 'h')
                {
                    if (robotXY[0] + 1 < map.GetLength(0))
                    {
                        if (map[robotXY[0] + 1, robotXY[1]] == "0")
                        {
                            robotHP--;
                        }
                        else
                        {
                            map[robotXY[0] + 1, robotXY[1]] = "¤";
                            robotXY[0]++;
                        }
                    }
                    else
                    {
                        robotHP = 0;
                    }
                }
                if (utvonal[i] == 'j')
                {
                    if (robotXY[1] + 1 < map.GetLength(1))//
                    {
                        if (map[robotXY[0], robotXY[1] + 1] == "0")//
                        {
                            robotHP--;
                        }
                        else
                        {
                            map[robotXY[0], robotXY[1] + 1] = "¤";//
                            robotXY[1]++;
                        }
                    }
                    else
                    {
                        robotHP = 0;
                    }
                }
                if (utvonal[i] == 'b')
                {
                    if (robotXY[1] - 1 > 0)
                    {
                        if (map[robotXY[0], robotXY[1] - 1] == "0")
                        {
                            robotHP--;
                        }
                        else
                        {
                            map[robotXY[0], robotXY[1] - 1] = "¤";
                            robotXY[1]--;

                        }
                    }
                    else
                    {
                        robotHP = 0;
                    }
                }

            }

        }

        public bool robotKint()
        {
            if(robotXY[0]==map.GetLength(0)-1 
                || robotXY[0] == 0 
                || robotXY[1] == map.GetLength(1) - 1 
                || robotXY[1] == 0)
            {
                return true;
            }

            return false;

        }
    }
}
