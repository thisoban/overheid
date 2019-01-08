using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace overheid
{

    public static class Huur {
        public static string Username;
        public static string Email;
        public static int infoid;
        public static int userid;
        public static int inschrijvingid;
        public static string inschrijvingstatus;

    }

    class huurder
    {
        int Inschrijvingid;

        public int inschrijvingid
        {
            get { return Inschrijvingid; }
            set { Inschrijvingid = value; }
        }

        string Infonaam;

        public string infonaam
        {
            get { return Infonaam; }
            set { Infonaam = value; }
        }

         string Infoachternaam;

        public string infoachternaam
        {
            get { return Infoachternaam; }
            set { Infoachternaam = value; }
        }

         string  Useremail;

        public string  usermail
        {
            get { return Useremail; }
            set { Useremail = value; }
        }

        string Inschrijfadres;

        public string inschrijfadres
        {
            get { return Inschrijfadres; }
            set { Inschrijfadres = value; }
        }

         int Inschrijfhuisnum;

        public int inschrijfhuisnum
        {
            get { return Inschrijfhuisnum; }
            set { Inschrijfhuisnum = value; }
        }


         string Inschrijfplaats;

        public string inschrijfplaats
        {
            get { return Inschrijfplaats; }
            set { Inschrijfplaats = value; }
        }

         string Inschrijfpostcode;

        public string inschrijfpostcode
        {
            get { return Inschrijfpostcode; }
            set { Inschrijfpostcode = value; }
        }

        string Inschrijfstatus;

        public string inschrijfstatus
        {
            get { return Inschrijfstatus; }
            set { Inschrijfstatus = value; }
        }

         string Infoadres;

        public string infoadres
        {
            get { return Infoadres; }
            set { Infoadres = value; }
        }

        int Infohuisnum;

        public int infohuisnum
        {
            get { return Infohuisnum; }
            set { Infohuisnum = value; }
        }

         string Infopostcode;

        public string infopostcode
        {
            get { return Infopostcode; }
            set { Infopostcode = value; }
        }

         string  Infoplaats;

        public string  infoplaats
        {
            get { return Infoplaats; }
            set { Infoplaats = value; }
        }

    }
}
