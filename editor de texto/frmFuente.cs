using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_editor
{
    public partial class frmFuente : Form
    {
        private FontStyle sty = FontStyle.Regular;
        private Font createdFont;
        private int[] lastIndex = new int[3];
        private bool first;
        private bool lastUnderlinedCheckedState;
        private bool cancelFontChange = true;


        public frmFuente()
        {
            InitializeComponent();

            using (var fntCollection = new InstalledFontCollection())
            {
                foreach (FontFamily fnt in fntCollection.Families)
                {
                    lstBoxFont.Items.Add(fnt.Name);
                }
            }

            lstBoxFont.SelectedItem = "Arial";
            lstBoxStyle.SelectedItem = "Normal";
            lstBoxSize.SelectedItem = "20";

            setLastIndexes();

            first = true;
        }

        private void lstBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxFont.Text = lstBoxFont.SelectedItem.ToString();

            setFnt();
        }

        private void lstBoxStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxStyle.Text = lstBoxStyle.SelectedItem.ToString();

            setFnt();
        }

        private void lstBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxSize.Text = lstBoxSize.SelectedItem.ToString();

            setFnt();
        }

        private void setFnt()
        {
            if (first)
            {
                if (chkBoxUnderlined.Checked && lstBoxStyle.SelectedItem.ToString() == "Normal") sty = FontStyle.Regular | FontStyle.Underline;

                else if (!chkBoxUnderlined.Checked && lstBoxStyle.SelectedItem.ToString() == "Normal") sty = FontStyle.Regular;

                else if (chkBoxUnderlined.Checked && lstBoxStyle.SelectedItem.ToString() == "Cursiva") sty = FontStyle.Italic | FontStyle.Underline;

                else if (!chkBoxUnderlined.Checked && lstBoxStyle.SelectedItem.ToString() == "Cursiva") sty = FontStyle.Italic;

                else if (chkBoxUnderlined.Checked && lstBoxStyle.SelectedItem.ToString() == "Negrita") sty = FontStyle.Bold | FontStyle.Underline;

                else if (!chkBoxUnderlined.Checked && lstBoxStyle.SelectedItem.ToString() == "Negrita") sty = FontStyle.Bold;

                else if (chkBoxUnderlined.Checked && lstBoxStyle.SelectedItem.ToString() == "Negrita cursiva") sty = FontStyle.Italic | FontStyle.Bold | FontStyle.Underline;

                else if (!chkBoxUnderlined.Checked && lstBoxStyle.SelectedItem.ToString() == "Negrita cursiva") sty = FontStyle.Italic | FontStyle.Bold;

                crtFont(lstBoxFont.SelectedItem.ToString(), float.Parse(lstBoxSize.SelectedItem.ToString()));
            }
        }

        private void crtFont(string fnt, float size)
        {
            createdFont = new Font(fnt, size, sty);

            lblSample.Font = createdFont;
        }

        private void chkBoxStrikeout_CheckedChanged(object sender, EventArgs e)
        {
            setFnt();
        }

        private void chkBoxUnderlined_CheckedChanged(object sender, EventArgs e)
        {
            setFnt();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            cancelFontChange = false;

            Close();
        }

        private void setLastIndexes()
        {
            lastIndex[0] = lstBoxFont.SelectedIndex;
            lastIndex[1] = lstBoxStyle.SelectedIndex;
            lastIndex[2] = lstBoxSize.SelectedIndex;

            lastUnderlinedCheckedState = chkBoxUnderlined.Checked;
        }

        private void frmFuente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cancelFontChange)
            {
                lstBoxFont.SelectedIndex = lastIndex[0];
                lstBoxStyle.SelectedIndex = lastIndex[1];
                lstBoxSize.SelectedIndex = lastIndex[2];

                chkBoxUnderlined.Checked = lastUnderlinedCheckedState;
            }

            else
            {
                setLastIndexes();

                Program.SetFont(createdFont);

                cancelFontChange = true;
            }
        }
    }
}