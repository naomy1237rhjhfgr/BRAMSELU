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
            this.btnventa = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pnlContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnventa
            // 
            this.btnventa.Location = new System.Drawing.Point(506, 275);
            this.btnventa.Name = "btnventa";
            this.btnventa.Size = new System.Drawing.Size(147, 140);
            this.btnventa.TabIndex = 0;
            this.btnventa.Text = "ventas";
            this.btnventa.UseVisualStyleBackColor = true;
            this.btnventa.Click += new System.EventHandler(this.btnventa_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 293);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 140);
            this.button2.TabIndex = 1;
            this.button2.Text = "compras";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Controls.Add(this.button3);
            this.pnlContenedor.Controls.Add(this.button1);
            this.pnlContenedor.Controls.Add(this.btnventa);
            this.pnlContenedor.Controls.Add(this.button2);
            this.pnlContenedor.Location = new System.Drawing.Point(37, 32);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1323, 537);
            this.pnlContenedor.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(321, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 140);
            this.button1.TabIndex = 2;
            this.button1.Text = "stock";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(529, 112);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 140);
            this.button3.TabIndex = 3;
            this.button3.Text = "caja";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 581);
            this.Controls.Add(this.pnlContenedor);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.pnlContenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnventa;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}