namespace BRAMSELU
{
    partial class frmCitas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LblEspecialista = new System.Windows.Forms.Label();
            this.LblTelefono = new System.Windows.Forms.Label();
            this.LblHora = new System.Windows.Forms.Label();
            this.LblFecha = new System.Windows.Forms.Label();
            this.LblServicio = new System.Windows.Forms.Label();
            this.LblCliente = new System.Windows.Forms.Label();
            this.lblTituloCitas = new System.Windows.Forms.Label();
            this.LblDuracion = new System.Windows.Forms.Label();
            this.CmbCliente = new System.Windows.Forms.ComboBox();
            this.CmbServicio = new System.Windows.Forms.ComboBox();
            this.LblNotas = new System.Windows.Forms.Label();
            this.CmbEspecialista = new System.Windows.Forms.ComboBox();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.TxtNotas = new System.Windows.Forms.TextBox();
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.pnlSeparador = new System.Windows.Forms.Panel();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.TxtDuracion = new System.Windows.Forms.TextBox();
            this.TxtHora = new System.Windows.Forms.TextBox();
            this.LblEstado = new System.Windows.Forms.Label();
            this.LblPrecio = new System.Windows.Forms.Label();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.TxtCita = new System.Windows.Forms.TextBox();
            this.LblIdCita = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // LblEspecialista
            // 
            this.LblEspecialista.AutoSize = true;
            this.LblEspecialista.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.LblEspecialista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.LblEspecialista.Location = new System.Drawing.Point(525, 500);
            this.LblEspecialista.Name = "LblEspecialista";
            this.LblEspecialista.Size = new System.Drawing.Size(92, 21);
            this.LblEspecialista.TabIndex = 46;
            this.LblEspecialista.Text = "Especialista:";
            // 
            // LblTelefono
            // 
            this.LblTelefono.AutoSize = true;
            this.LblTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.LblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.LblTelefono.Location = new System.Drawing.Point(525, 462);
            this.LblTelefono.Name = "LblTelefono";
            this.LblTelefono.Size = new System.Drawing.Size(71, 21);
            this.LblTelefono.TabIndex = 44;
            this.LblTelefono.Text = "Teléfono:";
            // 
            // LblHora
            // 
            this.LblHora.AutoSize = true;
            this.LblHora.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.LblHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.LblHora.Location = new System.Drawing.Point(528, 571);
            this.LblHora.Name = "LblHora";
            this.LblHora.Size = new System.Drawing.Size(47, 21);
            this.LblHora.TabIndex = 42;
            this.LblHora.Text = "Hora:";
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.LblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.LblFecha.Location = new System.Drawing.Point(58, 570);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(53, 21);
            this.LblFecha.TabIndex = 40;
            this.LblFecha.Text = "Fecha:";
            // 
            // LblServicio
            // 
            this.LblServicio.AutoSize = true;
            this.LblServicio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.LblServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.LblServicio.Location = new System.Drawing.Point(58, 538);
            this.LblServicio.Name = "LblServicio";
            this.LblServicio.Size = new System.Drawing.Size(68, 21);
            this.LblServicio.TabIndex = 38;
            this.LblServicio.Text = "Servicio:";
            // 
            // LblCliente
            // 
            this.LblCliente.AutoSize = true;
            this.LblCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.LblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.LblCliente.Location = new System.Drawing.Point(58, 503);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.Size = new System.Drawing.Size(61, 21);
            this.LblCliente.TabIndex = 36;
            this.LblCliente.Text = "Cliente:";
            // 
            // lblTituloCitas
            // 
            this.lblTituloCitas.AutoSize = true;
            this.lblTituloCitas.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTituloCitas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(110)))), ((int)(((byte)(75)))));
            this.lblTituloCitas.Location = new System.Drawing.Point(52, 26);
            this.lblTituloCitas.Name = "lblTituloCitas";
            this.lblTituloCitas.Size = new System.Drawing.Size(223, 37);
            this.lblTituloCitas.TabIndex = 48;
            this.lblTituloCitas.Text = "Control de Citas";
            // 
            // LblDuracion
            // 
            this.LblDuracion.AutoSize = true;
            this.LblDuracion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.LblDuracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.LblDuracion.Location = new System.Drawing.Point(525, 535);
            this.LblDuracion.Name = "LblDuracion";
            this.LblDuracion.Size = new System.Drawing.Size(76, 21);
            this.LblDuracion.TabIndex = 51;
            this.LblDuracion.Text = "Duración:";
            // 
            // CmbCliente
            // 
            this.CmbCliente.FormattingEnabled = true;
            this.CmbCliente.ItemHeight = 16;
            this.CmbCliente.Location = new System.Drawing.Point(158, 501);
            this.CmbCliente.Name = "CmbCliente";
            this.CmbCliente.Size = new System.Drawing.Size(340, 24);
            this.CmbCliente.TabIndex = 52;
            // 
            // CmbServicio
            // 
            this.CmbServicio.FormattingEnabled = true;
            this.CmbServicio.Location = new System.Drawing.Point(158, 539);
            this.CmbServicio.Name = "CmbServicio";
            this.CmbServicio.Size = new System.Drawing.Size(340, 24);
            this.CmbServicio.TabIndex = 53;
            // 
            // LblNotas
            // 
            this.LblNotas.AutoSize = true;
            this.LblNotas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.LblNotas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.LblNotas.Location = new System.Drawing.Point(58, 607);
            this.LblNotas.Name = "LblNotas";
            this.LblNotas.Size = new System.Drawing.Size(54, 21);
            this.LblNotas.TabIndex = 54;
            this.LblNotas.Text = "Notas:";
            // 
            // CmbEspecialista
            // 
            this.CmbEspecialista.FormattingEnabled = true;
            this.CmbEspecialista.Location = new System.Drawing.Point(628, 501);
            this.CmbEspecialista.Name = "CmbEspecialista";
            this.CmbEspecialista.Size = new System.Drawing.Size(340, 24);
            this.CmbEspecialista.TabIndex = 55;
            // 
            // DtpFecha
            // 
            this.DtpFecha.Location = new System.Drawing.Point(158, 569);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(340, 22);
            this.DtpFecha.TabIndex = 56;
            this.DtpFecha.Value = new System.DateTime(2026, 6, 28, 21, 56, 45, 0);
            // 
            // TxtNotas
            // 
            this.TxtNotas.Location = new System.Drawing.Point(62, 642);
            this.TxtNotas.Multiline = true;
            this.TxtNotas.Name = "TxtNotas";
            this.TxtNotas.Size = new System.Drawing.Size(910, 119);
            this.TxtNotas.TabIndex = 58;
            // 
            // CmbEstado
            // 
            this.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Location = new System.Drawing.Point(212, 781);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(307, 24);
            this.CmbEstado.TabIndex = 62;
            this.CmbEstado.SelectedIndexChanged += new System.EventHandler(this.frmCitas_Load);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(130)))), ((int)(((byte)(160)))));
            this.BtnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBuscar.FlatAppearance.BorderSize = 0;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BtnBuscar.ForeColor = System.Drawing.Color.White;
            this.BtnBuscar.Location = new System.Drawing.Point(808, 81);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(100, 34);
            this.BtnBuscar.TabIndex = 74;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.lblBuscar.Location = new System.Drawing.Point(54, 88);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(59, 21);
            this.lblBuscar.TabIndex = 68;
            this.lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(132, 85);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(220, 30);
            this.txtBuscar.TabIndex = 69;
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(154)))), ((int)(((byte)(108)))));
            this.BtnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnNuevo.FlatAppearance.BorderSize = 0;
            this.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BtnNuevo.ForeColor = System.Drawing.Color.White;
            this.BtnNuevo.Location = new System.Drawing.Point(372, 83);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(100, 32);
            this.BtnNuevo.TabIndex = 70;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = false;
            this.BtnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(110)))), ((int)(((byte)(75)))));
            this.BtnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEditar.FlatAppearance.BorderSize = 0;
            this.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BtnEditar.ForeColor = System.Drawing.Color.White;
            this.BtnEditar.Location = new System.Drawing.Point(482, 83);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(100, 32);
            this.BtnEditar.TabIndex = 71;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = false;
            this.BtnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.BtnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEliminar.FlatAppearance.BorderSize = 0;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BtnEliminar.ForeColor = System.Drawing.Color.White;
            this.BtnEliminar.Location = new System.Drawing.Point(592, 83);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(100, 32);
            this.BtnEliminar.TabIndex = 72;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(150)))), ((int)(((byte)(110)))));
            this.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Location = new System.Drawing.Point(702, 83);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(100, 32);
            this.BtnGuardar.TabIndex = 73;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvCitas
            // 
            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(154)))), ((int)(((byte)(108)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCitas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCitas.ColumnHeadersHeight = 36;
            this.dgvCitas.Location = new System.Drawing.Point(58, 136);
            this.dgvCitas.MultiSelect = false;
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.RowHeadersVisible = false;
            this.dgvCitas.RowHeadersWidth = 62;
            this.dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitas.Size = new System.Drawing.Size(900, 270);
            this.dgvCitas.TabIndex = 75;
            // 
            // pnlSeparador
            // 
            this.pnlSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(204)))), ((int)(((byte)(197)))));
            this.pnlSeparador.Location = new System.Drawing.Point(58, 421);
            this.pnlSeparador.Name = "pnlSeparador";
            this.pnlSeparador.Size = new System.Drawing.Size(900, 1);
            this.pnlSeparador.TabIndex = 76;
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSeccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(110)))), ((int)(((byte)(75)))));
            this.lblSeccion.Location = new System.Drawing.Point(58, 433);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(156, 21);
            this.lblSeccion.TabIndex = 77;
            this.lblSeccion.Text = "Datos del Producto";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.lblMarca.Location = new System.Drawing.Point(538, 463);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(0, 21);
            this.lblMarca.TabIndex = 80;
            // 
            // TxtDuracion
            // 
            this.TxtDuracion.Location = new System.Drawing.Point(628, 535);
            this.TxtDuracion.Multiline = true;
            this.TxtDuracion.Name = "TxtDuracion";
            this.TxtDuracion.Size = new System.Drawing.Size(340, 30);
            this.TxtDuracion.TabIndex = 90;
            // 
            // TxtHora
            // 
            this.TxtHora.Location = new System.Drawing.Point(628, 571);
            this.TxtHora.Multiline = true;
            this.TxtHora.Name = "TxtHora";
            this.TxtHora.Size = new System.Drawing.Size(340, 30);
            this.TxtHora.TabIndex = 91;
            // 
            // LblEstado
            // 
            this.LblEstado.AutoSize = true;
            this.LblEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.LblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.LblEstado.Location = new System.Drawing.Point(58, 780);
            this.LblEstado.Name = "LblEstado";
            this.LblEstado.Size = new System.Drawing.Size(127, 21);
            this.LblEstado.TabIndex = 59;
            this.LblEstado.Text = "Estado de la Cita:";
            // 
            // LblPrecio
            // 
            this.LblPrecio.AutoSize = true;
            this.LblPrecio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.LblPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.LblPrecio.Location = new System.Drawing.Point(525, 779);
            this.LblPrecio.Name = "LblPrecio";
            this.LblPrecio.Size = new System.Drawing.Size(56, 21);
            this.LblPrecio.TabIndex = 60;
            this.LblPrecio.Text = "Precio:";
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Location = new System.Drawing.Point(628, 780);
            this.TxtPrecio.Multiline = true;
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(340, 30);
            this.TxtPrecio.TabIndex = 92;
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.Location = new System.Drawing.Point(628, 460);
            this.TxtTelefono.Multiline = true;
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(340, 30);
            this.TxtTelefono.TabIndex = 93;
            // 
            // TxtCita
            // 
            this.TxtCita.Location = new System.Drawing.Point(158, 463);
            this.TxtCita.Multiline = true;
            this.TxtCita.Name = "TxtCita";
            this.TxtCita.Size = new System.Drawing.Size(340, 30);
            this.TxtCita.TabIndex = 96;
            // 
            // LblIdCita
            // 
            this.LblIdCita.AutoSize = true;
            this.LblIdCita.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.LblIdCita.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.LblIdCita.Location = new System.Drawing.Point(68, 466);
            this.LblIdCita.Name = "LblIdCita";
            this.LblIdCita.Size = new System.Drawing.Size(0, 21);
            this.LblIdCita.TabIndex = 95;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.label2.Location = new System.Drawing.Point(58, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 94;
            this.label2.Text = "ID Cita:";
            // 
            // frmCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1084, 872);
            this.Controls.Add(this.TxtCita);
            this.Controls.Add(this.LblIdCita);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtTelefono);
            this.Controls.Add(this.TxtPrecio);
            this.Controls.Add(this.TxtHora);
            this.Controls.Add(this.TxtDuracion);
            this.Controls.Add(this.dgvCitas);
            this.Controls.Add(this.pnlSeparador);
            this.Controls.Add(this.lblSeccion);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.CmbEstado);
            this.Controls.Add(this.LblPrecio);
            this.Controls.Add(this.LblEstado);
            this.Controls.Add(this.TxtNotas);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.CmbEspecialista);
            this.Controls.Add(this.LblNotas);
            this.Controls.Add(this.CmbServicio);
            this.Controls.Add(this.CmbCliente);
            this.Controls.Add(this.LblDuracion);
            this.Controls.Add(this.lblTituloCitas);
            this.Controls.Add(this.LblEspecialista);
            this.Controls.Add(this.LblTelefono);
            this.Controls.Add(this.LblHora);
            this.Controls.Add(this.LblFecha);
            this.Controls.Add(this.LblServicio);
            this.Controls.Add(this.LblCliente);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCitas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblEspecialista;
        private System.Windows.Forms.Label LblTelefono;
        private System.Windows.Forms.Label LblHora;
        private System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.Label LblServicio;
        private System.Windows.Forms.Label LblCliente;
        private System.Windows.Forms.Label lblTituloCitas;
        private System.Windows.Forms.Label LblDuracion;
        private System.Windows.Forms.ComboBox CmbCliente;
        private System.Windows.Forms.ComboBox CmbServicio;
        private System.Windows.Forms.Label LblNotas;
        private System.Windows.Forms.ComboBox CmbEspecialista;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.TextBox TxtNotas;
        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Panel pnlSeparador;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox TxtDuracion;
        private System.Windows.Forms.TextBox TxtHora;
        private System.Windows.Forms.Label LblPrecio;
        private System.Windows.Forms.Label LblEstado;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.TextBox TxtCita;
        private System.Windows.Forms.Label LblIdCita;
        private System.Windows.Forms.Label label2;
    }
}