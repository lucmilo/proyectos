
namespace Proyecto_Reloj
{
    partial class frmCronometro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCronometro));
            this.txtCrono = new System.Windows.Forms.TextBox();
            this.btnEmpezarParar = new System.Windows.Forms.Button();
            this.btnRestablecerParcial = new System.Windows.Forms.Button();
            this.dgvParcial = new System.Windows.Forms.DataGridView();
            this.txtCronoParc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcial)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCrono
            // 
            this.txtCrono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCrono.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrono.Location = new System.Drawing.Point(135, 12);
            this.txtCrono.Name = "txtCrono";
            this.txtCrono.ReadOnly = true;
            this.txtCrono.Size = new System.Drawing.Size(245, 38);
            this.txtCrono.TabIndex = 0;
            this.txtCrono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEmpezarParar
            // 
            this.btnEmpezarParar.Location = new System.Drawing.Point(409, 21);
            this.btnEmpezarParar.Name = "btnEmpezarParar";
            this.btnEmpezarParar.Size = new System.Drawing.Size(75, 23);
            this.btnEmpezarParar.TabIndex = 1;
            this.btnEmpezarParar.Text = "Empezar";
            this.btnEmpezarParar.UseVisualStyleBackColor = true;
            this.btnEmpezarParar.Click += new System.EventHandler(this.btnEmpezarParar_Click);
            // 
            // btnRestablecerParcial
            // 
            this.btnRestablecerParcial.Location = new System.Drawing.Point(30, 20);
            this.btnRestablecerParcial.Name = "btnRestablecerParcial";
            this.btnRestablecerParcial.Size = new System.Drawing.Size(75, 23);
            this.btnRestablecerParcial.TabIndex = 2;
            this.btnRestablecerParcial.Text = "Parcial";
            this.btnRestablecerParcial.UseVisualStyleBackColor = true;
            this.btnRestablecerParcial.Click += new System.EventHandler(this.btnRestablecerParcial_Click);
            // 
            // dgvParcial
            // 
            this.dgvParcial.AllowUserToAddRows = false;
            this.dgvParcial.AllowUserToDeleteRows = false;
            this.dgvParcial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParcial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvParcial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParcial.Location = new System.Drawing.Point(36, 126);
            this.dgvParcial.Name = "dgvParcial";
            this.dgvParcial.ReadOnly = true;
            this.dgvParcial.RowHeadersVisible = false;
            this.dgvParcial.Size = new System.Drawing.Size(454, 116);
            this.dgvParcial.TabIndex = 3;
            // 
            // txtCronoParc
            // 
            this.txtCronoParc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCronoParc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCronoParc.Location = new System.Drawing.Point(163, 56);
            this.txtCronoParc.Name = "txtCronoParc";
            this.txtCronoParc.ReadOnly = true;
            this.txtCronoParc.Size = new System.Drawing.Size(191, 30);
            this.txtCronoParc.TabIndex = 4;
            this.txtCronoParc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmCronometro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 271);
            this.Controls.Add(this.txtCronoParc);
            this.Controls.Add(this.dgvParcial);
            this.Controls.Add(this.btnRestablecerParcial);
            this.Controls.Add(this.btnEmpezarParar);
            this.Controls.Add(this.txtCrono);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCronometro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cronómetro";
            ((System.ComponentModel.ISupportInitialize)(this.dgvParcial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCrono;
        private System.Windows.Forms.Button btnEmpezarParar;
        private System.Windows.Forms.Button btnRestablecerParcial;
        private System.Windows.Forms.DataGridView dgvParcial;
        private System.Windows.Forms.TextBox txtCronoParc;
    }
}