using System.Collections.Generic;

namespace Blackjack
{
    partial class frmBlackjack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBlackjack));
            picCardPlayerL = new System.Windows.Forms.PictureBox();
            picCardPlayerR = new System.Windows.Forms.PictureBox();
            picCardIA1R = new System.Windows.Forms.PictureBox();
            picCardIA1L = new System.Windows.Forms.PictureBox();
            picCardIA2R = new System.Windows.Forms.PictureBox();
            picCardIA2L = new System.Windows.Forms.PictureBox();
            picCardBancaR = new System.Windows.Forms.PictureBox();
            picCardBancaL = new System.Windows.Forms.PictureBox();
            btnIniciar = new System.Windows.Forms.Button();
            lblApuesta = new System.Windows.Forms.Label();
            lblMonto = new System.Windows.Forms.Label();
            nudApuesta = new System.Windows.Forms.NumericUpDown();
            lblPuntosPlayer = new System.Windows.Forms.Label();
            btnPedir = new System.Windows.Forms.Button();
            btnQuedarse = new System.Windows.Forms.Button();
            lblPuntosIA1 = new System.Windows.Forms.Label();
            lblPuntosIA2 = new System.Windows.Forms.Label();
            lblPuntosBanca = new System.Windows.Forms.Label();
            lblClock = new System.Windows.Forms.Label();
            picCardPlayerAs = new System.Windows.Forms.PictureBox();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            estadísticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            btnReiniciar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)picCardPlayerL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCardPlayerR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCardIA1R).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCardIA1L).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCardIA2R).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCardIA2L).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCardBancaR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCardBancaL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudApuesta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCardPlayerAs).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // picCardPlayerL
            // 
            picCardPlayerL.Image = (System.Drawing.Image)resources.GetObject("picCardPlayerL.Image");
            picCardPlayerL.Location = new System.Drawing.Point(497, 448);
            picCardPlayerL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            picCardPlayerL.Name = "picCardPlayerL";
            picCardPlayerL.Size = new System.Drawing.Size(128, 168);
            picCardPlayerL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picCardPlayerL.TabIndex = 0;
            picCardPlayerL.TabStop = false;
            // 
            // picCardPlayerR
            // 
            picCardPlayerR.Image = (System.Drawing.Image)resources.GetObject("picCardPlayerR.Image");
            picCardPlayerR.Location = new System.Drawing.Point(713, 448);
            picCardPlayerR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            picCardPlayerR.Name = "picCardPlayerR";
            picCardPlayerR.Size = new System.Drawing.Size(128, 168);
            picCardPlayerR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picCardPlayerR.TabIndex = 1;
            picCardPlayerR.TabStop = false;
            // 
            // picCardIA1R
            // 
            picCardIA1R.Image = (System.Drawing.Image)resources.GetObject("picCardIA1R.Image");
            picCardIA1R.Location = new System.Drawing.Point(270, 388);
            picCardIA1R.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            picCardIA1R.Name = "picCardIA1R";
            picCardIA1R.Size = new System.Drawing.Size(128, 168);
            picCardIA1R.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picCardIA1R.TabIndex = 3;
            picCardIA1R.TabStop = false;
            // 
            // picCardIA1L
            // 
            picCardIA1L.Image = (System.Drawing.Image)resources.GetObject("picCardIA1L.Image");
            picCardIA1L.Location = new System.Drawing.Point(58, 388);
            picCardIA1L.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            picCardIA1L.Name = "picCardIA1L";
            picCardIA1L.Size = new System.Drawing.Size(128, 168);
            picCardIA1L.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picCardIA1L.TabIndex = 2;
            picCardIA1L.TabStop = false;
            // 
            // picCardIA2R
            // 
            picCardIA2R.Image = (System.Drawing.Image)resources.GetObject("picCardIA2R.Image");
            picCardIA2R.Location = new System.Drawing.Point(1174, 388);
            picCardIA2R.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            picCardIA2R.Name = "picCardIA2R";
            picCardIA2R.Size = new System.Drawing.Size(128, 168);
            picCardIA2R.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picCardIA2R.TabIndex = 5;
            picCardIA2R.TabStop = false;
            // 
            // picCardIA2L
            // 
            picCardIA2L.Image = (System.Drawing.Image)resources.GetObject("picCardIA2L.Image");
            picCardIA2L.Location = new System.Drawing.Point(962, 388);
            picCardIA2L.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            picCardIA2L.Name = "picCardIA2L";
            picCardIA2L.Size = new System.Drawing.Size(128, 168);
            picCardIA2L.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picCardIA2L.TabIndex = 4;
            picCardIA2L.TabStop = false;
            // 
            // picCardBancaR
            // 
            picCardBancaR.Image = (System.Drawing.Image)resources.GetObject("picCardBancaR.Image");
            picCardBancaR.Location = new System.Drawing.Point(713, 76);
            picCardBancaR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            picCardBancaR.Name = "picCardBancaR";
            picCardBancaR.Size = new System.Drawing.Size(128, 168);
            picCardBancaR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picCardBancaR.TabIndex = 7;
            picCardBancaR.TabStop = false;
            // 
            // picCardBancaL
            // 
            picCardBancaL.Image = (System.Drawing.Image)resources.GetObject("picCardBancaL.Image");
            picCardBancaL.Location = new System.Drawing.Point(497, 76);
            picCardBancaL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            picCardBancaL.Name = "picCardBancaL";
            picCardBancaL.Size = new System.Drawing.Size(128, 168);
            picCardBancaL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picCardBancaL.TabIndex = 6;
            picCardBancaL.TabStop = false;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new System.Drawing.Point(1113, 135);
            btnIniciar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new System.Drawing.Size(88, 27);
            btnIniciar.TabIndex = 8;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // lblApuesta
            // 
            lblApuesta.AutoSize = true;
            lblApuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblApuesta.Location = new System.Drawing.Point(992, 196);
            lblApuesta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblApuesta.Name = "lblApuesta";
            lblApuesta.Size = new System.Drawing.Size(60, 16);
            lblApuesta.TabIndex = 10;
            lblApuesta.Text = "Apuesta:";
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblMonto.Location = new System.Drawing.Point(1098, 719);
            lblMonto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new System.Drawing.Size(67, 20);
            lblMonto.TabIndex = 11;
            lblMonto.Text = "Monto: -";
            // 
            // nudApuesta
            // 
            nudApuesta.Location = new System.Drawing.Point(1087, 192);
            nudApuesta.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudApuesta.Name = "nudApuesta";
            nudApuesta.Size = new System.Drawing.Size(140, 23);
            nudApuesta.TabIndex = 12;
            // 
            // lblPuntosPlayer
            // 
            lblPuntosPlayer.AutoSize = true;
            lblPuntosPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblPuntosPlayer.Location = new System.Drawing.Point(634, 651);
            lblPuntosPlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPuntosPlayer.Name = "lblPuntosPlayer";
            lblPuntosPlayer.Size = new System.Drawing.Size(58, 16);
            lblPuntosPlayer.TabIndex = 13;
            lblPuntosPlayer.Text = "Puntos: -";
            // 
            // btnPedir
            // 
            btnPedir.Location = new System.Drawing.Point(517, 333);
            btnPedir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnPedir.Name = "btnPedir";
            btnPedir.Size = new System.Drawing.Size(88, 27);
            btnPedir.TabIndex = 14;
            btnPedir.Text = "Pedir";
            btnPedir.UseVisualStyleBackColor = true;
            btnPedir.Click += btnPedir_Click;
            // 
            // btnQuedarse
            // 
            btnQuedarse.Location = new System.Drawing.Point(736, 333);
            btnQuedarse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnQuedarse.Name = "btnQuedarse";
            btnQuedarse.Size = new System.Drawing.Size(88, 27);
            btnQuedarse.TabIndex = 15;
            btnQuedarse.Text = "Quedarse";
            btnQuedarse.UseVisualStyleBackColor = true;
            btnQuedarse.Click += btnQuedarse_Click;
            // 
            // lblPuntosIA1
            // 
            lblPuntosIA1.AutoSize = true;
            lblPuntosIA1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblPuntosIA1.Location = new System.Drawing.Point(191, 598);
            lblPuntosIA1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPuntosIA1.Name = "lblPuntosIA1";
            lblPuntosIA1.Size = new System.Drawing.Size(58, 16);
            lblPuntosIA1.TabIndex = 16;
            lblPuntosIA1.Text = "Puntos: -";
            // 
            // lblPuntosIA2
            // 
            lblPuntosIA2.AutoSize = true;
            lblPuntosIA2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblPuntosIA2.Location = new System.Drawing.Point(1099, 598);
            lblPuntosIA2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPuntosIA2.Name = "lblPuntosIA2";
            lblPuntosIA2.Size = new System.Drawing.Size(58, 16);
            lblPuntosIA2.TabIndex = 17;
            lblPuntosIA2.Text = "Puntos: -";
            // 
            // lblPuntosBanca
            // 
            lblPuntosBanca.AutoSize = true;
            lblPuntosBanca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblPuntosBanca.Location = new System.Drawing.Point(634, 42);
            lblPuntosBanca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPuntosBanca.Name = "lblPuntosBanca";
            lblPuntosBanca.Size = new System.Drawing.Size(61, 16);
            lblPuntosBanca.TabIndex = 18;
            lblPuntosBanca.Text = "Puntos: ?";
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblClock.Location = new System.Drawing.Point(14, 719);
            lblClock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblClock.Name = "lblClock";
            lblClock.Size = new System.Drawing.Size(87, 20);
            lblClock.TabIndex = 19;
            lblClock.Text = "00 : 00 : 00";
            // 
            // picCardPlayerAs
            // 
            picCardPlayerAs.Image = (System.Drawing.Image)resources.GetObject("picCardPlayerAs.Image");
            picCardPlayerAs.Location = new System.Drawing.Point(802, 553);
            picCardPlayerAs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            picCardPlayerAs.Name = "picCardPlayerAs";
            picCardPlayerAs.Size = new System.Drawing.Size(128, 168);
            picCardPlayerAs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picCardPlayerAs.TabIndex = 20;
            picCardPlayerAs.TabStop = false;
            picCardPlayerAs.Click += picCardPlayerAs_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { archivoToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(1350, 24);
            menuStrip1.TabIndex = 21;
            menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { estadísticasToolStripMenuItem, salirToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // estadísticasToolStripMenuItem
            // 
            estadísticasToolStripMenuItem.Name = "estadísticasToolStripMenuItem";
            estadísticasToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            estadísticasToolStripMenuItem.Text = "Estadísticas";
            estadísticasToolStripMenuItem.Click += estadísticasToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // btnReiniciar
            // 
            btnReiniciar.Location = new System.Drawing.Point(629, 333);
            btnReiniciar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new System.Drawing.Size(88, 27);
            btnReiniciar.TabIndex = 22;
            btnReiniciar.Text = "Reiniciar";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += btnReiniciar_Click;
            // 
            // frmBlackjack
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.tabletexture;
            ClientSize = new System.Drawing.Size(1350, 752);
            Controls.Add(btnReiniciar);
            Controls.Add(picCardPlayerAs);
            Controls.Add(lblClock);
            Controls.Add(lblPuntosBanca);
            Controls.Add(lblPuntosIA2);
            Controls.Add(lblPuntosIA1);
            Controls.Add(btnQuedarse);
            Controls.Add(btnPedir);
            Controls.Add(lblPuntosPlayer);
            Controls.Add(nudApuesta);
            Controls.Add(lblMonto);
            Controls.Add(lblApuesta);
            Controls.Add(btnIniciar);
            Controls.Add(picCardBancaR);
            Controls.Add(picCardBancaL);
            Controls.Add(picCardIA2R);
            Controls.Add(picCardIA2L);
            Controls.Add(picCardIA1R);
            Controls.Add(picCardIA1L);
            Controls.Add(picCardPlayerR);
            Controls.Add(picCardPlayerL);
            Controls.Add(menuStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "frmBlackjack";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Blackjack";
            FormClosing += frmBlackjack_FormClosing;
            Load += frmBlackjack_Load;
            KeyPress += frmBlackjack_KeyPress;
            ((System.ComponentModel.ISupportInitialize)picCardPlayerL).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCardPlayerR).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCardIA1R).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCardIA1L).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCardIA2R).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCardIA2L).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCardBancaR).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCardBancaL).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudApuesta).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCardPlayerAs).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picCardPlayerL;
        private System.Windows.Forms.PictureBox picCardPlayerR;
        private System.Windows.Forms.PictureBox picCardIA1R;
        private System.Windows.Forms.PictureBox picCardIA1L;
        private System.Windows.Forms.PictureBox picCardIA2R;
        private System.Windows.Forms.PictureBox picCardIA2L;
        private System.Windows.Forms.PictureBox picCardBancaR;
        private System.Windows.Forms.PictureBox picCardBancaL;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblApuesta;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown nudApuesta;
        private System.Windows.Forms.Label lblPuntosPlayer;
        private System.Windows.Forms.Button btnPedir;
        private System.Windows.Forms.Button btnQuedarse;
        private System.Windows.Forms.Label lblPuntosIA1;
        private System.Windows.Forms.Label lblPuntosIA2;
        private System.Windows.Forms.Label lblPuntosBanca;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.PictureBox picCardPlayerAs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadísticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Button btnReiniciar;
    }
}