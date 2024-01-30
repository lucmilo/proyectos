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
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading;

namespace Blackjack
{
    public partial class frmPerfiles : Form
    {
        private List<int> codJugList = new List<int>();
        private bool pmrPerBorrado; // Booleano que indica si ya se borró un perfil para no mostrar el mensaje de éxito una y otra vez.
        private frmLoading objLoading = new frmLoading();
        private delegate void delCloseLoadingFrm();

        public frmPerfiles()
        {
            InitializeComponent();

            btnAceptar.Enabled = false;
            btnBorrar.Enabled = false;

            //var t = new Thread(FrmLoadingThread);
            //t.Name = "Hilo de formulario \"Loading\""; // No iniciar hilos en el constructor de una clase (formulario) ya que el formulario
            // todavía no tiene identificador de ventana (window handle), puede causar problemas al manejar los formularios entre distintos hilos. Si hay que iniciar un hilo al momento que un formulario se crea,
            // es mejor utilizar el evento "Load", que se produce cuando se llama al método Show() o ShowDialog() del objeto de la clase del
            // formulario, al llamar a cualquiera de esos 2 métodos, ya se define el identificador de ventana.
            // En lo posible, evitar manejar los objetos de las clases de formularios entre distintos hilos.
            //t.Start();

            //try
            //{
            //    using (var con = new SqlConnection(Globales.DBCon()))
            //    {
            //        con.Open();

            //        using (var cmd = new SqlCommand())
            //        {
            //            cmd.Connection = con;
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.CommandText = "SEL_ALL_PERFILES";

            //            var rdr = cmd.ExecuteReader();

            //            if (rdr.HasRows)
            //            {
            //                while (rdr.Read())
            //                {
            //                    lstboxPerfiles.Items.Add(rdr[1]);

            //                    codJugList.Add(Convert.ToInt32(rdr[0]));
            //                }
            //            }

            //            else
            //            {
            //                btnAceptar.Enabled = false;

            //                lstboxPerfiles.Items.Add("(No hay perfiles)");
            //            }

            //            rdr.Close();
            //        }

            //        con.Close();
            //    }
            //}

            //catch
            //{
            //    CloseLoadingFrmInvoke();

            //    MessageBox.Show("Se ha producido un error al recuperar los perfiles desde el servidor.\nEl servidor no está disponible en este momento.", "Error de acceso",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    Close();
            //}

            //CloseLoadingFrmInvoke();
        }

        private void FrmLoadingThread(object o) => objLoading.ShowDialog(); // No sé para qué está el argumento "o".

        private void CloseLoadingFrmInvoke()
        {
            if (objLoading.IsDisposed)
            {
                Debug.WriteLine("Loading ha sido desechado. No se puede cerrar.");
                throw new ObjectDisposedException(GetType().FullName);
            }

            if (!objLoading.IsHandleCreated)
                objLoading.CreateControl();

            if (objLoading.InvokeRequired)
                Invoke(new delCloseLoadingFrm(objLoading.Close));

            else
                objLoading.Close();

            objLoading.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (lstboxPerfiles.SelectedIndex != -1 && lstboxPerfiles.Items[0].ToString() != "(No hay perfiles)")
            {
                frmBlackjack.SetCodJug((ushort)codJugList[lstboxPerfiles.SelectedIndex]);

                DialogResult = DialogResult.OK;
            }

            else
                MessageBox.Show("Seleccioná un perfil primero.", "No hay perfil seleccionado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmCrearPerfil objCrearPerfil = new frmCrearPerfil();

            int codJugFlt = objCrearPerfil.GetCodJugFlt();

            if (objCrearPerfil.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var con = new SqlConnection(Globales.DBCon()))
                    {
                        con.Open();

                        using (var cmd = new SqlCommand())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SEL_ALL_PERFILES";

                            var rdr = cmd.ExecuteReader();

                            // No hace falta preguntar si el reader tiene aunque sea un campo porque recién creamos un perfil (en la otra clase).
                            while (rdr.Read())
                            {
                                if (Convert.ToInt32(rdr[0]) == codJugFlt)
                                {
                                    if (lstboxPerfiles.Items.Contains("(No hay perfiles)"))
                                        lstboxPerfiles.Items.Remove("(No hay perfiles)");

                                    lstboxPerfiles.Items.Insert(codJugFlt - 1, rdr[1]);

                                    codJugList.Insert(codJugFlt - 1, Convert.ToInt32(rdr[0]));

                                    lstboxPerfiles.SelectedIndex = lstboxPerfiles.Items.Count - 1;

                                    break;
                                }
                            }

                            rdr.Close();
                        }

                        con.Close();
                    }
                }

                catch
                {
                    MessageBox.Show("Se ha producido un error al crear el perfil.\nEl servidor no está disponible en este momento.", "Error de acceso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (lstboxPerfiles.SelectedIndex != -1 && lstboxPerfiles.Items[0].ToString() != "(No hay perfiles)")
            {
                if (MessageBox.Show("¿Estás seguro que querés borrar este perfil?", "Borrar perfil",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        using (var con = new SqlConnection(Globales.DBCon()))
                        {
                            con.Open();

                            using (var cmd = new SqlCommand())
                            {
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "DEL_ESTADISTICAS_PERFIL";

                                cmd.Parameters.AddWithValue("CODJUG", codJugList[lstboxPerfiles.SelectedIndex]);

                                cmd.ExecuteNonQuery(); // Primero se borra el registro en la tabla "Estadisticas_Perfiles".
                                                       // Esto es por la FK.

                                cmd.CommandText = "DEL_PERFIL";

                                cmd.ExecuteNonQuery(); // Después se borra el registro en la tabla "Perfiles".

                                codJugList.RemoveAt(lstboxPerfiles.SelectedIndex);
                                lstboxPerfiles.Items.RemoveAt(lstboxPerfiles.SelectedIndex);

                                if (lstboxPerfiles.Items.Count == 0)
                                    lstboxPerfiles.Items.Add("(No hay perfiles)");

                                else
                                    lstboxPerfiles.SelectedIndex = lstboxPerfiles.Items.Count - 1;

                                if (!pmrPerBorrado)
                                {
                                    pmrPerBorrado = true;

                                    MessageBox.Show("Perfil borrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            con.Close();
                        }
                    }

                    catch
                    {
                        MessageBox.Show("Se ha producido un error al borrar el perfil.\nEl servidor no está disponible en este momento.", "Error de acceso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void lstboxPerfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstboxPerfiles.SelectedIndex == -1 || lstboxPerfiles.Items[0].ToString() == "(No hay perfiles)")
            {
                btnAceptar.Enabled = false;
                btnBorrar.Enabled = false;
            }

            else
            {
                btnAceptar.Enabled = true;
                btnBorrar.Enabled = true;
            }
        }

        private void frmPerfiles_Click(object sender, EventArgs e)
        {
            lstboxPerfiles.SelectedIndex = -1;
        }

        private void frmPerfiles_Load(object sender, EventArgs e)
        {
            var t = new Thread(FrmLoadingThread);
            t.Name = "Hilo de formulario \"Loading\"";
            t.Start();

            Thread.Sleep(3000);

            try
            {
                using (var con = new SqlConnection(Globales.DBCon()))
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
                            while (rdr.Read())
                            {
                                lstboxPerfiles.Items.Add(rdr[1]);

                                codJugList.Add(Convert.ToInt32(rdr[0]));
                            }
                        }

                        else
                        {
                            btnAceptar.Enabled = false;

                            lstboxPerfiles.Items.Add("(No hay perfiles)");
                        }

                        rdr.Close();
                    }

                    con.Close();
                }
            }

            catch
            {
                CloseLoadingFrmInvoke();

                MessageBox.Show("Se ha producido un error al recuperar los perfiles desde el servidor.\nEl servidor no está disponible en este momento.", "Error de acceso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
                return;
            }

            CloseLoadingFrmInvoke();
        }
    }
}