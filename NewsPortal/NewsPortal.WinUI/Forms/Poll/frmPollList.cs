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

namespace NewsPortal.WinUI.Forms.Poll
{
    public partial class frmPollList : Form
    {
        private readonly APIService _poll = new APIService("Poll");
        public frmPollList()
        {
            InitializeComponent();
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            PollSearchRequest search = new PollSearchRequest()
            {
                Question = txtName.Text
            };
            var result = await _poll.Get<List<MPoll>>(search);

            dgvPolls.DataSource = result.ToList();
        }
        private async void btnPonisti_Click(object sender, EventArgs e)
        {
            var result = await _poll.Get<List<MPoll>>(null);
            dgvPolls.DataSource = result.ToList();
            txtName.Text = "";
        }
        private async void frmPollList_Load(object sender, EventArgs e)
        {
            var result = await _poll.Get<List<MPoll>>(null);
            dgvPolls.DataSource = result.ToList();
        }
        private void dgvPollList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = int.Parse(dgvPolls.SelectedRows[0].Cells[0].Value.ToString());
            frmAddPoll frm = new frmAddPoll(id);
            frm.ShowDialog();
            this.Close();
        }

    
    }
}
