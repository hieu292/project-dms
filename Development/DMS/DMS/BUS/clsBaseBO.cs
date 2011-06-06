using System;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.IO;
using System.Collections;
using System.Windows.Forms;

using DMS.Utils;
using DMS.DataAccessObject;

using System.Runtime.InteropServices; // For COMException
using System.Diagnostics; // to ensure EXCEL process is really killed
using System.ComponentModel;

namespace DMS.BusinessObject
{
	/// <summary>
	/// Summary description for BaseBO.
	/// </summary>
	public class clsBaseBO
	{
		private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsBaseBO));

		protected const char DEF_SPACE = ' ';
		protected const char DEF_ZERO = '0';

        /// Define max len of product code 
        /// </summary>
        private string pramam_Max_Product = "MAX_LEN_PRODUCT_CODE";

        public int GetLenProductCode()
        {
            return int.Parse(dao.GetParameterValue(pramam_Max_Product));
        }

		//Use to import/export excel
		public static string []COL_NAME = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
										   "AA","AB","AC","AD","AE","AF","AG","AH","AI","AJ","AK","AL","AM","AN","AO","AP","AQ","AR","AS","AT","AU","AV","AW","AX","AY","AZ",
										   "BA","BB","BC","BD","BE","BF","BG","BH","BI","BJ","BK","BL","BM","BN"};
		public static object missing = Missing.Value;
		public static int EXCEL_COL_SPACE = 2;

		public static bool IS_EXPORT_DAILY_PPO = false;

		private clsBaseDAO dao = new clsBaseDAO();

	
		public clsBaseBO()
		{
		}

		/// <summary>
		/// Get current week
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int GetCurrentWeek()
		{
            //Thanhnq fix bug: 20090218: get curent week from database
			//I will get current year from database by shipping calendar.
            //int week = (DateTime.Now.DayOfYear / 7) + 1;

            //if(week > 52)
            //    week = 52;

			//return week;
            return clsCommon.GetCurrentULVWeek();

		}
		public string WEEK
		{
			get{return GetWeek();}
		}

		/// <summary>
		/// Get current year
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int GetCurrentYear()
		{
			//Thanhnq fix bug: 20090218: get curent year from database
            //return DateTime.Now.Year;
            return clsCommon.GetCurrentULVYear();
		}
        /*=======12-Mar-2009: Dung ham chung trong clsBase==============
		/// <summary>
		/// Get all regions by logined user
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable GetRegions()
		{
			clsCommon common = new clsCommon();
			string strSql = string.Format("SELECT A.REGION_CODE, REGION_NAME FROM (SELECT REGION_CODE FROM SCM_AUT_USER_REGION WHERE USERNAME = '{0}') AS A LEFT JOIN SCM_REGION_HIERARCHY B ON A.REGION_CODE = B.REGION_CODE ORDER BY B.PRIORITY", common.EncodeString(clsSystemConfig.UserName));
			DataTable dt = dao.GetDataTable(strSql);
			DataRow row = dt.NewRow();
			row[0] = string.Empty;
			row[1] = string.Empty;
			dt.Rows.InsertAt(row, 0);
			return dt;
		}
        =======================*/

		/// <summary>
		/// Get one product by P_ID
		/// </summary>
		/// <param name="pid"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataRow GetProduct(string pid)
		{
			SqlCommand cmd = new SqlCommand("SELECT P_ID, P_DESC, PCS_PER_CASE, NET_WEIGHT, PRICE, DIVISION_ID, CAT_ID, SUB_CAT_ID, BRAND_ID, STATUS, BRANDY_ID, BRANDY_NAME, VARIANT_ID, PACKSIZE, STDSKU, STDSKU_NAME FROM GENERAL_PRODUCT WHERE P_ID = @P_ID");
			cmd.Parameters.Add("@P_ID", SqlDbType.VarChar, 14).Value = pid;
			DataTable dt = dao.GetDataTable(cmd);
			if(dt.Rows.Count == 0)
				return null;
			else
				return dt.Rows[0];
		}

		/// <summary>
		/// Get all customers
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable GetCustomers()
		{
			clsCommon common = new clsCommon();
			string strSql = string.Format("SELECT DISTINCT CUST_CODE, CUST_NAME FROM GENERAL_DISTRIBUTOR_HIERARCHY ORDER BY CUST_CODE");
			DataTable dt = dao.GetDataTable(strSql);
			DataRow row = dt.NewRow();
			row[0] = string.Empty;
			row[1] = string.Empty;
			dt.Rows.InsertAt(row, 0);
			return dt;
		}

		public DataTable GetShipTo(string strCustCode)
		{
			string strSql;

			try
			{
				strSql = "SELECT SHIP_TO_CODE, SHIP_TO_NAME, PROMOTION_PERCENT, ADDRESS = CASE WHEN ADDRESS <> '' THEN ADDRESS ELSE '(n/a)' END, PHONE = CASE WHEN PHONE <> '' THEN PHONE ELSE '(n/a)' END, CONTACT_PERSON = CASE WHEN CONTACT_PERSON <> '' THEN CONTACT_PERSON ELSE '(n/a)' END, MAIN_SITE = CASE WHEN MAIN_SITE = 'Y' THEN 'Yes' ELSE 'No' END, STATUS = CASE WHEN STATUS = 'AC' THEN 'Active' ELSE 'Inactive' END, RURAL FROM GENERAL_SHIP_TO WHERE STATUS = 'AC' AND CUST_CODE = '" + strCustCode + "' ORDER BY MAIN_SITE DESC, SHIP_TO_CODE";
				return dao.GetDataTable(strSql);
			}
			catch(Exception ex)
			{
				log.Error(ex.ToString());
				return null;
			}
		}

		public DataTable GetRuralSKUList(string shipToCode, int week, int year)
		{
			try
			{
				SqlParameter[] parameters = new SqlParameter[3];

				parameters[0] = new SqlParameter();
				parameters[0].ParameterName = "@SHIP_TO_CODE";
				parameters[0].SqlDbType = SqlDbType.VarChar;
				parameters[0].Value = shipToCode;

				parameters[1] = new SqlParameter();
				parameters[1].ParameterName = "@WEEK";
				parameters[1].SqlDbType = SqlDbType.Int;
				parameters[1].Value = week;

				parameters[2] = new SqlParameter();
				parameters[2].ParameterName = "@YEAR";
				parameters[2].SqlDbType = SqlDbType.Int;
				parameters[2].Value = year;

				return dao.ExecuteQuerySp("sp_GetRuralSTDSKUList", parameters);
			}
			catch(Exception ex)
			{
				log.Error(ex.ToString());
				throw new Exception("clsPPODAO.GetRuralSKUList error");
			}
		}

		/// <summary>
		/// Get region code of customer by CustCode
		/// </summary>
		/// <param name="custCode"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public string GetRegionCode(string custCode)
		{
			string strSql = string.Format("SELECT TOP 1 REGION_CODE FROM GENERAL_DISTRIBUTOR_HIERARCHY WHERE CUST_CODE = '{0}'", custCode);
			object obj = dao.ExecuteScalar(strSql);
			if(obj == null)
				return "";
			else
				return obj.ToString();
		}



		#region Export to Excel


		/// <summary>
		/// Export data table to Excel
		/// </summary>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public void ExportToExcel(DataTable dt)
		{
			Excel.Application excelApp = null;
			Excel.Workbook excelBook = null;
			Excel.Worksheet sheet = null;
			Excel.Range range = null;

			int i = 0;
			int j = 0;
			int rowCout = dt.Rows.Count;
			int colCount = dt.Columns.Count;
			DataColumnCollection cols = dt.Columns;
			DataRowCollection rows = dt.Rows;

			try
			{
				excelApp = new Excel.Application();
				excelBook = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
				sheet = (Excel.Worksheet) excelBook.Worksheets[1];
				range = null;

				//Export header
				for(i = 0; i < colCount; i ++)
				{
					range = sheet.get_Range(COL_NAME[i] + "1", missing);
					range.Font.Bold = true;
					range.Value2 = cols[i].ColumnName;

					range.EntireColumn.AutoFit();
				}
				
				// Export data row in dt into excel row
				for(i = 0; i < rowCout; i ++)
				{
					for(j = 0; j < colCount; j ++)
					{
						sheet.get_Range(COL_NAME[j] + (i + EXCEL_COL_SPACE), missing).Value2 = rows[i][j].ToString();
					}
				}

				
				excelApp.Visible = true;
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
				if(excelApp != null)
					excelApp.Visible = true;
			}
		}

		/// <summary>
		/// Export data table to Excel like DataGridTableStyle
		/// </summary>
		/// <param name="dt"></param>
		/// <param name="grdStyle"></param>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public void ExportToExcel(DataTable dt, DataGridTableStyle grdStyle)
		{
			ExportToExcel(dt, grdStyle, 0, 0);
		}

		public void ExportToExcel(DataTable dt, DataGridTableStyle grdStyle, int startRow, int startCol)
		{
			if(dt == null)
				return;
			ExportToExcel(dt.DefaultView, grdStyle, startRow, startCol);
		}

		/// <summary>
		/// Export data table to Excel like DataGridTableStyle
		/// </summary>
		/// <param name="view"></param>
		/// <param name="grdStyle"></param>
		/// <param name="startRow"></param>
		/// <param name="startCol"></param>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public void ExportToExcel(DataView view, DataGridTableStyle grdStyle, int startRow, int startCol)
		{
			if(view == null || grdStyle == null)
				return;

			clsCommon common = new clsCommon();
			string[] headers = null;
			int[] indexes = null;
			common.GetExportInfo(view, grdStyle.GridColumnStyles, ref headers, ref indexes);
			ExportToExcel(view, headers, indexes, startRow, startCol);
		}

		/// <summary>
		/// Export data table to Excel like DataGridTableStyle
		/// </summary>
		/// <param name="view"></param>
		/// <param name="headers"></param>
		/// <param name="indexes"></param>
		/// <param name="startRow"></param>
		/// <param name="startCol"></param>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public void ExportToExcel(DataView view, string[] headers, int[] indexes, int startRow, int startCol)
		{
			Excel.Application excelApp = null;
			Excel.Workbook excelBook = null;
			Excel.Worksheet sheet = null;

			try
			{
				excelApp = new Excel.Application();
				excelBook = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
				sheet = (Excel.Worksheet) excelBook.Worksheets[1];

				ExportToExcel(view, headers, indexes, startRow, startCol, sheet);

				excelApp.Visible = true;
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
				if(excelApp != null)
					excelApp.Visible = true;
			}
		}

		/// <summary>
		/// Export data table to Excel
		/// </summary>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public void ExportToExcel(DataView view, DataGridTableStyle grdStyle, int startRow, int startCol, Excel.Worksheet sheet)
		{
			clsCommon common = new clsCommon();
			string[] headers = null;
			int[] indexes = null;
			common.GetExportInfo(view, grdStyle.GridColumnStyles, ref headers, ref indexes);

			ExportToExcel(view, headers, indexes, startRow, startCol, sheet);
		}

		/// <summary>
		/// Export data table to Excel
		/// </summary>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public void ExportToExcel(DataView view, string[] headers, int[] indexes, int startRow, int startCol, Excel.Worksheet sheet)
		{
			Excel.Range range = null;
			object obj = null;

			int i = 0;
			int j = 0;
			DataColumnCollection cols = view.Table.Columns;
			//DataRowCollection rows = dt.Rows;
			DataView rows = view;
			int rowCout = rows.Count;
			int colCount = indexes.Length;

			for(i = 0; i < rowCout; i ++)
			{
				for(j = 0; j < colCount; j ++)
				{
					obj = rows[i][indexes[j]];
                    sheet.get_Range(COL_NAME[j + startCol] + (i + startRow + EXCEL_COL_SPACE), missing).NumberFormat = "@";
					sheet.get_Range(COL_NAME[j + startCol] + (i + startRow + EXCEL_COL_SPACE), missing).Value2 = obj.ToString();
				}
			}

			//Export header
			colCount = headers.Length;
			for(i = 0; i < colCount; i ++)
			{
				range = sheet.get_Range(COL_NAME[i + startCol] + (startRow + 1), missing);
				range.Font.Bold = true;
				range.Value2 = headers[i];
				range.EntireColumn.AutoFit();
			}
		}

		/// <summary>
		/// Export data table to Excel
		/// </summary>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public void ExportToExcel(DataTable dt, string[] headers, int[] indexes)
		{
			ExportToExcel(dt.DefaultView, headers, indexes, 0, 0);
		}

		#endregion Export to Excel


		/// <summary>
		/// Replace ' by ''
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public string EncodeString(string value)
		{
			if(value == null || value.Length == 0)
				return value;
			return value.Replace("'", "''");
		}

		/// <summary>
		/// tra ve gia tri tuan bang chu (W12_2011)
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>
		/// <returns>strDate</returns>

		public string GetWeek()
		{
			string strDate="W";
			SqlConnection con = clsBaseDAO.Connection;
			if(con == null)
				throw new Exception(clsBaseDAO.CONNECTION_ERROR);
			if(con.State != ConnectionState.Open)
				con.Open();
			
			SqlCommand cmd = new SqlCommand("sp_GETWEEK", con);
			cmd.CommandType = CommandType.StoredProcedure;
			try
			{
				strDate	 += cmd.ExecuteScalar().ToString();
			}
			catch(Exception ex)
			{
				throw ex;
			}
			strDate += "_";
			strDate += DateTime.Now.Year.ToString();
			return strDate;
		}

		/// <summary>
		/// tra ve gia tri tuan bang so
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>
		/// <returns>strDate</returns>

		public string GetWeekSingle()
		{
			string strDate = "";
			SqlConnection con = clsBaseDAO.Connection;

			try
			{
				if(con.State != ConnectionState.Open)
					con.Open();
			
				SqlCommand cmd = new SqlCommand("sp_GETWEEK", con);
				cmd.CommandType = CommandType.StoredProcedure;

				object obj = cmd.ExecuteScalar();
				if(obj != null)
					strDate = obj.ToString();
				else
					strDate = "";

				//strDate	 = cmd.ExecuteScalar();
				return strDate;
			}
			catch(Exception ex)
			{
				throw ex;
			}			
		}

		/// <summary>
		/// bien chuoi truyen vao theo kieu WildCard
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>
		/// <returns>dtTemp</returns>

		public string WildCard(string strValue)
		{
			for (int i=0;i<strValue.Length;i++)
			{
				if(strValue[i] == '*')
					strValue = strValue.Replace('*', '%');
				else if(strValue[i] == '?')
					strValue = strValue.Replace('?', '_');
			}
			strValue= strValue + "%";
			return strValue;
		}

		/// <summary>
		/// tra ve gia tri tuan: tu tuan hien tai cho den tuan 52
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>
		/// <returns>intWeeks</returns>
	
		public int[] InitWeek()
		{
			clsCommon common = new clsCommon();
			int intCurrentWeek = common.GetInt(GetWeekSingle());
			if(intCurrentWeek < 52)
				intCurrentWeek += 1;
			int intArraySize = 53-intCurrentWeek;
			int[] intWeeks  = new int[intArraySize];
			int i=0;
			while(intCurrentWeek<=52)
			{
				intWeeks[i] = intCurrentWeek;
				i++;
				intCurrentWeek++;
			}
			return intWeeks;
		}

		/// <summary>
		/// tra ve gia tri nam: nam hien tai, qua khu va nam tiep theo
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>
		/// <returns>intYears</returns>
		
		public int[] InitYear()
		{
			int intCurrentYear = DateTime.Now.Year;
			int[] intYears = {intCurrentYear-1, intCurrentYear, intCurrentYear+1};
			return intYears;
		}

		/// <summary>
		/// neu chuoi rong tra ve gia tri can thiet, neu ko tra ve chinh chuoi do
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>
		/// <param name="strValue"</param>
		/// <returns>intYears</returns>

		public object EmptyNull(object objValue, object objReturnValue)
		{
			if(objValue.ToString().Length == 0 || objValue == DBNull.Value)
				return objReturnValue;
			else
				return objValue;
		}


        /// <summary>
        /// Get Strategic Region by UserName
        /// CanLV: 11-Mar-2009
        /// </summary>
        /// <returns></returns>
        public DataTable GetAuthorizedStrategicRegion()
        {
            try
            {
                return dao.GetAuthorizedStrategicRegion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Strategic Region by UserName
        /// CanLV: 11-Mar-2009
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetAuthorizedStrategicRegion(string userName)
        {
            try
            {
                return dao.GetAuthorizedStrategicRegion(userName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get RegionCode by UserName
        /// CanLV: 11-Mar-2009
        /// </summary>
        /// <returns></returns>
        public DataTable GetAuthorizedRegion()
        {
            try
            {
                return dao.GetAuthorizedRegion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get RegionCode by UserName
        /// CanLV: 11-Mar-2009
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable GetAuthorizedRegion(string userName)
        {
            try
            {
                return dao.GetAuthorizedRegion(userName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add order-number column to datatable.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="colName">Name of order0number column</param>
        /// <returns></returns>
        public DataTable AddOrderNumColumn(DataTable dt, string colName)
        {
            //Add column if not exist
            if (!dt.Columns.Contains(colName))
            {
                dt.Columns.Add(colName);
            }

            int num = 1;

            foreach (DataRow row in dt.Rows)
            {
                row[colName] = num;
                num++;
            }

            return dt;
        }

        /// <summary>
        /// Get sales org by ship to
        /// </summary>
        /// <param name="strShipToCode"></param>
        /// <returns></returns>
        /// <remarks>
        /// TruongNC - 2009/09/29
        /// </remarks>
        public string GetSalesOrg(string strShipToCode)
        {
            try
            {
                clsBaseDAO m_dao = new clsBaseDAO();
                return m_dao.GetSalesOrg(strShipToCode);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                throw ex;
            }
        }
	}
}
