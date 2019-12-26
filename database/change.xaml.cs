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
    /// Логика взаимодействия для change.xaml
    /// </summary>
    public partial class change : Page
    {
        public MainWindow mainWindow;
        public change(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            ComboBox.Items.Add("Название");
            ComboBox.Items.Add("Жанр");
            ComboBox.Items.Add("Перемещение");
            ComboBox.Items.Add("Дата перемещения");
            ComboBox.Items.Add("Дата поступления");
            ComboBox.Items.Add("Причина списания");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.change(what.Text, for_what.Text, ComboBox.SelectedIndex + 1);
        }
    }
}
