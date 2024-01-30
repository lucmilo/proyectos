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
using System.Security.Cryptography;

namespace Password_Generator_and_Checker
{
    public partial class frmPrincipal : Form
    {
        private readonly Font IniFont = new Font("Microsoft Sans Serif", 12, FontStyle.Italic);
        private readonly Font AftFont = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

        private readonly char[] numChArray = "01234567890123456789".ToArray(); // 20 caracteres.
        private readonly char[] mayChArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray(); // 26 caracteres.
        private readonly char[] minChArray = "abcdefghijklmnopqrstuvwxyz".ToArray(); // 26 caracteres.
        private readonly char[] simChArray = "#$%&/()=?¿!¡|°[]{}+-*@".ToArray(); // 22 caracteres.

        private List<char> passChList = new List<char>();

        private readonly Stopwatch clock = new Stopwatch();

        public frmPrincipal()
        {
            InitializeComponent();

            txtPass.Font = IniFont;
            txtPass.Text = "La contraseña aparecerá acá...";

            chkBoxMay.Checked = true;
            chkBoxMin.Checked = true;

            cboBoxLenght.Text = "10";

            statusStripLbl1.Text = "Esperando...";
        }

        private string genPass()
        {
            using (var RNG = RandomNumberGenerator.Create())
            {
                var posSel = new byte[128];
                RNG.GetBytes(posSel);

                var passConst = new StringBuilder();

                char aux;

                foreach (char ch in passChList)
                {
                    passConst.Append(ch);
                }

                Debug.WriteLine("passChList antes de ser mezclado:\n" + passConst + "\n");

                try
                {
                    for (int i = 0; i < passChList.Count; i++)
                    {
                        aux = passChList[i];

                        passChList[i] = passChList[posSel[i] % passChList.Count];

                        passChList[posSel[i] % passChList.Count] = aux;
                    }
                }

                catch (Exception ex)
                {
                    Debug.WriteLine("\nExcepción producida: " + ex.Message);

                    txtPass.Font = IniFont;

                    txtPass.Text = "Se ha producido un error.";
                }

                passConst.Clear();

                foreach (char ch in passChList)
                {
                    passConst.Append(ch);
                }

                Debug.WriteLine("passChList después de ser mezclado:\n" + passConst);

                passConst.Clear();

                try
                {
                    for (int i = 0; i < Convert.ToInt32(cboBoxLenght.SelectedItem); i++)
                    {
                        passConst.Append(passChList[posSel[i] % passChList.Count]);

                        Debug.WriteLine("\nPosición elegida: " + (posSel[i] % passChList.Count) + ".\nDe la posición: "
                            + posSel[i] + ".\n");                        
                    }
                }

                catch (Exception ex)
                {
                    Debug.WriteLine("\nExcepción producida: " + ex.Message);

                    txtPass.Font = IniFont;

                    txtPass.Text = "Se ha producido un error.";
                }

                return passConst.ToString();
            }
        }

        private void chkBoxMay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxMay.Checked)
            {
                Debug.WriteLine("Letras mayúsculas agregadas a la lista de caracteres.\n");

                foreach (char ch in mayChArray) passChList.Add(ch);
            }

            else
            {
                Debug.WriteLine("Letras mayúsculas eliminadas a la lista de caracteres.\n");

                foreach (char ch in mayChArray) passChList.Remove(ch);
            }
        }

        private void chkBoxMin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxMin.Checked)
            {
                Debug.WriteLine("Letras minúsculas agregadas a la lista de caracteres.\n");

                foreach (char ch in minChArray) passChList.Add(ch);
            }

            else
            {
                Debug.WriteLine("Letras minúsculas eliminadas a la lista de caracteres.\n");

                foreach (char ch in minChArray) passChList.Remove(ch);
            }
        }

        private void chkBoxNum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxNum.Checked)
            {
                Debug.WriteLine("Números agregados a la lista de caracteres.\n");

                foreach (char ch in numChArray) passChList.Add(ch);
            }

            else
            {
                Debug.WriteLine("Números eliminados a la lista de caracteres.\n");

                foreach (char ch in numChArray) passChList.Remove(ch);
            }
        }

        private void chkBoxSim_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxSim.Checked)
            {
                Debug.WriteLine("Símbolos agregados a la lista de caracteres.\n");

                foreach (char ch in simChArray) passChList.Add(ch);
            }

            else
            {
                Debug.WriteLine("Símbolos eliminados a la lista de caracteres.\n");

                foreach (char ch in simChArray) passChList.Remove(ch);
            }
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            showPass();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showPass()
        {
            clock.Start();

            string result = genPass().Trim();

            if (!string.IsNullOrWhiteSpace(result))
            {
                Debug.WriteLine("String devuelto con éxito.\n" + "Largo: " + result.Length + ".");

                txtPass.Font = AftFont;
                txtPass.Text = result;

                statusStripLbl1.Text = clock.Elapsed.TotalMilliseconds + " ms";

                clock.Reset();
            }

            else
            {
                Debug.WriteLine("El método genPass() devolvió un string vacío.");

                txtPass.Font = IniFont;
                txtPass.Text = "Seleccione por lo menos una opción de Incluir.";
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                showPass();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void verificadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var objVer = new frmVerificador();

            objVer.ShowDialog();
        }
    }
}