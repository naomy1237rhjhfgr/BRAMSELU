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
            lblMensajeconfirmacion.AutoSize = true;
            lblMensajeconfirmacion.MaximumSize = new Size(700, 0);
            lblMensajeconfirmacion.TextAlign = ContentAlignment.MiddleCenter;
            lblMensajeconfirmacion.Text = mensaje;
            pictureBox2.Image = Properties.Resources.pregunta;

            lblMensajeconfirmacion.Left = (this.ClientSize.Width - lblMensajeconfirmacion.Width) / 2;

            AjustarLayoutConfirmacion();
        }

        private void bttnAceptarconfirmacion_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        private void AjustarLayoutConfirmacion()
        {
            const int margen = 20;
            const int espacio = 15;

            Size texto = TextRenderer.MeasureText(
                lblMensajeconfirmacion.Text,
                lblMensajeconfirmacion.Font,
                new Size(300, int.MaxValue),
                TextFormatFlags.WordBreak);

            lblMensajeconfirmacion.Size = texto;

            int anchoContenido = pictureBox2.Width + espacio + lblMensajeconfirmacion.Width;
            int inicioX = (ClientSize.Width - anchoContenido) / 2;

            pictureBox2.Left = inicioX;
            lblMensajeconfirmacion.Left = pictureBox2.Right + espacio;

            int altoContenido = Math.Max(pictureBox2.Height, lblMensajeconfirmacion.Height);

            pictureBox2.Top = margen;
            lblMensajeconfirmacion.Top = margen + (altoContenido - lblMensajeconfirmacion.Height) / 2;

            int espacioBotones = 10;

            int anchoBotones = bttnAceptarconfirmacion.Width +
                               espacioBotones +
                               bttncancelarconfirmacion.Width;

            int inicioBotones = (ClientSize.Width - anchoBotones) / 2;

            bttnAceptarconfirmacion.Left = inicioBotones;
            bttncancelarconfirmacion.Left = bttnAceptarconfirmacion.Right + espacioBotones;

            bttnAceptarconfirmacion.Top = Math.Max(pictureBox2.Bottom, lblMensajeconfirmacion.Bottom) + 25;
            bttncancelarconfirmacion.Top = bttnAceptarconfirmacion.Top;

            ClientSize = new Size(
                ClientSize.Width,
                bttnAceptarconfirmacion.Bottom + margen);
        }

        private void bttncancelarconfirmacion_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
