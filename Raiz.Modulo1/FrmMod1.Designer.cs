namespace Raiz.Modulo1
{
    partial class FrmMod1
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
            this.mnuMod1 = new System.Windows.Forms.MenuStrip();
            this.modulo1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMod1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMod1
            // 
            this.mnuMod1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modulo1ToolStripMenuItem});
            this.mnuMod1.Location = new System.Drawing.Point(0, 0);
            this.mnuMod1.Name = "mnuMod1";
            this.mnuMod1.Size = new System.Drawing.Size(284, 24);
            this.mnuMod1.TabIndex = 0;
            this.mnuMod1.Text = "menuStrip1";
            // 
            // modulo1ToolStripMenuItem
            // 
            this.modulo1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu1ToolStripMenuItem,
            this.menu2ToolStripMenuItem});
            this.modulo1ToolStripMenuItem.Name = "modulo1ToolStripMenuItem";
            this.modulo1ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.modulo1ToolStripMenuItem.Text = "Modulo1";
            // 
            // menu1ToolStripMenuItem
            // 
            this.menu1ToolStripMenuItem.Name = "menu1ToolStripMenuItem";
            this.menu1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.menu1ToolStripMenuItem.Text = "Menu1";
            // 
            // menu2ToolStripMenuItem
            // 
            this.menu2ToolStripMenuItem.Name = "menu2ToolStripMenuItem";
            this.menu2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.menu2ToolStripMenuItem.Text = "Menu2";
            // 
            // FrmMod1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.mnuMod1);
            this.MainMenuStrip = this.mnuMod1;
            this.Name = "FrmMod1";
            this.Text = "Form1";
            this.mnuMod1.ResumeLayout(false);
            this.mnuMod1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMod1;
        private System.Windows.Forms.ToolStripMenuItem modulo1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu2ToolStripMenuItem;
    }
}

