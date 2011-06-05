using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using SCM.Utils;
using SCM.BusinessObject;

namespace SCM.Presentation
{
	/// <summary>
	/// Summary description for frmChangeCustCode.
	/// </summary>
	public class frmChangeCustCode : System.Windows.Forms.Form
	{
		private DotNetSkin.SkinControls.SkinButton btnOK;
		private DotNetSkin.SkinControls.SkinButton btnCancel;
		private System.Windows.Forms.Label lbNewCustCode;
		private System.Windows.Forms.Label lOldCustcode;
		private System.Windows.Forms.TextBox txtOldCustCode;
		private System.Windows.Forms.TextBox txtNewCustCode;

		private System.Windows.Forms.ErrorProvider ep;
		private clsAutUserBO bo = new clsAutUserBO();
		private bool bln_Success = false;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChangeCustCode()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmChangeCustCode));
			this.lbNewCustCode = new System.Windows.Forms.Label();
			this.txtOldCustCode = new System.Windows.Forms.TextBox();
			this.txtNewCustCode = new System.Windows.Forms.TextBox();
			this.lOldCustcode = new System.Windows.Forms.Label();
			this.btnOK = new DotNetSkin.SkinControls.SkinButton();
			this.btnCancel = new DotNetSkin.SkinControls.SkinButton();
			this.ep = new System.Windows.Forms.ErrorProvider();
			this.SuspendLayout();
			// 
			// lbNewCustCode
			// 
			this.lbNewCustCode.AutoSize = true;
			this.lbNewCustCode.Location = new System.Drawing.Point(53, 51);
			this.lbNewCustCode.Name = "lbNewCustCode";
			this.lbNewCustCode.Size = new System.Drawing.Size(107, 16);
			this.lbNewCustCode.TabIndex = 14;
			this.lbNewCustCode.Text = "New customer code:";
			// 
			// txtOldCustCode
			// 
			this.txtOldCustCode.Location = new System.Drawing.Point(162, 22);
			this.txtOldCustCode.Name = "txtOldCustCode";
			this.txtOldCustCode.Size = new System.Drawing.Size(154, 20);
			this.txtOldCustCode.TabIndex = 15;
			this.txtOldCustCode.Text = "";
			// 
			// txtNewCustCode
			// 
			this.txtNewCustCode.Location = new System.Drawing.Point(162, 51);
			this.txtNewCustCode.Name = "txtNewCustCode";
			this.txtNewCustCode.Size = new System.Drawing.Size(155, 20);
			this.txtNewCustCode.TabIndex = 16;
			this.txtNewCustCode.Text = "";
			// 
			// lOldCustcode
			// 
			this.lOldCustcode.AutoSize = true;
			this.lOldCustcode.Location = new System.Drawing.Point(53, 24);
			this.lOldCustcode.Name = "lOldCustcode";
			this.lOldCustcode.Size = new System.Drawing.Size(102, 16);
			this.lOldCustcode.TabIndex = 13;
			this.lOldCustcode.Text = "Old customer code:";
			// 
			// btnOK
			// 
			this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
			this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOK.Location = new System.Drawing.Point(86, 92);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(92, 25);
			this.btnOK.TabIndex = 11;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
			this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancel.Location = new System.Drawing.Point(197, 92);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(92, 25);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// ep
			// 
			this.ep.ContainerControl = this;
			// 
			// frmChangeCustCode
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(376, 140);
			this.Controls.Add(this.lbNewCustCode);
			this.Controls.Add(this.txtOldCustCode);
			this.Controls.Add(this.txtNewCustCode);
			this.Controls.Add(this.lOldCustcode);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmChangeCustCode";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Change customer code";
			this.TransparencyKey = System.Drawing.SystemColors.Control;
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(!ValidateChangeInput())
				return;
			string oldCustCode = txtOldCustCode.Text.Trim();
			string newCustCode = txtNewCustCode.Text.Trim();
			int resultValue = 0;

			try
			{
				Cursor.Current = Cursors.WaitCursor;
				
				resultValue = bo.ChangeCustCode(oldCustCode, newCustCode);
				//----
				if (resultValue == -1)
				{
					MessageBox.Show("Old customer code not existed, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtOldCustCode.Focus();
				}
				else if (resultValue == -3)
				{
					MessageBox.Show("New customer code length must be equal 5 !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -20)
				{
					MessageBox.Show("New customer code existed in [SCM_DISTRIBUTOR_HIERARCHY] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				
				//---------------------------------------------------------------------
				else if (resultValue == -21)
				{
					MessageBox.Show("New customer code existed in [SCM_SHIP_TO] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -22)
				{
					MessageBox.Show("New customer code existed in [TEMP_LACK_SP] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -23)
				{
					MessageBox.Show("New customer code existed in [RCM] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -24)
				{
					MessageBox.Show("New customer code existed in [SCM_ALLOCATION_FORWARDING] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -25)
				{
					MessageBox.Show("New customer code existed in [SCM_CO_HEADER] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -26)
				{
					MessageBox.Show("New customer code existed in [SCM_CO_TEMP] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -27)
				{
					MessageBox.Show("New customer code existed in [SCM_CUSTOMER_SMS] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -28)
				{
					MessageBox.Show("New customer code existed in [SCM_DEFINE_ORDER_SPLIT_HEADER] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -29)
				{
					MessageBox.Show("New customer code existed in [SCM_DELIVERY_WEIGHT] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -30)
				{
					MessageBox.Show("New customer code existed in [SCM_DISTRIBUTOR_DAILY_SCHEDULE] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -31)
				{
					MessageBox.Show("New customer code existed in [SCM_ORDER_SPLIT_HEADER] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -32)
				{
					MessageBox.Show("New customer code existed in [SCM_PARAMETERS_MOQ_FULL] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -33)
				{
					MessageBox.Show("New customer code existed in [SCM_PPO_HEADER] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -34)
				{
					MessageBox.Show("New customer code existed in [SCM_PPO_HEADER_LACK] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -35)
				{
					MessageBox.Show("New customer code existed in [SCM_PROMOTION_CUST] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -36)
				{
					MessageBox.Show("New customer code existed in [SCM_PROMOTION_CUST_SWAP] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -37)
				{
					MessageBox.Show("New customer code existed in [SCM_PROMOTION_CUST_WEEK] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}			
				else if (resultValue == -38)
				{
					MessageBox.Show("New customer code existed in [SCM_RURAL_SKU] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -39)
				{
					MessageBox.Show("New customer code existed in [SCM_RURAL_SKU_IMPORT_HEADER] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -40)
				{
					MessageBox.Show("New customer code existed in [SCM_SEC_SLS] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -41)
				{
					MessageBox.Show("New customer code existed in [SCM_SP_SPECIAL] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -42)
				{
					MessageBox.Show("New customer code existed in [SCM_CO_OTHER] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}		
				else if (resultValue == -43)
				{
					MessageBox.Show("New customer code existed in [UERRM] table, please input another !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				//---------------------------------------------------------------------
				else if (resultValue == -4)
				{
					MessageBox.Show("New customer code must be contains region code !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == -5)
				{
					MessageBox.Show("New customer code must be have region code same as old customer code!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					txtNewCustCode.Focus();
				}
				else if (resultValue == 0)
				{
					MessageBox.Show("Change customer code fail, data will roll back !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);	
					Success = false;
					this.Close();
				}
				else if (resultValue == 1)
				{
					MessageBox.Show("Changed customer code success", clsResources.GetMessage("messages.general"), MessageBoxButtons.OK, MessageBoxIcon.Information);
					Success = true;
					this.Close();
				}					
					
				Cursor.Current = Cursors.Default;	
			}
			catch (Exception ex)
			{
				MessageBox.Show(clsResources.GetMessage("messages.changecustcode.fail") + "\r\nDetail: " + ex.Message, clsResources.GetMessage("messages.general"), MessageBoxButtons.OK, MessageBoxIcon.Error);
					
			}

		}

		//---------------- check data input before change ---------------
		private bool ValidateChangeInput()
		{
			ep.SetError(txtOldCustCode, "");
			ep.SetError(txtNewCustCode, "");
			if(txtOldCustCode.Text.Trim().Length == 0)
			{
				ep.SetError(txtOldCustCode, clsResources.GetMessage("errors.required", txtOldCustCode.Text));
				txtOldCustCode.Focus();
				return false;
			}
			else if(txtNewCustCode.Text.Trim().Length == 0)
			{
				ep.SetError(txtNewCustCode, clsResources.GetMessage("errors.required", txtNewCustCode.Text));
				txtNewCustCode.Focus();
				return false;
			}
			else if (!ValidateNumber(txtNewCustCode.Text))
			{
				MessageBox.Show("New customer code must be numeric and not any space !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);	
				txtNewCustCode.Focus();
				return false;
			}
			
			return true;

		}

		public bool ValidateNumber(string input )
		{
			foreach ( char c in input )
			{
				if ( ! Char.IsNumber( c ) )
				{
					return false;
				}
			} return true;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Return true if update successfully. Otherwise return false
		/// </summary>
		public bool Success
		{
			get{return bln_Success;}
			set{bln_Success = value;}
		}
	}
}
