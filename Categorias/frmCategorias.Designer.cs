namespace BRAMSELU
{
    partial class frmCategorias
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
            this.components = new System.ComponentModel.Container();
            this.lblcategorias = new System.Windows.Forms.Label();
            this.progressBarcategorias = new System.Windows.Forms.ProgressBar();
            this.txtidcategoria = new System.Windows.Forms.MaskedTextBox();
            this.lblidcategoria = new System.Windows.Forms.Label();
            this.labeldescripcion = new System.Windows.Forms.Label();
            this.txtnombrecategoria = new System.Windows.Forms.TextBox();
            this.labelnombrecategoria = new System.Windows.Forms.Label();
            this.lbldatoscategoria = new System.Windows.Forms.Label();
            this.btnbuscarcategoria = new System.Windows.Forms.Button();
            this.txtBuscarcategoria = new System.Windows.Forms.TextBox();
            this.btnguardarcategoria = new System.Windows.Forms.Button();
            this.bttneliminarcategoria = new System.Windows.Forms.Button();
            this.bttneditarcategoria = new System.Windows.Forms.Button();
            this.Btnnuevocategoria = new System.Windows.Forms.Button();
            this.dataGridViewcategoria = new System.Windows.Forms.DataGridView();
            this.labelbuscarcategoria = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblproductoscategorias = new System.Windows.Forms.Label();
            this.dataGridViewproCategorias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewcategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewproCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // lblcategorias
            // 
            this.lblcategorias.AutoSize = true;
            this.lblcategorias.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.lblcategorias.Location = new System.Drawing.Point(67, 22);
            this.lblcategorias.Name = "lblcategorias";
            this.lblcategorias.Size = new System.Drawing.Size(325, 41);
            this.lblcategorias.TabIndex = 13;
            this.lblcategorias.Text = "Control de Categorías";
            // 
            // progressBarcategorias
            // 
            this.progressBarcategorias.Location = new System.Drawing.Point(67, 775);
            this.progressBarcategorias.Name = "progressBarcategorias";
            this.progressBarcategorias.Size = new System.Drawing.Size(129, 23);
            this.progressBarcategorias.TabIndex = 62;
            this.progressBarcategorias.Visible = false;
            this.progressBarcategorias.Click += new System.EventHandler(this.progressBarcategorias_Click);
            // 
            // txtidcategoria
            // 
            this.txtidcategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidcategoria.Location = new System.Drawing.Point(197, 443);
            this.txtidcategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtidcategoria.Name = "txtidcategoria";
            this.txtidcategoria.Size = new System.Drawing.Size(348, 34);
            this.txtidcategoria.TabIndex = 59;
            // 
            // lblidcategoria
            // 
            this.lblidcategoria.AutoSize = true;
            this.lblidcategoria.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblidcategoria.ForeColor = System.Drawing.Color.DimGray;
            this.lblidcategoria.Location = new System.Drawing.Point(67, 443);
            this.lblidcategoria.Name = "lblidcategoria";
            this.lblidcategoria.Size = new System.Drawing.Size(144, 31);
            this.lblidcategoria.TabIndex = 58;
            this.lblidcategoria.Text = "Id Categoria";
            // 
            // labeldescripcion
            // 
            this.labeldescripcion.AutoSize = true;
            this.labeldescripcion.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldescripcion.ForeColor = System.Drawing.Color.DimGray;
            this.labeldescripcion.Location = new System.Drawing.Point(643, 443);
            this.labeldescripcion.Name = "labeldescripcion";
            this.labeldescripcion.Size = new System.Drawing.Size(146, 31);
            this.labeldescripcion.TabIndex = 52;
            this.labeldescripcion.Text = "Descripcion:";
            // 
            // txtnombrecategoria
            // 
            this.txtnombrecategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnombrecategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombrecategoria.Location = new System.Drawing.Point(197, 481);
            this.txtnombrecategoria.Name = "txtnombrecategoria";
            this.txtnombrecategoria.Size = new System.Drawing.Size(348, 34);
            this.txtnombrecategoria.TabIndex = 51;
            // 
            // labelnombrecategoria
            // 
            this.labelnombrecategoria.AutoSize = true;
            this.labelnombrecategoria.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnombrecategoria.ForeColor = System.Drawing.Color.DimGray;
            this.labelnombrecategoria.Location = new System.Drawing.Point(68, 481);
            this.labelnombrecategoria.Name = "labelnombrecategoria";
            this.labelnombrecategoria.Size = new System.Drawing.Size(108, 31);
            this.labelnombrecategoria.TabIndex = 50;
            this.labelnombrecategoria.Text = "Nombre:";
            // 
            // lbldatoscategoria
            // 
            this.lbldatoscategoria.AutoSize = true;
            this.lbldatoscategoria.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatoscategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.lbldatoscategoria.Location = new System.Drawing.Point(67, 400);
            this.lbldatoscategoria.Name = "lbldatoscategoria";
            this.lbldatoscategoria.Size = new System.Drawing.Size(242, 31);
            this.lbldatoscategoria.TabIndex = 49;
            this.lbldatoscategoria.Text = "Datos de la Categoria";
            // 
            // btnbuscarcategoria
            // 
            this.btnbuscarcategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnbuscarcategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarcategoria.FlatAppearance.BorderSize = 0;
            this.btnbuscarcategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarcategoria.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscarcategoria.ForeColor = System.Drawing.Color.White;
            this.btnbuscarcategoria.Location = new System.Drawing.Point(529, 72);
            this.btnbuscarcategoria.Name = "btnbuscarcategoria";
            this.btnbuscarcategoria.Size = new System.Drawing.Size(112, 38);
            this.btnbuscarcategoria.TabIndex = 48;
            this.btnbuscarcategoria.Text = "Buscar";
            this.btnbuscarcategoria.UseVisualStyleBackColor = false;
            this.btnbuscarcategoria.Click += new System.EventHandler(this.btnbuscarcategoria_Click);
            // 
            // txtBuscarcategoria
            // 
            this.txtBuscarcategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarcategoria.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarcategoria.Location = new System.Drawing.Point(165, 72);
            this.txtBuscarcategoria.Name = "txtBuscarcategoria";
            this.txtBuscarcategoria.Size = new System.Drawing.Size(340, 38);
            this.txtBuscarcategoria.TabIndex = 47;
            this.txtBuscarcategoria.TextChanged += new System.EventHandler(this.txtBuscarcategoria_TextChanged);
            // 
            // btnguardarcategoria
            // 
            this.btnguardarcategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(193)))), ((int)(((byte)(91)))));
            this.btnguardarcategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnguardarcategoria.FlatAppearance.BorderSize = 0;
            this.btnguardarcategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardarcategoria.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardarcategoria.ForeColor = System.Drawing.Color.White;
            this.btnguardarcategoria.Location = new System.Drawing.Point(1001, 72);
            this.btnguardarcategoria.Name = "btnguardarcategoria";
            this.btnguardarcategoria.Size = new System.Drawing.Size(112, 38);
            this.btnguardarcategoria.TabIndex = 46;
            this.btnguardarcategoria.Text = "Guardar";
            this.btnguardarcategoria.UseVisualStyleBackColor = false;
            this.btnguardarcategoria.Click += new System.EventHandler(this.btnguardarcategoria_Click);
            // 
            // bttneliminarcategoria
            // 
            this.bttneliminarcategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(83)))), ((int)(((byte)(112)))));
            this.bttneliminarcategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttneliminarcategoria.FlatAppearance.BorderSize = 0;
            this.bttneliminarcategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttneliminarcategoria.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttneliminarcategoria.ForeColor = System.Drawing.Color.White;
            this.bttneliminarcategoria.Location = new System.Drawing.Point(883, 72);
            this.bttneliminarcategoria.Name = "bttneliminarcategoria";
            this.bttneliminarcategoria.Size = new System.Drawing.Size(112, 38);
            this.bttneliminarcategoria.TabIndex = 45;
            this.bttneliminarcategoria.Text = "Eliminar";
            this.bttneliminarcategoria.UseVisualStyleBackColor = false;
            this.bttneliminarcategoria.Click += new System.EventHandler(this.bttneliminarcategoria_Click);
            // 
            // bttneditarcategoria
            // 
            this.bttneditarcategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(110)))), ((int)(((byte)(75)))));
            this.bttneditarcategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttneditarcategoria.FlatAppearance.BorderSize = 0;
            this.bttneditarcategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttneditarcategoria.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttneditarcategoria.ForeColor = System.Drawing.Color.White;
            this.bttneditarcategoria.Location = new System.Drawing.Point(765, 72);
            this.bttneditarcategoria.Name = "bttneditarcategoria";
            this.bttneditarcategoria.Size = new System.Drawing.Size(112, 38);
            this.bttneditarcategoria.TabIndex = 44;
            this.bttneditarcategoria.Text = "Editar";
            this.bttneditarcategoria.UseVisualStyleBackColor = false;
            this.bttneditarcategoria.Click += new System.EventHandler(this.bttneditarcategoria_Click);
            // 
            // Btnnuevocategoria
            // 
            this.Btnnuevocategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(182)))), ((int)(((byte)(77)))));
            this.Btnnuevocategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btnnuevocategoria.FlatAppearance.BorderSize = 0;
            this.Btnnuevocategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btnnuevocategoria.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnnuevocategoria.ForeColor = System.Drawing.Color.White;
            this.Btnnuevocategoria.Location = new System.Drawing.Point(647, 72);
            this.Btnnuevocategoria.Name = "Btnnuevocategoria";
            this.Btnnuevocategoria.Size = new System.Drawing.Size(112, 38);
            this.Btnnuevocategoria.TabIndex = 43;
            this.Btnnuevocategoria.Text = "Nuevo";
            this.Btnnuevocategoria.UseVisualStyleBackColor = false;
            this.Btnnuevocategoria.Click += new System.EventHandler(this.Btnnuevocategoria_Click);
            // 
            // dataGridViewcategoria
            // 
            this.dataGridViewcategoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewcategoria.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewcategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewcategoria.Location = new System.Drawing.Point(67, 125);
            this.dataGridViewcategoria.MultiSelect = false;
            this.dataGridViewcategoria.Name = "dataGridViewcategoria";
            this.dataGridViewcategoria.RowHeadersVisible = false;
            this.dataGridViewcategoria.RowHeadersWidth = 51;
            this.dataGridViewcategoria.RowTemplate.Height = 24;
            this.dataGridViewcategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewcategoria.ShowEditingIcon = false;
            this.dataGridViewcategoria.Size = new System.Drawing.Size(1045, 250);
            this.dataGridViewcategoria.TabIndex = 42;
            this.dataGridViewcategoria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewcategoria_CellClick);
            // 
            // labelbuscarcategoria
            // 
            this.labelbuscarcategoria.AutoSize = true;
            this.labelbuscarcategoria.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelbuscarcategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(75)))), ((int)(((byte)(65)))));
            this.labelbuscarcategoria.Location = new System.Drawing.Point(67, 72);
            this.labelbuscarcategoria.Name = "labelbuscarcategoria";
            this.labelbuscarcategoria.Size = new System.Drawing.Size(92, 31);
            this.labelbuscarcategoria.TabIndex = 41;
            this.labelbuscarcategoria.Text = "Buscar:";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescripcion.Location = new System.Drawing.Point(765, 443);
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(348, 78);
            this.txtdescripcion.TabIndex = 63;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblproductoscategorias
            // 
            this.lblproductoscategorias.AutoSize = true;
            this.lblproductoscategorias.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblproductoscategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
            this.lblproductoscategorias.Location = new System.Drawing.Point(68, 534);
            this.lblproductoscategorias.Name = "lblproductoscategorias";
            this.lblproductoscategorias.Size = new System.Drawing.Size(316, 31);
            this.lblproductoscategorias.TabIndex = 64;
            this.lblproductoscategorias.Text = "Productos De Esta Categoria";
            this.lblproductoscategorias.Click += new System.EventHandler(this.lblproductoscategorias_Click);
            // 
            // dataGridViewproCategorias
            // 
            this.dataGridViewproCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewproCategorias.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewproCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewproCategorias.Location = new System.Drawing.Point(67, 568);
            this.dataGridViewproCategorias.MultiSelect = false;
            this.dataGridViewproCategorias.Name = "dataGridViewproCategorias";
            this.dataGridViewproCategorias.RowHeadersVisible = false;
            this.dataGridViewproCategorias.RowHeadersWidth = 51;
            this.dataGridViewproCategorias.RowTemplate.Height = 24;
            this.dataGridViewproCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewproCategorias.Size = new System.Drawing.Size(1046, 146);
            this.dataGridViewproCategorias.TabIndex = 65;
            this.dataGridViewproCategorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewproCategorias_CellContentClick);
            // 
            // frmCategorias
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1182, 720);
            this.Controls.Add(this.dataGridViewproCategorias);
            this.Controls.Add(this.lblproductoscategorias);
            this.Controls.Add(this.txtdescripcion);
            this.Controls.Add(this.progressBarcategorias);
            this.Controls.Add(this.txtidcategoria);
            this.Controls.Add(this.lblidcategoria);
            this.Controls.Add(this.labeldescripcion);
            this.Controls.Add(this.txtnombrecategoria);
            this.Controls.Add(this.labelnombrecategoria);
            this.Controls.Add(this.lbldatoscategoria);
            this.Controls.Add(this.btnbuscarcategoria);
            this.Controls.Add(this.txtBuscarcategoria);
            this.Controls.Add(this.btnguardarcategoria);
            this.Controls.Add(this.bttneliminarcategoria);
            this.Controls.Add(this.bttneditarcategoria);
            this.Controls.Add(this.Btnnuevocategoria);
            this.Controls.Add(this.dataGridViewcategoria);
            this.Controls.Add(this.labelbuscarcategoria);
            this.Controls.Add(this.lblcategorias);
            this.Name = "frmCategorias";
            this.Text = "frmCategorias";
            this.Load += new System.EventHandler(this.frmCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewcategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewproCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcategorias;
        private System.Windows.Forms.ProgressBar progressBarcategorias;
        private System.Windows.Forms.MaskedTextBox txtidcategoria;
        private System.Windows.Forms.Label lblidcategoria;
        private System.Windows.Forms.Label labeldescripcion;
        private System.Windows.Forms.TextBox txtnombrecategoria;
        private System.Windows.Forms.Label labelnombrecategoria;
        private System.Windows.Forms.Label lbldatoscategoria;
        private System.Windows.Forms.Button btnbuscarcategoria;
        private System.Windows.Forms.TextBox txtBuscarcategoria;
        private System.Windows.Forms.Button btnguardarcategoria;
        private System.Windows.Forms.Button bttneliminarcategoria;
        private System.Windows.Forms.Button bttneditarcategoria;
        private System.Windows.Forms.Button Btnnuevocategoria;
        private System.Windows.Forms.DataGridView dataGridViewcategoria;
        private System.Windows.Forms.Label labelbuscarcategoria;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblproductoscategorias;
        private System.Windows.Forms.DataGridView dataGridViewproCategorias;
    }
}