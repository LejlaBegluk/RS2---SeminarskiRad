
namespace NewsPortal.WinUI.Forms.Poll
{
    partial class frmPollList
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
            this.Ankete = new System.Windows.Forms.GroupBox();
            this.dgvPolls = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPonisti = new System.Windows.Forms.Button();
            this.btnPretraga = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Ankete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolls)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            this.dgvPolls.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvPollList_MouseDoubleClick);

            // 
            // Ankete
            // 
            this.Ankete.Controls.Add(this.dgvPolls);
            this.Ankete.Location = new System.Drawing.Point(8, 144);
            this.Ankete.Name = "Ankete";
            this.Ankete.Size = new System.Drawing.Size(784, 280);
            this.Ankete.TabIndex = 4;
            this.Ankete.TabStop = false;
            this.Ankete.Text = "Ankete";
            // 
            // dgvPolls
            // 
            this.dgvPolls.AllowUserToAddRows = false;
            this.dgvPolls.AllowUserToDeleteRows = false;
            this.dgvPolls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPolls.Location = new System.Drawing.Point(7, 23);
            this.dgvPolls.Name = "dgvPolls";
            this.dgvPolls.ReadOnly = true;
            this.dgvPolls.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPolls.RowTemplate.Height = 25;
            this.dgvPolls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPolls.Size = new System.Drawing.Size(771, 251);
            this.dgvPolls.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPonisti);
            this.groupBox1.Controls.Add(this.btnPretraga);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 101);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pretraga";
            // 
            // btnPonisti
            // 
            this.btnPonisti.Location = new System.Drawing.Point(466, 33);
            this.btnPonisti.Name = "btnPonisti";
            this.btnPonisti.Size = new System.Drawing.Size(75, 23);
            this.btnPonisti.TabIndex = 5;
            this.btnPonisti.Text = "Ponisti";
            this.btnPonisti.UseVisualStyleBackColor = true;
            // 
            // btnPretraga
            // 
            this.btnPretraga.Location = new System.Drawing.Point(385, 33);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Size = new System.Drawing.Size(75, 23);
            this.btnPretraga.TabIndex = 4;
            this.btnPretraga.Text = "Pretraga";
            this.btnPretraga.UseVisualStyleBackColor = true;
            this.btnPretraga.Click += new System.EventHandler(this.btnPretraga_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(118, 33);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(228, 23);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv";
            // 
            // frmPollList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Ankete);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPollList";
            this.Text = "frmPollList";
            this.Load += new System.EventHandler(this.frmPollList_Load);
            this.Ankete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPolls)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Ankete;
        private System.Windows.Forms.DataGridView dgvPolls;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPonisti;
        private System.Windows.Forms.Button btnPretraga;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
    }
}