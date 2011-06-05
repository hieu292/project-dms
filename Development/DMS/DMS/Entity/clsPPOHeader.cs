using System;
using System.Collections;

namespace SCM.ValueObject
{
	/// <summary>
	/// Summary description for clsPPOHeader.
	/// </summary>
	public class clsPPOHeader : clsBaseObject
	{
		protected string m_PPOCode;
		protected string m_CustCode;
		protected DateTime m_OrdDate;
		protected decimal m_WeekNo;
		protected decimal m_YearNo;
		protected byte m_Status;
		protected string m_Type;
		protected string m_PPOFileSource;
		protected DateTime m_ImportedDate;
		protected DateTime m_LastUpdatedDate;
		protected ArrayList ppoDetails = new ArrayList();
		protected ArrayList ppoRevised = new ArrayList();

		public ArrayList PPODetails
		{
			get{return ppoDetails;}
			set{ppoDetails = value;}
		}

		public ArrayList PPORevised
		{
			get{return ppoRevised;}
			set{ppoRevised = value;}
		}

		public string PPOCode
		{
			get{return m_PPOCode;}
			set{m_PPOCode = value;}
		}
		public string CustCode
		{
			get{return m_CustCode;}
			set{m_CustCode = value;}
		}
		public DateTime OrdDate
		{
			get{return m_OrdDate;}
			set{m_OrdDate = value;}
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
		public byte Status
		{
			get{return m_Status;}
			set{m_Status = value;}
		}
		public string Type
		{
			get{return m_Type;}
			set{m_Type = value;}
		}
		public string PPOFileSource
		{
			get{return m_PPOFileSource;}
			set{m_PPOFileSource = value;}
		}
		public DateTime ImportedDate
		{
			get{return m_ImportedDate;}
			set{m_ImportedDate = value;}
		}
		public DateTime LastUpdatedDate
		{
			get{return m_LastUpdatedDate;}
			set{m_LastUpdatedDate = value;}
		}
		public clsPPOHeader(){}
		public clsPPOHeader(string PPOCode, string CustCode, DateTime OrdDate, decimal WeekNo, decimal YearNo, byte Status, string Type, string PPOFileSource, DateTime ImportedDate, DateTime LastUpdatedDate)
		{
			this.m_PPOCode = PPOCode;
			this.m_CustCode = CustCode;
			this.m_OrdDate = OrdDate;
			this.m_WeekNo = WeekNo;
			this.m_YearNo = YearNo;
			this.m_Status = Status;
			this.m_Type = Type;
			this.m_PPOFileSource = PPOFileSource;
			this.m_ImportedDate = ImportedDate;
			this.m_LastUpdatedDate = LastUpdatedDate;
		}
	}
}
