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
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace NewsPortal.WinUI.Forms.Articles
{
    public partial class frmAddArticle : Form
    {
        private readonly APIService _category = new APIService("Category");
        private readonly APIService _userService = new APIService("User");
        private readonly APIService _articleService = new APIService("Article");

        ArticleUpsertRequest request = new ArticleUpsertRequest();
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
 
        private async void frmAddArticle_Load(object sender, EventArgs e)
        {
            try
            {

           
            if (Id.HasValue)
            {
                var model = await _articleService.GetById<MArticle>(Id);
                txtTitle.Text = model.Title;
                txtContent.Text = model.Content;
                cbCategory.SelectedValue = model.CategoryId;
                request.UserId = model.UserId;
                request.CreateOn = model.CreateOn;

                    byte[] image = model.Photo;

                MemoryStream ms=new MemoryStream(image);
                //ms.Flush();
                //ms.Position = 0;
                //ms = 
                if (ms.Length == 0 && ms.Position == 0 && ms.Capacity == 0)
                {

                    string startuppath = Path.GetDirectoryName(Application.ExecutablePath).Replace("NewsPortal.WinUI\\bin\\Debug\\net5.0-windows", string.Empty);
                    string s = "NewsPortal.WinUI\\Resources\\news.jpg";
                    var filename = startuppath + s;


                    Image imaged = Image.FromFile(filename);
                    pictureBox.Image = imaged;
                }
                else
                {
                       
                        pictureBox.Image =Image.FromStream(ms);
                }


                }
            else
                {
                    UserSearchRequest search = new UserSearchRequest()
                    {
                        Username = _userService.GetActiveUser()
                    };
                    var users = await _userService.Get<List<MUser>>(search);
                    request.UserId = users.FirstOrDefault().Id;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                var filename = openFileDialog1.FileName;
                var file = File.ReadAllBytes(openFileDialog1.FileName);
                request.Photo = file;
                txtPhotoInput.Text = filename;
                Image image = Image.FromFile(filename);
                pictureBox.Image = image;

            }

        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
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

                    request.CategoryId = (int)cbCategory.SelectedValue;
                    request.Content = txtContent.Text;
                    request.Title = txtTitle.Text;
                  
                    if (Id == null)
                    {
                        try
                        {                           
                            request.CreateOn = DateTime.Now;
                            var result = await _articleService.Insert<MArticle>(request);
                            if (result != null)
                            {
                                MessageBox.Show("Article added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            request.Id = (int)Id;
                            var result = await _articleService.Update<MArticle>(Id, request);
                            if (result != null)
                            {
                                MessageBox.Show("Article was updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
