
namespace Proyecto_Reloj
{
    partial class frmTemporizador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTemporizador));
            this.txtHora = new System.Windows.Forms.TextBox();
            this.txtMinuto = new System.Windows.Forms.TextBox();
            this.txtSegundo = new System.Windows.Forms.TextBox();
            this.btnEmpRea = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubHora = new System.Windows.Forms.Button();
            this.btnBajHora = new System.Windows.Forms.Button();
            this.btnSubMin = new System.Windows.Forms.Button();
            this.btnBajMin = new System.Windows.Forms.Button();
            this.btnSubSeg = new System.Windows.Forms.Button();
            this.btnBajSeg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHora
            // 
            this.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Location = new System.Drawing.Point(118, 63);
            this.txtHora.Name = "txtHora";
            this.txtHora.ReadOnly = true;
            this.txtHora.Size = new System.Drawing.Size(61, 53);
            this.txtHora.TabIndex = 0;
            this.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMinuto
            // 
            this.txtMinuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinuto.Location = new System.Drawing.Point(222, 63);
            this.txtMinuto.Name = "txtMinuto";
            this.txtMinuto.ReadOnly = true;
            this.txtMinuto.Size = new System.Drawing.Size(61, 53);
            this.txtMinuto.TabIndex = 1;
            this.txtMinuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSegundo
            // 
            this.txtSegundo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSegundo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSegundo.Location = new System.Drawing.Point(326, 63);
            this.txtSegundo.Name = "txtSegundo";
            this.txtSegundo.ReadOnly = true;
            this.txtSegundo.Size = new System.Drawing.Size(61, 53);
            this.txtSegundo.TabIndex = 2;
            this.txtSegundo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEmpRea
            // 
            this.btnEmpRea.Location = new System.Drawing.Point(410, 76);
            this.btnEmpRea.Name = "btnEmpRea";
            this.btnEmpRea.Size = new System.Drawing.Size(75, 23);
            this.btnEmpRea.TabIndex = 3;
            this.btnEmpRea.Text = "Empezar";
            this.btnEmpRea.UseVisualStyleBackColor = true;
            this.btnEmpRea.Click += new System.EventHandler(this.btnEmpRea_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(22, 76);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Restablecer";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 46);
            this.label1.TabIndex = 5;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(289, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 46);
            this.label2.TabIndex = 6;
            this.label2.Text = ":";
            // 
            // btnSubHora
            // 
            this.btnSubHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubHora.Location = new System.Drawing.Point(118, 34);
            this.btnSubHora.Name = "btnSubHora";
            this.btnSubHora.Size = new System.Drawing.Size(61, 23);
            this.btnSubHora.TabIndex = 7;
            this.btnSubHora.Text = "🠕";
            this.btnSubHora.UseVisualStyleBackColor = true;
            this.btnSubHora.Click += new System.EventHandler(this.btnSubHora_Click);
            // 
            // btnBajHora
            // 
            this.btnBajHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajHora.Location = new System.Drawing.Point(118, 122);
            this.btnBajHora.Name = "btnBajHora";
            this.btnBajHora.Size = new System.Drawing.Size(61, 23);
            this.btnBajHora.TabIndex = 8;
            this.btnBajHora.Text = "🠗";
            this.btnBajHora.UseVisualStyleBackColor = true;
            this.btnBajHora.Click += new System.EventHandler(this.btnBajHora_Click);
            // 
            // btnSubMin
            // 
            this.btnSubMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubMin.Location = new System.Drawing.Point(222, 34);
            this.btnSubMin.Name = "btnSubMin";
            this.btnSubMin.Size = new System.Drawing.Size(61, 23);
            this.btnSubMin.TabIndex = 9;
            this.btnSubMin.Text = "🠕";
            this.btnSubMin.UseVisualStyleBackColor = true;
            this.btnSubMin.Click += new System.EventHandler(this.btnSubMin_Click);
            // 
            // btnBajMin
            // 
            this.btnBajMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajMin.Location = new System.Drawing.Point(222, 122);
            this.btnBajMin.Name = "btnBajMin";
            this.btnBajMin.Size = new System.Drawing.Size(61, 23);
            this.btnBajMin.TabIndex = 10;
            this.btnBajMin.Text = "🠗";
            this.btnBajMin.UseVisualStyleBackColor = true;
            this.btnBajMin.Click += new System.EventHandler(this.btnBajMin_Click);
            // 
            // btnSubSeg
            // 
            this.btnSubSeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubSeg.Location = new System.Drawing.Point(326, 34);
            this.btnSubSeg.Name = "btnSubSeg";
            this.btnSubSeg.Size = new System.Drawing.Size(61, 23);
            this.btnSubSeg.TabIndex = 11;
            this.btnSubSeg.Text = "🠕";
            this.btnSubSeg.UseVisualStyleBackColor = true;
            this.btnSubSeg.Click += new System.EventHandler(this.btnSubSeg_Click);
            // 
            // btnBajSeg
            // 
            this.btnBajSeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajSeg.Location = new System.Drawing.Point(326, 122);
            this.btnBajSeg.Name = "btnBajSeg";
            this.btnBajSeg.Size = new System.Drawing.Size(61, 23);
            this.btnBajSeg.TabIndex = 12;
            this.btnBajSeg.Text = "🠗";
            this.btnBajSeg.UseVisualStyleBackColor = true;
            this.btnBajSeg.Click += new System.EventHandler(this.btnBajSeg_Click);
            // 
            // frmTemporizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 206);
            this.Controls.Add(this.btnBajSeg);
            this.Controls.Add(this.btnSubSeg);
            this.Controls.Add(this.btnBajMin);
            this.Controls.Add(this.btnSubMin);
            this.Controls.Add(this.btnBajHora);
            this.Controls.Add(this.btnSubHora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEmpRea);
            this.Controls.Add(this.txtSegundo);
            this.Controls.Add(this.txtMinuto);
            this.Controls.Add(this.txtHora);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTemporizador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Temporizador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.TextBox txtMinuto;
        private System.Windows.Forms.TextBox txtSegundo;
        private System.Windows.Forms.Button btnEmpRea;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubHora;
        private System.Windows.Forms.Button btnBajHora;
        private System.Windows.Forms.Button btnSubMin;
        private System.Windows.Forms.Button btnBajMin;
        private System.Windows.Forms.Button btnSubSeg;
        private System.Windows.Forms.Button btnBajSeg;
    }
}