
namespace NewsPortal.WinUI.Forms.Poll
{
    partial class frmAddPoll
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Odgovori = new System.Windows.Forms.GroupBox();
            this.dgvPollAnswers = new System.Windows.Forms.DataGridView();
            this.btnAddAnswer = new System.Windows.Forms.Button();
            this.Odgovori.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPollAnswers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(362, 101);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Odustani";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(237, 101);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Spremi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(237, 57);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(238, 23);
            this.txtQuestion.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Pitanje";
            // 
            // Odgovori
            // 
            this.Odgovori.Controls.Add(this.dgvPollAnswers);
            this.Odgovori.Location = new System.Drawing.Point(50, 175);
            this.Odgovori.Name = "Odgovori";
            this.Odgovori.Size = new System.Drawing.Size(665, 234);
            this.Odgovori.TabIndex = 26;
            this.Odgovori.TabStop = false;
            this.Odgovori.Text = "Odgovori";
            // 
            // dgvPollAnswers
            // 
            this.dgvPollAnswers.AllowUserToAddRows = false;
            this.dgvPollAnswers.AllowUserToDeleteRows = false;
            this.dgvPollAnswers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPollAnswers.Location = new System.Drawing.Point(6, 22);
            this.dgvPollAnswers.Name = "dgvPollAnswers";
            this.dgvPollAnswers.ReadOnly = true;
            this.dgvPollAnswers.RowTemplate.Height = 25;
            this.dgvPollAnswers.Size = new System.Drawing.Size(653, 206);
            this.dgvPollAnswers.TabIndex = 0;
            this.dgvPollAnswers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPollAnswers_CellContentClick);
            // 
            // btnAddAnswer
            // 
            this.btnAddAnswer.Location = new System.Drawing.Point(50, 146);
            this.btnAddAnswer.Name = "btnAddAnswer";
            this.btnAddAnswer.Size = new System.Drawing.Size(75, 23);
            this.btnAddAnswer.TabIndex = 27;
            this.btnAddAnswer.Text = "Dodaj";
            this.btnAddAnswer.UseVisualStyleBackColor = true;
            this.btnAddAnswer.Click += new System.EventHandler(this.btnAddAnswer_Click);
            // 
            // frmAddPoll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 447);
            this.Controls.Add(this.btnAddAnswer);
            this.Controls.Add(this.Odgovori);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.label1);
            this.Name = "frmAddPoll";
            this.Text = "frmAddPoll";
            this.Load += new System.EventHandler(this.frmAddPoll_Load);
            this.Odgovori.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPollAnswers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Odgovori;
        private System.Windows.Forms.DataGridView dgvPollAnswers;
        private System.Windows.Forms.Button btnAddAnswer;
    }
}