using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace SIMPLE_APP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        AppContext db;
        public RegistrationWindow()
        {
            InitializeComponent();

            db = new AppContext();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBox_login.Text.Trim();
            string pass = PasswordBox_password.Password.Trim();
            string pass_2 = PasswordBox_repeat_password.Password.Trim();
            string email = TextBox_email.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                TextBox_login.ToolTip = "Ойойой, ошибочка вышла...";
                TextBox_login.Background = Brushes.Linen;
            }
            else if (pass.Length < 5)
            {
                PasswordBox_password.ToolTip = "Ойойой, ошибочка вышла...";
                PasswordBox_password.Background = Brushes.Teal;
            }
            else if (pass_2 != pass)
            {
                PasswordBox_repeat_password.ToolTip = "Ойойой, ошибочка вышла...";
                PasswordBox_repeat_password.Background = Brushes.Teal;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                TextBox_email.ToolTip = "Ойойой, ошибочка вышла...";
                TextBox_email.Background = Brushes.Teal;
            }
            else
            {
                TextBox_login.ToolTip = "";
                TextBox_login.Background = Brushes.Transparent;
                PasswordBox_password.ToolTip = "";
                PasswordBox_password.Background = Brushes.Transparent;
                PasswordBox_repeat_password.ToolTip = "";
                PasswordBox_repeat_password.Background = Brushes.Transparent;
                TextBox_email.ToolTip = "";
                TextBox_email.Background = Brushes.Transparent;

                
                User user = new User(login, email, pass);

                db.Users.Add(user);
                db.SaveChanges();

                MessageBox.Show("SO GOOD!");

                Autorization autorization = new Autorization();
                autorization.Show();
                Hide();
            }
        }

        private void Button_wa_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
            Hide();

        }
    }
}
       
