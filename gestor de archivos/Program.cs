namespace File_Uploader
{
    internal static class Program
    {
        private static frmPrincipal objFrmPrincipal;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            objFrmPrincipal = new frmPrincipal();
            Application.Run(objFrmPrincipal);
        }

        public static void ChangePgrBarValue(int value)
        {
            objFrmPrincipal.ChangePgrBarValue(value);
        }

        public static void ChangeStripLbl(string value)
        {
            objFrmPrincipal.InvokeChangeLbls(value);
        }
    }
}