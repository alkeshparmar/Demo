using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCCRUDOnlineShoppign.Utils
{
    public class DBOperations
    {
        public int InsertUpdateDelete(string sp,SqlParameter[] spCol)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineShoppingConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if(spCol != null && spCol.Length > 0)
                    {
                        cmd.Parameters.AddRange(spCol);
                    }
                    conn.Open();
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                    return i;
                }
            }
            
        }

        public DataSet FillDataByID(string sp,SqlParameter[] spCol)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineShoppingConnectionString"].ConnectionString))
            {
                using(SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    using(SqlDataAdapter da = new SqlDataAdapter())
                    {
                        DataSet ds = new DataSet();
                        cmd.CommandType = CommandType.StoredProcedure;
                        if(spCol != null && spCol.Length > 0)
                        {
                            cmd.Parameters.AddRange(spCol);
                        }
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
        }

        public DataSet FillData(string sp)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlineShoppingConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        DataSet ds = new DataSet();
                        cmd.CommandType = CommandType.StoredProcedure;                        
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
        }
    }
}