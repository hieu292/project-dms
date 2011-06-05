using System;

namespace SCM.ValueObject
{
	/// <summary>
	/// Summary description for clsPromotionCustWeek.
	/// </summary>
	public class clsPromotionCustWeek : clsBaseObject
	{
		protected string m_DealID = "";
		protected string m_CustCode = "";
		protected decimal m_WeekNo = 0;
		protected decimal m_YearNo = 0;
		protected decimal m_Quantity = 0;

		public string DealID
		{
			get{return m_DealID;}
			set{m_DealID = value;}
		}
		public string CustCode
		{
			get{return m_CustCode;}
			set{m_CustCode = value;}
		}
		public decimal WeekNo
		{
			get{return m_WeekNo;}
			set{m_WeekNo = value;}
		}
		public decimal YearNo
		{
			get{return m_YearNo;}
			set{m_YearNo = value;}
		}
		public decimal Quantity
		{
			get{return m_Quantity;}
			set{m_Quantity = value;}
		}
		public clsPromotionCustWeek(){}
		public clsPromotionCustWeek(string DealID, string CustCode, decimal WeekNo, decimal YearNo, decimal Quantity)
		{
			this.m_DealID = DealID;
			this.m_CustCode = CustCode;
			this.m_WeekNo = WeekNo;
			this.m_YearNo = YearNo;
			this.m_Quantity = Quantity;
		}
	}

}
