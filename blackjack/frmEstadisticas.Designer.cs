namespace Blackjack
{
    partial class frmEstadisticas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstadisticas));
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblCodJug = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblDinGan = new System.Windows.Forms.Label();
            this.lblDinPer = new System.Windows.Forms.Label();
            this.lblPtdGan = new System.Windows.Forms.Label();
            this.lblPtdPer = new System.Windows.Forms.Label();
            this.lblCtaPed = new System.Windows.Forms.Label();
            this.lblVceQue = new System.Windows.Forms.Label();
            this.lblPtoObt = new System.Windows.Forms.Label();
            this.lblBlkJck = new System.Windows.Forms.Label();
            this.lblTpoTot = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(574, 319);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblCodJug
            // 
            this.lblCodJug.AutoSize = true;
            this.lblCodJug.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodJug.Location = new System.Drawing.Point(23, 20);
            this.lblCodJug.Name = "lblCodJug";
            this.lblCodJug.Size = new System.Drawing.Size(183, 24);
            this.lblCodJug.TabIndex = 1;
            this.lblCodJug.Text = "Código de jugador: -";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.Location = new System.Drawing.Point(22, 94);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(67, 20);
            this.lblMonto.TabIndex = 2;
            this.lblMonto.Text = "Monto: -";
            // 
            // lblDinGan
            // 
            this.lblDinGan.AutoSize = true;
            this.lblDinGan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDinGan.Location = new System.Drawing.Point(22, 145);
            this.lblDinGan.Name = "lblDinGan";
            this.lblDinGan.Size = new System.Drawing.Size(127, 20);
            this.lblDinGan.TabIndex = 3;
            this.lblDinGan.Text = "Dinero ganado: -";
            // 
            // lblDinPer
            // 
            this.lblDinPer.AutoSize = true;
            this.lblDinPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDinPer.Location = new System.Drawing.Point(22, 197);
            this.lblDinPer.Name = "lblDinPer";
            this.lblDinPer.Size = new System.Drawing.Size(126, 20);
            this.lblDinPer.TabIndex = 4;
            this.lblDinPer.Text = "Dinero perdido: -";
            // 
            // lblPtdGan
            // 
            this.lblPtdGan.AutoSize = true;
            this.lblPtdGan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPtdGan.Location = new System.Drawing.Point(23, 249);
            this.lblPtdGan.Name = "lblPtdGan";
            this.lblPtdGan.Size = new System.Drawing.Size(146, 20);
            this.lblPtdGan.TabIndex = 5;
            this.lblPtdGan.Text = "Partidas ganadas: -";
            // 
            // lblPtdPer
            // 
            this.lblPtdPer.AutoSize = true;
            this.lblPtdPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPtdPer.Location = new System.Drawing.Point(22, 300);
            this.lblPtdPer.Name = "lblPtdPer";
            this.lblPtdPer.Size = new System.Drawing.Size(145, 20);
            this.lblPtdPer.TabIndex = 6;
            this.lblPtdPer.Text = "Partidas perdidas: -";
            // 
            // lblCtaPed
            // 
            this.lblCtaPed.AutoSize = true;
            this.lblCtaPed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtaPed.Location = new System.Drawing.Point(331, 94);
            this.lblCtaPed.Name = "lblCtaPed";
            this.lblCtaPed.Size = new System.Drawing.Size(129, 20);
            this.lblCtaPed.TabIndex = 7;
            this.lblCtaPed.Text = "Cartas pedidas: -";
            // 
            // lblVceQue
            // 
            this.lblVceQue.AutoSize = true;
            this.lblVceQue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVceQue.Location = new System.Drawing.Point(331, 142);
            this.lblVceQue.Name = "lblVceQue";
            this.lblVceQue.Size = new System.Drawing.Size(142, 20);
            this.lblVceQue.TabIndex = 8;
            this.lblVceQue.Text = "Veces quedadas: -";
            // 
            // lblPtoObt
            // 
            this.lblPtoObt.AutoSize = true;
            this.lblPtoObt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPtoObt.Location = new System.Drawing.Point(331, 193);
            this.lblPtoObt.Name = "lblPtoObt";
            this.lblPtoObt.Size = new System.Drawing.Size(146, 20);
            this.lblPtoObt.TabIndex = 9;
            this.lblPtoObt.Text = "Puntos obtenidos: -";
            // 
            // lblBlkJck
            // 
            this.lblBlkJck.AutoSize = true;
            this.lblBlkJck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlkJck.Location = new System.Drawing.Point(331, 245);
            this.lblBlkJck.Name = "lblBlkJck";
            this.lblBlkJck.Size = new System.Drawing.Size(97, 20);
            this.lblBlkJck.TabIndex = 10;
            this.lblBlkJck.Text = "Blackjacks: -";
            // 
            // lblTpoTot
            // 
            this.lblTpoTot.AutoSize = true;
            this.lblTpoTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTpoTot.Location = new System.Drawing.Point(331, 297);
            this.lblTpoTot.Name = "lblTpoTot";
            this.lblTpoTot.Size = new System.Drawing.Size(109, 20);
            this.lblTpoTot.TabIndex = 11;
            this.lblTpoTot.Text = "Tiempo total: -";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(616, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // frmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 354);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTpoTot);
            this.Controls.Add(this.lblBlkJck);
            this.Controls.Add(this.lblPtoObt);
            this.Controls.Add(this.lblVceQue);
            this.Controls.Add(this.lblCtaPed);
            this.Controls.Add(this.lblPtdPer);
            this.Controls.Add(this.lblPtdGan);
            this.Controls.Add(this.lblDinPer);
            this.Controls.Add(this.lblDinGan);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblCodJug);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmEstadisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estadísticas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblCodJug;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblDinGan;
        private System.Windows.Forms.Label lblDinPer;
        private System.Windows.Forms.Label lblPtdGan;
        private System.Windows.Forms.Label lblPtdPer;
        private System.Windows.Forms.Label lblCtaPed;
        private System.Windows.Forms.Label lblVceQue;
        private System.Windows.Forms.Label lblPtoObt;
        private System.Windows.Forms.Label lblBlkJck;
        private System.Windows.Forms.Label lblTpoTot;
        private System.Windows.Forms.Label label1;
    }
}