using System;
using System.Collections.Generic;
using System.IO;

//jó név 1p
namespace Fuvar
{
    class Program
    {
        static void Main(string[] args)
        {
            // 40 pont
            Console.WriteLine("Hello World!");
            //megfelelő adatszerkezet 3p
            List<int> taxiId = new List<int>();
            List<string> indulas = new List<string>();
            List<int> idotartam = new List<int>();
            List<double> tavolsag = new List<double>();
            List<double> viteldij = new List<double>();
            List<double> borravalo = new List<double>();
            List<string> fizetesModja = new List<string>();

            //beolvasásra megnyit 1p
            StreamReader olvas = new StreamReader("fuvar.csv");
            //első sor más 1p
            olvas.ReadLine();
            //egyet beolvas 1p
            //mind beolvas 1p
            while(!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                string[] vag = sor.Split(";");
                //mind eltárol 1p
                taxiId.Add(Convert.ToInt32(vag[0]));
                indulas.Add(vag[1]);
                idotartam.Add(Convert.ToInt32(vag[2]));
                tavolsag.Add(Convert.ToDouble(vag[3]));
                viteldij.Add(Convert.ToDouble(vag[4]));
                borravalo.Add(Convert.ToDouble(vag[5]));
                fizetesModja.Add(vag[6]);
            }

            olvas.Close();

            //megszámol 1p
            //kiír 1p
            Console.WriteLine("3. feladat: {0} fuvar",borravalo.Count);

            double ossz = 0;
            int db = 0;
            //minden adatot végignéz 1p
            for (int i = 0; i < taxiId.Count; i++)
            {
                //megfelelő taxist vizsgál 1p
                if(taxiId[i]==6185)
                {
                    //osszeget számol 1p
                    //borravalót is 1p
                    ossz += viteldij[i] + borravalo[i];
                    //darabszámot 1p
                    db++;
                }
            }
            //helyes kiírás 1p
            //jó adat 1p
            Console.WriteLine("4. feladat: {0} fuvar alatt: {1}$",db,ossz);

            //legalább 1 fizetésmódot megszámol 2p
            //mindent megszámol 2p
            List<string> modok = new List<string>();
            List<int> hasznalat = new List<int>();
            for (int i = 0; i < fizetesModja.Count; i++)
            {
                if(modok.Contains(fizetesModja[i]))
                {
                    hasznalat[modok.IndexOf(fizetesModja[i])]++;
                }
                else
                {
                    modok.Add(fizetesModja[i]);
                    hasznalat.Add(1);
                }
            }

            //mintának megfelelően kiír egyet 2p
            //mindet 1p
            Console.WriteLine("5. feladat");
            for (int i = 0; i < modok.Count; i++)
            {
                Console.WriteLine("\t{0}: {1} fuvar",modok[i],hasznalat[i]);
            }


            ossz = 0;
            for (int i = 0; i < tavolsag.Count; i++)
            {
                //összegzi a távolságokat 1p
                ossz += tavolsag[i];
            }
            //kiírja 1p
            //megfelelő érték 1p
            //megfelelő formázás 1p
            Console.WriteLine("6. feladat: {0:0.00} km",ossz*1.6);


            int maxIndex = 0;
            //minden adatot végignéz 1p
            for (int i = 0; i < tavolsag.Count; i++)
            {
                //legalább kettőt összehasonlít 1p
                if(idotartam[i]> idotartam[maxIndex])
                {
                    maxIndex = i;
                }
            }

            //helyesen kiír 4p
            Console.WriteLine("7. feladat: Leghosszabb fuvar:");
            Console.WriteLine("\tFuvar hossza: {0} másodperc", idotartam[maxIndex]);
            Console.WriteLine("\tTaxi azonosító: {0}", taxiId[maxIndex]);
            Console.WriteLine("\tTávolág: {0} km", tavolsag[maxIndex]*1.6);
            Console.WriteLine("\tViteldij: {0} $", viteldij[maxIndex]);


            //írásra megnyit 1p
            StreamWriter ir = new StreamWriter("hibak.txt");
            List<string> rendez = new List<string>();
            for (int i = 0; i < taxiId.Count; i++)
            {
                if(viteldij[i]>0 && idotartam[i]>0 && tavolsag[i]==0)
                {
                    rendez.Add(indulas[i] + ";" + taxiId[i]);
                }
            }

            //rendezett 1p
            rendez.Sort();

            //minden sort kiír 1p
            foreach (var item in rendez)
            {
//                Console.WriteLine(item);
                string[] vag = item.Split(";");
                int i = indulas.IndexOf(vag[0]);
                //legalább 1 sort ír 1p
                ir.WriteLine("{0};{1};{2};{3};{4};{5};{6}", taxiId[i]
                    , indulas[i]
                    , idotartam[i]
                    , tavolsag[i]
                    , viteldij[i]
                    , borravalo[i], fizetesModja[i]);
            }

            ir.Close();
            //helyes a szerkezet 1p

            //rendez

        }
    }
}
