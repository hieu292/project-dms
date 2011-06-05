using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Web;

using SCM.DataAccessObject;
using SCM.BusinessObject;
using SCM.Utils;

namespace SCM.BusinessObject
{
	/// <summary>
	/// Summary description for CustomerBO.
	/// </summary>
	public class clsParameterBO:clsBaseBO
	{
		private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsParameterBO));
		protected clsParameterDAO dao = new clsParameterDAO();
		public clsParameterBO()
		{
			
		}	

		/// <summary>
		/// Return DataTable to Combobox
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>
		
		public DataTable LoadAll()
		{
			return dao.GetDataTable("SELECT DISTINCT PARAM_GROUP FROM SCM_PARAMETERS ORDER BY PARAM_GROUP DESC");
		}
		
		
		/// <summary>
		/// Return DataTable to Set Source for DAtaGrid
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>
		
		public DataTable GetOne(string ParamterGroup, string param)
		{
            return dao.GetOne(ParamterGroup, param);
		}

		/// <summary>
		/// Update Parameter value
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>		
		
		public bool Update(string m_value, string m_name)
		{
			return dao.UpdateValue(m_value, m_name);
		}

		/// <summary>
		/// Check Parameter value
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>		
		
		public bool Validate(string strType, string strValue)
		{
			if(strType=="s")
			{
//				if(Directory.Exists(strValue)==false)
//				{	return false; }
				strValue=strValue.Replace(":", "");
				if(isNumeric(strValue))
				{
					return false;
				}
			}
//			else 
			if(strType=="t"||strType=="n")
			{
				strValue=strValue.Replace(":", "0");
				if( !isNumeric(strValue))
				{
					return false;
				}
			}
			else if(strType=="b")
			{
				if(!(strValue=="Y"||strValue=="y" || strValue== "N"||strValue=="n"))
					return false;
			}
			else if(strType == "d")
			{
				// Modified by: TuanDH
                // Date: 19/07/2010
                int intCheck = 0;
				
                string[] strDate = {"MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN"};
				for(int i = 0; i < strDate.Length; i++)
				{
                    if (strValue.ToUpper() == strDate[i].ToUpper())
                        return true;
                    
                    intCheck += 1;
                }
				
                //if(intCheck == strDate.Length) return false;
                return false;
			}
			
            return true;
		}

		/// <summary>
		/// Check chuoi co phai la numeric hay ko
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>

		public bool isNumeric(string val)
		{
			try
			{
				Double.Parse(val);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Export Parameter
		/// </summary>
		/// <remarks>
		/// Author			:	Nguyen Bao Nguyen G3
		/// Created day		:	24-Apr-2011
		/// </remarks>
		public string ExportParameter(string strRRWeek, string strMaxPPO, string strMinPPO)
		{
			string strParamPath = "";
			try
			{
				strParamPath = dao.ExportParameter(strRRWeek, strMaxPPO, strMinPPO);
				if (strParamPath != "") // khac rong co nghia la export param thanh cong
					ZipFileParam(strParamPath);
				return strParamPath;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//-- tuannh2 added 20080822: export param cua nhung cust_code dat hang daily
		public string ExportDailyParameter()
		{
			try
			{
				string path = "";
				DataTable dt = dao.GetDataTable("select distinct cust_code from SCM_DISTRIBUTOR_HIERARCHY where PPO_TYPE = 'D' AND STATUS = 'AC'");
				string strExportPath = dao.GetExportParamPath();
				foreach(DataRow drow in dt.Rows)
				{
					string strCustCode = drow["CUST_CODE"].ToString();
					path = dao.ExportDailyParameter(strCustCode, strExportPath);
				}
				ZipFileParam(path);
				return path;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		//-- end tuannh2

		/// <summary>
		/// Get Status of Stock Paramters
		/// </summary>
		///  <remarks>
		///  //true: exported , false : unexported
		/// Author:			Nguyen Bao Nguyen	G3
		/// Modified:		24-Apr-2011
		/// </remarks>
		/// <returns></returns>
		public bool ExistUnexportedParam()
		{
			try 
			{
				return dao.ExistUnexportedParam();
			}
			catch (Exception ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
		}


		/// <summary>
		/// Zip file
		/// </summary>
		/// <remarks>
		/// Author			:	Nguyen Bao Nguyen G3
		/// Created day		:	24-Apr-2011
		/// </remarks>
		public void ZipFileParam(string strParamPath)
		{
			try 
			{
				//string strFileNameToEncode = "";
				string strZipFilename = "";
				string strPass = "";

				string strPath = strParamPath;
				string[] filenames = Directory.GetFiles(strPath, "*.xml");
				clsCryptography genPass = new clsCryptography();
		

				foreach (string file in filenames)
				{
					strZipFilename = file.Substring(0, file.Length -4)+".zip";
					//strFileNameToEncode = file.Substring(0, file.Length -4);
					strPass = genPass.GenPWDByFilename(strZipFilename);
					clsZip.ZipFiles(file, strZipFilename, strPass);
					File.Delete(file);
				}
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}
        // Author: TuanDH
        // Created Date: 02/07/2010
        public DayOfWeek GetFirstDayOfWeek()
        {
            string firstDayOfWeek = dao.GetFirstDayOfWeek();
            
            switch (firstDayOfWeek)
            {
                case "MON":
                    return DayOfWeek.Monday;
                case "TUE":
                    return DayOfWeek.Tuesday;
                case "WED":
                    return DayOfWeek.Wednesday;
                case "THU":
                    return DayOfWeek.Thursday;
                case "FRI":
                    return DayOfWeek.Friday;
                case "SAT":
                    return DayOfWeek.Saturday;
                case "SUN":
                    return DayOfWeek.Sunday;
            }
            
            return DayOfWeek.Monday;
        }

        // Author: TuanDH
        // Created Date: 02/07/2010
        public DayOfWeek GetEndDayOfWeek()
        {
            string endDayOfWeek = dao.GetEndDayOfWeek();

            switch (endDayOfWeek.ToUpper())
            {
                case "MON":
                    return DayOfWeek.Monday;
                case "TUE":
                    return DayOfWeek.Tuesday;
                case "WED":
                    return DayOfWeek.Wednesday;
                case "THU":
                    return DayOfWeek.Thursday;
                case "FRI":
                    return DayOfWeek.Friday;
                case "SAT":
                    return DayOfWeek.Saturday;
                case "SUN":
                    return DayOfWeek.Sunday;
            }

            return DayOfWeek.Sunday;
        }

        // Author: TuanDH
        // Created Date: 08/07/2010
        public int GetMaxDaysOfFirstWeek()
        {
            try
            {
                string maxDays = dao.GetMaxDaysOfFirstWeek();
                return int.Parse(maxDays);
            }
            catch
            {
                return 13;
            }
        }
	}
	
}
