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
    /// Interaction logic for home_admin.xaml
    /// </summary>
    public partial class home_admin : Window
    {
        database database = new database();

        List<User> user = new List<User>();
        public home_admin()
        {
            InitializeComponent();
            
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            user = database.GetUsers();
            datagridUser.ItemsSource = user;
        }
    }
}
