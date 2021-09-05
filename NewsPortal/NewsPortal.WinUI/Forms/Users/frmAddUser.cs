using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using NewsPortal.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewsPortal.WinUI.Forms.Users
{
    public partial class frmAddUser : Form
    {
        private readonly APIService userService = new APIService("User");
        private readonly APIService roleService = new APIService("Role");
        string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";

        public frmAddUser()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                   // var roleList = clbRoles.CheckedItems.Cast<MRole>().Select(i => i.RoleID).ToList();

                    var request = new UserUpsertRequest
                    {
                        FirstName = txtName.Text,
                        LastName = txtLastname.Text,
                        Username = txtUsername.Text,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhone.Text,
                        Password = txtPassword.Text,
                        PasswordConfirmation = txtConfirmPass.Text,
                      //  Image = pbUserImage.Image != null ? ImageHelper.SystemDrawingToByteArray(pbUserImage.Image) : null,
                        Roles = new List<int>() { 1 }
                    };

                    await userService.Insert<MUser>(request);

                    MessageBox.Show("User added Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // PanelHelper.SwapPanels(this.Parent, this, new frmUserList());
                }
                catch
                {
                    MessageBox.Show("You don't have permission to do that!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
