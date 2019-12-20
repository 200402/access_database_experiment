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

namespace database
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Ahmadeev.mdb;";
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Workers.mdb;";

        private string access_level = "123";
        private OleDbConnection myConnection;
        public static string table_name;

        public List<List<string>> table = new List<List<string>>(); 
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
            menu,
        } 

        public string Access_lvl()
        {
            return access_level;
        }

        public void OpenPage(pages pages)
        {
            if (pages == pages.login)
            {
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
            //else if ()
            {

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
                List<string> table2 = new List<string>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    table2.Add(reader[i].ToString());
                }
                table.Add(table2);
            }

            for (int i = 0; i < table.Count; i++)
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
            }
        } 

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            myConnection.Close();
        }

        public OleDbDataReader filling() //определенной таблицы
        {
            string query = "SELECT * FROM [" + table_name + "];";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            return command.ExecuteReader();
        }

    }
}