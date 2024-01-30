using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using TCPComs;

namespace TCP_Chat
{
    public partial class frmChat : Form
    {
        private Client? cli;
        private Server svr;
        private StringBuilder strBuilder = new StringBuilder();
        private List<string> strList = new List<string>();
        private string thisUserName;
        private bool conEstablished;

        public frmChat()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            SendMsg();
        }

        private async void frmChat_Load(object sender, EventArgs e)
        {
            string ipString;
            ushort port;

            string? response = null;

            btnEnviar.Enabled = false;

            frmConInfo objConInfo = new frmConInfo();
            if (objConInfo.ShowDialog() == DialogResult.Cancel)
            {
                this.Close();
                return;
            }

            try
            {
                if (objConInfo.IsDisposed)
                    throw new ObjectDisposedException(objConInfo.GetType().FullName);

                else
                {
                    ipString = objConInfo.GetIPString;
                    port = objConInfo.GetPort;
                    thisUserName = objConInfo.GetName;
                }
            }

            catch (ObjectDisposedException ex)
            {
                MessageBox.Show("ObjectDisposedException: " + ex.Message + "\n\nEl programa se cerrará.", "Error al acceder objeto",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                return;
            }

            try // Client
            {
                cli = new Client(ipString, port);
                await Task.Run(cli.StartListening);

                cli.WriteData("(El usuario " + thisUserName + " se ha conectado)", 0);

                strList.Add("(Conexión establecida)");

                foreach (var str in strList)
                {
                    strBuilder.AppendLine(str);
                }

                rchTxtBox.Text = strBuilder.ToString();

                strBuilder.Clear();

                //Program.ChangeFrmText("TCP Chat (Client)");

                _ = Task.Run(async () =>
                {
                    while (true)
                    {
                        if (!cli.CheckStreamCon(0))
                        {
                            strList.Add("(Conexión perdida. La aplicación se cerrará en 3 segundos.)");

                            foreach (var str in strList)
                            {
                                strBuilder.AppendLine(str);
                            }

                            rchTxtBox.Text = strBuilder.ToString();

                            strBuilder.Clear();

                            btnEnviar.Enabled = false;

                            await Task.Delay(3000);

                            this.Close();
                            return;
                        }

                        response = cli.ReadData(0);

                        if (response != null)
                            InsertMessagesToTextBox(response);
                    }
                });

                //MessageBox.Show("Server found!");
            }

            catch (SocketException) // Server
            {
                strList.Add("(Esperando conexión...)");

                foreach (string str in strList)
                    strBuilder.AppendLine(str);

                rchTxtBox.Text = strBuilder.ToString();

                strBuilder.Clear();

                //Program.ChangeFrmText("TCP Chat (Server)");

                //MessageBox.Show("No server found.");
                cli = null;

                svr = new Server(ipString, port);

                try
                {
                    await Task.Run(svr.StartListening);
                }

                catch (SocketException ex)
                {
                    MessageBox.Show("SocketException: " + ex.Message + "\n\nEl programa se cerrará.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.Close();
                    return;
                }

                await Task.Run(svr.AcceptConnection); // Esperamos al primer cliente.

                _ = Task.Run(() => // Empezamos a escuchar a los próximos clientes.
                {
                    //while (true)
                    //{
                    //    for (int i = 0; i < svr.GetIndex; i++)
                    //        svr.AcceptConnection();
                    //}

                    for (int i = 0; i < svr.GetIndex; i++)
                        svr.AcceptConnection();
                });

                await Task.Delay(300);

                //string? connectedUser = svr.ReadData(0);

                //strList.Add("(El usuario " + connectedUser + " se ha conectado)");

                //foreach (var str in strList)
                //    strBuilder.AppendLine(str);

                //rchTxtBox.Text = strBuilder.ToString();

                //strBuilder.Clear();

                _ = Task.Run(async () =>
                {
                    while (true)
                    {
                        for (int i = 0; i < svr.GetIndex; i++)
                        {
                            if (!svr.CheckAllStreamCons())
                            {
                                strList.Add("(Conexión perdida. La aplicación se cerrará en 3 segundos.)");

                                foreach (var str in strList)
                                {
                                    strBuilder.AppendLine(str);
                                }

                                rchTxtBox.Text = strBuilder.ToString();

                                strBuilder.Clear();

                                btnEnviar.Enabled = false;

                                await Task.Delay(3000);

                                this.Close();
                                return;
                            }

                            try
                            {
                                response = svr.ReadData(i); // Si un cliente se desconecta, es imposible que mande mensajes, por lo que no podría
                                                            // suceder una excepción acá nunca.
                            }

                            catch
                            {
                                InsertMessagesToTextBox("El cliente " + i + " se desconectó.");

                                continue;
                            }

                            if (response != null)
                            {
                                for (int x = 0; x < svr.GetIndex; x++)
                                {
                                    try
                                    {
                                        svr.WriteData(response, x);
                                    }

                                    catch
                                    {

                                    }
                                }

                                InsertMessagesToTextBox(response);
                            }
                        }
                    }
                });

                //MessageBox.Show("Connection established!");
            }

            conEstablished = true;
        }

        private void InsertMessagesToTextBox(string value)
        {
            strList.Add(value);

            foreach (var str in strList)
                strBuilder.AppendLine(str);

            rchTxtBox.Text = strBuilder.ToString();

            strBuilder.Clear();
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if (txtBox.TextLength > 0 && conEstablished)
                btnEnviar.Enabled = true;

            else
                btnEnviar.Enabled = false;
        }

        private void SendMsg()
        {
            try
            {
                if (cli != null)
                    cli.WriteData($"<{thisUserName}>: " + txtBox.Text, 0);

                else
                {
                    InsertMessagesToTextBox($"<{thisUserName}>: " + txtBox.Text);

                    for (int i = 0; i < svr.GetIndex; i++)
                    {
                        try
                        {
                            svr.WriteData($"<{thisUserName}>: " + txtBox.Text, i);
                        }

                        catch
                        {

                        }
                    }
                }
            }

            catch
            {
                // Nada.
            }

            txtBox.Text = string.Empty;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && ActiveControl.Name == "txtBox" && txtBox.TextLength > 0 && conEstablished)
            {
                SendMsg();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void rchTxtBox_TextChanged(object sender, EventArgs e)
        {
            rchTxtBox.SelectionStart = rchTxtBox.TextLength;
            rchTxtBox.ScrollToCaret();
        }
    }
}