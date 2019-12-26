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
    /// Логика взаимодействия для Request.xaml
    /// </summary>
    public partial class Request : Page
    {
        public MainWindow mainWindow;
        public Request(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            List<string> list = new List<string>();

            for (int i = 0; i < mainWindow.table.Count; i++)
            {
                if (mainWindow.table[i][3] == "На руках")
                {
                    list.Add(mainWindow.table[i][1]);
                }
            }

            int max = 0;

            string[,] mas = new string[list.Count,2];

            int Count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                byte control = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        Count++;
                    }
                    if (list[i] == mas[j, 0])
                    {
                        control = 1;
                    }
                }
                if (control == 0)
                {
                    int j;
                    for ( j = 0; mas[j,0] != null; j++)
                    {

                    }
                    mas[j, 0] = list[i];
                    mas[j, 1] = Count.ToString();
                }
                if (max < Count)
                {
                    max = Count;
                }
                Count = 0;
            }

            for (;max != 0; max--)
            {
                for (int i = 0; i < mas.Length/2; i++)
                {
                    if (mas[i,1] == max.ToString())
                    {
                        int q = 0;
                        string str = null;
                        while (str == null)
                        {
                            Count = 0;
                            if (mainWindow.table[q][1] == mas[i, 0])
                            {
                                for (int qwe = 0; qwe < mainWindow.table.Count; qwe++)
                                {
                                    if (mainWindow.table[qwe][1] == mas[i, 0] && mainWindow.table[qwe][3] == "В библиотеке")
                                    {
                                        Count++;
                                    }
                                }
                                str = $"Название: {mainWindow.table[q][1]}";
                                str += $", жанр {mainWindow.table[q][2]}, ";
                                str += $"в библиотеке осталось {Count} таких,";
                                str += $" а на руках их { mas[i, 1]}";
                            }
                            q++;
                        }
                        ListBox.Items.Add(str);
                    }
                }
            }
        }
    }
}
