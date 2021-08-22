using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewsPortal.WinUI.Users
{
    public partial class fmfLogin : Form
    {
        private APIService _api = new APIService("Uposlenik");
        public fmfLogin()
        {
            InitializeComponent();
        }


    }
}
