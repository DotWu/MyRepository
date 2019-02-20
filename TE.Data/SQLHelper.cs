using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TE.Data
{
    public class SQLHelper
    {
        //Data Source = 123.207.1.223,55972; Initial Catalog = kongheydb; User ID = konghey; Password=konghey518
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();


        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(sql);
            SqlCommand comm = new SqlCommand(connString, conn);
        
            try
            {
                conn.Open();
                return comm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
