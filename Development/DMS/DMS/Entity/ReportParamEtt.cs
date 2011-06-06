using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.DataAccessObject
{
    /// <summary>
    ///    
    /// </summary>
    [Serializable]
    public class ReportParamEtt
    {
        #region Propreties
        private String _ParamName = String.Empty;
        private String _ParamType = String.Empty;
        private Object _ParamValue = String.Empty;

        public String ParamName
        {
            get { return _ParamName; }
            set { this._ParamName = value; }
        }

        public String ParamType
        {
            get { return _ParamType; }
            set { this._ParamType = value; }
        }

        public Object ParamValue
        {
            get { return _ParamValue; }
            set { this._ParamValue = value; }
        }
        #endregion

        #region Constructor
        public ReportParamEtt(String paramName, String paramType, String paramValue)
        {
            this._ParamName = paramName;
            this._ParamType = paramType;
            this._ParamValue = paramValue;
        }

        #endregion
    }
}
