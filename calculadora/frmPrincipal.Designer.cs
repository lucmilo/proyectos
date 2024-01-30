
namespace Calculadora
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.btnRes = new System.Windows.Forms.Button();
            this.btnPun = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnPosNeg = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnSum = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnResta = new System.Windows.Forms.Button();
            this.btnMul = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btnRaizCua = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnEleCua = new System.Windows.Forms.Button();
            this.btnInv = new System.Windows.Forms.Button();
            this.btnPorc = new System.Windows.Forms.Button();
            this.btnCE = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.lblRes = new System.Windows.Forms.Label();
            this.lblAnt = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRes
            // 
            this.btnRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRes.Location = new System.Drawing.Point(216, 448);
            this.btnRes.Name = "btnRes";
            this.btnRes.Size = new System.Drawing.Size(75, 52);
            this.btnRes.TabIndex = 0;
            this.btnRes.Text = "=";
            this.btnRes.UseVisualStyleBackColor = true;
            this.btnRes.Click += new System.EventHandler(this.btnRes_Click);
            // 
            // btnPun
            // 
            this.btnPun.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPun.Location = new System.Drawing.Point(144, 448);
            this.btnPun.Name = "btnPun";
            this.btnPun.Size = new System.Drawing.Size(75, 52);
            this.btnPun.TabIndex = 1;
            this.btnPun.Text = ".";
            this.btnPun.UseVisualStyleBackColor = true;
            this.btnPun.Click += new System.EventHandler(this.btnPun_Click);
            // 
            // btn0
            // 
            this.btn0.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.Location = new System.Drawing.Point(72, 448);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(75, 52);
            this.btn0.TabIndex = 2;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // btnPosNeg
            // 
            this.btnPosNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosNeg.Location = new System.Drawing.Point(0, 448);
            this.btnPosNeg.Name = "btnPosNeg";
            this.btnPosNeg.Size = new System.Drawing.Size(75, 52);
            this.btnPosNeg.TabIndex = 3;
            this.btnPosNeg.Text = "⁺/₋";
            this.btnPosNeg.UseVisualStyleBackColor = true;
            this.btnPosNeg.Click += new System.EventHandler(this.btnPosNeg_Click);
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(0, 397);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 52);
            this.btn1.TabIndex = 4;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(72, 397);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(75, 52);
            this.btn2.TabIndex = 5;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(144, 397);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(75, 52);
            this.btn3.TabIndex = 6;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btnSum
            // 
            this.btnSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSum.Location = new System.Drawing.Point(216, 397);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(75, 52);
            this.btnSum.TabIndex = 7;
            this.btnSum.Text = "+";
            this.btnSum.UseVisualStyleBackColor = true;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(291, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem,
            this.acercadeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configuraciónToolStripMenuItem.Image")));
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            this.configuraciónToolStripMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // acercadeToolStripMenuItem
            // 
            this.acercadeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("acercadeToolStripMenuItem.Image")));
            this.acercadeToolStripMenuItem.Name = "acercadeToolStripMenuItem";
            this.acercadeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.acercadeToolStripMenuItem.Text = "Acerca de";
            this.acercadeToolStripMenuItem.Click += new System.EventHandler(this.acercadeToolStripMenuItem_Click);
            // 
            // btnResta
            // 
            this.btnResta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResta.Location = new System.Drawing.Point(216, 348);
            this.btnResta.Name = "btnResta";
            this.btnResta.Size = new System.Drawing.Size(75, 52);
            this.btnResta.TabIndex = 9;
            this.btnResta.Text = "_";
            this.btnResta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnResta.UseVisualStyleBackColor = true;
            this.btnResta.Click += new System.EventHandler(this.btnResta_Click);
            // 
            // btnMul
            // 
            this.btnMul.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMul.Location = new System.Drawing.Point(216, 298);
            this.btnMul.Name = "btnMul";
            this.btnMul.Size = new System.Drawing.Size(75, 52);
            this.btnMul.TabIndex = 10;
            this.btnMul.Text = "×";
            this.btnMul.UseVisualStyleBackColor = true;
            this.btnMul.Click += new System.EventHandler(this.btnMul_Click);
            // 
            // btnDiv
            // 
            this.btnDiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiv.Location = new System.Drawing.Point(216, 248);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(75, 52);
            this.btnDiv.TabIndex = 11;
            this.btnDiv.Text = "÷";
            this.btnDiv.UseVisualStyleBackColor = true;
            this.btnDiv.Click += new System.EventHandler(this.btnDiv_Click);
            // 
            // btnRaizCua
            // 
            this.btnRaizCua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRaizCua.Location = new System.Drawing.Point(144, 248);
            this.btnRaizCua.Name = "btnRaizCua";
            this.btnRaizCua.Size = new System.Drawing.Size(75, 52);
            this.btnRaizCua.TabIndex = 12;
            this.btnRaizCua.Text = "²√x";
            this.btnRaizCua.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Location = new System.Drawing.Point(0, 348);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(75, 52);
            this.btn4.TabIndex = 13;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn5
            // 
            this.btn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Location = new System.Drawing.Point(72, 348);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(75, 52);
            this.btn5.TabIndex = 14;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn6
            // 
            this.btn6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.Location = new System.Drawing.Point(144, 348);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(75, 52);
            this.btn6.TabIndex = 15;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btn7
            // 
            this.btn7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.Location = new System.Drawing.Point(0, 298);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(75, 52);
            this.btn7.TabIndex = 16;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // btn8
            // 
            this.btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.Location = new System.Drawing.Point(72, 298);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(75, 52);
            this.btn8.TabIndex = 17;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btn9
            // 
            this.btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.Location = new System.Drawing.Point(144, 298);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(75, 52);
            this.btn9.TabIndex = 18;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btnEleCua
            // 
            this.btnEleCua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEleCua.Location = new System.Drawing.Point(72, 248);
            this.btnEleCua.Name = "btnEleCua";
            this.btnEleCua.Size = new System.Drawing.Size(75, 52);
            this.btnEleCua.TabIndex = 19;
            this.btnEleCua.Text = "x²";
            this.btnEleCua.UseVisualStyleBackColor = true;
            // 
            // btnInv
            // 
            this.btnInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInv.Location = new System.Drawing.Point(0, 248);
            this.btnInv.Name = "btnInv";
            this.btnInv.Size = new System.Drawing.Size(75, 52);
            this.btnInv.TabIndex = 20;
            this.btnInv.Text = "¹/ₓ";
            this.btnInv.UseVisualStyleBackColor = true;
            this.btnInv.Click += new System.EventHandler(this.btnInv_Click);
            // 
            // btnPorc
            // 
            this.btnPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPorc.Location = new System.Drawing.Point(0, 197);
            this.btnPorc.Name = "btnPorc";
            this.btnPorc.Size = new System.Drawing.Size(75, 52);
            this.btnPorc.TabIndex = 21;
            this.btnPorc.Text = "%";
            this.btnPorc.UseVisualStyleBackColor = true;
            this.btnPorc.Click += new System.EventHandler(this.btnPorc_Click);
            // 
            // btnCE
            // 
            this.btnCE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCE.Location = new System.Drawing.Point(72, 197);
            this.btnCE.Name = "btnCE";
            this.btnCE.Size = new System.Drawing.Size(75, 52);
            this.btnCE.TabIndex = 22;
            this.btnCE.Text = "CE";
            this.btnCE.UseVisualStyleBackColor = true;
            this.btnCE.Click += new System.EventHandler(this.btnCE_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(144, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 52);
            this.button1.TabIndex = 23;
            this.button1.Text = "C";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(216, 197);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 52);
            this.btnBorrar.TabIndex = 24;
            this.btnBorrar.Text = "⌦";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // lblRes
            // 
            this.lblRes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRes.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRes.Location = new System.Drawing.Point(0, 89);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(291, 51);
            this.lblRes.TabIndex = 25;
            this.lblRes.Text = "0";
            this.lblRes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.lblRes, "Doble click para copiar el resultado.");
            this.lblRes.DoubleClick += new System.EventHandler(this.lblRes_DoubleClick);
            // 
            // lblAnt
            // 
            this.lblAnt.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblAnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnt.Location = new System.Drawing.Point(0, 38);
            this.lblAnt.Name = "lblAnt";
            this.lblAnt.Size = new System.Drawing.Size(291, 51);
            this.lblAnt.TabIndex = 26;
            this.lblAnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 500);
            this.Controls.Add(this.lblAnt);
            this.Controls.Add(this.lblRes);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCE);
            this.Controls.Add(this.btnPorc);
            this.Controls.Add(this.btnInv);
            this.Controls.Add(this.btnEleCua);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btnRaizCua);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.btnMul);
            this.Controls.Add(this.btnResta);
            this.Controls.Add(this.btnSum);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnPosNeg);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnPun);
            this.Controls.Add(this.btnRes);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.Text = "Calculadora simple";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrincipal_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRes;
        private System.Windows.Forms.Button btnPun;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnPosNeg;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btnSum;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercadeToolStripMenuItem;
        private System.Windows.Forms.Button btnResta;
        private System.Windows.Forms.Button btnMul;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Button btnRaizCua;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btnEleCua;
        private System.Windows.Forms.Button btnInv;
        private System.Windows.Forms.Button btnPorc;
        private System.Windows.Forms.Button btnCE;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.Label lblAnt;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

