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
    public partial class FrmConfirmacion : Form
    {
        public FrmConfirmacion(string mensaje)
        {
            InitializeComponent();
            lblMensajeconfirmacion.Text = mensaje;
            pictureBox2.Image = Properties.Resources.pregunta;
        }

        private void bttnAceptarconfirmacion_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void bttncancelarconfirmacion_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
