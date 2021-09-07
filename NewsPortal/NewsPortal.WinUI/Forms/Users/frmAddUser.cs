using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using NewsPortal.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsPortal.WinUI.Forms.Users
{
    public partial class frmAddUser : Form
    {
        private readonly APIService userService = new APIService("User");
        private readonly APIService roleService = new APIService("Role");
        private readonly APIService userroleService = new APIService("UserRole");
        private int? Id = null;

        public frmAddUser(int? userId = null)
        {
            InitializeComponent();
            Id = userId;
        }

        private async void frmAddUser_Load(object sender, EventArgs e)
        {
            var result = await roleService.Get<List<MRole>>(null);

            cbRole.DataSource = result;
            cbRole.DisplayMember = "Name";
            cbRole.ValueMember = "Id";

            if (Id != null)
            {
                var korisnik = await userService.GetById<MUser>(Id);
                txtName.Text = korisnik.FirstName;
                txtLastname.Text = korisnik.LastName;
                txtEmail.Text = korisnik.Email;
                txtUsername.Text = korisnik.Username;
                txtPhone.Text = korisnik.PhoneNumber;
                dtpBirthDate.Value = korisnik.BirthDate;
                chbActive.Checked = korisnik.IsActive ;
                var uloge = await userroleService.Get<List<MUserRole>>(null);
                var ulogekorisnika = uloge.Where(a => a.UserId == korisnik.Id).FirstOrDefault();
                cbRole.SelectedValue = ulogekorisnika.RoleId;
            }
        }
        private async Task<bool> txtUsername_Validating()
        {
            var result = await userService.Get<List<MUser>>(null);
            int id = Id ?? 0;
            foreach (var item in result)
                if (item.Username == txtUsername.Text && item.Id != id)
                {
                    MessageBox.Show("Username already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
      
            return true;
        }

        private async Task<bool> txtEmail_Validating()
        {
            var result = await userService.Get<List<MUser>>(null);
            int id = Id ?? 0;
            foreach (var item in result)
                if (item.Email == txtEmail.Text && item.Id != id)
                {
                    MessageBox.Show("Email already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            return true;
        }

        private bool txtPassword_Validating()
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (Id.HasValue)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Password is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (txtPassword.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Passwords don't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() && txtPassword_Validating() && await txtUsername_Validating() && await txtEmail_Validating())
            {
                try
                {
                    // var roleList = clbRoles.CheckedItems.Cast<MRole>().Select(i => i.RoleID).ToList();


                    var x = cbRole.SelectedItem;

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
                        Role = (int)cbRole.SelectedValue
                    };

                    if (Id == null)
                    {
                        try
                        {
                            var result = await userService.Insert<MUser>(request);
                            if (result != null)
                            {
                                MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var frm = new frmUserList();
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
                            var result = await userService.Update<MUser>(Id, request);
                            if (result != null)
                            {
                                MessageBox.Show("User was updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var frm = new frmUserList();
                                this.Close();
                                frm.Show();
                            }
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message);
                        }

                      

                   // PanelHelper.SwapPanels(this.Parent, this, new frmUserList());
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
