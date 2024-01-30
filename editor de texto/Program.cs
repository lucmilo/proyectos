using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Text_editor
{
    public static class Program
    {
        private static frmPrincipal mainForm;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new frmPrincipal();
            Application.Run(mainForm);
        }

        public static string GetMainFormText() => mainForm.GetText();

        public static void SelectMainFormText(int ini, int end)
        {
            mainForm.SelectText(ini, end);
        }

        public static void SetFormName(string txtNom)
        {
            mainForm.Text = txtNom;
        }

        public static int GetCursorPos() => mainForm.GetCursorPos();

        public static void SrhWindowClosed()
        {
            mainForm.SrhWindowClosed();
        }

        public static string GetFormName() => mainForm.Text;

        public static void SetFont(Font fnt)
        {
            mainForm.SetFont(fnt);
        }
    }
}