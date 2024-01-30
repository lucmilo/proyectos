using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Proyecto_Reloj
{
    public partial class frmPrincipal : Form
    {
        private delegate void delChangeLblReloj(string str);

        public frmPrincipal()
        {
            InitializeComponent();

            lblReloj.Text = "Obteniendo hora...";

            var timer = new Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(getTime);
            timer.Start();

            lblZonaHoraria.Text = TimeZoneInfo.Local.DisplayName;
        }

        private void getTime(object sender, ElapsedEventArgs e)
        {
            char[] time = DateTime.Now.ToString().ToArray();

            var strBuilder = new StringBuilder();

            for (int i = 0; i < time.Length; i++)
            {
                if (char.IsWhiteSpace(time[i]) && !char.IsLetter(time[i + 1]))
                    strBuilder.Append("\n\n");

                else
                    strBuilder.Append(time[i]);
            }

            if (lblReloj.InvokeRequired)
            {
                var dlg = new delChangeLblReloj(changeLblReloj);

                try
                {
                    Invoke(dlg, new string[] { strBuilder.ToString() });
                }

                catch (ObjectDisposedException)
                {
                    MessageBox.Show("Referencia a objeto no existente en memoria.", "Objeto desechado", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
                lblReloj.Text = strBuilder.ToString();
        }

        private void changeLblReloj(string str)
        {
            lblReloj.Text = str;
        }

        private void cronómetroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var objCrono = new frmCronometro();
            objCrono.ShowDialog();

            objCrono.Dispose();
        }

        private void temporizadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var objTempo = new frmTemporizador();
            objTempo.ShowDialog();

            objTempo.Dispose();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}