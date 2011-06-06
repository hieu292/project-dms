using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using log4net;

using DMS.Utils;

namespace DMS.DataAccessObject
{
	/// <summary>
	/// Summary description for clsAutUserDAO.
	/// </summary>
	/// <remarks>
	/// Author:			PhatLT. FPTSS.
	/// Created date:	14/02/2011
	/// </remarks>
	public class clsAutUserDAO : clsBaseDAO
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(clsAutUserDAO));

		private static string TableName = "GENERAL_AUT_USER";

		private static string m_strConn = clsCommon.GetConnectionString();

		public clsAutUserDAO(){}

		/// <summary>
		/// Get schema of GENERAL_AUT_USER table
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable GetSchemaTable()
		{
			DataTable dt = new DataTable(TableName);
			dt.Columns.Add("USERNAME", typeof(string)).DefaultValue = "";
			dt.Columns.Add("PASSWORD", typeof(string)).DefaultValue = "";
			dt.Columns.Add("FIRSTNAME", typeof(string)).DefaultValue = "";
			dt.Columns.Add("LASTNAME", typeof(string)).DefaultValue = "";
			dt.Columns.Add("EMAIL", typeof(string)).DefaultValue = "";
			dt.Columns.Add("ADDRESS", typeof(string)).DefaultValue = "";
			dt.Columns.Add("PHONE", typeof(string)).DefaultValue = "";
			dt.Columns.Add("START_DATE", typeof(DateTime)).DefaultValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			dt.Columns.Add("END_DATE", typeof(DateTime)).DefaultValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			dt.Columns.Add("PWD_CHG_DATE", typeof(string));
			dt.Columns.Add("STATUS", typeof(string));//.DefaultValue = "";
			dt.Columns.Add("UROLE_ID", typeof(string));//.DefaultValue = "";
			dt.Columns.Add("DESCRIPTION", typeof(string)).DefaultValue = "";

			return dt;
		}

		/// <summary>
		/// Get Region from GENERAL_AUT_USER_REGION table by UserName
		/// </summary>
		/// <param name="UserName"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public ArrayList GetRegion(string UserName)
		{
			ArrayList arrs = new ArrayList();
			SqlConnection con = Connection;
			SqlDataReader reader = null;
			SqlCommand cmd = null;

			try
			{
				cmd = new SqlCommand("SELECT REGION_CODE FROM GENERAL_AUT_USER_REGION WHERE USERNAME = @USERNAME AND NOT (REGION_CODE IS null)", con);
				cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar, 255).Value = UserName;

				if(con.State != ConnectionState.Open)
					con.Open();

				reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				while(reader.Read())
				{
					arrs.Add(reader[0]);
				}

				reader.Close();
				return arrs;
			}
			catch(SqlException ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
			finally
			{
				if(con != null && con.State == ConnectionState.Open)
					con.Close();
			}
		}

		/// <summary>
		/// Get StragicRegion from GENERAL_AUT_USER_STRATEGIC_REGION table by UserName
		/// </summary>
		/// <param name="UserName"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public ArrayList GetStrategicRegion(string UserName)
		{
			ArrayList arrs = new ArrayList();
			SqlConnection con = Connection;
			SqlDataReader reader = null;
			SqlCommand cmd = null;

			try
			{
				cmd = new SqlCommand("SELECT STRATEGIC_REGION_CODE FROM GENERAL_AUT_USER_STRATEGIC_REGION WHERE USERNAME = @USERNAME AND NOT (STRATEGIC_REGION_CODE IS null)", con);
				cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar, 255).Value = UserName;

				if(con.State != ConnectionState.Open)
					con.Open();

				reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				while(reader.Read())
				{
					arrs.Add(reader[0]);
				}

				reader.Close();
				return arrs;
			}
			catch(SqlException ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
			finally
			{
				if(con != null && con.State == ConnectionState.Open)
					con.Close();
			}
		}

		/// <summary>
		/// Check whether this user name exists
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public bool Exist(string userName)
		{
			bool exist = false;
			if(userName == null)
				return exist;

			SqlConnection con = Connection;
			SqlCommand cmd = null;

			try
			{
				cmd = new SqlCommand("SELECT COUNT(*) FROM GENERAL_AUT_USER WHERE USERNAME = @USERNAME", con);
				cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = userName;

				if(con.State != ConnectionState.Open)
					con.Open();

				if((int)cmd.ExecuteScalar() > 0)
					exist = true;

			}
			catch(SqlException ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
			finally
			{
				if(con != null && con.State == ConnectionState.Open)
					con.Close();
			}
			return exist;
		}
		/// <summary>
		/// Set Rights for one user on region and strategic region
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="regions"></param>
		/// <param name="strategicRegions"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int SetRights(string userName, ArrayList regions, ArrayList strategicRegions)
		{
			SqlConnection con = Connection;
			SqlTransaction trans = null;
			SqlCommand cmd = null;

			clsCryptography crypto = new clsCryptography();
			int count = 0;

			try
			{
				if(con.State != ConnectionState.Open)
					con.Open();

				trans = con.BeginTransaction();

				cmd = new SqlCommand("", con, trans);

				//DELETE FROM GENERAL_AUT_USER_REGION WHERE USERNAME = @USERNAME
				cmd.Parameters.Clear();
				cmd.CommandText = "DELETE FROM GENERAL_AUT_USER_REGION WHERE USERNAME = @USERNAME";
				cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar, 20).Value = userName;

				cmd.Parameters.Clear();
				cmd.CommandText = "DELETE FROM GENERAL_AUT_USER_REGION WHERE USERNAME = @USERNAME";
				cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar, 20).Value = userName;
				cmd.ExecuteNonQuery();

				cmd.Parameters.Clear();
				cmd.CommandText = "DELETE FROM GENERAL_AUT_USER_STRATEGIC_REGION WHERE USERNAME = @USERNAME";
				cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar, 20).Value = userName;
				cmd.ExecuteNonQuery();

				cmd.Parameters.Clear();
				cmd.CommandText = "INSERT INTO GENERAL_AUT_USER_REGION(USERNAME, REGION_CODE) VALUES (@USERNAME, @REGION_CODE)";
				cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar, 20).Value = userName;
				cmd.Parameters.Add("@REGION_CODE", SqlDbType.VarChar, 14);
				foreach(string regionCode in regions)
				{
					cmd.Parameters["@REGION_CODE"].Value = regionCode;
					count += cmd.ExecuteNonQuery();
				}
				

				cmd.Parameters.Clear();
				cmd.CommandText = "INSERT INTO GENERAL_AUT_USER_STRATEGIC_REGION(USERNAME, STRATEGIC_REGION_CODE) VALUES (@USERNAME, @STRATEGIC_REGION_CODE)";
				cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar, 20).Value = userName;
				cmd.Parameters.Add("@STRATEGIC_REGION_CODE", SqlDbType.VarChar, 14);
				foreach(string strategicRegionCode in strategicRegions)
				{
					cmd.Parameters["@STRATEGIC_REGION_CODE"].Value = strategicRegionCode;
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
		/// <summary>
		/// Load all user from GENERAL_AUT_USER table
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable LoadAll()
		{
			SqlConnection con = Connection;
			DataTable dt = null;

			try
			{
				dt = new DataTable(TableName);

				SqlCommand cmd = new SqlCommand("SELECT USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, ADDRESS, PHONE, START_DATE, END_DATE, PWD_CHG_DATE, STATUS, UROLE_ID, DESCRIPTION FROM GENERAL_AUT_USER", con);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
				return dt;
			}
			catch(SqlException ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
		}
		/// <summary>
		/// Get one user from GENERAL_AUT_USER table by username
		/// </summary>
		/// <param name="username"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable GetOne(string username)
		{
			SqlConnection con = Connection;
			DataTable dt = null;

			try
			{
				dt = new DataTable(TableName);

				SqlCommand cmd = new SqlCommand("SELECT USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, ADDRESS, PHONE, START_DATE, END_DATE, PWD_CHG_DATE, STATUS, UROLE_ID, DESCRIPTION, PASSWORD AS OLDPASSWORD FROM GENERAL_AUT_USER WHERE USERNAME = @USERNAME", con);
				cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = username;

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
				return dt;
			}
			catch(SqlException ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
		}

		
		/// <summary>
		/// Load all Status.
		/// AC Active.
		/// IN Inactive.
		/// LI Limit.
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable LoadAllStatus()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("Value", typeof(string));
			dt.Columns.Add("Name", typeof(string));

			DataRow row = dt.NewRow();
			row.ItemArray = new object[]{"AC", "Active"};
			dt.Rows.Add(row);

			row = dt.NewRow();
			row.ItemArray = new object[]{"IN", "Inactive"};
			dt.Rows.Add(row);

			row = dt.NewRow();
			row.ItemArray = new object[]{"LI", "Limit"};
			dt.Rows.Add(row);

			return dt;
		}

		/// <summary>
		/// Load All UserRole from GENERAL_AUT_USERROLE table
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable LoadAllUserRole()
		{
			SqlConnection con = Connection;
			DataTable dt = null;

			try
			{
				dt = new DataTable(TableName);
				SqlCommand cmd = new SqlCommand("SELECT UROLE_ID, ROLE_NAME FROM GENERAL_AUT_USERROLE", con);
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
				return dt;
			}
			catch(SqlException ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
		}
		/// <summary>
		/// Changed password by username, oldPassword, newPassword
		/// </summary>
		/// <param name="username"></param>
		/// <param name="oldPassword"></param>
		/// <param name="newPassword"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int ChangePassword(string username, string oldPassword, string newPassword)
		{
			SqlConnection con = Connection;
			SqlTransaction trans = null;
			SqlCommand cmd = null;

			clsCryptography crypto = new clsCryptography();

			int count = 0;

			try
			{
				if(con.State != ConnectionState.Open)
					con.Open();

				trans = con.BeginTransaction();

				cmd = new SqlCommand("UPDATE GENERAL_AUT_USER SET PASSWORD = @PASSWORD, PWD_CHG_DATE = getdate() WHERE USERNAME = @USERNAME AND PASSWORD = @ORIGINAL_PASSWORD", con, trans);
				cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar, 20).Value = username;
				cmd.Parameters.Add("@ORIGINAL_PASSWORD", SqlDbType.VarChar, 255).Value = crypto.Encode(oldPassword);
				cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar, 255).Value = crypto.Encode(newPassword);

				count = cmd.ExecuteNonQuery();

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

		/// <summary>
		/// Insert one row into GENERAL_AUT_USER table
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int Insert(DataRow row)
		{
			SqlConnection con = Connection;
			SqlTransaction trans = null;
			SqlCommand cmd = null;

			clsCryptography crypto = new clsCryptography();
			int count = 0;

			try
			{
				if(con.State != ConnectionState.Open)
					con.Open();

				trans = con.BeginTransaction();

				cmd = new SqlCommand("INSERT INTO GENERAL_AUT_USER(USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, ADDRESS, PHONE, START_DATE, END_DATE, PWD_CHG_DATE, STATUS, UROLE_ID, DESCRIPTION) VALUES(@USERNAME, @PASSWORD, @FIRSTNAME, @LASTNAME, @EMAIL, @ADDRESS, @PHONE, @START_DATE, @END_DATE, getdate(), @STATUS, @UROLE_ID, @DESCRIPTION)", con, trans);
				cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = row["USERNAME"];
				cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = crypto.Encode(row["PASSWORD"].ToString());
				cmd.Parameters.Add("@FIRSTNAME", SqlDbType.NVarChar).Value = row["FIRSTNAME"];
				cmd.Parameters.Add("@LASTNAME", SqlDbType.NVarChar).Value = row["LASTNAME"];
				cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = row["EMAIL"];
				cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar).Value = row["ADDRESS"];
				cmd.Parameters.Add("@PHONE", SqlDbType.VarChar).Value = row["PHONE"];
				cmd.Parameters.Add("@START_DATE", SqlDbType.DateTime).Value = row["START_DATE"];
				cmd.Parameters.Add("@END_DATE", SqlDbType.DateTime).Value = row["END_DATE"];
				//cmd.Parameters.Add("@PWD_CHG_DATE", SqlDbType.DateTime).Value = row["PWD_CHG_DATE"];
				cmd.Parameters.Add("@STATUS", SqlDbType.Char).Value = row["STATUS"];
				cmd.Parameters.Add("@UROLE_ID", SqlDbType.VarChar).Value = row["UROLE_ID"];
				cmd.Parameters.Add("@DESCRIPTION", SqlDbType.NVarChar).Value = row["DESCRIPTION"];

				count = cmd.ExecuteNonQuery();

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

		/// <summary>
		/// Update one row of GENERAL_AUT_USER by USERNAME
		/// </summary>
		/// <param name="row"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int Update(DataRow row)
		{
			SqlConnection con = Connection;
			SqlTransaction trans = null;
			SqlCommand cmd = null;

			clsCryptography crypto = new clsCryptography();
			int count = 0;

			try
			{
				string newPassword = row["PASSWORD"].ToString();

				if(con.State != ConnectionState.Open)
					con.Open();

				trans = con.BeginTransaction();
				string strPWDChangeDate = "";
				if(!row["PASSWORD"].Equals(row["OLDPASSWORD"]))
					strPWDChangeDate = " , PWD_CHG_DATE = getdate() ";
				string cmdText = string.Format("UPDATE GENERAL_AUT_USER SET PASSWORD = @PASSWORD, FIRSTNAME = @FIRSTNAME, LASTNAME = @LASTNAME, EMAIL = @EMAIL, ADDRESS = @ADDRESS, PHONE = @PHONE, START_DATE = @START_DATE, END_DATE = @END_DATE, STATUS = @STATUS, UROLE_ID = @UROLE_ID, DESCRIPTION = @DESCRIPTION {0} WHERE USERNAME = @USERNAME", strPWDChangeDate);
				cmd = new SqlCommand(cmdText, con, trans);
				cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = row["USERNAME"];
				cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = crypto.Encode(newPassword);
				cmd.Parameters.Add("@FIRSTNAME", SqlDbType.NVarChar).Value = row["FIRSTNAME"];
				cmd.Parameters.Add("@LASTNAME", SqlDbType.NVarChar).Value = row["LASTNAME"];
				cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = row["EMAIL"];
				cmd.Parameters.Add("@ADDRESS", SqlDbType.NVarChar).Value = row["ADDRESS"];
				cmd.Parameters.Add("@PHONE", SqlDbType.VarChar).Value = row["PHONE"];
				cmd.Parameters.Add("@START_DATE", SqlDbType.DateTime).Value = row["START_DATE"];
				cmd.Parameters.Add("@END_DATE", SqlDbType.DateTime).Value = row["END_DATE"];
				cmd.Parameters.Add("@STATUS", SqlDbType.Char).Value = row["STATUS"];
				cmd.Parameters.Add("@UROLE_ID", SqlDbType.VarChar).Value = row["UROLE_ID"];
				cmd.Parameters.Add("@DESCRIPTION", SqlDbType.NVarChar).Value = row["DESCRIPTION"];

				count = cmd.ExecuteNonQuery();

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

		/// <summary>
		/// Delete one row of GENERAL_AUT_USER by USERNAME
		/// </summary>
		/// <param name="username"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int Delete(string username)
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

				cmd = new SqlCommand("DELETE FROM GENERAL_AUT_USER WHERE USERNAME = @USERNAME", con, trans);
				cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = username;

				count = cmd.ExecuteNonQuery();

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

		/// <summary>
		/// Login
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="expiredDays"></param>
		/// <param name="result"></param>
		/// <returns>Return all feature of this user</returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable Login(string username, string password, int expiredDays, out int result)
		{
			clsCryptography crypto = new clsCryptography();

			SqlConnection con = Connection;
			SqlCommand cmd = null;
			DataTable dt = null;

			try
			{
				cmd = new SqlCommand("sp_CheckValidLogin", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@i_sUsername", SqlDbType.VarChar, 20).Value = username;
				cmd.Parameters.Add("@i_sPassword", SqlDbType.VarChar, 20).Value = crypto.Encode(password);
				cmd.Parameters.Add("@i_nPwdExpired", SqlDbType.Int, 4).Value = expiredDays;
				cmd.Parameters.Add("@o_nResult", SqlDbType.Int, 4);
				cmd.Parameters["@o_nResult"].Direction = ParameterDirection.Output;

				cmd.CommandTimeout = 3600;				

				dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);

				result = Convert.ToInt32(cmd.Parameters["@o_nResult"].Value);

				return dt;
			}
			catch(Exception ex)
			{
				log.Error(ex.ToString());
				throw new Exception("clsAutUserDAO.LogIn error");
			}
			
		}



		/// <summary>
		/// Clear authority
		/// </summary>
		/// <remarks>
		/// Author:			Nguyen Quy Vinh Loc. FPTSS.
		/// Created date:	9/04/2008
		/// </remarks>
		public DataTable ChangeCustCode(string oldcustcode, string newcustcode, out int result)
		{
			SqlConnection con = Connection;
			SqlCommand cmd = null;
			DataTable dt = null;

			try
			{
				if(con.State != ConnectionState.Open)
					con.Open();

				cmd = new SqlCommand("sp_ChangeCustCode", con);
				cmd.CommandTimeout = 3600;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@oldCustCode", SqlDbType.VarChar, 14).Value = oldcustcode;
				cmd.Parameters.Add("@newCustCode", SqlDbType.VarChar, 14).Value = newcustcode;
				cmd.Parameters.Add("@return", SqlDbType.Int, 4);
				cmd.Parameters["@return"].Direction = ParameterDirection.Output;
									
				dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);

				result = Convert.ToInt32(cmd.Parameters["@return"].Value);

				return dt;
			}
			catch(Exception ex)
			{
				log.Error(ex.ToString());
				throw new Exception("clsAutUserDAO.ChangeCustCode error");
			}
			finally
			{
				if(con != null && con.State == ConnectionState.Open)
					con.Close();
			}
		}
	}
}
