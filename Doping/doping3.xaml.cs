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
using System.Windows.Shapes;

namespace dopin
{
    /// <summary>
    /// Логика взаимодействия для doping3.xaml
    /// </summary>
    public partial class doping3 : Window
    {
        public doping3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            doping4 Doping4 = new doping4();
            Doping4.Show();
            this.Close();
        }

       

        

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            doping12 Doping12 = new doping12();
            Doping12.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow(); 
            MainWindow.Show();
            this.Close();
        }
    }
}
