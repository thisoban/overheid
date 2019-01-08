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
     
       public void verhuizing(string straat,int huisnum, string postcode, string plaats)
        {
            Adres = straat;
            Huisnum = huisnum;
            Postcode = postcode;
            Plaats = plaats;

            string query = "INSERT INTO inschrijving (`user_id`, `info_id`, `inschrijf_adres`, `inschrijf_huisnummer`,`inschrijf_postcode`, `inschrijf_plaats`, `inschrijf_status`) VALUES( @user_id, @info_id, @inschrijf_adres, @inschrijf_huisnummer, @inschrijf_postcode, @inschrijf_plaats, @inschrijf_status)";
            using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.Add(new MySqlParameter("@user_id", Userid));
                command.Parameters.Add(new MySqlParameter("@info_id", Infoid));
                command.Parameters.Add(new MySqlParameter("@inschrijf_adres", Adres));
                command.Parameters.Add(new MySqlParameter("@inschrijf_huisnummer", Huisnum));
                command.Parameters.Add(new MySqlParameter("@inschrijf_postcode", Postcode));
                command.Parameters.Add(new MySqlParameter("@inschrijf_plaats", Plaats));
                command.Parameters.Add(new MySqlParameter("@inschrijf_status", Inschrijfstatus));
                command.ExecuteNonQuery();
            }

            MessageBox.Show("u heeft u gegevens ingevoerd");
            
        }

        public List<huurder> GetHuur()
        {
            List<huurder> huurlist = new List<huurder>();

           
               
            string sql = "SELECT user.user_id, user.user_email, user.info_id, info.info_id, info.info_voornaam, info.info_achternaam, info.info_adres, info.info_huisnummer, info.info_postcode, info.info_plaats, inschrijving.user_id, inschrijving.inschrijf_id, inschrijving.inschrijf_adres, inschrijving.inschrijf_huisnummer, inschrijving.inschrijf_postcode, inschrijving.inschrijf_plaats, inschrijving.inschrijf_status FROM user inner join inschrijving on user.user_id = inschrijving.user_id inner join info ON user.info_id = info.info_id";
            Connection.Open();

            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                //read through all the data
                while (reader.Read())
                {
                    //create new uitlening
                    huurder huur = new huurder();

                    //add value to the fields
                   // huur.userid = reader.GetInt32("user_id");
                    huur.usermail = reader.GetString("user_email");
                   // huur.infoid = reader.GetInt32("info_id");
                    huur.infonaam = reader.GetString("info_voornaam");
                    huur.infoachternaam = reader.GetString("info_achternaam");
                    huur.inschrijvingid = reader.GetInt32("inschrijf_id");
                    huur.infoadres = reader.GetString("info_adres");
                    huur.infohuisnum = reader.GetInt32("info_huisnummer");
                    huur.infopostcode = reader.GetString("info_postcode");
                    huur.infoplaats = reader.GetString("info_plaats");
                    huur.inschrijfadres = reader.GetString("inschrijf_adres");
                    huur.inschrijfhuisnum = reader.GetInt32("inschrijf_huisnummer");
                    huur.inschrijfpostcode = reader.GetString("inschrijf_postcode");
                    huur.inschrijfplaats = reader.GetString("inschrijf_plaats");
                    huur.inschrijfstatus = reader.GetString("inschrijf_status");
                    // save uitlening to the list
                    huurlist.Add(huur);

                }

            }
            catch
            {
                Console.WriteLine("kan de query niet uitvoeren! LOL");
            }
            Connection.Close();
            return huurlist;
        }
        public void toegestaan(int Rowid)
        {
            string confirm = "toegestaangemeente";
            int rowid = Rowid;

            using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
            {
                string query = "UPDATE `inschrijving` SET `inschrijf_status`= @inschrijf_status WHERE inschrijf_id = @inschrijf_id";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("@inschrijf_id", rowid));
                cmd.Parameters.Add(new MySqlParameter("@inschrijf_status", confirm));
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("vernieuw de pagina");
            }
        }

        string query = "SELECT * FROM `inschrijving`  GROUP BY inschrijf_id DESC ";

    }
}
