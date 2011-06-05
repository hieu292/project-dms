

using System;
using System.Collections;

namespace SCM.DataAccessObject
{   
    public class SCM_PARAMETERData
    {
        #region Fields
        public static readonly string TableName = "SCM_PARAMETER";
        
        public static readonly string ColParamId = "ParamId";
        
        public static readonly string ColParamName = "ParamName";
        
        public static readonly string ColParamValue = "ParamValue";
        
        public static readonly string ColDescription = "Description";
        

        public static readonly string LIST_STOREPROCEDURE = "sp_GetAllSCM_PARAMETER";
        public static readonly string READ_STOREPROCEDURE = "sp_GetSCM_PARAMETER";
        public static readonly string UPDATE_STOREPROCEDURE = "sp_UpdateSCM_PARAMETER";
        public static readonly string ADD_STOREPROCEDURE = "sp_AddSCM_PARAMETER";
        public static readonly string DELETE_STOREPROCEDURE = "sp_DeleteSCM_PARAMETER";
        public static readonly string PERMANENT_DELETE_STOREPROCEDURE = "sp_PermanentDeleteSCM_PARAMETER";
        public static readonly string SEARCH_STOREPROCEDURE = "sp_SearchSCM_PARAMETER";
        #endregion
    }
}

