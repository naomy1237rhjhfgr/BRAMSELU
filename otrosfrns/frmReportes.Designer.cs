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
            this.pnlContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnventa
            // 
            this.btnventa.Location = new System.Drawing.Point(506, 275);
            this.btnventa.Name = "btnventa";
            this.btnventa.Size = new System.Drawing.Size(147, 140);
            this.btnventa.TabIndex = 0;
            this.btnventa.Text = "button1";
            this.btnventa.UseVisualStyleBackColor = true;
            this.btnventa.Click += new System.EventHandler(this.btnventa_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 293);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 140);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Controls.Add(this.btnventa);
            this.pnlContenedor.Controls.Add(this.button2);
            this.pnlContenedor.Location = new System.Drawing.Point(37, 32);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(914, 436);
            this.pnlContenedor.TabIndex = 2;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 491);
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
    }
}