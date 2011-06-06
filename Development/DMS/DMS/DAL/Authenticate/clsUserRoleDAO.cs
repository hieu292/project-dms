using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace DMS.DataAccessObject
{
	/// <summary>
	/// Summary description for clsUserRoleDAO.
	/// </summary>
	/// <remarks>
	/// Author:			PhatLT. FPTSS.
	/// Created date:	14/02/2011
	/// </remarks>
	public class clsUserRoleDAO:clsBaseDAO
	{
		public static string TableName = "GENERAL_AUT_USERROLE";
		private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsUserRoleDAO));

		public clsUserRoleDAO()
		{
		}

		/// <summary>
		/// Get schema of GENERAL_AUT_USERROLE table
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable GetSchemaTable()
		{
			DataTable dt = new DataTable(TableName);
			dt.Columns.Add("UROLE_ID", typeof(string));
			dt.Columns.Add("ROLE_NAME", typeof(string));
			return dt;
		}

		/// <summary>
		/// Get insert cmd of GENERAL_AUT_USERROLE table
		/// </summary>
		/// <param name="con"></param>
		/// <param name="trans"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public SqlCommand GetInsertCommand(SqlConnection con, SqlTransaction trans)
		{
			SqlCommand cmd = new SqlCommand("INSERT INTO GENERAL_AUT_USERROLE(UROLE_ID, ROLE_NAME) VALUES(@UROLE_ID, @ROLE_NAME)", con, trans);
			cmd.Parameters.Add("@UROLE_ID", SqlDbType.VarChar, 14, "UROLE_ID");
			cmd.Parameters.Add("@ROLE_NAME", SqlDbType.VarChar, 255, "ROLE_NAME");
			return cmd;
		}

		/// <summary>
		/// Get update cmd of GENERAL_AUT_USERROLE table
		/// </summary>
		/// <param name="con"></param>
		/// <param name="trans"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public SqlCommand GetUpdateCommand(SqlConnection con, SqlTransaction trans)
		{
			SqlCommand cmd = new SqlCommand("UPDATE GENERAL_AUT_USERROLE SET ROLE_NAME = @ROLE_NAME WHERE UROLE_ID = @UROLE_ID", con, trans);
			cmd.Parameters.Add("@ROLE_NAME", SqlDbType.VarChar, 255, "ROLE_NAME");
			cmd.Parameters.Add("@UROLE_ID", SqlDbType.VarChar, 14, "UROLE_ID");
			return cmd;
		}

		/// <summary>
		/// Get delete cmd of GENERAL_AUT_USERROLE table
		/// </summary>
		/// <param name="con"></param>
		/// <param name="trans"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public SqlCommand GetDeleteCommand(SqlConnection con, SqlTransaction trans)
		{
			SqlCommand cmd = new SqlCommand("DELETE FROM GENERAL_AUT_USERROLE WHERE UROLE_ID = @UROLE_ID", con, trans);
			cmd.Parameters.Add("@UROLE_ID", SqlDbType.VarChar, 14, "UROLE_ID");
			return cmd;
		}

		protected SqlDataAdapter m_da = new SqlDataAdapter();

		public SqlDataAdapter DataAdapter
		{
			get{return m_da;}
			set{m_da = value;}
		}

		/// <summary>
		/// Update all DataRow by DataRowState
		/// </summary>
		/// <param name="dt"></param>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int UpdateAll(DataTable dt)
		{
			SqlConnection con = Connection;
			SqlTransaction trans = null;

			int count = -1;

			try
			{
				if(con.State != ConnectionState.Open)
					con.Open();

				trans = con.BeginTransaction();

				m_da.InsertCommand = GetInsertCommand(con, trans);
				m_da.UpdateCommand = GetUpdateCommand(con, trans);
				m_da.DeleteCommand = GetDeleteCommand(con, trans);

				count = m_da.Update(dt);
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
