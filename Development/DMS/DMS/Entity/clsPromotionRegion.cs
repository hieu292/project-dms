using System;

namespace DMS.ValueObject
{
	/// <summary>
	/// Summary description for PromotionRegion.
	/// </summary>
	public class clsPromotionRegion : clsBaseObject
	{
		protected string m_DealID = "";
		protected string m_DealType = "P";
		protected string m_PID = "";
		protected string m_Description= "";
		protected decimal m_FromWeek = 0;
		protected decimal m_FromYear = 0;
		protected decimal m_ToWeek = 0;
		protected decimal m_ToYear = 0;

		protected string m_RegionCode = "";
		protected string m_StrategicRegionCode = "";
		protected decimal m_OriginalQuantity = 0;
		protected decimal m_Quantity = 0;
		protected decimal m_AvailableQuantity = 0;


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
		public string Description
		{
			get{return m_Description;}
			set{m_Description = value;}
		}
		public string RegionCode
		{
			get{return m_RegionCode;}
			set{m_RegionCode = value;}
		}
		public string StrategicRegionCode
		{
			get{return m_StrategicRegionCode;}
			set{m_StrategicRegionCode = value;}
		}
		public decimal OriginalQuantity
		{
			get{return m_OriginalQuantity;}
			set{m_OriginalQuantity = value;}
		}
		public decimal Quantity
		{
			get{return m_Quantity;}
			set{m_Quantity = value;}
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
		/// <summary>
		/// Sum of quantity of customers in inactive weeks
		/// </summary>
		public decimal AvailableQuantity
		{
			get{return m_AvailableQuantity;}
			set{m_AvailableQuantity = value;}
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
					return (int)(WEEKS_OF_YEAR + m_ToWeek - m_FromWeek);
				}
			}
		}
		public clsPromotionRegion(){}
		public clsPromotionRegion(string DealID, string DealType, string PID, string Description, string RegionCode, string StrategicRegionCode, decimal OriginalQuantity, decimal Quantity, decimal FromWeek, decimal FromYear, decimal ToWeek, decimal ToYear)
		{
			this.m_DealID = DealID;
			this.m_DealType = DealType;
			this.m_PID = PID;
			this.m_Description = Description;
			this.m_RegionCode = RegionCode;
			this.m_StrategicRegionCode = StrategicRegionCode;
			this.m_OriginalQuantity = OriginalQuantity;
			this.m_Quantity = Quantity;
			this.m_FromWeek = FromWeek;
			this.m_FromYear = FromYear;
			this.m_ToWeek = ToWeek;
			this.m_ToYear = ToYear;
		}
	}

}
