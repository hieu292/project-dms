using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Web;
using System.Collections;
using SCM.DataAccessObject;
using SCM.BusinessObject;
using SCM.Utils;

namespace SCM.BusinessObject
{
	/// <summary>
	/// Summary description for clsSMSConfigurationBO.
	/// Author: DucND 15-12-2008
	/// </summary>
	public class clsSMSConfigurationBO:clsBaseBO
	{
		private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsSMSConfigurationBO));
		protected clsSMSConfigurationDAO dao = new clsSMSConfigurationDAO();
		public clsSMSConfigurationBO()
		{

		}

		/// <summary>
		/// Return DataTable to form frmSMSConfiguration
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Dinh Duc G3
		/// Modified:	15-Dec-2008
		/// </remarks>
		public DataTable Load()
		{
			return dao.GetSMSParameters();
		}

		/// <summary>
		/// Update Parameter value into database
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Dinh Duc G3
		/// Modified:	15-Dec-2008
		/// </remarks>		
		public bool Update(Hashtable parameter)
		{
			return dao.UpdateSMSParameters(parameter);
		}
	}
}
