using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SCM.Utils;

namespace SCM.Utils
{
    public class DataServices
    {
        /// <summary>
        /// Get connection string from App config
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return clsCommon.GetConnectionString();
        }
        
        public static SqlDataReader ExecuteReader(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteReader(GetConnectionString(), commandType, commandText, commandParameters);
        }
        
        public static DataTable ExecuteDataTable(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteDataset(GetConnectionString(), commandType, commandText, commandParameters).Tables[0];
        }

        public static void  ExecuteNonQuery( CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {    
            SqlHelper.ExecuteNonQuery(GetConnectionString(), commandType, commandText, commandParameters);
        }
        public static void ExecuteNonQuery(SqlTransaction transaction,CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlHelper.ExecuteNonQuery(transaction,GetConnectionString(), commandType, commandText, commandParameters);
        }
        public static int ExecuteStoredProcedure(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            return SqlHelper.ExecuteNonQuery(GetConnectionString(), commandType, commandText, commandParameters);            
        }
        public static object ExecuteScalar(CommandType commandType, string commandText)
        {
            return SqlHelper.ExecuteScalar(GetConnectionString(), commandType, commandText);
        }
        public static void ExecuteNonQuery(CommandType commandType, string commandText)
        {
            SqlHelper.ExecuteNonQuery(GetConnectionString(), commandType, commandText);
        }
    }
}
