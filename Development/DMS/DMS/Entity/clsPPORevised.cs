using System;

namespace SCM.ValueObject
{
	/// <summary>
	/// Summary description for clsPPORevised.
	/// </summary>
	public class clsPPORevised : clsBaseObject
	{
		protected string m_PPOCode;
		protected string m_ProCode;
		protected decimal m_OrdQty;
		protected decimal m_AutRevQty;
		protected decimal m_RevQty;
		protected string m_UOM;

		public string PPOCode
		{
			get{return m_PPOCode;}
			set{m_PPOCode = value;}
		}
		public string ProCode
		{
			get{return m_ProCode;}
			set{m_ProCode = value;}
		}
		public decimal OrdQty
		{
			get{return m_OrdQty;}
			set{m_OrdQty = value;}
		}
		public decimal AutRevQty
		{
			get{return m_AutRevQty;}
			set{m_AutRevQty = value;}
		}
		public decimal RevQty
		{
			get{return m_RevQty;}
			set{m_RevQty = value;}
		}
		public string UOM
		{
			get{return m_UOM;}
			set{m_UOM = value;}
		}
		public clsPPORevised(){}
		public clsPPORevised(string PPOCode, string ProCode, decimal OrdQty, decimal AutRevQty, decimal RevQty, string UOM)
		{
			this.m_PPOCode = PPOCode;
			this.m_ProCode = ProCode;
			this.m_OrdQty = OrdQty;
			this.m_AutRevQty = AutRevQty;
			this.m_RevQty = RevQty;
			this.m_UOM = UOM;
		}

	}
}
