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
   
    public partial class verhuizing : Window
    {
        public verhuizing()
        {
            InitializeComponent();
        }
        home home = new home();
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            home.Show();
            this.Close();
        }

        private void VerhuizingBtn_Click(object sender, RoutedEventArgs e)
        {
            string straat = straatTxt.Text;
            int huisnum = Convert.ToInt32(HuisnumTxt.Text);
            string postcode = PostcodeTxt.Text;
            string plaats = plaatsTxt.Text;

            exchange verhuis = new exchange();
            verhuis.verhuizing(straat, huisnum, postcode, plaats);
            home.Show();
            this.Close();
        }
    }
}
