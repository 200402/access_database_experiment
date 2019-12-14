using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
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

namespace database
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Ahmadeev.mdb;";
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Workers.mdb;";

        private OleDbConnection myConnection;

        public static string access_level = "123";


        public MainWindow()
        {
            InitializeComponent(); 
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OpenPage(pages.login);
        } 
         
        public enum pages
        {
            login,
            directory,
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
            //try
            { 
                access_level = command.ExecuteScalar().ToString();
                OpenPage(pages.directory);
            }
            //catch
            {
              //  MessageBox.Show("Пользователь не найден");
            }


            /*OleDbCommand command = myConnection.CreateCommand();
            command.CommandText = query;
            OleDbDataReader DataReader = command.ExecuteReader();
            while (DataReader.Read()) 
            {
                Console.WriteLine(string.Format("Id: {0}", DataReader));
            }*/
        }


        public OleDbDataReader filling(string table)
        {
            string query = "SELECT * FROM ["+ table + "];";
            OleDbCommand command = new OleDbCommand(query, myConnection); 
            return command.ExecuteReader();
        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            myConnection.Close();
        }
    }
}