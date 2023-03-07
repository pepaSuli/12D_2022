using System;
using System.Collections.Generic;
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

namespace BukkMaraton2019GUI
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            double sebesseg;

            int tav;
            int index = comboBox.SelectedIndex;

            if (index == 0) tav = 16;
            else if (index == 1) tav = 38;
            else if (index == 2) tav = 54;
            else if (index == 3) tav = 57;
            else tav = 94;

            string idoSzoveg = textBox.Text;
            //"1:00:00"
            //3600
            string[] vag = idoSzoveg.Split(':');
            int ora = Convert.ToInt32(vag[0]);
            int perc = Convert.ToInt32(vag[1]);
            int mp = Convert.ToInt32(vag[2]);

            int ido = ora * 3600 + perc * 60 + mp;

            double mps = tav*1000.0 / ido;
            sebesseg = tav / (ido/3600.0);

            mps = Math.Round(mps, 2);
            sebesseg = Math.Round(sebesseg, 2);

            vKmH.Content = sebesseg;
            vMS.Content = mps;

        }
    }
}
