using System;
using System.Drawing;
using System.Windows.Forms;

namespace BRAMSELU.Compra
{
    partial class FrmCompra
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.btnSeleccionarProducto = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnAgregarAlCarrito = new System.Windows.Forms.Button();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.btnFinalizarCompra = new System.Windows.Forms.Button();
            this.lblTextoTotalGrl = new System.Windows.Forms.Label();
            this.lblTotalGrl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbProveedor);
            this.groupBox1.Controls.Add(this.lblProveedor);
            this.groupBox1.Controls.Add(this.btnSeleccionarProducto);
            this.groupBox1.Controls.Add(this.lblProducto);
            this.groupBox1.Controls.Add(this.txtProducto);
            this.groupBox1.Controls.Add(this.lblCantidad);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.lblPrecio);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.btnAgregarAlCarrito);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1140, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestión de Compras y Proveedores";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(120, 42);
            this.cmbProveedor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(328, 28);
            this.cmbProveedor.TabIndex = 1;
            this.cmbProveedor.SelectedIndexChanged += new System.EventHandler(this.cmbProveedor_SelectedIndexChanged);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(22, 46);
            this.lblProveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(85, 20);
            this.lblProveedor.TabIndex = 0;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // btnSeleccionarProducto
            // 
            this.btnSeleccionarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnSeleccionarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarProducto.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarProducto.Location = new System.Drawing.Point(22, 100);
            this.btnSeleccionarProducto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSeleccionarProducto.Name = "btnSeleccionarProducto";
            this.btnSeleccionarProducto.Size = new System.Drawing.Size(195, 38);
            this.btnSeleccionarProducto.TabIndex = 2;
            this.btnSeleccionarProducto.Text = "Seleccionar Producto";
            this.btnSeleccionarProducto.UseVisualStyleBackColor = false;
            this.btnSeleccionarProducto.Click += new System.EventHandler(this.btnSeleccionarProducto_Click);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(232, 80);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(77, 20);
            this.lblProducto.TabIndex = 3;
            this.lblProducto.Text = "Producto:";
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(232, 105);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(268, 26);
            this.txtProducto.TabIndex = 4;
            this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(518, 80);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(77, 20);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(518, 105);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(103, 26);
            this.txtCantidad.TabIndex = 6;
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(638, 80);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(57, 20);
            this.lblPrecio.TabIndex = 7;
            this.lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(638, 105);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(118, 26);
            this.txtPrecio.TabIndex = 8;
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            // 
            // btnAgregarAlCarrito
            // 
            this.btnAgregarAlCarrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAgregarAlCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarAlCarrito.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAlCarrito.Location = new System.Drawing.Point(780, 100);
            this.btnAgregarAlCarrito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregarAlCarrito.Name = "btnAgregarAlCarrito";
            this.btnAgregarAlCarrito.Size = new System.Drawing.Size(165, 38);
            this.btnAgregarAlCarrito.TabIndex = 9;
            this.btnAgregarAlCarrito.Text = "Agregar al Carrito";
            this.btnAgregarAlCarrito.UseVisualStyleBackColor = false;
            this.btnAgregarAlCarrito.Click += new System.EventHandler(this.btnAgregarAlCarrito_Click);
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Location = new System.Drawing.Point(18, 212);
            this.dgvCarrito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.RowHeadersWidth = 62;
            this.dgvCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrito.Size = new System.Drawing.Size(1140, 385);
            this.dgvCarrito.TabIndex = 1;
            // 
            // btnFinalizarCompra
            // 
            this.btnFinalizarCompra.BackColor = System.Drawing.Color.ForestGreen;
            this.btnFinalizarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarCompra.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarCompra.Location = new System.Drawing.Point(18, 623);
            this.btnFinalizarCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFinalizarCompra.Name = "btnFinalizarCompra";
            this.btnFinalizarCompra.Size = new System.Drawing.Size(210, 62);
            this.btnFinalizarCompra.TabIndex = 2;
            this.btnFinalizarCompra.Text = "Finalizar Compra";
            this.btnFinalizarCompra.UseVisualStyleBackColor = false;
            this.btnFinalizarCompra.Click += new System.EventHandler(this.btnFinalizarCompra_Click);
            // 
            // lblTextoTotalGrl
            // 
            this.lblTextoTotalGrl.AutoSize = true;
            this.lblTextoTotalGrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoTotalGrl.ForeColor = System.Drawing.Color.White;
            this.lblTextoTotalGrl.Location = new System.Drawing.Point(795, 638);
            this.lblTextoTotalGrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextoTotalGrl.Name = "lblTextoTotalGrl";
            this.lblTextoTotalGrl.Size = new System.Drawing.Size(162, 29);
            this.lblTextoTotalGrl.TabIndex = 3;
            this.lblTextoTotalGrl.Text = "TOTAL GRL:";
            // 
            // lblTotalGrl
            // 
            this.lblTotalGrl.AutoSize = true;
            this.lblTotalGrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGrl.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTotalGrl.Location = new System.Drawing.Point(975, 635);
            this.lblTotalGrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalGrl.Name = "lblTotalGrl";
            this.lblTotalGrl.Size = new System.Drawing.Size(108, 32);
            this.lblTotalGrl.TabIndex = 4;
            this.lblTotalGrl.Text = "L. 0.00";
            // 
            // FrmCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1176, 709);
            this.Controls.Add(this.lblTotalGrl);
            this.Controls.Add(this.lblTextoTotalGrl);
            this.Controls.Add(this.btnFinalizarCompra);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmCompra";
            this.Text = "Gestión de Compras y Proveedores";
            this.Load += new System.EventHandler(this.FrmCompra_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Button btnSeleccionarProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnAgregarAlCarrito;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Button btnFinalizarCompra;
        private System.Windows.Forms.Label lblTextoTotalGrl;
        private System.Windows.Forms.Label lblTotalGrl;
    }
}