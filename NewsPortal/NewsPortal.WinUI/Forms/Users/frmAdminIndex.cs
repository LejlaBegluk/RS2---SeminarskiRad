using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewsPortal.WinUI.Forms.Users
{
    public partial class frmAdminIndex : Form
    {
        public frmAdminIndex(WebAPI.Model.MUser user)
        {
            InitializeComponent();
        }
    }
}
