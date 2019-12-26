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
                int a = int.Parse(mainWindow.table[mainWindow.table.Count - 1][0]);
                for (int i = 0; i < int.Parse(quantity.Text); i++)
                {
                    a++;
                    List<string> table2 = new List<string>();
                    table2.Add(a.ToString());
                    table2.Add(Name.Text);
                    table2.Add(Genre.Text);
                    table2.Add(Moving.Text);
                    table2.Add(Data_move.Text);
                    table2.Add(Data.Text);
                    table2.Add(Write_off.Text);
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
