
namespace Text_editor
{
    partial class frmBuscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscar));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoButtonDown = new System.Windows.Forms.RadioButton();
            this.rdoButtonUp = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkBoxMatchCase = new System.Windows.Forms.CheckBox();
            this.chkBoxWrapAround = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Texto a buscar:";
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Location = new System.Drawing.Point(118, 15);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(206, 20);
            this.txtBoxSearch.TabIndex = 1;
            this.txtBoxSearch.TextChanged += new System.EventHandler(this.txtBoxSearch_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(330, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoButtonDown);
            this.groupBox1.Controls.Add(this.rdoButtonUp);
            this.groupBox1.Location = new System.Drawing.Point(196, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 49);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dirección";
            // 
            // rdoButtonDown
            // 
            this.rdoButtonDown.AutoSize = true;
            this.rdoButtonDown.Checked = true;
            this.rdoButtonDown.Location = new System.Drawing.Point(70, 19);
            this.rdoButtonDown.Name = "rdoButtonDown";
            this.rdoButtonDown.Size = new System.Drawing.Size(52, 17);
            this.rdoButtonDown.TabIndex = 1;
            this.rdoButtonDown.TabStop = true;
            this.rdoButtonDown.Text = "Abajo";
            this.rdoButtonDown.UseVisualStyleBackColor = true;
            this.rdoButtonDown.CheckedChanged += new System.EventHandler(this.rdoButtonDown_CheckedChanged);
            // 
            // rdoButtonUp
            // 
            this.rdoButtonUp.AutoSize = true;
            this.rdoButtonUp.Location = new System.Drawing.Point(6, 19);
            this.rdoButtonUp.Name = "rdoButtonUp";
            this.rdoButtonUp.Size = new System.Drawing.Size(52, 17);
            this.rdoButtonUp.TabIndex = 0;
            this.rdoButtonUp.Text = "Arriba";
            this.rdoButtonUp.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(330, 41);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkBoxMatchCase
            // 
            this.chkBoxMatchCase.AutoSize = true;
            this.chkBoxMatchCase.Checked = true;
            this.chkBoxMatchCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxMatchCase.Location = new System.Drawing.Point(12, 87);
            this.chkBoxMatchCase.Name = "chkBoxMatchCase";
            this.chkBoxMatchCase.Size = new System.Drawing.Size(115, 17);
            this.chkBoxMatchCase.TabIndex = 5;
            this.chkBoxMatchCase.Text = "Coincidir may y min";
            this.chkBoxMatchCase.UseVisualStyleBackColor = true;
            this.chkBoxMatchCase.CheckedChanged += new System.EventHandler(this.chkBoxMatchCase_CheckedChanged);
            // 
            // chkBoxWrapAround
            // 
            this.chkBoxWrapAround.AutoSize = true;
            this.chkBoxWrapAround.Location = new System.Drawing.Point(12, 119);
            this.chkBoxWrapAround.Name = "chkBoxWrapAround";
            this.chkBoxWrapAround.Size = new System.Drawing.Size(86, 17);
            this.chkBoxWrapAround.TabIndex = 6;
            this.chkBoxWrapAround.Text = "Recomenzar";
            this.chkBoxWrapAround.UseVisualStyleBackColor = true;
            this.chkBoxWrapAround.CheckedChanged += new System.EventHandler(this.chkBoxWrapAround_CheckedChanged);
            // 
            // frmBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 157);
            this.Controls.Add(this.chkBoxWrapAround);
            this.Controls.Add(this.chkBoxMatchCase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBuscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBuscar_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoButtonDown;
        private System.Windows.Forms.RadioButton rdoButtonUp;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkBoxMatchCase;
        private System.Windows.Forms.CheckBox chkBoxWrapAround;
    }
}