namespace Raiz.Deployment.ServerManager
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPase = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbProduccion = new System.Windows.Forms.RadioButton();
            this.rbTesting = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscarComponente = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarOrigen = new System.Windows.Forms.Button();
            this.txtRutaOrigen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fbd1 = new System.Windows.Forms.FolderBrowserDialog();
            this.grillaComponentes = new System.Windows.Forms.DataGridView();
            this.Componente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.btnBuscarDestino = new System.Windows.Forms.Button();
            this.txtRutaDestino = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fbd2 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaComponentes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPase);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnBuscarComponente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBuscarOrigen);
            this.groupBox1.Controls.Add(this.txtRutaOrigen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Origen de componentes";
            // 
            // lblPase
            // 
            this.lblPase.Location = new System.Drawing.Point(67, 132);
            this.lblPase.Name = "lblPase";
            this.lblPase.Size = new System.Drawing.Size(426, 43);
            this.lblPase.TabIndex = 9;
            this.lblPase.Text = "Pase:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbProduccion);
            this.groupBox3.Controls.Add(this.rbTesting);
            this.groupBox3.Location = new System.Drawing.Point(124, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(267, 35);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // rbProduccion
            // 
            this.rbProduccion.AutoSize = true;
            this.rbProduccion.Location = new System.Drawing.Point(146, 12);
            this.rbProduccion.Name = "rbProduccion";
            this.rbProduccion.Size = new System.Drawing.Size(79, 17);
            this.rbProduccion.TabIndex = 1;
            this.rbProduccion.Text = "Producción";
            this.rbProduccion.UseVisualStyleBackColor = true;
            // 
            // rbTesting
            // 
            this.rbTesting.AutoSize = true;
            this.rbTesting.Checked = true;
            this.rbTesting.Location = new System.Drawing.Point(28, 12);
            this.rbTesting.Name = "rbTesting";
            this.rbTesting.Size = new System.Drawing.Size(60, 17);
            this.rbTesting.TabIndex = 0;
            this.rbTesting.TabStop = true;
            this.rbTesting.Text = "Testing";
            this.rbTesting.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ambiente:";
            // 
            // btnBuscarComponente
            // 
            this.btnBuscarComponente.Location = new System.Drawing.Point(270, 101);
            this.btnBuscarComponente.Name = "btnBuscarComponente";
            this.btnBuscarComponente.Size = new System.Drawing.Size(121, 23);
            this.btnBuscarComponente.TabIndex = 6;
            this.btnBuscarComponente.Text = "Buscar componentes";
            this.btnBuscarComponente.UseVisualStyleBackColor = true;
            this.btnBuscarComponente.Click += new System.EventHandler(this.btnBuscarComponente_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(104, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "SPPROD";
            // 
            // txtPase
            // 
            this.txtPase.Location = new System.Drawing.Point(164, 103);
            this.txtPase.Name = "txtPase";
            this.txtPase.Size = new System.Drawing.Size(100, 20);
            this.txtPase.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pase:";
            // 
            // btnBuscarOrigen
            // 
            this.btnBuscarOrigen.Location = new System.Drawing.Point(468, 36);
            this.btnBuscarOrigen.Name = "btnBuscarOrigen";
            this.btnBuscarOrigen.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarOrigen.TabIndex = 2;
            this.btnBuscarOrigen.Text = "...";
            this.btnBuscarOrigen.UseVisualStyleBackColor = true;
            this.btnBuscarOrigen.Click += new System.EventHandler(this.btnBuscarOrigen_Click);
            // 
            // txtRutaOrigen
            // 
            this.txtRutaOrigen.Location = new System.Drawing.Point(100, 37);
            this.txtRutaOrigen.Name = "txtRutaOrigen";
            this.txtRutaOrigen.Size = new System.Drawing.Size(365, 20);
            this.txtRutaOrigen.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ruta origen:";
            // 
            // grillaComponentes
            // 
            this.grillaComponentes.AllowUserToAddRows = false;
            this.grillaComponentes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grillaComponentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaComponentes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Componente,
            this.Version,
            this.Resultado});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grillaComponentes.DefaultCellStyle = dataGridViewCellStyle1;
            this.grillaComponentes.Location = new System.Drawing.Point(12, 297);
            this.grillaComponentes.Name = "grillaComponentes";
            this.grillaComponentes.Size = new System.Drawing.Size(521, 225);
            this.grillaComponentes.TabIndex = 1;
            // 
            // Componente
            // 
            this.Componente.HeaderText = "Componente";
            this.Componente.Name = "Componente";
            this.Componente.Width = 200;
            // 
            // Version
            // 
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            // 
            // Resultado
            // 
            this.Resultado.HeaderText = "Resultado";
            this.Resultado.Name = "Resultado";
            this.Resultado.Width = 160;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPublicar);
            this.groupBox2.Controls.Add(this.btnBuscarDestino);
            this.groupBox2.Controls.Add(this.txtRutaDestino);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 73);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Destino de publicación";
            // 
            // btnPublicar
            // 
            this.btnPublicar.Location = new System.Drawing.Point(100, 42);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(75, 23);
            this.btnPublicar.TabIndex = 6;
            this.btnPublicar.Text = "&Publicar";
            this.btnPublicar.UseVisualStyleBackColor = true;
            this.btnPublicar.Click += new System.EventHandler(this.btnPublicar_Click);
            // 
            // btnBuscarDestino
            // 
            this.btnBuscarDestino.Location = new System.Drawing.Point(468, 15);
            this.btnBuscarDestino.Name = "btnBuscarDestino";
            this.btnBuscarDestino.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarDestino.TabIndex = 5;
            this.btnBuscarDestino.Text = "...";
            this.btnBuscarDestino.UseVisualStyleBackColor = true;
            this.btnBuscarDestino.Click += new System.EventHandler(this.btnBuscarDestino_Click);
            // 
            // txtRutaDestino
            // 
            this.txtRutaDestino.Location = new System.Drawing.Point(100, 16);
            this.txtRutaDestino.Name = "txtRutaDestino";
            this.txtRutaDestino.Size = new System.Drawing.Size(365, 20);
            this.txtRutaDestino.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ruta Destino:";
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(12, 528);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(75, 23);
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.Text = "&Ver usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnBuscarComponente;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 560);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grillaComponentes);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Despliegue de cambios Raiznet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaComponentes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarOrigen;
        private System.Windows.Forms.TextBox txtRutaOrigen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fbd1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarComponente;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbProduccion;
        private System.Windows.Forms.RadioButton rbTesting;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grillaComponentes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Componente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resultado;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.Button btnBuscarDestino;
        private System.Windows.Forms.TextBox txtRutaDestino;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FolderBrowserDialog fbd2;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Label lblPase;
        private System.Windows.Forms.NotifyIcon notifyIcon1;

    }
}

