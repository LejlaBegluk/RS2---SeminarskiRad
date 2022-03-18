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
            var result = await _article.Get<List<MArticle>>(null);
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
    }
}
