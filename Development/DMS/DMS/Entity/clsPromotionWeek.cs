using System;

namespace SCM.ValueObject
{
	/// <summary>
	/// Summary description for clsPromotionWeek.
	/// </summary>
	public class clsPromotionWeek : clsBaseObject
	{
		protected string m_DealID = "";
		protected decimal m_WeekNo = 0;
		protected decimal m_YearNo = 0;
		protected decimal m_Ratio = 0;
		protected string m_Status;
		protected bool m_IsActive = true;

		public string DealID
		{
			get{return m_DealID;}
			set{m_DealID = value;}
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
		public decimal Ratio
		{
			get{return m_Ratio;}
			set{m_Ratio = value;}
		}
		public string Status
		{
			get{return m_Status;}
			set
			{
				m_Status = value;
				m_IsActive = (m_Status!= "25");
			}
		}

		public bool IsActive
		{
			get{return m_IsActive;}//{return Status != "25";}
		}

		public clsPromotionWeek(){}
		public clsPromotionWeek(string DealID, decimal WeekNo, decimal YearNo, decimal Ratio, string Status)
		{
			this.m_DealID = DealID;
			this.m_WeekNo = WeekNo;
			this.m_YearNo = YearNo;
			this.m_Ratio = Ratio;
			this.m_Status = Status;
		}
	}
}
