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

namespace korok
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

        List<kor> korok = new List<kor>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] sorok = File.ReadAllLines("Korok.txt");
            for (int i = 0; i < sorok.Length; i++)
            {
                korok.Add(new kor(sorok[i], i + 1));
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int[] stat = new int[5];

            for (int i = 0; i < korok.Count; i++)
            {
                stat[korok[i].siknegyed()]++;
            }

            textBlock1.Text = stat[1].ToString("# darab");
            textBlock2.Text = stat[2].ToString("# darab");
            textBlock3.Text = stat[3].ToString("# darab");
            textBlock4.Text = stat[4].ToString("# darab");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            double ossz = 0;
            for (int i = 0; i < korok.Count; i++)
            {
                if(korok[i].siknegyed()==8)
                {
                    ossz += korok[i].T();
                }
            }

            label.Content = "T összes = " + ossz.ToString("0.00");
        }
    }

    class kor
    {
        public int x, y, r,sorszam;
        public kor(string sor,int sorszam)
        {
            string[] vag = sor.Split(';');
            x = Convert.ToInt32(vag[0]);
            y = Convert.ToInt32(vag[1]);
            r = Convert.ToInt32(vag[2]);
            this.sorszam = sorszam;
        }

        public int siknegyed()
        {
            int A = y - r;
            int B = x - r;
            int C = y + r;
            int D = x + r;

            if(A>=0 && B>=0){        return 1;   }
            else if(A>=0 && D<=0){   return 2;   }
            else if(C<=0 && D<=0){   return 3;   }
            else if (C <= 0 && B >= 0) { return 4; }
            else if (A < 0 && B < 0 && C>0 && D>0) { return 8; }
            else {   return 0;   }
        }

        public double T()
        {
            return r * r * Math.PI;
        }

        public double tavolsag(kor masik)
        {
            int a = x - masik.x;
            int b = y - masik.y;
            double c = Math.Sqrt(a * a + b * b);

            return c - r - masik.r;
        }
    }
}
