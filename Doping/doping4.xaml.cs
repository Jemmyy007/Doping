using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
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
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Windows.Media.Media3D;
using static System.Net.Mime.MediaTypeNames;

namespace dopin
{
    /// <summary>
    /// Логика взаимодействия для doping4.xaml
    /// </summary>
    public partial class doping4 : Window
    {

        OleDbConnection con;  // Задаем осн. команды для использования
        OleDbCommand cmd, cmd2;
        OleDbDataReader dr;
        OleDbDataAdapter da, da2;
        DataSet ds, ds2;

       

     

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string blank = File.ReadAllText(@"message.txt");
           
     

            string TO = txtMail.Text;
            string date = DateTime.Now.ToString("G");

            SmtpClient Client = new SmtpClient();
            Client.Credentials = new NetworkCredential("dopingovich1234@mail.ru", "0UusFAryTk4M87MWeN1U");
            Client.Host = "smtp.mail.ru";
            Client.Port = 587;
            Client.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("dopingovich1234@mail.ru");
            mail.To.Add(new MailAddress(TO));
            mail.Subject = "Бланк мед.освед. " + $"({date})";
            mail.IsBodyHtml = true;
            mail.Body = blank;
            Client.Send(mail);

            MessageBox.Show("Бланк выслан");
            txtMail.Text = "";
            txtNom.Text = "";

        }

        private void txtNom_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                int nom = Convert.ToInt32(txtNom.Text);

                string queryG2 = "SELECT [Номер спортсмена] FROM  [Спортсмены] where  [Номер спортсмена] =" + nom;
                OleDbDataAdapter ad2 = new OleDbDataAdapter(queryG2, con);
                DataTable dtbl2 = new DataTable();
                ad2.Fill(dtbl2);


                if (dtbl2.Rows.Count == 0)
                {
                    MessageBox.Show("Такого спортсмена не существует");
                    txtNom.Text = "";
                }

                else
                {
                    con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = ДопингБД.accdb");
                    con.Open();



                    string queryG = "SELECT [Почта] FROM  [Спортсмены] where  [Номер спортсмена] =" + nom;
                    OleDbCommand cmd = new OleDbCommand(queryG, con);
                    txtMail.Text = cmd.ExecuteScalar().ToString();

                    con.Close();

                }
            }
            catch (FormatException)
            {
                txtNom.Text = "";


            }
        }

        private void txtSearch1_TextChanged(object sender, TextChangedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = ДопингБД.accdb"); // Создаем подключение к БД для этой функции
            cmd = new OleDbCommand(); // Создаем команду
            con.Open();

            string searh = txtSearch1.Text;
            string queary = "SELECT [Номер спортсмена], ФИО, [Номер телефона], Почта FROM Спортсмены WHERE " +
                " ФИО LIKE '%" + searh + "%'";
            OleDbDataAdapter com = new OleDbDataAdapter(queary, con);
            DataSet ds = new DataSet();
            com.Fill(ds, "Спортсмены");
            GridSport.ItemsSource = ds.Tables["Спортсмены"].DefaultView;

            con.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            doping3 Doping3 = new doping3();
            Doping3.Show();
            this.Close();
        }

        public doping4()
        {
            InitializeComponent();

            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = ДопингБД.accdb");

            cmd = new OleDbCommand(); // Создаем команду
            con.Open(); // Открываем соединение с базой

            da = new OleDbDataAdapter("select [Номер спортсмена], ФИО, [Номер телефона], Почта from Спортсмены", con); // Представляет набор команд данных и подключение к базе данных, которые используются для заполнения DataSet и обновления источника данных.
            ds = new DataSet();
            da.Fill(ds, "Спортсмены");

            GridSport.ItemsSource = ds.Tables["Спортсмены"].DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            doping3 Doping3 = new doping3();
            Doping3.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
            PrintDialog pr = new PrintDialog();
            if (pr.ShowDialog() == true)
            {
                pr.PrintVisual(blank, "Печать");
            }
        }
    }
}
