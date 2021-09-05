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
            var frm = new frmAddUser();
           // frm.MdiParent = this;
            frm.Show();
            //PanelHelper.SwapPanels(this.Parent, this, new frmAddUser());
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmUserList();
          //  frm.MdiParent = this;
            frm.Show();
        }
    }
}
