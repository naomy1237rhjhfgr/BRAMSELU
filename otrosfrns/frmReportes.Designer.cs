namespace BRAMSELU
{
    partial class frmReportes
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
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnventa = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pnlContenedor.SuspendLayout();
            this.SuspendLayout();

            // ---------------------------------------------------------
            // Paleta armonizada:
            //   Fondo del formulario -> celeste muy suave (marco)
            //   Panel                -> blanco (tarjeta central)
            //   Botones               -> blanco con borde azul, hover celeste
            //   Textos/titulo         -> azul marino
            // ---------------------------------------------------------
            System.Drawing.Color colorFondoForm = System.Drawing.Color.FromArgb(230, 240, 250); // celeste marco
            System.Drawing.Color colorPanel = System.Drawing.Color.White;                        // tarjeta
            System.Drawing.Color colorBorde = System.Drawing.Color.FromArgb(170, 210, 245);      // borde botones
            System.Drawing.Color colorHover = System.Drawing.Color.FromArgb(225, 240, 253);      // hover suave
            System.Drawing.Color colorTexto = System.Drawing.Color.FromArgb(25, 70, 115);        // azul marino
            System.Drawing.Color colorTitulo = System.Drawing.Color.FromArgb(20, 60, 100);        // titulo mas oscuro

            // -------- Panel contenedor (tarjeta) --------
            this.pnlContenedor.BackColor = colorPanel;
            this.pnlContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContenedor.Controls.Add(this.lblTitulo);
            this.pnlContenedor.Controls.Add(this.button4);
            this.pnlContenedor.Controls.Add(this.button3);
            this.pnlContenedor.Controls.Add(this.button1);
            this.pnlContenedor.Controls.Add(this.btnventa);
            this.pnlContenedor.Controls.Add(this.button2);
            this.pnlContenedor.Location = new System.Drawing.Point(37, 32);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1323, 537);
            this.pnlContenedor.TabIndex = 2;

            // -------- Titulo --------
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = colorTitulo;
            this.lblTitulo.Location = new System.Drawing.Point(45, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(271, 41);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Panel de Reportes";

            // -------- Stock --------
            this.button1.BackColor = colorPanel;
            this.button1.FlatAppearance.BorderColor = colorBorde;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseOverBackColor = colorHover;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = colorTexto;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(45, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 140);
            this.button1.TabIndex = 2;
            this.button1.Text = "📦 Stock";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // -------- Caja --------
            this.button3.BackColor = colorPanel;
            this.button3.FlatAppearance.BorderColor = colorBorde;
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatAppearance.MouseOverBackColor = colorHover;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = colorTexto;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(290, 110);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(220, 140);
            this.button3.TabIndex = 3;
            this.button3.Text = "💰 Caja";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);

            // -------- Compras --------
            this.button2.BackColor = colorPanel;
            this.button2.FlatAppearance.BorderColor = colorBorde;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatAppearance.MouseOverBackColor = colorHover;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = colorTexto;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(535, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(220, 140);
            this.button2.TabIndex = 1;
            this.button2.Text = "🛒 Compras";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);

            // -------- Ventas --------
            this.btnventa.BackColor = colorPanel;
            this.btnventa.FlatAppearance.BorderColor = colorBorde;
            this.btnventa.FlatAppearance.BorderSize = 2;
            this.btnventa.FlatAppearance.MouseOverBackColor = colorHover;
            this.btnventa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnventa.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnventa.ForeColor = colorTexto;
            this.btnventa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnventa.Location = new System.Drawing.Point(780, 110);
            this.btnventa.Name = "btnventa";
            this.btnventa.Size = new System.Drawing.Size(220, 140);
            this.btnventa.TabIndex = 0;
            this.btnventa.Text = "📊 Ventas";
            this.btnventa.UseVisualStyleBackColor = false;
            this.btnventa.Click += new System.EventHandler(this.btnventa_Click_1);

            // -------- Producto mas vendido --------
            this.button4.BackColor = colorPanel;
            this.button4.FlatAppearance.BorderColor = colorBorde;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatAppearance.MouseOverBackColor = colorHover;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = colorTexto;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(1025, 110);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(220, 140);
            this.button4.TabIndex = 4;
            this.button4.Text = "⭐ Producto más vendido";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);

            // -------- Formulario --------
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = colorFondoForm;
            this.ClientSize = new System.Drawing.Size(1385, 581);
            this.Controls.Add(this.pnlContenedor);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnventa;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblTitulo;
    }
}