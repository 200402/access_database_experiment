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
    /// Логика взаимодействия для directory_admin.xaml
    /// </summary>
    public partial class directory : Page
    {
        public MainWindow mainWindow;
        private List<Base> local_table = new List<Base>();
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
            mainWindow.nomber = 0;
            Button1.FontWeight = FontWeights.Bold;
            Button1.FontStyle = FontStyles.Italic;
            MainWindow.table_name = "Справочник";
            filling_table();
            filling();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            StyleText();
            mainWindow.nomber = 0;
            Button2.FontWeight = FontWeights.Bold;
            Button2.FontStyle = FontStyles.Italic;
            MainWindow.table_name = "В библиотеке";
            filling_table();
            filling();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            StyleText();
            mainWindow.nomber = 0;
            Button3.FontWeight = FontWeights.Bold;
            Button3.FontStyle = FontStyles.Italic;
            MainWindow.table_name = "В читальном зале";
            filling_table();
            filling();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            StyleText();
            mainWindow.nomber = 0;
            Button4.FontWeight = FontWeights.Bold;
            Button4.FontStyle = FontStyles.Italic;
            MainWindow.table_name = "На руках";
            filling_table();
            filling();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            StyleText();
            mainWindow.nomber = 0;
            Button5.FontWeight = FontWeights.Bold;
            Button5.FontStyle = FontStyles.Italic;
            MainWindow.table_name = "На списание";
            filling_table();
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
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            local_table = filling_table(local_table, mainWindow.table);
            filling();
            TextBox.Text = "";
            ComboBox.SelectedIndex = -1;
            Combo.SelectedIndex = -1;
        }


        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox.SelectedIndex == 2 && Combo.SelectedIndex != -1)
            {
                filling_table(ComboBox.Text, Combo.Text);
                filling();
            }
            else if (ComboBox.SelectedIndex != -1 && TextBox.Text.Length > 0)
            {
                filling_table(ComboBox.Text, TextBox.Text);
                filling();
            }
            TextBox.Text = "";
            ComboBox.SelectedIndex = -1;
            Combo.SelectedIndex = -1;

        }

        private void filling_table(string CB, string str)
        {
            int check = 0;
            switch (CB)
            {
                case "Код":
                    for (int i = 0; mainWindow.table.Count > i; i++)
                    {
                        if (mainWindow.table[i].ID.ToString() == str)
                        {
                            if (check == 0)
                            {
                                check = 1;
                                local_table.Clear();
                                mainWindow.nomber = 0;
                            }
                            Base qwe = mainWindow.table[i];
                            local_table.Add(qwe);
                                
                        }
                    }
                    break;
                case "Название":
                    for (int i = 0; mainWindow.table.Count > i; i++)
                    {
                        if (mainWindow.table[i].Name == str)
                        {
                            if (check == 0)
                            {
                                check = 1;
                                local_table.Clear();
                                mainWindow.nomber = 0;
                            }
                            local_table.Add(mainWindow.table[i]);
                        }
                    }
                    break;
                case "Жанр":
                    for (int i = 0; mainWindow.table.Count > i; i++)
                    {
                        if (mainWindow.table[i].Genre == str)
                        {
                            if (check == 0)
                            {
                                check = 1;
                                local_table.Clear();
                                mainWindow.nomber = 0;
                            }
                            local_table.Add(mainWindow.table[i]);
                        }
                    }
                    break;
                case "Перемещение":
                    for (int i = 0; mainWindow.table.Count > i; i++)
                    {
                        if (mainWindow.table[i].Moving == str)
                        {
                            if (check == 0)
                            {
                                check = 1;
                                local_table.Clear();
                                mainWindow.nomber = 0;
                            }
                            local_table.Add(mainWindow.table[i]);
                        }
                    }
                    break;
                case "Дата перемещения":
                    for (int i = 0; mainWindow.table.Count > i; i++)
                    {
                        if (mainWindow.table[i].Data_move == Convert.ToDateTime(str))
                        {
                            if (check == 0)
                            {
                                check = 1;
                                local_table.Clear();
                                mainWindow.nomber = 0;
                            }
                            local_table.Add(mainWindow.table[i]);
                        }
                    }
                    break;
                case "Дата поступления":
                    for (int i = 0; mainWindow.table.Count > i; i++)
                    {
                        if (mainWindow.table[i].Data == Convert.ToDateTime(str))
                        {
                            if (check == 0)
                            {
                                check = 1;
                                local_table.Clear();
                                mainWindow.nomber = 0;
                            }
                            local_table.Add(mainWindow.table[i]);
                        }
                    }
                    break;
                case "Причина списания":
                    for (int i = 0; mainWindow.table.Count > i; i++)
                    {
                        if (mainWindow.table[i].Write_off == str)
                        {
                            if (check == 0)
                            {
                                check = 1;
                                local_table.Clear();
                                mainWindow.nomber = 0;
                            }
                            local_table.Add(mainWindow.table[i]);
                        }
                    }
                    break;

            }
            if (check == 0)
            {
                MessageBox.Show("Ничего не найдено");
            }
        }

        private void filling_table()
        {
            if (MainWindow.table_name == "Справочник")
            {
                for (int i = 0; i < mainWindow.table.Count; i++)
                {
                    local_table.Add(mainWindow.table[i]);
                }
            }
            else
            {
                for (int i = 0; i < mainWindow.table.Count; i++)
                {
                    if (mainWindow.table[i].Moving == MainWindow.table_name)
                    {
                        local_table.Add(mainWindow.table[i]);
                    }
                }
            }
            local_table.Clear();
            mainWindow.nomber = 0;
        }

        private List<Base> filling_table(List<Base> table_in, List<Base> table_of)
        {
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
                    if (table_of[i].Moving == MainWindow.table_name)
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

            Data_move.Text = "";
            Data.Text = "";
            Write_off.Text = "";
            ComboBox.Items.Clear();

            ID.Text = local_table[mainWindow.nomber].ID.ToString();
            Name.Text = local_table[mainWindow.nomber].Name;
            Moving.Text = local_table[mainWindow.nomber].Moving;
            Genre.Text = local_table[mainWindow.nomber].Genre;
            Data_move.Text = local_table[mainWindow.nomber].Data_move.ToString();
            Data.Text = local_table[mainWindow.nomber].Data.ToString();

            ComboBox.Items.Add("Код");
            ComboBox.Items.Add("Название");
            ComboBox.Items.Add("Жанр");
            ComboBox.Items.Add("Перемещение");
            ComboBox.Items.Add("Дата перемещения");
            ComboBox.Items.Add("Дата поступления");

            if (MainWindow.table_name == "Справочник")
            {
                if (local_table[mainWindow.nomber].Moving == "На списание")
                {
                    Write_off_text.Visibility = Visibility.Visible;
                    Write_off.Visibility = Visibility.Visible;
                    Write_off.Text = local_table[mainWindow.nomber].Write_off;
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
                Write_off.Text = local_table[mainWindow.nomber].Write_off;
                ComboBox.Items.Add("Причина списания");
            }
            else
            {
                Write_off_text.Visibility = Visibility.Hidden;
                Write_off.Visibility = Visibility.Hidden;
            }
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < mainWindow.table.Count; i++)
            {
                if (mainWindow.table[i].ID.ToString() == ID.Text)
                {
                    mainWindow.table[i].Name = Name.Text;
                    mainWindow.table[i].Genre = Genre.Text;
                    mainWindow.table[i].Moving = Moving.Text;
                    mainWindow.table[i].Data_move = Convert.ToDateTime(Data_move.Text);
                    mainWindow.table[i].Data = Convert.ToDateTime(Data.Text);
                    mainWindow.table[i].Write_off = Write_off.Text;
                }

            }
            for (int i = 0; i < local_table.Count; i++)
            {
                if (local_table[i].ID.ToString() == ID.Text)
                {
                    local_table[i].Name = Name.Text;
                    local_table[i].Genre = Genre.Text;
                    local_table[i].Moving = Moving.Text;
                    local_table[i].Data_move = Convert.ToDateTime(Data_move.Text);
                    local_table[i].Data = Convert.ToDateTime(Data.Text);
                    local_table[i].Write_off = Write_off.Text;
                }
            }

            if (Moving.Text == "На списание")
            {
                Write_off_text.Visibility = Visibility.Visible;
                Write_off.Visibility = Visibility.Visible;
                if (Write_off.Text.Length <= 1)
                {
                    Write_off.Text = "Ветхость";
                }
            }
            else
            {
                Write_off_text.Visibility = Visibility.Hidden;
                Write_off.Visibility = Visibility.Hidden;
                Write_off.Text = " ";
            }

            if (ComboBox.Text == "Жанр")
            {
                Combo.Visibility = Visibility.Visible;

                for (int i = 0; i < mainWindow.table.Count; i++)
                {
                    int check = 0;
                    for (int j = 0; Combo.Items.Count > j; j++)
                    {
                        if (Combo.Items.IndexOf(mainWindow.table[i].Genre) != -1)
                        {
                            check = 1;
                        }
                    }
                    if (check == 0)
                    {
                        Combo.Items.Add(mainWindow.table[i].Genre);
                    }
                }
            }
            else
            {
                Combo.Visibility = Visibility.Hidden;
            }

        }

        private void Moving_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data_move.Text = DateTime.Now.ToString();
        }

        private void Page_PreviewMouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}