using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();

            nmrUpDown1.Maximum = 7;

            nmrUpDown1.Minimum = 2;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public byte GetNmrDec() => (byte)nmrUpDown1.Value;
    }
}