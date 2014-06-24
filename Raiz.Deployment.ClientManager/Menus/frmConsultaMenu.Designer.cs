namespace Raiz.Deployment.ClientManager.Menus
{
    partial class frmConsultaMenu
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
            this.lblCodigo = new System.Windows.Forms.GroupBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.CmbVisibilidad = new System.Windows.Forms.ComboBox();
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.lblVisibilidad = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridConsulta = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Formulario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Componente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.lblCodigo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridConsulta)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.Controls.Add(this.BtnBuscar);
            this.lblCodigo.Controls.Add(this.CmbVisibilidad);
            this.lblCodigo.Controls.Add(this.CmbEstado);
            this.lblCodigo.Controls.Add(this.TxtDescripcion);
            this.lblCodigo.Controls.Add(this.TxtCodigo);
            this.lblCodigo.Controls.Add(this.lblVisibilidad);
            this.lblCodigo.Controls.Add(this.lblEstado);
            this.lblCodigo.Controls.Add(this.lblDescripcion);
            this.lblCodigo.Controls.Add(this.label1);
            this.lblCodigo.Location = new System.Drawing.Point(18, 15);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(751, 78);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.TabStop = false;
            this.lblCodigo.Text = "Filtros de Búsqueda";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(645, 19);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(100, 38);
            this.BtnBuscar.TabIndex = 8;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // CmbVisibilidad
            // 
            this.CmbVisibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbVisibilidad.FormattingEnabled = true;
            this.CmbVisibilidad.Location = new System.Drawing.Point(426, 42);
            this.CmbVisibilidad.Name = "CmbVisibilidad";
            this.CmbVisibilidad.Size = new System.Drawing.Size(166, 21);
            this.CmbVisibilidad.TabIndex = 7;
            // 
            // CmbEstado
            // 
            this.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Location = new System.Drawing.Point(426, 17);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(166, 21);
            this.CmbEstado.TabIndex = 6;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(97, 43);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(188, 20);
            this.TxtDescripcion.TabIndex = 5;
            this.TxtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDescripcion_KeyPress);
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Location = new System.Drawing.Point(97, 19);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(67, 20);
            this.TxtCodigo.TabIndex = 4;
            this.TxtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigo_KeyPress);
            // 
            // lblVisibilidad
            // 
            this.lblVisibilidad.AutoSize = true;
            this.lblVisibilidad.Location = new System.Drawing.Point(366, 50);
            this.lblVisibilidad.Name = "lblVisibilidad";
            this.lblVisibilidad.Size = new System.Drawing.Size(56, 13);
            this.lblVisibilidad.TabIndex = 3;
            this.lblVisibilidad.Text = "Visibilidad:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(366, 25);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 2;
            this.lblEstado.Text = "Estado:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(18, 50);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridConsulta);
            this.groupBox1.Location = new System.Drawing.Point(18, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(751, 306);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // gridConsulta
            // 
            this.gridConsulta.AllowUserToAddRows = false;
            this.gridConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConsulta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.Descripcion,
            this.Formulario,
            this.Componente});
            this.gridConsulta.Location = new System.Drawing.Point(6, 9);
            this.gridConsulta.Name = "gridConsulta";
            this.gridConsulta.ReadOnly = true;
            this.gridConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridConsulta.Size = new System.Drawing.Size(739, 291);
            this.gridConsulta.TabIndex = 0;
            this.gridConsulta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridConsulta_CellDoubleClick);
            this.gridConsulta.SelectionChanged += new System.EventHandler(this.gridConsulta_SelectionChanged);
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 50;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 200;
            // 
            // Formulario
            // 
            this.Formulario.HeaderText = "Formulario";
            this.Formulario.Name = "Formulario";
            this.Formulario.ReadOnly = true;
            this.Formulario.Width = 200;
            // 
            // Componente
            // 
            this.Componente.HeaderText = "Componente";
            this.Componente.Name = "Componente";
            this.Componente.ReadOnly = true;
            this.Componente.Width = 220;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnSalir);
            this.groupBox2.Controls.Add(this.BtnEliminar);
            this.groupBox2.Controls.Add(this.BtnModificar);
            this.groupBox2.Controls.Add(this.BtnNuevo);
            this.groupBox2.Location = new System.Drawing.Point(18, 411);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 56);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // BtnSalir
            // 
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.Location = new System.Drawing.Point(303, 12);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(92, 38);
            this.BtnSalir.TabIndex = 12;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(205, 12);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(92, 38);
            this.BtnEliminar.TabIndex = 11;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(107, 12);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(92, 38);
            this.BtnModificar.TabIndex = 10;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(9, 12);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(92, 38);
            this.BtnNuevo.TabIndex = 9;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // frmConsultaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(781, 470);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCodigo);
            this.Name = "frmConsultaMenu";
            this.Text = "Consulta Menus";
            this.Load += new System.EventHandler(this.frmConsultaMenu_Load);
            this.lblCodigo.ResumeLayout(false);
            this.lblCodigo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridConsulta)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox lblCodigo;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.ComboBox CmbVisibilidad;
        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label lblVisibilidad;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridConsulta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Formulario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Componente;
    }
}