using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DMS.Presentation
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}