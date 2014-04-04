namespace Raiz.Main.Notifier
{
    partial class Form1
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
            this.btnNotify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNotify
            // 
            this.btnNotify.Location = new System.Drawing.Point(12, 12);
            this.btnNotify.Name = "btnNotify";
            this.btnNotify.Size = new System.Drawing.Size(75, 23);
            this.btnNotify.TabIndex = 0;
            this.btnNotify.Text = "Notificar";
            this.btnNotify.UseVisualStyleBackColor = true;
            this.btnNotify.Click += new System.EventHandler(this.btnNotify_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 177);
            this.Controls.Add(this.btnNotify);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNotify;
    }
}

