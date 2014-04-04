namespace Raiz.Main
{
    partial class frmCambioClave
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
            this.lblClaveAntigua = new System.Windows.Forms.Label();
            this.lblNuevaClave1 = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.TextBox();
            this.lblNuevaClave2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnAcepta = new System.Windows.Forms.Button();
            this.btnCancela = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblClaveAntigua
            // 
            this.lblClaveAntigua.AutoSize = true;
            this.lblClaveAntigua.Location = new System.Drawing.Point(11, 16);
            this.lblClaveAntigua.Name = "lblClaveAntigua";
            this.lblClaveAntigua.Size = new System.Drawing.Size(104, 13);
            this.lblClaveAntigua.TabIndex = 1;
            this.lblClaveAntigua.Text = "Tipee clave antigua:";
            // 
            // lblNuevaClave1
            // 
            this.lblNuevaClave1.AutoSize = true;
            this.lblNuevaClave1.Location = new System.Drawing.Point(11, 42);
            this.lblNuevaClave1.Name = "lblNuevaClave1";
            this.lblNuevaClave1.Size = new System.Drawing.Size(99, 13);
            this.lblNuevaClave1.TabIndex = 2;
            this.lblNuevaClave1.Text = "Tipee nueva clave:";
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(136, 13);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(100, 20);
            this.txt.TabIndex = 3;
            // 
            // lblNuevaClave2
            // 
            this.lblNuevaClave2.AutoSize = true;
            this.lblNuevaClave2.Location = new System.Drawing.Point(11, 69);
            this.lblNuevaClave2.Name = "lblNuevaClave2";
            this.lblNuevaClave2.Size = new System.Drawing.Size(109, 13);
            this.lblNuevaClave2.TabIndex = 4;
            this.lblNuevaClave2.Text = "Retipee nueva clave:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(136, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            // 
            // btnAcepta
            // 
            this.btnAcepta.Location = new System.Drawing.Point(80, 92);
            this.btnAcepta.Name = "btnAcepta";
            this.btnAcepta.Size = new System.Drawing.Size(75, 23);
            this.btnAcepta.TabIndex = 7;
            this.btnAcepta.Text = "Aceptar";
            this.btnAcepta.UseVisualStyleBackColor = true;
            // 
            // btnCancela
            // 
            this.btnCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancela.Location = new System.Drawing.Point(161, 92);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(75, 23);
            this.btnCancela.TabIndex = 8;
            this.btnCancela.Text = "Cancelar";
            this.btnCancela.UseVisualStyleBackColor = true;
            // 
            // frmCambioClave
            // 
            this.AcceptButton = this.btnAcepta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancela;
            this.ClientSize = new System.Drawing.Size(250, 125);
            this.Controls.Add(this.btnCancela);
            this.Controls.Add(this.btnAcepta);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblNuevaClave2);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.lblNuevaClave1);
            this.Controls.Add(this.lblClaveAntigua);
            this.Name = "frmCambioClave";
            this.Text = "Nueva Clave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClaveAntigua;
        private System.Windows.Forms.Label lblNuevaClave1;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Label lblNuevaClave2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnAcepta;
        private System.Windows.Forms.Button btnCancela;
    }
}