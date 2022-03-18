using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsPortal.WinUI.Forms.Articles
{
    public partial class frmAddArticle : Form
    {
        private readonly APIService _category = new APIService("Category");

        public  frmAddArticle()
        {
            InitializeCategory();
            InitializeComponent();
        }
        private async void InitializeCategory()
        {
            var categoryList = await _category.Get<List<MCategory>>(null);
            categoryList.Add(new MCategory { Id = 0, Name = "-Odaberite-" });
            cbCategory.DataSource = categoryList;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";
            cbCategory.SelectedValue = 0;
        }
        ArticleUpsertRequest request = new ArticleUpsertRequest();
        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                var filename = openFileDialog1.FileName;
                var file = File.ReadAllBytes(filename);
                request.Photo = file;
                txtPhotoInput.Text = filename;
                Image image = Image.FromFile(filename);
                pictureBox.Image = image;

            }

        }

        private void btnDeletePhoto_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            txtPhotoInput.Text = "";
            request.Photo = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var frm = new frmArticleIndex();
            this.Close();
            frm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
