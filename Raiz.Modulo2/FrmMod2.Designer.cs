namespace Raiz.Modulo2
{
    partial class FrmMod2
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
            this.modulo2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu23ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu22ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modulo2ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // modulo2ToolStripMenuItem
            // 
            this.modulo2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu23ToolStripMenuItem,
            this.menu22ToolStripMenuItem});
            this.modulo2ToolStripMenuItem.Name = "modulo2ToolStripMenuItem";
            this.modulo2ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.modulo2ToolStripMenuItem.Text = "Modulo2";
            // 
            // menu23ToolStripMenuItem
            // 
            this.menu23ToolStripMenuItem.Name = "menu23ToolStripMenuItem";
            this.menu23ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.menu23ToolStripMenuItem.Text = "Menu21";
            // 
            // menu22ToolStripMenuItem
            // 
            this.menu22ToolStripMenuItem.Name = "menu22ToolStripMenuItem";
            this.menu22ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.menu22ToolStripMenuItem.Text = "Menu22";
            // 
            // FrmMod2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMod2";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modulo2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu23ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu22ToolStripMenuItem;
    }
}

