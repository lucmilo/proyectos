using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_Chat
{
    public partial class frmConInfo : Form
    {
        private ushort port;

        private bool nameVal;
        private bool ipVal;
        private bool portVal;

        public frmConInfo()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void txtBoxName_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxName.TextLength >= 3)
                nameVal = true;

            else
                nameVal = false;

            EnableBtn();
        }

        private void txtBoxIP_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxIP.TextLength > 0 && IPAddress.TryParse(txtBoxIP.Text, out _))
                ipVal = true;

            else
                ipVal = false;

            EnableBtn();
        }

        private void txtBoxPort_TextChanged(object sender, EventArgs e)
        {
            if (ushort.TryParse(txtBoxPort.Text, out port))
                portVal = true;

            else
                portVal = false;

            EnableBtn();
        }

        private void EnableBtn()
        {
            if (nameVal && ipVal && portVal)
                btnAceptar.Enabled = true;

            else
                btnAceptar.Enabled = false;
        }

        public string GetName
        {
            get
            {
                if (chkAnonName.Checked)
                    return "Anónimo";

                else
                    return txtBoxName.Text;
            }
        }

        public string GetIPString => txtBoxIP.Text;

        public ushort GetPort => port;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && nameVal && ipVal && portVal)
            {
                DialogResult = DialogResult.OK;

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void chkAnonName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnonName.Checked)
            {
                if (!nameVal)
                    nameVal = true;
                txtBoxName.Enabled = false;
            }

            else
            {
                if (nameVal && txtBoxName.TextLength < 3)
                    nameVal = false;
                txtBoxName.Enabled = true;
            }

            EnableBtn();
        }
    }
}