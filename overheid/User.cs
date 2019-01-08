using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overheid
{
    class User
    {
        int userId;
        string userName;
        string userPass;
        string userMail;
        int roleID;
        int infoID;
        string infoVoornaam;
        string infoAchternaam;
        string infoAdres;
        int infohuisnum;
        string infoPostcode;
        string infoPlaats;

        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public string UserPass
        {
            get
            {
                return userPass;
            }
            set
            {
                userPass = value;
            }
        }

        public string Usermail
        {
            get
            {
                return userMail;
            }
            set
            {
                userMail = value;
            }
        }

        public int RoleID
        {
            get
            {
                return roleID;
            }
            set
            {
                roleID = value;
            }
        }
        //dit worden echt tering veel fields
        public int InfoID
        {
            get
            {
                return infoID;
            }
            set
            {
                infoID = value;
            }
        }


       





        //dit moet je blijven herhalen voor iedere variabele, ik kijk wel mee yuw ik wou al zeggen ik maak ze even XD
        public string InfoVoornaam
        {
            get
            {
                return infoVoornaam;
            }
            set
            {
                infoVoornaam = value;
            }
        }
        public string InfoAchternaam
        {
            get
            {
                return infoAchternaam;
            }
            set
            {
                infoAchternaam = value;
            }
        }
        public string InfoAdres
        {
            get
            {
                return infoAdres;
            }
            set
            {
                infoAdres = value;
            }
        }
        public int Infohuisnum
        {
            get
            {
                return infohuisnum;
            }
            set
            {
                infohuisnum = value;
            }
        }
        public string InfoPostcode
        {
            get
            {
                return infoPostcode;
            }
            set
            {
                infoPostcode = value;
            }
        }
        public string InfoPlaats
        {
            get
            {
                return infoPlaats;
            }
            set
            {
                infoPlaats = value;
            }
        }

       

        
    }
}
