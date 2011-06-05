using System;

namespace SCM.Utils
{
	/// <summary>
	/// Summary description for clsConstants.
	/// </summary>
	/// <remarks>
	/// Author:			NguyenLD. FPTSS.
	/// Created date:	14/02/2011
	/// </remarks>
	public static class clsConstants
	{
        // Report path
        public const String RPT_QUALIFIELD_PATH = "ReportTemplate/QualifieldResult.rdlc";
        public const String RPT_QUALIFIELD_DETAIL_PATH = "ReportTemplate/QualifieldDetailResult.rdlc";
        public const String RPT_QUALIFIELD_TABLE_NAME = "ReportData_QUALIFIELDRESULT";
        public const String RPT_QUALIFIELD_DETAIL_TABLE_NAME = "ReportData_QUALIFIELDRESULTDETAIL";

        public const String SCM_CORE_LOG = "SCM.Log";
        // Status of access right
        public const String RIGHT_ACCESS = "1";
        public const String LIMIT_ACCESS = "0";
        // Datetime format
        public const String MMDDYYYY = "MM/dd/yyyy";

		/// <summary>
		/// WEEK = "WEEK"
		/// </summary>
		public static string WEEK = "WEEK";
		/// <summary>
		/// Excel template file path
		/// </summary>
		public static string EXCEL_PROMOTION_TEMPLATE= "\\Template\\Template For Promotion.xls";

		///<summary>
		///The path containing CO Master file
		///</summary>
		public const string CO_MASTER_PATH = "DEF_CO_MASTER_PATH";

		///<summary>
		///The path containing CO file for each distributor
		///</summary>
		public const string CO_RELEASE_PATH = "DEF_CO_RELEASE_PATH";

		///<summary>
		///Date to check CO
		///</summary>
		public const string DATE_CHECK_CO = "DEF_DATE_CHECK_CO";

		///<summary>
		///Date to check PPO
		///</summary>
		public const string DATE_CHECK_PPO = "DEF_DATE_CHECK_PPO";

		///<summary>
		///The number of records for each times I saved to text file.
		///</summary>
		public const string EXPORT_DAILY_PPO_NUMBER = "DEF_EXPORT_DAILY_PPO_NUMBER";

		///<summary>
		///The path containing daily PPO files
		///</summary>
		public const string PPO_DAILY_PATH = "DEF_PPO_DAILY_PATH";

		///<summary>
		///The folder contains PPO Backup files
		///</summary>
		public const string PPO_ORIGINAL_BACKUP = "DEF_PPO_ORIGINAL_BACKUP";

		///<summary>
		///The path containing the original PPO file
		///</summary>
		public const string PPO_ORIGINAL_PATH = "DEF_PPO_ORIGINAL_PATH";

		///<summary>
		///Time to check CO file
		///</summary>
		public const string TIME_CHECK_CO = "DEF_TIME_CHECK_CO";

		///<summary>
		///Time to check PPO
		///</summary>
		public const string TIME_CHECK_PPO = "DEF_TIME_CHECK_PPO";


		public const string SWAP_TYPE_SUPPLY = "S";

		public const string SWAP_TYPE_RECEIVE = "R";

		public const int SWAP_CONCURRENT = -1;

		public const string EXCLUDE_STOCK = "DEF_EXCLUDE_STOCK_PATH";

		public const string EXCLUDE_RR = "DEF_EXCLUDE_RR_PATH";

		public const string CASE_PALLET_STDSKU_CODE_TYPE = "H";

        /// Define max len of product code. This values change when modify product code
        /// </summary>
        public const int MAX_LEN_PRODUCT_CODE = 9;

		#region Login Constants

		/// <summary>
		/// Expired day
		/// </summary>
		public static string EXPIRED_DAYS = "DEF_EXPIRED_DAYS";

		/// <summary>
		/// Default expired days. DEFAULT_EXPIRED_DAYS = 90
		/// </summary>
		public const int DEFAULT_EXPIRED_DAYS = 90;

		/// <summary>
		/// LOGIN_SUCCESS = 0
		/// </summary>
		public const int LOGIN_SUCCESS = 0;

		/// <summary>
		/// ACCOUNT_NOT_EXIST = -2
		/// </summary>
		public const int ACCOUNT_NOT_EXIST = -2;

		/// <summary>
		/// PASSWORD_WRONG = -3
		/// </summary>
		public const int PASSWORD_WRONG = -3;

		/// <summary>
		/// ACCOUNT_INACTIVE = -4
		/// </summary>
		public const int ACCOUNT_INACTIVE = -4;

		/// <summary>
		/// ACCOUNT_EXPIRED = -5
		/// </summary>
		public const int ACCOUNT_EXPIRED = -5;

		/// <summary>
		/// PASSWORD_EXPIRED = -6
		/// </summary>
		public const int PASSWORD_EXPIRED = -6;

        public const int PPO_STATUS_UNZIP_FAIL = 2;
        public const int PPO_STATUS_IMPORT_FAIL = 4;
        public const int PPO_STATUS_READY_REVISE = 5;

        public const string PPO_DESCR_UPDATE = "Application updated";
        public const string APP_NAME = "SCM";
        

        public const string FORMAT_IMPORT_FILE_PPO_MANUALLY = "*.zip";
		#endregion Login Constants

		#region Action
		public static string MINUS = "-";
		public const string MENU_WINDOWS = "mnuWindow";
		public static string MENU_SEPARATE = "mnuSeparate";
		public static string MENU_HELP_TOPIC = "mnuHelpTopic";
		public static string MENU_HELP_ABOUT = "mnuHelpAbout";
		public static string EXPORT_STOCK_POLICY = "mnuSPExportSP";
		public static string WINDOW_CASCADE = "mnuWindowCascade";
		public static string WINDOW_TILE_HOZ = "mnuWindowTileHorizontal";
		public static string WINDOW_TILE_VERT = "mnuWindowTileVertical";
		public static string WINDOW_CLOSE_ALL = "mnuCloseAllWindow";
        public static string IMPORT_PPO_MANUALLY = "mnuImportPPO";
		
		/// <summary>
		/// Exit application
		/// </summary>
		public static string LOG_OUT = "mnuLogout";
		/// <summary>
		/// Exit application
		/// </summary>
		public static string EXIT = "mnuExit";

		/// <summary>
		/// Change language to English
		/// </summary>
		public static string ENGLISH = "EN";

		/// <summary>
		/// Change languate to Vietnamese
		/// </summary>
		public static string VIETNAMESE = "VN";

		/// <summary>
		/// Change language to English
		/// </summary>
		public static string SET_ENGLISH_LANGUAGE = "mnuEN";

		/// <summary>
		/// Change languate to Vietnamese
		/// </summary>
		public static string SET_VIETNAMESE_LANGUAGE = "mnuVN";

		/// <summary>
		/// Maximized MDI Children when appear.
		/// </summary>
		public static string MAXIMIZED = "mnuMaximized";

		/// <summary>
		/// Flat System style
		/// </summary>
		public static string SYSTEM_STYLE = "mnuSystemStyle";
		public static string COLOR_FOCUS_CONTROL = "mnuColorFocusControl";

        #region -Excel format-
        public const int PPO_ORDPROPOSAL_MIN = 0;
        public const int PPO_ORDPROPOSAL_MAX = 99999;
        public const int PPO_NOTE_MAX_LENGTH = 255;
        public const string PPO_MSG_SUM = "Sum of {0} = {1}";
        public const string PPO_MSG_INPUT = "Valid quantity is in range between {0} and {1}";
        #endregion

		#endregion Action

        // ThucNV - 20110216
        #region Card Type
        public const string CARD_TYPE = "CARD_TYPE";
        public const string CARD_TYPE_AMOUNT = "Amount";
        public const string CARD_TYPE_FREEITEM = "FreeItem";
        public const string CARD_TYPE_FREEITEM_AND_AMOUNT = "Amount&FreeItem";
        #endregion
        #region Scheme status
        public const string SCHEME_STATUS = "SCHEME_STATUS";
        public const string SCHEME_STATUS_OPEN = "Open";
        public const string SCHEME_STATUS_EXPIRE = "Expire";
        public const string SCHEME_STATUS_CLAIMED = "Claimed";
        #endregion

        // End
	}
}
