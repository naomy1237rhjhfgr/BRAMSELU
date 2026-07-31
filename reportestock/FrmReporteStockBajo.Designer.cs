namespace BRAMSELU.reportestock
{
    partial class FrmReporteStockBajo
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtStockLimite = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.lblMensajeAlerta = new System.Windows.Forms.Label();
            this.dgvStockBajo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockBajo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Límite de Stock :";
            // 
            // txtStockLimite
            // 
            this.txtStockLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockLimite.Location = new System.Drawing.Point(250, 38);
            this.txtStockLimite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStockLimite.Name = "txtStockLimite";
            this.txtStockLimite.Size = new System.Drawing.Size(186, 29);
            this.txtStockLimite.TabIndex = 1;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(465, 34);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(150, 46);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Generar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // lblMensajeAlerta
            // 
            this.lblMensajeAlerta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeAlerta.Location = new System.Drawing.Point(38, 105);
            this.lblMensajeAlerta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMensajeAlerta.Name = "lblMensajeAlerta";
            this.lblMensajeAlerta.Size = new System.Drawing.Size(1102, 35);
            this.lblMensajeAlerta.TabIndex = 3;
            this.lblMensajeAlerta.Text = "Mensaje de estado...";
            // 
            // dgvStockBajo
            // 
            this.dgvStockBajo.AllowUserToAddRows = false;
            this.dgvStockBajo.AllowUserToDeleteRows = false;
            this.dgvStockBajo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockBajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockBajo.Location = new System.Drawing.Point(38, 162);
            this.dgvStockBajo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvStockBajo.Name = "dgvStockBajo";
            this.dgvStockBajo.ReadOnly = true;
            this.dgvStockBajo.RowHeadersWidth = 62;
            this.dgvStockBajo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockBajo.Size = new System.Drawing.Size(1102, 523);
            this.dgvStockBajo.TabIndex = 4;
            // 
            // FrmReporteStockBajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 725);
            this.Controls.Add(this.dgvStockBajo);
            this.Controls.Add(this.lblMensajeAlerta);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.txtStockLimite);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmReporteStockBajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Stock Bajo - Inventario Crítico";
            this.Load += new System.EventHandler(this.FrmReporteStockBajo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockBajo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStockLimite;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label lblMensajeAlerta;
        private System.Windows.Forms.DataGridView dgvStockBajo;
    }
}