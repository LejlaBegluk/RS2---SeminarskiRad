using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using NewsPortal.WinUI.Forms.PollAnswer;
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
    public partial class frmAddPoll : Form
    {
        private int? Id = null;
        private readonly APIService _poll = new APIService("Poll");
        private readonly APIService _pollAnswer = new APIService("PollAnswer");
        private readonly APIService _userService = new APIService("User");

        PollUpsertRequest request = new PollUpsertRequest();

        public frmAddPoll(int? pollId = null)
        {
            Id = pollId;
            InitializeComponent();
        }

        private async void frmAddPoll_Load(object sender, EventArgs e)
        {
            if (Id != null)
            {
                var model = await _poll.GetById<MPoll>(Id);
                txtQuestion.Text = model.Question;
                PollAnswerSearchRequest search = new PollAnswerSearchRequest()
                {
                    Text = ""
                };
                var result = await _pollAnswer.Get<List<MPollAnswer>>(search);

                dgvPollAnswers.DataSource = result.Where(x=>x.PollId==Id).ToList();
                request.UserId = model.UserId;
                request.CreateOn = model.CreateOn;
                var deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "btnDelete";
                deleteButton.HeaderText = "Delete";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;
              
                dgvPollAnswers.Columns.Add(deleteButton);


            }
            else
            {
                btnAddAnswer.Visible = false;
                UserSearchRequest search = new UserSearchRequest()
                {
                    Username = _userService.GetActiveUser()
                };
                var users = await _userService.Get<List<MUser>>(search);
                request.UserId = users.FirstOrDefault().Id;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {

                    request.Question = txtQuestion.Text;
                    if (Id == null)
                    {
                        try
                        {
                            request.CreateOn = DateTime.Now;
                            var result = await _poll.Insert<MPoll>(request);
                            if (result != null)
                            {
                                MessageBox.Show("Poll added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var frm = new frmPollList();
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
                        request.UpdateOn = DateTime.Now;
                        try
                        {
                            var result = await _poll.Update<MPoll>(Id, request);
                            if (result != null)
                            {
                                MessageBox.Show("Poll was updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var frm = new frmPollList();
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

        private void btnAddAnswer_Click(object sender, EventArgs e)
        {
            var frm = new frmAddPollAnswer(Id);
            this.Close();
            frm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var frm = new frmPollList();
            this.Close();
            frm.Show();
        }

        private void dgvPollAnswers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DialogResult result = MessageBox.Show("Do You Want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    //int id = int.Parse(dgvPollAnswers.SelectedRows[0].Cells[0].Value.ToString());
                    //_pollAnswer.Delete
                }
                else
                {
                }


            }
        }
    }
}
