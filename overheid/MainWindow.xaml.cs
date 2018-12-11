using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.ComponentModel;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace overheid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        database database = new database();
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTxt.Text;
            string password = passwordTxt.Text;

            database.LoginUser( username, password);
            if (database.verificatie == true ) {
                this.Hide();
                Console.WriteLine("ik ga nu hiden");
            }
            else
            {
                Console.WriteLine("ik ga  het niet done");
            }
            
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            register register = new register();
            register.Show();
            this.Hide();
        }
    }
}
