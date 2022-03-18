
namespace NewsPortal.WinUI.Forms.Users
{
    partial class frmEditorIndex
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kategorijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaKategorijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.članciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noviČlanakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anketeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.novaAnketaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kategorijeToolStripMenuItem,
            this.članciToolStripMenuItem,
            this.anketeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kategorijeToolStripMenuItem
            // 
            this.kategorijeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem,
            this.novaKategorijaToolStripMenuItem});
            this.kategorijeToolStripMenuItem.Name = "kategorijeToolStripMenuItem";
            this.kategorijeToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.kategorijeToolStripMenuItem.Text = "Kategorije";
            // 
            // pretragaToolStripMenuItem
            // 
            this.pretragaToolStripMenuItem.Name = "pretragaToolStripMenuItem";
            this.pretragaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pretragaToolStripMenuItem.Text = "Pretraga";
            this.pretragaToolStripMenuItem.Click += new System.EventHandler(this.pretragaToolStripMenuItem_Click);
            // 
            // novaKategorijaToolStripMenuItem
            // 
            this.novaKategorijaToolStripMenuItem.Name = "novaKategorijaToolStripMenuItem";
            this.novaKategorijaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.novaKategorijaToolStripMenuItem.Text = "Nova kategorija";
            this.novaKategorijaToolStripMenuItem.Click += new System.EventHandler(this.novaKategorijaToolStripMenuItem_Click_1);
            // 
            // članciToolStripMenuItem
            // 
            this.članciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem1,
            this.noviČlanakToolStripMenuItem});
            this.članciToolStripMenuItem.Name = "članciToolStripMenuItem";
            this.članciToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.članciToolStripMenuItem.Text = "Članci";
            // 
            // pretragaToolStripMenuItem1
            // 
            this.pretragaToolStripMenuItem1.Name = "pretragaToolStripMenuItem1";
            this.pretragaToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.pretragaToolStripMenuItem1.Text = "Pretraga";
            this.pretragaToolStripMenuItem1.Click += new System.EventHandler(this.pretragaToolStripMenuItem1_Click);
            // 
            // noviČlanakToolStripMenuItem
            // 
            this.noviČlanakToolStripMenuItem.Name = "noviČlanakToolStripMenuItem";
            this.noviČlanakToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.noviČlanakToolStripMenuItem.Text = "Novi članak";
            // 
            // anketeToolStripMenuItem
            // 
            this.anketeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem2,
            this.novaAnketaToolStripMenuItem});
            this.anketeToolStripMenuItem.Name = "anketeToolStripMenuItem";
            this.anketeToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.anketeToolStripMenuItem.Text = "Ankete";
            // 
            // pretragaToolStripMenuItem2
            // 
            this.pretragaToolStripMenuItem2.Name = "pretragaToolStripMenuItem2";
            this.pretragaToolStripMenuItem2.Size = new System.Drawing.Size(140, 22);
            this.pretragaToolStripMenuItem2.Text = "Pretraga";
            // 
            // novaAnketaToolStripMenuItem
            // 
            this.novaAnketaToolStripMenuItem.Name = "novaAnketaToolStripMenuItem";
            this.novaAnketaToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.novaAnketaToolStripMenuItem.Text = "Nova anketa";
            // 
            // frmEditorIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmEditorIndex";
            this.Text = "frmEditorIndex";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kategorijeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaKategorijaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem članciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem noviČlanakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anketeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem novaAnketaToolStripMenuItem;
    }
}