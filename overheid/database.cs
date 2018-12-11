using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;


namespace overheid
{
    class database
    {

       
      public  const string MyConnectionString = "SERVER=localhost;DATABASE=gemeente;UID=root;PASSWORD='';";
        MySqlConnection Connection = new MySqlConnection(MyConnectionString);
        public string usernaam;
        public string wachtwoord;
        public string voornaam;
        public string achternaam;
        public string straatnaam;
        public string huisnmmer;
        public string postcode;
        public string stad;
        public string plaats;
        public string telefoonnummer;
        int roleid;
        int infoid;
        public bool verificatie = false;

        //connection

        //select

        // update

        // delete


        public BindingSource source = new BindingSource();

        public void register(string username, string password, string email, string achternaam, string voornaam, string huisnummer)
        {
            string Username = username;
            string Password = password;
            string Email = email;
            string Voornaam = voornaam;
            string Achternaam = achternaam;
            string Straatnaam = straatnaam;
            string Huisnum = huisnummer;
            string Postcode = postcode;
            string Stad = stad;
            string Plaats = plaats;
            string Telefoonnummer = telefoonnummer;
            int Infoid = infoid;
            int role = 4;
            string hallo = "INSERT INTO user(user_name, user_pass, user`_email, role_id) VALUES (@user_name, _pass, @user_email, role_id)";
            using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
            {
                string query = "INSERT INTO user( user_name, user_pass, user_mail ) VALUES ( @user_name, @user_pass, user_mail)";
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.Add(new MySqlParameter("@user_name", Username));
                command.Parameters.Add(new MySqlParameter("@user_pass", Password));
                command.Parameters.Add(new MySqlParameter("@user_mail", Email));
                command.Parameters.Add(new MySqlParameter("@role_id", role));
                command.Parameters.Add(new MySqlParameter("@info_id", Infoid));
                command.Parameters.Add(new MySqlParameter("@info_voornaam", Voornaam));
                command.Parameters.Add(new MySqlParameter("@info_achternaam", Achternaam));
                command.Parameters.Add(new MySqlParameter("@info_straatnaam", Straatnaam));
                command.Parameters.Add(new MySqlParameter("@info_huisnummer", Huisnum));
                command.Parameters.Add(new MySqlParameter("@info_postcode", Postcode));
                command.Parameters.Add(new MySqlParameter("@info_plaats", Plaats));
                command.ExecuteNonQuery();
                //gebruik inner join om de rest van de gegevens te regristeren dus plaats etc
                conn.Close();

            }

        }

        

        public void LoginUser(string username, string password)
        {
            home_admin home = new home_admin();

            using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
            {
                conn.Open();
                string query = "(SELECT * FROM user WHERE user_name = @user_name AND user_pass = @user_pass) ";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.Add(new MySqlParameter("@user_name", username));
                command.Parameters.Add(new MySqlParameter("@user_pass", password));
                MySqlDataReader login = command.ExecuteReader();
                while (login.Read())
                {
                    usernaam = login.GetString("user_name");
                    wachtwoord = login.GetString("user_pass");
                    int roleid = login.GetInt32("role_id");
                    Console.WriteLine(roleid);

                }
                if (usernaam == username)
                {
                    Console.WriteLine(" de username klopt");
                    if (wachtwoord == password)
                    {
                        Console.WriteLine(" het wachtwoord klopt");

                        verificatie = true;


                    }
                    if (roleid == 1)
                    {
                       
                        home.Show();
                        Console.WriteLine("admin");
                    }
                    if (roleid == 2)
                    {
                        Console.WriteLine("gemeente");
                    }
                    if (roleid == 3)
                    {
                        Console.WriteLine("woonstichting");
                    }
                    if (roleid == 4)
                    {
                        Console.WriteLine("huurder");
                    }
                    else
                    {
                        home.Show();
                    }
                }
                
                else
                {
                    MessageBox.Show("De ingevoerde gegevens kloppen niet");
                }

            }
        }

        public List<User> GetUsers()
        {
            List<User> userlist = new List<User>();
            string sql = "SELECT user.user_id, user.user_name, user.user_pass, user.user_email, user.role_id, user.info_id, info.info_id, info.info_voornaam, info.info_achternaam, info.info_adres, info.info_huisnummer, info.info_postcode, info.info_plaats FROM `user` INNER JOIN info on user.info_id = info.info_id;";
            Connection.Open();

            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                //read through all the data
                while (reader.Read())
                {
                    //create new uitlening
                    User user = new User();

                    //add value to the fields
                    user.InfoID = reader.GetInt32("info_id");
                    user.InfoVoornaam = reader.GetString("info_voornaam");
                    user.InfoAchternaam = reader.GetString("info_achternaam");
                    user.InfoAdres = reader.GetString("info_adres");
                    user.Infohuisnum = reader.GetInt32("info_huisnummer");
                    user.InfoPostcode = reader.GetString("info_postcode");
                    user.InfoPlaats = reader.GetString("info_plaats");
                    user.UserId = reader.GetInt32("user_id");
                    user.UserName = reader.GetString("user_name");
                    user.UserPass = reader.GetString("user_pass");
                    user.Usermail = reader.GetString("user_email");
                    user.RoleID = reader.GetInt32("role_id");

                    // save uitlening to the list
                    userlist.Add(user);

                }
                
            }
            catch
            {
                Console.WriteLine("kan de query niet uitvoeren! LOL");
            }
            Connection.Close();
            return userlist;
        }

       
        public void user()
        {
           
            List<string> user = new List<string>();
             

            Connection.Open();

            string gebruiker = "SELECT * FROM user";
            MySqlCommand cmd = new MySqlCommand(gebruiker, Connection);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {

            }

            Connection.Close();
        }

    }
}
