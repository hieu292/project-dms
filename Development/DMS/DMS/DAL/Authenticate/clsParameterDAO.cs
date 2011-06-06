using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

using DMS.Utils;

namespace DMS.DataAccessObject
{
	/// <summary>
	/// Summary description for clsParameterDAO.
	/// </summary>
	public class clsParameterDAO:clsBaseDAO
	{
		private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsParameterDAO));
		public clsParameterDAO()
		{
			
		}
				
		public clsParameterDAO(SqlConnection con):base(con)
		{

		}
		/*******************************************************************************
		'Purpose      : nhan vao ten nhom Parameter, sau do tra ve 1 datatable chua cac Param cua nhom do
		'Author       : Nguyen Minh Khoa - Developer, FPTSS.
		'Created      : 28-Mar-2011 
		'******************************************************************************/
		public DataTable GetOne(string strParam_Group, string strParam)
		{
			SqlConnection con = Connection;
			if(con == null)
				throw new Exception(CONNECTION_ERROR);
            string strSql = "SELECT PARAM_NAME, PARAM_VALUE, PARAM_TYPE, DESCRIPTION FROM GENERAL_PARAMETERS WHERE PARAM_GROUP LIKE '{0}' AND (PARAM_NAME LIKE '%{1}%' OR DESCRIPTION LIKE '%{2}%')";
            strSql = string.Format(strSql,strParam_Group, strParam,strParam);
            SqlCommand cmd = new SqlCommand(strSql, con);

			try
			{
				DataTable dt = new DataTable();
				SqlDataAdapter m_DataAdapter = new SqlDataAdapter(cmd);
				m_DataAdapter.Fill(dt);
				return dt;
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
				MessageBox.Show(ex.ToString());
			}
			finally
			{
				if(con != null && con.State == ConnectionState.Open)
					con.Close();
			}
			return null;
		}
		
		/*******************************************************************************
		'Purpose      : nhan vao gia tri va ten cua param, sau do update DB dua vao 2 gia tri nay
		'Author       : Nguyen Minh Khoa - Developer, FPTSS.
		'Created      : 28-Mar-2011 
		'******************************************************************************/
		public bool UpdateValue(string Param_Value, string Param_Name)
		{
			bool blnsuccess = false;
			SqlConnection con = Connection;
			if(con == null)
				throw new Exception(CONNECTION_ERROR);
			if(con.State != ConnectionState.Open)
				con.Open();
			
			SqlCommand cmd = new SqlCommand("sp_UpdateParameter", con);
			cmd.CommandType = CommandType.StoredProcedure;

			cmd.Parameters.Add("@Param_Value", SqlDbType.VarChar);
			cmd.Parameters["@Param_Value"].Value = Param_Value;
			cmd.Parameters.Add("@Param_Name", SqlDbType.VarChar);
			cmd.Parameters["@Param_Name"].Value = Param_Name;

			try
			{
				cmd.ExecuteNonQuery();
				blnsuccess=true;
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
				MessageBox.Show(ex.ToString());
			}
			finally
			{
				if(con != null && con.State == ConnectionState.Open)
					con.Close();
			}
			return blnsuccess;
		}


		/// <summary>
		/// Get datatable contains RR_WEEKS and DEF_PPO_UPPER_ADJ_PER 
		/// and DEF_PPO_LOWER_ADJ_PER parameters 
		/// </summary>
		/// <remarks>
		/// Author:			Nguyen Bao Nguyen	G3
		/// Modified:		24-Apr-2011
		/// </remarks>
		/// <returns></returns>
		public string ExportParameter(string strRRWeek, string strMaxPPO, string strMinPPO)
		{
			string strPath = "";
			bool blnExport = true;
			try 
			{
				strPath = GetExportParamPath();
				if (strPath == "")
				{
					blnExport = false;
				}
				else 
				{
					if ( (!Directory.Exists(strPath)) && (strPath != "") )
					{
						Directory.CreateDirectory(strPath);
					}
					if ( (blnExport) && (strPath != "") )
					{
						//DungNDQ comment
						//xoa het file trong thu muc export parameter
//						#region Xoa file trong thu muc export
//						string[] files = Directory.GetFiles(strPath);
//						foreach (string file in files)
//						{
//							File.Delete(file);
//						}
//						#endregion
						//DungNDQ comment

						//get datatable chua cac parameter
						#region get datatable chua cac parameter
						
						string strFileName = strPath + "\\SCM" + "PARAM_"+DateTime.Now.ToString("yyyyMMdd")+".xml";
						DataSet dsParam = new DataSet("StockParameters");
						DataTable dtParam = new DataTable("StockParameters");
					
						DataTable dt = new DataTable();

						string strSql = "SELECT * FROM GENERAL_PARAMETERS WHERE PARAM_NAME = 'DEF_RR_WEEKS' OR PARAM_NAME = 'DEF_PPO_UPPER_ADJ_PER' OR PARAM_NAME = 'DEF_PPO_LOWER_ADJ_PER'";
						dt = GetDataTable(strSql);
						dt.TableName = "StockParameters";
						dt.Rows[0][0] = "PPO_LOWER_ADJ_PER";
						dt.Rows[1][0] = "PPO_UPPER_ADJ_PER";
						dt.Rows[2][0] = "RR_WEEKS";
						
						#endregion
						
						//add data table vao dataset
						dsParam.Tables.Add(dt);
						//xuat file xml
						dsParam.WriteXml(strFileName, System.Data.XmlWriteMode.WriteSchema);
						// doi status cua parameter tu 1 sang 0
						ChangeExportedStatus();
					}
				}
				return strPath;
			}
			catch (Exception ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
		}

		//-- tuannh2 added 20080822: export thong so cua nhung cust_code dat hang daily
		public string ExportDailyParameter(string Cust_Code, string strPath)
		{
			bool blnExport = true;
			try 
			{
				if (strPath == "")
				{
					blnExport = false;
				}
				else 
				{
					if ( (!Directory.Exists(strPath)) && (strPath != "") )
					{
						Directory.CreateDirectory(strPath);
					}
					if ( (blnExport) && (strPath != "") )
					{
						//get datatable chua cac parameter

                        string strFileName = strPath + "\\4408_VN001_" + Cust_Code + "_SCM-PRM-01_" + DateTime.Now.ToString("yyyyMMdd") + "_01" + ".xml";
						DataSet dsParam = new DataSet();
						DataTable dtParam = new DataTable();

						SqlParameter[] arrParam =  new SqlParameter[1];
						arrParam[0] = new SqlParameter();
						arrParam[0].ParameterName = "@CustCode";
						arrParam[0].SqlDbType = SqlDbType.VarChar;
						arrParam[0].Value = Cust_Code;

						dtParam = ExecuteQuerySp("sp_GetExportDailyParams", arrParam);
						
						//add data table vao dataset
						dsParam.Tables.Add(dtParam);
						//xuat file xml
						dsParam.WriteXml(strFileName, System.Data.XmlWriteMode.WriteSchema);
					}
				}
				return strPath;
			}
			catch (Exception ex)
			{
				log.Error(ex.Message, ex);
				throw ex;
			}
		} 
		//-- end tuannh2

		/// <summary>
		/// Get path to export Parameter
		/// </summary>
		/// <remarks>
		/// Author:			Nguyen Bao Nguyen	G3
		/// Modified:		24-Apr-2011
		/// </remarks>
		/// <returns></returns>
		public string GetExportParamPath()
		{
			string strWorkingDir = System.Environment.CurrentDirectory + "\\EXPORTED_PARAM";
			string strRetVal = "";
			string strSql = "SELECT PARAM_VALUE FROM GENERAL_PARAMETERS WHERE PARAM_NAME = 'DEF_PARAM_PATH'";
			SqlDataReader dr = GetSqlDataReader(strSql);
			if (dr.Read())
			{
				strRetVal = dr.GetValue(0).ToString();
				dr.Close();
			}
			else
			{
				dr.Close();
				strRetVal = "";
			}

			if ( (strRetVal == "") || ( !System.IO.Directory.Exists(strRetVal) ) )
			{
				if (MessageBox.Show(clsResources.GetMessage("messages.createfolderParam.confirm",strWorkingDir.ToUpper()), clsResources.GetMessage("messages.general"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
				{
					strRetVal = strWorkingDir.ToUpper();
				}
				else 
				{
					strRetVal = "";
				}
			}
			return strRetVal;
		}

		/// <summary>
		/// Get RR Weeks
		/// </summary>
		/// <remarks>
		/// Author:			Nguyen Bao Nguyen	G3
		/// Modified:		24-Apr-2011
		/// </remarks>
		/// <returns></returns>
		public string GetRR_Weeks()
		{
			string strRRWeek = "";
			SqlConnection con = Connection;
			SqlTransaction trans = null;
			SqlCommand cmd = new SqlCommand();
			try 
			{
				if (con.State != ConnectionState.Open)
					con.Open();
				trans = con.BeginTransaction();
				cmd.CommandText = "SELECT PARAM_VALUE FROM GENERAL_PARAMETERS WHERE PARAM_NAME = 'DEF_RR_WEEKS'";
				cmd.CommandTimeout = 0;
				cmd.Connection = con;
				cmd.Transaction = trans;
				strRRWeek = cmd.ExecuteScalar().ToString();
				trans.Commit();
				
				if (con.State != ConnectionState.Closed)
					con.Close();

				return strRRWeek;

			}
			catch (Exception ex)
			{
				log.Error(ex.Message, ex);
				if (trans != null)
					trans.Rollback();
				throw ex;
			}
		}

		/// <summary>
		/// Get lower permitted percentage to edit PPO
		/// </summary>
		/// <remarks>
		/// Author:			Nguyen Bao Nguyen	G3
		/// Modified:		24-Apr-2011
		/// </remarks>
		/// <returns></returns>
		public string GetLowerPPOAdjustPercentage()
		{
			string strPPO = "";
			SqlConnection con = Connection;
			SqlCommand cmd = new SqlCommand();
			SqlTransaction trans = null;
			try 
			{
				if (con.State != ConnectionState.Open)
					con.Open();
				trans = con.BeginTransaction();
				cmd.CommandText = "SELECT PARAM_VALUE FROM GENERAL_PARAMETERS WHERE PARAM_NAME = 'DEF_PPO_LOWER_ADJ_PER'";
				cmd.CommandTimeout = 0;
				cmd.Connection = con;
				cmd.Transaction = trans;
				strPPO = cmd.ExecuteScalar().ToString();
				trans.Commit();
				
				if (con.State != ConnectionState.Closed)
					con.Close();

				return strPPO;

			}
			catch (Exception ex)
			{
				log.Error(ex.Message, ex);
				if (trans != null)
					trans.Rollback();
				throw ex;
			}
		}


		/// <summary>
		/// Get upper permitted percentage to edit PPO
		/// </summary>
		/// <remarks>
		/// Author:			Nguyen Bao Nguyen	G3
		/// Modified:		24-Apr-2011
		/// </remarks>
		/// <returns></returns>
		public string GetUpperPPOAdjustPercentage()
		{
			string strPPO = "";
			SqlConnection con = Connection;
			SqlCommand cmd = new SqlCommand();
			SqlTransaction trans = null;
			try 
			{
				if (con.State != ConnectionState.Open)
					con.Open();
				trans = con.BeginTransaction();
				cmd.CommandText = "SELECT PARAM_VALUE FROM GENERAL_PARAMETERS WHERE PARAM_NAME = 'DEF_PPO_UPPER_ADJ_PER'";
				cmd.CommandTimeout = 0;
				cmd.Connection = con;
				cmd.Transaction = trans;
				strPPO = cmd.ExecuteScalar().ToString();
				trans.Commit();
				
				if (con.State != ConnectionState.Closed)
					con.Close();

				return strPPO;

			}
			catch (Exception ex)
			{
				log.Error(ex.Message, ex);
				if (trans != null)
					trans.Rollback();
				throw ex;
			}
		}

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
			bool blnExportedStatus = false;
			SqlConnection con = Connection;
			SqlCommand cmd = new SqlCommand();
			SqlTransaction trans = null;
			SqlDataReader dr = null;
			try 
			{
				if (con.State != ConnectionState.Open)
					con.Open();
				trans = con.BeginTransaction();
				cmd.CommandText = "SELECT STATUS FROM GENERAL_PARAMETERS WHERE PARAM_NAME = 'DEF_PPO_LOWER_ADJ_PER' OR PARAM_NAME = 'DEF_PPO_UPPER_ADJ_PER' OR PARAM_NAME = 'DEF_RR_WEEKS' ";
				cmd.CommandTimeout = 0;
				cmd.Connection = con;
				cmd.Transaction = trans;
				dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					if (dr.GetValue(0).ToString() == "1") 
					{
						blnExportedStatus = true;
						break;
					}
				}
				dr.Close();
				trans.Commit();
				
				if (con.State != ConnectionState.Closed)
					con.Close();

				return blnExportedStatus;

			}
			catch (Exception ex)
			{
				log.Error(ex.Message, ex);
				if (dr != null)
					dr.Close();
				if (trans != null)
					trans.Rollback();
				throw ex;
			}
		}

		/// <summary>
		/// Change Status of Stock Paramters
		/// </summary>
		/// <remarks>
		/// Author:			Nguyen Bao Nguyen	G3
		/// Modified:		24-Apr-2011
		/// </remarks>
		/// <returns></returns>
		public void ChangeExportedStatus()
		{
			SqlConnection con = Connection;
			SqlCommand cmd = new SqlCommand();
			SqlTransaction trans = null;
			try 
			{
				if (con.State != ConnectionState.Open)
					con.Open();
				trans = con.BeginTransaction();
				cmd.CommandText = "UPDATE GENERAL_PARAMETERS SET STATUS = '0' WHERE (PARAM_NAME = 'DEF_PPO_UPPER_ADJ_PER' OR PARAM_NAME = 'DEF_PPO_LOWER_ADJ_PER' OR PARAM_NAME = 'DEF_RR_WEEKS') AND STATUS = '1' ";
				cmd.CommandTimeout = 0;
				cmd.Connection = con;
				cmd.Transaction = trans;
				cmd.ExecuteScalar();
				
				trans.Commit();
				
				if (con.State != ConnectionState.Closed)
					con.Close();
			}
			catch (Exception ex)
			{
				log.Error(ex.Message, ex);
				if (trans != null)
					trans.Rollback();
				throw ex;
			}
		}

        // Author: TuanDH
        // Created Date: 02/07/2010
        public string GetFirstDayOfWeek()
        {
            string strSQL = "SELECT * FROM GENERAL_PARAMETERS WHERE Param_Name = 'DATE_OF_START_WEEK'";
            try
            {
                DataTable dt = this.GetDataTable(strSQL);

                return dt.Rows[0]["Param_Value"].ToString();
            }
            catch (Exception ex)
            {
				log.Error(ex.Message, ex);
				throw ex;
            }
        }

        // Author: TuanDH
        // Created Date: 02/07/2010
        public string GetEndDayOfWeek()
        {
            string strSQL = "SELECT * FROM GENERAL_PARAMETERS WHERE Param_Name = 'DATE_OF_END_WEEK'";
            try
            {
                DataTable dt = this.GetDataTable(strSQL);

                return dt.Rows[0]["Param_Value"].ToString();
            }
            catch (Exception ex)
            {
				log.Error(ex.Message, ex);
				throw ex;
            }
        }

        // Author: TuanDH
        // Created Date: 08/07/2010
        public string GetMaxDaysOfFirstWeek()
        {
            string strSQL = "SELECT * FROM GENERAL_PARAMETERS WHERE Param_Name = 'MAX_DAYS_OF_FIRST_WEEK'";
            try
            {
                DataTable dt = this.GetDataTable(strSQL);

                return dt.Rows[0]["Param_Value"].ToString();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                throw ex;
            }
        }
	}
}
