namespace Raiz.Deployment.ClientManager.Menus
{
    partial class frmNuevoMenu
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
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtMenuPadre = new System.Windows.Forms.TextBox();
            this.lblMenuPadre = new System.Windows.Forms.Label();
            this.CmbVisibilidad = new System.Windows.Forms.ComboBox();
            this.lblVisibilidad = new System.Windows.Forms.Label();
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.TxtComponente = new System.Windows.Forms.TextBox();
            this.TxtFormulario = new System.Windows.Forms.TextBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.TxtNomMenu = new System.Windows.Forms.TextBox();
            this.lblNomMenu = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.lblComponente = new System.Windows.Forms.Label();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.grv = new System.Windows.Forms.GroupBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.lblPrograma = new System.Windows.Forms.Label();
            this.TxtPrograma = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.grv.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtPrograma);
            this.groupBox1.Controls.Add(this.lblPrograma);
            this.groupBox1.Controls.Add(this.BtnCancelar);
            this.groupBox1.Controls.Add(this.BtnBuscar);
            this.groupBox1.Controls.Add(this.TxtMenuPadre);
            this.groupBox1.Controls.Add(this.lblMenuPadre);
            this.groupBox1.Controls.Add(this.CmbVisibilidad);
            this.groupBox1.Controls.Add(this.lblVisibilidad);
            this.groupBox1.Controls.Add(this.CmbEstado);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.TxtComponente);
            this.groupBox1.Controls.Add(this.TxtFormulario);
            this.groupBox1.Controls.Add(this.TxtDescripcion);
            this.groupBox1.Controls.Add(this.TxtNomMenu);
            this.groupBox1.Controls.Add(this.lblNomMenu);
            this.groupBox1.Controls.Add(this.lblDescripcion);
            this.groupBox1.Controls.Add(this.lblFormulario);
            this.groupBox1.Controls.Add(this.lblComponente);
            this.groupBox1.Location = new System.Drawing.Point(34, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 334);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(480, 251);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(31, 20);
            this.BtnCancelar.TabIndex = 12;
            this.BtnCancelar.Text = "X";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(443, 251);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(31, 20);
            this.BtnBuscar.TabIndex = 8;
            this.BtnBuscar.Text = "...";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtMenuPadre
            // 
            this.TxtMenuPadre.Enabled = false;
            this.TxtMenuPadre.Location = new System.Drawing.Point(103, 251);
            this.TxtMenuPadre.Name = "TxtMenuPadre";
            this.TxtMenuPadre.Size = new System.Drawing.Size(334, 20);
            this.TxtMenuPadre.TabIndex = 8;
            // 
            // lblMenuPadre
            // 
            this.lblMenuPadre.AutoSize = true;
            this.lblMenuPadre.Location = new System.Drawing.Point(20, 254);
            this.lblMenuPadre.Name = "lblMenuPadre";
            this.lblMenuPadre.Size = new System.Drawing.Size(68, 13);
            this.lblMenuPadre.TabIndex = 11;
            this.lblMenuPadre.Text = "Menu Padre:";
            // 
            // CmbVisibilidad
            // 
            this.CmbVisibilidad.FormattingEnabled = true;
            this.CmbVisibilidad.Location = new System.Drawing.Point(103, 302);
            this.CmbVisibilidad.Name = "CmbVisibilidad";
            this.CmbVisibilidad.Size = new System.Drawing.Size(62, 21);
            this.CmbVisibilidad.TabIndex = 10;
            // 
            // lblVisibilidad
            // 
            this.lblVisibilidad.AutoSize = true;
            this.lblVisibilidad.Location = new System.Drawing.Point(22, 310);
            this.lblVisibilidad.Name = "lblVisibilidad";
            this.lblVisibilidad.Size = new System.Drawing.Size(56, 13);
            this.lblVisibilidad.TabIndex = 9;
            this.lblVisibilidad.Text = "Visibilidad:";
            // 
            // CmbEstado
            // 
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Location = new System.Drawing.Point(103, 275);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(141, 21);
            this.CmbEstado.TabIndex = 9;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(20, 283);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Estado:";
            // 
            // TxtComponente
            // 
            this.TxtComponente.Location = new System.Drawing.Point(103, 190);
            this.TxtComponente.Name = "TxtComponente";
            this.TxtComponente.Size = new System.Drawing.Size(494, 20);
            this.TxtComponente.TabIndex = 7;
            // 
            // TxtFormulario
            // 
            this.TxtFormulario.Location = new System.Drawing.Point(103, 164);
            this.TxtFormulario.Name = "TxtFormulario";
            this.TxtFormulario.Size = new System.Drawing.Size(494, 20);
            this.TxtFormulario.TabIndex = 6;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(103, 44);
            this.TxtDescripcion.MaxLength = 512;
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(494, 112);
            this.TxtDescripcion.TabIndex = 5;
            // 
            // TxtNomMenu
            // 
            this.TxtNomMenu.Location = new System.Drawing.Point(103, 13);
            this.TxtNomMenu.Name = "TxtNomMenu";
            this.TxtNomMenu.Size = new System.Drawing.Size(494, 20);
            this.TxtNomMenu.TabIndex = 4;
            // 
            // lblNomMenu
            // 
            this.lblNomMenu.AutoSize = true;
            this.lblNomMenu.Location = new System.Drawing.Point(20, 16);
            this.lblNomMenu.Name = "lblNomMenu";
            this.lblNomMenu.Size = new System.Drawing.Size(77, 13);
            this.lblNomMenu.TabIndex = 3;
            this.lblNomMenu.Text = "Nombre Menú:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(20, 44);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblFormulario
            // 
            this.lblFormulario.AutoSize = true;
            this.lblFormulario.Location = new System.Drawing.Point(20, 167);
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(58, 13);
            this.lblFormulario.TabIndex = 1;
            this.lblFormulario.Text = "Formulario:";
            // 
            // lblComponente
            // 
            this.lblComponente.AutoSize = true;
            this.lblComponente.Location = new System.Drawing.Point(20, 193);
            this.lblComponente.Name = "lblComponente";
            this.lblComponente.Size = new System.Drawing.Size(70, 13);
            this.lblComponente.TabIndex = 0;
            this.lblComponente.Text = "Componente:";
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(6, 19);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(87, 53);
            this.BtnNuevo.TabIndex = 7;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // grv
            // 
            this.grv.Controls.Add(this.BtnSalir);
            this.grv.Controls.Add(this.BtnGuardar);
            this.grv.Controls.Add(this.BtnNuevo);
            this.grv.Controls.Add(this.BtnEliminar);
            this.grv.Controls.Add(this.BtnModificar);
            this.grv.Location = new System.Drawing.Point(192, 363);
            this.grv.Name = "grv";
            this.grv.Size = new System.Drawing.Size(478, 78);
            this.grv.TabIndex = 3;
            this.grv.TabStop = false;
            // 
            // BtnSalir
            // 
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.Location = new System.Drawing.Point(378, 19);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(86, 53);
            this.BtnSalir.TabIndex = 11;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(99, 19);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(87, 53);
            this.BtnGuardar.TabIndex = 5;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(285, 19);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(87, 53);
            this.BtnEliminar.TabIndex = 5;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(192, 19);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(87, 53);
            this.BtnModificar.TabIndex = 4;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // lblPrograma
            // 
            this.lblPrograma.AutoSize = true;
            this.lblPrograma.Location = new System.Drawing.Point(20, 224);
            this.lblPrograma.Name = "lblPrograma";
            this.lblPrograma.Size = new System.Drawing.Size(55, 13);
            this.lblPrograma.TabIndex = 13;
            this.lblPrograma.Text = "Programa:";
            // 
            // TxtPrograma
            // 
            this.TxtPrograma.Location = new System.Drawing.Point(103, 221);
            this.TxtPrograma.MaxLength = 14;
            this.TxtPrograma.Name = "TxtPrograma";
            this.TxtPrograma.Size = new System.Drawing.Size(334, 20);
            this.TxtPrograma.TabIndex = 14;
            // 
            // frmNuevoMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnSalir;
            this.ClientSize = new System.Drawing.Size(701, 458);
            this.Controls.Add(this.grv);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmNuevoMenu";
            this.Text = "Mantenimiento de Menus";
            this.Load += new System.EventHandler(this.frmNuevoMenu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtNomMenu;
        private System.Windows.Forms.Label lblNomMenu;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.Label lblComponente;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.ComboBox CmbVisibilidad;
        private System.Windows.Forms.Label lblVisibilidad;
        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox TxtComponente;
        private System.Windows.Forms.TextBox TxtFormulario;
        private System.Windows.Forms.GroupBox grv;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtMenuPadre;
        private System.Windows.Forms.Label lblMenuPadre;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.TextBox TxtPrograma;
        private System.Windows.Forms.Label lblPrograma;
    }
}