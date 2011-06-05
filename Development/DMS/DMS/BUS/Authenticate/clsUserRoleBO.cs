using System;
using System.Data;
using System.Text;

using SCM.Utils;
using SCM.DataAccessObject;

namespace SCM.BusinessObject
{
	/// <summary>
	/// Summary description for clsUserRoleBO.
	/// </summary>
	/// <remarks>
	/// Author:			NguyenLD. FPTSS.
	/// Created date:	14/02/2011
	/// </remarks>
	public class clsUserRoleBO : clsBaseBO
	{
		private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsUserRoleBO));

		private  clsUserRoleDAO dao = new clsUserRoleDAO();

		public clsUserRoleBO()
		{
		}

		/// <summary>
		/// Get schema of SCM_AUT_USERROLE table
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// Author:			NguyenLD. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable GetSchemaTable()
		{
			return dao.GetSchemaTable();
		}

		/// <summary>
		/// Search data from SCM_AUT_USERROLE table
		/// </summary>
		/// <param name="dt"></param>
		/// <param name="URoleID"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			NguyenLD. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable Search(DataTable dt, string URoleID)
		{
			clsCommon common = new clsCommon();
			string strSql = "SELECT UROLE_ID, ROLE_NAME FROM SCM_AUT_USERROLE ";

			StringBuilder sb = new StringBuilder();
			if(URoleID != null && URoleID.Length > 0)
			{
				sb.Append(string.Format(" UROLE_ID LIKE '{0}' ", common.EncodeKeyword(URoleID)));
			}

			if(sb.Length > 0)
				strSql = strSql + " WHERE " + sb.ToString();

			return dao.GetDataTable(dt, strSql);
		}

        public DataTable CheckIsExistAcount(string URoleID)
        {
            clsCommon common = new clsCommon();
            string strSql = "SELECT * FROM SCM_AUT_USER ";

            StringBuilder sb = new StringBuilder();
            if (URoleID != null && URoleID.Length > 0)
            {
                sb.Append(string.Format(" UROLE_ID LIKE '{0}' ", common.EncodeKeyword(URoleID)));
            }

            if (sb.Length > 0)
                strSql = strSql + " WHERE " + sb.ToString();

            return dao.GetDataTable(strSql);
        }

		/// <summary>
		/// Update all DataRow by DataRowState
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			NguyenLD. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int UpdateAll(DataTable dt)
		{
			return dao.UpdateAll(dt);
		}
	}
}
