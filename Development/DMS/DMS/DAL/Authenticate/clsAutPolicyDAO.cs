using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text;

namespace DMS.DataAccessObject
{
	/// <summary>
	/// Summary description for clsAutPolicyDAO.
	/// </summary>
	/// <remarks>
	/// Author:			PhatLT. FPTSS.
	/// Created date:	14/02/2011
	/// </remarks>
	public class clsAutPolicyDAO:clsBaseDAO
	{
		public static string TableName = "GENERAL_AUT_POLICY";
		private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsAutPolicyDAO));

		public clsAutPolicyDAO()
		{
		}

		/// <summary>
		/// Get Policy of one user
		/// </summary>
		/// <param name="URoleID"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable GetPolicy(string URoleID)
		{
			SqlConnection con = Connection;

			SqlCommand cmd = new SqlCommand("sp_GetPolicy", con);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@UROLE_ID", SqlDbType.VarChar, 14, "UROLE_ID").Value = URoleID;

			DataTable dt = new DataTable(TableName);
			return GetDataTable(dt, cmd);
		}

		/// <summary>
		/// Update all feature of one role by RoleID
		/// </summary>
		/// <param name="URoleID"></param>
		/// <param name="added"></param>
		/// <param name="deleted"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int UpdateAll(string URoleID, ArrayList added, ArrayList deleted)
		{
			SqlConnection con = Connection;
			SqlTransaction trans = null;
			SqlCommand cmd = null;

			int count = 0;

			try
			{
				if(con.State != ConnectionState.Open)
					con.Open();

				trans = con.BeginTransaction();

				cmd = new SqlCommand("", con, trans);

				URoleID = EncodeString(URoleID);

				if(deleted.Count > 0)
				{
					StringBuilder sb = new StringBuilder();
					foreach(string id in deleted)
					{
						sb.Append(EncodeString(id) + ", ");
					}
					sb.Remove(sb.Length - 2, 2);
					cmd.Parameters.Clear();
					cmd.CommandText = string.Format("DELETE FROM GENERAL_AUT_POLICY WHERE UROLE_ID = '{0}' AND FEATURE_ID IN ({1})", URoleID, sb.ToString());
					count += cmd.ExecuteNonQuery();
				}

				foreach(string id in added)
				{
					cmd.CommandText = string.Format("INSERT INTO GENERAL_AUT_POLICY(FEATURE_ID, UROLE_ID, LEVEL_ID)VALUES({0}, '{1}', 0)", id, URoleID);
					count += cmd.ExecuteNonQuery();
				}

				trans.Commit();
			}
			catch(SqlException ex)
			{
				log.Error(ex.Message, ex);
				if(trans != null)
					trans.Rollback();
				throw ex;
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
				if(trans != null)
					trans.Rollback();
				throw ex;
			}
			finally
			{
				if(con != null && con.State == ConnectionState.Open)
					con.Close();
			}
			return count;
		}
	}
}
