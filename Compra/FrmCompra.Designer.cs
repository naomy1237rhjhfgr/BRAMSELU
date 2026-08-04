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
            DataGridViewCellStyle dgvHeaderStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvDefaultStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvAltStyle = new DataGridViewCellStyle();

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
            this.pnlAcento = new Panel();

            this.pnlHeader = new Panel();
            this.lblTitulo = new Label();
            this.pnlCompra = new Panel();
            this.lblCompraCaption = new Label();
            this.pnlResumen = new Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();

            // Paleta (misma que FrmVentas)
            Color azulAccento = Color.FromArgb(64, 153, 255);
            Color azulMarino = Color.FromArgb(27, 35, 42);
            Color verde = Color.FromArgb(17, 193, 91);
            Color grisTexto = Color.FromArgb(70, 70, 70);
            Color fondoPagina = Color.FromArgb(244, 247, 251);

            // 
            // pnlAcento (franja azul superior)
            // 
            this.pnlAcento.BackColor = azulAccento;
            this.pnlAcento.Location = new Point(0, 0);
            this.pnlAcento.Name = "pnlAcento";
            this.pnlAcento.Size = new Size(1200, 6);
            this.pnlAcento.TabIndex = 97;

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = azulMarino;
            this.pnlHeader.Location = new Point(0, 6);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(1200, 64);
            this.pnlHeader.TabIndex = 96;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = Color.Transparent;
            this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location = new Point(28, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Gestión de Compras";
            this.pnlHeader.Controls.Add(this.lblTitulo);

            // 
            // pnlCompra (tarjeta "Información de Compra")
            // 
            this.pnlCompra.BackColor = Color.White;
            this.pnlCompra.BorderStyle = BorderStyle.FixedSingle;
            this.pnlCompra.Location = new Point(24, 90);
            this.pnlCompra.Name = "pnlCompra";
            this.pnlCompra.Size = new Size(1152, 150);
            this.pnlCompra.TabIndex = 95;

            // 
            // lblCompraCaption
            // 
            this.lblCompraCaption.AutoSize = true;
            this.lblCompraCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCompraCaption.ForeColor = azulAccento;
            this.lblCompraCaption.Location = new Point(18, 12);
            this.lblCompraCaption.Name = "lblCompraCaption";
            this.lblCompraCaption.Text = "INFORMACIÓN DE COMPRA";

            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblProveedor.ForeColor = grisTexto;
            this.lblProveedor.Location = new Point(18, 46);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Text = "Proveedor:";

            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbProveedor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.cmbProveedor.FlatStyle = FlatStyle.Flat;
            this.cmbProveedor.Location = new Point(140, 40);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new Size(280, 40);
            this.cmbProveedor.TabIndex = 0;
            this.cmbProveedor.SelectedIndexChanged += new EventHandler(this.cmbProveedor_SelectedIndexChanged);

            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblProducto.ForeColor = grisTexto;
            this.lblProducto.Location = new Point(460, 46);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Text = "Producto:";

            // 
            // txtProducto
            // 
            this.txtProducto.BackColor = Color.FromArgb(248, 249, 251);
            this.txtProducto.BorderStyle = BorderStyle.FixedSingle;
            this.txtProducto.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            this.txtProducto.Location = new Point(570, 40);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new Size(280, 38);
            this.txtProducto.TabIndex = 1;

            // 
            // btnSeleccionarProducto
            // 
            this.btnSeleccionarProducto.BackColor = azulAccento;
            this.btnSeleccionarProducto.Cursor = Cursors.Hand;
            this.btnSeleccionarProducto.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarProducto.FlatStyle = FlatStyle.Flat;
            this.btnSeleccionarProducto.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnSeleccionarProducto.ForeColor = Color.White;
            this.btnSeleccionarProducto.Location = new Point(870, 38);
            this.btnSeleccionarProducto.Name = "btnSeleccionarProducto";
            this.btnSeleccionarProducto.Size = new Size(160, 42);
            this.btnSeleccionarProducto.TabIndex = 2;
            this.btnSeleccionarProducto.Text = "Seleccionar";
            this.btnSeleccionarProducto.UseVisualStyleBackColor = false;
            this.btnSeleccionarProducto.Click += new EventHandler(this.btnSeleccionarProducto_Click);

            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblCantidad.ForeColor = grisTexto;
            this.lblCantidad.Location = new Point(18, 104);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Text = "Cantidad:";

            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = Color.FromArgb(248, 249, 251);
            this.txtCantidad.BorderStyle = BorderStyle.FixedSingle;
            this.txtCantidad.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            this.txtCantidad.Location = new Point(140, 98);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new Size(90, 38);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.Text = "1";

            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblPrecio.ForeColor = grisTexto;
            this.lblPrecio.Location = new Point(260, 104);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Text = "Precio:";

            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = Color.FromArgb(248, 249, 251);
            this.txtPrecio.BorderStyle = BorderStyle.FixedSingle;
            this.txtPrecio.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            this.txtPrecio.Location = new Point(340, 98);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new Size(120, 38);
            this.txtPrecio.TabIndex = 4;

            // 
            // btnAgregarAlCarrito
            // 
            this.btnAgregarAlCarrito.BackColor = verde;
            this.btnAgregarAlCarrito.Cursor = Cursors.Hand;
            this.btnAgregarAlCarrito.FlatAppearance.BorderSize = 0;
            this.btnAgregarAlCarrito.FlatStyle = FlatStyle.Flat;
            this.btnAgregarAlCarrito.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnAgregarAlCarrito.ForeColor = Color.White;
            this.btnAgregarAlCarrito.Location = new Point(870, 94);
            this.btnAgregarAlCarrito.Name = "btnAgregarAlCarrito";
            this.btnAgregarAlCarrito.Size = new Size(260, 42);
            this.btnAgregarAlCarrito.TabIndex = 5;
            this.btnAgregarAlCarrito.Text = "+ Agregar al Carrito";
            this.btnAgregarAlCarrito.UseVisualStyleBackColor = false;
            this.btnAgregarAlCarrito.Click += new EventHandler(this.btnAgregarAlCarrito_Click);

            this.pnlCompra.Controls.Add(this.lblCompraCaption);
            this.pnlCompra.Controls.Add(this.lblProveedor);
            this.pnlCompra.Controls.Add(this.cmbProveedor);
            this.pnlCompra.Controls.Add(this.lblProducto);
            this.pnlCompra.Controls.Add(this.txtProducto);
            this.pnlCompra.Controls.Add(this.btnSeleccionarProducto);
            this.pnlCompra.Controls.Add(this.lblCantidad);
            this.pnlCompra.Controls.Add(this.txtCantidad);
            this.pnlCompra.Controls.Add(this.lblPrecio);
            this.pnlCompra.Controls.Add(this.txtPrecio);
            this.pnlCompra.Controls.Add(this.btnAgregarAlCarrito);

            // 
            // dgvCarrito
            // 
            dgvHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = azulMarino;
            dgvHeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvHeaderStyle.ForeColor = Color.White;
            dgvHeaderStyle.Padding = new Padding(10, 0, 0, 0);
            dgvHeaderStyle.SelectionBackColor = azulMarino;
            dgvHeaderStyle.SelectionForeColor = Color.White;
            dgvHeaderStyle.WrapMode = DataGridViewTriState.True;

            dgvDefaultStyle.BackColor = Color.White;
            dgvDefaultStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvDefaultStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgvDefaultStyle.Padding = new Padding(10, 4, 4, 4);
            dgvDefaultStyle.SelectionBackColor = azulAccento;
            dgvDefaultStyle.SelectionForeColor = Color.White;

            dgvAltStyle.BackColor = Color.FromArgb(244, 249, 255);

            this.dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.BackgroundColor = Color.White;
            this.dgvCarrito.BorderStyle = BorderStyle.FixedSingle;
            this.dgvCarrito.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCarrito.GridColor = Color.FromArgb(232, 235, 240);
            this.dgvCarrito.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvCarrito.ColumnHeadersHeight = 42;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCarrito.DefaultCellStyle = dgvDefaultStyle;
            this.dgvCarrito.AlternatingRowsDefaultCellStyle = dgvAltStyle;
            this.dgvCarrito.RowTemplate.Height = 36;
            this.dgvCarrito.EnableHeadersVisualStyles = false;
            this.dgvCarrito.Location = new Point(24, 260);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AllowUserToResizeRows = false;
            this.dgvCarrito.RowHeadersVisible = false;
            this.dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrito.Size = new Size(1152, 380);
            this.dgvCarrito.TabIndex = 6;

            // 
            // pnlResumen (tarjeta inferior con total y botón de finalizar)
            // 
            this.pnlResumen.BackColor = Color.FromArgb(232, 242, 255);
            this.pnlResumen.BorderStyle = BorderStyle.FixedSingle;
            this.pnlResumen.Location = new Point(24, 660);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new Size(1152, 76);
            this.pnlResumen.TabIndex = 93;

            // 
            // btnFinalizarCompra
            // 
            this.btnFinalizarCompra.BackColor = verde;
            this.btnFinalizarCompra.Cursor = Cursors.Hand;
            this.btnFinalizarCompra.FlatAppearance.BorderSize = 0;
            this.btnFinalizarCompra.FlatStyle = FlatStyle.Flat;
            this.btnFinalizarCompra.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            this.btnFinalizarCompra.ForeColor = Color.White;
            this.btnFinalizarCompra.Location = new Point(24, 16);
            this.btnFinalizarCompra.Name = "btnFinalizarCompra";
            this.btnFinalizarCompra.Size = new Size(240, 44);
            this.btnFinalizarCompra.TabIndex = 7;
            this.btnFinalizarCompra.Text = "Finalizar Compra";
            this.btnFinalizarCompra.UseVisualStyleBackColor = false;
            this.btnFinalizarCompra.Click += new EventHandler(this.btnFinalizarCompra_Click);

            // 
            // lblTextoTotalGrl
            // 
            this.lblTextoTotalGrl.AutoSize = true;
            this.lblTextoTotalGrl.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTextoTotalGrl.ForeColor = Color.FromArgb(90, 100, 115);
            this.lblTextoTotalGrl.Location = new Point(830, 26);
            this.lblTextoTotalGrl.Name = "lblTextoTotalGrl";
            this.lblTextoTotalGrl.Text = "TOTAL:";

            // 
            // lblTotalGrl
            // 
            this.lblTotalGrl.AutoSize = true;
            this.lblTotalGrl.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            this.lblTotalGrl.ForeColor = verde;
            this.lblTotalGrl.Location = new Point(940, 16);
            this.lblTotalGrl.Name = "lblTotalGrl";
            this.lblTotalGrl.Text = "L. 0.00";

            this.pnlResumen.Controls.Add(this.btnFinalizarCompra);
            this.pnlResumen.Controls.Add(this.lblTextoTotalGrl);
            this.pnlResumen.Controls.Add(this.lblTotalGrl);

            // 
            // FrmCompra
            // 
            this.BackColor = fondoPagina;
            this.ClientSize = new Size(1200, 760);
            this.Controls.Add(this.pnlAcento);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlCompra);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.pnlResumen);
            this.Name = "FrmCompra";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestión de Compras";
            this.Load += new EventHandler(this.FrmCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);
        }

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
        private Panel pnlAcento;

        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlCompra;
        private Label lblCompraCaption;
        private Panel pnlResumen;
    }
}