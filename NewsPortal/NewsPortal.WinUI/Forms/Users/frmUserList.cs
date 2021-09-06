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
            var result2 = await _userRole.Get<List<MUserRole>>(null);
            foreach (var item in result)
            {
                if (item.IsActive == true)
                    item.Active = "DA";

                var userrole = result2.Where(x => x.UserId == item.Id).FirstOrDefault();
                var role = await _role.GetById<MRole>(userrole.RoleId);
                item.Uloga += role.Name;

            }


            dgvUsers.DataSource = result.ToList();


        }
        private async void frmUserList_Load(object sender, EventArgs e)
        {
            var result = await _user.Get<List<MUser>>(null);
            var result2 = await _userRole.Get<List<MUserRole>>(null);
            foreach (var item in result)
            {
                if (item.IsActive == true)
                    item.Active = "DA";

               var userrole = result2.Where(x=>x.UserId==item.Id).FirstOrDefault();
               var role = await _role.GetById<MRole>(userrole.RoleId);
                item.Uloga += role.Name;

            }


            dgvUsers.DataSource = result.ToList();

        }

        private async void btnPonisti_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            var result = await _user.Get<List<MUser>>(null);
            var result2 = await _userRole.Get<List<MUserRole>>(null);
            foreach (var item in result)
            {
                if (item.IsActive == true)
                    item.Active = "DA";

                var userrole = result2.Where(x => x.UserId == item.Id).FirstOrDefault();
                var role = await _role.GetById<MRole>(userrole.RoleId);
                item.Uloga += role.Name;

            }


            dgvUsers.DataSource = result.ToList();
        }
    }
}
