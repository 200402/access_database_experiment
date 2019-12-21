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
    /// Логика взаимодействия для new_user.xaml
    /// </summary>
    public partial class new_user : Page
    {
        public MainWindow mainWindow;
        public new_user(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            level.Items.Add("Админ");
            level.Items.Add("Юзер");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.add_user(Login.Text, password.Password, level.Text);
        }
    }
}
