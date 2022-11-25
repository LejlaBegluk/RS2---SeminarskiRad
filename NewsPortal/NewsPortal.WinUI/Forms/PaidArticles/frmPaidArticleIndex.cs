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

namespace NewsPortal.WinUI.Forms.PaidArticles
{
    public partial class frmPaidArticleIndex : Form
    {
        private readonly APIService _article = new APIService("PaidArticle");
       // private readonly APIService _category = new APIService("Category");

        public frmPaidArticleIndex()
        {
            InitializeComponent();
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            PaidArticleSearchRequest search = new PaidArticleSearchRequest()
            {
                 Text = txtName.Text
            };
            var result = await _article.Get<List<MPaidArticle>>(search);
          //  var categories = await _category.Get<List<MCategory>>(null);
            dgvArticle.DataSource = result.ToList();
        }
        private async void frmArticle_Load(object sender, EventArgs e)
        {
            var result = await _article.Get<IEnumerable<MPaidArticle>>(new PaidArticleSearchRequest());
            dgvArticle.AutoGenerateColumns = false;
            dgvArticle.ColumnCount = 5;
            dgvArticle.Columns[0].Name = "Id";
            dgvArticle.Columns[0].HeaderText = "Id";
            dgvArticle.Columns[0].DataPropertyName = "Id";
            dgvArticle.Columns[1].Name = "CreateOn";
            dgvArticle.Columns[1].HeaderText = "Datum";
            dgvArticle.Columns[1].DataPropertyName = "CreateOn";
            dgvArticle.Columns[2].Name = "Title";
            dgvArticle.Columns[2].HeaderText = "Naslov";
            dgvArticle.Columns[2].DataPropertyName = "Title";
            dgvArticle.Columns[3].Name = "PaidArticleStatusName";
            dgvArticle.Columns[3].HeaderText = "Status";
            dgvArticle.Columns[3].DataPropertyName = "PaidArticleStatusName";
            dgvArticle.Columns[4].Name = "UserUsername";
            dgvArticle.Columns[4].HeaderText = "Username";
            dgvArticle.Columns[4].DataPropertyName = "UserUsername";
            dgvArticle.DataSource = result.ToList();
        }

        private async void btnPonisti_Click(object sender, EventArgs e)
        {
            var result = await _article.Get<List<MArticle>>(null);
          //  var categories = await _category.Get<List<MCategory>>(null);
            txtName.Text = "";
            dgvArticle.DataSource = result.ToList();
        }

        private void dgvArticle_DoubleClick(object sender, MouseEventArgs e)
        {
            int id = int.Parse(dgvArticle.SelectedRows[0].Cells[0].Value.ToString());
            frmEditPaidArticle frm = new frmEditPaidArticle(id);
            frm.ShowDialog();
            this.Close();
        }

    }
}
