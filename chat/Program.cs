namespace TCP_Chat
{
    internal static class Program
    {
        private static frmChat frmChat;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            frmChat = new frmChat();
            Application.Run(frmChat);
        }

        public static void ChangeFrmText(string value)
        {
            frmChat.Text = value;
        }
    }
}