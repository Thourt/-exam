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
using System.Windows.Shapes;

namespace exam
{
    /// <summary>
    /// Логика взаимодействия для WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window
    {
        public WindowRegister()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginInput.Text;
            string pass = PassInput.Text;
            if (login != "" && pass != "")
            {
                new Database.Database().register(login, pass);
                WindowLogin window = new WindowLogin();
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowLogin window = new WindowLogin();
            window.Show();
            this.Close();
        }
    }
}
