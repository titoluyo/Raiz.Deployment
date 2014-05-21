namespace Raiz.Deployment.ClientManager
{
    partial class frmDownload
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblDescarga = new System.Windows.Forms.Label();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblMsje = new System.Windows.Forms.Label();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(12, 86);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(394, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(135, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(159, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar descarga";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.Enabled = false;
            this.lblPorcentaje.Location = new System.Drawing.Point(102, 117);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(229, 23);
            this.lblPorcentaje.TabIndex = 2;
            this.lblPorcentaje.Text = "[  ]";
            // 
            // lblDescarga
            // 
            this.lblDescarga.Enabled = false;
            this.lblDescarga.Location = new System.Drawing.Point(128, 144);
            this.lblDescarga.Name = "lblDescarga";
            this.lblDescarga.Size = new System.Drawing.Size(174, 23);
            this.lblDescarga.TabIndex = 3;
            this.lblDescarga.Text = "[ ]";
            // 
            // lblVelocidad
            // 
            this.lblVelocidad.AutoSize = true;
            this.lblVelocidad.Enabled = false;
            this.lblVelocidad.Location = new System.Drawing.Point(182, 198);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(13, 13);
            this.lblVelocidad.TabIndex = 4;
            this.lblVelocidad.Text = "[]";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(117, 57);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(78, 23);
            this.btnIniciar.TabIndex = 5;
            this.btnIniciar.Text = "&Si";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblMsje
            // 
            this.lblMsje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsje.Location = new System.Drawing.Point(23, 12);
            this.lblMsje.Name = "lblMsje";
            this.lblMsje.Size = new System.Drawing.Size(383, 45);
            this.lblMsje.TabIndex = 6;
            this.lblMsje.Text = "[Mensaje]";
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(216, 57);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(78, 23);
            this.btnNo.TabIndex = 7;
            this.btnNo.Text = "&No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 234);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.lblMsje);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.lblVelocidad);
            this.Controls.Add(this.lblDescarga);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descarga..";
            this.Load += new System.EventHandler(this.frmDownload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblDescarga;
        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblMsje;
        private System.Windows.Forms.Button btnNo;
    }
}