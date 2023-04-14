using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
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
using System.Diagnostics;

namespace dopin
{
    /// <summary>
    /// Логика взаимодействия для doping1.xaml
    /// </summary>
    public partial class doping1 : Window
    {
        OleDbConnection con;
        OleDbCommand cmd;

        public doping1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = ДопингБД.accdb");
            con.Open();


                string fio = txtFIO.Text;
                string tel = txtTel.Text;
                string mail = txtMail.Text;
            if (txtFIO.Text == "" || txtTel.Text == "" || txtMail.Text == "")
            {
                MessageBox.Show("Введите данные спортсмена полностью");
            }
            else
            {
                doping2 Doping2 = new doping2(fio, tel, mail);
                Doping2.Show();

                txtFIO.Text = "";
                txtTel.Text = "";
                txtMail.Text = "";
            }


            /* string query = $"INSERT INTO Спортсмены (ФИО, [Номер телефона], Почта) VALUES ('{fio} ', ' {tel} ', ' {mail}')";
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Запись добавлена"); */



            /* doping2 Doping2 = new doping2(fio, tel, mail);
             Doping2.Show();
             this.Close(); */








        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void txtMail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
