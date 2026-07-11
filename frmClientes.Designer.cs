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
            this.labelbuscar = new System.Windows.Forms.Label();
            this.dataGridViewclientes = new System.Windows.Forms.DataGridView();
            this.bttnguardarclientes = new System.Windows.Forms.Button();
            this.bttneditarclientes = new System.Windows.Forms.Button();
            this.bttneliminarclientes = new System.Windows.Forms.Button();
            this.btnguardarcliente = new System.Windows.Forms.Button();
            this.lblcontrolclientes = new System.Windows.Forms.Label();
            this.txtbuscarcliente = new System.Windows.Forms.TextBox();
            this.btnbuscarclientes = new System.Windows.Forms.Button();
            this.lbldatosclientes = new System.Windows.Forms.Label();
            this.lblidcliente = new System.Windows.Forms.Label();
            this.txtidcliente = new System.Windows.Forms.TextBox();
            this.labelnombrecliente = new System.Windows.Forms.Label();
            this.txtnombrecliente = new System.Windows.Forms.TextBox();
            this.labeltelefonocliente = new System.Windows.Forms.Label();
            this.txttelefonocliente = new System.Windows.Forms.TextBox();
            this.labelcorreroclientle = new System.Windows.Forms.Label();
            this.txtcorreocliente = new System.Windows.Forms.TextBox();
            this.labeldireecioncliente = new System.Windows.Forms.Label();
            this.txtdireccioncliente = new System.Windows.Forms.TextBox();
            this.labeltipopielcliente = new System.Windows.Forms.Label();
            this.txttipopielcliente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewclientes)).BeginInit();
            this.SuspendLayout();
            // 
            // labelbuscar
            // 
            this.labelbuscar.AutoSize = true;
            this.labelbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelbuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labelbuscar.Location = new System.Drawing.Point(17, 75);
            this.labelbuscar.Name = "labelbuscar";
            this.labelbuscar.Size = new System.Drawing.Size(85, 25);
            this.labelbuscar.TabIndex = 1;
            this.labelbuscar.Text = "Buscar:";
            // 
            // dataGridViewclientes
            // 
            this.dataGridViewclientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewclientes.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewclientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewclientes.Location = new System.Drawing.Point(12, 118);
            this.dataGridViewclientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewclientes.Name = "dataGridViewclientes";
            this.dataGridViewclientes.RowHeadersVisible = false;
            this.dataGridViewclientes.RowHeadersWidth = 51;
            this.dataGridViewclientes.RowTemplate.Height = 24;
            this.dataGridViewclientes.Size = new System.Drawing.Size(1034, 183);
            this.dataGridViewclientes.TabIndex = 7;
            this.dataGridViewclientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewclientes_CellClick);
            // 
            // bttnguardarclientes
            // 
            this.bttnguardarclientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(154)))), ((int)(((byte)(108)))));
            this.bttnguardarclientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnguardarclientes.FlatAppearance.BorderSize = 0;
            this.bttnguardarclientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnguardarclientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bttnguardarclientes.ForeColor = System.Drawing.Color.White;
            this.bttnguardarclientes.Location = new System.Drawing.Point(468, 70);
            this.bttnguardarclientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttnguardarclientes.Name = "bttnguardarclientes";
            this.bttnguardarclientes.Size = new System.Drawing.Size(124, 40);
            this.bttnguardarclientes.TabIndex = 8;
            this.bttnguardarclientes.Text = "Nuevo";
            this.bttnguardarclientes.UseVisualStyleBackColor = false;
            // 
            // bttneditarclientes
            // 
            this.bttneditarclientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(110)))), ((int)(((byte)(75)))));
            this.bttneditarclientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttneditarclientes.FlatAppearance.BorderSize = 0;
            this.bttneditarclientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttneditarclientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bttneditarclientes.ForeColor = System.Drawing.Color.White;
            this.bttneditarclientes.Location = new System.Drawing.Point(620, 70);
            this.bttneditarclientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttneditarclientes.Name = "bttneditarclientes";
            this.bttneditarclientes.Size = new System.Drawing.Size(124, 40);
            this.bttneditarclientes.TabIndex = 9;
            this.bttneditarclientes.Text = "Editar";
            this.bttneditarclientes.UseVisualStyleBackColor = false;
            this.bttneditarclientes.Click += new System.EventHandler(this.bttneditarclientes_Click);
            // 
            // bttneliminarclientes
            // 
            this.bttneliminarclientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.bttneliminarclientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttneliminarclientes.FlatAppearance.BorderSize = 0;
            this.bttneliminarclientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttneliminarclientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bttneliminarclientes.ForeColor = System.Drawing.Color.White;
            this.bttneliminarclientes.Location = new System.Drawing.Point(769, 70);
            this.bttneliminarclientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bttneliminarclientes.Name = "bttneliminarclientes";
            this.bttneliminarclientes.Size = new System.Drawing.Size(124, 40);
            this.bttneliminarclientes.TabIndex = 10;
            this.bttneliminarclientes.Text = "Eliminar";
            this.bttneliminarclientes.UseVisualStyleBackColor = false;
            this.bttneliminarclientes.Click += new System.EventHandler(this.bttneliminarclientes_Click);
            // 
            // btnguardarcliente
            // 
            this.btnguardarcliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(150)))), ((int)(((byte)(110)))));
            this.btnguardarcliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardarcliente.FlatAppearance.BorderSize = 0;
            this.btnguardarcliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardarcliente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnguardarcliente.ForeColor = System.Drawing.Color.White;
            this.btnguardarcliente.Location = new System.Drawing.Point(919, 70);
            this.btnguardarcliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnguardarcliente.Name = "btnguardarcliente";
            this.btnguardarcliente.Size = new System.Drawing.Size(124, 40);
            this.btnguardarcliente.TabIndex = 11;
            this.btnguardarcliente.Text = "Guardar";
            this.btnguardarcliente.UseVisualStyleBackColor = false;
            this.btnguardarcliente.Click += new System.EventHandler(this.btnguardarcliente_Click);
            // 
            // lblcontrolclientes
            // 
            this.lblcontrolclientes.AutoSize = true;
            this.lblcontrolclientes.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblcontrolclientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(110)))), ((int)(((byte)(75)))));
            this.lblcontrolclientes.Location = new System.Drawing.Point(14, 11);
            this.lblcontrolclientes.Name = "lblcontrolclientes";
            this.lblcontrolclientes.Size = new System.Drawing.Size(305, 45);
            this.lblcontrolclientes.TabIndex = 12;
            this.lblcontrolclientes.Text = "Control de Clientes";
            // 
            // txtbuscarcliente
            // 
            this.txtbuscarcliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbuscarcliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtbuscarcliente.Location = new System.Drawing.Point(100, 70);
            this.txtbuscarcliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbuscarcliente.Name = "txtbuscarcliente";
            this.txtbuscarcliente.Size = new System.Drawing.Size(219, 34);
            this.txtbuscarcliente.TabIndex = 13;
            this.txtbuscarcliente.TextChanged += new System.EventHandler(this.txtbuscarcliente_TextChanged);
            // 
            // btnbuscarclientes
            // 
            this.btnbuscarclientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(130)))), ((int)(((byte)(160)))));
            this.btnbuscarclientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarclientes.FlatAppearance.BorderSize = 0;
            this.btnbuscarclientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarclientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnbuscarclientes.ForeColor = System.Drawing.Color.White;
            this.btnbuscarclientes.Location = new System.Drawing.Point(344, 65);
            this.btnbuscarclientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnbuscarclientes.Name = "btnbuscarclientes";
            this.btnbuscarclientes.Size = new System.Drawing.Size(112, 42);
            this.btnbuscarclientes.TabIndex = 22;
            this.btnbuscarclientes.Text = "Buscar";
            this.btnbuscarclientes.UseVisualStyleBackColor = false;
            this.btnbuscarclientes.Click += new System.EventHandler(this.btnbuscarclientes_Click);
            // 
            // lbldatosclientes
            // 
            this.lbldatosclientes.AutoSize = true;
            this.lbldatosclientes.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbldatosclientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(110)))), ((int)(((byte)(75)))));
            this.lbldatosclientes.Location = new System.Drawing.Point(26, 337);
            this.lbldatosclientes.Name = "lbldatosclientes";
            this.lbldatosclientes.Size = new System.Drawing.Size(161, 25);
            this.lbldatosclientes.TabIndex = 23;
            this.lbldatosclientes.Text = "Datos del Cliente";
            // 
            // lblidcliente
            // 
            this.lblidcliente.AutoSize = true;
            this.lblidcliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblidcliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.lblidcliente.Location = new System.Drawing.Point(45, 379);
            this.lblidcliente.Name = "lblidcliente";
            this.lblidcliente.Size = new System.Drawing.Size(34, 25);
            this.lblidcliente.TabIndex = 24;
            this.lblidcliente.Text = "ID:";
            // 
            // txtidcliente
            // 
            this.txtidcliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtidcliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtidcliente.Location = new System.Drawing.Point(100, 374);
            this.txtidcliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtidcliente.Name = "txtidcliente";
            this.txtidcliente.Size = new System.Drawing.Size(382, 34);
            this.txtidcliente.TabIndex = 25;
            this.txtidcliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidcliente_KeyPress);
            // 
            // labelnombrecliente
            // 
            this.labelnombrecliente.AutoSize = true;
            this.labelnombrecliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labelnombrecliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labelnombrecliente.Location = new System.Drawing.Point(7, 431);
            this.labelnombrecliente.Name = "labelnombrecliente";
            this.labelnombrecliente.Size = new System.Drawing.Size(85, 25);
            this.labelnombrecliente.TabIndex = 26;
            this.labelnombrecliente.Text = "Nombre:";
            // 
            // txtnombrecliente
            // 
            this.txtnombrecliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnombrecliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtnombrecliente.Location = new System.Drawing.Point(100, 426);
            this.txtnombrecliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtnombrecliente.Name = "txtnombrecliente";
            this.txtnombrecliente.Size = new System.Drawing.Size(382, 34);
            this.txtnombrecliente.TabIndex = 27;
            // 
            // labeltelefonocliente
            // 
            this.labeltelefonocliente.AutoSize = true;
            this.labeltelefonocliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labeltelefonocliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labeltelefonocliente.Location = new System.Drawing.Point(12, 491);
            this.labeltelefonocliente.Name = "labeltelefonocliente";
            this.labeltelefonocliente.Size = new System.Drawing.Size(88, 25);
            this.labeltelefonocliente.TabIndex = 28;
            this.labeltelefonocliente.Text = "Telefono:";
            // 
            // txttelefonocliente
            // 
            this.txttelefonocliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttelefonocliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txttelefonocliente.Location = new System.Drawing.Point(106, 486);
            this.txttelefonocliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttelefonocliente.Name = "txttelefonocliente";
            this.txttelefonocliente.Size = new System.Drawing.Size(194, 34);
            this.txttelefonocliente.TabIndex = 29;
            this.txttelefonocliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttelefonocliente_KeyPress);
            // 
            // labelcorreroclientle
            // 
            this.labelcorreroclientle.AutoSize = true;
            this.labelcorreroclientle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labelcorreroclientle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labelcorreroclientle.Location = new System.Drawing.Point(625, 374);
            this.labelcorreroclientle.Name = "labelcorreroclientle";
            this.labelcorreroclientle.Size = new System.Drawing.Size(70, 25);
            this.labelcorreroclientle.TabIndex = 30;
            this.labelcorreroclientle.Text = "Correo";
            // 
            // txtcorreocliente
            // 
            this.txtcorreocliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcorreocliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtcorreocliente.Location = new System.Drawing.Point(727, 369);
            this.txtcorreocliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcorreocliente.Name = "txtcorreocliente";
            this.txtcorreocliente.Size = new System.Drawing.Size(382, 34);
            this.txtcorreocliente.TabIndex = 31;
            // 
            // labeldireecioncliente
            // 
            this.labeldireecioncliente.AutoSize = true;
            this.labeldireecioncliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labeldireecioncliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labeldireecioncliente.Location = new System.Drawing.Point(599, 426);
            this.labeldireecioncliente.Name = "labeldireecioncliente";
            this.labeldireecioncliente.Size = new System.Drawing.Size(96, 25);
            this.labeldireecioncliente.TabIndex = 32;
            this.labeldireecioncliente.Text = "Direccion:";
            // 
            // txtdireccioncliente
            // 
            this.txtdireccioncliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdireccioncliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtdireccioncliente.Location = new System.Drawing.Point(727, 435);
            this.txtdireccioncliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdireccioncliente.Name = "txtdireccioncliente";
            this.txtdireccioncliente.Size = new System.Drawing.Size(382, 34);
            this.txtdireccioncliente.TabIndex = 33;
            // 
            // labeltipopielcliente
            // 
            this.labeltipopielcliente.AutoSize = true;
            this.labeltipopielcliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labeltipopielcliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labeltipopielcliente.Location = new System.Drawing.Point(580, 491);
            this.labeltipopielcliente.Name = "labeltipopielcliente";
            this.labeltipopielcliente.Size = new System.Drawing.Size(115, 25);
            this.labeltipopielcliente.TabIndex = 34;
            this.labeltipopielcliente.Text = "Tipo de Piel:";
            // 
            // txttipopielcliente
            // 
            this.txttipopielcliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttipopielcliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txttipopielcliente.Location = new System.Drawing.Point(727, 495);
            this.txttipopielcliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttipopielcliente.Name = "txttipopielcliente";
            this.txttipopielcliente.Size = new System.Drawing.Size(376, 34);
            this.txttipopielcliente.TabIndex = 35;
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1326, 760);
            this.Controls.Add(this.txttipopielcliente);
            this.Controls.Add(this.labeltipopielcliente);
            this.Controls.Add(this.txtdireccioncliente);
            this.Controls.Add(this.labeldireecioncliente);
            this.Controls.Add(this.txtcorreocliente);
            this.Controls.Add(this.labelcorreroclientle);
            this.Controls.Add(this.txttelefonocliente);
            this.Controls.Add(this.labeltelefonocliente);
            this.Controls.Add(this.txtnombrecliente);
            this.Controls.Add(this.labelnombrecliente);
            this.Controls.Add(this.txtidcliente);
            this.Controls.Add(this.lblidcliente);
            this.Controls.Add(this.lbldatosclientes);
            this.Controls.Add(this.btnbuscarclientes);
            this.Controls.Add(this.txtbuscarcliente);
            this.Controls.Add(this.lblcontrolclientes);
            this.Controls.Add(this.btnguardarcliente);
            this.Controls.Add(this.bttneliminarclientes);
            this.Controls.Add(this.bttneditarclientes);
            this.Controls.Add(this.bttnguardarclientes);
            this.Controls.Add(this.dataGridViewclientes);
            this.Controls.Add(this.labelbuscar);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmClientes";
            this.Text = "frmClientes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewclientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelbuscar;
        private System.Windows.Forms.DataGridView dataGridViewclientes;
        private System.Windows.Forms.Button bttnguardarclientes;
        private System.Windows.Forms.Button bttneditarclientes;
        private System.Windows.Forms.Button bttneliminarclientes;
        private System.Windows.Forms.Button btnguardarcliente;
        private System.Windows.Forms.Label lblcontrolclientes;
        private System.Windows.Forms.TextBox txtbuscarcliente;
        private System.Windows.Forms.Button btnbuscarclientes;
        private System.Windows.Forms.Label lbldatosclientes;
        private System.Windows.Forms.Label lblidcliente;
        private System.Windows.Forms.TextBox txtidcliente;
        private System.Windows.Forms.Label labelnombrecliente;
        private System.Windows.Forms.TextBox txtnombrecliente;
        private System.Windows.Forms.Label labeltelefonocliente;
        private System.Windows.Forms.TextBox txttelefonocliente;
        private System.Windows.Forms.Label labelcorreroclientle;
        private System.Windows.Forms.TextBox txtcorreocliente;
        private System.Windows.Forms.Label labeldireecioncliente;
        private System.Windows.Forms.TextBox txtdireccioncliente;
        private System.Windows.Forms.Label labeltipopielcliente;
        private System.Windows.Forms.TextBox txttipopielcliente;
    }
}