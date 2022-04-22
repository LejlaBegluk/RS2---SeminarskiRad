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
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDelete";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;

            dgvCategories.Columns.Add(deleteButton);
        }
        private void dgvCategoryList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = int.Parse(dgvCategories.SelectedRows[0].Cells[0].Value.ToString());
            frmAddCategory frm = new frmAddCategory(id);
            frm.ShowDialog();
            this.Close();
        }
        private async void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    // int id = int.Parse(dgvPollAnswers.SelectedRows[0].Cells[0].Value.ToString());
                    DataGridViewRow row = this.dgvCategories.Rows[e.RowIndex];
                    int id = Int32.Parse(row.Cells["Id"].Value.ToString());
                    var isDeleted=await _category.Delete(id);
                    this.Close();
                    if (isDeleted)
                    {
                        var frm = new frmCategoryList();
                        frm.Show();
                    }
                    else {
                        MessageBox.Show("Record is connected to other objects in system.", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                }


            }
        }
    }
}
