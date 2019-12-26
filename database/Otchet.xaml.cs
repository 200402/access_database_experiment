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
    /// Логика взаимодействия для Otchet.xaml
    /// </summary>
    public partial class Otchet : Page
    {
        public MainWindow mainWindow;
        int i = 0;
        int ii = -1;
        List<int> qwer= new List<int>();
        public Otchet(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            InitializeComponent();
            zap();
        }


        public void zap()
        {
            ii++;
            qwer.Add(i);
            int schet = 0;
            string str = mainWindow.table[i][1];
            name.Text = str;
            date.Text = mainWindow.table[i][5];
            for (;mainWindow.table[i][1] == str && i+1 < mainWindow.table.Count; i++)
            {
                schet++;
            }
            kolvo.Text = schet.ToString();
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            if (ii != 0)
            {
                ii--;
                i = qwer[ii];
                ii--;
                zap();
            }
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            if (i + 1 >= mainWindow.table.Count - 1)
            {

            }
            else
            {
                i++;
                zap();
            }
        }
    }
}
