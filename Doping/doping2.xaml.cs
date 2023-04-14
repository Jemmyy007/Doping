using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
    /// Логика взаимодействия для doping2.xaml
    /// </summary>
    public partial class doping2 : Window
    {

        public doping2(string fio, string tel, string mail)
        {
            InitializeComponent();
            
            l1.Content= fio;
            l2.Content= tel;
            l3.Content= mail;
           
        }

       

        

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            doping1 dp1 = new doping1();
            this.Close();
            dp1.txtFIO.Text = "";
            dp1.txtTel.Text = "";
            dp1.txtMail.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

                string fio = l1.Content.ToString();
                string tel = l2.Content.ToString();
                string mail = l3.Content.ToString();

                OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = ДопингБД.accdb");
                string query = $"INSERT INTO Спортсмены (ФИО, [Номер телефона], Почта) VALUES ('{fio} ', ' {tel} ', ' {mail}')";
                con.Open();
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Спортсмен зарегистрирован");
                con.Close();

                doping1 dp1 = new doping1();

                dp1.txtFIO.Text = "";
                dp1.txtTel.Text = "";
                dp1.txtMail.Text = "";

                this.Close();

                
            

        }





    }
}
