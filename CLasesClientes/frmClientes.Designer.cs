namespace BRAMSELU
{
    partial class frmClientes
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
            this.labelbuscar = new System.Windows.Forms.Label();
            this.dataGridViewclientes = new System.Windows.Forms.DataGridView();
            this.Btnnuevo = new System.Windows.Forms.Button();
            this.bttneditarclientes = new System.Windows.Forms.Button();
            this.bttneliminarclientes = new System.Windows.Forms.Button();
            this.btnguardarcliente = new System.Windows.Forms.Button();
            this.lblcontrolclientes = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnbuscarcliente = new System.Windows.Forms.Button();
            this.lbldatosclientes = new System.Windows.Forms.Label();
            this.labelnombrecliente = new System.Windows.Forms.Label();
            this.txtnombrecliente = new System.Windows.Forms.TextBox();
            this.labeltelefonocliente = new System.Windows.Forms.Label();
            this.labelcorreroclientle = new System.Windows.Forms.Label();
            this.txtcorreocliente = new System.Windows.Forms.TextBox();
            this.labeldireecioncliente = new System.Windows.Forms.Label();
            this.txtdireccioncliente = new System.Windows.Forms.TextBox();
            this.labeltipopielcliente = new System.Windows.Forms.Label();
            this.txtidcliente = new System.Windows.Forms.MaskedTextBox();
            this.lblIdentidad = new System.Windows.Forms.Label();
            this.txttelefonocliente = new System.Windows.Forms.MaskedTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Cmbpiel = new System.Windows.Forms.ComboBox();
            this.progressBarclientes = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewclientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelbuscar
            // 
            this.labelbuscar.AutoSize = true;
            this.labelbuscar.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelbuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labelbuscar.Location = new System.Drawing.Point(67, 72);
            this.labelbuscar.Name = "labelbuscar";
            this.labelbuscar.Size = new System.Drawing.Size(92, 31);
            this.labelbuscar.TabIndex = 1;
            this.labelbuscar.Text = "Buscar:";
            // 
            // dataGridViewclientes
            // 
            this.dataGridViewclientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewclientes.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewclientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewclientes.Location = new System.Drawing.Point(67, 125);
            this.dataGridViewclientes.Name = "dataGridViewclientes";
            this.dataGridViewclientes.RowHeadersVisible = false;
            this.dataGridViewclientes.RowHeadersWidth = 51;
            this.dataGridViewclientes.RowTemplate.Height = 24;
            this.dataGridViewclientes.Size = new System.Drawing.Size(1045, 250);
            this.dataGridViewclientes.TabIndex = 7;
            this.dataGridViewclientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewclientes_CellClick);
            // 
            // Btnnuevo
            // 
            this.Btnnuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(182)))), ((int)(((byte)(77)))));
            this.Btnnuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnnuevo.FlatAppearance.BorderSize = 0;
            this.Btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnnuevo.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnnuevo.ForeColor = System.Drawing.Color.White;
            this.Btnnuevo.Location = new System.Drawing.Point(647, 72);
            this.Btnnuevo.Name = "Btnnuevo";
            this.Btnnuevo.Size = new System.Drawing.Size(112, 38);
            this.Btnnuevo.TabIndex = 8;
            this.Btnnuevo.Text = "Nuevo";
            this.Btnnuevo.UseVisualStyleBackColor = false;
            this.Btnnuevo.Click += new System.EventHandler(this.Btnnuevo_Click_1);
            // 
            // bttneditarclientes
            // 
            this.bttneditarclientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(110)))), ((int)(((byte)(75)))));
            this.bttneditarclientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttneditarclientes.FlatAppearance.BorderSize = 0;
            this.bttneditarclientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttneditarclientes.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttneditarclientes.ForeColor = System.Drawing.Color.White;
            this.bttneditarclientes.Location = new System.Drawing.Point(765, 72);
            this.bttneditarclientes.Name = "bttneditarclientes";
            this.bttneditarclientes.Size = new System.Drawing.Size(112, 38);
            this.bttneditarclientes.TabIndex = 9;
            this.bttneditarclientes.Text = "Editar";
            this.bttneditarclientes.UseVisualStyleBackColor = false;
            this.bttneditarclientes.Click += new System.EventHandler(this.bttneditarclientes_Click);
            // 
            // bttneliminarclientes
            // 
            this.bttneliminarclientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(83)))), ((int)(((byte)(112)))));
            this.bttneliminarclientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttneliminarclientes.FlatAppearance.BorderSize = 0;
            this.bttneliminarclientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttneliminarclientes.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttneliminarclientes.ForeColor = System.Drawing.Color.White;
            this.bttneliminarclientes.Location = new System.Drawing.Point(883, 72);
            this.bttneliminarclientes.Name = "bttneliminarclientes";
            this.bttneliminarclientes.Size = new System.Drawing.Size(112, 38);
            this.bttneliminarclientes.TabIndex = 10;
            this.bttneliminarclientes.Text = "Eliminar";
            this.bttneliminarclientes.UseVisualStyleBackColor = false;
            this.bttneliminarclientes.Click += new System.EventHandler(this.bttneliminarclientes_Click);
            // 
            // btnguardarcliente
            // 
            this.btnguardarcliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(193)))), ((int)(((byte)(91)))));
            this.btnguardarcliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardarcliente.FlatAppearance.BorderSize = 0;
            this.btnguardarcliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardarcliente.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardarcliente.ForeColor = System.Drawing.Color.White;
            this.btnguardarcliente.Location = new System.Drawing.Point(1001, 72);
            this.btnguardarcliente.Name = "btnguardarcliente";
            this.btnguardarcliente.Size = new System.Drawing.Size(112, 38);
            this.btnguardarcliente.TabIndex = 11;
            this.btnguardarcliente.Text = "Guardar";
            this.btnguardarcliente.UseVisualStyleBackColor = false;
            this.btnguardarcliente.Click += new System.EventHandler(this.btnguardarcliente_Click);
            // 
            // lblcontrolclientes
            // 
            this.lblcontrolclientes.AutoSize = true;
            this.lblcontrolclientes.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcontrolclientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.lblcontrolclientes.Location = new System.Drawing.Point(67, 22);
            this.lblcontrolclientes.Name = "lblcontrolclientes";
            this.lblcontrolclientes.Size = new System.Drawing.Size(287, 41);
            this.lblcontrolclientes.TabIndex = 12;
            this.lblcontrolclientes.Text = "Control de Clientes";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(165, 72);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(340, 38);
            this.txtBuscar.TabIndex = 13;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnbuscarcliente
            // 
            this.btnbuscarcliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnbuscarcliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarcliente.FlatAppearance.BorderSize = 0;
            this.btnbuscarcliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarcliente.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscarcliente.ForeColor = System.Drawing.Color.White;
            this.btnbuscarcliente.Location = new System.Drawing.Point(529, 72);
            this.btnbuscarcliente.Name = "btnbuscarcliente";
            this.btnbuscarcliente.Size = new System.Drawing.Size(112, 38);
            this.btnbuscarcliente.TabIndex = 22;
            this.btnbuscarcliente.Text = "Buscar";
            this.btnbuscarcliente.UseVisualStyleBackColor = false;
            this.btnbuscarcliente.Click += new System.EventHandler(this.btnbuscarcliente_Click_1);
            // 
            // lbldatosclientes
            // 
            this.lbldatosclientes.AutoSize = true;
            this.lbldatosclientes.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatosclientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.lbldatosclientes.Location = new System.Drawing.Point(67, 400);
            this.lbldatosclientes.Name = "lbldatosclientes";
            this.lbldatosclientes.Size = new System.Drawing.Size(196, 31);
            this.lbldatosclientes.TabIndex = 23;
            this.lbldatosclientes.Text = "Datos del Cliente";
            // 
            // labelnombrecliente
            // 
            this.labelnombrecliente.AutoSize = true;
            this.labelnombrecliente.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnombrecliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labelnombrecliente.Location = new System.Drawing.Point(67, 481);
            this.labelnombrecliente.Name = "labelnombrecliente";
            this.labelnombrecliente.Size = new System.Drawing.Size(103, 31);
            this.labelnombrecliente.TabIndex = 26;
            this.labelnombrecliente.Text = "Nombre:";
            // 
            // txtnombrecliente
            // 
            this.txtnombrecliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnombrecliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombrecliente.Location = new System.Drawing.Point(197, 481);
            this.txtnombrecliente.Name = "txtnombrecliente";
            this.txtnombrecliente.Size = new System.Drawing.Size(348, 34);
            this.txtnombrecliente.TabIndex = 27;
            // 
            // labeltelefonocliente
            // 
            this.labeltelefonocliente.AutoSize = true;
            this.labeltelefonocliente.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltelefonocliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labeltelefonocliente.Location = new System.Drawing.Point(67, 519);
            this.labeltelefonocliente.Name = "labeltelefonocliente";
            this.labeltelefonocliente.Size = new System.Drawing.Size(105, 31);
            this.labeltelefonocliente.TabIndex = 28;
            this.labeltelefonocliente.Text = "Telefono:";
            // 
            // labelcorreroclientle
            // 
            this.labelcorreroclientle.AutoSize = true;
            this.labelcorreroclientle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelcorreroclientle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labelcorreroclientle.Location = new System.Drawing.Point(646, 443);
            this.labelcorreroclientle.Name = "labelcorreroclientle";
            this.labelcorreroclientle.Size = new System.Drawing.Size(87, 31);
            this.labelcorreroclientle.TabIndex = 30;
            this.labelcorreroclientle.Text = "Correo:";
            // 
            // txtcorreocliente
            // 
            this.txtcorreocliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcorreocliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcorreocliente.Location = new System.Drawing.Point(765, 443);
            this.txtcorreocliente.Name = "txtcorreocliente";
            this.txtcorreocliente.Size = new System.Drawing.Size(348, 34);
            this.txtcorreocliente.TabIndex = 31;
            // 
            // labeldireecioncliente
            // 
            this.labeldireecioncliente.AutoSize = true;
            this.labeldireecioncliente.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldireecioncliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labeldireecioncliente.Location = new System.Drawing.Point(646, 481);
            this.labeldireecioncliente.Name = "labeldireecioncliente";
            this.labeldireecioncliente.Size = new System.Drawing.Size(115, 31);
            this.labeldireecioncliente.TabIndex = 32;
            this.labeldireecioncliente.Text = "Direccion:";
            // 
            // txtdireccioncliente
            // 
            this.txtdireccioncliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdireccioncliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdireccioncliente.Location = new System.Drawing.Point(765, 481);
            this.txtdireccioncliente.Name = "txtdireccioncliente";
            this.txtdireccioncliente.Size = new System.Drawing.Size(348, 34);
            this.txtdireccioncliente.TabIndex = 33;
            // 
            // labeltipopielcliente
            // 
            this.labeltipopielcliente.AutoSize = true;
            this.labeltipopielcliente.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltipopielcliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labeltipopielcliente.Location = new System.Drawing.Point(646, 519);
            this.labeltipopielcliente.Name = "labeltipopielcliente";
            this.labeltipopielcliente.Size = new System.Drawing.Size(139, 31);
            this.labeltipopielcliente.TabIndex = 34;
            this.labeltipopielcliente.Text = "Tipo de Piel:";
            // 
            // txtidcliente
            // 
            this.txtidcliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidcliente.Location = new System.Drawing.Point(197, 443);
            this.txtidcliente.Name = "txtidcliente";
            this.txtidcliente.Size = new System.Drawing.Size(348, 34);
            this.txtidcliente.TabIndex = 37;
            // 
            // lblIdentidad
            // 
            this.lblIdentidad.AutoSize = true;
            this.lblIdentidad.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.lblIdentidad.Location = new System.Drawing.Point(67, 443);
            this.lblIdentidad.Name = "lblIdentidad";
            this.lblIdentidad.Size = new System.Drawing.Size(118, 31);
            this.lblIdentidad.TabIndex = 36;
            this.lblIdentidad.Text = "Identidad:";
            // 
            // txttelefonocliente
            // 
            this.txttelefonocliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttelefonocliente.Location = new System.Drawing.Point(197, 518);
            this.txttelefonocliente.Name = "txttelefonocliente";
            this.txttelefonocliente.Size = new System.Drawing.Size(348, 34);
            this.txttelefonocliente.TabIndex = 38;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Cmbpiel
            // 
            this.Cmbpiel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmbpiel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmbpiel.FormattingEnabled = true;
            this.Cmbpiel.Items.AddRange(new object[] {
            "Piel Normal",
            "Piel Seca",
            "Piel Grasa",
            "Piel Mixta",
            "Piel Sensible",
            "Piel Deshidratada",
            "Piel Madura",
            "Piel Acneica",
            "Piel Reactiva",
            "Todo Tipo de Piel"});
            this.Cmbpiel.Location = new System.Drawing.Point(765, 519);
            this.Cmbpiel.Name = "Cmbpiel";
            this.Cmbpiel.Size = new System.Drawing.Size(348, 36);
            this.Cmbpiel.TabIndex = 39;
            // 
            // progressBarclientes
            // 
            this.progressBarclientes.Location = new System.Drawing.Point(67, 648);
            this.progressBarclientes.Name = "progressBarclientes";
            this.progressBarclientes.Size = new System.Drawing.Size(129, 29);
            this.progressBarclientes.TabIndex = 40;
            this.progressBarclientes.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1182, 720);
            this.Controls.Add(this.progressBarclientes);
            this.Controls.Add(this.Cmbpiel);
            this.Controls.Add(this.txttelefonocliente);
            this.Controls.Add(this.txtidcliente);
            this.Controls.Add(this.lblIdentidad);
            this.Controls.Add(this.labeltipopielcliente);
            this.Controls.Add(this.txtdireccioncliente);
            this.Controls.Add(this.labeldireecioncliente);
            this.Controls.Add(this.txtcorreocliente);
            this.Controls.Add(this.labelcorreroclientle);
            this.Controls.Add(this.labeltelefonocliente);
            this.Controls.Add(this.txtnombrecliente);
            this.Controls.Add(this.labelnombrecliente);
            this.Controls.Add(this.lbldatosclientes);
            this.Controls.Add(this.btnbuscarcliente);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblcontrolclientes);
            this.Controls.Add(this.btnguardarcliente);
            this.Controls.Add(this.bttneliminarclientes);
            this.Controls.Add(this.bttneditarclientes);
            this.Controls.Add(this.Btnnuevo);
            this.Controls.Add(this.dataGridViewclientes);
            this.Controls.Add(this.labelbuscar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmClientes";
            this.Text = "frmClientes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewclientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelbuscar;
        private System.Windows.Forms.DataGridView dataGridViewclientes;
        private System.Windows.Forms.Button Btnnuevo;
        private System.Windows.Forms.Button bttneditarclientes;
        private System.Windows.Forms.Button bttneliminarclientes;
        private System.Windows.Forms.Button btnguardarcliente;
        private System.Windows.Forms.Label lblcontrolclientes;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnbuscarcliente;
        private System.Windows.Forms.Label lbldatosclientes;
        private System.Windows.Forms.Label labelnombrecliente;
        private System.Windows.Forms.TextBox txtnombrecliente;
        private System.Windows.Forms.Label labeltelefonocliente;
        private System.Windows.Forms.Label labelcorreroclientle;
        private System.Windows.Forms.TextBox txtcorreocliente;
        private System.Windows.Forms.Label labeldireecioncliente;
        private System.Windows.Forms.TextBox txtdireccioncliente;
        private System.Windows.Forms.Label labeltipopielcliente;
        private System.Windows.Forms.MaskedTextBox txtidcliente;
        private System.Windows.Forms.Label lblIdentidad;
        private System.Windows.Forms.MaskedTextBox txttelefonocliente;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox Cmbpiel;
        private System.Windows.Forms.ProgressBar progressBarclientes;
        private System.Windows.Forms.Timer timer1;
    }
}