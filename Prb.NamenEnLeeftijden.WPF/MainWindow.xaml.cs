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

namespace Prb.NamenEnLeeftijden.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> names;
        List<int> ages;
        Random rnd;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            names = new List<string>();
            ages = new List<int>();
            rnd = new Random();
            txtName.Focus();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text.Trim();
            if (name.Length == 0)
            {
                txtName.Focus();
                return;
            }
            name = name.Replace('|', 'I');
            name = name.ToLower();
            int leeftijd = rnd.Next(1, 100);
            if (names.Exists(zoek => zoek == name))
            {
                txtName.Focus();
                return;
            }
            names.Add(name);
            ages.Add(leeftijd);
            lstNames.Items.Add(name + "|" + leeftijd.ToString());
            txtName.Text = "";
            txtName.Focus();
        }
        private void lstNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = lstNames.SelectedItem.ToString();
            string[] stringParts = name.Split('|');
            name = stringParts[0];
            int indeks = 0;
            indeks = names.FindIndex(zoek => zoek == name);

            int age = ages[indeks];

            lblSelectedName.Content = name;
            lblSelectedAge.Content = age.ToString();
        }



    }
}
