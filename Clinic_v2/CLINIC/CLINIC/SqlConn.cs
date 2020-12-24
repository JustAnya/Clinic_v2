using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Data.SqlClient;
using CLINIC.Models;
using System.Text;
using System.Threading.Tasks;

namespace CLINIC
{
    class SqlConn
    {
        static public string CurrentConnectionString = ConnectionString.defaultString;
        static public string UserConnectionString = ConnectionString.user;
        public class ConnectionString
        {
            static public string defaultString = "Data Source=DESKTOP-RV3DCL8\\SQLEXPRESS;Initial Catalog=CLINIC;Integrated Security=true;";
            static public string user = "Data Source=DESKTOP-RV3DCL8\\SQLEXPRESS\\SQLEXPRESS;Integrated Security = False; User ID = Anna Mozol; Password=1;ApplicationIntent=ReadWrite;";
            //static public string admin = "Data Source=DESKTOP-FFV5E68\\SQLEXPRESS;Integrated Security=False;User ID=adminln;Password=admin;ApplicationIntent=ReadWrite;";
        }
    }

   
}

