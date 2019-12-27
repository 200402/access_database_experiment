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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace database
{
    /// <summary>
    /// Логика взаимодействия для append.xaml
    /// </summary>
    public partial class append : Page
    {
        public MainWindow mainWindow;
        public append(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            Data_move.Text = DateTime.Now.ToString();
            Data.Text = DateTime.Now.ToString();
            Moving.Items.Clear();
            Moving.Items.Add("В библиотеке");
            Moving.Items.Add("В читальном зале");
            Moving.Items.Add("На руках");
            Moving.Items.Add("На списание");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = mainWindow.table[mainWindow.table.Count - 1].ID;
                for (int i = 0; i < int.Parse(quantity.Text); i++)
                {
                    a++;
                    Base table2 = new Base
                    {
                        ID = a,
                        Name = Name.Text,
                        Genre = Genre.Text,
                        Moving = Moving.Text,
                        Data_move = Convert.ToDateTime(Data_move.Text),
                        Data = Convert.ToDateTime(Data.Text),
                        Write_off = Write_off.Text
                    };

                    mainWindow.table.Add(table2);
                }
                MessageBox.Show("Записи успешно добаленны");
                mainWindow.OpenPage(MainWindow.pages.directory);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if ( Moving.Text != "На списание")
            {
                Write_off.Text = "";
                Write_off.IsReadOnly = true;
            }
            else
            {
                Write_off.IsReadOnly = false;
            }
        }
    }
}
