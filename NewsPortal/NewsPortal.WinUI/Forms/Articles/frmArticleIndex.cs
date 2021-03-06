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

namespace NewsPortal.WinUI.Forms.Articles
{
    public partial class frmArticleIndex : Form
    {
        private readonly APIService _article = new APIService("Article");
        private readonly APIService _category = new APIService("Category");

        public frmArticleIndex()
        {
            InitializeComponent();
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            ArticleSearchRequest search = new ArticleSearchRequest()
            {
                Title = txtName.Text
            };
            var result = await _article.Get<List<MArticle>>(search);
            var categories = await _category.Get<List<MCategory>>(null);

            foreach (var item in result)
            {
                if (item.Active == true)
                    item.ActiveStatus = "DA";
                else
                    item.ActiveStatus = "NE";

                item.CategoryName = categories.Where(x => x.Id == item.CategoryId).Select(m => m.Name).FirstOrDefault();
            }
            dgvArticle.DataSource = result.ToList();
        }
        private async void frmArticle_Load(object sender, EventArgs e)
        {
            var result = await _article.Get<IEnumerable<MArticle>>(null);
            var categories = await _category.Get<IEnumerable<MCategory>>(null);

            foreach (var item in result)
            {
                if (item.Active == true)
                    item.ActiveStatus = "DA";
                else
                    item.ActiveStatus = "NE";

                item.CategoryName = categories.Where(x => x.Id == item.CategoryId).Select(m => m.Name).FirstOrDefault();
            }
            dgvArticle.AutoGenerateColumns = false;
            dgvArticle.ColumnCount = 4;
            dgvArticle.Columns[0].Name = "Id";
            dgvArticle.Columns[0].HeaderText = "Id";
            dgvArticle.Columns[0].DataPropertyName = "Id";
            dgvArticle.Columns[1].Name = "Title";
            dgvArticle.Columns[1].HeaderText = "Title";
            dgvArticle.Columns[1].DataPropertyName = "Title";
            dgvArticle.Columns[2].Name = "CategoryName";
            dgvArticle.Columns[2].HeaderText = "Category";
            dgvArticle.Columns[2].DataPropertyName = "CategoryName";
            dgvArticle.Columns[3].Name = "ActiveStatus";
            dgvArticle.Columns[3].HeaderText = "Active";
            dgvArticle.Columns[3].DataPropertyName = "ActiveStatus";


            dgvArticle.DataSource = result.ToList();
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDelete";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;

            dgvArticle.Columns.Add(deleteButton);
        }

        private async void btnPonisti_Click(object sender, EventArgs e)
        {
            var result = await _article.Get<List<MArticle>>(null);
            var categories = await _category.Get<List<MCategory>>(null);
            txtName.Text = "";
            foreach (var item in result)
            {
                if (item.Active == true)
                    item.ActiveStatus = "DA";
                else
                    item.ActiveStatus = "NE";

                item.CategoryName = categories.Where(x => x.Id == item.CategoryId).Select(m => m.Name).FirstOrDefault();
            }
            dgvArticle.DataSource = result.ToList();
        }

        private void dgvArticle_DoubleClick(object sender, MouseEventArgs e)
        {
            int id = int.Parse(dgvArticle.SelectedRows[0].Cells[0].Value.ToString());
            frmAddArticle frm = new frmAddArticle(id);
            frm.ShowDialog();
            this.Close();
        }
        private async void dgvArticle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    // int id = int.Parse(dgvPollAnswers.SelectedRows[0].Cells[0].Value.ToString());
                    DataGridViewRow row = this.dgvArticle.Rows[e.RowIndex];
                    int id = Int32.Parse(row.Cells["Id"].Value.ToString());
                    var isDeleted = await _article.Delete(id);
                    this.Close();
                    if (isDeleted)
                    {
                        var frm = new frmArticleIndex();
                        frm.Show();
                    }
                    else
                    {
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
