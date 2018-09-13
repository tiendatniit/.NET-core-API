using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class ConnectionString
    {
        public string _conString { get; set; }

        public ConnectionString(string ConString)
        {
            this._conString = ConString;
        }
        public static SqlConnection Connect(string connection)
        {
            SqlConnection con = new SqlConnection(connection);
            return con;
        }
    }
}
