using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using SCM;
using SCM.BusinessObject;
using System.IO;
using SCM.Utils;

namespace SCM.Presentation
{
	/// <summary>
	/// Summary description for SCM_Parameter.
	/// </summary>
	public class frmParameter : System.Windows.Forms.Form
	{
		#region ".NET Code"
		
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.DataGrid grdParam;
		private System.Windows.Forms.LinkLabel lnkBrowse;
		private System.Windows.Forms.TextBox txtParamValue;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.TextBox txtParamName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label9;
		private DotNetSkin.SkinControls.SkinButton btnClose;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox cboParamGroup;
		private System.Windows.Forms.Label label1;
		private DotNetSkin.SkinControls.SkinButton btnView;
        private Label lblParameter;
        private TextBox txtParameter;
		private DotNetSkin.SkinControls.SkinButton btnUpdate;	

		public frmParameter()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			InitializeCombo();

			FixPosition();
		}

		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// 
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region "Variable"
		
		private DataTable m_dt = null;
		private CurrencyManager m_manager = null;
		private clsParameterBO bo = new clsParameterBO();
		private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(frmParameter));

		public DataTable DataSource
		{
			get{return m_dt;}
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParameter));
            this.grdParam = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lnkBrowse = new System.Windows.Forms.LinkLabel();
            this.btnUpdate = new DotNetSkin.SkinControls.SkinButton();
            this.txtParamValue = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtParamName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new DotNetSkin.SkinControls.SkinButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblParameter = new System.Windows.Forms.Label();
            this.txtParameter = new System.Windows.Forms.TextBox();
            this.btnView = new DotNetSkin.SkinControls.SkinButton();
            this.cboParamGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdParam)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdParam
            // 
            this.grdParam.AllowSorting = false;
            this.grdParam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdParam.CaptionVisible = false;
            this.grdParam.DataMember = "";
            this.grdParam.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdParam.Location = new System.Drawing.Point(5, 237);
            this.grdParam.Name = "grdParam";
            this.grdParam.ReadOnly = true;
            this.grdParam.Size = new System.Drawing.Size(839, 250);
            this.grdParam.TabIndex = 3;
            this.grdParam.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.grdParam.CurrentCellChanged += new System.EventHandler(this.grdParam_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.AliceBlue;
            this.dataGridTableStyle1.DataGrid = this.grdParam;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Parameter Name";
            this.dataGridTextBoxColumn1.MappingName = "Param_Name";
            this.dataGridTextBoxColumn1.Width = 190;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Parameter Value";
            this.dataGridTextBoxColumn2.MappingName = "Param_Value";
            this.dataGridTextBoxColumn2.Width = 135;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Description";
            this.dataGridTextBoxColumn3.MappingName = "Description";
            this.dataGridTextBoxColumn3.Width = 400;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Location = new System.Drawing.Point(8, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(839, 64);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(32, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(328, 16);
            this.label9.TabIndex = 21;
            this.label9.Tag = "";
            this.label9.Text = "WS: Parameters relate to Windows Service";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(400, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(301, 16);
            this.label8.TabIndex = 16;
            this.label8.Tag = "";
            this.label8.Text = "SP: Parameters relate to Stock Policy";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(32, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "PPO: Parameters relate to Proposal purchase Order";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(400, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(311, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "OTHER: Other parameters";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MediumBlue;
            this.panel3.Location = new System.Drawing.Point(385, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(8, 8);
            this.panel3.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumBlue;
            this.panel2.Location = new System.Drawing.Point(385, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 8);
            this.panel2.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumBlue;
            this.panel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Location = new System.Drawing.Point(16, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 8);
            this.panel1.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumBlue;
            this.panel4.Location = new System.Drawing.Point(16, 43);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(8, 8);
            this.panel4.TabIndex = 17;
            // 
            // lnkBrowse
            // 
            this.lnkBrowse.Location = new System.Drawing.Point(418, 79);
            this.lnkBrowse.Name = "lnkBrowse";
            this.lnkBrowse.Size = new System.Drawing.Size(24, 16);
            this.lnkBrowse.TabIndex = 7;
            this.lnkBrowse.TabStop = true;
            this.lnkBrowse.Text = "[...]";
            this.lnkBrowse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBrowse_LinkClicked);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(681, 70);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(69, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "      Save";
            this.btnUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // txtParamValue
            // 
            this.txtParamValue.Location = new System.Drawing.Point(157, 80);
            this.txtParamValue.Name = "txtParamValue";
            this.txtParamValue.Size = new System.Drawing.Size(256, 20);
            this.txtParamValue.TabIndex = 6;
            this.txtParamValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParamValue_KeyPress);
            // 
            // txtDescription
            // 
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(157, 48);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(256, 20);
            this.txtDescription.TabIndex = 5;
            // 
            // txtParamName
            // 
            this.txtParamName.Enabled = false;
            this.txtParamName.Location = new System.Drawing.Point(157, 16);
            this.txtParamName.Name = "txtParamName";
            this.txtParamName.Size = new System.Drawing.Size(256, 20);
            this.txtParamName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "ParameterValue";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parameter Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.txtParamName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtParamValue);
            this.groupBox2.Controls.Add(this.lnkBrowse);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Location = new System.Drawing.Point(8, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(839, 105);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(759, 69);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "    Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblParameter);
            this.groupBox3.Controls.Add(this.txtParameter);
            this.groupBox3.Controls.Add(this.btnView);
            this.groupBox3.Controls.Add(this.cboParamGroup);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(841, 50);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // lblParameter
            // 
            this.lblParameter.Location = new System.Drawing.Point(471, 17);
            this.lblParameter.Name = "lblParameter";
            this.lblParameter.Size = new System.Drawing.Size(57, 17);
            this.lblParameter.TabIndex = 14;
            this.lblParameter.Text = "Param";
            this.lblParameter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtParameter
            // 
            this.txtParameter.Location = new System.Drawing.Point(547, 14);
            this.txtParameter.MaxLength = 20;
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.Size = new System.Drawing.Size(113, 20);
            this.txtParameter.TabIndex = 15;
            // 
            // btnView
            // 
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(681, 12);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(76, 23);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "     Search";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // cboParamGroup
            // 
            this.cboParamGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParamGroup.Location = new System.Drawing.Point(140, 14);
            this.cboParamGroup.Name = "cboParamGroup";
            this.cboParamGroup.Size = new System.Drawing.Size(326, 21);
            this.cboParamGroup.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Parameter Group";
            // 
            // frmParameter
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(856, 494);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdParam);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(632, 432);
            this.Name = "frmParameter";
            this.Text = "SCM - Parameter Management";
            ((System.ComponentModel.ISupportInitialize)(this.grdParam)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region MainFunctions

		/// <summary>
		///fix position cho cac control
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>
		
		public void FixPosition()
		{	
			label1.Top = 10;
			cboParamGroup.Top = 10;
			label1.Left = 10;
			cboParamGroup.Left = label1.Right + 5;
			groupBox3.Height = cboParamGroup.Bottom + 12;
			groupBox1.Top = groupBox3.Bottom + 8;
            groupBox2.Top = groupBox1.Bottom + 5;
			grdParam.Top = groupBox2.Bottom + 5;
			btnView.Top = cboParamGroup.Top - 2;
			label2.Top = 10;
			txtParamName.Top = 10;
			label4.Top = label2.Bottom+ 5;
			label3.Top = label4.Bottom+5;
			txtDescription.Top = label4.Top;
			txtParamValue.Top = label3.Top;
			label2.Left = 10;
			label3.Left = 10;
			label4.Left = 10;
			txtParamName.Left = label2.Right + 5;
			txtDescription.Left = txtParamName.Left;
			txtParamValue.Left = txtParamName.Left;
			lnkBrowse.Top = txtParamValue.Top +7;
			btnUpdate.Top = txtParamValue.Top - 3;
			btnClose.Top = btnUpdate.Top;
		}
		
		/// <summary>
		/// bind du lieu tu datatable vao cac textbox
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>
		
		public void BindDataToControl()
		{
            if (m_dt.Rows.Count > 0)
            {
                txtParamName.Text = m_dt.Rows[m_manager.Position]["PARAM_NAME"].ToString();
                txtDescription.Text = m_dt.Rows[m_manager.Position]["DESCRIPTION"].ToString();
                txtParamValue.Text = m_dt.Rows[m_manager.Position]["PARAM_VALUE"].ToString();
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
		}
		
		/// <summary>
		/// Nhan mot datable tu ham LoadAll, sau do gan vao datasource cua combobox
		/// </summary>
		/// <remarks>
		/// Author:		Nguyen Minh Khoa G3
		/// Modified:	18-Apr-2011
		/// </remarks>

		private void InitializeCombo()
		{
			try
			{
				m_dt=bo.LoadAll();
                DataRow dr = m_dt.NewRow();
                dr["PARAM_GROUP"] = "[ALL]";
                m_dt.Rows.InsertAt(dr, 0);
				cboParamGroup.DataSource= DataSource;
				cboParamGroup.DisplayMember= "PARAM_GROUP";
				cboParamGroup.ValueMember= "PARAM_GROUP";
                (cboParamGroup.DataSource as DataTable).DefaultView.Sort = "PARAM_GROUP";
				cboParamGroup.SelectedIndex=0;			
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
				MessageBox.Show(clsResources.GetMessage("errors.available"), clsResources.GetMessage("messages.general"), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Event				
		        
		private void grdParam_CurrentCellChanged(object sender, System.EventArgs e)
		{
			BindDataToControl();
		}
		private void btnView_Click(object sender, System.EventArgs e)
		{
			if(cboParamGroup.Text=="Time")
			{
				lnkBrowse.Enabled=false;
			}
			else
			{
				lnkBrowse.Enabled=true;
			}
            string strgroup = cboParamGroup.Text == "[ALL]" ? "%%" : cboParamGroup.Text;
			m_dt=bo.GetOne(strgroup, txtParameter.Text.Trim());
			grdParam.DataSource=DataSource;
			m_manager = (CurrencyManager)this.BindingContext[DataSource];
			BindDataToControl();
		}
		private void lnkBrowse_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			FolderBrowserDialog fbrdlg = new FolderBrowserDialog();
			fbrdlg.ShowNewFolderButton = true;
			if (fbrdlg.ShowDialog() == DialogResult.OK)
			{
				this.txtParamValue.Text=fbrdlg.SelectedPath;
			}
		}
		private void txtParamValue_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(cboParamGroup.Text=="Time")
			{
				char chr = e.KeyChar;
				if(!(chr >= '1' && chr <= '9' || chr == 8 || chr == 13))
					e.Handled = true;				
			}			
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdUpdate_Click(object sender, System.EventArgs e)
		{
			string strValue, strName, strType;
			strValue=txtParamValue.Text;
			strName=txtParamName.Text;
			strType=m_dt.Rows[m_manager.Position]["PARAM_TYPE"].ToString();

			System.Windows.Forms.DialogResult i = MessageBox.Show(clsResources.GetMessage("messages.save"), clsResources.GetMessage("messages.general"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (i.ToString() == "No")
				return;

			if (strValue=="")
			{
				MessageBox.Show(clsResources.GetMessage("errors.fill", txtParamValue.Text), clsResources.GetMessage("messages.general"), MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtParamValue.Focus();
				txtParamValue.SelectAll();
				return;
			}
//			if(strType =="s" && m_dt.Rows[m_manager.Position]["PARAM_NAME"].ToString() != "WS_RURAL_SKU_REMINDER_PERIOD") //nghiahbt added 28-May-07
//			{
//				strDes = m_dt.Rows[m_manager.Position]["DESCRIPTION"].ToString();
//				if(strDes.IndexOf("day")!= -1)
//				{
//					strValue = strValue.ToUpper();
//					if(strValue!= "MON" && strValue!= "TUE" && strValue!= "WED"
//						&& strValue!= "THU" && strValue!= "FRI" && strValue!= "SAT" && strValue!= "SUN")
//					{
//						MessageBox.Show(strDes,clsResources.GetMessage("messages.general"),MessageBoxButtons.OK, MessageBoxIcon.Error);
//						txtParamValue.Focus();
//						txtParamValue.SelectAll();
//						return;
//					
//					}
//				}
//			}
			if( bo.Validate(strType, strValue) == false)
			{				
//				if(strType=="s")
//					MessageBox.Show(clsResources.GetMessage("errors.exist", txtParamValue.Text), clsResources.GetMessage("messages.general"), MessageBoxButtons.OK, MessageBoxIcon.Error);
//				else 
				if(strType=="t"||strType=="n")
					MessageBox.Show(clsResources.GetMessage("errors.number", "Time"), clsResources.GetMessage("messages.general"), MessageBoxButtons.OK, MessageBoxIcon.Error);
				else if(strType=="d")
					MessageBox.Show(clsResources.GetMessage("errors.date"), clsResources.GetMessage("messages.general"), MessageBoxButtons.OK, MessageBoxIcon.Error);
				else if(strType=="b")
					MessageBox.Show(clsResources.GetMessage("errors.bool"), clsResources.GetMessage("messages.general"), MessageBoxButtons.OK, MessageBoxIcon.Error);					
				
				m_dt.RejectChanges();
				txtParamValue.Focus();
				txtParamValue.SelectAll();
				return;
			}			
			
			if (bo.Update(strValue, strName))
			{
				m_dt.Rows[m_manager.Position]["PARAM_VALUE"] = txtParamValue.Text;
				m_dt.AcceptChanges();
				MessageBox.Show(clsResources.GetMessage("messages.success"), clsResources.GetMessage("messages.general"), MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		
		#endregion			


	
    }
}
