﻿using NewsPortal.WinUI.Forms.Articles;
using NewsPortal.WinUI.Forms.Categories;
using NewsPortal.WinUI.Forms.PaidArticles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewsPortal.WinUI.Forms.Users
{
    public partial class frmEditorIndex : Form
    {
        public frmEditorIndex(WebAPI.Model.MUser user)
        {
            InitializeComponent();
        }


        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmCategoryList();
            //  frm.MdiParent = this;
            frm.Show();
        }

        private void novaKategorijaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var frm = new frmAddCategory();
            frm.Show();
        }

        private void pretragaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new frmArticleIndex();
            frm.Show();
        }

        private void pretragaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var frm = new frmPaidArticleIndex();
            frm.Show();
        }
    }
}
