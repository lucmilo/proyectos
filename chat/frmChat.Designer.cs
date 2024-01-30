namespace TCP_Chat
{
    partial class frmChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChat));
            rchTxtBox = new RichTextBox();
            txtBox = new TextBox();
            btnEnviar = new Button();
            SuspendLayout();
            // 
            // rchTxtBox
            // 
            rchTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rchTxtBox.Cursor = Cursors.No;
            rchTxtBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            rchTxtBox.Location = new Point(0, 0);
            rchTxtBox.Name = "rchTxtBox";
            rchTxtBox.ReadOnly = true;
            rchTxtBox.Size = new Size(324, 488);
            rchTxtBox.TabIndex = 0;
            rchTxtBox.Text = "";
            rchTxtBox.TextChanged += rchTxtBox_TextChanged;
            // 
            // txtBox
            // 
            txtBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBox.Location = new Point(0, 494);
            txtBox.Name = "txtBox";
            txtBox.Size = new Size(231, 23);
            txtBox.TabIndex = 1;
            txtBox.TextChanged += txtBox_TextChanged;
            // 
            // btnEnviar
            // 
            btnEnviar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEnviar.Location = new Point(241, 493);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(75, 23);
            btnEnviar.TabIndex = 2;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // frmChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 517);
            Controls.Add(btnEnviar);
            Controls.Add(txtBox);
            Controls.Add(rchTxtBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(290, 471);
            Name = "frmChat";
            Text = "TCP Chat";
            Load += frmChat_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rchTxtBox;
        private TextBox txtBox;
        private Button btnEnviar;
    }
}