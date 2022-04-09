
namespace NewsPortal.WinUI.Forms.Users
{
    partial class frmAddUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.lbLastname = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lbPhone = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lbUsername = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.lbConfirmPass = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chbActive = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDeletePhoto = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhotoInput = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(243, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(201, 23);
            this.txtName.TabIndex = 1;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(243, 72);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(201, 23);
            this.txtLastname.TabIndex = 3;
            this.txtLastname.Validating += new System.ComponentModel.CancelEventHandler(this.txtLastname_Validating);
            // 
            // lbLastname
            // 
            this.lbLastname.AutoSize = true;
            this.lbLastname.Location = new System.Drawing.Point(123, 72);
            this.lbLastname.Name = "lbLastname";
            this.lbLastname.Size = new System.Drawing.Size(49, 15);
            this.lbLastname.TabIndex = 2;
            this.lbLastname.Text = "Prezime";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(243, 155);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(201, 23);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(123, 155);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(36, 15);
            this.lbEmail.TabIndex = 6;
            this.lbEmail.Text = "Email";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(243, 113);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(201, 23);
            this.txtPhone.TabIndex = 5;
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhone_Validating);
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Location = new System.Drawing.Point(123, 113);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(46, 15);
            this.lbPhone.TabIndex = 4;
            this.lbPhone.Text = "Telefon";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(243, 277);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(201, 23);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(123, 277);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(47, 15);
            this.lbPassword.TabIndex = 12;
            this.lbPassword.Text = "Lozinka";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "DatumRođenja";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(243, 194);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(201, 23);
            this.txtUsername.TabIndex = 9;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(123, 194);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(85, 15);
            this.lbUsername.TabIndex = 8;
            this.lbUsername.Text = "Korisničko ime";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Location = new System.Drawing.Point(243, 235);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(200, 23);
            this.dtpBirthDate.TabIndex = 14;
            this.dtpBirthDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpBirthDate_Validating);
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(242, 316);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '*';
            this.txtConfirmPass.Size = new System.Drawing.Size(201, 23);
            this.txtConfirmPass.TabIndex = 16;
            this.txtConfirmPass.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPass_Validating);
            // 
            // lbConfirmPass
            // 
            this.lbConfirmPass.AutoSize = true;
            this.lbConfirmPass.Location = new System.Drawing.Point(122, 316);
            this.lbConfirmPass.Name = "lbConfirmPass";
            this.lbConfirmPass.Size = new System.Drawing.Size(86, 15);
            this.lbConfirmPass.TabIndex = 15;
            this.lbConfirmPass.Text = "Potvrdi lozinku";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(242, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Spremi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(368, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Odustani";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(242, 350);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(201, 23);
            this.cbRole.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Uloga";
            // 
            // chbActive
            // 
            this.chbActive.AutoSize = true;
            this.chbActive.Location = new System.Drawing.Point(242, 379);
            this.chbActive.Name = "chbActive";
            this.chbActive.Size = new System.Drawing.Size(66, 19);
            this.chbActive.TabIndex = 21;
            this.chbActive.Text = "Aktivan";
            this.chbActive.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnDeletePhoto
            // 
            this.btnDeletePhoto.Location = new System.Drawing.Point(747, 29);
            this.btnDeletePhoto.Name = "btnDeletePhoto";
            this.btnDeletePhoto.Size = new System.Drawing.Size(58, 23);
            this.btnDeletePhoto.TabIndex = 39;
            this.btnDeletePhoto.Text = "Poništi";
            this.btnDeletePhoto.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "Slika";
            // 
            // txtPhotoInput
            // 
            this.txtPhotoInput.Enabled = false;
            this.txtPhotoInput.Location = new System.Drawing.Point(503, 30);
            this.txtPhotoInput.Name = "txtPhotoInput";
            this.txtPhotoInput.Size = new System.Drawing.Size(183, 23);
            this.txtPhotoInput.TabIndex = 37;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(503, 59);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(183, 89);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 36;
            this.pictureBox.TabStop = false;
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.Location = new System.Drawing.Point(692, 30);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(49, 23);
            this.btnAddPhoto.TabIndex = 35;
            this.btnAddPhoto.Text = "Dodaj";
            this.btnAddPhoto.UseVisualStyleBackColor = true;
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 450);
            this.Controls.Add(this.btnDeletePhoto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPhotoInput);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnAddPhoto);
            this.Controls.Add(this.chbActive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.lbConfirmPass);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.txtLastname);
            this.Controls.Add(this.lbLastname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "frmAddUser";
            this.Text = "frmAddUser";
            this.Load += new System.EventHandler(this.frmAddUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.Label lbLastname;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Label lbConfirmPass;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbActive;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnDeletePhoto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhotoInput;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnAddPhoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}