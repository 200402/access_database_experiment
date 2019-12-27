using System;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text; 
using System.Web.UI.MobileControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Diagnostics;

namespace database
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Ahmadeev.mdb;";
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Workers.mdb;";

        public string access_level = "Юзер";
        private OleDbConnection myConnection;
        public static string table_name;

        public List<Base> table = new List<Base>(); 
        public int nomber; 
        public static int Collums;
        
        
        public MainWindow()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OpenPage(pages.login);
            bdForList();
        } 
         
        public enum pages
        {
            login,
            directory,
            directory_admin,
            new_user,
            menu,
            Request,
            change,
            append,
            Otchet,
        } 

        public string Access_lvl()
        {
            return access_level;
        }

        public void OpenPage(pages pages)
        {
            if (access_level == "Юзер")
            {
                if (pages == pages.login)
                {
                    access_level = "Юзер";
                    menu.Navigate(new frame_clear(this));
                    content.Navigate(new frame_clear(this));
                    frame.Navigate(new login(this));
                } 
                else if (pages == pages.directory)
                {
                    frame.Navigate(new frame_clear(this));
                    content.Navigate(new directory(this));
                    menu.Navigate(new menu(this));
                }
                else if (pages == pages.Request)
                {
                    frame.Navigate(new frame_clear(this));
                    content.Navigate(new Request(this));
                    menu.Navigate(new menu(this));
                }
                else if (pages == pages.Otchet)
                {
                    frame.Navigate(new frame_clear(this));
                    content.Navigate(new Otchet(this));
                    menu.Navigate(new menu(this));
                }
            }
            else if (access_level == "Админ")
            {
                if (pages == pages.login)
                {
                    access_level = "Юзер";
                    menu.Navigate(new frame_clear(this));
                    content.Navigate(new frame_clear(this));
                    frame.Navigate(new login(this));
                }
                else if (pages == pages.Request)
                {
                    frame.Navigate(new frame_clear(this));
                    content.Navigate(new Request(this));
                    menu.Navigate(new menu(this));
                }
                else if (pages == pages.directory)
                {
                    frame.Navigate(new frame_clear(this));
                    content.Navigate(new directory_admin(this));
                    menu.Navigate(new menu(this));
                }
                else if (pages == pages.new_user)
                {
                    frame.Navigate(new frame_clear(this));
                    content.Navigate(new new_user(this));
                    menu.Navigate(new menu(this));
                } 
                else if (pages == pages.change)
                {
                    frame.Navigate(new frame_clear(this));
                    content.Navigate(new change(this));
                    menu.Navigate(new menu(this));
                }
                else if (pages == pages.append)
                {
                    frame.Navigate(new frame_clear(this));
                    content.Navigate(new append(this));
                    menu.Navigate(new menu(this));
                }
                else if (pages == pages.Otchet)
                {
                    frame.Navigate(new frame_clear(this));
                    content.Navigate(new Otchet(this));
                    menu.Navigate(new menu(this));
                }
            }
        }

        public void register(string login, string password)
        {
            //string query = "SELECT Access.Access_level FROM Access WHERE(((Access.Login) =login) AND((Access.Password) =password));";
            string query = "SELECT Access.Access_level FROM Access WHERE(((Access.Login) ='" + login + "') AND((Access.Password) ='" + password + "'));";
            
            OleDbCommand command = new OleDbCommand(query, myConnection); 
            
            if (command.ExecuteScalar() != null)
            {
                access_level = command.ExecuteScalar().ToString();
                OpenPage(pages.directory);
            }
            else
            {
                MessageBox.Show("Не правильный логин или пароль");
            }


            /*OleDbCommand command = myConnection.CreateCommand();
            command.CommandText = query;
            OleDbDataReader DataReader = command.ExecuteReader();
            while (DataReader.Read()) 
            {
                Console.WriteLine(string.Format("Id: {0}", DataReader));
            }*/
        }

        public void bdForList() //определенной таблицы
        {
            string query = "SELECT * FROM [Справочник];";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                    Base table2 = new Base();
                    table2.ID = Int32.Parse(reader[0].ToString());
                    table2.Name = reader[1].ToString();
                    table2.Genre = reader[2].ToString();
                    table2.Moving = reader[3].ToString();
                    table2.Data_move = Convert.ToDateTime(reader[4].ToString());
                    table2.Data = Convert.ToDateTime(reader[5]);
                    table2.Write_off = reader[6].ToString();
                    table.Add(table2);
            }

            /*for (int i = 0; i < table.Count; i++)
            {
                try
                {
                    table[i][4] = table[i][4].Remove(table[i][4].Length - 8);
                }
                catch
                {

                }
                try
                {
                    table[i][5] = table[i][5].Remove(table[i][5].Length - 8);
                }
                catch
                {

                }
            }*/
        } 

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            string query = "DELETE * FROM [Справочник];";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteReader();
            for (int i = 0; i < table.Count; i++)
            {
                query = "INSERT INTO [Справочник] VALUES(" + table[i].ID + ",'" + table[i].Name + "','" + table[i].Genre + "','" + table[i].Moving + "','" + table[i].Data_move + "','" + table[i].Data + "','" + table[i].Write_off + "')";
                OleDbCommand command2 = new OleDbCommand(query, myConnection);
                command2.ExecuteNonQuery();
            }
            
        }

        public OleDbDataReader filling() //определенной таблицы
        {
            string query = "SELECT * FROM [" + table_name + "];";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            return command.ExecuteReader();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (access_level == "Админ")
            {
                if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.U)
                {
                    OpenPage(pages.new_user);
                }
                else if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.Q)
                {
                    myConnection.Close();
                    Process.GetCurrentProcess().Kill();
                }
                else if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.H)
                {
                    OpenPage(pages.change);
                }
                else if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D)
                {
                    OpenPage(pages.append);
                }
            }
        }

        public void add_user(string login, string password, string lvl)
        {
            try
            {
                string query = "INSERT INTO [Access] VALUES('" + login + "','" + password + "','" + lvl + "')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Пользователь успешно добавлен");
                OpenPage(pages.directory);
            }
            catch
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
            }
        }

        public void change(string what, string for_what,string qwer)
        {

            try
            {
                int a = 0;
                for (int i = 0; i < table.Count;i++)
                {
                    switch (qwer)
                    {
                        case "Название":
                            if (table[i].Name.Contains(what))
                            {
                                table[i].Name = table[i].Name.Replace(what, for_what);
                                a++;
                            }
                            break;

                        case "Жанр":
                            if (table[i].Genre.Contains(what))
                            {
                                table[i].Genre = table[i].Genre.Replace(what, for_what);
                                a++;
                            }
                            break;

                        case "Дата перемещения":
                            if (table[i].Data_move == Convert.ToDateTime(what))
                            {
                                table[i].Data_move = Convert.ToDateTime(what);
                                a++;
                            }
                            break;

                        case "Дата поступления":
                            if (table[i].Data == Convert.ToDateTime(what))
                            {
                                table[i].Data = Convert.ToDateTime(what);
                                a++;
                            }
                            break;

                        case "Причина списания":
                            if (table[i].Write_off.Contains(what))
                            {
                                table[i].Write_off = table[i].Write_off.Replace(what, for_what);
                                a++;
                            }
                            break;

                    }
                }
                MessageBox.Show($"Было имененно {a} записей");
                OpenPage(pages.directory); 
            }
            catch
            {
                MessageBox.Show("Выберите столбец");
            }
        }

        
    }

    public class Base
    {
        public int ID;
        public string Name;
        public string Genre;
        public string Moving;
        public DateTime Data_move;
        public DateTime Data;
        public string Write_off;
    }
}