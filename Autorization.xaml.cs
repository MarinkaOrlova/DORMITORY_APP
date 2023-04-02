using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MessageBox = System.Windows.MessageBox;

namespace SIMPLE_APP
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Button_Auto_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBox_login.Text.Trim();
            string pass = PasswordBox_password.Password.Trim();

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
            else
            {
                /*TextBox_login.ToolTip = "";
                TextBox_login.Background = Brushes.Transparent;
                PasswordBox_password.ToolTip = "";
                PasswordBox_password.Background = Brushes.Transparent;*/

                User authuser = null;
                using (AppContext db = new AppContext())
                {
                    authuser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }

                if (authuser != null)
                {
                    MainWindow mainWindow= new MainWindow();
                    mainWindow.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Вы ввели что-то некорректно");
            }
        }

        private void Button_R_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Hide();
        }
    }
}
