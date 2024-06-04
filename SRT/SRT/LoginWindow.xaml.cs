using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

namespace SRT
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Dictionary<string, string> accounts;
        public LoginWindow()
        {
            InitializeComponent();
            InitializeAccounts();
        }
        private void InitializeAccounts()
        {
            accounts = new Dictionary<string, string>
            {
                { "ЖЭК", "admin" }, { "Кассир", "kassir" }, { "user", "user" }
            };
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Text;

            if (accounts.ContainsKey(username) && accounts[username] == password)
            {
                MessageBox.Show("Вход выполнен");
                if (username == "ЖЭК")
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else if (username == "Кассир")
                {
                    KassirWindow kassirWindow = new KassirWindow();
                    kassirWindow.Show();
                }
                else if (username == "user")
                {
                    UserWindow userWindow = new UserWindow();
                    userWindow.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
