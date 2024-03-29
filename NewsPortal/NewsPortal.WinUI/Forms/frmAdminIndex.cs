﻿using NewsPortal.WebAPI.Model;
using NewsPortal.WinUI.Forms.Articles;
using NewsPortal.WinUI.Forms.Categories;
using NewsPortal.WinUI.Forms.PaidArticles;
using NewsPortal.WinUI.Forms.Poll;
using NewsPortal.WinUI.Forms.Report;
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

        private void pretragaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new frmCategoryList();
            //  frm.MdiParent = this;
            frm.Show();
        }

        private void novaKategorijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmAddCategory();
            frm.Show();
        }

        private void pretragaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var frm = new frmArticleIndex();
            frm.Show();
        }

        private async void noviČlanakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmAddArticle(null);
            frm.Show();
        }

        private void pretragaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var frm = new frmPollList();
            frm.Show();
        }

        private void novaAnketaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmAddPoll();
            frm.Show();
        }

        private void izvještajONovinarimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmReport();
            frm.Show();
        }

        private void pretragaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var frm = new frmPaidArticleIndex();
            frm.Show();
        }
    }
}
