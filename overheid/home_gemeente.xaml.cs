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
    /// Interaction logic for home_gemeente.xaml
    /// </summary>
    public partial class home_gemeente : Window
    {
        public home_gemeente()
        {
            InitializeComponent();
           
        }
        
        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        List<huurder> GetHuur = new List<huurder>();
        exchange exchange = new exchange();

        private void VernieuwenBtn_Click(object sender, RoutedEventArgs e)
        {
            //datagrid1.ItemsSource();
            if (datagrid1.ItemsSource == null)
            {
                GetHuur = exchange.GetHuur();
                datagrid1.ItemsSource = GetHuur;
                Console.WriteLine("moet nu eigenlijk wat laten zien");
            }
            else
            {
                datagrid1.ItemsSource = null;
                datagrid1.ItemsSource = GetHuur;

                Console.WriteLine("nu niks meer");
            }
        }

        private void ToestaanBtn_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid1.SelectedIndex >= 0)
            {
                TextBlock rowID = datagrid1.Columns[0].GetCellContent(datagrid1.Items[datagrid1.SelectedIndex]) as TextBlock;
                int rowid = Convert.ToInt32(rowID.Text);
                exchange.toegestaan(rowid);
            }
        }
    }
}
