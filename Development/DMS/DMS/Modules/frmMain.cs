using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using SCM.Presentation;
using SCM.DataAccessObject;
using SCM.BusinessObject;
using SCM.Utils;
using SCM.Controls;
using System.Threading;

using DotNetSkin.SkinControls;
using PureComponents.NicePanel;

namespace SCM
{
	/// <summary>
	/// Summary description for frmMain
	/// </summary>
	/// <remarks>
	/// Author: Le Dinh Nguyen. 
	/// </remarks>
	public class frmMain : System.Windows.Forms.Form
	{
		private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(frmMain));
		
		private System.ComponentModel.IContainer components;
		//private Control pnlToolBar;
		//private Panel pnlToolBar;

		#region Window Control

		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.ToolTip tip;
		private System.Windows.Forms.MainMenu mnuMain;
		#endregion Window Control

		public frmMain()
		{
			InitializeComponent();

			clsAutUserBO bo = new clsAutUserBO();
			DataTable dt = bo.GetCommonMenu();
			mnuMain = BuildMenu(dt);
			this.Menu = mnuMain;

			#region Old
//			if(clsStyleManager.Aqua)
//				pnlToolBar = clsStyleManager.CreateMainPanel();
//			else
//			{
//				pnlToolBar = new Panel();
//				((Panel)pnlToolBar).DockPadding.Top = 1;
//				((Panel)pnlToolBar).DockPadding.Bottom = 1;
//			}
//			pnlToolBar.Height = 24;
//			pnlToolBar.Dock = DockStyle.Top;
//			pnlToolBar.Visible = false;
//
//			this.Controls.Add(pnlToolBar);

			//clsTitleManager.InitTitle(this, mnuMain);
			#endregion

			try
			{
				string filename = clsSystemConfig.ImageFolder + ConfigurationManager.AppSettings["Background"];
				if(File.Exists(filename))
				{
					this.BackgroundImage = Image.FromFile(clsSystemConfig.ImageFolder + ConfigurationManager.AppSettings["Background"]);
				}
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
			}
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFile = new System.Windows.Forms.MenuItem();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFile});
            // 
            // mnuFile
            // 
            this.mnuFile.Index = 0;
            this.mnuFile.Text = "File";
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(656, 457);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Menu = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "SCM System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
		[STAThread]
		static void Main() 
		{
			if(clsSystemConfig.Init())
			{
                System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US", false);
                Application.CurrentCulture = ci;

                bool createdNew = true;
                using (Mutex mutex = new Mutex(true, "SCM", out createdNew))
                {
                    if (createdNew)
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new frmMain());
                    }
                }  
			}
			else
			{
 				MessageBox.Show(clsSystemConfig.GetMessage(), "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		//private static string TOOLBAR_BUTTON_INDEX = "TOOLBAR_BUTTON_INDEX";
		private static string TOOLBAR_NAME = "TOOLBAR_NAME";
		private static string FORM_ID = "FORM_ID";
		private static string FORM_NAME = "FORM_NAME";
		private static string MENU_NAME = "MENU_NAME";
		private static string MENU_ZORDER = "MENU_ZORDER";
		//private static string DESCRIPTION = "DESCRIPTION";
		//private static string MENU_PID = "MENU_PID";
		private static string ICON_NAME = "ICON_NAME";
		private static string AssemblyName = "SCM.Presentation.";
		private static string frmMainName = "frmMain.";

		/// <summary>
		/// Build dynamic menu
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
		private MainMenu BuildMenu(DataTable dt)
		{
			MainMenu mainMenu = new MainMenu();

			DataRow[]rows;
			rows = dt.Select("MENU_PID = 0", MENU_ZORDER);
			MDMenuItem item;
			Font font = this.Font;
			foreach(DataRow row in rows)
			{
				item = new MDMenuItem();

				item.ID = int.Parse(row[FORM_ID].ToString());
				item.Name = row[MENU_NAME].ToString();
				item.FormName = AssemblyName + row[FORM_NAME].ToString();
				item.Text = clsResources.GetTitle(frmMainName + row[MENU_NAME].ToString());
				item.Font = font;

				if(item.Name == clsConstants.MENU_WINDOWS)
				{
					item.MdiList = true;
				}

				mainMenu.MenuItems.Add(item);
				AddSub(item, dt);
			}
			return mainMenu;
		}

		/// <summary>
		/// Add sub menu item on recursive
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="dt"></param>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
        private void AddSub(MDMenuItem parent, DataTable dt)
        {
            DataRow[] rows = dt.Select(string.Format("MENU_PID = {0}", parent.ID), MENU_ZORDER);
            if (rows.Length > 0)
            {
                MDMenuItem item;
                string folder = clsSystemConfig.IconFolder;
                string iconName = null;
                Size size = new Size(14, 14);
                foreach (DataRow row in rows)
                {
                    item = new MDMenuItem();
                    item.Font = parent.Font;
                    item.OwnerDraw = true;
                    item.Name = row[MENU_NAME].ToString();
                    iconName = row[ICON_NAME].ToString();
                    if (iconName.Length > 0)
                    {
                        string filename = folder + iconName;
                        if (File.Exists(filename))
                        {
                            try
                            {
                                Icon icon = new Icon(filename);
                                item.Icon = icon;
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex.Message, ex);
                            }
                        }
                    }
                    if (item.Name == clsConstants.MENU_SEPARATE)
                    {
                        item.OwnerDraw = false;
                        item.Text = clsConstants.MINUS;
                        parent.MenuItems.Add(item);
                    }
                    else if (item.Name == clsConstants.MAXIMIZED)
                    {
                        item.Text = clsResources.GetTitle(frmMainName + row[MENU_NAME].ToString());

                        parent.MenuItems.Add(item);
                        item.Checked = clsFormManager.Maximized;
                        item.Click += new EventHandler(MenuItem_OnClick);
                    }
                    else if (item.Name == clsConstants.SYSTEM_STYLE)
                    {
                        item.Text = clsResources.GetTitle(frmMainName + row[MENU_NAME].ToString());

                        parent.MenuItems.Add(item);
                        item.Checked = clsStyleManager.SystemStyle;
                        item.Click += new EventHandler(MenuItem_OnClick);
                    }
                    else
                    {
                        item.ID = int.Parse(row[FORM_ID].ToString());
                        string formName = row[FORM_NAME].ToString();
                        if (formName.Length > 0)
                            item.FormName = AssemblyName + formName;
                        else
                            item.FormName = "";

                        item.Text = clsResources.GetTitle(frmMainName + row[MENU_NAME].ToString());
                        parent.MenuItems.Add(item);
                        AddSub(item, dt);
                    }
                }
            }
            else
            {
                parent.Click += new EventHandler(MenuItem_OnClick);
            }
        }

		/// <summary>
		/// Handle events when click on menu Item (Open window and other action).
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
		private void MenuItem_OnClick(object sender, EventArgs e)
		{
			string formName = "";

			MDMenuItem item = (MDMenuItem)sender;
			if(clsConstants.EXIT == item.Name)
			{
				this.Close();
			}			
            else if (clsConstants.MENU_HELP_TOPIC == item.Name)
            {
            }
            else if (clsConstants.MENU_HELP_ABOUT == item.Name)
            {
                frmAbout frmAbout = new frmAbout();
                frmAbout.ShowDialog();
            }
            else if (clsConstants.WINDOW_CASCADE == item.Name)
            {
                this.LayoutMdi(MdiLayout.Cascade);
            }
            else if (clsConstants.WINDOW_TILE_HOZ == item.Name)
            {
                this.LayoutMdi(MdiLayout.TileHorizontal);
            }
            else if (clsConstants.WINDOW_TILE_VERT == item.Name)
            {
                this.LayoutMdi(MdiLayout.TileVertical);
            }
            else if (clsConstants.WINDOW_CLOSE_ALL == item.Name)
            {
                CloseAllWindow();
            }
            else if (clsConstants.SYSTEM_STYLE == item.Name)
            {
                item.Checked = !item.Checked;
                clsStyleManager.SystemStyle = item.Checked;
            }
            else if (clsConstants.COLOR_FOCUS_CONTROL == item.Name)
            {
                item.Checked = !item.Checked;
                clsStyleManager.ColorFocusControl = item.Checked;
            }
            else if (clsConstants.MAXIMIZED == item.Name)
            {
                item.Checked = !item.Checked;
                clsFormManager.Maximized = item.Checked;
            }
            else if (clsConstants.SET_ENGLISH_LANGUAGE == item.Name)
            {
                clsResources.Init(clsConstants.ENGLISH);

                clsTitleManager.InitToolBarToolTip(this);
                //				tip.RemoveAll();
                //				foreach(Control ctrl in pnlToolBar.Controls)
                //				{
                //					tip.SetToolTip(ctrl, clsResources.GetTitle(frmMainName + ctrl.Name));
                //				}
                clsTitleManager.InitTitle(this, this.Menu);
                foreach (Form frm in this.MdiChildren)
                {
                    clsTitleManager.InitTitle(frm);
                }
            }
            else if (clsConstants.SET_VIETNAMESE_LANGUAGE == item.Name)
            {
                clsResources.Init(clsConstants.VIETNAMESE);
                clsTitleManager.InitToolBarToolTip(this);
                //				tip.RemoveAll();
                //				foreach(Control ctrl in pnlToolBar.Controls)
                //				{
                //					tip.SetToolTip(ctrl, clsResources.GetTitle(frmMainName + ctrl.Name));
                //				}
                clsTitleManager.InitTitle(this, this.Menu);
                foreach (Form frm in this.MdiChildren)
                {
                    clsTitleManager.InitTitle(frm);
                }
            }
            else if (clsConstants.LOG_OUT == item.Name)
            {
                if (MessageBox.Show(clsResources.GetMessage("messages.logout"), clsResources.GetMessage("messages.general"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CloseAllWindow();
                    this.Text = clsResources.GetTitle("frmMain.Title");
                    this.Menu = mnuMain;
                    //pnlToolBar.Visible = false;
                    clsCommon.RemoveAllToolBar(this);
                    mnuLogin_Click(null, null);
                }
            }
            else
            {
                formName = item.FormName;
                if (formName.Length > 0 && formName != AssemblyName)
                {
                    if (formName == "SCM.Presentation.frmLogin")
                    {
                        mnuLogin_Click(null, null);
                    }
                    else
                    {
                        Form frm = null;
                        try
                        {
                            frm = (Form)Activator.CreateInstance(Type.GetType(formName), null);
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex.Message, ex);
                            MessageBox.Show(clsResources.GetMessage("errors.form.create", formName));
                        }
                        if (frm != null)
                        {
                            clsFormManager.ShowMDIChild(frm);
                        }
                    }
                }
            }
		}

		/// <summary>
		/// Create tool bar
		/// </summary>
		/// <param name="dt"></param>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
        public void CreateToolBar(DataTable dt)
        {
            clsCommon.RemoveAllToolBar(this);
            ArrayList ctrls = new ArrayList();
            string otbName = null;
            string tbName = "";
            string description = null;
            string iconName = null;
            string filename;
            string folder = clsSystemConfig.IconFolder;
            Size size = new Size(180, 10);
            ToolBar tb = null;
            MDToolBarButton tbb = null;
            ImageList imgs = null;
            DataRow[] rows = dt.Select("TOOLBAR_BUTTON_INDEX >= 0", "TOOLBAR_NAME, TOOLBAR_BUTTON_INDEX");
            int index = 0;
            foreach (DataRow row in rows)
            {
                tbb = new MDToolBarButton();
                tbName = row[TOOLBAR_NAME].ToString();
                iconName = row[ICON_NAME].ToString();
                if (tbName != otbName)
                {
                    tb = new ToolBar();
                    tb.TextAlign = ToolBarTextAlign.Right;
                    tb.Dock = DockStyle.Left;
                    tb.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    tb.AutoSize = false;
                    //tb.Height = size.Height;
                    tb.Width = size.Width;
                    tb.ButtonSize = size;
                    tb.Appearance = ToolBarAppearance.Flat;
                    tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    imgs = new ImageList();
                    imgs.ColorDepth = ColorDepth.Depth32Bit;
                    //imgs.ImageSize = new Size(14,14);
                    index = 0;

                    // Create panel in order to toolbar can inherit backcolor
                    Panel pnl = new Panel();
                    pnl.BackColor =
                        System.Drawing.Color.FromArgb(((System.Byte)(142)), ((System.Byte)(179)), ((System.Byte)(231)));

                    pnl.ForeColor = Color.Green;
                    pnl.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    pnl.Size = new Size(180, 1000);
                    pnl.Controls.Add(tb);

                    // This toolbar holds panel
                    ToolBar tbx = new ToolBar();
                    tbx.Dock = DockStyle.Left;
                    tbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    tbx.Controls.Add(pnl);
                    tbx.AutoSize = false;
                    tbx.Size = pnl.Size;

                    ctrls.Add(tbx);
                    otbName = tbName;
                    tb.ImageList = imgs;
                    tb.ButtonClick += new ToolBarButtonClickEventHandler(ToolBarButtonOnClick);
                }

                tbb.Name = row[MENU_NAME].ToString();
                tbb.FormName = AssemblyName + row[FORM_NAME].ToString();
                description = clsResources.GetTitle(frmMainName + tbb.Name);

                tbb.Text = description;
                if (iconName.Length > 0)
                {
                    filename = folder + iconName;
                    if (File.Exists(filename))
                    {
                        try
                        {
                            Icon icon = new Icon(filename);
                            imgs.Images.Add(icon);
                            tbb.ImageIndex = index;
                            index++;
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex.Message, ex);
                        }
                    }
                }

                tb.Buttons.Add(tbb);
            }
            foreach (Control ctrl in ctrls)
                this.Controls.Add(ctrl);
        }

		/// <summary>
		/// Close all MDI Children Windows
		/// </summary>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
		public void CloseAllWindow()
		{
			while(this.MdiChildren.Length > 0)
			{
				foreach(Form frm in this.MdiChildren)
				{
					if(frm.Visible)
						frm.Close();
				}
			}
		}

		/// <summary>
		/// Open login form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
		private void mnuLogin_Click(object sender, System.EventArgs e)
		{
			int LoginResult = clsConstants.PASSWORD_WRONG;
			frmLogin frm = new frmLogin();
			if(frm.ShowDialog() == DialogResult.OK)
			{
				LoginResult = frm.LoginResult;
			}

			if(LoginResult == clsConstants.LOGIN_SUCCESS)
			{
				//SingleInstance.SingleApplication.Run(new frmMain());
				clsAutUserBO bo = new clsAutUserBO();
				DataTable dt = bo.GetAuthority();
				this.Menu = BuildMenu(dt);
				//CreateToolBar(dt);
				bo.ClearAuthority();
				this.Text = clsResources.GetTitle("frmMain.Title") + " - " + clsResources.GetMessage("messages.username.title", clsSystemConfig.UserName);
				clsFormManager.MainForm = this;
			}

		}

		/// <summary>
		/// Open login form on load events
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
		private void frmMain_Load(object sender, System.EventArgs e)
		{
			mnuLogin_Click(null, null);
		}

		/// <summary>
		/// Question before exit application. Do not exit application if user chooses "No".
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
		private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(MessageBox.Show(clsResources.GetMessage("messages.exit"), clsResources.GetMessage("messages.general"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Application.Exit();
			}
			else
			{
				e.Cancel = true;
			}
		}

		/// <summary>
		/// Handle event when click on Tool bar button (Open new window).
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Author:			Le Dinh Nguyen. 
		/// Created date:	14/05/2011
		/// </remarks>
		private void ToolBarButtonOnClick(object sender, ToolBarButtonClickEventArgs e)
		{
			MDToolBarButton tbb = e.Button as MDToolBarButton;
			if(tbb == null)
				return;

			string formName = tbb.FormName;
			Form frm = null;
			try
			{
				if(formName != AssemblyName)
					frm = (Form)Activator.CreateInstance(Type.GetType(formName), null);
			}
			catch(Exception ex)
			{
				log.Error(ex.Message, ex);
				MessageBox.Show(clsResources.GetMessage("errors.form.create", formName));
			}
			if(frm != null)
			{
				clsFormManager.ShowMDIChild(frm);
			}
		}
	}
}