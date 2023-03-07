using System;
using System.Collections.Generic;
using System.IO;

namespace kosar2004
{
    class Program
    {
        static void Main(string[] args)
        {
            //hazai;idegen;hazai_pont;idegen_pont;helyszín;időpont
            List<string> hazai = new List<string>();
            List<string> idegen = new List<string>();
            List<int> hazaiPont = new List<int>();
            List<int> idegenPont = new List<int>();
            List<string> helyszin = new List<string>();
            List<string> idopont = new List<string>();

            StreamReader olvas = new StreamReader("eredmenyek.csv");
            olvas.ReadLine();
            while(!olvas.EndOfStream)
            {
                string[] vag = olvas.ReadLine().Split(";");
                hazai.Add(vag[0]);
                idegen.Add(vag[1]);
                hazaiPont.Add(Convert.ToInt32(vag[2]));
                idegenPont.Add(Convert.ToInt32(vag[3]));
                helyszin.Add(vag[4]);
                idopont.Add(vag[5]);

            }
            olvas.Close();

            int hazaiDb = 0;
            int idegenDb = 0;

            for (int i = 0; i < hazai.Count; i++)
            {
                if (hazai[i] == "Real Madrid")
                {
                    hazaiDb++;
                }
            }
            for (int i = 0; i < idegen.Count; i++)
            {
                if (idegen[i] == "Real Madrid")
                {
                    idegenDb++;
                }
            }

            Console.WriteLine("3.feladat: Real Madrid: Hazai: {0}, Idegen: {1}", hazaiDb, idegenDb);

            bool dontetlenVolt = false;

            for (int i = 0; i < hazaiPont.Count; i++)
            {
                if(hazaiPont[i]==idegenPont[i])
                {
                    dontetlenVolt = true;
                    break;
                }
            }

            Console.Write("4. feladat: Volt döntetlen? ");
            if(dontetlenVolt)
            {
                Console.WriteLine(" igen");
            }
            else
            {
                Console.WriteLine(" nem");
            }

            for (int i = 0; i < hazai.Count; i++)
            {
                if(hazai[i].Contains("Barcelona"))
                {
                    Console.WriteLine("5. feladat: a barcelonai csapat neve: {0}",hazai[i]);
                    break;
                }
            }

            Console.WriteLine("6. feladat");
            for (int i = 0; i < hazai.Count; i++)
            {
                if(idopont[i]=="2004-11-21")
                {
                    Console.WriteLine($"\t{hazai[i]} {idegen[i]} ({hazaiPont[i]}:{idegenPont[i]})");
                    Console.WriteLine("\t{0} {1} ({2}:{3})",
                                    hazai[i],
                                    idegen[i],
                                    hazaiPont[i],
                                    idegenPont[i]);
                }
            }

            List<string> stadion = new List<string>();
            List<int> merkozesSzam = new List<int>();

            for (int i = 0; i < helyszin.Count; i++)
            {
                if(!stadion.Contains(helyszin[i]))
                {
                    stadion.Add(helyszin[i]);
                }
            }

            for (int i = 0; i < stadion.Count; i++)
            {
                int db = 0;
                for (int k = 0; k < helyszin.Count; k++)
                {
                    if(stadion[i]==helyszin[k])
                    {
                        db++;
                    }
                }
                merkozesSzam.Add(db);
            }
            Console.WriteLine("7. feladat");
            for (int i = 0; i < merkozesSzam.Count; i++)
            {
                if(merkozesSzam[i]>20)
                {
                    Console.WriteLine("\t{0} {1}",stadion[i],merkozesSzam[i]);
                }
            }

        }
    }
}
