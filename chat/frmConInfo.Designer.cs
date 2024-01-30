namespace TCP_Chat
{
    partial class frmConInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConInfo));
            btnAceptar = new Button();
            txtBoxName = new TextBox();
            txtBoxIP = new TextBox();
            txtBoxPort = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            chkAnonName = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Enabled = false;
            btnAceptar.Location = new Point(245, 137);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Ingresar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(6, 36);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(123, 23);
            txtBoxName.TabIndex = 1;
            txtBoxName.TextChanged += txtBoxName_TextChanged;
            // 
            // txtBoxIP
            // 
            txtBoxIP.Location = new Point(6, 80);
            txtBoxIP.Name = "txtBoxIP";
            txtBoxIP.Size = new Size(123, 23);
            txtBoxIP.TabIndex = 2;
            txtBoxIP.TextChanged += txtBoxIP_TextChanged;
            // 
            // txtBoxPort
            // 
            txtBoxPort.Location = new Point(6, 124);
            txtBoxPort.Name = "txtBoxPort";
            txtBoxPort.Size = new Size(123, 23);
            txtBoxPort.TabIndex = 3;
            txtBoxPort.TextChanged += txtBoxPort_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 18);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 4;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 62);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 5;
            label2.Text = "Dirección IP:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 106);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 6;
            label3.Text = "Puerto:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtBoxPort);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtBoxName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtBoxIP);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(135, 155);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingresar datos";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkAnonName);
            groupBox2.Location = new Point(200, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(120, 103);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Otras opciones";
            // 
            // chkAnonName
            // 
            chkAnonName.AutoSize = true;
            chkAnonName.Location = new Point(6, 17);
            chkAnonName.Name = "chkAnonName";
            chkAnonName.Size = new Size(76, 19);
            chkAnonName.TabIndex = 0;
            chkAnonName.Text = "Anónimo";
            chkAnonName.UseVisualStyleBackColor = true;
            chkAnonName.CheckedChanged += chkAnonName_CheckedChanged;
            // 
            // frmConInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 172);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmConInfo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Datos de conexión";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAceptar;
        private TextBox txtBoxName;
        private TextBox txtBoxIP;
        private TextBox txtBoxPort;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox chkAnonName;
    }
}