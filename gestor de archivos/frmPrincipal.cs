using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Globalization;
using System.Diagnostics;

namespace File_Uploader
{
    public partial class frmPrincipal : Form
    {
        private Server server;
        private Client client;

        private SaveFileDialog sfdObject = new SaveFileDialog();

        private CancellationTokenSource canTokenSource = default;
        private CancellationToken token;

        private string pathSend;
        private string? pathSendAnt = null;
        private string pathReceive;

        private bool ipVal;
        private bool portVal;
        private bool conEstaReset = true;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void txtBoxIP_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBoxIP.Text) && IPAddress.TryParse(txtBoxIP.Text, out _))
                ipVal = true;

            else
                ipVal = false;

            CheckConVals();
        }

        private void txtBoxPuerto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBoxPuerto.Text) && ushort.TryParse(txtBoxPuerto.Text, out _))
                portVal = true;

            else
                portVal = false;

            CheckConVals();
        }

        private void CheckConVals()
        {
            if (ipVal && portVal)
                btnEstablecer.Enabled = true;

            else
                btnEstablecer.Enabled = false;
        }

        private async void btnEstablecer_Click(object sender, EventArgs e)
        {
            if (canTokenSource == null)
                canTokenSource = new CancellationTokenSource();

            if (conEstaReset)
            {
                token = canTokenSource.Token; // "token" podría ser una variable local en vez de un campo de clase, no cambia mucho igual.

                if (rdnBtnServer.Checked)
                {
                    server = new Server(txtBoxIP.Text, Convert.ToUInt16(txtBoxPuerto.Text));

                    try
                    {
                        ChangeConLbls();
                        //grBoxCon.Enabled = false;
                        stripLbl.Text = "Estado: Intentando iniciar...";

                        server.StartListening();

                        stripLbl.Text = "Estado: Escuchando conexiones entrantes...";

                        try
                        {
                            await Task.Run(server.AcceptConnection, token);
                        }

                        catch (SocketException)
                        {
                            return;
                        }

                        //try
                        //{
                        //    server.AcceptConnection(token); // Cuando una función que yo hice devuelve Task o Task<T>, no se va a ejecutar
                        //                                    // en otro hilo en realidad, como pensé en un principio, se va a ejecutar
                        //                                    // de forma sincrónica.
                        //}

                        //catch (OperationCanceledException)
                        //{
                        //    return;
                        //}

                        stripLbl.Text = "Estado: Conexión establecida.";

                        grBoxFilePath.Enabled = true;
                        grBoxFileInfo.Enabled = true;

                        _ = Task.Run(async () =>
                        {
                            while (true)
                            {
                                try
                                {
                                    byte[]? data = server.ReadData().Result;

                                    WriteFile(data);

                                    if (token.IsCancellationRequested)
                                        return;

                                    await Task.Delay(300);
                                }

                                catch (Exception ex)
                                {
                                    if (ex is NullReferenceException)
                                        return;

                                    if (progressBar1.InvokeRequired)
                                        progressBar1.Invoke(() => progressBar1.Value = 0);

                                    if (strip.InvokeRequired)
                                        strip.Invoke(() => stripLbl.Text = "Estado: Error al recibir archivo");

                                    if (ex is IOException)
                                    {
                                        IOException ioEx = ex as IOException;

                                        if (ioEx.InnerException is SocketException)
                                        {
                                            SocketException skEx = ioEx.InnerException as SocketException;

                                            Debug.WriteLine("SocketException error code: " + skEx.ErrorCode);

                                            this.Invoke(() => MessageBox.Show(skEx.Message, "Error de recepción", MessageBoxButtons.OK, MessageBoxIcon.Error));
                                        }

                                        else
                                        {
                                            Debug.WriteLine(ioEx.Message);

                                            this.Invoke(() => MessageBox.Show(ioEx.Message, "Error de recepción", MessageBoxButtons.OK, MessageBoxIcon.Error));
                                        }
                                    }

                                    else
                                    {
                                        Debug.WriteLine(ex.Message);

                                        this.Invoke(() => MessageBox.Show(ex.Message, "Error de recepción", MessageBoxButtons.OK, MessageBoxIcon.Error));
                                    }
                                }
                            }
                        }); // TODO: Hay que cancelar esta tarea cuando el servidor se cierra. Hecho.
                    }

                    catch (Exception ex)
                    {
                        ChangeConLbls();

                        if (ex is SocketException)
                            MessageBox.Show("No se ha podido iniciar el servidor, verifique los datos de conexión.", "Error al iniciar",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                        else
                            MessageBox.Show("Error: " + ex.Message, "Error al iniciar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        server.Dispose();
                        server = null;
                    }
                }

                else
                {
                    client = new Client(txtBoxIP.Text, Convert.ToUInt16(txtBoxPuerto.Text));

                    try
                    {
                        btnEstablecer.Enabled = false;
                        ChangeConLbls();
                        //grBoxCon.Enabled = false;
                        stripLbl.Text = "Estado: Intentando conectar...";

                        Func<bool> dlgSL = new Func<bool>(client.StartListening);
                        await Task.Run(dlgSL);

                        stripLbl.Text = "Estado: Conexión establecida";

                        grBoxFilePath.Enabled = true;
                        grBoxFileInfo.Enabled = true;

                        _ = Task.Run(async () =>
                        {
                            while (true)
                            {
                                try
                                {
                                    byte[]? data = client.ReadData().Result;

                                    WriteFile(data);

                                    if (token.IsCancellationRequested)
                                        return;

                                    await Task.Delay(300);
                                }

                                catch (Exception ex)
                                {
                                    if (ex is NullReferenceException)
                                        return;

                                    if (progressBar1.InvokeRequired)
                                        progressBar1.Invoke(() => progressBar1.Value = 0);

                                    if (strip.InvokeRequired)
                                        strip.Invoke(() => stripLbl.Text = "Estado: Error al recibir archivo");

                                    if (ex is IOException)
                                    {
                                        IOException ioEx = ex as IOException;

                                        if (ioEx.InnerException is SocketException)
                                        {
                                            SocketException skEx = ioEx.InnerException as SocketException;

                                            Debug.WriteLine("SocketException error code: " + skEx.ErrorCode);

                                            this.Invoke(() => MessageBox.Show(skEx.Message, "Error de recepción", MessageBoxButtons.OK, MessageBoxIcon.Error));
                                        }

                                        else
                                        {
                                            Debug.WriteLine(ioEx.Message);

                                            this.Invoke(() => MessageBox.Show(ioEx.Message, "Error de recepción", MessageBoxButtons.OK, MessageBoxIcon.Error));
                                        }
                                    }

                                    else
                                    {
                                        Debug.WriteLine(ex.Message);

                                        this.Invoke(() => MessageBox.Show(ex.Message, "Error de recepción", MessageBoxButtons.OK, MessageBoxIcon.Error));
                                    }
                                }
                            }
                        }); // TODO: Hay que cancelar esta tarea cuando se desconecta el cliente. Hecho.

                        btnEstablecer.Enabled = true;
                    }

                    catch (Exception ex)
                    {
                        btnEstablecer.Enabled = true;
                        ChangeConLbls();

                        if (ex is SocketException)
                            MessageBox.Show("No se ha podido conectar con el servidor, verifique los datos de conexión.", "Error al conectar",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                        else
                            MessageBox.Show("Error: " + ex.Message, "Error al conectar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        client.Dispose();
                        client = null;
                    }
                }
            }

            else
            {
                canTokenSource.Cancel();
                canTokenSource.Dispose();
                canTokenSource = null;

                if (rdnBtnServer.Checked)
                {
                    server.Dispose();
                    server = null;

                    btnEstablecer.Text = "Iniciar";
                }

                else
                {
                    client.Dispose();
                    client = null;

                    btnEstablecer.Text = "Conectar";
                }

                ChangeConLbls();
            }
        }

        private void ChangeConLbls()
        {
            if (rdnBtnServer.Checked)
            {
                if (conEstaReset)
                {
                    btnEstablecer.Text = "Cerrar";

                    conEstaReset = false;

                    txtBoxIP.Enabled = false;
                    txtBoxPuerto.Enabled = false;

                    rdnBtnServer.Enabled = false;
                    rdnBtnClient.Enabled = false;
                }

                else
                {
                    btnEstablecer.Text = "Iniciar";

                    stripLbl.Text = "Estado: Esperando...";

                    conEstaReset = true;

                    txtBoxIP.Enabled = true;
                    txtBoxPuerto.Enabled = true;

                    rdnBtnServer.Enabled = true;
                    rdnBtnClient.Enabled = true;

                    grBoxFilePath.Enabled = false;
                    grBoxFileInfo.Enabled = false;
                    btnEnviarCancelar.Enabled = false;

                    progressBar1.Value = 0;
                }
            }

            else
            {
                if (conEstaReset)
                {
                    btnEstablecer.Text = "Desconectar";

                    conEstaReset = false;

                    txtBoxIP.Enabled = false;
                    txtBoxPuerto.Enabled = false;

                    rdnBtnServer.Enabled = false;
                    rdnBtnClient.Enabled = false;

                    if (txtBoxPath.TextLength > 0)
                        btnEnviarCancelar.Enabled = true;
                }

                else
                {
                    btnEstablecer.Text = "Conectar";

                    stripLbl.Text = "Estado: Esperando...";

                    conEstaReset = true;

                    txtBoxIP.Enabled = true;
                    txtBoxPuerto.Enabled = true;

                    rdnBtnServer.Enabled = true;
                    rdnBtnClient.Enabled = true;

                    grBoxFilePath.Enabled = false;
                    grBoxFileInfo.Enabled = false;
                    btnEnviarCancelar.Enabled = false;

                    progressBar1.Value = 0;
                }
            }
        }

        private void WriteFile(byte[]? dataBuffer)
        {
            if (dataBuffer != null)
            {
                DialogResult res = MsgBoxInvoke();

                if (res == DialogResult.Yes)
                {
                    int bytesExtCount = Convert.ToInt32(Encoding.ASCII.GetString(new byte[] { dataBuffer[0] }));

                    List<byte> extList = new List<byte>();

                    for (int i = 1; i <= bytesExtCount; i++)
                        extList.Add(dataBuffer[i]);

                    string ext = Encoding.ASCII.GetString(extList.ToArray());

                    sfdObject.Filter = string.Format("Archivos {0} (*{1})|*{2}", ext.Substring(1, ext.Length - 1), ext, ext);

                    if (SfdInvoke() == DialogResult.OK)
                    {
                        pathReceive = sfdObject.FileName;

                        List<byte> bytesNoExt = new List<byte>(dataBuffer);

                        for (int i = 0; i <= bytesExtCount; i++)
                            bytesNoExt.RemoveAt(0);

                        using (BinaryWriter fileWriter = new BinaryWriter(File.OpenWrite(pathReceive), Encoding.Unicode))
                        {
                            fileWriter.Write(bytesNoExt.ToArray());
                            fileWriter.Flush();
                        }

                        ChangeFileInfoLbls();

                        InvokeChangeLbls("Estado: Archivo recibido");
                    }

                    else
                        InvokeChangeLbls("Estado: Archivo rechazado");

                    sfdObject.FileName = string.Empty;
                }

                else
                    InvokeChangeLbls("Estado: Archivo rechazado");
            }
        }

        private DialogResult MsgBoxInvoke()
        {
            if (this.InvokeRequired)
            {
                Func<DialogResult> dlgMsg = new Func<DialogResult>(MsgBoxInvoke);

                return this.Invoke(dlgMsg);
            }

            else
                return MessageBox.Show("¿Desea guardar el archivo recibido?", "Archivo recibido", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
        }

        private DialogResult SfdInvoke()
        {
            if (this.InvokeRequired)
            {
                Func<DialogResult> dlgSfd = new Func<DialogResult>(SfdInvoke);

                return this.Invoke(dlgSfd);
            }

            else
                return sfdObject.ShowDialog();
        }

        public void InvokeChangeLbls(string value)
        {
            if (lblProgreso.InvokeRequired || strip.InvokeRequired)
            {
                lblProgreso.Invoke(() =>
                {
                    if (lblProgreso.Text != "Progreso (Recibido):")
                        lblProgreso.Text = "Progreso (Recibido):";
                });

                strip.Invoke(() => stripLbl.Text = value);
            }

            else
            {
                if (lblProgreso.Text != "Progreso (Recibido):")
                    lblProgreso.Text = "Progreso (Recibido):";

                stripLbl.Text = value;
            }
        }

        private void ChangeFileInfoLbls()
        {
            if (lblFileName.InvokeRequired || lblFileSize.InvokeRequired || lblCreatedDate.InvokeRequired || lblModDate.InvokeRequired)
            {
                FileInfo fileInfo = new FileInfo(pathReceive);

                lblFileName.Invoke(() => lblFileName.Text = "Nombre: " + fileInfo.Name);

                double size = fileInfo.Length;
                double sizeGB = size / Math.Pow(1024, 3);
                double sizeMB = size / Math.Pow(1024, 2);
                double sizeKB = size / 1024;

                if (sizeGB >= 1)
                    lblFileSize.Invoke(() => lblFileSize.Text = "Tamaño: " + Math.Round(sizeGB, 2) + " GB");

                else if (sizeMB >= 1)
                    lblFileSize.Invoke(() => lblFileSize.Text = "Tamaño: " + Math.Round(sizeMB, 2) + " MB");

                else if (sizeKB >= 100)
                    lblFileSize.Invoke(() => lblFileSize.Text = "Tamaño: " + Math.Truncate(sizeKB) + " KB");

                else
                    lblFileSize.Invoke(() => lblFileSize.Text = "Tamaño: " + Math.Round(sizeKB, 2) + " KB");

                DateTime createdDate = DateTime.Parse(fileInfo.CreationTime.ToString(), CultureInfo.CurrentCulture.DateTimeFormat);
                DateTime modDate = DateTime.Parse(fileInfo.LastWriteTime.ToString(), CultureInfo.CurrentCulture.DateTimeFormat);

                lblCreatedDate.Invoke(() => lblCreatedDate.Text = "Creado: " + createdDate.ToShortDateString());

                lblModDate.Invoke(() => lblModDate.Text = "Modificado: " + modDate.ToShortDateString());
            }

            else
            {
                MessageBox.Show("¿Cómo provocaste este error? No debería haber pasado, el programa se cerrará.", "???",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        private async void btnEnviarCancelar_Click(object sender, EventArgs e)
        {
            if (Path.Exists(pathSend))
            {
                try
                {
                    stripLbl.Text = "Estado: Enviando archivo...";

                    if (progressBar1.Value > 0)
                        progressBar1.Value = 0;

                    lblProgreso.Text = "Progreso (Enviado):";

                    string ext = Path.GetExtension(pathSend);

                    List<byte> dataList = new List<byte>(Encoding.ASCII.GetBytes(ext.Length.ToString())); // Debido a la codificación ASCII, no puede guardarse en la misma posición (0) un número mayor a 9.
                                                                                                          // O sea que la extensión, incluyendo el punto (.), no puede superar los 9 caracteres.
                    dataList.AddRange(Encoding.ASCII.GetBytes(ext));

                    progressBar1.Value = 10;

                    dataList.AddRange(await File.ReadAllBytesAsync(pathSend));

                    progressBar1.Value = 50;

                    if (rdnBtnServer.Checked)
                        await server.WriteData(dataList.ToArray());

                    else
                        await client.WriteData(dataList.ToArray());

                    progressBar1.Value = 100;

                    stripLbl.Text = "Estado: Archivo enviado";
                }

                catch (IOException)
                {
                    ResetComponents();

                    MessageBox.Show("Se ha producido un error al enviar el archivo. Verifique la conexión e inténtelo de nuevo.",
                        "Error al enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                catch (Exception ex)
                {
                    ResetComponents();

                    MessageBox.Show("Se ha producido un error al enviar el archivo. " + ex.Message,
                        "Error al enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("La ruta especificada no corresponde a ningún archivo o es inválida.",
                        "Error al enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetComponents()
        {
            if (progressBar1.Value > 0)
                progressBar1.Value = 0;

            stripLbl.Text = "Estado: Esperando...";
        }

        private void rdnBtnServer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnBtnServer.Checked)
                btnEstablecer.Text = "Iniciar";

            else
                btnEstablecer.Text = "Conectar";
        }

        private void btnExplorar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdObject = new OpenFileDialog())
            {
                if (pathSendAnt != null)
                    ofdObject.InitialDirectory = Path.GetDirectoryName(pathSendAnt);

                else
                    ofdObject.InitialDirectory = "C:\\";

                ofdObject.Title = "Seleccionar archivo";
                ofdObject.Filter = "Todos los archivos (*.*)|*.*";
                ofdObject.Multiselect = false;

                if (ofdObject.ShowDialog() == DialogResult.OK)
                {
                    pathSend = ofdObject.FileName;

                    FileInfo fileInfo = new FileInfo(pathSend);

                    double size = fileInfo.Length;
                    double sizeGB = size / Math.Pow(1024, 3);
                    double sizeMB = size / Math.Pow(1024, 2);
                    double sizeKB = size / 1024;

                    if (sizeGB > 1.5)
                    {
                        MessageBox.Show("El archivo (" + Math.Round(sizeGB, 2) + " GB) supera el tamaño máximo permitido (1,5 GB)",
                            "Error de tamaño", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        pathSend = pathSendAnt;

                        ofdObject.Dispose();

                        return;
                    }

                    int fileExtLength = Path.GetExtension(pathSend).Length;

                    if (fileExtLength > 9)
                    {
                        MessageBox.Show("La extensión del archivo es demasiado larga ("  + fileExtLength + " caracteres). El máximo es 9.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        pathSend = pathSendAnt;

                        ofdObject.Dispose();

                        return;
                    }

                    pathSendAnt = pathSend;

                    txtBoxPath.Text = pathSend;

                    lblFileName.Text = "Nombre: " + fileInfo.Name;

                    if (sizeGB >= 1)
                        lblFileSize.Text = "Tamaño: " + Math.Round(sizeGB, 2) + " GB";

                    else if (sizeMB >= 1)
                        lblFileSize.Text = "Tamaño: " + Math.Round(sizeMB, 2) + " MB";

                    else if (sizeKB >= 100)
                        lblFileSize.Text = "Tamaño: " + Math.Truncate(sizeKB) + " KB";

                    else
                        lblFileSize.Text = "Tamaño: " + Math.Round(sizeKB, 2) + " KB";

                    DateTime createdDate = DateTime.Parse(fileInfo.CreationTime.ToString(), CultureInfo.CurrentCulture.DateTimeFormat);
                    DateTime modDate = DateTime.Parse(fileInfo.LastWriteTime.ToString(), CultureInfo.CurrentCulture.DateTimeFormat);

                    lblCreatedDate.Text = "Creado: " + createdDate.ToShortDateString();
                    lblModDate.Text = "Modificado: " + modDate.ToShortDateString();
                }
            }
        }

        private void txtBoxPath_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxPath.TextLength > 0)
            {
                btnEnviarCancelar.Enabled = true;

                pathSend = txtBoxPath.Text;
            }

            else
            {
                btnEnviarCancelar.Enabled = false;

                pathSend = string.Empty;
            }
        }

        public void ChangePgrBarValue(int value)
        {
            if (progressBar1.InvokeRequired)
                progressBar1.Invoke(() => progressBar1.Value = value);

            else
                progressBar1.Value = value;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            btnEnviarCancelar.Enabled = false;
            btnEstablecer.Enabled = false;

            rdnBtnServer.Checked = true;

            grBoxFilePath.Enabled = false;
            grBoxFileInfo.Enabled = false;

            sfdObject.Title = "Guardar archivo";
            sfdObject.RestoreDirectory = true;
        }
    }
}