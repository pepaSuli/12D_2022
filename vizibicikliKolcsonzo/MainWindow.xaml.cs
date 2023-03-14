using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace vizibicikliKolcsonzo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Kolcsonzes> naplo = new List<Kolcsonzes>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] sorok = File.ReadAllLines("kolcsonzesek.txt");
            for (int i = 1; i < sorok.Length; i++)
            {
                naplo.Add(new Kolcsonzes(sorok[i]));
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = naplo.Count.ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < naplo.Count; i++)
            {
                if(naplo[i].nev==textBox.Text)
                {
                    listBox.Items.Add(naplo[i].startOra + ":"
                            + naplo[i].startPerc + "-" +
                            naplo[i].stopOra + ":" +
                            naplo[i].stopPerc);
                }
            }
            if(listBox.Items.Count==0)
            {
                listBox.Items.Add("Nem volt ilyen nevű.");
            }
        }
    }

    class Kolcsonzes
    {
        public string nev, jarmuAzonosito;
        public int startOra, startPerc, stopOra, stopPerc;
        public Kolcsonzes(string sor)
        {
            string[] vag = sor.Split(';');
            nev = vag[0];
            jarmuAzonosito = vag[1];
            startOra = Convert.ToInt32(vag[2]);
            startPerc = Convert.ToInt32(vag[3]);
            stopOra = Convert.ToInt32(vag[4]);
            stopPerc = Convert.ToInt32(vag[5]);
        }
    }
}
