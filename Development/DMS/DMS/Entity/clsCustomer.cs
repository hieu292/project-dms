using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.ValueObject
{
    class clsCustomer
    {
        private string custCode = "";

        public string CustCode
        {
            get { return custCode; }
            set { custCode = value; }
        }

        private string shipToCode = "";

        public string ShipToCode
        {
            get { return shipToCode; }
            set { shipToCode = value; }
        }

    }
}
