
namespace Password_Generator_and_Checker
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.lblTitle = new System.Windows.Forms.Label();
            this.cboBoxLenght = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.chkBoxMin = new System.Windows.Forms.CheckBox();
            this.chkBoxMay = new System.Windows.Forms.CheckBox();
            this.chkBoxNum = new System.Windows.Forms.CheckBox();
            this.chkBoxSim = new System.Windows.Forms.CheckBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusStripLbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.achivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.másHerramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verificadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(222, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(366, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Generador de Contraseñas";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboBoxLenght
            // 
            this.cboBoxLenght.FormattingEnabled = true;
            this.cboBoxLenght.Items.AddRange(new object[] {
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64"});
            this.cboBoxLenght.Location = new System.Drawing.Point(253, 120);
            this.cboBoxLenght.Name = "cboBoxLenght";
            this.cboBoxLenght.Size = new System.Drawing.Size(44, 21);
            this.cboBoxLenght.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblLength
            // 
            this.lblLength.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLength.Location = new System.Drawing.Point(184, 121);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(54, 20);
            this.lblLength.TabIndex = 3;
            this.lblLength.Text = "Largo:";
            // 
            // chkBoxMin
            // 
            this.chkBoxMin.AutoSize = true;
            this.chkBoxMin.Location = new System.Drawing.Point(320, 124);
            this.chkBoxMin.Name = "chkBoxMin";
            this.chkBoxMin.Size = new System.Drawing.Size(109, 17);
            this.chkBoxMin.TabIndex = 4;
            this.chkBoxMin.Text = "Incluir minúsculas";
            this.chkBoxMin.UseVisualStyleBackColor = true;
            this.chkBoxMin.CheckedChanged += new System.EventHandler(this.chkBoxMin_CheckedChanged);
            // 
            // chkBoxMay
            // 
            this.chkBoxMay.AutoSize = true;
            this.chkBoxMay.Location = new System.Drawing.Point(444, 124);
            this.chkBoxMay.Name = "chkBoxMay";
            this.chkBoxMay.Size = new System.Drawing.Size(112, 17);
            this.chkBoxMay.TabIndex = 5;
            this.chkBoxMay.Text = "Incluir mayúsculas";
            this.chkBoxMay.UseVisualStyleBackColor = true;
            this.chkBoxMay.CheckedChanged += new System.EventHandler(this.chkBoxMay_CheckedChanged);
            // 
            // chkBoxNum
            // 
            this.chkBoxNum.AutoSize = true;
            this.chkBoxNum.Location = new System.Drawing.Point(320, 163);
            this.chkBoxNum.Name = "chkBoxNum";
            this.chkBoxNum.Size = new System.Drawing.Size(97, 17);
            this.chkBoxNum.TabIndex = 6;
            this.chkBoxNum.Text = "Incluir números";
            this.chkBoxNum.UseVisualStyleBackColor = true;
            this.chkBoxNum.CheckedChanged += new System.EventHandler(this.chkBoxNum_CheckedChanged);
            // 
            // chkBoxSim
            // 
            this.chkBoxSim.AutoSize = true;
            this.chkBoxSim.Location = new System.Drawing.Point(444, 163);
            this.chkBoxSim.Name = "chkBoxSim";
            this.chkBoxSim.Size = new System.Drawing.Size(99, 17);
            this.chkBoxSim.TabIndex = 7;
            this.chkBoxSim.Text = "Incluir símbolos";
            this.chkBoxSim.UseVisualStyleBackColor = true;
            this.chkBoxSim.CheckedChanged += new System.EventHandler(this.chkBoxSim_CheckedChanged);
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(603, 144);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 23);
            this.btnGen.TabIndex = 9;
            this.btnGen.Text = "Generar";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // txtPass
            // 
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPass.Location = new System.Drawing.Point(148, 229);
            this.txtPass.Name = "txtPass";
            this.txtPass.ReadOnly = true;
            this.txtPass.Size = new System.Drawing.Size(609, 20);
            this.txtPass.TabIndex = 10;
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLbl1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 354);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(769, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusStripLbl1
            // 
            this.statusStripLbl1.Name = "statusStripLbl1";
            this.statusStripLbl1.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.achivoToolStripMenuItem,
            this.másHerramientasToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(769, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // achivoToolStripMenuItem
            // 
            this.achivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.achivoToolStripMenuItem.Name = "achivoToolStripMenuItem";
            this.achivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.achivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salirToolStripMenuItem.Image")));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // másHerramientasToolStripMenuItem
            // 
            this.másHerramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verificadorToolStripMenuItem});
            this.másHerramientasToolStripMenuItem.Name = "másHerramientasToolStripMenuItem";
            this.másHerramientasToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.másHerramientasToolStripMenuItem.Text = "Más herramientas";
            // 
            // verificadorToolStripMenuItem
            // 
            this.verificadorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("verificadorToolStripMenuItem.Image")));
            this.verificadorToolStripMenuItem.Name = "verificadorToolStripMenuItem";
            this.verificadorToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.verificadorToolStripMenuItem.Text = "Verificador";
            this.verificadorToolStripMenuItem.Click += new System.EventHandler(this.verificadorToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("acercaDeToolStripMenuItem.Image")));
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 376);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.chkBoxSim);
            this.Controls.Add(this.chkBoxNum);
            this.Controls.Add(this.chkBoxMay);
            this.Controls.Add(this.chkBoxMin);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cboBoxLenght);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(877, 462);
            this.MinimumSize = new System.Drawing.Size(785, 415);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generador de Contraseñas y Verificador";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cboBoxLenght;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.CheckBox chkBoxMin;
        private System.Windows.Forms.CheckBox chkBoxMay;
        private System.Windows.Forms.CheckBox chkBoxNum;
        private System.Windows.Forms.CheckBox chkBoxSim;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLbl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem achivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem másHerramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verificadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
    }
}

