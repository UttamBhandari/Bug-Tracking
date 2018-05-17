using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Bug_Tracking
{
    class DbConnection
    {
        private string connString = ConfigurationManager.ConnStrings["connectionstr"].ConnString;

        /// <summary>
        /// connects sql query with connection string
        /// </summary>
        /// <returns>SqlConnection</returns>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connString);
        }   
    }
}
