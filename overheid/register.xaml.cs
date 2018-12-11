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

namespace overheid
{
    /// <summary>
    /// Interaction logic for register.xaml
    /// </summary>
    public partial class register : Window
    {
        public register()
        {
            InitializeComponent();
        }

        private void TerugBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void RegristeerBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTxt.Text;
            string password = password1TXT.Text;
            string password2 = password2TXT.Text;
            string email = emailTXT.Text;
            string voornaam = voornaamTXT.Text;
            string achternaam = achternaamTXT.Text;
            string adres = adresTXT.Text;
            int huisnummer = Convert.ToInt32(huisnummerTXT.Text);
            string postcode = postcodeTXT.Text;
            string plaats = plaatsTXT.Text;

        }
    }
}
