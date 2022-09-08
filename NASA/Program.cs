using System;
using System.Collections.Generic;
using System.IO;

namespace NASA
{
    class Program
    {
        static void Main(string[] args)
        {
            feladat f = new feladat();
        }
    }
    class feladat
    {
        public feladat()
        {
            f4();
        }

        List<adatok> log = new List<adatok>();
        void f4()
        {
            string[] sorok = File.ReadAllLines("NASAlog.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                log.Add(new adatok(sorok[i]));
            }
        }
    }
    class adatok
    {
        public string domain;
        public string datum;
        public string kep;
        public int kod;
        public int meret;
        public adatok(string sor)
        {
            //rn3.swc.com*20/Jul/1995:12:55:04*GET /images/small.jpg*200 46573
            string[] vag = sor.Split("*");
            /*
             * rn3.swc.com
             * 20/Jul/1995:12:55:04
             * GET /images/small.jpg
             * 200 46573
             * */
            domain = vag[0];
            datum = vag[1];
            kep = vag[2];
            string[] vag2 = vag[3].Split(" ");

            kod = Convert.ToInt32(vag2[0]);
            if(vag2[1]=="-")
            {
                meret = 0;
            }
            else
            {
                meret = Convert.ToInt32(vag2[1]);
            }

        }
    }
}
