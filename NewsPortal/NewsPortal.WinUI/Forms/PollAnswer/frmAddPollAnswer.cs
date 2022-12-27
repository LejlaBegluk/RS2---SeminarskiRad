using NewsPortal.Model.Request;
using NewsPortal.WebAPI.Model;
using NewsPortal.WinUI.Forms.Poll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsPortal.WinUI.Forms.PollAnswer
{
    public partial class frmAddPollAnswer : Form
    {
        private int? pollId = null;
        private readonly APIService _pollAnswer = new APIService("PollAnswer");

        public frmAddPollAnswer(int? Id)
        {
            pollId = Id;
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {

                    var request = new PollAnswerUpsertRequest
                    {
                        Text = txtAnswer.Text,
                        PollId= (int)pollId,
                        Counter=0
                    };
                    
                            var result = await _pollAnswer.Insert<MPollAnswer>(request);
                            if (result != null)
                            {
                                MessageBox.Show("Answer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var frm = new frmAddPoll(pollId);
                                this.Close();
                                frm.Show();
                            }
                        }
                catch(Exception ex)
                {
                    MessageBox.Show("That answer already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var frm = new frmAddPoll(pollId);
            this.Close();
            frm.Show();
        }
    }
}
