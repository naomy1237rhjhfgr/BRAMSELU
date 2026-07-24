namespace BRAMSELU.Mensajes
{
    partial class FrmConfirmacion
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
            this.lblMensajeconfirmacion = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelsuperiorconfirmacion = new System.Windows.Forms.Panel();
            this.bttnAceptarconfirmacion = new System.Windows.Forms.Button();
            this.bttncancelarconfirmacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelsuperiorconfirmacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMensajeconfirmacion
            // 
            this.lblMensajeconfirmacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeconfirmacion.Location = new System.Drawing.Point(76, 21);
            this.lblMensajeconfirmacion.Name = "lblMensajeconfirmacion";
            this.lblMensajeconfirmacion.Size = new System.Drawing.Size(328, 28);
            this.lblMensajeconfirmacion.TabIndex = 0;
            this.lblMensajeconfirmacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(22, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // panelsuperiorconfirmacion
            // 
            this.panelsuperiorconfirmacion.Controls.Add(this.pictureBox2);
            this.panelsuperiorconfirmacion.Controls.Add(this.lblMensajeconfirmacion);
            this.panelsuperiorconfirmacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelsuperiorconfirmacion.Location = new System.Drawing.Point(0, 0);
            this.panelsuperiorconfirmacion.Name = "panelsuperiorconfirmacion";
            this.panelsuperiorconfirmacion.Size = new System.Drawing.Size(462, 75);
            this.panelsuperiorconfirmacion.TabIndex = 48;
            // 
            // bttnAceptarconfirmacion
            // 
            this.bttnAceptarconfirmacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(150)))), ((int)(((byte)(110)))));
            this.bttnAceptarconfirmacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnAceptarconfirmacion.FlatAppearance.BorderSize = 0;
            this.bttnAceptarconfirmacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnAceptarconfirmacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bttnAceptarconfirmacion.ForeColor = System.Drawing.Color.Transparent;
            this.bttnAceptarconfirmacion.Location = new System.Drawing.Point(245, 89);
            this.bttnAceptarconfirmacion.Name = "bttnAceptarconfirmacion";
            this.bttnAceptarconfirmacion.Size = new System.Drawing.Size(100, 32);
            this.bttnAceptarconfirmacion.TabIndex = 49;
            this.bttnAceptarconfirmacion.Text = "Aceptar";
            this.bttnAceptarconfirmacion.UseVisualStyleBackColor = false;
            this.bttnAceptarconfirmacion.Click += new System.EventHandler(this.bttnAceptarconfirmacion_Click);
            // 
            // bttncancelarconfirmacion
            // 
            this.bttncancelarconfirmacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(90)))), ((int)(((byte)(80)))));
            this.bttncancelarconfirmacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttncancelarconfirmacion.FlatAppearance.BorderSize = 0;
            this.bttncancelarconfirmacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttncancelarconfirmacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bttncancelarconfirmacion.ForeColor = System.Drawing.Color.White;
            this.bttncancelarconfirmacion.Location = new System.Drawing.Point(101, 89);
            this.bttncancelarconfirmacion.Name = "bttncancelarconfirmacion";
            this.bttncancelarconfirmacion.Size = new System.Drawing.Size(100, 32);
            this.bttncancelarconfirmacion.TabIndex = 50;
            this.bttncancelarconfirmacion.Text = "Cancelar";
            this.bttncancelarconfirmacion.UseVisualStyleBackColor = false;
            this.bttncancelarconfirmacion.Click += new System.EventHandler(this.bttncancelarconfirmacion_Click);
            // 
            // FrmConfirmacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 133);
            this.Controls.Add(this.bttncancelarconfirmacion);
            this.Controls.Add(this.bttnAceptarconfirmacion);
            this.Controls.Add(this.panelsuperiorconfirmacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfirmacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConfirmacion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelsuperiorconfirmacion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMensajeconfirmacion;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelsuperiorconfirmacion;
        private System.Windows.Forms.Button bttnAceptarconfirmacion;
        private System.Windows.Forms.Button bttncancelarconfirmacion;
    }
}