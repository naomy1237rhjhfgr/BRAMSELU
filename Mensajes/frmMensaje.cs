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
        public frmMensaje(string mensaje, TipoMensaje tipo)
        {
            InitializeComponent();

            lblMensaje.MaximumSize = new Size(300, 0);
            lblMensaje.AutoSize = true;
            lblMensaje.TextAlign = ContentAlignment.MiddleCenter;
            lblMensaje.Text = mensaje;

            AjustarAnchoMensaje();
            AjustarLayout();

            switch (tipo)
            {
                case TipoMensaje.Exito:
                    this.Text = "Éxito";
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
                    this.Text = "Información";
                    pictureBox1.Image = Properties.Resources.informacion;
                    break;
            }

            lblMensaje.Refresh();

            AjustarLayout();
        }

        public void MostrarMensaje(string mensaje, TipoMensaje tipo)
        {
            lblMensaje.Text = mensaje;
            CentrarControles();
            AjustarAnchoMensaje();
            AjustarLayout();
        }
        private void AjustarLayout()
        {
            const int margen = 20;
            const int espacio = 15;

            // Calcula el tamaño que necesita el texto
            Size texto = TextRenderer.MeasureText(
                lblMensaje.Text,
                lblMensaje.Font,
                new Size(300, int.MaxValue),
                TextFormatFlags.WordBreak);

            lblMensaje.Size = texto;

            // Centrar icono y texto
            int anchoContenido = pictureBox1.Width + espacio + lblMensaje.Width;
            int inicioX = (ClientSize.Width - anchoContenido) / 2;

            pictureBox1.Left = inicioX;
            lblMensaje.Left = pictureBox1.Right + espacio;

            int altoContenido = Math.Max(pictureBox1.Height, lblMensaje.Height);

            pictureBox1.Top = margen;
            lblMensaje.Top = margen + (altoContenido - lblMensaje.Height) / 2;

            // Botón
            // Obtener la parte más baja entre el icono y el mensaje
            int parteInferior = panelsuperior.Bottom;

            // Colocar el botón debajo del panel
            bttnAceptar.Top = parteInferior + 50;

            // Centrar el botón
            bttnAceptar.Left = (ClientSize.Width - bttnAceptar.Width) / 2;

            // Ajustar la altura del formulario
            ClientSize = new Size(
                ClientSize.Width,
                bttnAceptar.Bottom + margen);
        }

        private void bttnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CentrarControles()
        {
            lblMensaje.Left = (this.ClientSize.Width - lblMensaje.Width) / 2;
            bttnAceptar.Left = (this.ClientSize.Width - bttnAceptar.Width) / 2;
        }
        private void AjustarAnchoMensaje()
        {
            int anchoMinimo = 300;
            int anchoMaximo = 600;

            // Calcula el ancho que ocuparía el texto en una sola línea
            Size texto = TextRenderer.MeasureText(
                lblMensaje.Text,
                lblMensaje.Font);

            // Agrega un pequeño margen
            int anchoNecesario = texto.Width + 20;

            // Limita el ancho entre el mínimo y el máximo
            anchoNecesario = Math.Max(anchoMinimo, Math.Min(anchoNecesario, anchoMaximo));

            lblMensaje.MaximumSize = new Size(anchoNecesario, 0);

            // Recalcula el tamaño del Label con el nuevo ancho
            Size nuevoTamano = TextRenderer.MeasureText(
                lblMensaje.Text,
                lblMensaje.Font,
                new Size(anchoNecesario, int.MaxValue),
                TextFormatFlags.WordBreak);

            lblMensaje.Size = nuevoTamano;

            // Ajusta el ancho del formulario
            int anchoFormulario = pictureBox1.Width + lblMensaje.Width + 80;

            this.ClientSize = new Size(
                Math.Max(420, Math.Min(anchoFormulario, 700)),
                this.ClientSize.Height);
        }
    }
}
