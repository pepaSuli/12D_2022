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

namespace szam2szovegWPF
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

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                label1.Content = textBox.Text;
            }
            catch (Exception)
            {
                string valid = "0123456789";
                for (int i = 0; i < textBox.Text.Length; i++)
                {
                    if(!valid.Contains(textBox.Text[i]))
                    {
                        textBox.Text=textBox.Text.Remove(i, 1);
                        i--;
                    }
                }
            }
            label1.Content = "";
            textBlock.Text = "";
            for (int i = textBox.Text.Length-1; i >=0 ; i--)
            {
                string resz = szamjegy(textBox.Text[textBox.Text.Length-1-i].ToString());
                
                if(i%3==1)
                {
                    //ha 1 vagy 2, és a következő 0 (tíz:tizen-, húsz:huszon- probléma)
                    if((textBox.Text[textBox.Text.Length - 1 - i]=='1'
                            || textBox.Text[textBox.Text.Length - 1 - i] == '2')
                        && textBox.Text[textBox.Text.Length - 1 - i +1] == '0')
                    {
                        resz = szamjegy10(textBox.Text[textBox.Text.Length - 1 - i].ToString()+"0");
                    }
                    else
                    {
                        resz = szamjegy10(textBox.Text[textBox.Text.Length - 1 - i].ToString());
                    }
                }
                else if (i % 3 == 2)
                {
                    //ne legyen egyszaz
                    if (textBox.Text[textBox.Text.Length - 1 - i] == '1')
                    {
                        resz = "";
                    }
                    resz += "száz";
                }
                else if (i>0 && i % 3 == 0)
                {
                    //ne legyen egyezer
                    if (i==3 && textBox.Text[textBox.Text.Length - 1 - i] == '1')
                    {
                        resz = "";
                    }

                    string[] postfix = new string[] {"","ezer-", "millió-","milliárd-","billió-", "billiárd-" };
                    //nagyonnagy számok esetén is, amit ki sem tud mondani
                    int sorszam=(i / 3);
                    if(sorszam>= postfix.Length)
                    {
                        sorszam = sorszam % postfix.Length + 1;
                    }
                    resz += postfix[sorszam];

                    //2000 alatt egybeírjuk
                    if (textBox.Text.Length==4 && Convert.ToInt32(textBox.Text)<2000)
                    {
                        resz = resz.Replace("-", "");
                    }
                }
                if(textBox.Text[textBox.Text.Length - 1 - i]!='0')
                {
                    textBlock.Text += resz;
                    label1.Content += resz;
                }
            }


        }

        string szamjegy(string szam)
        {
            switch (szam)
            {
                case "1": return "egy";
                case "2": return "kettő";
                case "3": return "három";
                case "4": return "négy";
                case "5": return "öt";
                case "6": return "hat";
                case "7": return "hét";
                case "8": return "nyolc";
                case "9": return "kilenc";
                default:
                    return "";
            }
        }
        string szamjegy10(string szam)
        {
            switch (szam)
            {
                case "1": return "tizen";
                case "2": return "huszon";
                case "3": return "harminc";
                case "4": return "negyven";
                case "5": return "ötven";
                case "6": return "hatvan";
                case "7": return "hetven";
                case "8": return "nyolcvan";
                case "9": return "kilencven";
                case "10": return "tíz";
                case "20": return "húsz";
                default:
                    return "";
            }
        }
    }
}
