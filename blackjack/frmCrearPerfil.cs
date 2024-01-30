using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Blackjack
{
    public partial class frmCrearPerfil : Form
    {
        private ushort codJugMay;
        private ushort codJugFlt; // Código de jugador faltante, es uno de los códigos de perfiles eliminados anteriormente.
        private bool fltCodJug; // Booleano que indica si falta un código de jugador, debido a que se borró un perfil anteriormente.

        public frmCrearPerfil()
        {
            InitializeComponent();

            txtNomJug.Focus();

            btnAceptar.Enabled = false;

            try
            {
                using (var con = new SqlConnection(Globales.DBCon())) // TODO: Meter en un try-catch.
                {
                    con.Open();

                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SEL_CODJUG_MAY";

                        var rdr = cmd.ExecuteReader();

                        rdr.Read();

                        if (!rdr.IsDBNull(0))
                            codJugMay = Convert.ToUInt16(rdr[0]);

                        else
                            codJugMay = 0;

                        rdr.Close();
                    }

                    con.Close();
                }

                using (var con = new SqlConnection(Globales.DBCon())) // TODO: Meter en un try-catch.
                {
                    con.Open();

                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SEL_ALL_PERFILES";

                        var rdr = cmd.ExecuteReader();

                        if (rdr.HasRows)
                        {
                            ushort aux = 1;

                            while (rdr.Read())
                            {
                                if (aux != Convert.ToUInt16(rdr[0]))
                                {
                                    codJugFlt = aux;

                                    fltCodJug = true;

                                    break;
                                }

                                else
                                    aux++;
                            }
                        }

                        rdr.Close();
                    }

                    con.Close();
                }
            }

            catch
            {
                // Nada.
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (CrearPerfil() == DialogResult.OK)
                DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private DialogResult CrearPerfil()
        {
            if (txtNomJug.Text.Trim().ToLower() != "(no hay perfiles)")
            {
                try
                {
                    using (var con = new SqlConnection(Globales.DBCon())) // TODO: Meter en un try-catch.
                    {
                        con.Open();

                        using (var cmd = new SqlCommand())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "INS_PERFIL";

                            if (fltCodJug)
                                cmd.Parameters.AddWithValue("CODJUG", (int)codJugFlt);

                            else
                                cmd.Parameters.AddWithValue("CODJUG", codJugMay + 1);

                            cmd.Parameters.AddWithValue("NOMJUG", txtNomJug.Text.Trim());

                            cmd.ExecuteNonQuery();
                        }

                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Se ha producido un error al crear el perfil.\nEl servidor no está disponible en este momento.", "Error de acceso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return DialogResult.Cancel;
                }

                return DialogResult.OK;
            }

            else
            {
                MessageBox.Show("Este nombre de perfil está reservado para el sistema.", "Nombre inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return DialogResult.Cancel;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && ActiveControl.Name == "txtNomJug" && btnAceptar.Enabled)
            {
                if (CrearPerfil() == DialogResult.OK)
                    DialogResult = DialogResult.OK;

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtNomJug_TextChanged(object sender, EventArgs e)
        {
            if (txtNomJug.Text.Trim().Length > 0)
                btnAceptar.Enabled = true;

            else
                btnAceptar.Enabled = false;
        }

        public int GetCodJugFlt()
        {
            if (fltCodJug)
                return codJugFlt;

            else
                return codJugMay + 1;
        }
    }
}