using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.ValueObject
{
    public class clsCustomer : clsBaseObject
    {
#region Attributes 

        private string m_CustID;
        private string m_CustName;
        private string m_CellPhoneNbr;
        private string m_TelePhoneNbr;
        private string m_Email;
        private string m_Address;
        private string m_StreetCode;
        private string m_DistCode;
        private string m_CityCode;
        private string m_Type;
        private string m_AccountNbr;
        private string m_Status;

#endregion Attributes

#region Constructors

        public clsCustomer()
        {

        }

        public clsCustomer(  string strCustID,
          string strCustName,
          string strCellPhoneNbr,
          string strTelePhoneNbr,
          string strEmail,
          string strAddress,
          string strStreetCode,
          string strDistCode,
          string strCityCode,
          string strType,
          string strAccountNbr,
          string strStatus)
        {
            m_CustID = strCustID;
            m_CustName = strCustName;
            m_CellPhoneNbr = strCellPhoneNbr;
            m_TelePhoneNbr = strTelePhoneNbr;
            m_Email = strEmail;
            m_Address = strAddress;
            m_Type = strType;
            m_AccountNbr = strAccountNbr;
            m_Status = strStatus;
            m_StreetCode = strStreetCode;
            m_DistCode = strDistCode;
            m_CityCode = strCityCode;
        }

#endregion Constructors

#region Properties
        public string CustID
        {
            get { return m_CustID; }
            set { m_CustID = value; }
        }

        public string CustName
        {
            get { return m_CustName; }
            set { m_CustName = value; }
        }

        public string CellPhoneNbr
        {
            get { return m_CellPhoneNbr; }
            set { m_CellPhoneNbr = value; }
        }

        public string TelePhoneNbr
        {
            get { return m_TelePhoneNbr; }
            set { m_TelePhoneNbr = value; }
        }

        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }

        public string StreetCode
        {
            get { return m_StreetCode; }
            set { m_StreetCode = value; }
        }

        public string DistCode
        {
            get { return m_DistCode; }
            set { m_DistCode = value; }
        }

        public string CityCode
        {
            get { return m_CityCode; }
            set { m_CityCode = value; }
        } 

        public string Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }

        public string AccountNbr
        {
            get { return m_AccountNbr; }
            set { m_AccountNbr = value; }
        }

        public string Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

#endregion Properties

    }
}
