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

namespace NewsPortal.WinUI.Forms.Categories
{
    public partial class frmAddCategory : Form
    {
        private int? Id = null;
        private readonly APIService _category = new APIService("Category");
        public frmAddCategory(int? categoryId = null)
        {
            Id = categoryId;
            InitializeComponent();
        }
        private async void frmAddCategory_Load(object sender, EventArgs e)
        {
            if (Id != null)
            {
                var model = await _category.GetById<MCategory>(Id);
                txtName.Text = model.Name;
            }
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
                if (ValidateChildren())
                {
                    try
                    {
                   
                        var request = new CategoryUpsertRequest
                        {
                            Name = txtName.Text,
       
                        };

                        if (Id == null)
                        {
                            try
                            {
                 
                                var result = await _category.Insert<MCategory>(request);
                                if (result != null)
                                {
                                    MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    var frm = new frmCategoryList();
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
                                var result = await _category.Update<MCategory>(Id, request);
                                if (result != null)
                                {
                                    MessageBox.Show("Category was updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    var frm = new frmCategoryList();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var frm = new frmCategoryList();
            this.Close();
            frm.Show();
        }
        private void txtName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {

                errorProvider.SetError(txtName, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, null);
            }
        }
    }
}
