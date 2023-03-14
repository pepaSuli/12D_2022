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

namespace furdoWPF
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
        List<adatok> naplo = new List<adatok>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] sorok = File.ReadAllLines("furdoadat.txt");

            for (int i = 0; i < sorok.Length; i++)
            {
                naplo.Add(new adatok(sorok[i]));
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = naplo[0].ido();

            int utolso = 0;
            for (int i = 0; i < naplo.Count; i++)
            {
                if(naplo[i].belep)
                {
                    utolso = i;
                }
            }
            textBlock_Copy.Text = naplo[utolso].ido();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int db = 0;
            int sorSzam = 1;
            for (int i = 1; i < naplo.Count; i++)
            {
                if(naplo[i].id!=naplo[i-1].id)
                {
                    if(sorSzam==4)
                    {
                        db++;
                    }

                    sorSzam = 1;
                }
                else
                {
                    sorSzam++;
                }
            }

            textBlock1.Text = db.ToString("0 fő");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //
            int id = 0;
            int max = 0;
            int beIdo = 0;
            for (int i = 0; i < naplo.Count; i++)
            {
                if(naplo[i].reszlegId==0 && !naplo[i].belep)
                {
                    beIdo = naplo[i].idoMp();
                }

                //öltözőbe vissza
                if (naplo[i].reszlegId == 0 && naplo[i].belep)
                {
                    int osszIdo=naplo[i].idoMp() - beIdo;
                    if(max<osszIdo)
                    {
                        max = osszIdo;
                        id = naplo[i].id;
                    }
                }

            }

            textBlock2.Text = id.ToString();

            int ora = max / 3600;
            int perc = (max - ora * 3600) / 60;
            int mp = max - ora*3600 - perc*60;

            textBlock3.Text = ora+":"+perc+":"+mp;


        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            int[] db = new int[3];

            for (int i = 0; i < naplo.Count; i++)
            {
                if(naplo[i].reszlegId==0 && !naplo[i].belep)
                {
                    if(naplo[i].ora<9)
                    {
                        db[0]++;
                    }
                    else if (naplo[i].ora>=16)
                    {
                        db[2]++;
                    }
                    else
                    {
                        db[1]++;
                    }
                }
            }

            listBox.Items.Add("6-9 között " + db[0] + " vendég érkezett.");
            listBox.Items.Add("9-16 között " + db[1] + " vendég érkezett.");
            listBox.Items.Add("16-20 között " + db[2] + " vendég érkezett.");
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("aaaaaaaaaaa");
            SortedDictionary<int, int> stat = new SortedDictionary<int, int>();
            int beIdo = 0;
            int osszIdo = 0;
            for (int i = 0; i < naplo.Count; i++)
            {
                if (naplo[i].reszlegId == 2 && naplo[i].belep)
                {
                    beIdo = naplo[i].idoMp();
                }

                if (naplo[i].reszlegId == 2 && !naplo[i].belep)
                {
                    if (stat.ContainsKey(naplo[i].id))
                    {
                        stat[naplo[i].id] += naplo[i].idoMp() - beIdo;
                    }
                    else
                    {
                        stat.Add(naplo[i].id, naplo[i].idoMp() - beIdo);
                    }
                }
            }
            
            StreamWriter ir = new StreamWriter("szauna.txt");
            foreach (var item in stat)
            {
                ir.WriteLine("{0} {1}:{2}:{3}",item.Key,
                        item.Value/3600,
                        item.Value%3600/60,
                        item.Value%60);
            }
            ir.Close();
         
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("aaaaaaaaaaa");
        }

        private void button4_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }

    class adatok
    {
        public int id, reszlegId, ora, perc, mp;
        public bool belep;
        public adatok(string sor)
        {
            string[] vag = sor.Split(' ');
            id = Convert.ToInt32(vag[0]);
            reszlegId = Convert.ToInt32(vag[1]);
            belep = vag[2]=="0";
            ora = Convert.ToInt32(vag[3]);
            perc = Convert.ToInt32(vag[4]);
            mp = Convert.ToInt32(vag[5]);

        }
        public string ido()
        {
            //6:14:56

            return ora + ":" + perc + ":" + mp;
        }

        public int idoMp()
        {
            return ora * 3600 + perc * 60 + mp;
        }
    }
}
