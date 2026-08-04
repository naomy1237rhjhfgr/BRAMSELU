using System;
using System.Drawing;
using System.Windows.Forms;

namespace BRAMSELU.Ventas
{
    partial class FrmVentas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dgvHeaderStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvDefaultStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvAltStyle = new DataGridViewCellStyle();

            this.btnSeleccionarProducto = new Button();
            this.txtProducto = new TextBox();
            this.txtCantidad = new TextBox();
            this.btnAgregar = new Button();
            this.dgvCarrito = new DataGridView();
            this.lblTotal = new Label();
            this.txtEfectivo = new TextBox();
            this.btnCobrar = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.pnlAcento = new Panel();
            this.btnSeleccionarCliente = new Button();
            this.txtDniCliente = new TextBox();
            this.label5 = new Label();

            this.pnlHeader = new Panel();
            this.lblTitulo = new Label();
            this.pnlCliente = new Panel();
            this.lblClienteCaption = new Label();
            this.pnlProducto = new Panel();
            this.lblProductoCaption = new Label();
            this.pnlResumen = new Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();

            // Paleta
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
            // pnlHeader (barra azul marino con título)
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
            this.lblTitulo.Text = "Módulo de Ventas";
            this.pnlHeader.Controls.Add(this.lblTitulo);

            // 
            // pnlCliente (tarjeta cliente)
            // 
            this.pnlCliente.BackColor = Color.White;
            this.pnlCliente.BorderStyle = BorderStyle.FixedSingle;
            this.pnlCliente.Location = new Point(24, 90);
            this.pnlCliente.Name = "pnlCliente";
            this.pnlCliente.Size = new Size(360, 150);
            this.pnlCliente.TabIndex = 95;

            // 
            // lblClienteCaption
            // 
            this.lblClienteCaption.AutoSize = true;
            this.lblClienteCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblClienteCaption.ForeColor = azulAccento;
            this.lblClienteCaption.Location = new Point(18, 12);
            this.lblClienteCaption.Name = "lblClienteCaption";
            this.lblClienteCaption.Text = "CLIENTE";

            // 
            // label5 (DNI:)
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.label5.ForeColor = grisTexto;
            this.label5.Location = new Point(18, 72);
            this.label5.Name = "label5";
            this.label5.Text = "DNI:";

            // 
            // txtDniCliente
            // 
            this.txtDniCliente.BackColor = Color.FromArgb(248, 249, 251);
            this.txtDniCliente.BorderStyle = BorderStyle.FixedSingle;
            this.txtDniCliente.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            this.txtDniCliente.Location = new Point(70, 66);
            this.txtDniCliente.Name = "txtDniCliente";
            this.txtDniCliente.ReadOnly = true;
            this.txtDniCliente.Size = new Size(160, 38);
            this.txtDniCliente.TabIndex = 0;

            // 
            // btnSeleccionarCliente
            // 
            this.btnSeleccionarCliente.BackColor = azulAccento;
            this.btnSeleccionarCliente.Cursor = Cursors.Hand;
            this.btnSeleccionarCliente.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarCliente.FlatStyle = FlatStyle.Flat;
            this.btnSeleccionarCliente.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            this.btnSeleccionarCliente.ForeColor = Color.White;
            this.btnSeleccionarCliente.Location = new Point(250, 64);
            this.btnSeleccionarCliente.Name = "btnSeleccionarCliente";
            this.btnSeleccionarCliente.Size = new Size(90, 42);
            this.btnSeleccionarCliente.TabIndex = 1;
            this.btnSeleccionarCliente.Text = "Buscar";
            this.btnSeleccionarCliente.UseVisualStyleBackColor = false;
            this.btnSeleccionarCliente.Click += new EventHandler(this.btnSeleccionarCliente_Click);

            this.pnlCliente.Controls.Add(this.lblClienteCaption);
            this.pnlCliente.Controls.Add(this.label5);
            this.pnlCliente.Controls.Add(this.txtDniCliente);
            this.pnlCliente.Controls.Add(this.btnSeleccionarCliente);

            // 
            // pnlProducto (tarjeta producto)
            // 
            this.pnlProducto.BackColor = Color.White;
            this.pnlProducto.BorderStyle = BorderStyle.FixedSingle;
            this.pnlProducto.Location = new Point(400, 90);
            this.pnlProducto.Name = "pnlProducto";
            this.pnlProducto.Size = new Size(776, 150);
            this.pnlProducto.TabIndex = 94;

            // 
            // lblProductoCaption
            // 
            this.lblProductoCaption.AutoSize = true;
            this.lblProductoCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblProductoCaption.ForeColor = azulAccento;
            this.lblProductoCaption.Location = new Point(18, 12);
            this.lblProductoCaption.Name = "lblProductoCaption";
            this.lblProductoCaption.Text = "PRODUCTO";

            // 
            // label1 (Producto:)
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.label1.ForeColor = grisTexto;
            this.label1.Location = new Point(18, 44);
            this.label1.Name = "label1";
            this.label1.Text = "Producto:";

            // 
            // txtProducto
            // 
            this.txtProducto.BackColor = Color.FromArgb(248, 249, 251);
            this.txtProducto.BorderStyle = BorderStyle.FixedSingle;
            this.txtProducto.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            this.txtProducto.Location = new Point(115, 38);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new Size(300, 38);
            this.txtProducto.TabIndex = 2;

            // 
            // btnSeleccionarProducto
            // 
            this.btnSeleccionarProducto.BackColor = azulAccento;
            this.btnSeleccionarProducto.Cursor = Cursors.Hand;
            this.btnSeleccionarProducto.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarProducto.FlatStyle = FlatStyle.Flat;
            this.btnSeleccionarProducto.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnSeleccionarProducto.ForeColor = Color.White;
            this.btnSeleccionarProducto.Location = new Point(430, 36);
            this.btnSeleccionarProducto.Name = "btnSeleccionarProducto";
            this.btnSeleccionarProducto.Size = new Size(150, 42);
            this.btnSeleccionarProducto.TabIndex = 3;
            this.btnSeleccionarProducto.Text = "Seleccionar";
            this.btnSeleccionarProducto.UseVisualStyleBackColor = false;
            this.btnSeleccionarProducto.Click += new EventHandler(this.btnSeleccionarProducto_Click);

            // 
            // label2 (Cantidad:)
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.label2.ForeColor = grisTexto;
            this.label2.Location = new Point(18, 104);
            this.label2.Name = "label2";
            this.label2.Text = "Cantidad:";

            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = Color.FromArgb(248, 249, 251);
            this.txtCantidad.BorderStyle = BorderStyle.FixedSingle;
            this.txtCantidad.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            this.txtCantidad.Location = new Point(115, 98);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new Size(100, 38);
            this.txtCantidad.TabIndex = 4;

            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = verde;
            this.btnAgregar.Cursor = Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = FlatStyle.Flat;
            this.btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnAgregar.ForeColor = Color.White;
            this.btnAgregar.Location = new Point(456, 96);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(300, 42);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "+ Agregar al Carrito";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new EventHandler(this.btnAgregar_Click);

            this.pnlProducto.Controls.Add(this.lblProductoCaption);
            this.pnlProducto.Controls.Add(this.label1);
            this.pnlProducto.Controls.Add(this.txtProducto);
            this.pnlProducto.Controls.Add(this.btnSeleccionarProducto);
            this.pnlProducto.Controls.Add(this.label2);
            this.pnlProducto.Controls.Add(this.txtCantidad);
            this.pnlProducto.Controls.Add(this.btnAgregar);

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
            this.dgvCarrito.Size = new Size(1152, 300);
            this.dgvCarrito.TabIndex = 6;

            // 
            // pnlResumen (tarjeta de cobro, fondo celeste claro)
            // 
            this.pnlResumen.BackColor = Color.FromArgb(232, 242, 255);
            this.pnlResumen.BorderStyle = BorderStyle.FixedSingle;
            this.pnlResumen.Location = new Point(24, 580);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Size = new Size(1152, 100);
            this.pnlResumen.TabIndex = 93;

            // 
            // label4 (Efectivo recibido:)
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.label4.ForeColor = azulMarino;
            this.label4.Location = new Point(24, 32);
            this.label4.Name = "label4";
            this.label4.Text = "Efectivo recibido:";

            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = Color.White;
            this.txtEfectivo.BorderStyle = BorderStyle.FixedSingle;
            this.txtEfectivo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.txtEfectivo.Location = new Point(230, 26);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new Size(180, 46);
            this.txtEfectivo.TabIndex = 7;
            this.txtEfectivo.TextChanged += new EventHandler(this.txtEfectivo_TextChanged);

            // 
            // label3 (Total a Pagar:)
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.label3.ForeColor = Color.FromArgb(90, 100, 115);
            this.label3.Location = new Point(520, 18);
            this.label3.Name = "label3";
            this.label3.Text = "TOTAL A PAGAR";

            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTotal.ForeColor = verde;
            this.lblTotal.Location = new Point(518, 40);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "L. 0.00";

            // 
            // btnCobrar
            // 
            this.btnCobrar.BackColor = verde;
            this.btnCobrar.Cursor = Cursors.Hand;
            this.btnCobrar.FlatAppearance.BorderSize = 0;
            this.btnCobrar.FlatStyle = FlatStyle.Flat;
            this.btnCobrar.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            this.btnCobrar.ForeColor = Color.White;
            this.btnCobrar.Location = new Point(870, 24);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new Size(258, 50);
            this.btnCobrar.TabIndex = 8;
            this.btnCobrar.Text = "Finalizar Cobro";
            this.btnCobrar.UseVisualStyleBackColor = false;
            this.btnCobrar.Click += new EventHandler(this.btnCobrar_Click);

            this.pnlResumen.Controls.Add(this.label4);
            this.pnlResumen.Controls.Add(this.txtEfectivo);
            this.pnlResumen.Controls.Add(this.label3);
            this.pnlResumen.Controls.Add(this.lblTotal);
            this.pnlResumen.Controls.Add(this.btnCobrar);

            // 
            // FrmVentas
            // 
            this.BackColor = fondoPagina;
            this.ClientSize = new Size(1200, 704);
            this.Controls.Add(this.pnlAcento);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlCliente);
            this.Controls.Add(this.pnlProducto);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.pnlResumen);
            this.Name = "FrmVentas";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Módulo de Ventas";
            this.Load += new EventHandler(this.FrmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);
        }

        private Button btnSeleccionarProducto;
        private TextBox txtProducto;
        private TextBox txtCantidad;
        private Button btnAgregar;
        private DataGridView dgvCarrito;
        private Label lblTotal;
        private TextBox txtEfectivo;
        private Button btnCobrar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel pnlAcento;
        private Button btnSeleccionarCliente;
        private TextBox txtDniCliente;
        private Label label5;

        private Panel pnlHeader;
        private Label lblTitulo;
        private Panel pnlCliente;
        private Label lblClienteCaption;
        private Panel pnlProducto;
        private Label lblProductoCaption;
        private Panel pnlResumen;
    }
}