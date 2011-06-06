using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using log4net;

using DMS.DataAccessObject;
using DMS.Utils;

namespace DMS.BusinessObject
{
	/// <summary>
	/// Summary description for clsAutUserBO.
	/// </summary>
	/// <remarks>
	/// Author:			PhatLT. FPTSS.
	/// Created date:	14/02/2011
	/// </remarks>
	public class clsAutUserBO
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(clsAutUserBO));
		private clsAutUserDAO dao = new clsAutUserDAO();

		private static DataTable m_dtAuthority;

		public clsAutUserBO(){}

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
			return dao.GetSchemaTable();
		}

		/// <summary>
		/// Search data from 
		/// </summary>
		/// <param name="dt"></param>
		/// <param name="userName"></param>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="email"></param>
		/// <param name="roleID"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable Search(DataTable dt, string userName, string firstName, string lastName, string email, string roleID, string status)
		{
			clsCommon common = new clsCommon();
			string strSql = "SELECT USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, ADDRESS, PHONE, START_DATE, END_DATE, PWD_CHG_DATE, STATUS, UROLE_ID, DESCRIPTION FROM GENERAL_AUT_USER";
			StringBuilder sb = new StringBuilder();

			if(userName != null && userName.Length > 0)
			{
				sb.Append(string.Format(" AND USERNAME LIKE '{0}' ", common.EncodeKeyword(userName)));
			}

			if(roleID != null && roleID.Length > 0)
			{
				sb.Append(string.Format(" AND UROLE_ID = '{0}' ", common.EncodeString(roleID)));
			}

			if(status != null && status.Length > 0)
			{
				sb.Append(string.Format(" AND STATUS = '{0}' ", common.EncodeString(status)));
			}

			if(firstName != null && firstName.Length > 0)
			{
				sb.Append(string.Format(" AND FIRSTNAME LIKE '{0}' ", common.EncodeKeyword(firstName)));
			}

			if(lastName != null && lastName.Length > 0)
			{
				sb.Append(string.Format(" AND LASTNAME LIKE '{0}' ", common.EncodeKeyword(lastName)));
			}

			if(email != null && email.Length > 0)
			{
				sb.Append(string.Format(" AND EMAIL LIKE '{0}' ", common.EncodeKeyword(email)));
			}

			if(sb.Length > 0)
				strSql = strSql + " WHERE " + sb.ToString(4, sb.Length - 4);

			return dao.GetDataTable(dt, strSql);
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
			return dao.LoadAll();
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
			return dao.Exist(userName);
		}
		/// <summary>
		/// Get one user from GENERAL_AUT_USER table by username
		/// </summary>
		/// <param name="username"></param>
		/// <returns></returns>
		public DataTable GetOne(string username)
		{
			return dao.GetOne(username);
		}

		/// <summary>
		/// Load all Status
		/// </summary>
		/// <returns></returns>
		public DataTable LoadAllStatus()
		{
			return dao.LoadAllStatus();
		}

		/// <summary>
		/// Get Region from GENERAL_AUT_USER_REGION table by UserName
		/// </summary>
		/// <param name="UserName"></param>
		/// <returns></returns>
		public ArrayList GetRegion(string UserName)
		{
			return dao.GetRegion(UserName);
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
			return dao.SetRights(userName, regions, strategicRegions);
		}
		/// <summary>
		/// Get StragicRegion from GENERAL_AUT_USER_STRATEGIC_REGION table by UserName
		/// </summary>
		/// <param name="UserName"></param>
		/// <returns></returns>
		public ArrayList GetStrategicRegion(string UserName)
		{
			return dao.GetStrategicRegion(UserName);
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
			return dao.LoadAllUserRole();
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
			return dao.Insert(row);
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
			return dao.Update(row);
		}

		/// <summary>
		/// Get DataTable by cmdText
		/// </summary>
		/// <param name="cmdText"></param>
		/// <returns>return DataTable</returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable GetCommonMenu()
		{
			string strSql = "SELECT FORM_ID, FORM_NAME, MENU_NAME, MENU_LEVEL, MENU_PID, MENU_ZORDER, TOOLBAR_BUTTON_INDEX, TOOLBAR_BUTTON_NAME, TOOLBAR_NAME, DESCRIPTION, ICON_NAME FROM GENERAL_AUT_FORM WHERE COMMON_MENU = '1'";
			return dao.GetDataTable(strSql);
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
			return dao.Delete(username);
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
			return dao.ChangePassword(username, oldPassword, newPassword);
		}

		/// <summary>
		/// Login
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int Login(string username, string password)
		{
			int intResult;
			clsAutUserDAO login;
			int intExpiredDays;

			try
			{
				login = new clsAutUserDAO();
                //intExpiredDays = int.Parse(dao.GetParameterValue(clsConstants.EXPIRED_DAYS)); ;//Convert.ToInt32(ConfigurationManager.AppSettings["ExpiredDays"]);

                DataTable dt = login.Login(username, password, 90, out intResult);
				if(intResult == clsConstants.LOGIN_SUCCESS)
				{
					m_dtAuthority = dt;
				}
				return intResult;
			}
			catch(Exception ex)
			{
				log.Error(ex.ToString());
				throw new Exception("clsAutUserBO.LogIn error");
			}
		}

		/// <summary>
		/// Get authority. Return all feature of this user.
		/// </summary>
		/// <returns>Return all feature of this user</returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable GetAuthority()
		{
			return m_dtAuthority;
		}

		/// <summary>
		/// Clear authority
		/// </summary>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public void ClearAuthority()
		{
			if(m_dtAuthority != null)
			{
				m_dtAuthority.Clear();
			}
		}
		
		/// <summary>
		/// Clear authority
		/// </summary>
		/// <remarks>
		/// Author:			Nguyen Quy Vinh Loc. FPTSS.
		/// Created date:	9/04/2008
		/// </remarks>
		public int ChangeCustCode(string oldcustcode, string newcustcode)
		{
			int intResult;
			clsAutUserDAO changeCC;
			try
			{
				changeCC = new clsAutUserDAO();
				DataTable dt = changeCC.ChangeCustCode(oldcustcode, newcustcode, out intResult);
		
				return intResult;
			}
			catch(Exception ex)
			{
				log.Error(ex.ToString());
				throw new Exception("clsAutUserBO.ChangeCustCode error");
			}
		}

	}
}
