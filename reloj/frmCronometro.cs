using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Timer = System.Timers.Timer;
using System.Timers;

namespace Proyecto_Reloj
{
    public partial class frmCronometro : Form
    {
        private bool btnEmpParaState = true;
        private bool btnResParcState;
        private bool frsTime = true;
        private int cont = 0;
        private delegate void delShowStopwatchTime(string str);
        private Stopwatch clock = new Stopwatch();
        private Stopwatch clockParc = new Stopwatch();
        private Timer updTimer = new Timer(1);
        private Timer updTimerParc = new Timer(1);

        public frmCronometro()
        {
            InitializeComponent();

            txtCrono.Text = "00 : 00 : 00.0";

            btnRestablecerParcial.Enabled = false;

            txtCronoParc.Visible = false;

            updTimer.AutoReset = true;
            updTimer.Elapsed += new ElapsedEventHandler(updStopwatch);

            updTimerParc.AutoReset = true;
            updTimerParc.Elapsed += new ElapsedEventHandler(updStopwatchParc);

            dgvParcial.ColumnCount = 3;

            dgvParcial.Columns[0].Name = "Vuelta";
            dgvParcial.Columns[1].Name = "Tiempos parciales";
            dgvParcial.Columns[2].Name = "Tiempo total";

            dgvParcial.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcial.Columns[1].SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParcial.Columns[2].SortMode = DataGridViewColumnSortMode.Programmatic;

            dgvParcial.Visible = false;
        }

        private void btnEmpezarParar_Click(object sender, EventArgs e)
        {
            if (btnEmpParaState)
            {
                clock.Start();

                updTimer.Start();

                if (!frsTime)
                {
                    clockParc.Start();

                    updTimerParc.Start();
                }

                btnEmpezarParar.Text = "Parar";
                btnRestablecerParcial.Text = "Parcial";

                btnEmpParaState = false;
                btnResParcState = false;

                btnRestablecerParcial.Enabled = true;
            }

            else
            {
                clock.Stop();
                clockParc.Stop();

                updTimer.Stop();
                updTimerParc.Stop();

                txtCrono.Text = GetRelojTimeStr();

                btnEmpezarParar.Text = "Reanudar";
                btnRestablecerParcial.Text = "Restablecer";

                btnEmpParaState = true;
                btnResParcState = true;
            }
        }

        private void btnRestablecerParcial_Click(object sender, EventArgs e)
        {
            if (btnResParcState)
            {
                clock.Reset();
                clockParc.Reset();

                txtCrono.Text = GetRelojTimeStr();
                txtCronoParc.Text = GetRelojTimeParcStr();

                btnRestablecerParcial.Text = "Parcial";
                btnEmpezarParar.Text = "Empezar";

                btnRestablecerParcial.Enabled = false;

                if (dgvParcial.Visible)
                    txtCronoParc.Visible = false;

                frsTime = true;

                dgvParcial.Visible = false;
                dgvParcial.Rows.Clear();

                cont = 0;
            }

            else
            {
                cont++;

                if (!dgvParcial.Visible)
                    dgvParcial.Visible = true;

                if (frsTime)
                {
                    txtCronoParc.Visible = true;

                    dgvParcial.Rows.Add(new object[] { cont, GetRelojTimeStr(), GetRelojTimeStr() });                    

                    clockParc.Start();

                    updTimerParc.Start();

                    frsTime = false;
                }

                else
                {
                    dgvParcial.Rows.Add(new object[] { cont, GetRelojTimeParcStr(), GetRelojTimeStr() });
                    dgvParcial.Sort(dgvParcial.Columns[0], ListSortDirection.Descending);

                    clockParc.Restart();
                }                
            }
        }

        private void updStopwatch(object sender, ElapsedEventArgs e)
        {
            if (txtCrono.InvokeRequired)
            {
                var dlg = new delShowStopwatchTime(showStopwatchTime);

                try
                {
                    Invoke(dlg, new string[] { GetRelojTimeStr() });
                }

                catch (ObjectDisposedException)
                {
                    Debug.WriteLine("ALERTA");
                }

                catch (InvalidOperationException)
                {
                    Debug.WriteLine("ALERTA");
                }
            }

            else
                txtCrono.Text = GetRelojTimeStr();
        }

        private void updStopwatchParc(object sender, ElapsedEventArgs e)
        {
            if (txtCronoParc.InvokeRequired)
            {
                var dlg = new delShowStopwatchTime(showStopwatchTimeParc);

                try
                {
                    Invoke(dlg, new string[] { GetRelojTimeParcStr() });
                }

                catch (ObjectDisposedException)
                {
                    Debug.WriteLine("ALERTA");
                }

                catch (InvalidOperationException)
                {
                    Debug.WriteLine("ALERTA");
                }
            }

            else
                txtCronoParc.Text = GetRelojTimeParcStr();
        }

        private void showStopwatchTime(string str)
        {
            txtCrono.Text = str;
        }

        private void showStopwatchTimeParc(string str)
        {
            txtCronoParc.Text = str;
        }

        private string GetRelojTimeStr() => string.Format("{0:00}", clock.Elapsed.Hours) + " : " + string.Format("{0:00}", clock.Elapsed.Minutes) +
            " : " + string.Format("{0:00}", clock.Elapsed.Seconds) + "." + clock.Elapsed.Milliseconds;

        private string GetRelojTimeParcStr() => string.Format("{0:00}", clockParc.Elapsed.Hours) + " : " + string.Format("{0:00}", clockParc.Elapsed.Minutes) +
            " : " + string.Format("{0:00}", clockParc.Elapsed.Seconds) + "." + clockParc.Elapsed.Milliseconds;
    }
}