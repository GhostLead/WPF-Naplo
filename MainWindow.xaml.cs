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
using System.IO;

namespace OraiGyak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dpDatum.Text = "2023.03.06";
            List<string> tantargyak = new List<string>();
            tantargyak.Add("Matematika");
            tantargyak.Add("Fizika");
            tantargyak.Add("Angol");
            tantargyak.Add("Irodalom");
            tantargyak.Add("Nyelvtan");
            cboTantargy.ItemsSource = tantargyak;
            cboTantargy.SelectedIndex = 0;
        }

        private void sliJegy_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblJegy.Content = Math.Floor(sliJegy.Value).ToString();
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {

            if (txtNev.Text == "")
            {
                MessageBox.Show("Adjon meg egy nevet!");
            }
            else
            {
                try
                {

                    FileStream fs = new FileStream("D:\\Barizs Márton Dániel\\WPF\\OraiGyak\\OraiGyak\\Naplo.csv", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);

                    sw.WriteLine($"{txtNev.Text};{cboTantargy.SelectedItem.ToString()};{dpDatum.Text};{lblJegy.Content}");
                    sw.Close();
                    fs.Close();
                    MessageBox.Show("Sikeres írás!");
                }
                catch (Exception)
                {

                    MessageBox.Show("SIKERTELEN írás");
                }
            }

            

            
        }

        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
        }
    }



}
