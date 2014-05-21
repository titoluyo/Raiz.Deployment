namespace Raiz.Deployment.ServerManager
{
    partial class frmConectados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConectados));
            this.lvConectados = new System.Windows.Forms.ListView();
            this.btnNotificar = new System.Windows.Forms.Button();
            this.btnForzarCierre = new System.Windows.Forms.Button();
            this.btnVersInst = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvConectados
            // 
            this.lvConectados.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvConectados.Location = new System.Drawing.Point(12, 12);
            this.lvConectados.Name = "lvConectados";
            this.lvConectados.Size = new System.Drawing.Size(319, 448);
            this.lvConectados.TabIndex = 0;
            this.lvConectados.UseCompatibleStateImageBehavior = false;
            this.lvConectados.View = System.Windows.Forms.View.List;
            // 
            // btnNotificar
            // 
            this.btnNotificar.Location = new System.Drawing.Point(369, 22);
            this.btnNotificar.Name = "btnNotificar";
            this.btnNotificar.Size = new System.Drawing.Size(75, 23);
            this.btnNotificar.TabIndex = 1;
            this.btnNotificar.Text = "&Notificar";
            this.btnNotificar.UseVisualStyleBackColor = true;
            // 
            // btnForzarCierre
            // 
            this.btnForzarCierre.Location = new System.Drawing.Point(369, 51);
            this.btnForzarCierre.Name = "btnForzarCierre";
            this.btnForzarCierre.Size = new System.Drawing.Size(75, 23);
            this.btnForzarCierre.TabIndex = 2;
            this.btnForzarCierre.Text = "&Forzar cierre";
            this.btnForzarCierre.UseVisualStyleBackColor = true;
            this.btnForzarCierre.Click += new System.EventHandler(this.btnForzarCierre_Click);
            // 
            // btnVersInst
            // 
            this.btnVersInst.Location = new System.Drawing.Point(369, 80);
            this.btnVersInst.Name = "btnVersInst";
            this.btnVersInst.Size = new System.Drawing.Size(75, 23);
            this.btnVersInst.TabIndex = 3;
            this.btnVersInst.Text = "&Vers. Instal.";
            this.btnVersInst.UseVisualStyleBackColor = true;
            this.btnVersInst.Click += new System.EventHandler(this.btnVersInst_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(12, 477);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(355, 72);
            this.txtMensaje.TabIndex = 4;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(373, 477);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 72);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // frmConectados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 574);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.btnVersInst);
            this.Controls.Add(this.btnForzarCierre);
            this.Controls.Add(this.btnNotificar);
            this.Controls.Add(this.lvConectados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConectados";
            this.Text = "Lista de usuarios conectados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConectados_FormClosing);
            this.Load += new System.EventHandler(this.frmConectados_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvConectados;
        private System.Windows.Forms.Button btnNotificar;
        private System.Windows.Forms.Button btnForzarCierre;
        private System.Windows.Forms.Button btnVersInst;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btnEnviar;
    }
}