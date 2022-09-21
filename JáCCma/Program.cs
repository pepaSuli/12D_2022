

List<bool> lista=new List<bool>();//igaz, ha az adogató nyert
string[] sorok = File.ReadAllLines("labdamenetek5.txt");

for (int i = 0; i < sorok.Length; i++)
{
    lista.Add(sorok[i] == "A");
}


Console.WriteLine("3. feladat: Labdamenetek száma: {0}", lista.Count);

int db = 0;
for (int i = 0; i < lista.Count; i++)
{
    if (lista[i])
    {
        db++;
    }
}

Console.WriteLine("4. feladat: Az adogató játékos {0:.000000000000000%} nyerte meg a labdameneteket.",(double)db/lista.Count);


int winStreak = 0;
int aktWinStreak = 0;

for (int i = 0; i < lista.Count; i++)
{
    if (lista[i])
    {
        aktWinStreak++;
    }
    else
    {
        if(winStreak<aktWinStreak)
        {
            winStreak = aktWinStreak;
        }
        aktWinStreak = 0;
    }
}

Console.WriteLine("5. feladat: Leghosszabb sorozat: {0}",winStreak);

Játék PróbaJáték = new Játék(new List<bool>() { false, true, false, true, true }, "Mahut", "Isner");
PróbaJáték.Hozzáad(true);
Console.WriteLine("7. feladat: A próbajáték");
Console.WriteLine("\tÁllás:{0}",PróbaJáték.allasSzoveg());
Console.Write("\tBefejeződött a játék:");
if (PróbaJáték.JátékVége())
{
    Console.WriteLine("igen");
}
else
{
    Console.WriteLine("nem");
}

List<Játék> meccs = new List<Játék>();

int q = 0;
while (q<lista.Count)
{
    Játék temp;
    if(meccs.Count%2==0)
    {
        temp = new Játék(new List<bool>() { }, "Isner", "Mahut");
    }
    else
    {
        temp = new Játék(new List<bool>() { }, "Mahut", "Isner");
    }

    while (!temp.JátékVége())
    {
        temp.Hozzáad(lista[q]);

        q++;
    }
    meccs.Add(temp);
}





class Játék
{
    List<bool> allas=new List<bool>();
    string adogato, fogado;
    public Játék(List<bool> allas,string adogato,string fogado)
    {
        this.allas = allas;
        this.adogato = adogato;
        this.fogado = fogado;
    }

    public void Hozzáad(bool labdaMenet)
    {
        allas.Add(labdaMenet);
    }
    public int NyertLabdamenetekSzáma(string nyertes)
    {
        int db = 0;
        for (int i = 0; i < allas.Count; i++)
        {
            if(nyertes=="A" && allas[i])
            {
                db++;
            }
            else if(nyertes == "F" && !allas[i])
            {
                db++;
            }
        }
        return db;
    }

    public bool JátékVége()
    {
        int nyertAdogató, nyertFogadó, különbség;
        nyertAdogató = NyertLabdamenetekSzáma("A");
        nyertFogadó = NyertLabdamenetekSzáma("F");
        különbség = Math.Abs(nyertAdogató - nyertFogadó);
        return (nyertAdogató >= 4 || nyertFogadó >= 4) && (különbség >= 2);
    }

    public string allasSzoveg()
    {
        string vissza = "";
        for (int i = 0; i < allas.Count; i++)
        {
            if (allas[i])
            {
                vissza += "A";
            }
            else
            {
                vissza += "F";
            }
        }

        return vissza;
    }
}