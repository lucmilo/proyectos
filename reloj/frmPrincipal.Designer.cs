
namespace Proyecto_Reloj
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
            this.lblReloj = new System.Windows.Forms.Label();
            this.lblZonaHoraria = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.másOpcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cronómetroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temporizadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblReloj
            // 
            this.lblReloj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReloj.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReloj.Location = new System.Drawing.Point(12, 38);
            this.lblReloj.Name = "lblReloj";
            this.lblReloj.Size = new System.Drawing.Size(484, 96);
            this.lblReloj.TabIndex = 0;
            this.lblReloj.Text = "-Reloj-";
            this.lblReloj.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblZonaHoraria
            // 
            this.lblZonaHoraria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZonaHoraria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZonaHoraria.Location = new System.Drawing.Point(18, 166);
            this.lblZonaHoraria.Name = "lblZonaHoraria";
            this.lblZonaHoraria.Size = new System.Drawing.Size(478, 25);
            this.lblZonaHoraria.TabIndex = 1;
            this.lblZonaHoraria.Text = "-Zona Horaria-";
            this.lblZonaHoraria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.másOpcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(508, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // másOpcionesToolStripMenuItem
            // 
            this.másOpcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cronómetroToolStripMenuItem,
            this.temporizadorToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.másOpcionesToolStripMenuItem.Name = "másOpcionesToolStripMenuItem";
            this.másOpcionesToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.másOpcionesToolStripMenuItem.Text = "Más opciones";
            // 
            // cronómetroToolStripMenuItem
            // 
            this.cronómetroToolStripMenuItem.Image = global::Proyecto_Reloj.Properties.Resources.stopwatch;
            this.cronómetroToolStripMenuItem.Name = "cronómetroToolStripMenuItem";
            this.cronómetroToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.cronómetroToolStripMenuItem.Text = "Cronómetro";
            this.cronómetroToolStripMenuItem.Click += new System.EventHandler(this.cronómetroToolStripMenuItem_Click);
            // 
            // temporizadorToolStripMenuItem
            // 
            this.temporizadorToolStripMenuItem.Image = global::Proyecto_Reloj.Properties.Resources.hourglass;
            this.temporizadorToolStripMenuItem.Name = "temporizadorToolStripMenuItem";
            this.temporizadorToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.temporizadorToolStripMenuItem.Text = "Temporizador";
            this.temporizadorToolStripMenuItem.Click += new System.EventHandler(this.temporizadorToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::Proyecto_Reloj.Properties.Resources.exit;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 243);
            this.Controls.Add(this.lblZonaHoraria);
            this.Controls.Add(this.lblReloj);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reloj";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReloj;
        private System.Windows.Forms.Label lblZonaHoraria;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem másOpcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cronómetroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temporizadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}