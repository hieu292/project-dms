using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;

using SCM.Utils;
using SCM.BusinessObject;

namespace SCM.Presentation
{
	/// <summary>
	/// Summary description for frmLogIn.
	/// </summary>
	public class frmLogin : System.Windows.Forms.Form
	{
		private clsAutUserBO bo= new clsAutUserBO();
        private IContainer components;
        private DotNetSkin.SkinControls.SkinButton btnLogin;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private DotNetSkin.SkinControls.SkinButton btnCancel;

		#region Window Control

        private System.Windows.Forms.ErrorProvider ep;
		#endregion Window Control

		#region Constructor and Destructor
		public frmLogin()
		{
			InitializeComponent();

            clsTitleManager.InitTitle(this);

            Color color = Color.CornflowerBlue;
            if (clsStyleManager.ThemeColor == Style.Blue)
            {
                color = Color.CornflowerBlue;
            }
            else if (clsStyleManager.ThemeColor == Style.Maveric)
            {
                color = Color.CornflowerBlue;
            }
            else if (clsStyleManager.ThemeColor == Style.Silver)
            {
                color = Color.FromArgb(134, 134, 134);
            }
            else if (clsStyleManager.ThemeColor == Style.Cyan)
            {
                color = Color.Green;
            }
            else if (clsStyleManager.ThemeColor == Style.Orange)
            {
                color = Color.OrangeRed;
            }
            btnLogin.ForeColor = color;
            btnCancel.ForeColor = color;
		}

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
		#endregion Constructor and Destructor

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new DotNetSkin.SkinControls.SkinButton();
            this.btnCancel = new DotNetSkin.SkinControls.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserName.Location = new System.Drawing.Point(218, 78);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(158, 15);
            this.txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Location = new System.Drawing.Point(219, 128);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(160, 13);
            this.txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogin.Location = new System.Drawing.Point(214, 158);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(81, 31);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Transparent;
            this.btnCancel.Location = new System.Drawing.Point(301, 158);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(400, 244);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmLogin_Closing);
            this.Load += new System.EventHandler(this.frmLogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		protected int m_iLoginResult = clsConstants.ACCOUNT_NOT_EXIST;

		/// <summary>
		/// Login Result
		/// </summary>
		public int LoginResult
		{
			get{return m_iLoginResult;}
		}

		/// <summary>
		/// Login
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
		private void btnLogIn_Click(object sender, System.EventArgs e)
		{
			ep.SetError(txtUserName, "");
			if(txtUserName.Text.Trim().Length == 0)
			{
				ep.SetError(txtUserName, clsResources.GetMessage("errors.required", "User name"));
				return;
			}
			clsAutUserBO login = new clsAutUserBO();
			string userName = txtUserName.Text.Trim();
			string password = txtPassword.Text;
			m_iLoginResult = login.Login(userName, password);
			switch(m_iLoginResult)
			{
				case clsConstants.ACCOUNT_NOT_EXIST://-2
					MessageBox.Show(clsResources.GetMessage("errors.login.ACCOUNT_NOT_EXIST"), clsResources.GetMessage("errors.general"), MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtPassword.Clear();
					txtUserName.Focus();
					txtUserName.SelectAll();
					break;
				case clsConstants.PASSWORD_WRONG://-3:					
					MessageBox.Show("Password is wrong", "Invalid LogIn", MessageBoxButtons.OK, MessageBoxIcon.Error);
					//txtPassword.Clear();
					txtPassword.Focus();
					txtPassword.SelectAll();
					break;
				case clsConstants.ACCOUNT_INACTIVE://-4:
					MessageBox.Show("Account is not active", "Invalid LogIn", MessageBoxButtons.OK, MessageBoxIcon.Error);
					//txtPassword.Clear();
					txtUserName.Focus();
					txtUserName.SelectAll();
					break;
				case clsConstants.ACCOUNT_EXPIRED://-5:
					MessageBox.Show("Account expired", "Invalid LogIn", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtPassword.Clear();
					txtUserName.Focus();
					txtUserName.SelectAll();
					break;
				case clsConstants.PASSWORD_EXPIRED://-6:
					MessageBox.Show("Password expired", "Invalid LogIn", MessageBoxButtons.OK, MessageBoxIcon.Error);
					clsSystemConfig.UserName = userName;
					frmChangePWD frm = new frmChangePWD();
					this.Hide();
					frm.ShowDialog();
					this.Show();
					txtPassword.Clear();
					txtUserName.Focus();
					txtUserName.SelectAll();
					break;
				case clsConstants.LOGIN_SUCCESS:
                    clsSystemConfig.UserName = userName;
                    this.Close();
                    break;
			}
		}

		/// <summary>
		/// Handle events on load events. Focus on txtUserName
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
		private void frmLogIn_Load(object sender, System.EventArgs e)
		{
			txtUserName.Focus();
//			txtPassword.Focus();
//			txtUserName.Text = ConfigurationManager.AppSettings["UserName"];
//			txtPassword.Text = ConfigurationManager.AppSettings["PassWord"];
		}

		/// <summary>
		/// Close this form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Handle event on closing event. Do not close this form when user click btnOK and login unsuccessfully.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
		private void frmLogin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(LoginResult != clsConstants.LOGIN_SUCCESS && this.DialogResult == DialogResult.OK)
			{
				e.Cancel = true;
			}
		}
	}
}
