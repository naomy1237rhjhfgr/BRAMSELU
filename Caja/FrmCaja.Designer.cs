namespace BRAMSELU.Caja
{
    partial class FrmCaja
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
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblInfoCaja = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAbrirCaja = new System.Windows.Forms.Button();
            this.txtMontoInicial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.txtMontoFinal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvVentasDelDia = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvComprasDelDia = new System.Windows.Forms.DataGridView();
            this.labelCompras = new System.Windows.Forms.Label();
            this.panelResumen = new System.Windows.Forms.Panel();
            this.lblEfectivoEsperado = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalCompras = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalVentas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasDelDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasDelDia)).BeginInit();
            this.panelResumen.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(20, 15);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(760, 30);
            this.lblEstado.TabIndex = 0;
            this.lblEstado.Text = "Estado: CAJA CERRADA";
            this.lblEstado.Click += new System.EventHandler(this.lblEstado_Click);

            // 
            // lblInfoCaja
            // 
            this.lblInfoCaja.AutoSize = true;
            this.lblInfoCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoCaja.Location = new System.Drawing.Point(20, 45);
            this.lblInfoCaja.Name = "lblInfoCaja";
            this.lblInfoCaja.Size = new System.Drawing.Size(287, 20);
            this.lblInfoCaja.TabIndex = 1;
            this.lblInfoCaja.Text = "Debe abrir caja para operar el sistema.";

            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAbrirCaja);
            this.groupBox1.Controls.Add(this.txtMontoInicial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Apertura de Caja (Skincare)";

            // 
            // btnAbrirCaja
            // 
            this.btnAbrirCaja.BackColor = System.Drawing.Color.Green;
            this.btnAbrirCaja.ForeColor = System.Drawing.Color.White;
            this.btnAbrirCaja.Location = new System.Drawing.Point(575, 35);
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(155, 35);
            this.btnAbrirCaja.TabIndex = 2;
            this.btnAbrirCaja.Text = "Abrir Caja";
            this.btnAbrirCaja.UseVisualStyleBackColor = false;
            this.btnAbrirCaja.Click += new System.EventHandler(this.btnAbrirCaja_Click);

            // 
            // txtMontoInicial
            // 
            this.txtMontoInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoInicial.Location = new System.Drawing.Point(230, 38);
            this.txtMontoInicial.Name = "txtMontoInicial";
            this.txtMontoInicial.Size = new System.Drawing.Size(320, 28);
            this.txtMontoInicial.TabIndex = 1;
            this.txtMontoInicial.TextChanged += new System.EventHandler(this.txtMontoInicial_TextChanged);

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto Inicial (Base):";

            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Transacciones del Día (Ventas):";

            // 
            // dgvVentasDelDia
            // 
            this.dgvVentasDelDia.AllowUserToAddRows = false;
            this.dgvVentasDelDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentasDelDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentasDelDia.Location = new System.Drawing.Point(20, 210);
            this.dgvVentasDelDia.Name = "dgvVentasDelDia";
            this.dgvVentasDelDia.RowHeadersWidth = 51;
            this.dgvVentasDelDia.RowTemplate.Height = 24;
            this.dgvVentasDelDia.Size = new System.Drawing.Size(760, 140);
            this.dgvVentasDelDia.TabIndex = 4;

            // 
            // labelCompras
            // 
            this.labelCompras.AutoSize = true;
            this.labelCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompras.Location = new System.Drawing.Point(20, 360);
            this.labelCompras.Name = "labelCompras";
            this.labelCompras.Size = new System.Drawing.Size(250, 20);
            this.labelCompras.TabIndex = 7;
            this.labelCompras.Text = "Transacciones del Día (Compras):";

            // 
            // dgvComprasDelDia
            // 
            this.dgvComprasDelDia.AllowUserToAddRows = false;
            this.dgvComprasDelDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComprasDelDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComprasDelDia.Location = new System.Drawing.Point(20, 385);
            this.dgvComprasDelDia.Name = "dgvComprasDelDia";
            this.dgvComprasDelDia.RowHeadersWidth = 51;
            this.dgvComprasDelDia.RowTemplate.Height = 24;
            this.dgvComprasDelDia.Size = new System.Drawing.Size(760, 140);
            this.dgvComprasDelDia.TabIndex = 8;

            // 
            // panelResumen
            // 
            this.panelResumen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResumen.Controls.Add(this.lblEfectivoEsperado);
            this.panelResumen.Controls.Add(this.label7);
            this.panelResumen.Controls.Add(this.lblTotalCompras);
            this.panelResumen.Controls.Add(this.label5);
            this.panelResumen.Controls.Add(this.lblTotalVentas);
            this.panelResumen.Controls.Add(this.label4);
            this.panelResumen.Location = new System.Drawing.Point(20, 535);
            this.panelResumen.Name = "panelResumen";
            this.panelResumen.Size = new System.Drawing.Size(760, 150);
            this.panelResumen.TabIndex = 6;

            // 
            // lblEfectivoEsperado
            // 
            this.lblEfectivoEsperado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEfectivoEsperado.ForeColor = System.Drawing.Color.Navy;
            this.lblEfectivoEsperado.Location = new System.Drawing.Point(500, 105);
            this.lblEfectivoEsperado.Name = "lblEfectivoEsperado";
            this.lblEfectivoEsperado.Size = new System.Drawing.Size(230, 25);
            this.lblEfectivoEsperado.TabIndex = 5;
            this.lblEfectivoEsperado.Text = "L. 0.00";
            this.lblEfectivoEsperado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(256, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Efectivo Esperado en Caja:";

            // 
            // lblTotalCompras
            // 
            this.lblTotalCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCompras.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTotalCompras.Location = new System.Drawing.Point(500, 60);
            this.lblTotalCompras.Name = "lblTotalCompras";
            this.lblTotalCompras.Size = new System.Drawing.Size(230, 25);
            this.lblTotalCompras.TabIndex = 3;
            this.lblTotalCompras.Text = "L. 0.00";
            this.lblTotalCompras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Total de Compras Turno (-):";

            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVentas.ForeColor = System.Drawing.Color.Green;
            this.lblTotalVentas.Location = new System.Drawing.Point(500, 15);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(230, 25);
            this.lblTotalVentas.TabIndex = 1;
            this.lblTotalVentas.Text = "L. 0.00";
            this.lblTotalVentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total de Ventas Turno (+):";

            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCerrarCaja);
            this.groupBox2.Controls.Add(this.txtMontoFinal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(20, 700);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 90);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cierre de Caja";

            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.BackColor = System.Drawing.Color.Firebrick;
            this.btnCerrarCaja.ForeColor = System.Drawing.Color.White;
            this.btnCerrarCaja.Location = new System.Drawing.Point(575, 35);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(155, 35);
            this.btnCerrarCaja.TabIndex = 2;
            this.btnCerrarCaja.Text = "Cerrar Caja";
            this.btnCerrarCaja.UseVisualStyleBackColor = false;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);

            // 
            // txtMontoFinal
            // 
            this.txtMontoFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoFinal.Location = new System.Drawing.Point(230, 38);
            this.txtMontoFinal.Name = "txtMontoFinal";
            this.txtMontoFinal.Size = new System.Drawing.Size(320, 28);
            this.txtMontoFinal.TabIndex = 1;
            this.txtMontoFinal.TextChanged += new System.EventHandler(this.txtMontoFinal_TextChanged);

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Efectivo Contado Físico:";

            // 
            // FrmCaja
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 810);
            this.Controls.Add(this.dgvComprasDelDia);
            this.Controls.Add(this.labelCompras);
            this.Controls.Add(this.panelResumen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvVentasDelDia);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblInfoCaja);
            this.Controls.Add(this.lblEstado);
            this.Name = "FrmCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de Caja y Turnos - Skincare";
            this.Load += new System.EventHandler(this.FrmCaja_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasDelDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasDelDia)).EndInit();
            this.panelResumen.ResumeLayout(false);
            this.panelResumen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblInfoCaja;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAbrirCaja;
        private System.Windows.Forms.TextBox txtMontoInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCerrarCaja;
        private System.Windows.Forms.TextBox txtMontoFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvVentasDelDia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvComprasDelDia;
        private System.Windows.Forms.Label labelCompras;
        private System.Windows.Forms.Panel panelResumen;
        private System.Windows.Forms.Label lblTotalVentas;
        private System.Windows.Forms.Label lblTotalCompras;
        private System.Windows.Forms.Label lblEfectivoEsperado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}