using System;
using System.Data;
using System.Data.SqlClient;
using log4net;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Diagnostics;
using System.Configuration;

using DMS.Presentation;
using DMS.ValueObject;

namespace DMS.Utils
{
    public enum PPOType
    {
        Weekly = 0,
        Daily = 1
    }

	/// <summary>
	/// Summary description for Common.
	/// </summary>
	/// <remarks>
	/// Author:			PhatLT. FPTSS.
	/// Created date:	14/02/2011
	/// </remarks>
	public class clsCommon
	{
		private static log4net.ILog log = LogManager.GetLogger(typeof(clsCommon));
		public clsCommon()
		{
			string strBrush = ConfigurationManager.AppSettings["WriteArea"];
			switch (strBrush)
			{
				case "LemonChiffon":
					brColor = new SolidBrush(Color.LemonChiffon);
					break;
				case "OrangeRed":
					brColor = new SolidBrush(Color.OrangeRed);
					break;
				case "Tomato":
					brColor = new SolidBrush(Color.Tomato);
					break;
				case "SkyBlue":
					brColor = new SolidBrush(Color.SkyBlue);
					break;				
				default:
					brColor = new SolidBrush(Color.Moccasin);
					break;
			}
		} 
		//public static Brush brColor = new SolidBrush(Color.LemonChiffon);
		public static Brush brColor = new SolidBrush(Color.Moccasin);
		public static Brush txtColor = new SolidBrush(Color.DarkBlue);
		#region Window Control Utilities
		//Region Window Control Utilities use static methods

		/// <summary>
		/// Remove all toolbar
		/// </summary>
		/// <param name="frm"></param>
		/// <remarks>
		/// Author		:	PhatLT G3
		/// Created day	:	04/10/2011
		/// </remarks>
		public static void RemoveAllToolBar(Form frm)
		{
			ToolBar tb = null;
			foreach(Control ctrl in frm.Controls)
			{
				tb = ctrl as ToolBar;
				if(tb != null)
				{
					frm.Controls.Remove(tb);
					tb.Dispose();
				}
			}

            ToolStrip tbStr = null;
            foreach (Control ctrl in frm.Controls)
            {
                tbStr = ctrl as ToolStrip;
                if (tbStr != null)
                {
                    frm.Controls.Remove(tbStr);
                    tbStr.Dispose();
                }
            }
		}

        /// <summary>
        /// Remove all toolbar
        /// </summary>
        /// <param name="frm"></param>
        /// <remarks>
        /// Author		:	PhatLT
        /// Created day	:	2010-11-25
        /// </remarks>
        public static void SetBackgroundButton(Form frm, string fromName)
        {
            int ex = 0;
            DotNetSkin.SkinControls.SkinButton bt = null;
            GroupBox grBox = null;
            DotNetSkin.SkinControls.SkinButton btOF = null;
            Label lbl = null;
            Label lblOF = null;
            MenuStrip ms = null;
            DataGrid dtGV = null;
            //DataGridViewCellStyle dtGVCS = null;
            foreach (Control ctrPar in frm.Controls)
            {
                grBox = ctrPar as GroupBox;               
                if (grBox != null)
                {
                    ex = grBox.Location.X;
                    foreach (Control ctrl in grBox.Controls)
                    {
                        lbl = ctrl as Label;
                        if (lbl != null)
                        {
                            lbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        }
                        bt = ctrl as DotNetSkin.SkinControls.SkinButton;
                        if (bt != null)
                        {
                            bt.Stardard = true;
                            bt.FlatStyle = FlatStyle.Popup;
                            bt.FlatAppearance.BorderSize = 1;
                            bt.FlatAppearance.BorderColor = Color.Red;
                            bt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            bt.ForeColor = SystemColors.Highlight;
                            //bt.Size = new Size(75, null);
                        }
                    }
                }
                
                // Button
                btOF = ctrPar as DotNetSkin.SkinControls.SkinButton;
                if (btOF != null)
                {
                    btOF.Stardard = true;
                    btOF.FlatStyle = FlatStyle.Popup;
                    btOF.FlatAppearance.BorderSize = 1;
                    btOF.FlatAppearance.BorderColor = Color.Red;
                    btOF.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btOF.ForeColor = SystemColors.Highlight;
                    //bt.Size = new Size(75,);
                }
                lblOF = ctrPar as Label;
                if (lblOF != null)
                {
                    lblOF.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                ms = ctrPar as MenuStrip;
                if (ms != null) {
                    ms.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                dtGV = ctrPar as DataGrid;
                if (dtGV != null) {
                    dtGV.ForeColor = Color.Blue;
                    //dtGVCS.ForeColor = Color.Blue;
                }

            }           

            //Label lb = new Label();
            //lb.Text = fromName;
            //lb.BackColor = Color.FromArgb(192, 255, 255);
            //lb.ForeColor = Color.White;
            
            //// lb.Location.X = ex;
            //frm.Controls.Add(lb);
        }
		/// <summary>
		/// Register the control that user only input number
		/// </summary>
		/// <param name="control"></param>
		/// <remarks>
		/// Author		:	PhatLT G3
		/// Created day	:	04/10/2011
		/// </remarks>
		public static void RegNumberOnly(Control control)
		{
			control.KeyPress+=new KeyPressEventHandler(Control_OnKeyPress);
		}

		/// <summary>
		/// Register the control that user only input positive numeric
		/// </summary>
		/// <param name="control"></param>
		/// <remarks>
		/// Created: ThienDLV	22/10/2007
		/// </remarks>
		public static void RegPosNumericOnly(Control control)
		{
			control.KeyPress+=new KeyPressEventHandler(Control_OnKeyPress_PosNumeric);
		}

		/// <summary>
		/// Handle the control that user only input number
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Author		:	PhatLT G3
		/// Created day	:	04/10/2011
		/// </remarks>
		private static void Control_OnKeyPress(object sender, KeyPressEventArgs e)
		{
			char chr = e.KeyChar;
			if (!(chr >= '0' && chr <= '9' || chr == 8 || chr == 13 || chr == ';'))
				e.Handled = true;
		}

		/// <summary>
		/// Handle the control that user only inputs positive numeric
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Created: ThienDLV	22/10/2007
		/// </remarks>
		private static void Control_OnKeyPress_PosNumeric(object sender, KeyPressEventArgs e)
		{
			string s = ((TextBox)sender).Text;
			char chr = e.KeyChar;
			if (!(chr >= '0' && chr <= '9' || chr == 8 || chr == 13 || chr == '.'))
			{
				e.Handled = true;
			}
			else
			{
				s += chr.ToString();
				if (chr == '.')
					try
					{
						Convert.ToDouble(s + "0");
					}
					catch
					{
						e.Handled = true;
					}
			}
		}
		
		/// <summary>
		/// Register the data grid that auto resize column width
		/// </summary>
		/// <param name="grd"></param>
		/// <remarks>
		/// Author		:	PhatLT G3
		/// Created day	:	04/10/2011
		/// </remarks>
		public static void RegAutoSizeCol(DataGrid grd)
		{
			DataGrid_Resize(grd, null);
            //Thanhnq comment: fix loi maximize man hinh thi mo man hinh khac bi loi.
            //grd.Resize -=new EventHandler(DataGrid_Resize);	
            //grd.Resize +=new EventHandler(DataGrid_Resize);			
		}

		/// <summary>
		/// Handle the data grid that auto resize column width
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Author		:	PhatLT G3
		/// Created day	:	04/10/2011
		/// </remarks>
		private static void DataGrid_Resize(object sender, EventArgs e)
		{
			if(sender == null)
				return;

			DataGrid grd = (DataGrid)sender;

//			DataGridTableStyle grdStyle = grd.TableStyles[0];
//			if(grdStyle == null || grdStyle.GridColumnStyles == null || grdStyle.GridColumnStyles.Count == 0)
//				return;

			grd.BeginInit();

			foreach(DataGridTableStyle grdStyle in grd.TableStyles)
			{

				int width = grd.Width - 56;//53;//real is 56

				GridColumnStylesCollection cols = grdStyle.GridColumnStyles;

				//calculate total of col
				int oldwidth = 0;
				foreach(DataGridColumnStyle col in cols)
				{
					oldwidth = oldwidth + col.Width;
				}

				if(oldwidth == 0)
					return;

				int count = grdStyle.GridColumnStyles.Count;

				double scale = 1.0*width/oldwidth;
				foreach(DataGridColumnStyle col in cols)
				{
					if(col.Width != 0)
						col.Width = (int)(col.Width * scale);
				}

			}

			grd.EndInit();

		}


		/// <summary>
		/// Add week to ComboBox
		/// </summary>
		/// <param name="cbo"></param>
		/// <remarks>
		/// Author		:	PhatLT G3
		/// Created day	:	04/10/2011
		/// </remarks>
		public static void AddWeekToCombo(ComboBox cbo)
		{
			cbo.Items.Add("");
			for(int week = 1; week <= 52; week ++)
			{
				//cbo.Items.Add(week.ToString().PadLeft(2, '0'));				
				cbo.Items.Add(week.ToString());
			}
			cbo.MaxDropDownItems = 18;
		}

		/// <summary>
		/// Add year to ComboBox
		/// </summary>
		/// <param name="cbo"></param>
		/// <remarks>
		/// Author		:	PhatLT G3
		/// Created day	:	04/10/2011
		/// </remarks>
		public static void AddYearToCombo(ComboBox cbo)
		{
			//DateTime date = new DateTime();  DucND comment
			int year = DateTime.Now.Year;
			year = year - 2 ;
			cbo.Items.Add("");
			for(int i = 0; i < 5; i ++)
			{
				cbo.Items.Add(year.ToString().PadLeft(4, '0'));
				year ++ ;
			}
		}

		/// <summary>
		/// Load all regions
		/// </summary>
		/// <param name="cbo"></param>
		/// <remarks>
		/// Author		:	ThienDLV
		/// Created day	:	26/10/2007
		/// </remarks>
		/// <summary>
		/// Load all regions
		/// </summary>
		public static DataTable LoadRegions()
		{
			string strConn = clsCommon.GetConnectionString();
			string strSql = "SELECT REGION_CODE, REGION_NAME FROM SCM_REGION_HIERARCHY";
			try
			{
				return SqlHelper.ExecuteDataset(strConn,CommandType.Text,strSql).Tables[0];
			}
			catch(SqlException ex)
			{
				log.Error(ex.Message,ex);
				//MessageBox.Show(ex.Message);
				return null;
			}
		}

		#endregion

		#region Hilight DataGrid (Rows and colums)
		
		/// <summary>
		/// Hiligh column of table that they can Edit
		/// </summary>
		/// <param name="dt">int put a ref parameter</param>
		/// <remarks>
		/// Auther		: Cuongvd G3 Fsoft HCM
		/// created day	: 17/01/207
		/// </remarks>
		public  void HilighColumn(ref DataGrid grd, System.Drawing.Color color)
		{
			if(grd.TableStyles[0].GridColumnStyles.Count <= 0)
				return;
			DataGridTableStyle grdNew = new DataGridTableStyle();
			
			for(int i =0;i < grd.TableStyles[0].GridColumnStyles.Count; i++)
			{
				if(grd.TableStyles[0].GridColumnStyles[i].ReadOnly == false && (grd.TableStyles[0].GridColumnStyles[i] is DataGridTextBoxColumn) )
				{
					DataGridTextBoxColumn colTextBox = (DataGridTextBoxColumn)grd.TableStyles[0].GridColumnStyles[i];
					FormattableTextBoxColumn colAdd = new FormattableTextBoxColumn();
					colAdd.MappingName = grd.TableStyles[0].GridColumnStyles[i].MappingName;
					colAdd.Width = grd.TableStyles[0].GridColumnStyles[i].Width;
					colAdd.ReadOnly = false;
					colAdd.TextBox.MaxLength = colTextBox.TextBox.MaxLength;
					RegNumberOnly(colAdd.TextBox);
					colAdd.NullText = "";
					colAdd.HeaderText = grd.TableStyles[0].GridColumnStyles[i].HeaderText;
					colAdd.SetCellFormat += new FormatCellEventHandler(SetHeaderCellFormat);
					//arlCol.Add(colAdd);
					grdNew.GridColumnStyles.Add(colAdd);
				}
				else
					if(grd.TableStyles[0].GridColumnStyles[i] is DataGridBoolColumn)
				{
					DataGridBoolColumn colBool = (DataGridBoolColumn)grd.TableStyles[0].GridColumnStyles[i];
					FormattableBooleanColumn colBoolAdd = new FormattableBooleanColumn();
					colBoolAdd.MappingName = colBool.MappingName;
					colBoolAdd.ReadOnly = false;
					colBoolAdd.TrueValue = colBool.TrueValue;;
					colBoolAdd.FalseValue =colBool.FalseValue;;
					colBoolAdd.AllowNull = colBool.AllowNull;
					colBoolAdd.HeaderText = colBool.HeaderText;
					colBoolAdd.SetCellFormat += new FormatCellEventHandler(SetHeaderCellFormat);
					//arlCol.Add(colBoolAdd);
					grdNew.GridColumnStyles.Add(colBoolAdd);
				}
				else
					grdNew.GridColumnStyles.Add(grd.TableStyles[0].GridColumnStyles[i]);
				//arlCol.Add(grd.TableStyles[0].GridColumnStyles[i]);
			}
			grdNew.HeaderBackColor = grd.TableStyles[0].HeaderBackColor;
			grdNew.AlternatingBackColor = grd.TableStyles[0].AlternatingBackColor;
			grd.TableStyles.RemoveAt(0);
			grd.TableStyles.Add(grdNew);

			//			foreach(object ojb in arlCol)
			//			{
			//				grd.TableStyles[0].GridColumnStyles.Add(ojb);
			//			}
		}
		/// <summary>
		/// Overload 2 Cuongvd
		/// Without color
		/// </summary>
		/// <param name="grd"></param>
		/// 
		public  void HilighColumn(ref DataGrid grd)
		{
			if(grd.TableStyles[0].GridColumnStyles.Count <= 0)
				return;
			DataGridTableStyle grdNew = new DataGridTableStyle();
			
			for(int i =0;i < grd.TableStyles[0].GridColumnStyles.Count; i++)
			{
				if(grd.TableStyles[0].GridColumnStyles[i].ReadOnly == false && (grd.TableStyles[0].GridColumnStyles[i] is DataGridTextBoxColumn) )
				{
					DataGridTextBoxColumn colTextbox = (DataGridTextBoxColumn)grd.TableStyles[0].GridColumnStyles[i];
					FormattableTextBoxColumn colAdd = new FormattableTextBoxColumn();
					colAdd.MappingName = grd.TableStyles[0].GridColumnStyles[i].MappingName;
					colAdd.ReadOnly = false;
					colAdd.TextBox.MaxLength = colTextbox.TextBox.MaxLength;
					colAdd.NullText = colTextbox.NullText;
					clsCommon.RegNumberOnly(colAdd.TextBox);
					colAdd.HeaderText = grd.TableStyles[0].GridColumnStyles[i].HeaderText;
					colAdd.SetCellFormat += new FormatCellEventHandler(SetHeaderCellFormat);
					//arlCol.Add(colAdd);
					grdNew.GridColumnStyles.Add(colAdd);


				}
				else
					if(grd.TableStyles[0].GridColumnStyles[i] is DataGridBoolColumn)
				{
					DataGridBoolColumn colBool = (DataGridBoolColumn)grd.TableStyles[0].GridColumnStyles[i];
					FormattableBooleanColumn colBoolAdd = new FormattableBooleanColumn();
					colBoolAdd.MappingName = colBool.MappingName;
					colBoolAdd.ReadOnly = false;
					colBoolAdd.TrueValue = colBool.TrueValue;;
					colBoolAdd.FalseValue =colBool.FalseValue;
					colBoolAdd.AllowNull = colBool.AllowNull;
					colBoolAdd.HeaderText = colBool.HeaderText;
					colBoolAdd.SetCellFormat += new FormatCellEventHandler(SetHeaderCellFormat);
					grdNew.GridColumnStyles.Add(colBoolAdd);
				}
				else
					grdNew.GridColumnStyles.Add(grd.TableStyles[0].GridColumnStyles[i]);
			}
			grdNew.HeaderBackColor = grd.TableStyles[0].HeaderBackColor;
			grd.TableStyles.Clear();
			grd.TableStyles.Add(grdNew);
		}
		/// <summary>
		/// for evnet change backcolor
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Created by	: cuongvd G3 fsoftHCM
		/// create date	: 18-jan-2007
		/// </remarks>
		private  void SetHeaderCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				e.BackBrush = brColor;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		#endregion
		#region Bind control to Solomon style. Ex: Press F3 to select product

		#endregion Bind control to Solomon style. Ex: Press F3 to select product

		/// <summary>
		/// Kill Excel process that created by SCM
		/// </summary>
		/// <param name="preExcelProcesses"></param>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public void KillProcess(Process[]preExcelProcesses)
		{
			Process[] excelProcesses = Process.GetProcessesByName("EXCEL");
			foreach(Process process in excelProcesses)
			{
				if(!Contain(preExcelProcesses, process))
				{
					process.Kill();
				}
			}
		}

		public static int GetWeek(DateTime dtm)
		{
			System.Globalization.GregorianCalendar gCalendar = new System.Globalization.GregorianCalendar();
			return gCalendar.GetWeekOfYear(dtm, System.Globalization.CalendarWeekRule.FirstDay, System.DayOfWeek.Monday);
		}

		/// <summary>
		/// Check whether processes contains process
		/// </summary>
		/// <param name="processes"></param>
		/// <param name="process"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		private bool Contain(Process[] processes, Process process)
		{
			foreach(Process p in processes)
			{
				if(p.Id == process.Id)
					return true;
			}
			return false;
		}

		/// <summary>
		/// Get Header Title and Index of table of DataGridTableStyle
		/// </summary>
		/// <param name="view"></param>
		/// <param name="cols"></param>
		/// <param name="headers"></param>
		/// <param name="indexes"></param>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public void GetExportInfo(DataView view, GridColumnStylesCollection cols, ref string[]headers, ref int [] indexes)
		{
			int count = cols.Count;
			headers = new string[count];
			indexes = new int[count];
			DataTable dt = view.Table;

			for(int i = 0; i < count; i ++)
			{
				headers[i] = cols[i].HeaderText;
				indexes[i] = GetColumnIndex(dt, cols[i].MappingName);
			}
		}

		/// <summary>
		/// Parse string to int
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int GetInt(string value)
		{
			try
			{
				int i = int.Parse(value);
				return i;
			}
			catch
			{
				return 0;
			}
		}

		/// <summary>
		/// Check whether the email is valid.
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public bool IsEmail(string email) 
		{
			email = email.Trim();
			if (email == null || email.Length < 5) 
			{
				return false;
			}
			int index = email.IndexOf('@');
			if (email.IndexOf('@', index + 1) >= 0) 
			{
				return false;
			}
			if (index < 1 || index >= email.Length - 3) 
			{
				return false;
			}
			index = email.IndexOf('.', index + 2);
			if (index < 0 || index >= email.Length - 1) 
			{
				return false;
			}

			int length = email.Length;
			for (int i = 0; i < length; i++) 
			{
				if (!IsValidCharMail(email[i])) 
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Check whether the string just contain character and number.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public bool IsLetterAndDigit(string value)
		{
			foreach(char chr in value)
			{
				if(!char.IsLetterOrDigit(chr))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Check whether this character is a valid email character.
		/// </summary>
		/// <param name="chr"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public bool IsValidCharMail(char chr) 
		{
			if ((chr >= 'A' && chr <= 'Z') || (chr >= 'a' && chr <= 'z')
				|| (chr >= '0' && chr <= '9') || chr == '.' || chr == '@'
				|| chr == '-' || chr == '_') 
			{
				return true;
			} 
			else 
			{
				return false;
			}
		}
		/// <summary>
		/// Parse string to double
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public double GetDouble(string value)
		{
			try
			{
				double i = double.Parse(value);
				return i;
			}
			catch
			{
				return 0;
			}
		}

		/// <summary>
		/// Clear errors of all DataRows of DataTable
		/// </summary>
		/// <param name="dt"></param>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public void ClearErrors(DataTable dt)
		{
			if(dt == null)
				return;

			foreach(DataRow row in dt.Rows)
				row.ClearErrors();
		}
		/// <summary>
		/// check whether the value just contains the number character.
		/// </summary>
		/// <remarks>
		/// Author		:	PhatLT G3
		/// Created day	:	04/10/2011
		/// </remarks>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public bool IsOnlyContainNumber(string value)
		{
			foreach(char chr in value)
			{
				if(!char.IsNumber(chr))
					return false;
			}
			return true;
		}

		public static bool IsNumeric(string s)
		{
			try
			{
				Convert.ToInt32(s);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static int StringToInt(string value)
		{
			try
			{
				return Convert.ToInt32(value);
			}
			catch
			{
				return 0;
			}
		}

		/// <summary>
		/// Select distinct valuemember From a DataTable
		/// </summary>
		/// <remarks>
		/// Author		:	PhatLT G3
		/// Created day	:	04/10/2011
		/// </remarks>
		/// <param name="dt"></param>
		/// <param name="ValueMember"></param>
		/// <param name="DisplayMember"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public DataTable GetDistict(DataTable dt, string ValueMember, string DisplayMember)
		{
			DataTable dtDistinct = new DataTable();

			if(ValueMember == DisplayMember)
			{
				dtDistinct.Columns.Add(ValueMember, dt.Columns[ValueMember].GetType());

				int count = dt.Rows.Count;
				if(count == 0) return dtDistinct;

				DataView view = new DataView(dt);
				view.Sort = DisplayMember;
			
				DataRow row = dtDistinct.NewRow();
				row[ValueMember] = view[0][ValueMember];
				dtDistinct.Rows.Add(row);

				for(int i = 1; i < count; i ++ )
				{
					if(!view[i][ValueMember].Equals(view[i-1][ValueMember]))
					{
						row = dtDistinct.NewRow();
						row[ValueMember] = view[i][ValueMember];
						dtDistinct.Rows.Add(row);
					}
				}
			}
			else
			{
				dtDistinct.Columns.Add(ValueMember, dt.Columns[ValueMember].GetType());
				dtDistinct.Columns.Add(DisplayMember, dt.Columns[DisplayMember].GetType());

				int count = dt.Rows.Count;
				if(count == 0) return dtDistinct;

				DataView view = new DataView(dt);
				view.Sort = DisplayMember;
			
				DataRow row = dtDistinct.NewRow();
				row[ValueMember] = view[0][ValueMember];
				row[DisplayMember] = view[0][DisplayMember];
				dtDistinct.Rows.Add(row);

				for(int i = 1; i < count; i ++ )
				{
					if(!view[i][ValueMember].Equals(view[i-1][ValueMember]))
					{
						row = dtDistinct.NewRow();
						row[ValueMember] = view[i][ValueMember];
						row[DisplayMember] = view[i][DisplayMember];
						dtDistinct.Rows.Add(row);
					}
				}
			}
			
			return dtDistinct;
		}

		/// <summary>
		/// format datetime
		/// </summary>
		/// <param name="date">format YYYYMMDD</param>
		/// <returns>format MM/DD/YYYY</returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public string FormatDate(string date)
		{
			if(date == null || date.Length != 8)
				return date;

			string year = date.Substring(0, 4);
			string month = date.Substring(4, 2);
			string day = date.Substring(6, 2);

			return day + "/" + month  + "/" + year;
		}
		/// <summary>
		/// Vu Dinh Cuong G3
		/// 24/01/2007
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static string FormatddMMyyy(DateTime date)
		{
//			if(date == null )//|| date.Length != 8)
//				return "01/01/1900";
			string year= "";
			string month = "";string day ="";
			try
			{
				year = date.Year.ToString();
				month = date.Month.ToString();
				day = date.Day.ToString();
			}
			catch(Exception ex){
				log4net.Util.LogLog.Error(ex.Message,ex);
			}
			if(day.Length <2)
				day = "0" + day;
			if(month.Length<2)
				month = "0" + month;
			return day + "/" + month  + "/" + year;
		}

		/// <summary>
		/// Change string date format "DD/MM/YYYY" to format "YYYYMMDD"
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Bao Nguyen G3
		/// Modified:	17-Apr-2011
		/// </remarks>
		/// <param name="date"></param>
		/// <returns></returns>
		public string GetDateYMD(string date)
		{
			if(date == null || date.Length != 10)
				return "";

			string year = date.Substring(6, 4);
			string month = date.Substring(3, 2);
			string day = date.Substring(0, 2);

			return year + month + day;
		}

		/// <summary>
		/// Replace ' by ''
		/// </summary>
		/// <remarks>
		/// Author		:	PhatLT G3
		/// Created day	:	04/10/2011
		/// </remarks>
		/// <param name="value"></param>
		/// <returns></returns>
		public string EncodeString(string value)
		{
			if(value == null || value.Length == 0)
				return value;
            return value.Replace("'", "''").Replace("?", "[?]").Replace("%", "[%]").Replace("_", "[_]");
		}

		/// <summary>
		/// replace ' by '', * by %, ? by _
		/// </summary>
		/// <param name="keyword"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public string EncodeKeyword(string keyword)
		{
			if(keyword == null || keyword.Length == 0)
				return "";
			keyword = keyword.Replace("'", "''");
			keyword = keyword.Replace("?", "_");
			if (keyword[0] == '*')
			{
				keyword = keyword.Replace('*', '%');
			}
			keyword = keyword + "%";
			return keyword;
		}

		/// <summary>
		/// Get column index by column name
		/// </summary>
		/// <param name="dt"></param>
		/// <param name="colName"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int GetColumnIndex(DataTable dt, string colName)
		{
			int i = 0;
			foreach(DataColumn col in dt.Columns)
			{
				if(col.ColumnName == colName)
					return i;
				i ++;
			}
			return -1;
		}

		public clsPromotionWeek [] GetActiveWeeks(clsPromotionWeek []proWeeks)
		{
			ArrayList arrs = new ArrayList();
			foreach(clsPromotionWeek proWeek in proWeeks)
			{
				if(proWeek.IsActive)
				{
					arrs.Add(proWeek);
				}
			}

			int length = proWeeks.Length;

			int i = 0;

			clsPromotionWeek[] values = new clsPromotionWeek[length];
			foreach(clsPromotionWeek proWeek in arrs)
			{
				values[i] = proWeek;
				i ++;
			}
			return values;
		}

		/// <summary>
		/// Get index of the first week
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int GetFirstWeek(DataTable dt)
		{
			int i = 0;
			foreach(DataColumn col in dt.Columns)
			{
				if(col.ColumnName.StartsWith("WEEK"))
				{
					return i;
				}
				i++;
			}
			return -1;
		}

		/// <summary>
		/// Get the index of first active week
		/// </summary>
		/// <param name="proWeeks"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			PhatLT. FPTSS.
		/// Created date:	14/02/2011
		/// </remarks>
		public int GetActiveWeekFrom(clsPromotionWeek []proWeeks)
		{
			int iActiveFrom = -1;
			int i = 0;
			foreach(clsPromotionWeek proWeek in proWeeks)
			{
				if(iActiveFrom == -1 && proWeek.IsActive)
				{
					iActiveFrom = i;
					return iActiveFrom;
				}

				i ++;
			}
			return proWeeks.Length;
		}

		public static string GetConnectionString()
		{
            string strConnection = ConfigurationManager.ConnectionStrings["DMS"].ConnectionString;
            strConnection = strConnection.Replace("Data Source=", "Server=");
            strConnection = strConnection.Replace("Initial Catalog=", "DataBase=");
            strConnection = strConnection.Replace("User ID=", "user=");
            strConnection = strConnection.Replace("Password=", "password=");
            strConnection = strConnection.Replace(";User Instance=False", "");
            strConnection = strConnection.Replace(";User Instance=True", "");
            return strConnection;
		}

		public static bool ZipFile(string path)
		{
			try 
			{
				//ten file zip
				string strZipFilename = "";
				//password
				string strPass = "";
				//duong dan file xml can zip
				string[] filenames = System.IO.Directory.GetFiles(path, "*.xml");
				clsCryptography genPass = new clsCryptography();
		
				foreach (string file in filenames)
				{
					//lay file nam xml , thay extension thang .zip
					strZipFilename = file.Substring(0, file.Length -4) + ".zip";
					//generate password
					strPass = genPass.GenPWDByFilename(strZipFilename);
					//zip file
					clsZip.ZipFiles(file, strZipFilename, strPass);
					//xoa file xml sau khi da zip xong
					System.IO.File.Delete(file);
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
		#region - Prevent Special charater, Numberic -
		private static void ControlOnKeyPress(object sender, KeyPressEventArgs e)
		{
			char chr = e.KeyChar;
			if (!((chr >= 'A' && chr <= 'Z') || (chr >= 'a' && chr <= 'z')|| chr == 8 || chr == 13))
				e.Handled = true;
		}


		public static void RegCharater(Control control)
		{
			control.KeyPress+=new KeyPressEventHandler(ControlOnKeyPress);
		}

		#endregion

        //Duylnk 02-11-2009 Created:
        public static int GetCurrentULVWeek()
        {
            try
            {
                string strCurrentDate = DateTime.Now.ToString("yyyyMMdd");
                string cmdText = "SELECT CLM_CYCLE FROM SCM_CALENDAR_MASTER WHERE CLM_TYPE = 'W' AND " + strCurrentDate + " BETWEEN CLM_START_DATE AND CLM_END_DATE";

                //			StreamWriter sw = new StreamWriter("D:\\abc.txt");
                //			sw.Write(cmdText);
                //			sw.Close();
                SqlConnection con = DataAccessObject.clsBaseDAO.Connection;
                SqlCommand cmd = new SqlCommand(cmdText, con);
                if(con.State != ConnectionState.Open)
                    con.Open();
                return int.Parse(cmd.ExecuteScalar().ToString());                
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
                throw ex;
            }
        }

        public static int GetCurrentULVYear()
        {
            try
            {
                string strCurrentDate = DateTime.Now.ToString("yyyyMMdd");
                string cmdText = "SELECT CLM_YEAR FROM SCM_CALENDAR_MASTER WHERE CLM_TYPE = 'W' AND " + strCurrentDate + " BETWEEN CLM_START_DATE AND CLM_END_DATE";
                SqlConnection con = DataAccessObject.clsBaseDAO.Connection;
                SqlCommand cmd = new SqlCommand(cmdText, DataAccessObject.clsBaseDAO.Connection);
                if (con.State != ConnectionState.Open)
                    con.Open();
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                throw ex;
            }
        }
        //end Duylnk 02-11-2009 Created:

        /// <summary>
        /// Kiem tra co phai la kieu decimal?
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDecimal(string s)
        {
            try
            {
                Convert.ToDecimal(s);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Kiem tra co phai la kieu ngay ?
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDate(string s)
        {
            try
            {
                Convert.ToDateTime(s);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// purpose: prevent character special in string SQL
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string FormatingCharacter(string strText)
        {
            return strText.Trim().Replace("'", "^").Replace("%", "[%]").Replace("_", "[_]").Replace("?", "[?]");
        }

        /// <summary>
        /// Convert string to decimal
        /// </summary>
        /// <param name="value">string</param>
        /// <returns>decimal</returns>
        public static decimal StringToDecimal(string value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return 0;
            }
        }

        //++PhatLT Add
        public static void SetNumberGrid(DataGrid datagrid)
        {
            DataTable dt = datagrid.DataSource as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int j = i+1;
                dt.Rows[i]["NO"] = j.ToString(); 
            }
        }
        public static void CheckID(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '_')
            {
                e.Handled = false;
            }
        }
        public static bool CheckID(string id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                if (!Char.IsDigit(id[i]) && !Char.IsLetter(id[i]) && id[i]!= '_')
                {
                    return false;
                }
            }
            return true;
        }
        public static void CheckNumber(KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public static bool CheckCombobox(string item, string[] list, bool allowblank)
        {
            if (allowblank && item == "")
                return true;
            for (int i = 0; i < list.Length; i++)
            {
                if (item == list[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckCombobox(ComboBox cb, bool allowblank)
        {
            if (allowblank && cb.Text == "")
                return true;
            for (int i = 0; i < cb.Items.Count; i++)
            {
                if (cb.Text == cb.Items[i].ToString())
                {
                    return true;
                }
            }
            DataTable dt = cb.DataSource as DataTable;
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (cb.Text == dr[cb.DisplayMember].ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static string DonotAllowVietnamese(string str)
        {
            string temp = "";
            for (int i = 0; i < str.Length; i++)
            {
                string letter = str.Substring(i, 1);
                if (letter == "Á" || letter == "Â" || letter == "Ă" || letter == "À"
                    || letter == "Ả" || letter == "Ã" || letter == "Ạ"
                    || letter == "Ấ" || letter == "Ậ" || letter == "Ầ" || letter == "Ẩ" || letter == "Ẫ"
                    || letter == "Ắ" || letter == "Ằ" || letter == "Ẳ" || letter == "Ẫ" || letter == "Ặ")
                {
                    letter = "A";
                }
                else if (letter == "á" || letter == "â" || letter == "ă" || letter == "à"
                    || letter == "ả" || letter == "ã" || letter == "ạ"
                    || letter == "ấ" || letter == "ậ" || letter == "ầ" || letter == "ẩ" || letter == "ẫ"
                    || letter == "ắ" || letter == "ằ" || letter == "ẳ" || letter == "ẵ" || letter == "ặ")   
                {
                    letter = "a";
                }
                else if (letter == "Ó" || letter == "Ô" || letter == "Ơ" || letter == "Ò"
                   || letter == "Ỏ" || letter == "Õ" || letter == "Ọ"
                   || letter == "Ố" || letter == "Ộ" || letter == "Ồ" || letter == "Ổ" || letter == "Ỗ"
                   || letter == "Ớ" || letter == "Ờ" || letter == "Ở" || letter == "Ỡ" || letter == "Ợ")
                {
                    letter = "O";
                }
                else if (letter == "ó" || letter == "ô" || letter == "ơ" || letter == "ò"
                  || letter == "ỏ" || letter == "õ" || letter == "ọ"
                  || letter == "ố" || letter == "ộ" || letter == "ồ" || letter == "ổ" || letter == "ỗ"
                  || letter == "ớ" || letter == "ờ" || letter == "ở" || letter == "ỡ" || letter == "ợ")
                {
                    letter = "o";
                }
                else if (letter == "É" || letter == "È" || letter == "Ẻ" || letter == "Ẽ"
                || letter == "Ẹ" || letter == "Ê" || letter == "Ế"
                || letter == "Ề" || letter == "Ể" || letter == "Ễ" || letter == "Ệ")
                {
                    letter = "E";
                }
                else if (letter == "é" || letter == "è" || letter == "ẻ" || letter == "ẽ"
                 || letter == "ẹ" || letter == "ê" || letter == "ế"
                 || letter == "ề" || letter == "ể" || letter == "ễ" || letter == "ệ")
                {
                    letter = "e";
                }
                else if (letter == "Ú" || letter == "Ù" || letter == "Ủ" || letter == "Ũ"
               || letter == "Ụ" || letter == "Ư" || letter == "Ứ"
               || letter == "Ừ" || letter == "Ử" || letter == "Ữ" || letter == "Ự")
                {
                    letter = "U";
                }
                else if (letter == "ú" || letter == "ù" || letter == "ủ" || letter == "ũ"
                || letter == "ụ" || letter == "ư" || letter == "ứ"
                || letter == "ừ" || letter == "ử" || letter == "ữ" || letter == "ự")
                {
                    letter = "u";
                }
                else if (letter == "Í" || letter == "Ì" || letter == "Ỉ" || letter == "Ĩ"
                || letter == "Ị")
                {
                    letter = "I";
                }
                else if (letter == "í" || letter == "ì" || letter == "ỉ" || letter == "ĩ"
               || letter == "ị")
                {
                    letter = "i";
                }
                temp += letter;
            }
            return temp;
        }
        //--PhatLT Add
    }
}
