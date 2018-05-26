using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DTO
{
   public class DTO_WriteDataConnect
    {
        private string datasource;
        public string Datasource
        {
            get { return datasource; }
            set { datasource = value; }
        }
        private string database;

        public string Database
        {
            get { return database; }
            set { database = value; }
        }
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public DTO_WriteDataConnect(string getdatasource, string getdatabase, string getusername, string getpassword)
        {
            Datasource = getdatasource;
            Database = getdatabase;
            Username = getusername;
            Password = getpassword;
        }
    }
}
