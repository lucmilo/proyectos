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

namespace Text_editor
{
    public partial class frmBuscar : Form
    {
        private List<char> lstCharMainTxt = new List<char>();
        private List<char> lstCharIngTxt = new List<char>();
        private int z;
        private bool asiZ = true;

        public frmBuscar()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(txtBoxSearch.Text + "\n" + Program.GetMainFormText() + "\n");

            Buscar();
        }

        private void Buscar()
        {
            if (txtBoxSearch.TextLength > 0)
            {
                bool pmrRep = true;

                int u = 0;

                if (chkBoxWrapAround.Checked)
                {
                    if (asiZ)
                    {
                        z = 0;

                        asiZ = false;
                    }

                    for (int i = z; i < lstCharMainTxt.Count; i++)
                    {
                        for (int x = 0; x < lstCharIngTxt.Count; x++)
                        {
                            if (pmrRep)
                            {
                                u = i;

                                pmrRep = false;
                            }

                            try
                            {
                                if (lstCharMainTxt[u] == lstCharIngTxt[x])
                                    ++u;

                                else
                                {
                                    pmrRep = true;

                                    break;
                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("Se ha producido un error.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }

                            if (x == (lstCharIngTxt.Count - 1))
                            {
                                Program.SelectMainFormText(i, lstCharIngTxt.Count);

                                z = u + 1;

                                return;
                            }
                        }
                    }

                    MessageBox.Show("No se ha encontrado ninguna coincidencia.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    if (rdoButtonDown.Checked)
                    {
                        if (asiZ)
                        {
                            z = Program.GetCursorPos();

                            asiZ = false;
                        }

                        for (int i = z; i < lstCharMainTxt.Count; i++)
                        {
                            for (int x = 0; x < lstCharIngTxt.Count; x++)
                            {
                                if (pmrRep)
                                {
                                    u = i;

                                    pmrRep = false;
                                }

                                try
                                {
                                    if (lstCharMainTxt[u] == lstCharIngTxt[x]) ++u;

                                    else
                                    {
                                        pmrRep = true;

                                        break;
                                    }
                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show("Se ha producido un error.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    return;
                                }

                                if (x == (lstCharIngTxt.Count - 1))
                                {
                                    Program.SelectMainFormText(i, lstCharIngTxt.Count);

                                    z = u + 1;

                                    return;
                                }
                            }
                        }

                        MessageBox.Show("No se ha encontrado ninguna coincidencia.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        if (asiZ)
                        {
                            z = Program.GetCursorPos() - 1;

                            asiZ = false;
                        }

                        for (int i = z; i >= 0; i--)
                        {
                            for (int x = lstCharIngTxt.Count - 1; x >= 0; x--)
                            {
                                if (pmrRep)
                                {
                                    u = i;

                                    pmrRep = false;
                                }

                                try
                                {
                                    if (lstCharMainTxt[u] == lstCharIngTxt[x]) --u;

                                    else
                                    {
                                        pmrRep = true;

                                        break;
                                    }
                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show("Se ha producido un error.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    return;
                                }

                                if (x == 0)
                                {
                                    Program.SelectMainFormText(u + 1, lstCharIngTxt.Count);

                                    z = u;

                                    return;
                                }
                            }
                        }

                        MessageBox.Show("No se ha encontrado ninguna coincidencia.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            else MessageBox.Show("No se ingresó ningún texto a buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkBoxWrapAround_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = !chkBoxWrapAround.Checked;

            resetVars();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && ActiveControl.Name == "txtBoxSearch")
            {
                Debug.WriteLine(txtBoxSearch.Text + "\n" + Program.GetMainFormText() + "\n");

                Buscar();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void rdoButtonDown_CheckedChanged(object sender, EventArgs e)
        {
            resetVars();
        }

        private void rellenarListas()
        {
            if (chkBoxMatchCase.Checked)
            {
                lstCharMainTxt.Clear();

                lstCharMainTxt.AddRange(Program.GetMainFormText().ToArray());

                lstCharIngTxt.Clear();

                lstCharIngTxt.AddRange(txtBoxSearch.Text.ToArray());
            }

            else
            {
                lstCharMainTxt.Clear();

                lstCharMainTxt.AddRange(Program.GetMainFormText().ToLower().ToArray());

                lstCharIngTxt.Clear();

                lstCharIngTxt.AddRange(txtBoxSearch.Text.ToLower().ToArray());
            }
        }

        private void frmBuscar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.SrhWindowClosed();
        }

        private void resetVars()
        {
            if (!asiZ) asiZ = true;

            rellenarListas();
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            resetVars();
        }

        private void chkBoxMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            resetVars();
        }
    }
}