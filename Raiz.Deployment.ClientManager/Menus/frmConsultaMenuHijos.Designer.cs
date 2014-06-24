namespace Raiz.Deployment.ClientManager.Menus
{
    partial class frmConsultaMenuHijos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSALIR = new System.Windows.Forms.Button();
            this.lblMenuHijos = new System.Windows.Forms.Label();
            this.DgvMenuHijos = new System.Windows.Forms.DataGridView();
            this.TxtMenuPadre = new System.Windows.Forms.TextBox();
            this.lblMenuPadre = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMenuHijos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMenuHijos);
            this.groupBox1.Controls.Add(this.DgvMenuHijos);
            this.groupBox1.Controls.Add(this.TxtMenuPadre);
            this.groupBox1.Controls.Add(this.lblMenuPadre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 368);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // BtnSALIR
            // 
            this.BtnSALIR.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSALIR.Location = new System.Drawing.Point(380, 31);
            this.BtnSALIR.Name = "BtnSALIR";
            this.BtnSALIR.Size = new System.Drawing.Size(75, 23);
            this.BtnSALIR.TabIndex = 1;
            this.BtnSALIR.Text = "Salir";
            this.BtnSALIR.UseVisualStyleBackColor = true;
            this.BtnSALIR.Click += new System.EventHandler(this.BtnSALIR_Click);
            // 
            // lblMenuHijos
            // 
            this.lblMenuHijos.AutoSize = true;
            this.lblMenuHijos.Location = new System.Drawing.Point(4, 53);
            this.lblMenuHijos.Name = "lblMenuHijos";
            this.lblMenuHijos.Size = new System.Drawing.Size(63, 13);
            this.lblMenuHijos.TabIndex = 2;
            this.lblMenuHijos.Text = "Menu Hijos:";
            // 
            // DgvMenuHijos
            // 
            this.DgvMenuHijos.AllowUserToAddRows = false;
            this.DgvMenuHijos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMenuHijos.Location = new System.Drawing.Point(6, 69);
            this.DgvMenuHijos.Name = "DgvMenuHijos";
            this.DgvMenuHijos.ReadOnly = true;
            this.DgvMenuHijos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMenuHijos.Size = new System.Drawing.Size(437, 291);
            this.DgvMenuHijos.TabIndex = 3;
            // 
            // TxtMenuPadre
            // 
            this.TxtMenuPadre.Enabled = false;
            this.TxtMenuPadre.Location = new System.Drawing.Point(78, 13);
            this.TxtMenuPadre.Name = "TxtMenuPadre";
            this.TxtMenuPadre.Size = new System.Drawing.Size(144, 20);
            this.TxtMenuPadre.TabIndex = 1;
            // 
            // lblMenuPadre
            // 
            this.lblMenuPadre.AutoSize = true;
            this.lblMenuPadre.Location = new System.Drawing.Point(4, 16);
            this.lblMenuPadre.Name = "lblMenuPadre";
            this.lblMenuPadre.Size = new System.Drawing.Size(68, 13);
            this.lblMenuPadre.TabIndex = 0;
            this.lblMenuPadre.Text = "Menu Padre:";
            // 
            // frmConsultaMenuHijos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSALIR;
            this.ClientSize = new System.Drawing.Size(476, 392);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnSALIR);
            this.Name = "frmConsultaMenuHijos";
            this.Text = "Consulta Menu Hijos::..";
            this.Load += new System.EventHandler(this.frmConsultaMenuHijos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMenuHijos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DgvMenuHijos;
        private System.Windows.Forms.TextBox TxtMenuPadre;
        private System.Windows.Forms.Label lblMenuPadre;
        private System.Windows.Forms.Label lblMenuHijos;
        private System.Windows.Forms.Button BtnSALIR;
    }
}