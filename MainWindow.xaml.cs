using exam.AssemblerCore;
using System;
using System.Windows;

namespace exam
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void UpdateUIRegister(int R0, int R1, int R2, int R3)
        {
            Register0.Content = R0;
            Register1.Content = R1;
            Register2.Content = R2;
            Register3.Content = R3;
        }

        //Обработчик нажатия кнопки "Выполнить"
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //Получаем массив комманд из TextBox
            string[] commands = Code.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Core core = new Core(commands);
            core.execude(this);
        }
    }
}
