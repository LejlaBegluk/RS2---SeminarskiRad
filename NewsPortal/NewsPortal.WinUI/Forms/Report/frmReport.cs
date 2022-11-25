using Microsoft.Reporting.WinForms;
using NewsPortal.Model.Request;
using NewsPortal.Model.ViewModels;
using NewsPortal.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NewsPortal.WinUI.Forms.Report
{
    public partial class frmReport : Form
    {
        private readonly APIService _userService = new APIService("User");
        private readonly APIService _commentService = new APIService("Comment");
        private readonly APIService _articleService = new APIService("Article");
        private readonly APIService _categoryService = new APIService("Category");
        List<ArticleReportViewModel> reportData = new List<ArticleReportViewModel>();
        public frmReport()
        {
            InitializeComponent();
        }
        private async void frmReport_Load(object sender, EventArgs e)
        {
            var result = await _userService.Get<List<MUser>>(null);

            cbJournalist.DataSource = result;
            cbJournalist.DisplayMember = "Username";
            cbJournalist.ValueMember = "Id";
            
        }
        Bitmap bmp;
        private void btnPrint_ClickAsync(object sender, EventArgs e)
        {
            frmPrint frm = new frmPrint(reportData);
            frm.ShowDialog();
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async  void btnSearch_Click(object sender, EventArgs e)
        {
            ArticleSearchRequest search = new ArticleSearchRequest()
            {
                UserID = (int)cbJournalist.SelectedValue,
                Title = String.Empty
            };
            var list = await _articleService.Get<List<MArticle>>(search);
            var user = await _userService.GetById<MUser>((int)cbJournalist.SelectedValue);
            var categories = await _categoryService.Get<List<MCategory>>(null);
            
            foreach (var item in list)
            {
                
                var comments = await _commentService.Get<List<MComment>>(new CommentSearchRequest() { Id=item.Id});
                reportData.Add(new ArticleReportViewModel
                {
                    CreateOn = item.CreateOn,
                    Likes = item.Likes,
                    Title = item.Title,
                    CommentNumber = comments==null?0:comments.Count(),
                    Journalist = user.FirstName + " " + user.LastName,
                    CategoryName = categories.Where(x => x.Id == item.CategoryId).Select(m => m.Name).FirstOrDefault()
            });


            }
            dgvReport.DataSource = reportData;

        }
    }
}
