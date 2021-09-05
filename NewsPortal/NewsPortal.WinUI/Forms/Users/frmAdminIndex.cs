using NewsPortal.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewsPortal.WinUI.Forms.Users
{
    public partial class frmAdminIndex : Form
    {
        public frmAdminIndex(WebAPI.Model.MUser user)
        {
            InitializeComponent();
        }

        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var m = new frmAddUser();
            m.Show();
            //PanelHelper.SwapPanels(this.Parent, this, new frmAddUser());
        }
    }
}
