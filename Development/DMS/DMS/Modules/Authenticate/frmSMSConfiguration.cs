using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SCM.Controls;
using SCM.Utils;
using SCM.BusinessObject;
using System.Data;

namespace SCM.Presentation
{
	/// <summary>
	/// Summary description for frmSMSConfiguration.
	/// Author: DucND 15-12-2008
	/// </summary>
	public class frmSMSConfiguration : System.Windows.Forms.Form
	{
		#region ".NET Code"

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox frequency_uplift;
		private System.Windows.Forms.TextBox recheck_uplift;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox Complete_One_Order;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox frequency_bpcs;
		private System.Windows.Forms.TextBox recheck_bpcs;
		private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label22;
		private System.Windows.Forms.CheckBox chkActive_uplift;
		private System.Windows.Forms.CheckBox chkactive_bpcs;
		private System.Windows.Forms.CheckBox chkSMS;
        private System.Windows.Forms.CheckBox chkEmail;
        // ThucNV - 20100107 - Change button type
		/*private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnApply;*/
        private DotNetSkin.SkinControls.SkinButton btnCancel;
        private DotNetSkin.SkinControls.SkinButton btnApply;
        // ThucNV - 20100107 - Change button type
		private System.Windows.Forms.DateTimePicker dtpUplift_daily;
		private System.Windows.Forms.DateTimePicker dtpUplift_weekly;
		private System.Windows.Forms.DateTimePicker dtpBPCS;
        private GroupBox groupBox6;
        private Label label1;
        private Label label23;
        private TextBox txtImportDuration;
        private Label lblImportDuration;
        private Label lblTimeUnit;
        private Label label14;
        private GroupBox gbBPCS;
        private GroupBox gbBPCSWeekly;
        private Label lblImportDurationWeekly;
        private Label label25;
        private Label label17Weekly;
        private TextBox txtImportDurationWeekly;
        private Label label18Weekly;
        private Label label19Weekly;
        private DateTimePicker dtpBPCSWeekly;
        private Label label20Weekly;
        private Label label30;
        private TextBox Complete_One_OrderWeekly;
        private TextBox recheck_bpcsWeekly;
        private Label label31;
        private TextBox frequency_bpcsWeekly;
        private SplitContainer splitContainer1;
        private GroupBox gbUPLIFT;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSMSConfiguration()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			LoadResource();
			LoadParametersData();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		#region -- Load resource --
		private void LoadResource()
		{
			//this.groupBox1.Text  = clsResources.GetTitle("frmSMSConfiguration.groupBox1");
			this.label2.Text = clsResources.GetTitle("frmSMSConfiguration.label2");
			this.label3.Text = clsResources.GetTitle("frmSMSConfiguration.label3");
			this.label4.Text = clsResources.GetTitle("frmSMSConfiguration.label4");
			this.label5.Text = clsResources.GetTitle("frmSMSConfiguration.label5");
			this.chkActive_uplift.Text = clsResources.GetTitle("frmSMSConfiguration.chkActive_uplift");
			
			this.label6.Text = clsResources.GetTitle("frmSMSConfiguration.label6");
			this.label7.Text = clsResources.GetTitle("frmSMSConfiguration.label7");
			this.label8.Text = clsResources.GetTitle("frmSMSConfiguration.label8");
			
			this.label9.Text = clsResources.GetTitle("frmSMSConfiguration.label9");
			this.label10.Text = clsResources.GetTitle("frmSMSConfiguration.label10");
			this.groupBox3.Text = clsResources.GetTitle("frmSMSConfiguration.groupBox3");
			this.label11.Text = clsResources.GetTitle("frmSMSConfiguration.label11");
			this.label12.Text = clsResources.GetTitle("frmSMSConfiguration.label12");
			this.label13.Text = clsResources.GetTitle("frmSMSConfiguration.label13");
			this.label15.Text = clsResources.GetTitle("frmSMSConfiguration.label15");
			this.label16.Text = clsResources.GetTitle("frmSMSConfiguration.label16");
			this.chkactive_bpcs.Text = clsResources.GetTitle("frmSMSConfiguration.chkactive_bpcs");
			this.label17.Text = clsResources.GetTitle("frmSMSConfiguration.label17");
			this.label18.Text = clsResources.GetTitle("frmSMSConfiguration.label18");
			this.label19.Text = clsResources.GetTitle("frmSMSConfiguration.label19");
			this.label20.Text = clsResources.GetTitle("frmSMSConfiguration.label20");
            label17Weekly.Text = clsResources.GetTitle("frmSMSConfiguration.label17");
            label18Weekly.Text = clsResources.GetTitle("frmSMSConfiguration.label18");
            label19Weekly.Text = clsResources.GetTitle("frmSMSConfiguration.label19");
            label20Weekly.Text = clsResources.GetTitle("frmSMSConfiguration.label20");

            label25.Text = clsResources.GetTitle("frmSMSConfiguration.label21");
            label30.Text = clsResources.GetTitle("frmSMSConfiguration.label21");
            label31.Text = clsResources.GetTitle("frmSMSConfiguration.label21");

			this.label21.Text = clsResources.GetTitle("frmSMSConfiguration.label21");

			this.label22.Text = clsResources.GetTitle("frmSMSConfiguration.label22");
			this.groupBox5.Text = clsResources.GetTitle("frmSMSConfiguration.groupBox5");
            this.label1.Text = clsResources.GetTitle("frmSMSConfiguration.groupBox5");
			this.chkSMS.Text = clsResources.GetTitle("frmSMSConfiguration.chkSMS");
			this.chkEmail.Text = clsResources.GetTitle("frmSMSConfiguration.chkEmail");
			this.btnCancel.Text = clsResources.GetTitle("frmSMSConfiguration.btnCancel");
			this.btnApply.Text = clsResources.GetTitle("frmSMSConfiguration.btnApply");
            this.label23.Text = clsResources.GetTitle("frmSMSConfiguration.label23");
            this.lblImportDuration.Text = clsResources.GetTitle("frmSMSConfiguration.lblImportDuration");
            this.lblImportDurationWeekly.Text = clsResources.GetTitle("frmSMSConfiguration.lblImportDurationWeekly");
            this.lblTimeUnit.Text = clsResources.GetTitle("frmSMSConfiguration.lblTimeUnit");
			this.Text = clsResources.GetTitle("frmSMSConfiguration.Form.Description");

            gbBPCS.Text = clsResources.GetTitle("frmSMSConfiguration.gbBPCS");
            gbBPCSWeekly.Text = clsResources.GetTitle("frmSMSConfiguration.gbBPCSWeekly");
		}
		#endregion --Load Resource--
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
		# endregion
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSMSConfiguration));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbUPLIFT = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpUplift_weekly = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.recheck_uplift = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.frequency_uplift = new System.Windows.Forms.TextBox();
            this.dtpUplift_daily = new System.Windows.Forms.DateTimePicker();
            this.chkActive_uplift = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbBPCS = new System.Windows.Forms.GroupBox();
            this.lblImportDuration = new System.Windows.Forms.Label();
            this.lblTimeUnit = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtImportDuration = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpBPCS = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.Complete_One_Order = new System.Windows.Forms.TextBox();
            this.recheck_bpcs = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.frequency_bpcs = new System.Windows.Forms.TextBox();
            this.gbBPCSWeekly = new System.Windows.Forms.GroupBox();
            this.lblImportDurationWeekly = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label17Weekly = new System.Windows.Forms.Label();
            this.txtImportDurationWeekly = new System.Windows.Forms.TextBox();
            this.label18Weekly = new System.Windows.Forms.Label();
            this.label19Weekly = new System.Windows.Forms.Label();
            this.dtpBPCSWeekly = new System.Windows.Forms.DateTimePicker();
            this.label20Weekly = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.Complete_One_OrderWeekly = new System.Windows.Forms.TextBox();
            this.recheck_bpcsWeekly = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.frequency_bpcsWeekly = new System.Windows.Forms.TextBox();
            this.chkactive_bpcs = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.chkSMS = new System.Windows.Forms.CheckBox();
            // ThucNV - 20100107 - Change button type
            /*this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();*/
            this.btnCancel = new DotNetSkin.SkinControls.SkinButton();
            this.btnApply = new DotNetSkin.SkinControls.SkinButton();
            // ThucNV - 20100107 - Change button type
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.gbUPLIFT.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbBPCS.SuspendLayout();
            this.gbBPCSWeekly.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gbUPLIFT);
            this.groupBox1.Controls.Add(this.chkActive_uplift);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(8, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 252);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Up-Lift";
            // 
            // gbUPLIFT
            // 
            this.gbUPLIFT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUPLIFT.Controls.Add(this.label6);
            this.gbUPLIFT.Controls.Add(this.dtpUplift_weekly);
            this.gbUPLIFT.Controls.Add(this.label7);
            this.gbUPLIFT.Controls.Add(this.label10);
            this.gbUPLIFT.Controls.Add(this.label8);
            this.gbUPLIFT.Controls.Add(this.recheck_uplift);
            this.gbUPLIFT.Controls.Add(this.label9);
            this.gbUPLIFT.Controls.Add(this.frequency_uplift);
            this.gbUPLIFT.Controls.Add(this.dtpUplift_daily);
            this.gbUPLIFT.Location = new System.Drawing.Point(32, 136);
            this.gbUPLIFT.Name = "gbUPLIFT";
            this.gbUPLIFT.Size = new System.Drawing.Size(862, 110);
            this.gbUPLIFT.TabIndex = 6;
            this.gbUPLIFT.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Daily Checking Time:";
            // 
            // dtpUplift_weekly
            // 
            this.dtpUplift_weekly.CustomFormat = "HH:mm";
            this.dtpUplift_weekly.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUplift_weekly.Location = new System.Drawing.Point(132, 37);
            this.dtpUplift_weekly.Name = "dtpUplift_weekly";
            this.dtpUplift_weekly.ShowUpDown = true;
            this.dtpUplift_weekly.Size = new System.Drawing.Size(104, 20);
            this.dtpUplift_weekly.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Weekly Checking Time:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(244, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "minutes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Recheck Frequency:";
            // 
            // recheck_uplift
            // 
            this.recheck_uplift.Location = new System.Drawing.Point(132, 85);
            this.recheck_uplift.MaxLength = 3;
            this.recheck_uplift.Name = "recheck_uplift";
            this.recheck_uplift.Size = new System.Drawing.Size(104, 20);
            this.recheck_uplift.TabIndex = 5;
            this.recheck_uplift.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumber_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Recheck After:";
            // 
            // frequency_uplift
            // 
            this.frequency_uplift.Location = new System.Drawing.Point(132, 61);
            this.frequency_uplift.MaxLength = 3;
            this.frequency_uplift.Name = "frequency_uplift";
            this.frequency_uplift.Size = new System.Drawing.Size(104, 20);
            this.frequency_uplift.TabIndex = 4;
            this.frequency_uplift.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumber_KeyPress);
            // 
            // dtpUplift_daily
            // 
            this.dtpUplift_daily.CustomFormat = "HH:mm";
            this.dtpUplift_daily.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUplift_daily.Location = new System.Drawing.Point(132, 13);
            this.dtpUplift_daily.Name = "dtpUplift_daily";
            this.dtpUplift_daily.ShowUpDown = true;
            this.dtpUplift_daily.Size = new System.Drawing.Size(104, 20);
            this.dtpUplift_daily.TabIndex = 2;
            // 
            // chkActive_uplift
            // 
            this.chkActive_uplift.Checked = true;
            this.chkActive_uplift.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive_uplift.Location = new System.Drawing.Point(32, 111);
            this.chkActive_uplift.Name = "chkActive_uplift";
            this.chkActive_uplift.Size = new System.Drawing.Size(104, 24);
            this.chkActive_uplift.TabIndex = 1;
            this.chkActive_uplift.Text = "Enable";
            this.chkActive_uplift.CheckedChanged += new System.EventHandler(this.chkActive_uplift_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(32, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(862, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(44, 33);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(256, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Check daily order time: Time for checking daily order.";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(44, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Recheck after:Duration between each checking";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(44, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(312, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Recheck frequency:Recheck time";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(44, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(375, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Check weekly order time:Time for checking weekly order.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Config check schedule on HO-SCM";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.splitContainer1);
            this.groupBox3.Controls.Add(this.chkactive_bpcs);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(8, 260);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(900, 300);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BPCS";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(32, 150);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbBPCS);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbBPCSWeekly);
            this.splitContainer1.Size = new System.Drawing.Size(862, 144);
            this.splitContainer1.SplitterDistance = 429;
            this.splitContainer1.TabIndex = 14;
            // 
            // gbBPCS
            // 
            this.gbBPCS.Controls.Add(this.lblImportDuration);
            this.gbBPCS.Controls.Add(this.lblTimeUnit);
            this.gbBPCS.Controls.Add(this.label17);
            this.gbBPCS.Controls.Add(this.txtImportDuration);
            this.gbBPCS.Controls.Add(this.label18);
            this.gbBPCS.Controls.Add(this.label19);
            this.gbBPCS.Controls.Add(this.dtpBPCS);
            this.gbBPCS.Controls.Add(this.label20);
            this.gbBPCS.Controls.Add(this.label22);
            this.gbBPCS.Controls.Add(this.Complete_One_Order);
            this.gbBPCS.Controls.Add(this.recheck_bpcs);
            this.gbBPCS.Controls.Add(this.label21);
            this.gbBPCS.Controls.Add(this.frequency_bpcs);
            this.gbBPCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBPCS.Location = new System.Drawing.Point(0, 0);
            this.gbBPCS.Name = "gbBPCS";
            this.gbBPCS.Size = new System.Drawing.Size(429, 144);
            this.gbBPCS.TabIndex = 14;
            this.gbBPCS.TabStop = false;
            this.gbBPCS.Text = "Daily";
            // 
            // lblImportDuration
            // 
            this.lblImportDuration.AutoSize = true;
            this.lblImportDuration.Location = new System.Drawing.Point(6, 16);
            this.lblImportDuration.Name = "lblImportDuration";
            this.lblImportDuration.Size = new System.Drawing.Size(107, 13);
            this.lblImportDuration.TabIndex = 11;
            this.lblImportDuration.Text = "PPO Import Duration:";
            // 
            // lblTimeUnit
            // 
            this.lblTimeUnit.Location = new System.Drawing.Point(284, 15);
            this.lblTimeUnit.Name = "lblTimeUnit";
            this.lblTimeUnit.Size = new System.Drawing.Size(48, 16);
            this.lblTimeUnit.TabIndex = 13;
            this.lblTimeUnit.Text = "minutes";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(130, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "PPO Processing Duration:";
            // 
            // txtImportDuration
            // 
            this.txtImportDuration.Location = new System.Drawing.Point(164, 13);
            this.txtImportDuration.MaxLength = 3;
            this.txtImportDuration.Name = "txtImportDuration";
            this.txtImportDuration.Size = new System.Drawing.Size(112, 20);
            this.txtImportDuration.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(120, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "All PPO completed time:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 90);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Recheck Frequency:";
            // 
            // dtpBPCS
            // 
            this.dtpBPCS.CustomFormat = "HH:mm";
            this.dtpBPCS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBPCS.Location = new System.Drawing.Point(164, 62);
            this.dtpBPCS.Name = "dtpBPCS";
            this.dtpBPCS.ShowUpDown = true;
            this.dtpBPCS.Size = new System.Drawing.Size(112, 20);
            this.dtpBPCS.TabIndex = 11;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 115);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Recheck After:";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(284, 114);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 16);
            this.label22.TabIndex = 0;
            this.label22.Text = "minutes";
            // 
            // Complete_One_Order
            // 
            this.Complete_One_Order.Location = new System.Drawing.Point(164, 38);
            this.Complete_One_Order.MaxLength = 3;
            this.Complete_One_Order.Name = "Complete_One_Order";
            this.Complete_One_Order.Size = new System.Drawing.Size(112, 20);
            this.Complete_One_Order.TabIndex = 9;
            this.Complete_One_Order.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumber_KeyPress);
            // 
            // recheck_bpcs
            // 
            this.recheck_bpcs.Location = new System.Drawing.Point(164, 110);
            this.recheck_bpcs.MaxLength = 3;
            this.recheck_bpcs.Name = "recheck_bpcs";
            this.recheck_bpcs.Size = new System.Drawing.Size(112, 20);
            this.recheck_bpcs.TabIndex = 15;
            this.recheck_bpcs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumber_KeyPress);
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(284, 40);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 16);
            this.label21.TabIndex = 0;
            this.label21.Text = "minutes";
            // 
            // frequency_bpcs
            // 
            this.frequency_bpcs.Location = new System.Drawing.Point(164, 86);
            this.frequency_bpcs.MaxLength = 3;
            this.frequency_bpcs.Name = "frequency_bpcs";
            this.frequency_bpcs.Size = new System.Drawing.Size(112, 20);
            this.frequency_bpcs.TabIndex = 13;
            this.frequency_bpcs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateNumber_KeyPress);
            // 
            // gbBPCSWeekly
            // 
            this.gbBPCSWeekly.Controls.Add(this.lblImportDurationWeekly);
            this.gbBPCSWeekly.Controls.Add(this.label25);
            this.gbBPCSWeekly.Controls.Add(this.label17Weekly);
            this.gbBPCSWeekly.Controls.Add(this.txtImportDurationWeekly);
            this.gbBPCSWeekly.Controls.Add(this.label18Weekly);
            this.gbBPCSWeekly.Controls.Add(this.label19Weekly);
            this.gbBPCSWeekly.Controls.Add(this.dtpBPCSWeekly);
            this.gbBPCSWeekly.Controls.Add(this.label20Weekly);
            this.gbBPCSWeekly.Controls.Add(this.label30);
            this.gbBPCSWeekly.Controls.Add(this.Complete_One_OrderWeekly);
            this.gbBPCSWeekly.Controls.Add(this.recheck_bpcsWeekly);
            this.gbBPCSWeekly.Controls.Add(this.label31);
            this.gbBPCSWeekly.Controls.Add(this.frequency_bpcsWeekly);
            this.gbBPCSWeekly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBPCSWeekly.Location = new System.Drawing.Point(0, 0);
            this.gbBPCSWeekly.Name = "gbBPCSWeekly";
            this.gbBPCSWeekly.Size = new System.Drawing.Size(429, 144);
            this.gbBPCSWeekly.TabIndex = 15;
            this.gbBPCSWeekly.TabStop = false;
            this.gbBPCSWeekly.Text = "Weekly";
            // 
            // lblImportDurationWeekly
            // 
            this.lblImportDurationWeekly.AutoSize = true;
            this.lblImportDurationWeekly.Location = new System.Drawing.Point(6, 16);
            this.lblImportDurationWeekly.Name = "lblImportDurationWeekly";
            this.lblImportDurationWeekly.Size = new System.Drawing.Size(107, 13);
            this.lblImportDurationWeekly.TabIndex = 11;
            this.lblImportDurationWeekly.Text = "PPO Import Duration:";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(284, 15);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 16);
            this.label25.TabIndex = 13;
            this.label25.Text = "minutes";
            // 
            // label17Weekly
            // 
            this.label17Weekly.AutoSize = true;
            this.label17Weekly.Location = new System.Drawing.Point(6, 41);
            this.label17Weekly.Name = "label17Weekly";
            this.label17Weekly.Size = new System.Drawing.Size(130, 13);
            this.label17Weekly.TabIndex = 0;
            this.label17Weekly.Text = "PPO Processing Duration:";
            // 
            // txtImportDurationWeekly
            // 
            this.txtImportDurationWeekly.Location = new System.Drawing.Point(164, 13);
            this.txtImportDurationWeekly.MaxLength = 3;
            this.txtImportDurationWeekly.Name = "txtImportDurationWeekly";
            this.txtImportDurationWeekly.Size = new System.Drawing.Size(112, 20);
            this.txtImportDurationWeekly.TabIndex = 8;
            // 
            // label18Weekly
            // 
            this.label18Weekly.AutoSize = true;
            this.label18Weekly.Location = new System.Drawing.Point(6, 65);
            this.label18Weekly.Name = "label18Weekly";
            this.label18Weekly.Size = new System.Drawing.Size(120, 13);
            this.label18Weekly.TabIndex = 0;
            this.label18Weekly.Text = "All PPO completed time:";
            // 
            // label19Weekly
            // 
            this.label19Weekly.AutoSize = true;
            this.label19Weekly.Location = new System.Drawing.Point(6, 90);
            this.label19Weekly.Name = "label19Weekly";
            this.label19Weekly.Size = new System.Drawing.Size(107, 13);
            this.label19Weekly.TabIndex = 0;
            this.label19Weekly.Text = "Recheck Frequency:";
            // 
            // dtpBPCSWeekly
            // 
            this.dtpBPCSWeekly.CustomFormat = "HH:mm";
            this.dtpBPCSWeekly.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBPCSWeekly.Location = new System.Drawing.Point(164, 62);
            this.dtpBPCSWeekly.Name = "dtpBPCSWeekly";
            this.dtpBPCSWeekly.ShowUpDown = true;
            this.dtpBPCSWeekly.Size = new System.Drawing.Size(112, 20);
            this.dtpBPCSWeekly.TabIndex = 12;
            // 
            // label20Weekly
            // 
            this.label20Weekly.AutoSize = true;
            this.label20Weekly.Location = new System.Drawing.Point(6, 115);
            this.label20Weekly.Name = "label20Weekly";
            this.label20Weekly.Size = new System.Drawing.Size(79, 13);
            this.label20Weekly.TabIndex = 0;
            this.label20Weekly.Text = "Recheck After:";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(284, 114);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(48, 16);
            this.label30.TabIndex = 0;
            this.label30.Text = "minutes";
            // 
            // Complete_One_OrderWeekly
            // 
            this.Complete_One_OrderWeekly.Location = new System.Drawing.Point(164, 38);
            this.Complete_One_OrderWeekly.MaxLength = 3;
            this.Complete_One_OrderWeekly.Name = "Complete_One_OrderWeekly";
            this.Complete_One_OrderWeekly.Size = new System.Drawing.Size(112, 20);
            this.Complete_One_OrderWeekly.TabIndex = 10;
            // 
            // recheck_bpcsWeekly
            // 
            this.recheck_bpcsWeekly.Location = new System.Drawing.Point(164, 110);
            this.recheck_bpcsWeekly.MaxLength = 3;
            this.recheck_bpcsWeekly.Name = "recheck_bpcsWeekly";
            this.recheck_bpcsWeekly.Size = new System.Drawing.Size(112, 20);
            this.recheck_bpcsWeekly.TabIndex = 16;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(284, 40);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 16);
            this.label31.TabIndex = 0;
            this.label31.Text = "minutes";
            // 
            // frequency_bpcsWeekly
            // 
            this.frequency_bpcsWeekly.Location = new System.Drawing.Point(164, 86);
            this.frequency_bpcsWeekly.MaxLength = 3;
            this.frequency_bpcsWeekly.Name = "frequency_bpcsWeekly";
            this.frequency_bpcsWeekly.Size = new System.Drawing.Size(112, 20);
            this.frequency_bpcsWeekly.TabIndex = 14;
            // 
            // chkactive_bpcs
            // 
            this.chkactive_bpcs.Checked = true;
            this.chkactive_bpcs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkactive_bpcs.Location = new System.Drawing.Point(32, 128);
            this.chkactive_bpcs.Name = "chkactive_bpcs";
            this.chkactive_bpcs.Size = new System.Drawing.Size(104, 16);
            this.chkactive_bpcs.TabIndex = 6;
            this.chkactive_bpcs.Text = "Enable";
            this.chkactive_bpcs.CheckedChanged += new System.EventHandler(this.chkactive_bpcs_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(35, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(859, 114);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(38, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(287, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "PPO Import Duration: Duration for import one order to BPCS";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(38, 96);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(236, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Recheck after:Duration between each checking";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(170, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Recheck frequency:Recheck time";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(503, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Check all orders complete time:Time for checking all order from HO-SCM  are proce" +
                "ssedsuccessfully or not";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(324, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "PPO Complete Duration: Duration for completing one order in BPCS";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(24, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(244, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Config check schedule on BPCS.";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.chkEmail);
            this.groupBox5.Controls.Add(this.chkSMS);
            this.groupBox5.Location = new System.Drawing.Point(8, 566);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(900, 40);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Inform Method";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inform Method";
            // 
            // chkEmail
            // 
            this.chkEmail.Location = new System.Drawing.Point(231, 16);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(104, 16);
            this.chkEmail.TabIndex = 18;
            this.chkEmail.Text = "Email";
            // 
            // chkSMS
            // 
            this.chkSMS.Location = new System.Drawing.Point(128, 16);
            this.chkSMS.Name = "chkSMS";
            this.chkSMS.Size = new System.Drawing.Size(104, 16);
            this.chkSMS.TabIndex = 17;
            this.chkSMS.Text = "SMS";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(819, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Close";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnApply.Image = ((System.Drawing.Image)(resources.GetObject("btnApply.Image")));
            this.btnApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApply.Location = new System.Drawing.Point(737, 12);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 25);
            this.btnApply.TabIndex = 19;
            this.btnApply.Text = "Save";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.btnApply);
            this.groupBox6.Controls.Add(this.btnCancel);
            this.groupBox6.Location = new System.Drawing.Point(8, 612);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(900, 49);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            // 
            // frmSMSConfiguration
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(916, 666);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSMSConfiguration";
            this.Text = "eOrder_SMS";
            this.groupBox1.ResumeLayout(false);
            this.gbUPLIFT.ResumeLayout(false);
            this.gbUPLIFT.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gbBPCS.ResumeLayout(false);
            this.gbBPCS.PerformLayout();
            this.gbBPCSWeekly.ResumeLayout(false);
            this.gbBPCSWeekly.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region "Variable"

		private DataTable m_dt = null;
		private CurrencyManager m_manager = null;
		private clsSMSConfigurationBO bo = new clsSMSConfigurationBO();
		private Hashtable parameters = null;
		private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(frmSMSConfiguration));
		
		public DataTable DataSource
		{
			get{return m_dt;}
		}

		# endregion
		#region MainFunctions

		public void BindDataToControl()
		{
			parameters = new Hashtable();
            try
            {
                for (int i = 0; i < m_dt.Rows.Count; i++)
                {
                    parameters.Add(m_dt.Rows[i]["PARAM_NAME"].ToString().Trim(), m_dt.Rows[i]["PARAM_VALUE"].ToString().Trim());
                }

                // Gan gia tri vao control
                //Up-Lift
                if (parameters["SMS_ACTIVE_CHECK_UPLIFT"].ToString().Equals("Y"))
                {
                    chkActive_uplift.Checked = true;
                }
                else
                {
                    chkActive_uplift.Checked = false;
                }
                if (parameters["SMS_DAILY_ORDER"].ToString() == String.Empty || parameters["SMS_DAILY_ORDER"].ToString() == "")
                    dtpUplift_daily.Text = "12:00:00";
                else
                    dtpUplift_daily.Text = parameters["SMS_DAILY_ORDER"].ToString().Substring(0, 2) + ":" + parameters["SMS_DAILY_ORDER"].ToString().Substring(2, 2) + ":00";

                if (parameters["SMS_WEEKLY_ORDER"].ToString() == String.Empty || parameters["SMS_WEEKLY_ORDER"].ToString() == "")
                    dtpUplift_weekly.Text = "12:00:00";
                else
                    dtpUplift_weekly.Text = parameters["SMS_WEEKLY_ORDER"].ToString().Substring(0, 2) + ":" + parameters["SMS_WEEKLY_ORDER"].ToString().Substring(2, 2) + ":00";

                frequency_uplift.Text = parameters["SMS_RECHECK_FREQUENCY_UPLIFT"].ToString().Trim();
                recheck_uplift.Text = parameters["SMS_RECHECK_AFTER_UPLIFT"].ToString().Trim();

                //BPCS
                if (parameters["SMS_ACTIVE_CHECK_BPCS"].ToString().Equals("Y"))
                {
                    chkactive_bpcs.Checked = true;
                }
                else
                {
                    chkactive_bpcs.Checked = false;
                }
                //DAILY
                Complete_One_Order.Text = parameters["SMS_COMPLETE_PPO_DURATION_DAILY"].ToString().Trim();
                txtImportDuration.Text = parameters["SMS_IMPORT_PPO_DURATION_DAILY"].ToString().Trim();


                if (parameters["SMS_PROCESS_SUCCESSFULLY_DAILY"].ToString() == String.Empty || parameters["SMS_PROCESS_SUCCESSFULLY_DAILY"].ToString() == "")
                    dtpBPCS.Text = "12:00:00";
                else
                    dtpBPCS.Text = parameters["SMS_PROCESS_SUCCESSFULLY_DAILY"].ToString().Substring(0, 2) + ":" + parameters["SMS_PROCESS_SUCCESSFULLY_DAILY"].ToString().Substring(2, 2) + ":00";
                
                frequency_bpcs.Text = parameters["SMS_RECHECK_FREQUENCY_BPCS_DAILY"].ToString().Trim();
                recheck_bpcs.Text = parameters["SMS_RECHECK_AFTER_BPCS_DAILY"].ToString().Trim();

                //WEEKLY
                Complete_One_OrderWeekly.Text = parameters["SMS_COMPLETE_PPO_DURATION_WEEKLY"].ToString().Trim();
                txtImportDurationWeekly.Text = parameters["SMS_IMPORT_PPO_DURATION_WEEKLY"].ToString().Trim();

                if (parameters["SMS_PROCESS_SUCCESSFULLY_WEEKLY"].ToString() == String.Empty || parameters["SMS_PROCESS_SUCCESSFULLY_WEEKLY"].ToString() == "")
                    dtpBPCSWeekly.Text = "12:00:00";
                else
                    dtpBPCSWeekly.Text = parameters["SMS_PROCESS_SUCCESSFULLY_WEEKLY"].ToString().Substring(0, 2) + ":" + parameters["SMS_PROCESS_SUCCESSFULLY_WEEKLY"].ToString().Substring(2, 2) + ":00";

                frequency_bpcsWeekly.Text = parameters["SMS_RECHECK_FREQUENCY_BPCS_WEEKLY"].ToString().Trim();
                recheck_bpcsWeekly.Text = parameters["SMS_RECHECK_AFTER_BPCS_WEEKLY"].ToString().Trim();

                //inform method
                if (parameters["SMS_INFORM_METHOD"].ToString().Equals("SMS"))
                {
                    chkSMS.Checked = true;
                    chkEmail.Checked = false;
                }
                else if (parameters["SMS_INFORM_METHOD"].ToString().Equals("EMAIL"))
                {
                    chkEmail.Checked = true;
                    chkSMS.Checked = false;
                }
                else
                {
                    chkEmail.Checked = true;
                    chkSMS.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occur when loading parameter");
                this.Close();
            }
		}

		private void LoadParametersData()
		{
			m_dt = bo.Load();
			m_manager = (CurrencyManager)this.BindingContext[DataSource];
			BindDataToControl();
		}
		# endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.DialogResult i = MessageBox.Show(clsResources.GetMessage("messages.save"), clsResources.GetMessage("messages.general"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (i.ToString() == "No")
				return;

            //DuyLNK 2009-07-03 check before save
            if (!Validation())
            {
                MessageBox.Show(clsResources.GetMessage("frmSMSConfiguration.Parameters.Error"), clsResources.GetMessage("errors.general"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

			// Gan gia tri cua control vao hashtable parameters            
			//Up-Lift
			if(chkActive_uplift.Checked)
			{
				parameters["SMS_ACTIVE_CHECK_UPLIFT"] = "Y";

                parameters["SMS_DAILY_ORDER"] = dtpUplift_daily.Text.Substring(0, 2) + dtpUplift_daily.Text.Substring(3, 2);
                parameters["SMS_WEEKLY_ORDER"] = dtpUplift_weekly.Text.Substring(0, 2) + dtpUplift_weekly.Text.Substring(3, 2);
                if (!frequency_uplift.Text.Trim().Equals(""))
                    parameters["SMS_RECHECK_FREQUENCY_UPLIFT"] = frequency_uplift.Text.Trim();
                else
                    parameters["SMS_RECHECK_FREQUENCY_UPLIFT"] = "1";

                if (!recheck_uplift.Text.Trim().Equals(""))
                    parameters["SMS_RECHECK_AFTER_UPLIFT"] = recheck_uplift.Text.Trim();
                else
                    parameters["SMS_RECHECK_AFTER_UPLIFT"] = "1";
			}
			else
			{
				parameters["SMS_ACTIVE_CHECK_UPLIFT"] = "N";
			}

            //DuyLNK 2009-06-26 modify: DIVIDE PARAMETER TO DAILY AND WEEKLY
			//BPCS
			if(chkactive_bpcs.Checked)
			{
				parameters["SMS_ACTIVE_CHECK_BPCS"] = "Y";

                //DAILY
                if (!Complete_One_Order.Text.Trim().Equals(""))
                    parameters["SMS_COMPLETE_PPO_DURATION_DAILY"] = Complete_One_Order.Text.Trim();
                else
                    parameters["SMS_COMPLETE_PPO_DURATION_DAILY"] = "45";

                if (!txtImportDuration.Text.Trim().Equals(""))
                    parameters["SMS_IMPORT_PPO_DURATION_DAILY"] = txtImportDuration.Text.Trim();
                else
                    parameters["SMS_IMPORT_PPO_DURATION_DAILY"] = "30";

                parameters["SMS_PROCESS_SUCCESSFULLY_DAILY"] = dtpBPCS.Text.Substring(0, 2) + dtpBPCS.Text.Substring(3, 2);

                if (!frequency_bpcs.Text.Trim().Equals(""))
                    parameters["SMS_RECHECK_FREQUENCY_BPCS_DAILY"] = frequency_bpcs.Text.Trim();
                else
                    parameters["SMS_RECHECK_FREQUENCY_BPCS_DAILY"] = "1";

                if (!recheck_bpcs.Text.Trim().Equals(""))
                    parameters["SMS_RECHECK_AFTER_BPCS_DAILY"] = recheck_bpcs.Text.Trim();
                else
                    parameters["SMS_RECHECK_AFTER_BPCS_DAILY"] = "1";

                //WEEKLY
                if (!Complete_One_OrderWeekly.Text.Trim().Equals(""))
                    parameters["SMS_COMPLETE_PPO_DURATION_WEEKLY"] = Complete_One_OrderWeekly.Text.Trim();
                else
                    parameters["SMS_COMPLETE_PPO_DURATION_WEEKLY"] = "45";

                if (!txtImportDurationWeekly.Text.Trim().Equals(""))
                    parameters["SMS_IMPORT_PPO_DURATION_WEEKLY"] = txtImportDurationWeekly.Text.Trim();
                else
                    parameters["SMS_IMPORT_PPO_DURATION_WEEKLY"] = "30";

                parameters["SMS_PROCESS_SUCCESSFULLY_WEEKLY"] = dtpBPCSWeekly.Text.Substring(0, 2) + dtpBPCSWeekly.Text.Substring(3, 2);

                if (!frequency_bpcsWeekly.Text.Trim().Equals(""))
                    parameters["SMS_RECHECK_FREQUENCY_BPCS_WEEKLY"] = frequency_bpcsWeekly.Text.Trim();
                else
                    parameters["SMS_RECHECK_FREQUENCY_BPCS_WEEKLY"] = "1";

                if (!recheck_bpcsWeekly.Text.Trim().Equals(""))
                    parameters["SMS_RECHECK_AFTER_BPCS_WEEKLY"] = recheck_bpcsWeekly.Text.Trim();
                else
                    parameters["SMS_RECHECK_AFTER_BPCS_WEEKLY"] = "1";
			}
			else
			{
				parameters["SMS_ACTIVE_CHECK_BPCS"] = "N";
			}

            

			//inform method
			if(chkSMS.Checked)
			{
				if(chkEmail.Checked)
				{
					parameters["SMS_INFORM_METHOD"] = "BOTH";
				}
				else
				{
					parameters["SMS_INFORM_METHOD"] = "SMS";
				}
			}
			else
			{
				if(chkEmail.Checked)
				{
					parameters["SMS_INFORM_METHOD"] = "EMAIL";
				}
			}
			if(bo.Update(parameters))
				MessageBox.Show(clsResources.GetMessage("messages.success"), clsResources.GetMessage("messages.general"), MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

        private bool Validation()
        {
            try
            {
                if (int.Parse(Complete_One_Order.Text.Trim()) <= int.Parse(txtImportDuration.Text.Trim()) ||
                    int.Parse(Complete_One_OrderWeekly.Text.Trim()) <= int.Parse(txtImportDurationWeekly.Text.Trim())
                    )
                    return false;
                return true;
            }
            catch 
            {
                return false;                
            }
        }

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			btnApply_Click(sender,e);
			this.Close();
		}

        private void ValidateNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.clsCommon.CheckNumber(e);
        }

        private void chkActive_uplift_CheckedChanged(object sender, EventArgs e)
        {
            gbUPLIFT.Enabled = chkActive_uplift.Checked;
        }

        private void chkactive_bpcs_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Enabled = chkactive_bpcs.Checked;
        }
	}
}
