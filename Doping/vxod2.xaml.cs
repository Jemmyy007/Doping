﻿using System;
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
using System.Data.OleDb;
using System.Data;

namespace dopin
{
    /// <summary>
    /// Логика взаимодействия для vxod2.xaml
    /// </summary>
    public partial class vxod2 : Window
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        public vxod2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string user = txtLogin.Text;
            string password = txtPassword.Password;
            if (txtLogin.Text == "" && txtPassword.Password == "")
            {
                MessageBox.Show("Введите логин и пароль, прежде чем войти");
            }

            else
            { 
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = ДопингБД.accdb");
            string query = "SELECT * FROM Авторизация where Логин ='" + user + "' AND Пароль ='" + password + "' AND Код = 2";
            OleDbDataAdapter ad = new OleDbDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            ad.Fill(dtbl);
            
            if (dtbl.Rows.Count == 1)
            {
                doping3 Doping3 = new doping3();
                Doping3.Show();
                this.Close();


            }
            else
            {
                MessageBox.Show("Неверный Логин или Парорль");
            }
            con.Close();
            }



        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
            this.Close();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
