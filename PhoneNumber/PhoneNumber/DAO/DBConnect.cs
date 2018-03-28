using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PhoneNumber.DAO
{
    class DBConnect
    {
        private string server, database, uid, password;
        public string connectionString()
        {
            server = "localhost";
            database = "traindb"; // Diganti nama database Anda
            uid = "root";   // Username Anda, default username phpmyadmin adalah root
            password = "toor.,.";   // Password username, default utk username root passwordnya kosong
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            return connectionString;
        }
    }
}
