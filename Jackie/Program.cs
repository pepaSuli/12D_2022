using System;
using System.Collections.Generic;
using System.IO;

//jó név 1
namespace Jackie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //year races   wins podiums poles fastests
 //jó adatszerkezet 3
            List<int> year = new List<int>();
            List<int> races = new List<int>();
            List<int> wins = new List<int>();
            List<int> podiums = new List<int>();
            List<int> poles = new List<int>();
            List<int> fastests = new List<int>();
            //beolvasásra megnyit 1p
            StreamReader olvas = new StreamReader("jackie.txt");
            //első sor más 1p
            olvas.ReadLine();
            //egyet beolvas 1p
            //mind beolvas 1p
            while (!olvas.EndOfStream)
            {
                string[] vag = olvas.ReadLine().Split("\t");
                int i= 0;
                //mind eltárol 1p
                year.Add(Convert.ToInt32(vag[i++]));
                races.Add(Convert.ToInt32(vag[i++]));
                wins.Add(Convert.ToInt32(vag[i++]));
                podiums.Add(Convert.ToInt32(vag[i++]));
                poles.Add(Convert.ToInt32(vag[i++]));
                fastests.Add(Convert.ToInt32(vag[i++]));
            }
            olvas.Close();

            //megszámol 1p
            //kiír 1p
            Console.WriteLine("3. feladat: {0}",year.Count);

            int maxIndex = 0;
            //minden adatot végignéz 1p
            for (int i = 0; i < races.Count; i++)
            {
                //legalább 1 összehasonlítást csinál
                if(races[i]>races[maxIndex])
                {
                    maxIndex = i;
                }
            }
            //megvan a legnagyobb érték 1
            //helyesen kiír 1p
            Console.WriteLine("4. feladat: {0}",year[maxIndex]);

            int ev60 = 0;
            int ev70 = 0;
            //minden adatot végigvesz 1
            for (int i = 0; i < wins.Count; i++)
            {
                if(year[i]>=1970)
                {
                    //megszámolja a 70-as éveket 2p
                    ev70 += wins[i];
                }
                else
                {
                    //megszámolja a 60-as éveket 2p
                    ev60 += wins[i];
                }
            }
            //helyesen kiír 1
            Console.WriteLine("5. feladat:\n\t70-es évek: {0} megnyert verseny\n\t60-es évek: {1} megnyert verseny",
                ev70, ev60);

            //írásra megnyit 1
            StreamWriter ir = new StreamWriter("jackie.html");
            //beleír valamit 1
            //helyesen bemásolta a htmlt 1
            ir.WriteLine("<!DOCTYPE html>\n<html lang=\"hu\">\n<head></head>\n<style>td { border:1px solid black;}</style><body><h1>Jackie Steward</h2><table>");
            //1 sort beír 1
            //minden sort beír 1
            for (int i = 0; i < year.Count; i++)
            {
                ir.WriteLine("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",year[i],races[i],wins[i]);
            }
            //html lezáró megvan 1
            ir.WriteLine("</body>\n</html>");

            //lezárja a file-t 1
            ir.Close();
        }
    }
}
