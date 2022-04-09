using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using NewsPortal.WinUI.Helpers;
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

namespace NewsPortal.WinUI.Forms.Users
{
    public partial class frmAddUser : Form
    {
        private readonly APIService _userService = new APIService("User");
        private readonly APIService _roleService = new APIService("Role");
        private readonly APIService _userroleService = new APIService("UserRole");
        private int? Id = null;
        UserUpsertRequest request = new UserUpsertRequest();
        public frmAddUser(int? userId = null)
        {
            InitializeComponent();
            Id = userId;
        }
        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                var filename = openFileDialog1.FileName;
                var file = File.ReadAllBytes(openFileDialog1.FileName);
                request.Photo = file;
                request.PhotoThumb = file;
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
        private async void frmAddUser_Load(object sender, EventArgs e)
        {
            var result = await _roleService.Get<List<MRole>>(null);

            cbRole.DataSource = result;
            cbRole.DisplayMember = "Name";
            cbRole.ValueMember = "Id";

            if (Id != null)
            {
                var korisnik = await _userService.GetById<MUser>(Id);
                txtName.Text = korisnik.FirstName;
                txtLastname.Text = korisnik.LastName;
                txtEmail.Text = korisnik.Email;
                txtUsername.Text = korisnik.Username;
                txtPhone.Text = korisnik.PhoneNumber;
                dtpBirthDate.Value = korisnik.BirthDate;
                chbActive.Checked = korisnik.IsActive ;
                var uloge = await _userroleService.Get<List<MUserRole>>(null);
                var ulogekorisnika = uloge.Where(a => a.UserId == korisnik.Id).FirstOrDefault();
                cbRole.SelectedValue = ulogekorisnika.RoleId;
            }
        }
 
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() && txtPassword_Validating() && await txtUsername_Validating() && await txtEmail_Validating())
            {

                try
                {
                    // var roleList = clbRoles.CheckedItems.Cast<MRole>().Select(i => i.RoleID).ToList();

                    // var x = cbRole.SelectedItem;

                    request.FirstName = txtName.Text;
                    request.LastName = txtLastname.Text;
                    request.Username = txtUsername.Text;
                    request.Email = txtEmail.Text;
                    request.PhoneNumber = txtPhone.Text;
                    request.Password = txtPassword.Text;
                    request.PasswordConfirmation = txtConfirmPass.Text;
                    request.BirthDate = Convert.ToDateTime(dtpBirthDate.Value);
                    request.IsActive =Convert.ToBoolean(chbActive);
                    //  Image = pbUserImage.Image != null ? ImageHelper.SystemDrawingToByteArray(pbUserImage.Image) : null,
                    request.Role = (int)cbRole.SelectedValue;

                    if (Id == null)
                    {
                        try
                        {
                            request.CreateOn = DateTime.Now;
                            var result = await _userService.Insert<MUser>(request);
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
                            var result = await _userService.Update<MUser>(Id, request);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var frm = new frmUserList();
            this.Close();
            frm.Show();
        }
        #region Validating
        private async Task<bool> txtUsername_Validating()
        {
            var result = await _userService.Get<List<MUser>>(null);
            int id = Id ?? 0;
            foreach (var item in result)
                if (item.Username == txtUsername.Text && item.Id != id)
                {
                    MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            return true;
        }

        private async Task<bool> txtEmail_Validating()
        {
            var result = await _userService.Get<List<MUser>>(null);
            int id = Id ?? 0;
            foreach (var item in result)
                if (item.Email == txtEmail.Text && item.Id != id)
                {
                    MessageBox.Show("Email already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        private void txtLastname_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtLastname.Text))
            {

                errorProvider.SetError(txtLastname, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLastname, null);
            }
        }
        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {

                errorProvider.SetError(txtUsername, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtUsername, null);
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {

                errorProvider.SetError(txtEmail, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {

                errorProvider.SetError(txtPhone, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPhone, null);
            }
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {

                errorProvider.SetError(txtPassword, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPassword, null);
            }
        }
        private void txtConfirmPass_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {

                errorProvider.SetError(txtConfirmPass, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtConfirmPass, null);
            }
        }
        private void dtpBirthDate_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(dtpBirthDate.Text))
            {

                errorProvider.SetError(dtpBirthDate, "Required field");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtpBirthDate, null);
            }
        }
        #endregion
    }
}
