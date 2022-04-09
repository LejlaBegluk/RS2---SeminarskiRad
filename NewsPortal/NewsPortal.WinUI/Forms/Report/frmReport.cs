using AspNetCore.Reporting;
using NewsPortal.Model.Request;
using NewsPortal.Model.ViewModels;
using NewsPortal.Services;
using NewsPortal.WebAPI.Model;
using NewsPortal.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsPortal.WinUI.Forms.Report
{
    public partial class frmReport : Form
    {
        private readonly APIService _userService = new APIService("User");
        private readonly APIService _commentService = new APIService("Comment");
        private readonly APIService _articleService = new APIService("Article");
        private readonly APIService _categoryService = new APIService("Category");

        private readonly LocalReport _localReport;
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
        private  void btnPrint_Click(object sender, EventArgs e)
        {
            int height = dgvReport.Height;
            dgvReport.Height = dgvReport.RowCount * dgvReport.RowTemplate.Height * 2;
            bmp = new Bitmap(dgvReport.Width, dgvReport.Height);
            dgvReport.DrawToBitmap(bmp, new Rectangle(0, 0, dgvReport.Width, dgvReport.Height));
            dgvReport.Height = height;
            printPreviewDialog1.ShowDialog();



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
            List<ArticleReportViewModel> reportData = new List<ArticleReportViewModel>();
            foreach (var item in list)
            {
                CommentSearchRequest commentSearch = new CommentSearchRequest()
                {
                    ArticleId = item.Id,
                    Text = String.Empty
                };
                var comments = await _commentService.Get<List<MComment>>(commentSearch);
                reportData.Add(new ArticleReportViewModel
                {
                    CreateOn = item.CreateOn,
                    Likes = item.Likes,
                    Title = item.Title,
                    CommentNumber = comments==null?0:comments.Count(),
                    Journalist = user.FirstName + " " + user.LastName,
                    CategoryName = categories.Where(x => x.Id == item.CategoryId).Select(m => m.Name).FirstOrDefault()
            });


                dgvReport.DataSource = reportData;
            }
        }
    }
}
