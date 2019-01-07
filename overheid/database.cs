using System;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;


namespace overheid
{
    class database
    {
        public  const string MyConnectionString = "SERVER=localhost;DATABASE=gemeente;UID=root;PASSWORD='';";
        MySqlConnection Connection = new MySqlConnection(MyConnectionString);
        public int userid;
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
        public int roleid;
        public int Infoid;
        public bool verificatie = false;

        //connection

        //select

        // update

        // delete

        
       

        public void register(string username, string password, string email,  string voornaam, string achternaam,string straatnaam,  int huisnummer, string postcode , string plaats)
        {
            string Username = username;
            string Password = password;
            string Email = email;
            string Voornaam = voornaam;
            string Achternaam = achternaam;
            string Straatnaam = straatnaam;
            int Huisnum = huisnummer;
            string Postcode = postcode;
            string Plaats = plaats;
            string Telefoonnummer = telefoonnummer;
     
            int role = 4;
          
            using (MySqlConnection conn = new MySqlConnection(MyConnectionString))
            {

                string query = "INSERT INTO `info` (`info_voornaam`,  `info_achternaam`, `info_adres`, `info_huisnummer`, `info_postcode`, `info_plaats`) VALUES ( @info_voornaam, @info_achternaam, @info_straatnaam, @info_huisnummer, @info_postcode, @info_plaats )";
                string query2 = "INSERT INTO `user`( `user_name`, `user_pass`, `user_email`, `role_id`, `info_id` ) VALUES ( @user_name, @user_pass, @user_email, @role_id , @info_id)";
                string query3 = "SELECT info_id FROM info WHERE info_id = (SELECT MAX(info_id) FROM info)";       
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.Add(new MySqlParameter("@info_voornaam", Voornaam));
                cmd.Parameters.Add(new MySqlParameter("@info_achternaam", Achternaam));
                cmd.Parameters.Add(new MySqlParameter("@info_straatnaam", Straatnaam));
                cmd.Parameters.Add(new MySqlParameter("@info_huisnummer", Huisnum));
                cmd.Parameters.Add(new MySqlParameter("@info_postcode", Postcode));
                cmd.Parameters.Add(new MySqlParameter("@info_plaats", Plaats));
                cmd.ExecuteNonQuery();
                MySqlCommand op = new MySqlCommand(query3, conn);
                MySqlDataReader info = op.ExecuteReader();
                while (info.Read()){
                    Infoid = info.GetInt32("info_id");
                    Console.WriteLine(Infoid);
                   
                }
                info.Close();

                if (Infoid == Infoid){
                    MySqlCommand command = new MySqlCommand(query2, conn);
                    command.Parameters.Add(new MySqlParameter("@user_name", Username));
                    command.Parameters.Add(new MySqlParameter("@user_pass", Password));
                    command.Parameters.Add(new MySqlParameter("@user_email", Email));
                    command.Parameters.Add(new MySqlParameter("@role_id", role));
                    command.Parameters.Add(new MySqlParameter("@info_id", Infoid));

                    command.ExecuteNonQuery();
                    conn.Close();
                }
                conn.Close();
            }


        }

        

        public void LoginUser(string username, string password)
        {
            home_admin admin = new home_admin();
            home gebruiker = new home();
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
                    userid = login.GetInt32("user_id");
                    roleid = login.GetInt32("role_id");
                    Infoid = login.GetInt32("info_id");
                    Person.userid = userid;
                    Person.infoid = Infoid;  
                }
                if (usernaam == username)
                {
                    Console.WriteLine(" de username klopt");
                    if (wachtwoord == password)
                    {
                        Console.WriteLine(" het wachtwoord klopt");
                    }     
                }
                 else
                {
                    MessageBox.Show("De ingevoerde gegevens kloppen niet");
                }
                if (roleid == 1)
                {
                    admin.Show();
                    Console.WriteLine("admin");
                    verificatie = true;
                }
                if (roleid == 2)
                {

                    Console.WriteLine("gemeente");
                    verificatie = true;
                }
                if (roleid == 3)
                {
                    Console.WriteLine("woonstichting");
                    verificatie = true;
                }
                if (roleid == 4)
                {
                    gebruiker.Show();
                    Console.WriteLine("huurder");
                    verificatie = true;
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
