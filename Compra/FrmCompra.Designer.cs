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
            this.groupBox1 = new GroupBox();
            this.cmbProveedor = new ComboBox();
            this.lblProveedor = new Label();
            this.btnSeleccionarProducto = new Button();
            this.lblProducto = new Label();
            this.txtProducto = new TextBox();
            this.lblCantidad = new Label();
            this.txtCantidad = new TextBox();
            this.lblPrecio = new Label();
            this.txtPrecio = new TextBox();
            this.btnAgregarAlCarrito = new Button();
            this.dgvCarrito = new DataGridView();
            this.btnFinalizarCompra = new Button();
            this.lblTextoTotalGrl = new Label();
            this.lblTotalGrl = new Label();

            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();


            // GROUPBOX
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

            this.groupBox1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.groupBox1.ForeColor = Color.FromArgb(41, 128, 185);
            this.groupBox1.Location = new Point(20, 20);
            this.groupBox1.Size = new Size(1140, 180);
            this.groupBox1.Text = "Información de Compra";


            // LABEL PROVEEDOR
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblProveedor.ForeColor = Color.DimGray;
            this.lblProveedor.Location = new Point(30, 50);
            this.lblProveedor.Text = "Proveedor:";


            // COMBO PROVEEDOR
            this.cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProveedor.Font = new Font("Segoe UI", 10F);
            this.cmbProveedor.Location = new Point(130, 45);
            this.cmbProveedor.Size = new Size(330, 30);
            this.cmbProveedor.SelectedIndexChanged += new EventHandler(this.cmbProveedor_SelectedIndexChanged);



            // BOTON SELECCIONAR
            this.btnSeleccionarProducto.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSeleccionarProducto.FlatStyle = FlatStyle.Flat;
            this.btnSeleccionarProducto.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarProducto.ForeColor = Color.White;
            this.btnSeleccionarProducto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSeleccionarProducto.Cursor = Cursors.Hand;
            this.btnSeleccionarProducto.Location = new Point(30, 110);
            this.btnSeleccionarProducto.Size = new Size(190, 40);
            this.btnSeleccionarProducto.Text = "Seleccionar Producto";
            this.btnSeleccionarProducto.Click += new EventHandler(this.btnSeleccionarProducto_Click);



            // PRODUCTO
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblProducto.ForeColor = Color.DimGray;
            this.lblProducto.Location = new Point(250, 90);
            this.lblProducto.Text = "Producto:";


            this.txtProducto.Font = new Font("Segoe UI", 10F);
            this.txtProducto.Location = new Point(250, 115);
            this.txtProducto.Size = new Size(250, 30);
            this.txtProducto.ReadOnly = true;



            // CANTIDAD
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblCantidad.ForeColor = Color.DimGray;
            this.lblCantidad.Location = new Point(530, 90);
            this.lblCantidad.Text = "Cantidad:";


            this.txtCantidad.Font = new Font("Segoe UI", 10F);
            this.txtCantidad.Location = new Point(530, 115);
            this.txtCantidad.Size = new Size(90, 30);
            this.txtCantidad.Text = "1";



            // PRECIO
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblPrecio.ForeColor = Color.DimGray;
            this.lblPrecio.Location = new Point(650, 90);
            this.lblPrecio.Text = "Precio:";


            this.txtPrecio.Font = new Font("Segoe UI", 10F);
            this.txtPrecio.Location = new Point(650, 115);
            this.txtPrecio.Size = new Size(120, 30);
            this.txtPrecio.ReadOnly = true;



            // AGREGAR CARRITO
            this.btnAgregarAlCarrito.BackColor = Color.FromArgb(46, 204, 113);
            this.btnAgregarAlCarrito.FlatStyle = FlatStyle.Flat;
            this.btnAgregarAlCarrito.FlatAppearance.BorderSize = 0;
            this.btnAgregarAlCarrito.ForeColor = Color.White;
            this.btnAgregarAlCarrito.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAgregarAlCarrito.Cursor = Cursors.Hand;
            this.btnAgregarAlCarrito.Location = new Point(810, 110);
            this.btnAgregarAlCarrito.Size = new Size(180, 40);
            this.btnAgregarAlCarrito.Text = "Agregar al Carrito";
            this.btnAgregarAlCarrito.Click += new EventHandler(this.btnAgregarAlCarrito_Click);



            // DATAGRID
            this.dgvCarrito.Location = new Point(20, 230);
            this.dgvCarrito.Size = new Size(1140, 370);
            this.dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.BackgroundColor = Color.White;
            this.dgvCarrito.BorderStyle = BorderStyle.Fixed3D;
            this.dgvCarrito.RowHeadersVisible = false;
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.dgvCarrito.EnableHeadersVisualStyles = false;
            this.dgvCarrito.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            this.dgvCarrito.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvCarrito.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);



            // FINALIZAR
            this.btnFinalizarCompra.BackColor = Color.FromArgb(39, 174, 96);
            this.btnFinalizarCompra.FlatStyle = FlatStyle.Flat;
            this.btnFinalizarCompra.FlatAppearance.BorderSize = 0;
            this.btnFinalizarCompra.ForeColor = Color.White;
            this.btnFinalizarCompra.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnFinalizarCompra.Cursor = Cursors.Hand;
            this.btnFinalizarCompra.Location = new Point(20, 640);
            this.btnFinalizarCompra.Size = new Size(220, 55);
            this.btnFinalizarCompra.Text = "Finalizar Compra";
            this.btnFinalizarCompra.Click += new EventHandler(this.btnFinalizarCompra_Click);



            // TOTAL
            this.lblTextoTotalGrl.AutoSize = true;
            this.lblTextoTotalGrl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTextoTotalGrl.ForeColor = Color.FromArgb(41, 128, 185);
            this.lblTextoTotalGrl.Location = new Point(800, 650);
            this.lblTextoTotalGrl.Text = "TOTAL:";


            this.lblTotalGrl.AutoSize = true;
            this.lblTotalGrl.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTotalGrl.ForeColor = Color.FromArgb(39, 174, 96);
            this.lblTotalGrl.Location = new Point(900, 645);
            this.lblTotalGrl.Text = "L. 0.00";



            // FORM
            this.ClientSize = new Size(1180, 720);
            this.BackColor = Color.WhiteSmoke;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.btnFinalizarCompra);
            this.Controls.Add(this.lblTextoTotalGrl);
            this.Controls.Add(this.lblTotalGrl);

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestión de Compras";


            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private GroupBox groupBox1;
        private ComboBox cmbProveedor;
        private Label lblProveedor;
        private Button btnSeleccionarProducto;
        private Label lblProducto;
        private TextBox txtProducto;
        private Label lblCantidad;
        private TextBox txtCantidad;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Button btnAgregarAlCarrito;
        private DataGridView dgvCarrito;
        private Button btnFinalizarCompra;
        private Label lblTextoTotalGrl;
        private Label lblTotalGrl;
    }
}