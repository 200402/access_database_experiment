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
    public partial class directory : Page
    {
        public MainWindow mainWindow;
        /*private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.F)
            { 
               // mainWindow.Column = dtGrid.CurrentColumn.DisplayIndex;
               // mainWindow.IsHitTestVisible = false;
            }
        }*/

        private List<List<string>> local_table = new List<List<string>>();

        public directory(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            MainWindow.table_name = "Справочник";
            InitializeComponent();
            mainWindow.nomber = 0;
            local_table = filling_table(local_table, mainWindow.table);
            filling();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StyleText();
            Button1.FontWeight = FontWeights.Bold;
            Button1.FontStyle = FontStyles.Italic;
            MainWindow.table_name = "Справочник";
            local_table = filling_table(local_table, mainWindow.table);
            filling();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            StyleText();
            Button2.FontWeight = FontWeights.Bold;
            Button2.FontStyle = FontStyles.Italic;
            MainWindow.table_name = "В библиотеке";
            local_table = filling_table(local_table, mainWindow.table);
            filling();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            StyleText();
            Button3.FontWeight = FontWeights.Bold;
            Button3.FontStyle = FontStyles.Italic;
            MainWindow.table_name = "В читальном зале";
            local_table = filling_table(local_table, mainWindow.table);
            filling();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            StyleText();
            Button4.FontWeight = FontWeights.Bold;
            Button4.FontStyle = FontStyles.Italic;
            MainWindow.table_name = "На руках";
            local_table = filling_table(local_table, mainWindow.table);
            filling();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            StyleText();
            Button5.FontWeight = FontWeights.Bold;
            Button5.FontStyle = FontStyles.Italic;
            MainWindow.table_name = "На списание";
            local_table = filling_table(local_table, mainWindow.table);
            filling();
        }
        private void StyleText()
        {
            Button1.FontWeight = FontWeights.Normal;
            Button1.FontStyle = FontStyles.Normal;
            Button2.FontWeight = FontWeights.Normal;
            Button2.FontStyle = FontStyles.Normal;
            Button3.FontWeight = FontWeights.Normal;
            Button3.FontStyle = FontStyles.Normal;
            Button4.FontWeight = FontWeights.Normal;
            Button4.FontStyle = FontStyles.Normal;
            Button5.FontWeight = FontWeights.Normal;
            Button5.FontStyle = FontStyles.Normal;
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow.nomber > 0)
            {
                mainWindow.nomber--;
                filling();
            }
        }
        private void Right_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow.nomber + 1 != local_table.Count)
            {
                mainWindow.nomber++;
                filling();
            }
        }
        private void Find_part_Click(object sender, RoutedEventArgs e)
        {

            if (ComboBox.SelectedIndex != -1 && TextBox.Text.Length > 0)
            {
                local_table = filling_part_table(local_table, mainWindow.table, ComboBox.SelectedIndex, TextBox.Text);
                filling();
            }
        }
        private List<List<string>> filling_part_table(List<List<string>> table_in, List<List<string>> table_of, int CB, string str)
        {
            local_table.Clear();
            mainWindow.nomber = 0;
            if (MainWindow.table_name == "Справочник")
            {
                for (int i = 0; i < table_of.Count; i++)
                {
                    if (table_of[i][CB].Contains(str))
                    {
                        table_in.Add(table_of[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < table_of.Count; i++)
                {
                    if (table_of[i][3] == MainWindow.table_name)
                    {
                        if (table_of[i][CB].Contains(str))
                        {
                            table_in.Add(table_of[i]);
                        }
                    }
                }
            }
            return table_in;
        }


        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox.SelectedIndex != -1 && TextBox.Text.Length > 0)
            {
                local_table = filling_table(local_table, mainWindow.table, ComboBox.SelectedIndex, TextBox.Text);
                filling();
            }
        }
        private List<List<string>> filling_table(List<List<string>> table_in, List<List<string>> table_of, int CB, string str)
        {
            local_table.Clear();
            mainWindow.nomber = 0;
            if (MainWindow.table_name == "Справочник")
            {
                for (int i = 0; i < table_of.Count; i++)
                {
                    if (table_of[i][CB] == str)
                    {
                        table_in.Add(table_of[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < table_of.Count; i++)
                {
                    if (table_of[i][3] == MainWindow.table_name)
                    {
                        if (table_of[i][CB] == str)
                        {
                            table_in.Add(table_of[i]);
                        }
                    }
                }
            }
            return table_in;
        }

        private List<List<string>> filling_table(List<List<string>> table_in, List<List<string>> table_of)
        {
            local_table.Clear();
            mainWindow.nomber = 0;
            if (MainWindow.table_name == "Справочник")
            {
                for (int i = 0; i < table_of.Count; i++)
                {
                    table_in.Add(table_of[i]);
                }
            }
            else
            {
                for (int i = 0; i < table_of.Count; i++)
                {
                    if (table_of[i][3] == MainWindow.table_name)
                    {
                        table_in.Add(mainWindow.table[i]);
                    }
                }
            }
            return table_in;
        }

        private void filling()
        {

            Quantity.Text = (mainWindow.nomber + 1) + " из " + local_table.Count;
            ID.Text = "";
            Name.Text = "";
            Genre.Text = "";
            Moving.Text = "";
            Data_move.Text = "";
            Data.Text = "";
            Write_off.Text = "";
            ComboBox.Items.Clear();

            ID.Text = local_table[mainWindow.nomber][0];
            Name.Text = local_table[mainWindow.nomber][1];
            Genre.Text = local_table[mainWindow.nomber][2];
            Moving.Text = local_table[mainWindow.nomber][3];
            Data_move.Text = local_table[mainWindow.nomber][4];
            Data.Text = local_table[mainWindow.nomber][5];

            ComboBox.Items.Add("Код");
            ComboBox.Items.Add("Название");
            ComboBox.Items.Add("Жанр");
            ComboBox.Items.Add("Перемещение");
            ComboBox.Items.Add("Дата перемещения");
            ComboBox.Items.Add("Дата поступления");

            if (MainWindow.table_name == "Справочник")
            {
                if (local_table[mainWindow.nomber][3] == "На списание")
                {
                    Write_off_text.Visibility = Visibility.Visible;
                    Write_off.Visibility = Visibility.Visible;
                    Write_off.Text = local_table[mainWindow.nomber][6];
                }
                else
                {
                    Write_off_text.Visibility = Visibility.Hidden;
                    Write_off.Visibility = Visibility.Hidden;
                }
                ComboBox.Items.Add("Причина списания");
            }
            else if (Moving.Text == "На списание")
            {
                Write_off_text.Visibility = Visibility.Visible;
                Write_off.Visibility = Visibility.Visible;
                Write_off.Text = local_table[mainWindow.nomber][6];
                ComboBox.Items.Add("Причина списания");
            }
            else
            {
                Write_off_text.Visibility = Visibility.Hidden;
                Write_off.Visibility = Visibility.Hidden;
            }
        }
    }
} 