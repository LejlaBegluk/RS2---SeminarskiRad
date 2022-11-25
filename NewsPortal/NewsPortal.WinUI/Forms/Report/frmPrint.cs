using Microsoft.Reporting.WinForms;
using NewsPortal.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NewsPortal.WinUI.ReportDataSet;
namespace NewsPortal.WinUI.Forms.Report
{
    public partial class frmPrint : Form
    {
        List<ArticleReportViewModel> reportData;
        public frmPrint(List<ArticleReportViewModel> data)
        {
            reportData= data;
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {

            // // var parameter = new ReportParameter("BuyerName", _model.FirstOrDefault().FirstName + " " + _model.FirstOrDefault().LastName);
            reportViewer1.LocalReport.ReportEmbeddedResource = "NewsPortal.WinUI.Forms.Report.rptArticle.rdlc";
            reportViewer1.RefreshReport();
            var tblOutputs = new ReportDataSet.dsEmployee.dtEmployeeDataTable();
              var rb = 1;
             foreach (var item in reportData)
            {
                var row = tblOutputs.NewdtEmployeeRow();
                row.Rb = rb++.ToString();
                row.CreateOn = item.CreateOn.ToString("dd.MM.yyyy");
                row.Title = item.Title;
                row.Journalist = item.Journalist;
                row.Likes = item.Likes.ToString();
                row.Comments = item.CommentNumber.ToString();
                row.Category = item.CategoryName;
                tblOutputs.AdddtEmployeeRow(row);
            }

            var dataSource = new ReportDataSource();
            dataSource.Name = "dsEmployee";
            dataSource.Value = tblOutputs;


            reportViewer1.LocalReport.DataSources.Add(dataSource);
            reportViewer1.RefreshReport();

        }
    }
}
