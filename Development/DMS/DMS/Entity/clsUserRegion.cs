using System;

namespace SCM.ValueObject
{
	/// <summary>
	/// Summary description for clsUserRegion.
	/// </summary>
	public class clsUserRegion : clsBaseObject
	{
		protected string m_strUserName = "";
		protected string m_strRegionCode = "";

		public string UserName
		{
			get{return m_strUserName;}
			set{m_strUserName = value;}
		}
		public string RegionCode
		{
			get{return m_strRegionCode;}
			set{m_strRegionCode = value;}
		}
		public clsUserRegion(){}
		public clsUserRegion(string userName, string regionCode)
		{
			this.m_strUserName = userName;
			this.m_strRegionCode = regionCode;
		}
	}
}
