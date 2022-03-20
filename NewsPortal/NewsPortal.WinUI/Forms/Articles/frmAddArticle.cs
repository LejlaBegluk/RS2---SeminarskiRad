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
        private readonly APIService _userService = new APIService("User");

        private int? Id = null;
        public  frmAddArticle(int? articleId)
        {
            Id = articleId;
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {

                    var request = new ArticleUpsertRequest
                    {
                          CategoryId = (int)cbCategory.SelectedValue,
                           Content=txtContent.Text,
                              Title=txtTitle.Text,
                              //  UserId= _userService.

                    };

                    if (Id == null)
                    {
                        try
                        {
                            request.CreateOn = DateTime.Now;
                            var result = await _category.Insert<MCategory>(request);
                            if (result != null)
                            {
                                MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var frm = new frmArticleIndex();
                                this.Close();
                                frm.Show();
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            request.UpdatedOn = DateTime.Now;

                            var result = await _category.Update<MCategory>(Id, request);
                            if (result != null)
                            {
                                MessageBox.Show("Category was updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var frm = new frmArticleIndex();
                                this.Close();
                                frm.Show();
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }

                    }
                }
                catch
                {
                    MessageBox.Show("You don't have permission to do that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #region Validating
        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {

                errorProvider.SetError(txtTitle, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTitle, null);
            }
        }
        private void cbCategory_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(cbCategory.Text))
            {

                errorProvider.SetError(cbCategory, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cbCategory, null);
            }
        }
        private void txtContent_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {

                errorProvider.SetError(txtContent, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtContent, null);
            }
        }
        #endregion
    }
}
