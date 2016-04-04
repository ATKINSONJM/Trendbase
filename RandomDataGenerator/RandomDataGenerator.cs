using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDataGenerator
{
    public class RandomDataGenerator
    {
        public static SqlConnection con = new SqlConnection();
        
        static void Main(string[] args)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TrendbaseConnecctionString"].ToString();
        }

        /// <summary>
        /// Method which will genreate data for people buying tickets and will act as a constant stream of data. 
        /// </summary>
        public void GenerateData()
        {
            
        }
    }
}
