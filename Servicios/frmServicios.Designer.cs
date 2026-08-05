namespace BRAMSELU
{
    partial class frmServicios
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtdescripcionservicio = new System.Windows.Forms.TextBox();
            this.progressBarservicio = new System.Windows.Forms.ProgressBar();
            this.lblidservicio = new System.Windows.Forms.Label();
            this.labeldescripcionservicio = new System.Windows.Forms.Label();
            this.labelnombreservicio = new System.Windows.Forms.Label();
            this.lbldatosservicio = new System.Windows.Forms.Label();
            this.btnbuscarservicio = new System.Windows.Forms.Button();
            this.txtBuscarservicio = new System.Windows.Forms.TextBox();
            this.btnguardarservicio = new System.Windows.Forms.Button();
            this.bttneliminarservicio = new System.Windows.Forms.Button();
            this.bttneditarservicio = new System.Windows.Forms.Button();
            this.Btnnuevoservicio = new System.Windows.Forms.Button();
            this.dataGridViewservicio = new System.Windows.Forms.DataGridView();
            this.labelbuscarservicio = new System.Windows.Forms.Label();
            this.lblservicios = new System.Windows.Forms.Label();
            this.lblprecioservicio = new System.Windows.Forms.Label();
            this.lblduracion = new System.Windows.Forms.Label();
            this.lblestado = new System.Windows.Forms.Label();
            this.comboBoxestadoservicio = new System.Windows.Forms.ComboBox();
            this.txtIdservicio = new System.Windows.Forms.TextBox();
            this.txtnombreservicio = new System.Windows.Forms.TextBox();
            this.txtprecioservicio = new System.Windows.Forms.TextBox();
            this.txtduracionservicio = new System.Windows.Forms.TextBox();
            this.L = new System.Windows.Forms.Label();
            this.minutosahoras = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewservicio)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtdescripcionservicio
            // 
            this.txtdescripcionservicio.Location = new System.Drawing.Point(197, 520);
            this.txtdescripcionservicio.Multiline = true;
            this.txtdescripcionservicio.Name = "txtdescripcionservicio";
            this.txtdescripcionservicio.Size = new System.Drawing.Size(348, 90);
            this.txtdescripcionservicio.TabIndex = 80;
            this.txtdescripcionservicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdescripcionservicio_KeyPress);
            // 
            // progressBarservicio
            // 
            this.progressBarservicio.Location = new System.Drawing.Point(74, 661);
            this.progressBarservicio.Name = "progressBarservicio";
            this.progressBarservicio.Size = new System.Drawing.Size(129, 23);
            this.progressBarservicio.TabIndex = 79;
            this.progressBarservicio.Visible = false;
            // 
            // lblidservicio
            // 
            this.lblidservicio.AutoSize = true;
            this.lblidservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidservicio.ForeColor = System.Drawing.Color.DimGray;
            this.lblidservicio.Location = new System.Drawing.Point(67, 443);
            this.lblidservicio.Name = "lblidservicio";
            this.lblidservicio.Size = new System.Drawing.Size(130, 31);
            this.lblidservicio.TabIndex = 77;
            this.lblidservicio.Text = "ID Servicio";
            // 
            // labeldescripcionservicio
            // 
            this.labeldescripcionservicio.AutoSize = true;
            this.labeldescripcionservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldescripcionservicio.ForeColor = System.Drawing.Color.DimGray;
            this.labeldescripcionservicio.Location = new System.Drawing.Point(67, 519);
            this.labeldescripcionservicio.Name = "labeldescripcionservicio";
            this.labeldescripcionservicio.Size = new System.Drawing.Size(146, 31);
            this.labeldescripcionservicio.TabIndex = 76;
            this.labeldescripcionservicio.Text = "Descripcion:";
            // 
            // labelnombreservicio
            // 
            this.labelnombreservicio.AutoSize = true;
            this.labelnombreservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnombreservicio.ForeColor = System.Drawing.Color.DimGray;
            this.labelnombreservicio.Location = new System.Drawing.Point(67, 481);
            this.labelnombreservicio.Name = "labelnombreservicio";
            this.labelnombreservicio.Size = new System.Drawing.Size(108, 31);
            this.labelnombreservicio.TabIndex = 74;
            this.labelnombreservicio.Text = "Nombre:";
            // 
            // lbldatosservicio
            // 
            this.lbldatosservicio.AutoSize = true;
            this.lbldatosservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatosservicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.lbldatosservicio.Location = new System.Drawing.Point(67, 400);
            this.lbldatosservicio.Name = "lbldatosservicio";
            this.lbldatosservicio.Size = new System.Drawing.Size(207, 31);
            this.lbldatosservicio.TabIndex = 73;
            this.lbldatosservicio.Text = "Datos del Servicio";
            // 
            // btnbuscarservicio
            // 
            this.btnbuscarservicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnbuscarservicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarservicio.FlatAppearance.BorderSize = 0;
            this.btnbuscarservicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscarservicio.ForeColor = System.Drawing.Color.White;
            this.btnbuscarservicio.Location = new System.Drawing.Point(529, 72);
            this.btnbuscarservicio.Name = "btnbuscarservicio";
            this.btnbuscarservicio.Size = new System.Drawing.Size(112, 38);
            this.btnbuscarservicio.TabIndex = 72;
            this.btnbuscarservicio.Text = "Buscar";
            this.btnbuscarservicio.UseVisualStyleBackColor = false;
            this.btnbuscarservicio.Click += new System.EventHandler(this.btnbuscarservicio_Click);
            // 
            // txtBuscarservicio
            // 
            this.txtBuscarservicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarservicio.Location = new System.Drawing.Point(165, 72);
            this.txtBuscarservicio.Name = "txtBuscarservicio";
            this.txtBuscarservicio.Size = new System.Drawing.Size(340, 38);
            this.txtBuscarservicio.TabIndex = 71;
            this.txtBuscarservicio.TextChanged += new System.EventHandler(this.txtBuscarservicio_TextChanged);
            // 
            // btnguardarservicio
            // 
            this.btnguardarservicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(193)))), ((int)(((byte)(91)))));
            this.btnguardarservicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardarservicio.FlatAppearance.BorderSize = 0;
            this.btnguardarservicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardarservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardarservicio.ForeColor = System.Drawing.Color.White;
            this.btnguardarservicio.Location = new System.Drawing.Point(1001, 72);
            this.btnguardarservicio.Name = "btnguardarservicio";
            this.btnguardarservicio.Size = new System.Drawing.Size(112, 38);
            this.btnguardarservicio.TabIndex = 70;
            this.btnguardarservicio.Text = "Guardar";
            this.btnguardarservicio.UseVisualStyleBackColor = false;
            this.btnguardarservicio.Click += new System.EventHandler(this.btnguardarservicio_Click);
            // 
            // bttneliminarservicio
            // 
            this.bttneliminarservicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(83)))), ((int)(((byte)(112)))));
            this.bttneliminarservicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttneliminarservicio.FlatAppearance.BorderSize = 0;
            this.bttneliminarservicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttneliminarservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttneliminarservicio.ForeColor = System.Drawing.Color.White;
            this.bttneliminarservicio.Location = new System.Drawing.Point(883, 72);
            this.bttneliminarservicio.Name = "bttneliminarservicio";
            this.bttneliminarservicio.Size = new System.Drawing.Size(112, 38);
            this.bttneliminarservicio.TabIndex = 69;
            this.bttneliminarservicio.Text = "Eliminar";
            this.bttneliminarservicio.UseVisualStyleBackColor = false;
            this.bttneliminarservicio.Click += new System.EventHandler(this.bttneliminarservicio_Click);
            // 
            // bttneditarservicio
            // 
            this.bttneditarservicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(110)))), ((int)(((byte)(75)))));
            this.bttneditarservicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttneditarservicio.FlatAppearance.BorderSize = 0;
            this.bttneditarservicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttneditarservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttneditarservicio.ForeColor = System.Drawing.Color.White;
            this.bttneditarservicio.Location = new System.Drawing.Point(765, 72);
            this.bttneditarservicio.Name = "bttneditarservicio";
            this.bttneditarservicio.Size = new System.Drawing.Size(112, 38);
            this.bttneditarservicio.TabIndex = 68;
            this.bttneditarservicio.Text = "Editar";
            this.bttneditarservicio.UseVisualStyleBackColor = false;
            this.bttneditarservicio.Click += new System.EventHandler(this.bttneditarservicio_Click);
            // 
            // Btnnuevoservicio
            // 
            this.Btnnuevoservicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(182)))), ((int)(((byte)(77)))));
            this.Btnnuevoservicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnnuevoservicio.FlatAppearance.BorderSize = 0;
            this.Btnnuevoservicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnnuevoservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnnuevoservicio.ForeColor = System.Drawing.Color.White;
            this.Btnnuevoservicio.Location = new System.Drawing.Point(647, 72);
            this.Btnnuevoservicio.Name = "Btnnuevoservicio";
            this.Btnnuevoservicio.Size = new System.Drawing.Size(112, 38);
            this.Btnnuevoservicio.TabIndex = 67;
            this.Btnnuevoservicio.Text = "Nuevo";
            this.Btnnuevoservicio.UseVisualStyleBackColor = false;
            this.Btnnuevoservicio.Click += new System.EventHandler(this.Btnnuevoservicio_Click);
            // 
            // dataGridViewservicio
            // 
            this.dataGridViewservicio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewservicio.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewservicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewservicio.Location = new System.Drawing.Point(67, 125);
            this.dataGridViewservicio.MultiSelect = false;
            this.dataGridViewservicio.Name = "dataGridViewservicio";
            this.dataGridViewservicio.RowHeadersVisible = false;
            this.dataGridViewservicio.RowHeadersWidth = 51;
            this.dataGridViewservicio.RowTemplate.Height = 24;
            this.dataGridViewservicio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewservicio.Size = new System.Drawing.Size(1045, 250);
            this.dataGridViewservicio.TabIndex = 66;
            this.dataGridViewservicio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewservicio_CellClick);
            // 
            // labelbuscarservicio
            // 
            this.labelbuscarservicio.AutoSize = true;
            this.labelbuscarservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelbuscarservicio.ForeColor = System.Drawing.Color.DimGray;
            this.labelbuscarservicio.Location = new System.Drawing.Point(67, 72);
            this.labelbuscarservicio.Name = "labelbuscarservicio";
            this.labelbuscarservicio.Size = new System.Drawing.Size(92, 31);
            this.labelbuscarservicio.TabIndex = 65;
            this.labelbuscarservicio.Text = "Buscar:";
            // 
            // lblservicios
            // 
            this.lblservicios.AutoSize = true;
            this.lblservicios.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblservicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.lblservicios.Location = new System.Drawing.Point(67, 22);
            this.lblservicios.Name = "lblservicios";
            this.lblservicios.Size = new System.Drawing.Size(300, 41);
            this.lblservicios.TabIndex = 64;
            this.lblservicios.Text = "Control de Servicios";
            // 
            // lblprecioservicio
            // 
            this.lblprecioservicio.AutoSize = true;
            this.lblprecioservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprecioservicio.ForeColor = System.Drawing.Color.DimGray;
            this.lblprecioservicio.Location = new System.Drawing.Point(643, 443);
            this.lblprecioservicio.Name = "lblprecioservicio";
            this.lblprecioservicio.Size = new System.Drawing.Size(87, 31);
            this.lblprecioservicio.TabIndex = 81;
            this.lblprecioservicio.Text = "Precio:";
            // 
            // lblduracion
            // 
            this.lblduracion.AutoSize = true;
            this.lblduracion.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblduracion.ForeColor = System.Drawing.Color.DimGray;
            this.lblduracion.Location = new System.Drawing.Point(643, 481);
            this.lblduracion.Name = "lblduracion";
            this.lblduracion.Size = new System.Drawing.Size(118, 31);
            this.lblduracion.TabIndex = 83;
            this.lblduracion.Text = "Duracion:";
            // 
            // lblestado
            // 
            this.lblestado.AutoSize = true;
            this.lblestado.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblestado.ForeColor = System.Drawing.Color.DimGray;
            this.lblestado.Location = new System.Drawing.Point(643, 557);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(91, 31);
            this.lblestado.TabIndex = 86;
            this.lblestado.Text = "Estado:";
            // 
            // comboBoxestadoservicio
            // 
            this.comboBoxestadoservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxestadoservicio.FormattingEnabled = true;
            this.comboBoxestadoservicio.Items.AddRange(new object[] {
            "Activo ",
            "Inactivo"});
            this.comboBoxestadoservicio.Location = new System.Drawing.Point(765, 556);
            this.comboBoxestadoservicio.Name = "comboBoxestadoservicio";
            this.comboBoxestadoservicio.Size = new System.Drawing.Size(348, 39);
            this.comboBoxestadoservicio.TabIndex = 87;
            // 
            // txtIdservicio
            // 
            this.txtIdservicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdservicio.Location = new System.Drawing.Point(197, 443);
            this.txtIdservicio.Name = "txtIdservicio";
            this.txtIdservicio.Size = new System.Drawing.Size(348, 34);
            this.txtIdservicio.TabIndex = 88;
            // 
            // txtnombreservicio
            // 
            this.txtnombreservicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombreservicio.Location = new System.Drawing.Point(197, 481);
            this.txtnombreservicio.Name = "txtnombreservicio";
            this.txtnombreservicio.Size = new System.Drawing.Size(348, 34);
            this.txtnombreservicio.TabIndex = 89;
            this.txtnombreservicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnombreservicio_KeyPress);
            // 
            // txtprecioservicio
            // 
            this.txtprecioservicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprecioservicio.Location = new System.Drawing.Point(765, 443);
            this.txtprecioservicio.Name = "txtprecioservicio";
            this.txtprecioservicio.Size = new System.Drawing.Size(348, 34);
            this.txtprecioservicio.TabIndex = 90;
            this.txtprecioservicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtprecioservicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprecioservicio_KeyPress);
            // 
            // txtduracionservicio
            // 
            this.txtduracionservicio.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtduracionservicio.Location = new System.Drawing.Point(765, 481);
            this.txtduracionservicio.Name = "txtduracionservicio";
            this.txtduracionservicio.Size = new System.Drawing.Size(347, 38);
            this.txtduracionservicio.TabIndex = 91;
            this.txtduracionservicio.TextChanged += new System.EventHandler(this.txtduracionservicio_TextChanged);
            this.txtduracionservicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtduracionservicio_KeyPress);
            // 
            // L
            // 
            this.L.AutoSize = true;
            this.L.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L.ForeColor = System.Drawing.Color.DimGray;
            this.L.Location = new System.Drawing.Point(736, 443);
            this.L.Name = "L";
            this.L.Size = new System.Drawing.Size(32, 31);
            this.L.TabIndex = 92;
            this.L.Text = "L.";
            // 
            // minutosahoras
            // 
            this.minutosahoras.BackColor = System.Drawing.Color.Transparent;
            this.minutosahoras.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minutosahoras.ForeColor = System.Drawing.Color.DimGray;
            this.minutosahoras.Location = new System.Drawing.Point(888, 522);
            this.minutosahoras.Name = "minutosahoras";
            this.minutosahoras.Size = new System.Drawing.Size(95, 28);
            this.minutosahoras.TabIndex = 93;
            this.minutosahoras.Text = "1 hora 30 minutos";
            // 
            // frmServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1182, 720);
            this.Controls.Add(this.minutosahoras);
            this.Controls.Add(this.L);
            this.Controls.Add(this.txtduracionservicio);
            this.Controls.Add(this.txtprecioservicio);
            this.Controls.Add(this.txtnombreservicio);
            this.Controls.Add(this.txtIdservicio);
            this.Controls.Add(this.comboBoxestadoservicio);
            this.Controls.Add(this.lblestado);
            this.Controls.Add(this.lblduracion);
            this.Controls.Add(this.lblprecioservicio);
            this.Controls.Add(this.txtdescripcionservicio);
            this.Controls.Add(this.progressBarservicio);
            this.Controls.Add(this.lblidservicio);
            this.Controls.Add(this.labeldescripcionservicio);
            this.Controls.Add(this.labelnombreservicio);
            this.Controls.Add(this.lbldatosservicio);
            this.Controls.Add(this.btnbuscarservicio);
            this.Controls.Add(this.txtBuscarservicio);
            this.Controls.Add(this.btnguardarservicio);
            this.Controls.Add(this.bttneliminarservicio);
            this.Controls.Add(this.bttneditarservicio);
            this.Controls.Add(this.Btnnuevoservicio);
            this.Controls.Add(this.dataGridViewservicio);
            this.Controls.Add(this.labelbuscarservicio);
            this.Controls.Add(this.lblservicios);
            this.Name = "frmServicios";
            this.Text = "frmServicios";
            this.Load += new System.EventHandler(this.frmServicios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewservicio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtdescripcionservicio;
        private System.Windows.Forms.ProgressBar progressBarservicio;
        private System.Windows.Forms.Label lblidservicio;
        private System.Windows.Forms.Label labeldescripcionservicio;
        private System.Windows.Forms.Label labelnombreservicio;
        private System.Windows.Forms.Label lbldatosservicio;
        private System.Windows.Forms.Button btnbuscarservicio;
        private System.Windows.Forms.TextBox txtBuscarservicio;
        private System.Windows.Forms.Button btnguardarservicio;
        private System.Windows.Forms.Button bttneliminarservicio;
        private System.Windows.Forms.Button bttneditarservicio;
        private System.Windows.Forms.Button Btnnuevoservicio;
        private System.Windows.Forms.DataGridView dataGridViewservicio;
        private System.Windows.Forms.Label labelbuscarservicio;
        private System.Windows.Forms.Label lblservicios;
        private System.Windows.Forms.Label lblprecioservicio;
        private System.Windows.Forms.Label lblduracion;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.ComboBox comboBoxestadoservicio;
        private System.Windows.Forms.TextBox txtIdservicio;
        private System.Windows.Forms.TextBox txtnombreservicio;
        private System.Windows.Forms.TextBox txtprecioservicio;
        private System.Windows.Forms.TextBox txtduracionservicio;
        private System.Windows.Forms.Label L;
        private System.Windows.Forms.Label minutosahoras;
    }
}