using System;
using System.Data;
using System.Collections;
using SCM.DataAccessObject;

namespace SCM.BusinessObject
{
	/// <summary>
	/// Summary description for clsAutPolicyBO.
	/// </summary>
	/// <remarks>
	/// Author:			NguyenLD. FPTSS.
	/// Created date:	14/02/2011
	/// </remarks>
	public class clsAutPolicyBO:clsBaseBO
	{
		private clsAutPolicyDAO dao = new clsAutPolicyDAO();
		public clsAutPolicyBO()
		{
		}

		/// <summary>
		/// Get Policy of one user
		/// </summary>
		/// <param name="URoleID"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			NguyenLD. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable GetPolicy(string URoleID)
		{
			return dao.GetPolicy(URoleID);
		}

		/// <summary>
		/// Update all feature of one role by RoleID
		/// </summary>
		/// <param name="URoleID"></param>
		/// <param name="added"></param>
		/// <param name="deleted"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			NguyenLD. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int UpdateAll(string URoleID, ArrayList added, ArrayList deleted)
		{
			return dao.UpdateAll(URoleID, added, deleted);
		}
	}
}
