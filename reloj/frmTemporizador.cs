using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Proyecto_Reloj
{
    public partial class frmTemporizador : Form
    {
        private Timer updTextBoxesTimer = new Timer(1000);
        private TimeSpan temp = new TimeSpan();
        private delegate void updTextBoxesDel();
        private int hora = 0;
        private int min = 0;
        private int seg = 0;
        private bool btnEmpParState = true;

        public frmTemporizador()
        {
            InitializeComponent();

            btnEmpRea.Enabled = false;
            btnCancelar.Enabled = false;

            txtHora.Text = "00";
            txtMinuto.Text = "00";
            txtSegundo.Text = "00";

            updTextBoxesTimer.AutoReset = true;
            updTextBoxesTimer.Elapsed += new ElapsedEventHandler(updTextBoxes);
        }

        private void btnSubHora_Click(object sender, EventArgs e)
        {
            changeTxtValue(hora, txtHora, true);
        }

        private void btnBajHora_Click(object sender, EventArgs e)
        {
            changeTxtValue(hora, txtHora, false);
        }

        private void btnSubMin_Click(object sender, EventArgs e)
        {
            changeTxtValue(min, txtMinuto, true);
        }

        private void btnBajMin_Click(object sender, EventArgs e)
        {
            changeTxtValue(min, txtMinuto, false);
        }

        private void btnSubSeg_Click(object sender, EventArgs e)
        {
            changeTxtValue(seg, txtSegundo, true);
        }

        private void btnBajSeg_Click(object sender, EventArgs e)
        {
            changeTxtValue(seg, txtSegundo, false);
        }

        private void btnEmpRea_Click(object sender, EventArgs e)
        {
            if (btnEmpParState)
            {
                var temp2 = new TimeSpan(Convert.ToInt16(txtHora.Text), Convert.ToInt16(txtMinuto.Text), Convert.ToInt16(txtSegundo.Text));

                temp = temp2;

                updTextBoxesTimer.Start();

                btnEmpRea.Text = "Parar";

                btnEmpParState = false;
                btnCancelar.Enabled = true;

                desTodasLasFlechas();
            }

            else
            {
                btnEmpRea.Text = "Reanudar";

                updTextBoxesTimer.Stop();
                System.Diagnostics.Debug.WriteLine("Evento pausado.");

                btnEmpParState = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEmpRea.Text = "Empezar";
            btnEmpParState = true;

            btnCancelar.Enabled = false;
            btnEmpRea.Enabled = false;

            hora = 0;
            min = 0;
            seg = 0;

            txtHora.Text = string.Format("{0:00}", hora);
            txtMinuto.Text = string.Format("{0:00}", min);
            txtSegundo.Text = string.Format("{0:00}", seg);

            updTextBoxesTimer.Stop();
            System.Diagnostics.Debug.WriteLine("Evento terminado por restablecimiento.");

            habTodasLasFlechas();
        }

        private void changeTxtValue(int cntName, TextBox txtName, bool upOrDown)
        {
            if (upOrDown && cntName < 59)
            {
                if (txtName.Name == "txtHora")
                    cntName = ++hora;

                else if (txtName.Name == "txtMinuto")
                    cntName = ++min;

                else if (txtName.Name == "txtSegundo")
                    cntName = ++seg;

                else
                    throw new ArgumentException("El argumento \"txtName\" no contiene un nombre válido.");

                txtName.Text = string.Format("{0:00}", cntName);
            }

            else if (!upOrDown && cntName > 0)
            {
                if (txtName.Name == "txtHora")
                    cntName = --hora;

                else if (txtName.Name == "txtMinuto")
                    cntName = --min;

                else if (txtName.Name == "txtSegundo")
                    cntName = --seg;

                else
                    throw new ArgumentException("El argumento \"txtName\" no contiene un nombre válido.");

                txtName.Text = string.Format("{0:00}", cntName);
            }

            else if (upOrDown && cntName == 59)
            {
                if (txtName.Name == "txtHora")
                {
                    cntName = 0;
                    hora = 0;
                }                    

                else if (txtName.Name == "txtMinuto")
                {
                    cntName = 0;
                    min = 0;
                }                    

                else if (txtName.Name == "txtSegundo")
                {
                    cntName = 0;
                    seg = 0;
                }                    

                else
                    throw new ArgumentException("El argumento \"txtName\" no contiene un nombre válido.");

                txtName.Text = string.Format("{0:00}", cntName);
            }

            else if (!upOrDown && cntName == 0)
            {
                if (txtName.Name == "txtHora")
                {
                    cntName = 24;
                    hora = 24;
                }                    

                else if (txtName.Name == "txtMinuto")
                {
                    cntName = 59;
                    min = 59;
                }                    

                else if (txtName.Name == "txtSegundo")
                {
                    cntName = 59;
                    seg = 59;
                }

                else
                    throw new ArgumentException("El argumento \"txtName\" no contiene un nombre válido.");

                txtName.Text = string.Format("{0:00}", cntName);
            }

            if (hora == 25)
            {
                hora = 0;

                txtHora.Text = string.Format("{0:00}", hora);
            }

            if (hora == 24)
            {
                min = 0;
                seg = 0;

                txtMinuto.Text = string.Format("{0:00}", min);
                txtSegundo.Text = string.Format("{0:00}", seg);

                btnSubMin.Enabled = false;
                btnSubSeg.Enabled = false;
                btnBajMin.Enabled = false;
                btnBajSeg.Enabled = false;
            }

            else
            {
                btnSubMin.Enabled = true;
                btnSubSeg.Enabled = true;
                btnBajMin.Enabled = true;
                btnBajSeg.Enabled = true;
            }

            if (seg == 0 && min == 0 && hora == 0)
                btnEmpRea.Enabled = false;

            else
                btnEmpRea.Enabled = true;
        }

        private void updTextBoxes(object sender, ElapsedEventArgs e)
        {
            if (txtHora.InvokeRequired && txtMinuto.InvokeRequired && txtSegundo.InvokeRequired)
            {
                var dlg = new updTextBoxesDel(updTextBoxesText);

                try
                {
                    Invoke(dlg);
                }

                catch (ObjectDisposedException)
                {
                    // Nada.
                }
            }
        }

        private void updTextBoxesText()
        {
            if (temp.TotalSeconds > 1)
            {
                temp = temp.Subtract(TimeSpan.FromSeconds(1));

                hora = temp.Hours;
                min = temp.Minutes;
                seg = temp.Seconds;

                txtHora.Text = string.Format("{0:00}", hora);
                txtMinuto.Text = string.Format("{0:00}", min);
                txtSegundo.Text = string.Format("{0:00}", seg);

                System.Diagnostics.Debug.WriteLine("Evento producido.");
            }

            else
            {
                updTextBoxesTimer.Stop();                

                btnEmpRea.Text = "Empezar";

                temp = TimeSpan.FromSeconds(0);

                btnEmpParState = true;
                btnCancelar.Enabled = false;
                btnEmpRea.Enabled = false;

                habTodasLasFlechas();

                hora = 0;
                min = 0;
                seg = 0;

                txtHora.Text = string.Format("{0:00}", hora);
                txtMinuto.Text = string.Format("{0:00}", min);
                txtSegundo.Text = string.Format("{0:00}", seg);

                System.Diagnostics.Debug.WriteLine("Evento terminado por finalización del tiempo.");

                MessageBox.Show("Tiempo terminado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void habTodasLasFlechas()
        {
            btnSubHora.Enabled = true;
            btnSubMin.Enabled = true;
            btnSubSeg.Enabled = true;
            btnBajHora.Enabled = true;
            btnBajMin.Enabled = true;
            btnBajSeg.Enabled = true;
        }

        private void desTodasLasFlechas()
        {
            btnSubHora.Enabled = false;
            btnSubMin.Enabled = false;
            btnSubSeg.Enabled = false;
            btnBajHora.Enabled = false;
            btnBajMin.Enabled = false;
            btnBajSeg.Enabled = false;
        }
    }
}