using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Calculadora
{
    public partial class frmPrincipal : Form
    {
        private frmAcercaDe objfrmAcercaDe = new frmAcercaDe();
        private frmConfiguracion objConfiguracion = new frmConfiguracion();
        private StringBuilder ConstNum = new StringBuilder();
        private Font SFont = new Font("Microsoft Sans Serif", 21);
        private Font MFont = new Font("Microsoft Sans Serif", 27);
        private Font LFont = new Font("Microsoft Sans Serif", 32);
        private double ultNum;
        private double res;
        private string opeAnt;
        private string numAntUlt;
        private bool hayPun;
        private bool pmrOpeReal;
        private bool resObt;
        private bool opeEnProc;
        private bool nuevoInvert;
        private bool opePosRes;
        private bool pmrPorcReal;
        private bool porcEnProc;
        private byte contNumAntUlt;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Esta calculadora está en desarrollo, puede devolver cálculos erróneos ¿Desea continuar?",
            //    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //if (result == DialogResult.No) Close();
        }

        private void acercadeToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            objfrmAcercaDe.ShowDialog();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objConfiguracion.ShowDialog();
        }

        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    objfrmAcercaDe.ShowDialog();

                    break;

                case Keys.D0:
                case Keys.NumPad0:
                    btnNumIgr(0);

                    break;

                case Keys.D1:
                case Keys.NumPad1:
                    btnNumIgr(1);

                    break;

                case Keys.D2:
                case Keys.NumPad2:
                    btnNumIgr(2);

                    break;

                case Keys.D3:
                case Keys.NumPad3:
                    btnNumIgr(3);

                    break;

                case Keys.D4:
                case Keys.NumPad4:
                    btnNumIgr(4);

                    break;

                case Keys.D5:
                case Keys.NumPad5:
                    btnNumIgr(5);

                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    btnNumIgr(6);

                    break;

                case Keys.D7:
                case Keys.NumPad7:
                    btnNumIgr(7);

                    break;

                case Keys.D8:
                case Keys.NumPad8:
                    btnNumIgr(8);

                    break;

                case Keys.D9:
                case Keys.NumPad9:
                    btnNumIgr(9);

                    break;

                case Keys.Escape:
                    reiniciarCalc();

                    break;

                case Keys.Back:
                    borrarNum();

                    break;

                case Keys.Oemplus:
                case Keys.Add:
                    if (!opeEnProc)
                    {
                        selectOpe("suma");

                        opeEnProc = true;
                    }

                    break;

                case Keys.OemMinus:
                case Keys.Subtract:
                    if (!opeEnProc)
                    {
                        selectOpe("resta");

                        opeEnProc = true;
                    }

                    break;

                case Keys.Multiply:
                    if (!opeEnProc)
                    {
                        selectOpe("mult");

                        opeEnProc = true;
                    }

                    break;

                case Keys.Divide:
                    if (!opeEnProc)
                    {
                        selectOpe("div");

                        opeEnProc = true;
                    }

                    break;

                case Keys.OemPeriod:
                    AgregarPun();

                    break;

                default:
                    if (e.Shift && e.KeyCode == Keys.Oemplus && !opeEnProc)
                    {
                        selectOpe("mult");

                        opeEnProc = true;
                    }

                    else if (e.Shift && e.KeyCode == Keys.D7 && !opeEnProc)
                    {
                        selectOpe("div");

                        opeEnProc = true;
                    }

                    else if (e.Shift && e.KeyCode == Keys.D5)
                    {
                        porcEnProc = true;

                        selectOpe("porc");
                    }

                    break;
            }

            e.Handled = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Return)
            {
                Debug.WriteLine("¡ÉXITO AL APRETAR ENTER!");

                try
                {
                    darRes();
                }

                catch (ArgumentException)
                {
                    deshabilitarOpes(false);

                    lblRes.Text = "Syntax error";
                }

                resObt = true;

                return true;
            }

            Debug.WriteLine("Se apretó la tecla " + keyData + ". El foco estaba en " + ActiveControl.Name + ".");

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            btnNumIgr(0);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btnNumIgr(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            btnNumIgr(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            btnNumIgr(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            btnNumIgr(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            btnNumIgr(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            btnNumIgr(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            btnNumIgr(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            btnNumIgr(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            btnNumIgr(9);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reiniciarCalc();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            // Todavía no hace nada.
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            borrarNum();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            if (!opeEnProc)
            {
                selectOpe("suma");

                opeEnProc = true;
            }
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            if (!opeEnProc)
            {
                selectOpe("resta");

                opeEnProc = true;
            }
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            if (!opeEnProc)
            {
                selectOpe("mult");

                opeEnProc = true;
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (!opeEnProc)
            {
                selectOpe("div");

                opeEnProc = true;
            }
        }

        private void btnInv_Click(object sender, EventArgs e)
        {
            selectOpe("invert");
        }

        private void btnPun_Click(object sender, EventArgs e)
        {
            AgregarPun();
        }

        private void btnPorc_Click(object sender, EventArgs e)
        {
            porcEnProc = true;

            selectOpe("porc");
        }

        private void btnPosNeg_Click(object sender, EventArgs e)
        {
            if (lblRes.Text != "0" && ConstNum.Length > 0 && ConstNum[0].ToString() != "-")
            {
                ConstNum.Insert(0, "-", 1);

                lblRes.Text = string.Format("{0:#,##0.#######}", Convert.ToDouble(ConstNum.ToString()));
            }

            else if (lblRes.Text != "0" && ConstNum.Length > 0 && ConstNum[0].ToString() == "-")
            {
                ConstNum.Remove(0, 1);

                lblRes.Text = string.Format("{0:#,##0.#######}", Convert.ToDouble(ConstNum.ToString()));
            }

            else if (ultNum > 0 && !resObt)
            {
                res = -res;

                lblRes.Text = string.Format("{0:#,##0.#######}", Convert.ToDouble(res.ToString()));
            }

            else if (ultNum < 0 && !resObt)
            {
                res = Math.Abs(res);

                lblRes.Text = string.Format("{0:#,##0.#######}", Convert.ToDouble(res.ToString()));
            }
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            try
            {
                darRes();
            }

            catch (ArgumentException)
            {
                deshabilitarOpes(false);

                lblRes.Text = "Syntax error";
            }

            resObt = true;
        }

        private void constNumFunc(byte num)
        {
            if (ConstNum.Length <= 14 && (lblRes.Text != "0" || num != 0))
            {
                ConstNum.Append(num);

                if (hayPun && ConstNum[ConstNum.Length - 1].ToString() == "0") lblRes.Text = ConstNum.ToString();

                else lblRes.Text = string.Format("{0:#,##0.#######}", Convert.ToDouble(ConstNum.ToString()));

                lblResFontChange();

                Debug.WriteLine("Largo del ConstNum: " + ConstNum.Length);
            }

            /*
            La condición "ConstNum.Length <= 8" no funciona por alguna razón.

            Ahora funciona, pero tuve que agregar paréntesis, no sé por qué
            la precedencia de los operadores lógicos no funciona.
            
            En realidad sí funciona, yo no la estaba entendiendo bien.
            */
        }

        private void reiniciarCalc()
        {
            ConstNum.Clear();

            res = 0;

            ultNum = 0;

            contNumAntUlt = 0;

            lblRes.Text = "0";

            lblRes.Font = LFont;

            lblAnt.Text = null;

            numAntUlt = null;

            // numAntUlt = null;

            btnSum.Enabled = true;

            btnResta.Enabled = true;

            btnMul.Enabled = true;

            btnDiv.Enabled = true;

            btnBorrar.Enabled = true;

            btnRes.Enabled = true;

            btnPosNeg.Enabled = true;

            btnPun.Enabled = true;

            pmrOpeReal = false;

            lblRes.Visible = true;

            lblAnt.Visible = true;

            hayPun = false;

            opeEnProc = false;

            resObt = false;

            nuevoInvert = false;

            opePosRes = false;

            pmrPorcReal = false;

            opeAnt = null;
        }

        private void borrarNum()
        {
            if (ConstNum.Length >= 1)
            {
                ConstNum.Remove(ConstNum.Length - 1, 1);

                if ((ConstNum.Length == 0) || (ConstNum[0].ToString() == "-" && ConstNum.Length <= 1))
                {
                    try
                    {
                        ConstNum.Remove(0, 1);
                    }

                    catch (ArgumentOutOfRangeException)
                    {
                        Debug.WriteLine("Se intentó borrar un elemento inexistente en ConstNum.");
                    }

                    lblRes.Text = "0";

                    ultNum = 0;
                }

                else
                {
                    try
                    {
                        bool pmrRep = true;

                        for (int i = 0; i < ConstNum.Length; i++)
                        {
                            if (ConstNum[i].ToString() == ".")
                            {
                                for (int x = i + 1; x <= ConstNum.Length; x++)
                                {
                                    if (pmrRep)
                                    {
                                        lblRes.Text = ConstNum.ToString();

                                        pmrRep = false;

                                        continue;
                                    }

                                    lblRes.Text = string.Format("{0:#,##0.#######}", Convert.ToDouble(ConstNum.ToString()));
                                }
                            }

                            else if (ConstNum[ConstNum.Length - 1].ToString() == "0") lblRes.Text = ConstNum.ToString();

                            else
                            {
                                hayPun = false;

                                lblRes.Text = string.Format("{0:#,##0.#######}", Convert.ToDouble(ConstNum.ToString()));
                            }

                            /*
                            Todo esto seguramente sea una solución de mierda, pero es lo único que se me ocurrió
                            hasta ahora. Si mi yo del futuro lee esto, ¿Capaz se te ocurra una mejor solución que
                            esta porquería que hice?.
                            */
                        }
                    }

                    catch
                    {
                        deshabilitarOpes(false);

                        lblRes.Text = "Error";
                    }
                }

                lblResFontChange();

                Debug.WriteLine("Largo del ConstNum: " + ConstNum.Length);
            }
        }

        private void darRes()
        {
            if (res != 0 || pmrOpeReal)
            {
                switch (opeAnt.ToLower())
                {
                    case "suma":
                        realizarOpe(opeAnt, true);

                        break;

                    case "resta":
                        realizarOpe(opeAnt, true);

                        break;

                    case "mult":
                        realizarOpe(opeAnt, true);

                        break;

                    case "div":
                        realizarOpe(opeAnt, true);

                        break;

                    case "invert":
                        realizarOpe(opeAnt, true);

                        break;

                    default:
                        throw new ArgumentException("El tipo de operación no es válido.");
                }                

                if (!string.IsNullOrEmpty(overfCheck())) lblRes.Text = overfCheck();

                else
                {
                    lblAnt.Text = $"{lblAnt.Text} =";

                    lblRes.Text = string.Format("{0:#,##0.#######}", RndNum(res));

                    opePosRes = true;

                    pmrOpeReal = false;
                }
            }
        }

        private void realizarOpe(string ope, bool ultOpeParam)
        {
            switch (ope.ToLower())
            {
                case "suma":
                    if (ConstNum.Length == 0)
                    {
                        numAntUlt = res.ToString();

                        res += ultNum;

                        lblAnt.Text = ConstNum.ToString() + " +";
                    }

                    else if (!opePosRes)
                    {
                        numAntUlt = res.ToString();

                        res += Convert.ToDouble(ConstNum.ToString());

                        ultNum = Convert.ToDouble(ConstNum.ToString());

                        lblAnt.Text = ConstNum.ToString() + " +";
                    }

                    else
                    {
                        lblAnt.Text = res.ToString() + " +";
                    }

                    mostrarCuentaReali("suma", ultOpeParam);

                    opeAnt = ope;                    

                    if (!ultOpeParam) ConstNum.Clear();

                    break;

                case "resta":
                    if (!pmrOpeReal && !opePosRes)
                    {
                        res += Convert.ToDouble(ConstNum.ToString());

                        ultNum = Convert.ToDouble(ConstNum.ToString());

                        lblAnt.Text = ConstNum.ToString() + " -";
                    }

                    else if (ConstNum.Length == 0)
                    {
                        numAntUlt = res.ToString();

                        res -= ultNum;

                        lblAnt.Text = ultNum.ToString() + " -";
                    }

                    else if (!opePosRes)
                    {
                        numAntUlt = res.ToString();

                        res -= Convert.ToDouble(ConstNum.ToString());

                        ultNum = Convert.ToDouble(ConstNum.ToString());

                        lblAnt.Text = ConstNum.ToString() + " -";
                    }

                    else
                    {
                        lblAnt.Text = res.ToString() + " -";
                    }

                    mostrarCuentaReali("resta", ultOpeParam);

                    if (!ultOpeParam) ConstNum.Clear();

                    opeAnt = ope;

                    break;

                case "mult":
                    if (!pmrOpeReal && !opePosRes)
                    {
                        res += Convert.ToDouble(ConstNum.ToString());

                        ultNum = Convert.ToDouble(ConstNum.ToString());

                        lblAnt.Text = ConstNum.ToString() + " ×";
                    }

                    else if (ConstNum.Length == 0)
                    {
                        numAntUlt = res.ToString();

                        res *= ultNum;

                        lblAnt.Text = ultNum.ToString() + " ×";
                    }

                    else if (!opePosRes)
                    {
                        numAntUlt = res.ToString();

                        res *= Convert.ToDouble(ConstNum.ToString());

                        ultNum = Convert.ToDouble(ConstNum.ToString());

                        lblAnt.Text = ConstNum.ToString() + " ×";
                    }

                    else
                    {
                        lblAnt.Text = res.ToString() + " ×";
                    }

                    mostrarCuentaReali("mult", ultOpeParam);

                    if (!ultOpeParam) ConstNum.Clear();

                    opeAnt = ope;

                    break;

                case "div":
                    if (!pmrOpeReal && !opePosRes)
                    {
                        res += Convert.ToDouble(ConstNum.ToString());

                        ultNum = Convert.ToDouble(ConstNum.ToString());

                        lblAnt.Text = ConstNum.ToString() + " ÷";                        
                    }

                    else if (ConstNum.Length == 0)
                    {
                        numAntUlt = res.ToString();

                        res /= ultNum;

                        lblAnt.Text = ultNum.ToString() + " ÷";
                    }

                    else if (!opePosRes)
                    {
                        numAntUlt = res.ToString();

                        res /= Convert.ToDouble(ConstNum.ToString());

                        /*if (Convert.ToDouble(ConstNum.ToString()) != 0) res /= Convert.ToDouble(ConstNum.ToString());

                        else
                        {
                            MessageBox.Show("No se puede dividir por 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            deshabilitarOpes(true);
                        }*/

                        ultNum = Convert.ToDouble(ConstNum.ToString());

                        lblAnt.Text = ConstNum.ToString() + " ÷";
                    }

                    else
                    {
                        lblAnt.Text = res.ToString() + " ÷";
                    }

                    mostrarCuentaReali("div", ultOpeParam);

                    if (!ultOpeParam) ConstNum.Clear();

                    opeAnt = ope;

                    break;

                case "invert":
                    if (!nuevoInvert && ConstNum.Length > 0)
                    {
                        ultNum = Convert.ToDouble(ConstNum.ToString());

                        res = 1 / ultNum;                                            
                    }

                    else
                    {
                        ultNum = res;

                        res = 1 / res;                                                
                    }

                    lblAnt.Text = "1/" + "(" + ultNum + ")";

                    ConstNum.Clear();

                    opeAnt = ope;

                    break;

                case "porc":
                    if (!pmrPorcReal && ConstNum.Length > 0)
                    {
                        res = Convert.ToDouble(ConstNum.ToString());

                        res /= 100;

                        ultNum = Convert.ToDouble(ConstNum.ToString());                        
                    }

                    else
                    {
                        ultNum = res;

                        res /= 100;                        
                    }

                    lblAnt.Text = "(" + ultNum.ToString() + ")%";

                    ConstNum.Clear();

                    ConstNum.Append(res);

                    opeAnt = ope;

                    porcEnProc = false;

                    break;

                default:
                    throw new ArgumentException("El tipo de operación no es válido.", "ope");
            }

            pmrOpeReal = true;

            pmrPorcReal = true;

            nuevoInvert = true;
        }

        private string overfCheck()
        {
            if (res < -999999999 || res > 999999999)
            {
                deshabilitarOpes(false);

                resObt = true;

                lblRes.Font = LFont;

                return "Overflow";
            }

            else return null;
        }

        private void deshabilitarOpes(bool divPor0)
        {
            btnSum.Enabled = false;

            btnResta.Enabled = false;

            btnMul.Enabled = false;

            btnDiv.Enabled = false;

            btnRes.Enabled = false;

            btnBorrar.Enabled = false;

            btnPosNeg.Enabled = false;

            btnPun.Enabled = false;

            lblAnt.Text = null;

            resObt = true;

            if (divPor0)
            {
                lblRes.Visible = false;

                lblAnt.Visible = false;
            }
        }

        private void btnNumIgr(byte num)
        {
            if ((resObt && !opeEnProc) || opeAnt == "porc" || opeAnt == "invert")
            {
                reiniciarCalc();

                constNumFunc(num);
            }

            else
            {
                constNumFunc(num);

                opeEnProc = false;

                nuevoInvert = false;

                opePosRes = false;
            }
        }

        private double RndNum(double num) => Math.Round(num, objConfiguracion.GetNmrDec());

        private void lblRes_DoubleClick(object sender, EventArgs e)
        {
            reiniciarCalc();

            lblRes.Text = "Copiado";
        }

        private void selectOpe(string ope)
        {
            if (lblRes.Text != "0" && lblRes.Text != lblAnt.Text)
            {
                if (opeAnt == "porc") opeAnt = ope;

                if (ope != opeAnt && pmrOpeReal && !porcEnProc)
                {
                    realizarOpe(opeAnt, false);

                    opeAnt = ope;

                    lblRes.Text = string.Format("{0:#,##0.#######}", RndNum(res));
                }

                else
                {
                    realizarOpe(ope, false);

                    lblRes.Text = string.Format("{0:#,##0.#######}", RndNum(res));                    
                }

                if (!string.IsNullOrEmpty(overfCheck())) lblRes.Text = overfCheck();

                // opeEnProc = true;

                hayPun = false;

                resObt = false;
            }
        }

        private void mostrarCuentaReali(string ope, bool ultOpeParam)
        {
            switch (ope.ToLower())
            {
                case "suma":
                    ++contNumAntUlt;

                    if (contNumAntUlt == 1 && !ultOpeParam) numAntUlt = ConstNum.ToString();

                    else if (contNumAntUlt == 2 && !ultOpeParam) lblAnt.Text = numAntUlt + " + " + ultNum.ToString();

                    else if (contNumAntUlt > 2 || ultOpeParam) lblAnt.Text = numAntUlt + " + " + ultNum.ToString();

                    break;

                case "resta":
                    ++contNumAntUlt;

                    if (contNumAntUlt == 1 && !ultOpeParam) numAntUlt = ConstNum.ToString();

                    else if (contNumAntUlt == 2 && !ultOpeParam) lblAnt.Text = numAntUlt + " - " + ultNum.ToString();

                    else if (contNumAntUlt > 2 || ultOpeParam) lblAnt.Text = numAntUlt + " - " + ultNum.ToString();

                    break;

                case "mult":
                    ++contNumAntUlt;

                    if (contNumAntUlt == 1 && !ultOpeParam) numAntUlt = ConstNum.ToString();

                    else if (contNumAntUlt == 2 && !ultOpeParam) lblAnt.Text = numAntUlt + " × " + ultNum.ToString();

                    else if (contNumAntUlt > 2 || ultOpeParam) lblAnt.Text = numAntUlt + " × " + ultNum.ToString();

                    break;

                case "div":
                    ++contNumAntUlt;

                    if (contNumAntUlt == 1 && !ultOpeParam) numAntUlt = ConstNum.ToString();

                    else if (contNumAntUlt == 2 && !ultOpeParam) lblAnt.Text = numAntUlt + " ÷ " + ultNum.ToString();

                    else if (contNumAntUlt > 2 || ultOpeParam) lblAnt.Text = numAntUlt + " ÷ " + ultNum.ToString();

                    break;

                default:
                    throw new ArgumentException("El tipo de operación no es válido.");
            }
        }

        private void AgregarPun()
        {
            for (int i = 0; i < ConstNum.Length; i++)
            {
                if (ConstNum[i].ToString() == ".")
                {
                    hayPun = true;

                    break;
                }

                else hayPun = false;
            }

            if (!hayPun && !resObt)
            {
                if (ConstNum.Length == 0) ConstNum.Append("0.");

                else ConstNum.Append(".");

                opePosRes = true;

                lblResFontChange();

                hayPun = true;

                lblRes.Text = ConstNum.ToString();
            }
        }

        private void lblResFontChange()
        {
            var lstChLblRes = new List<char>(lblRes.Text.ToArray());

            for (int i = 0; i < lstChLblRes.Count; i++)
            {
                if (lstChLblRes[i] == ',')
                {
                    lstChLblRes.RemoveAt(i);
                }
            }

            if (lstChLblRes.Count > 9 && lstChLblRes.Count < 13) lblRes.Font = MFont;

            else if (lstChLblRes.Count >= 13) lblRes.Font = SFont;

            else lblRes.Font = LFont;
        }
    }
}