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
using System.Data.Common;
using System.Linq.Expressions;

namespace dopin
{
    /// <summary>
    /// Логика взаимодействия для doping12.xaml
    /// </summary>
    public partial class doping12 : Window
    {
        OleDbConnection con;  // Задаем осн. команды для использования
        OleDbCommand cmd, cmd2;
        OleDbDataReader dr;
        OleDbDataAdapter da, da2;
        DataSet ds, ds2;

        public doping12()
        {
            InitializeComponent();

            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = ДопингБД.accdb");
        
            cmd = new OleDbCommand(); // Создаем команду
            con.Open(); // Открываем соединение с базой

            da = new OleDbDataAdapter("select [Номер спортсмена], ФИО, [Номер телефона] from Спортсмены", con); // Представляет набор команд данных и подключение к базе данных, которые используются для заполнения DataSet и обновления источника данных.
            ds = new DataSet();
            da.Fill(ds, "Спортсмены");

            GridSport.ItemsSource = ds.Tables["Спортсмены"].DefaultView; // Заполнение грида нужной базой


            InitializeComponent();

            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = ДопингБД.accdb");

            cmd = new OleDbCommand(); // Создаем команду
            con.Open(); // Открываем соединение с базой

            da = new OleDbDataAdapter("select [Номер спортсмена], ФИО, [Номер телефона], [Результат тестирования], [Причина] from [Результат тестирования]", con); // Представляет набор команд данных и подключение к базе данных, которые используются для заполнения DataSet и обновления источника данных.
            ds = new DataSet();
            da.Fill(ds, "Результат тестирования");

            GridRes.ItemsSource = ds.Tables["Результат тестирования"].DefaultView; // Заполнение грида нужной базой
            con.Close();

            combo1.SelectedIndex = 0;
            combo2.SelectedIndex = 0;
            combo3.SelectedIndex = 0;
            combo4.SelectedIndex = 0;

            con.Open();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            da = new OleDbDataAdapter("select [Номер спортсмена], ФИО, [Номер телефона], [Результат тестирования] from [Результат тестирования]", con); // Представляет набор команд данных и подключение к базе данных, которые используются для заполнения DataSet и обновления источника данных.
            ds = new DataSet();
            da.Fill(ds, "Результат тестирования");

            GridRes.ItemsSource = ds.Tables["Результат тестирования"].DefaultView;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            da = new OleDbDataAdapter("select [Номер спортсмена], ФИО, [Номер телефона], [Результат тестирования] from [Результат тестирования] where [Результат тестирования] = 'Годен'", con); // Представляет набор команд данных и подключение к базе данных, которые используются для заполнения DataSet и обновления источника данных.
            ds = new DataSet();
            da.Fill(ds, "Результат тестирования");

            GridRes.ItemsSource = ds.Tables["Результат тестирования"].DefaultView;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            da = new OleDbDataAdapter("select [Номер спортсмена], ФИО, [Номер телефона], [Результат тестирования] from [Результат тестирования] where [Результат тестирования] = 'Не годен'", con); // Представляет набор команд данных и подключение к базе данных, которые используются для заполнения DataSet и обновления источника данных.
            ds = new DataSet();
            da.Fill(ds, "Результат тестирования");

            GridRes.ItemsSource = ds.Tables["Результат тестирования"].DefaultView;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = ДопингБД.accdb");
            con.Open();

            try
            {
                int nom = Convert.ToInt32(txtID2.Text);

                string queryG2 = "SELECT [Номер спортсмена] FROM  [результат Тестирования] where  [Номер спортсмена] =" + nom;
                OleDbDataAdapter ad2 = new OleDbDataAdapter(queryG2, con);
                DataTable dtbl2 = new DataTable();
                ad2.Fill(dtbl2);

                if (dtbl2.Rows.Count == 0)
                {
                    MessageBox.Show("Такого спортсмена не существует");
                    txtID2.Text = "";
                }

                else
                {
                    try
                    {


                        string res = combo2.Text;
                        string prich2 = combo4.Text;

                        string query = "UPDATE [Результат тестирования] SET [Результат тестирования] = '" + res + "', [Причина] = '" + prich2 + "' WHERE [Номер спортсмена] = " + nom;
                        OleDbCommand cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Получилось");

                        da = new OleDbDataAdapter("select [Номер спортсмена], ФИО, [Номер телефона], [Результат тестирования], Причина from [Результат тестирования]", con); // Представляет набор команд данных и подключение к базе данных, которые используются для заполнения DataSet и обновления источника данных.
                        ds = new DataSet();
                        da.Fill(ds, "Результат тестирования");

                        GridRes.ItemsSource = ds.Tables["Результат тестирования"].DefaultView;



                        txtID2.Text = "";
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Введите номер правильно");
                        
                    }
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Введите номер правильно");
                txtID2.Text = "";
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            con.Close();
        }

        private void txtSearch1_TextChanged(object sender, TextChangedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = ДопингБД.accdb"); // Создаем подключение к БД для этой функции
            cmd = new OleDbCommand(); // Создаем команду
            con.Open();

            string searh = txtSearch1.Text;
            string queary = "SELECT [Номер спортсмена], ФИО, [Номер телефона] FROM Спортсмены WHERE " +
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

        private void txtSearch2_TextChanged(object sender, TextChangedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = ДопингБД.accdb"); // Создаем подключение к БД для этой функции
            cmd = new OleDbCommand(); // Создаем команду
            con.Open();

            string searh2 = txtSearch2.Text;
            string queary = "SELECT [Номер спортсмена], ФИО, [Номер телефона], [Результат тестирования], Причина FROM [Результат Тестирования] WHERE " +
                " ФИО LIKE '%" + searh2 + "%'";
            OleDbDataAdapter com = new OleDbDataAdapter(queary, con);
            DataSet ds = new DataSet();
            com.Fill(ds, "[Результат Тестирования]");
            GridRes.ItemsSource = ds.Tables["[Результат Тестирования]"].DefaultView;

            con.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            doping3 Doping3 = new doping3();
            Doping3.Show();
            this.Close();
        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            con = new OleDbConnection(@"Provider = Microsoft.ACE.Oledb.12.0; Data Source = ДопингБД.accdb");
            con.Open();

            try
            {

                int nom = Convert.ToInt32(txtID1.Text);


                string queryG = "SELECT [Номер спортсмена] FROM  [Результат Тестирования] where  [Номер спортсмена] =" + nom;
                OleDbDataAdapter ad = new OleDbDataAdapter(queryG, con);
                DataTable dtbl = new DataTable();
                ad.Fill(dtbl);

                if (dtbl.Rows.Count == 1)
                {
                    MessageBox.Show("Данному спортсмену уже присвоен результат");
                    txtID1.Text = "";
                }


                else
                {
                    string queryG2 = "SELECT [Номер спортсмена] FROM  [Спортсмены] where  [Номер спортсмена] =" + nom;
                    OleDbDataAdapter ad2 = new OleDbDataAdapter(queryG2, con);
                    DataTable dtbl2 = new DataTable();
                    ad2.Fill(dtbl2);

                    if (dtbl2.Rows.Count == 0)
                    {
                        MessageBox.Show("Такого спортсмена не существует");
                        txtID1.Text = "";
                    }

                    else
                    {


                        try
                        {


                            string res = combo1.Text;
                            string prich = combo3.Text;

                            string query1 = "SELECT [ФИО] FROM Спортсмены WHERE [Номер спортсмена] = " + nom;
                            OleDbCommand cmd = new OleDbCommand(query1, con);
                            string fio = cmd.ExecuteScalar().ToString();

                            string query2 = "SELECT [Номер телефона] FROM Спортсмены WHERE [Номер спортсмена] = " + nom;
                            cmd = new OleDbCommand(query2, con);
                            string tel = cmd.ExecuteScalar().ToString();

                            string query3 = "SELECT [Почта] FROM Спортсмены WHERE [Номер спортсмена] = " + nom;
                            cmd = new OleDbCommand(query3, con);
                            string mail = cmd.ExecuteScalar().ToString();

                            string query = $"INSERT INTO [Результат Тестирования] ([Номер спортсмена], ФИО, [Номер телефона], Почта, [Результат тестирования], Причина) VALUES ('{nom}'," +
                                $" '{fio}', '{tel}', '{mail}', '{res}', '{prich}')";
                            OleDbCommand cmd2 = new OleDbCommand(query, con);
                            cmd2.ExecuteNonQuery();

                            MessageBox.Show("Запись добавлена");

                            da = new OleDbDataAdapter("select [Номер спортсмена], ФИО, [Номер телефона], [Результат тестирования], Причина FROM [Результат Тестирования]", con);
                            ds = new DataSet();
                            da.Fill(ds, "[Результат Тестирования]");
                            GridRes.ItemsSource = ds.Tables["[Результат Тестирования]"].DefaultView;


                            string queryD = "DELETE FROM Спортсмены WHERE [Номер спортсмена] = " + nom;
                            cmd = new OleDbCommand(queryD, con);
                            cmd.ExecuteNonQuery();

                            da = new OleDbDataAdapter("select * from Спортсмены", con);
                            ds = new DataSet();
                            da.Fill(ds, "Спортсмены");
                            GridSport.ItemsSource = ds.Tables["Спортсмены"].DefaultView;





                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Введите номер правильно");

                        }

                    }
                }
            }


            catch (FormatException)
            {
                MessageBox.Show("Введите номер правильно");
                txtID1.Text = "";
            }

            }
        } 

        }
    

