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

namespace Password_Generator_and_Checker
{
    public partial class frmVerificador : Form
    {
        private readonly Font IniFont = new Font("Microsoft Sans Serif", 12, FontStyle.Italic);
        private readonly Font AftFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

        private readonly char[] numChArray = "0123456789".ToArray(); // 10 caracteres.
        private readonly char[] mayChArray = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ".ToArray(); // 27 caracteres.
        private readonly char[] minChArray = "abcdefghijklmnñopqrstuvwxyz".ToArray(); // 27 caracteres.
        private readonly char[] simChArray = "|°¬!\"#$%&/()='?\\¿¡´+{}¨*[]~^`,.-;:_<>@".ToArray(); // 38 caracteres.

        private readonly Stopwatch clock = new Stopwatch();

        public frmVerificador()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool showPassVer()
        {
            string result = verPass().Trim();

            switch (result)
            {
                case "El campo no puede estar vacío.":
                    lblVerRes.ForeColor = Color.Black;
                    lblVerRes.Font = IniFont;
                    lblVerRes.Text = result;

                    return false;

                case "Se ha producido un error.":
                    lblVerRes.ForeColor = Color.Red;
                    lblVerRes.Font = IniFont;
                    lblVerRes.Text = result;

                    return false;

                default:
                    lblVerRes.Font = AftFont;
                    lblVerRes.Text = result;

                    return true;
            }
        }

        private string verPass()
        {
            if (!string.IsNullOrWhiteSpace(txtBox1.Text)) Debug.WriteLine("String ingresado:\n" + txtBox1.Text + "\nLargo: "+ txtBox1.Text.Length
                + "\n\nPasando a Array de chars...\n");

            else
            {
                Debug.WriteLine("Se ingresó un string vacío.");

                return "El campo no puede estar vacío.";
            }

            char[] chArray = remBlkSpa(txtBox1.Text.ToArray());

            var verString = new StringBuilder();

            foreach (char ch in chArray)
            {
                verString.Append(ch);
            }

            Debug.WriteLine("String sin espacios en blanco:\n" + verString + "\nLargo: " + verString.Length + "\n");

            byte cntMay = 0;
            byte cntMin = 0;
            byte cntNum = 0;
            byte cntSim = 0;

            byte secuPoints = 0;

            if (chArray.Length >= 8 && chArray.Length <= 16) ++secuPoints;

            else if (chArray.Length >= 17 && chArray.Length <= 24) secuPoints += 2;

            else if (chArray.Length >= 25) secuPoints += 3;

            else Debug.WriteLine("El string tiene menos de 8 caracteres. No se suman puntos de seguridad.\n");

            try
            {
                foreach (char chIng in chArray)
                {
                    foreach (char chMay in mayChArray)
                    {
                        if (chIng == chMay)
                        {
                            Debug.WriteLine("Coincidencia encontrada.\n" + chIng + " (may)\n");

                            if (cntMay < 3) ++cntMay;

                            if (cntMay == 2) ++secuPoints;

                            break;
                        }
                    }

                    foreach (char chMin in minChArray)
                    {
                        if (chIng == chMin)
                        {
                            Debug.WriteLine("Coincidencia encontrada.\n" + chIng + " (min)\n");

                            if (cntMin < 3) ++cntMin;

                            if (cntMin == 2) ++secuPoints;

                            break;
                        }
                    }

                    foreach (char chNum in numChArray)
                    {
                        if (chIng == chNum)
                        {
                            Debug.WriteLine("Coincidencia encontrada.\n" + chIng + " (num)\n");

                            if (cntNum < 3) ++cntNum;

                            if (cntNum == 2) ++secuPoints;

                            break;
                        }
                    }

                    foreach (char chSim in simChArray)
                    {
                        if (chIng == chSim)
                        {
                            Debug.WriteLine("Coincidencia encontrada.\n" + chIng + " (sim)\n");

                            if (cntSim < 3) ++cntSim;

                            if (cntSim < 2) ++secuPoints;

                            break;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine("Excepción producida: " + ex.Message);

                return "Se ha producido un error.";
            }

            string result;

            switch (secuPoints)
            {
                case 7:
                case 6:
                    result = "Muy segura";

                    lblVerRes.ForeColor = Color.Green;

                    Debug.WriteLine("Valor de secuPoints: " + secuPoints + "\n");

                    break;

                case 5:
                case 4:
                    result = "Segura";

                    lblVerRes.ForeColor = Color.LightGreen;

                    Debug.WriteLine("Valor de secuPoints: " + secuPoints + "\n");

                    break;

                case 3:
                case 2:
                    result = "Algo segura";

                    lblVerRes.ForeColor = Color.Orange;

                    Debug.WriteLine("Valor de secuPoints: " + secuPoints + "\n");

                    break;
                case 1:
                    result = "Insegura";

                    lblVerRes.ForeColor = Color.IndianRed;

                    Debug.WriteLine("Valor de secuPoints: " + secuPoints + "\n");

                    break;

                case 0:
                    result = "Muy insegura";

                    lblVerRes.ForeColor = Color.Red;

                    Debug.WriteLine("Valor de secuPoints: " + secuPoints + "\n");

                    break;

                default:
                    Debug.WriteLine("Valor de secuPoints: " + secuPoints + "\n");

                    throw new InvalidOperationException();
            }

            return result;
        }

        private char[] remBlkSpa(char[] chArray)
        {
            var tempChList = new List<char>(chArray);

            for (int i = 0; i < chArray.Length; i++)
            {
                tempChList.Remove(' ');
            }

            return tempChList.ToArray();
        }

        private void txtBox1_TextChanged(object sender, EventArgs e)
        {
            clock.Start();

            lblCntCar.Text = "Cantidad de caracteres: " + remBlkSpa(txtBox1.Text.ToArray()).Length;

            if (showPassVer()) Debug.WriteLine("String devuelto con éxito.");

            statusStripLbl.Text = clock.Elapsed.TotalMilliseconds + " ms";

            clock.Reset();
        }
    }
}