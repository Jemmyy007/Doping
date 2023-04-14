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
    /// Логика взаимодействия для doping8.xaml
    /// </summary>
    public partial class doping8 : Window
    {
        public doping8()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            doping9 Doping9 = new doping9();
            Doping9.Show();
            this.Close();
        }

       

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            doping11 Doping11 = new doping11();
            Doping11.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            vxod1 Vxod1 = new vxod1();
            Vxod1.Show();
            this.Close();
        }
    }
}
