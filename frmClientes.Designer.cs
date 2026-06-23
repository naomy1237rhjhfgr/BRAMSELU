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
            this.idcliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtbuscarcliente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewclientes)).BeginInit();
            this.SuspendLayout();
            // 
            // labelbuscar
            // 
            this.labelbuscar.AutoSize = true;
            this.labelbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelbuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labelbuscar.Location = new System.Drawing.Point(15, 60);
            this.labelbuscar.Name = "labelbuscar";
            this.labelbuscar.Size = new System.Drawing.Size(68, 20);
            this.labelbuscar.TabIndex = 1;
            this.labelbuscar.Text = "Buscar:";
            // 
            // dataGridViewclientes
            // 
            this.dataGridViewclientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewclientes.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewclientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewclientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcliente,
            this.nombre,
            this.telefono,
            this.correo,
            this.direccion});
            this.dataGridViewclientes.Location = new System.Drawing.Point(19, 160);
            this.dataGridViewclientes.Name = "dataGridViewclientes";
            this.dataGridViewclientes.RowHeadersVisible = false;
            this.dataGridViewclientes.RowHeadersWidth = 51;
            this.dataGridViewclientes.RowTemplate.Height = 24;
            this.dataGridViewclientes.Size = new System.Drawing.Size(853, 358);
            this.dataGridViewclientes.TabIndex = 7;
            // 
            // bttnguardarclientes
            // 
            this.bttnguardarclientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(154)))), ((int)(((byte)(108)))));
            this.bttnguardarclientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnguardarclientes.FlatAppearance.BorderSize = 0;
            this.bttnguardarclientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnguardarclientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bttnguardarclientes.ForeColor = System.Drawing.Color.White;
            this.bttnguardarclientes.Location = new System.Drawing.Point(28, 102);
            this.bttnguardarclientes.Name = "bttnguardarclientes";
            this.bttnguardarclientes.Size = new System.Drawing.Size(110, 32);
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
            this.bttneditarclientes.Location = new System.Drawing.Point(164, 102);
            this.bttneditarclientes.Name = "bttneditarclientes";
            this.bttneditarclientes.Size = new System.Drawing.Size(110, 32);
            this.bttneditarclientes.TabIndex = 9;
            this.bttneditarclientes.Text = "Editar";
            this.bttneditarclientes.UseVisualStyleBackColor = false;
            // 
            // bttneliminarclientes
            // 
            this.bttneliminarclientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.bttneliminarclientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttneliminarclientes.FlatAppearance.BorderSize = 0;
            this.bttneliminarclientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttneliminarclientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bttneliminarclientes.ForeColor = System.Drawing.Color.White;
            this.bttneliminarclientes.Location = new System.Drawing.Point(296, 102);
            this.bttneliminarclientes.Name = "bttneliminarclientes";
            this.bttneliminarclientes.Size = new System.Drawing.Size(110, 32);
            this.bttneliminarclientes.TabIndex = 10;
            this.bttneliminarclientes.Text = "Eliminar";
            this.bttneliminarclientes.UseVisualStyleBackColor = false;
            // 
            // btnguardarcliente
            // 
            this.btnguardarcliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(150)))), ((int)(((byte)(110)))));
            this.btnguardarcliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardarcliente.FlatAppearance.BorderSize = 0;
            this.btnguardarcliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardarcliente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnguardarcliente.ForeColor = System.Drawing.Color.White;
            this.btnguardarcliente.Location = new System.Drawing.Point(429, 102);
            this.btnguardarcliente.Name = "btnguardarcliente";
            this.btnguardarcliente.Size = new System.Drawing.Size(110, 32);
            this.btnguardarcliente.TabIndex = 11;
            this.btnguardarcliente.Text = "Guardar";
            this.btnguardarcliente.UseVisualStyleBackColor = false;
            // 
            // lblcontrolclientes
            // 
            this.lblcontrolclientes.AutoSize = true;
            this.lblcontrolclientes.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblcontrolclientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(110)))), ((int)(((byte)(75)))));
            this.lblcontrolclientes.Location = new System.Drawing.Point(12, 9);
            this.lblcontrolclientes.Name = "lblcontrolclientes";
            this.lblcontrolclientes.Size = new System.Drawing.Size(262, 37);
            this.lblcontrolclientes.TabIndex = 12;
            this.lblcontrolclientes.Text = "Control de Clientes";
            // 
            // idcliente
            // 
            this.idcliente.FillWeight = 60F;
            this.idcliente.HeaderText = "ID";
            this.idcliente.MinimumWidth = 6;
            this.idcliente.Name = "idcliente";
            // 
            // nombre
            // 
            this.nombre.FillWeight = 180F;
            this.nombre.HeaderText = "Nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            // 
            // telefono
            // 
            this.telefono.FillWeight = 120F;
            this.telefono.HeaderText = "Telefono";
            this.telefono.MinimumWidth = 6;
            this.telefono.Name = "telefono";
            // 
            // correo
            // 
            this.correo.FillWeight = 200F;
            this.correo.HeaderText = "Correo";
            this.correo.MinimumWidth = 6;
            this.correo.Name = "correo";
            // 
            // direccion
            // 
            this.direccion.FillWeight = 250F;
            this.direccion.HeaderText = "Direccion ";
            this.direccion.MinimumWidth = 6;
            this.direccion.Name = "direccion";
            // 
            // txtbuscarcliente
            // 
            this.txtbuscarcliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbuscarcliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtbuscarcliente.Location = new System.Drawing.Point(89, 56);
            this.txtbuscarcliente.Name = "txtbuscarcliente";
            this.txtbuscarcliente.Size = new System.Drawing.Size(450, 30);
            this.txtbuscarcliente.TabIndex = 13;
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(900, 530);
            this.Controls.Add(this.txtbuscarcliente);
            this.Controls.Add(this.lblcontrolclientes);
            this.Controls.Add(this.btnguardarcliente);
            this.Controls.Add(this.bttneliminarclientes);
            this.Controls.Add(this.bttneditarclientes);
            this.Controls.Add(this.bttnguardarclientes);
            this.Controls.Add(this.dataGridViewclientes);
            this.Controls.Add(this.labelbuscar);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn idcliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.TextBox txtbuscarcliente;
    }
}