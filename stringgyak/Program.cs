string szoveg = "Almafa van a kertem végében. Az almafa minden évben hoz gyümölcsöt. Sok alma a fa alá esik, de megéri felszedni? ";

int elso = szoveg.ToLower().IndexOf("almafa");
int masodik = szoveg.ToLower().IndexOf("almafa",elso+1);

string darab1 = szoveg.Substring(0, masodik);
int elottePont = darab1.LastIndexOf(".");
string darab2 = szoveg.Substring(masodik);
int utanaPont = darab2.IndexOf(".");

Console.WriteLine(darab2);
Console.WriteLine(szoveg.Substring(elottePont+2,utanaPont));
Console.WriteLine(elso);
Console.WriteLine(masodik);
Console.WriteLine(darab1);

Console.WriteLine(elottePont);
Console.WriteLine(utanaPont);

