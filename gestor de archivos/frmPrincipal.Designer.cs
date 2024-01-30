namespace File_Uploader
{
    partial class frmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            grBoxCon = new GroupBox();
            btnEstablecer = new Button();
            rdnBtnServer = new RadioButton();
            rdnBtnClient = new RadioButton();
            txtBoxPuerto = new TextBox();
            label2 = new Label();
            txtBoxIP = new TextBox();
            label1 = new Label();
            grBoxFilePath = new GroupBox();
            btnExplorar = new Button();
            txtBoxPath = new TextBox();
            label3 = new Label();
            progressBar1 = new ProgressBar();
            btnEnviarCancelar = new Button();
            grBoxFileInfo = new GroupBox();
            lblCreatedDate = new Label();
            lblModDate = new Label();
            lblFileSize = new Label();
            lblFileName = new Label();
            lblProgreso = new Label();
            strip = new StatusStrip();
            stripLbl = new ToolStripStatusLabel();
            label4 = new Label();
            grBoxCon.SuspendLayout();
            grBoxFilePath.SuspendLayout();
            grBoxFileInfo.SuspendLayout();
            strip.SuspendLayout();
            SuspendLayout();
            // 
            // grBoxCon
            // 
            grBoxCon.Controls.Add(btnEstablecer);
            grBoxCon.Controls.Add(rdnBtnServer);
            grBoxCon.Controls.Add(rdnBtnClient);
            grBoxCon.Controls.Add(txtBoxPuerto);
            grBoxCon.Controls.Add(label2);
            grBoxCon.Controls.Add(txtBoxIP);
            grBoxCon.Controls.Add(label1);
            grBoxCon.Location = new Point(12, 26);
            grBoxCon.Name = "grBoxCon";
            grBoxCon.Size = new Size(238, 127);
            grBoxCon.TabIndex = 0;
            grBoxCon.TabStop = false;
            grBoxCon.Text = "Datos de conexión";
            // 
            // btnEstablecer
            // 
            btnEstablecer.Location = new Point(147, 84);
            btnEstablecer.Name = "btnEstablecer";
            btnEstablecer.Size = new Size(75, 23);
            btnEstablecer.TabIndex = 6;
            btnEstablecer.Text = "Iniciar";
            btnEstablecer.UseVisualStyleBackColor = true;
            btnEstablecer.Click += btnEstablecer_Click;
            // 
            // rdnBtnServer
            // 
            rdnBtnServer.AutoSize = true;
            rdnBtnServer.Location = new Point(147, 47);
            rdnBtnServer.Name = "rdnBtnServer";
            rdnBtnServer.Size = new Size(68, 19);
            rdnBtnServer.TabIndex = 5;
            rdnBtnServer.TabStop = true;
            rdnBtnServer.Text = "Servidor";
            rdnBtnServer.UseVisualStyleBackColor = true;
            rdnBtnServer.CheckedChanged += rdnBtnServer_CheckedChanged;
            // 
            // rdnBtnClient
            // 
            rdnBtnClient.AutoSize = true;
            rdnBtnClient.Location = new Point(147, 22);
            rdnBtnClient.Name = "rdnBtnClient";
            rdnBtnClient.Size = new Size(62, 19);
            rdnBtnClient.TabIndex = 4;
            rdnBtnClient.TabStop = true;
            rdnBtnClient.Text = "Cliente";
            rdnBtnClient.UseVisualStyleBackColor = true;
            // 
            // txtBoxPuerto
            // 
            txtBoxPuerto.Location = new Point(6, 83);
            txtBoxPuerto.Name = "txtBoxPuerto";
            txtBoxPuerto.Size = new Size(100, 23);
            txtBoxPuerto.TabIndex = 3;
            txtBoxPuerto.TextChanged += txtBoxPuerto_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 63);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 2;
            label2.Text = "Puerto:";
            // 
            // txtBoxIP
            // 
            txtBoxIP.Location = new Point(6, 37);
            txtBoxIP.Name = "txtBoxIP";
            txtBoxIP.Size = new Size(100, 23);
            txtBoxIP.TabIndex = 1;
            txtBoxIP.TextChanged += txtBoxIP_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 0;
            label1.Text = "IP:";
            // 
            // grBoxFilePath
            // 
            grBoxFilePath.Controls.Add(btnExplorar);
            grBoxFilePath.Controls.Add(txtBoxPath);
            grBoxFilePath.Controls.Add(label3);
            grBoxFilePath.Location = new Point(359, 26);
            grBoxFilePath.Name = "grBoxFilePath";
            grBoxFilePath.Size = new Size(365, 78);
            grBoxFilePath.TabIndex = 1;
            grBoxFilePath.TabStop = false;
            grBoxFilePath.Text = "Archivo a subir";
            // 
            // btnExplorar
            // 
            btnExplorar.Location = new Point(285, 37);
            btnExplorar.Name = "btnExplorar";
            btnExplorar.Size = new Size(75, 23);
            btnExplorar.TabIndex = 2;
            btnExplorar.Text = "Explorar";
            btnExplorar.UseVisualStyleBackColor = true;
            btnExplorar.Click += btnExplorar_Click;
            // 
            // txtBoxPath
            // 
            txtBoxPath.Location = new Point(6, 37);
            txtBoxPath.Name = "txtBoxPath";
            txtBoxPath.Size = new Size(273, 23);
            txtBoxPath.TabIndex = 1;
            txtBoxPath.TextChanged += txtBoxPath_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 0;
            label3.Text = "Ruta del archivo:";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 264);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(712, 23);
            progressBar1.TabIndex = 2;
            // 
            // btnEnviarCancelar
            // 
            btnEnviarCancelar.Location = new Point(649, 306);
            btnEnviarCancelar.Name = "btnEnviarCancelar";
            btnEnviarCancelar.Size = new Size(75, 23);
            btnEnviarCancelar.TabIndex = 3;
            btnEnviarCancelar.Text = "Enviar";
            btnEnviarCancelar.UseVisualStyleBackColor = true;
            btnEnviarCancelar.Click += btnEnviarCancelar_Click;
            // 
            // grBoxFileInfo
            // 
            grBoxFileInfo.Controls.Add(lblCreatedDate);
            grBoxFileInfo.Controls.Add(lblModDate);
            grBoxFileInfo.Controls.Add(lblFileSize);
            grBoxFileInfo.Controls.Add(lblFileName);
            grBoxFileInfo.Location = new Point(359, 110);
            grBoxFileInfo.Name = "grBoxFileInfo";
            grBoxFileInfo.Size = new Size(365, 86);
            grBoxFileInfo.TabIndex = 4;
            grBoxFileInfo.TabStop = false;
            grBoxFileInfo.Text = "Información del archivo";
            // 
            // lblCreatedDate
            // 
            lblCreatedDate.AutoSize = true;
            lblCreatedDate.Location = new Point(208, 56);
            lblCreatedDate.Name = "lblCreatedDate";
            lblCreatedDate.Size = new Size(56, 15);
            lblCreatedDate.TabIndex = 3;
            lblCreatedDate.Text = "Creado: -";
            // 
            // lblModDate
            // 
            lblModDate.AutoSize = true;
            lblModDate.Location = new Point(208, 28);
            lblModDate.Name = "lblModDate";
            lblModDate.Size = new Size(79, 15);
            lblModDate.TabIndex = 2;
            lblModDate.Text = "Modificado: -";
            // 
            // lblFileSize
            // 
            lblFileSize.AutoSize = true;
            lblFileSize.Location = new Point(6, 56);
            lblFileSize.Name = "lblFileSize";
            lblFileSize.Size = new Size(60, 15);
            lblFileSize.TabIndex = 1;
            lblFileSize.Text = "Tamaño: -";
            // 
            // lblFileName
            // 
            lblFileName.AutoEllipsis = true;
            lblFileName.Location = new Point(6, 28);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(196, 15);
            lblFileName.TabIndex = 0;
            lblFileName.Text = "Nombre: -";
            // 
            // lblProgreso
            // 
            lblProgreso.AutoSize = true;
            lblProgreso.Location = new Point(12, 236);
            lblProgreso.Name = "lblProgreso";
            lblProgreso.Size = new Size(57, 15);
            lblProgreso.TabIndex = 5;
            lblProgreso.Text = "Progreso:";
            // 
            // strip
            // 
            strip.Items.AddRange(new ToolStripItem[] { stripLbl });
            strip.Location = new Point(0, 338);
            strip.Name = "strip";
            strip.Size = new Size(736, 22);
            strip.TabIndex = 6;
            strip.Text = "statusStrip1";
            // 
            // stripLbl
            // 
            stripLbl.Name = "stripLbl";
            stripLbl.Size = new Size(112, 17);
            stripLbl.Text = "Estado: Esperando...";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.Location = new Point(12, 166);
            label4.Name = "label4";
            label4.Size = new Size(154, 60);
            label4.TabIndex = 7;
            label4.Text = "Lucas Miloqui\r\nC# .Net";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(736, 360);
            Controls.Add(label4);
            Controls.Add(strip);
            Controls.Add(lblProgreso);
            Controls.Add(grBoxFileInfo);
            Controls.Add(btnEnviarCancelar);
            Controls.Add(progressBar1);
            Controls.Add(grBoxFilePath);
            Controls.Add(grBoxCon);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(752, 382);
            Name = "frmPrincipal";
            Text = "Gestor de archivos";
            Load += frmPrincipal_Load;
            grBoxCon.ResumeLayout(false);
            grBoxCon.PerformLayout();
            grBoxFilePath.ResumeLayout(false);
            grBoxFilePath.PerformLayout();
            grBoxFileInfo.ResumeLayout(false);
            grBoxFileInfo.PerformLayout();
            strip.ResumeLayout(false);
            strip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grBoxCon;
        private TextBox txtBoxPuerto;
        private Label label2;
        private TextBox txtBoxIP;
        private Label label1;
        private GroupBox grBoxFilePath;
        private Button btnExplorar;
        private TextBox txtBoxPath;
        private Label label3;
        private ProgressBar progressBar1;
        private Button btnEnviarCancelar;
        private GroupBox grBoxFileInfo;
        private RadioButton rdnBtnServer;
        private RadioButton rdnBtnClient;
        private Label lblFileSize;
        private Label lblFileName;
        private Label lblModDate;
        private Label lblCreatedDate;
        private Label lblProgreso;
        private Button btnEstablecer;
        private StatusStrip strip;
        private ToolStripStatusLabel stripLbl;
        private Label label4;
    }
}