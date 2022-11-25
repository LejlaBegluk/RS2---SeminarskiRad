using NewsPortal.Model.Enums;
using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewsPortal.WinUI.Forms.Users
{
    public partial class frmLogin : Form
    {
        private APIService _api = new APIService("User");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void LoadPanel(MUser user)
        {

            if (user.RoleId == (int)Roles.Admin)
            {
                var form = new frmAdminIndex(user);
                form.Show();
            }
            else if (user.RoleId == (int)Roles.Editor || user.RoleId == (int)Roles.Journalist)
            {
                var form = new frmEditorIndex(user);
                form.Show();
            }
            else
            {
                MessageBox.Show("Please use right credentials to login!");
                frmLogin frm = new frmLogin();
                frm.Show();
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                APIService.Username = txtUserName.Text;
                APIService.Password = txtPassword.Text;

                var request = new UserAuthenticationRequest()
                {
                    Username = APIService.Username,
                    Password = APIService.Password
                };

                var user = await _api.Authenticate(APIService.Username, APIService.Password);
              
                if (user != null)
                {
                    LoadPanel(user);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Username Or Password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Authentikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
