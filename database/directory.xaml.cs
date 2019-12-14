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
    /// Логика взаимодействия для directory.xaml
    /// </summary>
    public partial class directory : Page
    {
        public MainWindow mainWindow;
        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.F)
            {
                Search Search = new Search();
                Search.Show();
            }

        }
        public directory(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            dtGrid.Items.Clear();
            dtGrid.ItemsSource = mainWindow.filling("Справочник");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StyleText(); 
            Button1.FontWeight = FontWeights.Bold;
            Button1.FontStyle = FontStyles.Italic;
            dtGrid.ItemsSource = mainWindow.filling("Справочник");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            StyleText();
            Button2.FontWeight = FontWeights.Bold;
            Button2.FontStyle = FontStyles.Italic;
            dtGrid.ItemsSource = mainWindow.filling("В библиотеке");
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            StyleText();
            Button3.FontWeight = FontWeights.Bold;
            Button3.FontStyle = FontStyles.Italic;
            dtGrid.ItemsSource = mainWindow.filling("В читальном зале");
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            StyleText();
            Button4.FontWeight = FontWeights.Bold;
            Button4.FontStyle = FontStyles.Italic;
            dtGrid.ItemsSource = mainWindow.filling("На руках");
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            StyleText();
            Button5.FontWeight = FontWeights.Bold;
            Button5.FontStyle = FontStyles.Italic;
            dtGrid.ItemsSource = mainWindow.filling("На списание");
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

    }
} 