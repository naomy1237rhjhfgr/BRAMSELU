using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRAMSELU.Servicios;
using BRAMSELU.Mensajes;

namespace BRAMSELU
{
    public partial class frmServicios : Form
    {
        private ServicioBLL servicioBLL = new ServicioBLL();
        private int idservicios = 0;
        private bool editando = false;
        public frmServicios()
        {
            InitializeComponent();
        }
    }
}
