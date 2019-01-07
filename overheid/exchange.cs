using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace overheid
{
    class exchange
    {
        public int Userid = Person.userid;
        public int Infoid = Person.infoid;
        public string Adres;
        public int Huisnum;
        public string Plaats;
        public string Postcode;
        public string Inschrijfstatus = "niet gecontroleerd";

        public const string MyConnectionString = "SERVER=localhost;DATABASE=gemeente;UID=root;PASSWORD='';";
        MySqlConnection Connection = new MySqlConnection(MyConnectionString);
        verhuizing verhuis = new verhuizing();
       public void verhuizing(string straat,int huisnum, string postcode, string plaats)
        {
            Adres = straat;
            Huisnum = huisnum;
            Postcode = postcode;
            Plaats = plaats;

            string query = "INSERT INTO inschrijving (`user_id`, `info_id`, `inschrijf_adres`, `inschrijf_huisnummer`, `inschrijf_plaats`, `inschrijf_status`) VALUES( @user_id, @info_id, @inschrijf_adres, @inschrijf_huisnummer, @inschrijf_plaats, @inschrijf_status)";
            using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.Add(new MySqlParameter("@user_id", Userid));
                command.Parameters.Add(new MySqlParameter("@info_id", Infoid));
                command.Parameters.Add(new MySqlParameter("@inschrijf_adres", Adres));
                command.Parameters.Add(new MySqlParameter("@inschrijf_huisnummer", Huisnum));
                command.Parameters.Add(new MySqlParameter("@inschrijf_plaats", Plaats));
                command.Parameters.Add(new MySqlParameter("@inschrijf_status", Inschrijfstatus));
                command.ExecuteNonQuery();
            }

            MessageBox.Show("u heeft u gegevens ingevoerd");
            
        }
    }
}
