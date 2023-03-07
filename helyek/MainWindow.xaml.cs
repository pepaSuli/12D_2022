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

namespace helyek
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

        List<adatok> allomasok = new List<adatok>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] sorok = File.ReadAllLines("hely.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                allomasok.Add(new adatok(sorok[i]));
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int szam1 = Convert.ToInt32(textBox.Text);
                int szam2 = 0;
                if (textBox1!=null)
                {
                    szam2 = Convert.ToInt32(textBox1.Text);
                }

                int tav = Math.Abs(allomasok[szam1 - 1].tavolsag - allomasok[szam2 - 1].tavolsag);
                textBlock1.Text = tav.ToString();

                double atlagSebesseg = allomasok[allomasok.Count - 1].tavolsag / Convert.ToDouble(textBlock.Text);
               // textBlock2.Text = Convert.ToString(tav / atlagSebesseg);
               // textBlock2.Text = ""+ (tav / atlagSebesseg);
                textBlock2.Text = (tav / atlagSebesseg).ToString("0.0 óra");


                List<string> nevek = new List<string>();
                if(szam1<szam2)
                {
                    for (int i = szam1; i <= szam2; i++)
                    {
                        nevek.Add(allomasok[i].nev);
                    }
                }
                else
                {
                    for (int i = szam1; i >= szam2; i--)
                    {
                        nevek.Add(allomasok[i].nev);
                    }
                }

                listBox.ItemsSource = nevek;

            }
            catch(Exception)
            {

            }

        }
    }

    class adatok
    {
        public string nev;
        public int tavolsag;
        public adatok(string sor)
        {
            string[] vag = sor.Split('\t');
            nev = vag[0];
            tavolsag = Convert.ToInt32(vag[1]);
        }
    }
}
