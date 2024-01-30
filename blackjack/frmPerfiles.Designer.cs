namespace Blackjack
{
    partial class frmPerfiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerfiles));
            lstboxPerfiles = new System.Windows.Forms.ListBox();
            btnAceptar = new System.Windows.Forms.Button();
            btnBorrar = new System.Windows.Forms.Button();
            btnCrear = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lstboxPerfiles
            // 
            lstboxPerfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lstboxPerfiles.FormattingEnabled = true;
            lstboxPerfiles.ItemHeight = 16;
            lstboxPerfiles.Location = new System.Drawing.Point(14, 14);
            lstboxPerfiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lstboxPerfiles.Name = "lstboxPerfiles";
            lstboxPerfiles.Size = new System.Drawing.Size(403, 132);
            lstboxPerfiles.TabIndex = 0;
            lstboxPerfiles.SelectedIndexChanged += lstboxPerfiles_SelectedIndexChanged;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new System.Drawing.Point(14, 182);
            btnAceptar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new System.Drawing.Size(88, 27);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new System.Drawing.Point(330, 182);
            btnBorrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new System.Drawing.Size(88, 27);
            btnBorrar.TabIndex = 2;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnCrear
            // 
            btnCrear.Location = new System.Drawing.Point(175, 182);
            btnCrear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new System.Drawing.Size(88, 27);
            btnCrear.TabIndex = 3;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // frmPerfiles
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(432, 223);
            Controls.Add(btnCrear);
            Controls.Add(btnBorrar);
            Controls.Add(btnAceptar);
            Controls.Add(lstboxPerfiles);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "frmPerfiles";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Seleccionar perfil";
            Load += frmPerfiles_Load;
            Click += frmPerfiles_Click;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox lstboxPerfiles;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnCrear;
    }
}