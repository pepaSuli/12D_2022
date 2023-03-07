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

namespace kopapirollo2
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

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if((p1k.IsChecked==true && p2o.IsChecked==true) 
                || (p1o.IsChecked==true && p2p.IsChecked==true)
                || (p1p.IsChecked == true && p2k.IsChecked == true))
            {
                textBox.Text = "1. játékos nyert";
            }

            if ((p2k.IsChecked == true && p1o.IsChecked == true)
                || (p2o.IsChecked == true && p1p.IsChecked == true)
                || (p2p.IsChecked == true && p1k.IsChecked == true))
            {
                textBox.Text = "2. játékos nyert";
            }

            if ((p1k.IsChecked == true && p2k.IsChecked == true)
                || (p1o.IsChecked == true && p2o.IsChecked == true)
                || (p1p.IsChecked == true && p2p.IsChecked == true))
            {
                textBox.Text = "Döntetlen";
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string[] sorok = File.ReadAllLines("jatek.txt");

            int[] stat = new int[3];
            //0:    döntetlen
            //1:    1. nyert
            //2:    2. nyert

            for (int i = 0; i < sorok.Length; i++)
            {
                //"1-2"
                if ((sorok[i][0] == '0' && sorok[i][2] == '2')
                    || (sorok[i][0] == '2' && sorok[i][2] == '1')
                    || (sorok[i][0] == '1' && sorok[i][2] == '0'))
                {
                    stat[1]++;
                }
                if ((sorok[i][2] == '0' && sorok[i][0] == '2')
                    || (sorok[i][2] == '2' && sorok[i][0] == '1')
                    || (sorok[i][2] == '1' && sorok[i][0] == '0'))
                {
                    stat[2]++;
                }
                if (sorok[i][0] == sorok[i][2])
                {
                    stat[0]++;
                }
            }

        }
    }
}
