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
using System.IO;

namespace Text_editor
{
    public partial class frmPrincipal : Form
    {
        private uint cntPal;
        private frmBuscar objBuscar;
        private string stmFile = null;
        private frmFuente objFuente = new frmFuente();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void richTxtBox_TextChanged(object sender, EventArgs e)
        {
            char[] chArray = richTxtBox.Text.Trim().ToLower().ToArray();

            for (int i = 0; i < chArray.Length; i++)
            {
                if ((chArray[i] == ' ' || chArray[i] == '\n') && chArray[i + 1] != ' ' && chArray[i + 1] != '\n') ++cntPal;
            }

            ++cntPal;

            if (chArray.Length == 0)
                cntPal = 0;

            Debug.WriteLine("Cantidad de caracteres: " + richTxtBox.Text.Trim().Length + "\n");

            Debug.WriteLine("Cantidad de espacios en blanco: " + cntPal + "\n");

            Debug.WriteLine(richTxtBox.Text + "\n");

            statusStripLblCar.Text = "Caracteres: " + richTxtBox.Text.Trim().Length;

            statusStripLblPal.Text = "Palabras: " + cntPal;

            if (cntPal > 0) cntPal = 0;
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (objBuscar == null)
            {
                objBuscar = new frmBuscar();

                objBuscar.Show();
            }

            else
            {
                Debug.WriteLine("La ventana de búsqueda ya existe. Estableciendo el foco...");

                objBuscar.Focus();                
            }
        }

        public void SrhWindowClosed()
        {
            objBuscar = null;
        }

        public string GetText() => richTxtBox.Text;

        public void SelectText(int ini, int end)
        {
            richTxtBox.Select(ini, end);
        }

        public int GetCursorPos() => richTxtBox.SelectionStart;

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resp;

            try
            {
                resp = checkChanges();
            }

            catch (FileNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el archivo especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                resp = DialogResult.Abort;
            }

            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el directorio especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                resp = DialogResult.Abort;
            }

            catch
            {
                MessageBox.Show("Se ha producido un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                resp = DialogResult.Abort;
            }

            if (resp == DialogResult.Yes)
            {
                saveTxt();

                openFileProc();
            }

            else if (resp == DialogResult.No || resp == DialogResult.None) openFileProc();

            else if (resp == DialogResult.Abort)
            {
                saveTxt(true);

                openFileProc();
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resp;

            try
            {
                resp = checkChanges();
            }

            catch (FileNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el archivo especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                resp = DialogResult.Abort;
            }

            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el directorio especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                resp = DialogResult.Abort;
            }

            catch
            {
                MessageBox.Show("Se ha producido un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                resp = DialogResult.Abort;
            }

            if (resp == DialogResult.Yes)
            {
                saveTxt();

                richTxtBox.Text = string.Empty;

                Program.SetFormName("Sin título");

                stmFile = null;
            }

            else if (resp == DialogResult.No || resp == DialogResult.None)
            {
                richTxtBox.Text = string.Empty;

                Program.SetFormName("Sin título");

                stmFile = null;
            }

            else if (resp == DialogResult.Abort)
            {
                saveTxt(true);

                richTxtBox.Text = string.Empty;

                Program.SetFormName("Sin título");

                stmFile = null;
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveTxt(true);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveTxt();
        }

        private void saveTxt(bool saveAs = false)
        {
            try
            {
                if (saveAs || stmFile == null)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        saveAsProc();
                }

                else
                {                    
                    var saveChars = new StreamWriter(stmFile);

                    saveChars.Write(richTxtBox.Text);

                    saveChars.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error en saveTxt.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveAsProc()
        {
            var saveChars = new StreamWriter(saveFileDialog1.FileName);

            Program.SetFormName(saveFileDialog1.FileName);

            saveChars.Write(richTxtBox.Text);

            saveChars.Close();

            stmFile = saveFileDialog1.FileName;
        }

        private DialogResult checkChanges()
        {
            if (stmFile != null)
            {
                var readChars = new StreamReader(stmFile);

                string[] wrdArray = richTxtBox.Text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                string[] fileWordArray = readChars.ReadToEnd().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                if (wrdArray.Length != fileWordArray.Length)
                {
                    DialogResult resp = MessageBox.Show("¿Desea guardar los cambios en " + Program.GetFormName() + "?", "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                    readChars.Close();

                    return resp;
                }

                for (int i = 0; i < wrdArray.Length; i++)
                {
                    if (wrdArray[i] != fileWordArray[i])
                    {
                        DialogResult resp = MessageBox.Show("¿Desea guardar los cambios en " + Program.GetFormName() + "?", "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        readChars.Close();

                        return resp;
                    }
                }

                readChars.Close();
            }

            else if (richTxtBox.TextLength > 0)
            {
                DialogResult resp = MessageBox.Show("¿Desea guardar los cambios en " + Program.GetFormName() + "?", "Confirmar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                return resp;
            }

            return DialogResult.None;
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resp;

            try
            {
                resp = checkChanges();
            }

            catch (FileNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el archivo especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                resp = DialogResult.Abort;
            }

            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el directorio especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                resp = DialogResult.Abort;
            }

            catch
            {
                MessageBox.Show("Se ha producido un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                resp = DialogResult.Abort;
            }

            if (resp == DialogResult.Yes) saveTxt();

            else if (resp == DialogResult.Cancel) e.Cancel = true;

            else if (resp == DialogResult.Abort) saveTxt(true);
        }

        private void openFileProc()
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    var readChars = new StreamReader(openFileDialog1.FileName);

                    Program.SetFormName(openFileDialog1.FileName);

                    richTxtBox.Text = readChars.ReadToEnd();

                    readChars.Close();

                    stmFile = openFileDialog1.FileName;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objFuente.ShowDialog();
        }

        public void SetFont(Font fnt)
        {
            richTxtBox.Font = fnt;
        }
    }
}