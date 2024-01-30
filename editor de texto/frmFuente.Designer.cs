
namespace Text_editor
{
    partial class frmFuente
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
            this.lstBoxFont = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxFont = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstBoxStyle = new System.Windows.Forms.ListBox();
            this.txtBoxStyle = new System.Windows.Forms.TextBox();
            this.lstBoxSize = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxSize = new System.Windows.Forms.TextBox();
            this.grpBoxSample = new System.Windows.Forms.GroupBox();
            this.lblSample = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBoxUnderlined = new System.Windows.Forms.CheckBox();
            this.chkBoxStrikeout = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.grpBoxSample.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBoxFont
            // 
            this.lstBoxFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxFont.FormattingEnabled = true;
            this.lstBoxFont.ItemHeight = 16;
            this.lstBoxFont.Location = new System.Drawing.Point(12, 65);
            this.lstBoxFont.Name = "lstBoxFont";
            this.lstBoxFont.Size = new System.Drawing.Size(167, 132);
            this.lstBoxFont.TabIndex = 0;
            this.lstBoxFont.SelectedIndexChanged += new System.EventHandler(this.lstBoxFont_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fuente:";
            // 
            // txtBoxFont
            // 
            this.txtBoxFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxFont.Location = new System.Drawing.Point(12, 37);
            this.txtBoxFont.Name = "txtBoxFont";
            this.txtBoxFont.ReadOnly = true;
            this.txtBoxFont.Size = new System.Drawing.Size(167, 22);
            this.txtBoxFont.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(191, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Estilo de fuente:";
            // 
            // lstBoxStyle
            // 
            this.lstBoxStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxStyle.FormattingEnabled = true;
            this.lstBoxStyle.ItemHeight = 16;
            this.lstBoxStyle.Items.AddRange(new object[] {
            "Normal",
            "Cursiva",
            "Negrita",
            "Negrita cursiva"});
            this.lstBoxStyle.Location = new System.Drawing.Point(194, 65);
            this.lstBoxStyle.Name = "lstBoxStyle";
            this.lstBoxStyle.Size = new System.Drawing.Size(120, 132);
            this.lstBoxStyle.TabIndex = 4;
            this.lstBoxStyle.SelectedIndexChanged += new System.EventHandler(this.lstBoxStyle_SelectedIndexChanged);
            // 
            // txtBoxStyle
            // 
            this.txtBoxStyle.Location = new System.Drawing.Point(194, 39);
            this.txtBoxStyle.Name = "txtBoxStyle";
            this.txtBoxStyle.ReadOnly = true;
            this.txtBoxStyle.Size = new System.Drawing.Size(120, 20);
            this.txtBoxStyle.TabIndex = 5;
            // 
            // lstBoxSize
            // 
            this.lstBoxSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxSize.FormattingEnabled = true;
            this.lstBoxSize.ItemHeight = 16;
            this.lstBoxSize.Items.AddRange(new object[] {
            "8",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.lstBoxSize.Location = new System.Drawing.Point(330, 65);
            this.lstBoxSize.Name = "lstBoxSize";
            this.lstBoxSize.Size = new System.Drawing.Size(59, 132);
            this.lstBoxSize.TabIndex = 6;
            this.lstBoxSize.SelectedIndexChanged += new System.EventHandler(this.lstBoxSize_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(327, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tamaño:";
            // 
            // txtBoxSize
            // 
            this.txtBoxSize.Location = new System.Drawing.Point(330, 39);
            this.txtBoxSize.Name = "txtBoxSize";
            this.txtBoxSize.ReadOnly = true;
            this.txtBoxSize.Size = new System.Drawing.Size(59, 20);
            this.txtBoxSize.TabIndex = 8;
            // 
            // grpBoxSample
            // 
            this.grpBoxSample.Controls.Add(this.lblSample);
            this.grpBoxSample.Location = new System.Drawing.Point(194, 214);
            this.grpBoxSample.Name = "grpBoxSample";
            this.grpBoxSample.Size = new System.Drawing.Size(195, 74);
            this.grpBoxSample.TabIndex = 9;
            this.grpBoxSample.TabStop = false;
            this.grpBoxSample.Text = "Ejemplo";
            // 
            // lblSample
            // 
            this.lblSample.AutoEllipsis = true;
            this.lblSample.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSample.Location = new System.Drawing.Point(6, 16);
            this.lblSample.Name = "lblSample";
            this.lblSample.Size = new System.Drawing.Size(183, 55);
            this.lblSample.TabIndex = 10;
            this.lblSample.Text = "AaBbYyZz";
            this.lblSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBoxUnderlined);
            this.groupBox1.Controls.Add(this.chkBoxStrikeout);
            this.groupBox1.Location = new System.Drawing.Point(12, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 137);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Efectos";
            // 
            // chkBoxUnderlined
            // 
            this.chkBoxUnderlined.AutoSize = true;
            this.chkBoxUnderlined.Location = new System.Drawing.Point(6, 48);
            this.chkBoxUnderlined.Name = "chkBoxUnderlined";
            this.chkBoxUnderlined.Size = new System.Drawing.Size(77, 17);
            this.chkBoxUnderlined.TabIndex = 12;
            this.chkBoxUnderlined.Text = "Subrayado";
            this.chkBoxUnderlined.UseVisualStyleBackColor = true;
            this.chkBoxUnderlined.CheckedChanged += new System.EventHandler(this.chkBoxUnderlined_CheckedChanged);
            // 
            // chkBoxStrikeout
            // 
            this.chkBoxStrikeout.AutoSize = true;
            this.chkBoxStrikeout.Enabled = false;
            this.chkBoxStrikeout.Location = new System.Drawing.Point(6, 25);
            this.chkBoxStrikeout.Name = "chkBoxStrikeout";
            this.chkBoxStrikeout.Size = new System.Drawing.Size(69, 17);
            this.chkBoxStrikeout.TabIndex = 11;
            this.chkBoxStrikeout.Text = "Tachado";
            this.chkBoxStrikeout.UseVisualStyleBackColor = true;
            this.chkBoxStrikeout.CheckedChanged += new System.EventHandler(this.chkBoxStrikeout_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(314, 328);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(233, 328);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmFuente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 363);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBoxSample);
            this.Controls.Add(this.txtBoxSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstBoxSize);
            this.Controls.Add(this.txtBoxStyle);
            this.Controls.Add(this.lstBoxStyle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxFont);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstBoxFont);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFuente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fuente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFuente_FormClosing);
            this.grpBoxSample.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxFont;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstBoxStyle;
        private System.Windows.Forms.TextBox txtBoxStyle;
        private System.Windows.Forms.ListBox lstBoxSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxSize;
        private System.Windows.Forms.GroupBox grpBoxSample;
        private System.Windows.Forms.Label lblSample;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBoxUnderlined;
        private System.Windows.Forms.CheckBox chkBoxStrikeout;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}