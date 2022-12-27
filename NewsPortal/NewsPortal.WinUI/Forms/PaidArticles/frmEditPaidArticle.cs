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
using NewsPortal.Model.Enums;

namespace NewsPortal.WinUI.Forms.PaidArticles
{
    public partial class frmEditPaidArticle : Form
    {

        private readonly APIService _articleService = new APIService("PaidArticle");
        ArticleUpsertRequest request = new ArticleUpsertRequest();
        private int? Id = null;
        MPaidArticle model=new MPaidArticle();
        public frmEditPaidArticle(int? articleId)
        {
            Id = articleId;
            InitializeComponent();
            InitializeStatus();
        }

        private async void frmEditArticle_Load(object sender, EventArgs e)
        {
            model = await _articleService.GetById<MPaidArticle>(Id);
            txtTitle.Text = model.Title;
            txtContent.Text = model.Content;
            cbStatus.SelectedValue = model.PaidArticleStatusId;
            txtKorisnik.Text = model.UserUsername;


        }
        private async void InitializeStatus()
        {
            Dictionary<string, int> dictionary = new Dictionary<string,int>();

            foreach (int enumValue in
            Enum.GetValues(typeof(PaidArticleStatus)))
            {
                dictionary.Add(Enum.GetName(typeof(PaidArticleStatus), enumValue), enumValue);
            }

            cbStatus.DisplayMember = "Key"; ;
            cbStatus.ValueMember = "Value";
            cbStatus.DataSource = new BindingSource(dictionary, null);


   
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var frm = new frmPaidArticleIndex();
            this.Close();
            frm.Show();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {

                    var request = new PaidArticleUpsertRequest
                    {
                        PaidArticleStatusId = (int)cbStatus.SelectedValue,
                        Content = txtContent.Text,
                        Title = txtTitle.Text,
                        CreateOn = model.CreateOn,
                        Active = model.Active,
                        UserId = model.UserId

                    };


                    try
                    {
                        var result = await _articleService.Update<MPaidArticle>(Id, request);
                        if (result != null)
                        {
                            MessageBox.Show("Paid article was updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var frm = new frmPaidArticleIndex();
                            this.Close();
                            frm.Show();
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }

                }

                catch
                {
                    MessageBox.Show("You don't have permission to do that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
