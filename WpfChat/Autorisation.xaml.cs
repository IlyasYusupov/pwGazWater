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
using pwGazWater.Data;

namespace WpfChat
{
    /// <summary>
    /// Логика взаимодействия для Autorisation.xaml
    /// </summary>
    public partial class Autorisation : Window
    {
        public Autorisation()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if(txtLogin.Text != string.Empty && txtPassword.Password != string.Empty)
            {
                var user = Mongo.FindCustomer(txtLogin.Text);
                if(user != null && txtPassword.Password == user.Password)
                {
                    CurrentUser.currentUser = user;
                    MainWindow mw = new MainWindow();
                    mw.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                    txtLogin.Text = string.Empty;
                    txtPassword.Password = string.Empty;
                }    
            }
        }
    }
}
