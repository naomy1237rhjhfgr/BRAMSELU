using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRAMSELU.Mensajes
{
    public partial class frmMensaje : Form
    {
        public frmMensaje()
        {
            InitializeComponent();
        }

        public frmMensaje(string mensaje, TipoMensaje tipo)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;

            switch (tipo)
            {
                case TipoMensaje.Exito:
                    this.Text = "Exito"; 
                    pictureBox1.Image = Properties.Resources.exito;
                    break;

                case TipoMensaje.Error:
                    this.Text = "Error";
                    pictureBox1.Image = Properties.Resources.error;
                    break;

                case TipoMensaje.Advertencia:
                    this.Text = "Advertencia";
                    pictureBox1.Image = Properties.Resources.advertencia;
                    break;

                case TipoMensaje.Informacion:
                    this.Text = "Informacion";
                    pictureBox1.Image = Properties.Resources.informacion;
                    break;
                    
            }
        }

        public void MostrarMensaje(string mensaje, TipoMensaje tipo)
        {
            lblMensaje.Text = mensaje;
        }

        private void bttnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
