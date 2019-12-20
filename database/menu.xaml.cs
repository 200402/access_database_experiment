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
    /// Логика взаимодействия для menu.xaml
    /// </summary>
    public partial class menu : Page
    {
        public MainWindow mainWindow;
        public directory Directory; 
        public login Login;
        public menu(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            TextBlock.Text = login.log;
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.login);
        }

        private void Request_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Moving_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.directory);
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
