
//main()
feladat f = new feladat();


class feladat
{
    public feladat()
    {
        f4();
        f5();
        f7();
    }
    List<JatekosLovese> lovesek = new List<JatekosLovese>();
    public void f7()
    {
        int minIndex = 0;
        for (int i = 0; i < lovesek.Count; i++)
        {
            if (lovesek[minIndex].Tavolsag() > lovesek[i].Tavolsag())
            {
                minIndex = i;
            }
        }

        Console.WriteLine("7. feladat: Legpontossabb lövés");
        Console.WriteLine("\t{0}.; {1}; x={2}; y={3}; távolság={4}", 
                lovesek[minIndex].sorszam, 
                lovesek[minIndex].nev, 
                lovesek[minIndex].abcissza, 
                lovesek[minIndex].ordinata, 
                lovesek[minIndex].Tavolsag());
    }
    public void f5()
    {
        Console.WriteLine("5. feladat: Lövések száma: {0} db",lovesek.Count);
    }

    public void f4()
    {
        string[] sorok = File.ReadAllLines("lovesek.txt");
        for (int i = 1; i < sorok.Length; i++)
        {
            lovesek.Add(new JatekosLovese(sorok[i], i, sorok[0]));
        }
    }
}
class JatekosLovese
{
    public string nev;
    public double abcissza, ordinata;
    public int sorszam;
    public double[] kozeppont=new double[2];
    public JatekosLovese(string sor, int sorszam,string kozep)
    {
        //sor = "Ricsi;26,99;33,00"
        //sorszam = 1

        string[] vag = sor.Split(";");
        nev=vag[0];
        abcissza=Convert.ToDouble(vag[1]);
        ordinata=Convert.ToDouble(vag[2]);
        this.sorszam = sorszam;

        vag = kozep.Split(";");
        kozeppont[0] = Convert.ToDouble(vag[0]);
        kozeppont[1] = Convert.ToDouble(vag[1]);

    }

    public double Tavolsag()
    {
        double dx = kozeppont[0] - abcissza;
        double dy = kozeppont[1] - ordinata;
        return Math.Sqrt(dx * dx + dy * dy);
    }

}
