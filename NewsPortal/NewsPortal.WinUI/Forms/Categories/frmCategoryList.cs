using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsPortal.WinUI.Forms.Categories
{
    public partial class frmCategoryList : Form
    {
        private readonly APIService _category = new APIService("Category");
        public frmCategoryList()
        {
            InitializeComponent();
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
           CategorySearchRequest search = new CategorySearchRequest()
            {
                Name = txtName.Text
            };
            var result = await _category.Get<List<MCategory>>(search);

            dgvCategories.DataSource = result.ToList();
        }

       private async void btnPonisti_Click(object sender, EventArgs e)
        {
            var result = await _category.Get<List<MCategory>>(null);
            dgvCategories.DataSource = result.ToList();
            txtName.Text = ""; 
        }
        private async void frmCategoryList_Load(object sender, EventArgs e)
        {
            var result = await _category.Get<List<MCategory>>(null);
            dgvCategories.DataSource = result.ToList();
        }
        private void dgvCategoryList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = int.Parse(dgvCategories.SelectedRows[0].Cells[0].Value.ToString());
            frmAddCategory frm = new frmAddCategory(id);
            frm.ShowDialog();
            this.Close();
        }

    }
}
