using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class frmEstadisticas : Form
    {
        public frmEstadisticas()
        {
            InitializeComponent();

            ushort codJug = frmBlackjack.GetCodJug();

            lblCodJug.Text = "Código de perfil: " + codJug;

            try
            {
                using (var con = new SqlConnection(Globales.DBCon()))
                {
                    con.Open();

                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SEL_ESTADISTICAS_PERFIL";

                        cmd.Parameters.AddWithValue("CODJUG", (int)codJug);

                        var rdr = cmd.ExecuteReader();

                        if (rdr.HasRows)
                        {
                            rdr.Read();

                            lblMonto.Text = "Monto: $" + rdr[0];
                            lblDinGan.Text = "Dinero ganado: $" + rdr[1];
                            lblDinPer.Text = "Dinero perdido: $" + rdr[2];
                            lblPtdGan.Text = "Partidas ganadas: " + rdr[3];
                            lblPtdPer.Text = "Partidas perdidas: " + rdr[4];
                            lblCtaPed.Text = "Cartas pedidas: " + rdr[5];
                            lblVceQue.Text = "Veces quedadas: " + rdr[6];
                            lblPtoObt.Text = "Puntos obtenidos: " + rdr[7];
                            lblBlkJck.Text = "Blackjacks: " + rdr[8];
                            var tpoTot = TimeSpan.FromTicks(Convert.ToInt64(rdr[9]));

                            if (tpoTot.TotalSeconds < 60)
                                lblTpoTot.Text = "Tiempo total: " + Math.Truncate(tpoTot.TotalSeconds) + " segundo(s)";

                            else if (tpoTot.TotalMinutes < 60)
                                lblTpoTot.Text = "Tiempo total: " + Math.Truncate(tpoTot.TotalMinutes) + " minuto(s)";

                            else
                                lblTpoTot.Text = "Tiempo total: " + Math.Round(tpoTot.TotalHours, 1) + " hora(s)";
                        }

                        else
                            MessageBox.Show("No se encontraron estadísticas para este perfil.", "No hay estadísticas", MessageBoxButtons.OK
                                , MessageBoxIcon.Information);

                        rdr.Close();
                    }

                    con.Close();
                }
            }

            catch
            {
                MessageBox.Show("Se ha producido un error al recuperar las estadísticas desde el servidor.\nEl servidor no está disponible en este momento", "Error de acceso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}