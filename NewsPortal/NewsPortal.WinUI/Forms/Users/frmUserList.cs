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
    public partial class frmUserList : Form
    {
        private readonly APIService _user = new APIService("User");
        private readonly APIService _userRole = new APIService("UserRole");
        private readonly APIService _role = new APIService("Role");

        public frmUserList()
        {
            InitializeComponent();
            dgvUsers.AutoGenerateColumns = true;

        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            UserSearchRequest search = new UserSearchRequest()
            {
                Username = txtUsername.Text
            };
            var result = await _user.Get<List<MUser>>(search);
            foreach (var item in result)
            {
                if (item.IsActive == true)
                    item.Active = "DA";
                else
                    item.Active = "NE";

                item.Uloga += item.Role.Name;

            }


            dgvUsers.DataSource = result.ToList();


        }
        private async void frmUserList_Load(object sender, EventArgs e)
        {
            var result = await _user.Get<IEnumerable<MUser>>(null);
            foreach (var item in result)
            {
                if (item.IsActive == true)
                    item.Active = "DA";

                item.Uloga +=item.Role.Name;

            }

            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.ColumnCount = 5;
            dgvUsers.Columns[0].Name = "Id";
            dgvUsers.Columns[0].HeaderText = "Id";
            dgvUsers.Columns[0].DataPropertyName = "Id";
            dgvUsers.Columns[1].Name = "FirstName";
            dgvUsers.Columns[1].HeaderText = "Ime";
            dgvUsers.Columns[1].DataPropertyName = "FirstName";
            dgvUsers.Columns[2].Name = "LastName";
            dgvUsers.Columns[2].HeaderText = "Prezime";
            dgvUsers.Columns[2].DataPropertyName = "LastName";
            dgvUsers.Columns[3].Name = "Username";
            dgvUsers.Columns[3].HeaderText = "Username";
            dgvUsers.Columns[3].DataPropertyName = "Username";

            dgvUsers.Columns[4].Name = "Uloga";
            dgvUsers.Columns[4].HeaderText = "Uloga";
            dgvUsers.Columns[4].DataPropertyName = "Uloga";

            dgvUsers.DataSource = result.ToList();

            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "btnDelete";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;

            dgvUsers.Columns.Add(deleteButton);

        }

        private async void btnPonisti_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            var result = await _user.Get<List<MUser>>(null);
            foreach (var item in result)
            {
                if (item.IsActive == true)
                    item.Active = "DA";

                item.Uloga += item.Role.Name; 

            }


            dgvUsers.DataSource = result.ToList();
        }

        private void dgvUserList_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            int idKorisnika = int.Parse(dgvUsers.SelectedRows[0].Cells[0].Value.ToString());
            frmAddUser frm = new frmAddUser(idKorisnika);
            frm.ShowDialog();
            this.Close();
        }
        private async void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    // int id = int.Parse(dgvPollAnswers.SelectedRows[0].Cells[0].Value.ToString());
                    DataGridViewRow row = this.dgvUsers.Rows[e.RowIndex];
                    int id = Int32.Parse(row.Cells["Id"].Value.ToString());
                    var isDeleted = await _user.Delete(id);
                    this.Close();
                    if (isDeleted)
                    {
                        var frm = new frmUserList();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Record is connected to other objects in system.", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                }


            }

        }
    }
}
