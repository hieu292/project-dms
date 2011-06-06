using System;

namespace DMS.ValueObject
{
	/// <summary>
	/// Summary description for clsPromotion.
	/// </summary>
	public class clsPromotion : clsBaseObject
	{
		protected string m_DealID;
		protected string m_DealType;
		protected string m_PID;
		protected decimal m_FromWeek;
		protected decimal m_FromYear;
		protected decimal m_ToWeek;
		protected decimal m_ToYear;
		protected string m_Status;
		protected string m_Description;

		public string DealID
		{
			get{return m_DealID;}
			set{m_DealID = value;}
		}
		public string DealType
		{
			get{return m_DealType;}
			set{m_DealType = value;}
		}
		public string PID
		{
			get{return m_PID;}
			set{m_PID = value;}
		}
		public decimal FromWeek
		{
			get{return m_FromWeek;}
			set{m_FromWeek = value;}
		}
		public decimal FromYear
		{
			get{return m_FromYear;}
			set{m_FromYear = value;}
		}
		public decimal ToWeek
		{
			get{return m_ToWeek;}
			set{m_ToWeek = value;}
		}
		public decimal ToYear
		{
			get{return m_ToYear;}
			set{m_ToYear = value;}
		}
		public string Status
		{
			get{return m_Status;}
			set{m_Status = value;}
		}
		public string Description
		{
			get{return m_Description;}
			set{m_Description = value;}
		}

		public int TotalWeek
		{
			get
			{
				if(m_ToYear == m_FromYear)
				{
					return (int)(m_ToWeek - m_FromWeek + 1);
				}
				else
				{
					return (int)(WEEKS_OF_YEAR + m_ToWeek - m_FromWeek + 1);
				}
			}
		}

		public clsPromotion(){}
		public clsPromotion(string DealID, string DealType, string PID, decimal FromWeek, decimal FromYear, decimal ToWeek, decimal ToYear, string Status, string Description)
		{
			this.m_DealID = DealID;
			this.m_DealType = DealType;
			this.m_PID = PID;
			this.m_FromWeek = FromWeek;
			this.m_FromYear = FromYear;
			this.m_ToWeek = ToWeek;
			this.m_ToYear = ToYear;
			this.m_Status = Status;
			this.m_Description = Description;
		}
	}

}
