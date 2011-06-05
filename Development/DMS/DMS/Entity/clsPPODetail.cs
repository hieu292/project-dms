using System;

namespace SCM.ValueObject
{
	/// <summary>
	/// Summary description for clsPPODetail.
	/// </summary>
	public class clsPPODetail
	{
		protected string m_PPOCode;
		protected string m_STDSKU;
		protected decimal m_OriQty;
		protected decimal m_OrdQty;
		protected string m_UOM;

		public string PPOCode
		{
			get{return m_PPOCode;}
			set{m_PPOCode = value;}
		}
		public string STDSKU
		{
			get{return m_STDSKU;}
			set{m_STDSKU = value;}
		}
		public decimal OriQty
		{
			get{return m_OriQty;}
			set{m_OriQty = value;}
		}
		public decimal OrdQty
		{
			get{return m_OrdQty;}
			set{m_OrdQty = value;}
		}
		public string UOM
		{
			get{return m_UOM;}
			set{m_UOM = value;}
		}
		public clsPPODetail(){}
		public clsPPODetail(string PPOCode, string STDSKU, decimal OriQty, decimal OrdQty, string UOM)
		{
			this.m_PPOCode = PPOCode;
			this.m_STDSKU = STDSKU;
			this.m_OriQty = OriQty;
			this.m_OrdQty = OrdQty;
			this.m_UOM = UOM;
		}
	}
}
