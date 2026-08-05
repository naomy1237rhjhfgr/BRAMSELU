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
            this.pnlAcento = new System.Windows.Forms.Panel();
            this.bttnAceptarconfirmacion = new System.Windows.Forms.Button();
            this.bttncancelarconfirmacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelsuperiorconfirmacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMensajeconfirmacion
            // 
            this.lblMensajeconfirmacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeconfirmacion.Location = new System.Drawing.Point(121, 22);
            this.lblMensajeconfirmacion.Name = "lblMensajeconfirmacion";
            this.lblMensajeconfirmacion.Size = new System.Drawing.Size(349, 46);
            this.lblMensajeconfirmacion.TabIndex = 0;
            this.lblMensajeconfirmacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(22, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 67);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // panelsuperiorconfirmacion
            // 
            this.panelsuperiorconfirmacion.Controls.Add(this.pnlAcento);
            this.panelsuperiorconfirmacion.Controls.Add(this.pictureBox2);
            this.panelsuperiorconfirmacion.Controls.Add(this.lblMensajeconfirmacion);
            this.panelsuperiorconfirmacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelsuperiorconfirmacion.Location = new System.Drawing.Point(0, 0);
            this.panelsuperiorconfirmacion.Name = "panelsuperiorconfirmacion";
            this.panelsuperiorconfirmacion.Size = new System.Drawing.Size(482, 93);
            this.panelsuperiorconfirmacion.TabIndex = 48;
            // 
            // pnlAcento
            // 
            this.pnlAcento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.pnlAcento.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAcento.Location = new System.Drawing.Point(0, 0);
            this.pnlAcento.Name = "pnlAcento";
            this.pnlAcento.Size = new System.Drawing.Size(482, 6);
            this.pnlAcento.TabIndex = 98;
            // 
            // bttnAceptarconfirmacion
            // 
            this.bttnAceptarconfirmacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(193)))), ((int)(((byte)(91)))));
            this.bttnAceptarconfirmacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnAceptarconfirmacion.FlatAppearance.BorderSize = 0;
            this.bttnAceptarconfirmacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnAceptarconfirmacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bttnAceptarconfirmacion.ForeColor = System.Drawing.Color.Transparent;
            this.bttnAceptarconfirmacion.Location = new System.Drawing.Point(93, 103);
            this.bttnAceptarconfirmacion.Name = "bttnAceptarconfirmacion";
            this.bttnAceptarconfirmacion.Size = new System.Drawing.Size(132, 38);
            this.bttnAceptarconfirmacion.TabIndex = 49;
            this.bttnAceptarconfirmacion.Text = "Aceptar";
            this.bttnAceptarconfirmacion.UseVisualStyleBackColor = false;
            this.bttnAceptarconfirmacion.Click += new System.EventHandler(this.bttnAceptarconfirmacion_Click);
            // 
            // bttncancelarconfirmacion
            // 
            this.bttncancelarconfirmacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(83)))), ((int)(((byte)(112)))));
            this.bttncancelarconfirmacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttncancelarconfirmacion.FlatAppearance.BorderSize = 0;
            this.bttncancelarconfirmacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttncancelarconfirmacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bttncancelarconfirmacion.ForeColor = System.Drawing.Color.White;
            this.bttncancelarconfirmacion.Location = new System.Drawing.Point(237, 103);
            this.bttncancelarconfirmacion.Name = "bttncancelarconfirmacion";
            this.bttncancelarconfirmacion.Size = new System.Drawing.Size(132, 38);
            this.bttncancelarconfirmacion.TabIndex = 50;
            this.bttncancelarconfirmacion.Text = "Cancelar";
            this.bttncancelarconfirmacion.UseVisualStyleBackColor = false;
            this.bttncancelarconfirmacion.Click += new System.EventHandler(this.bttncancelarconfirmacion_Click);
            // 
            // FrmConfirmacion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(482, 153);
            this.Controls.Add(this.bttncancelarconfirmacion);
            this.Controls.Add(this.bttnAceptarconfirmacion);
            this.Controls.Add(this.panelsuperiorconfirmacion);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
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
        private System.Windows.Forms.Panel pnlAcento;
    }
}