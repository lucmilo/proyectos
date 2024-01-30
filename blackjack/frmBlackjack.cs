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
using System.Security.Cryptography;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Data.SqlClient;
using System.Threading;

namespace Blackjack
{
    public partial class frmBlackjack : Form
    {
        private PictureBox[] picBoxArray = new PictureBox[9]; // Array donde se guarda la "imagen" de cada carta.

        private ushort[] valCtas = new ushort[9]; // Array donde se guarda el "valor" de cada carta.

        private bool ctaLORPlayer; // Booleano alternador entre carta izquierda y derecha para el jugador.
        private bool ctaLORIA1; // Booleano alternador entre carta izquierda y derecha para la IA1.
        private bool ctaLORIA2; // Booleano alternador entre carta izquierda y derecha para la IA2.
        private bool ctaLORBanca; // Booleano alternador entre carta izquierda y derecha para la banca.
        private bool tcoAsPlayer; // Booleano que determina si ya le tocó As al jugador.
        private bool tcoAsIA1; // Booleano que determina si ya le tocó As a la IA 1.
        private bool tcoAsIA2; // Booleano que determina si ya le tocó As a la IA 2.
        private bool tcoAsBanca; // Booleano que determina si ya le tocó As a la banca.
        private bool jgoIniciado; // Booleano que indica que ya empezó una partida.
        private bool noPdeMasIA1; // Booleano que indica que la IA1 no pide más.
        private bool noPdeMasIA2; // Booleano que indica que la IA2 no pide más.
        private bool camValorAsIA1; // Booleano que determina si ya se le cambió el valor a la As de la IA1.
        private bool camValorAsIA2; // Booleano que determina si ya se le cambió el valor a la As de la IA2.
        private bool camValorAsBanca; // Booleano que determina si ya se le cambió el valor a la As de la banca.

        private Random rndGen = new Random();

        private Timer stopWatchUpdTimer = new Timer(); // Temporizador para el cronómetro del juego.
        private Stopwatch clock = new Stopwatch();
        private Stopwatch pdrCartaBancaClock = new Stopwatch();
        private delegate void delUpdClockLbl(string time);
        private delegate void delUpdPtoBancaLbl(byte pto);

        private string cdsFolder;

        private byte cntCtasPdasPlayer = 2; // Contador de cartas que pidió el jugador. Empieza en 2 porque siempre se empieza con 2 cartas.
        private byte ptoBanca = 0;
        private byte ptoPlayer = 0;
        private byte ptoIA1 = 0;
        private byte ptoIA2 = 0;
        private byte turno = 0;
        private int mtoPlayer;

        private StringBuilder strBlrCheats = new StringBuilder();

        private static ushort codJug;
        private uint dinGan;
        private uint dinPer;
        private uint ptdGan;
        private uint ptdPer;
        private uint ctaPed;
        private uint vceQue;
        private uint ptoObt;
        private uint blkJck;
        private TimeSpan tpoTot;

        public frmBlackjack()
        {
            InitializeComponent();

            setPicBoxArray();

            //var tmeSpan = TimeSpan.FromDays(4.3);
            //Debug.WriteLine(tmeSpan.ToString());

            nudApuesta.Minimum = 0;
            nudApuesta.Maximum = 10000000;
            nudApuesta.Value = 50;

            btnPedir.Visible = false;
            btnQuedarse.Visible = false;
            btnReiniciar.Visible = false;

            lblPuntosBanca.Visible = false;
            lblPuntosPlayer.Visible = false;
            lblPuntosIA1.Visible = false;
            lblPuntosIA2.Visible = false;

            lblClock.Visible = false;

            picCardPlayerAs.Visible = false;

            stopWatchUpdTimer.Interval = 1000;
            stopWatchUpdTimer.AutoReset = true;

            stopWatchUpdTimer.Elapsed += new ElapsedEventHandler(updLblClockMethod);

            lblMonto.Text = "Monto: $" + mtoPlayer;

            var dirAllFolders = Directory.EnumerateDirectories(Directory.GetCurrentDirectory());

            if (dirAllFolders.Count() > 16)
            {
                MessageBox.Show("Se han detectado directorios no nativos a la aplicación.", "Error de ejecución",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
                return;
            }

            else if (dirAllFolders.Count() < 16)
            {
                MessageBox.Show("Faltan directorios en el directorio raíz de la aplicación.", "Error de ejecución",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
                return;
            }

            string[] dirValidNames = new string[] { "cs", "de", "es", "fr", "it", "ja", "ko", "pl", "pt-BR", "ru", "runtimes",
            "sounds", "textures", "tr", "zh-Hans", "zh-Hant"};

            for (int i = 0; i < dirAllFolders.Count(); i++)
            {
                if (Path.GetFileNameWithoutExtension(dirAllFolders.ElementAt(i)) != dirValidNames[i])
                {
                    MessageBox.Show("Los nombres de los directorios no pueden ser cambiados.", "Error de ejecución",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Close();
                    return;
                }
            }

            var texCount = Directory.EnumerateFiles(dirAllFolders.ElementAt(12));

            if (texCount.Count() > 19)
            {
                MessageBox.Show("Hay archivos no nativos en la carpeta \"textures\".", "Error de ejecución",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
                return;
            }

            else if (texCount.Count() < 19)
            {
                MessageBox.Show("Faltan archivos en la carpeta \"textures\".", "Error de ejecución",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
                return;
            }

            cdsFolder = dirAllFolders.ElementAt(12);

            //DateTime dte = DateTime.Parse("2001/10/03 04:25 pm", CultureInfo.CurrentCulture.DateTimeFormat);
            //Debug.WriteLine(dte.ToShortTimeString());
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (nudApuesta.Value > mtoPlayer)
            {
                MessageBox.Show("No alcanza el monto para hacer esta apuesta.", "Monto insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                nudApuesta.Value = mtoPlayer;

                nudApuesta.Focus();

                return;
            }

            else if (nudApuesta.Value > 1000000)
            {
                MessageBox.Show("La apuesta máxima es de $1.000.000.", "Apuesta máxima superada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                nudApuesta.Value = mtoPlayer;

                nudApuesta.Focus();

                return;
            }

            stopWatchUpdTimer.Start();
            clock.Start();

            IniciarJuego();

            lblPuntosPlayer.Text = "Puntos: " + ptoPlayer;
            lblPuntosIA1.Text = "Puntos: " + ptoIA1;
            lblPuntosIA2.Text = "Puntos: " + ptoIA2;

            btnIniciar.Visible = false;

            nudApuesta.Visible = false;
            lblApuesta.Visible = false;

            btnPedir.Visible = true;
            btnQuedarse.Visible = true;

            lblPuntosBanca.Visible = true;
            lblPuntosPlayer.Visible = true;
            lblPuntosIA1.Visible = true;
            lblPuntosIA2.Visible = true;

            lblClock.Visible = true;

            updLblMto(mtoPlayer - (int)nudApuesta.Value);
            mtoPlayer -= (int)nudApuesta.Value;

            Debug.WriteLine("Banca: " + ptoBanca + "\nIA1: " + ptoIA1 + "\nIA2: " + ptoIA2 + "\nPlayer: " + ptoPlayer + "\n");
        }

        private void btnPedir_Click(object sender, EventArgs e)
        {
            cntCtasPdasPlayer++;

            ctaPed++;

            if (pdrCartaJugador() == 0)
                Debug.WriteLine("Carta devuelta correctamente al jugador.");

            else
            {
                Debug.WriteLine("Ocurrió un error al devolver una carta al jugador.");

                return;
            }

            if (pdrCartaIAs() == 0)
                Debug.WriteLine("Cartas devueltas correctamente a las IAs.");

            else
            {
                Debug.WriteLine("Las dos o una de las dos IAs no recibió carta.");

                return;
            }
        }

        private void btnQuedarse_Click(object sender, EventArgs e)
        {
            vceQue++;

            if (pdrCartaIAs() == 0)
                Debug.WriteLine("Cartas devueltas correctamente a las IAs.");

            else
                Debug.WriteLine("Las dos o una de las dos IAs no recibió carta.");

            Debug.WriteLine("IA1 no pide cartas? " + noPdeMasIA1 + "\nIA2 no pide cartas? " + noPdeMasIA2);

            if (noPdeMasIA1 && noPdeMasIA2)
            {
                btnPedir.Enabled = false;
                btnQuedarse.Enabled = false;

                chkPto((byte)valCtas[0], 0);
                updBcaPicBoxes();

                updBcaPtosLbl();

                Debug.WriteLine("Puntos de la banca: " + ptoBanca);

                //Thread t = new Thread(loopPdrCartasBanca);
                //t.Name = "Hilo de la banca";
                //t.Start();
                //t.Join();

                //Debug.WriteLine("Hilo banca terminado.");

                pdrCartaBancaClock.Start();

                while (ptoBanca < 17)
                {
                    if (pdrCartaBancaClock.Elapsed >= TimeSpan.FromMilliseconds(1000))
                    {
                        pdrCartaBanca();
                        updBcaPicBoxes();

                        updBcaPtosLbl();

                        pdrCartaBancaClock.Restart();

                        Debug.WriteLine("Puntos de la banca: " + ptoBanca);
                    }
                }

                pdrCartaBancaClock.Stop();

                if ((ptoPlayer > ptoBanca || ptoBanca > 21) && ptoPlayer <= 20)
                {
                    RlzCalculoApuesta(1.5f);

                    Debug.WriteLine("El jugador ganó dinero.");
                }

                else if (cntCtasPdasPlayer > 2 && ptoPlayer == 21 && ptoPlayer != ptoBanca)
                {
                    RlzCalculoApuesta(2);

                    Debug.WriteLine("El jugador ganó dinero con 21 y con más de 2 cartas.");
                }

                else if (cntCtasPdasPlayer == 2 && ptoPlayer == 21 && ptoPlayer != ptoBanca)
                {
                    blkJck++;

                    RlzCalculoApuesta(3);

                    Debug.WriteLine("¡Blackjack!");

                    MessageBox.Show("¡Felicidades, hiciste Blackjack!", "¡Blackjack!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (ptoPlayer == ptoBanca && ptoPlayer <= 21 && ptoBanca <= 21)
                {
                    RlzCalculoApuesta(1, true);

                    Debug.WriteLine("Jugada nula. Se le devolvió la apuesta al jugador.");
                }

                else
                {
                    dinPer += Convert.ToUInt32(nudApuesta.Value);

                    ptdPer++;

                    lblMonto.Text = "Monto: $" + mtoPlayer + " (-" + nudApuesta.Value + ")";

                    Debug.WriteLine("El jugador perdió dinero.");
                }

                ptoObt += ptoPlayer;
                tpoTot += clock.Elapsed;

                clock.Reset();
                stopWatchUpdTimer.Stop();

                GdrEstadisticasNuevas();

                btnReiniciar.Visible = true;
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            btnReiniciar.Visible = false;
            btnPedir.Visible = false;
            btnQuedarse.Visible = false;

            lblPuntosBanca.Visible = false;
            lblPuntosIA1.Visible = false;
            lblPuntosIA2.Visible = false;
            lblPuntosPlayer.Visible = false;
            lblClock.Visible = false;

            btnIniciar.Visible = true;
            lblApuesta.Visible = true;
            nudApuesta.Visible = true;

            picBoxArray[8].Visible = false;

            jgoIniciado = false;

            lblMonto.Text = "Monto: $" + mtoPlayer;

            lblPuntosBanca.Text = "Puntos: ?";

            tcoAsBanca = false;
            tcoAsIA1 = false;
            tcoAsIA2 = false;
            tcoAsPlayer = false;

            noPdeMasIA1 = false;
            noPdeMasIA2 = false;

            camValorAsBanca = false;
            camValorAsIA1 = false;
            camValorAsIA2 = false;

            cntCtasPdasPlayer = 2;

            picBoxArray[8].Enabled = true;

            try
            {
                for (int i = 0; i < 8; i++)
                    picBoxArray[i].Image = GetUSDCard();
            }

            catch (FileNotFoundException)
            {
                MessageBox.Show("Se ha producido un error al intentar acceder a un archivo de la carpeta \"textures\".", "Error de acceso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }

            for (int i = 0; i < 9; i++)
                valCtas[i] = 0;
        }

        private void RlzCalculoApuesta(float mult, bool jdaNula = false)
        {
            int dinGndOPrd;

            dinGndOPrd = Convert.ToInt32((float)nudApuesta.Value * mult);
            mtoPlayer += dinGndOPrd;

            if (!jdaNula)
            {
                dinGan += Convert.ToUInt32(dinGndOPrd - (int)nudApuesta.Value);

                ptdGan++;

                lblMonto.Text = "Monto: $" + mtoPlayer + " (+" + (dinGndOPrd - (int)nudApuesta.Value) + ")";
            }

            else
                lblMonto.Text = "Monto: $" + mtoPlayer + " (+0)";
        }

        private void IniciarJuego()
        {
            ptoBanca = 0;
            ptoIA1 = 0;
            ptoIA2 = 0;
            ptoPlayer = 0;

            turno = 0;

            btnPedir.Enabled = true;
            btnQuedarse.Enabled = true;

            for (int i = 0; i < 8; i++)
            {
                byte pto = getPtoCarta(turno);

                if (pto != 11 || turno != 3)
                    valCtas[i] = pto;

                else
                    valCtas[8] = pto;

                switch (turno) // Instrucción Switch para evaluar el turno del que le toca carta.
                {
                    case 0:
                        if (pto == 11)
                            tcoAsBanca = true;

                        if (i > 0)
                            chkPto(pto, i);

                        ptoBanca += pto;

                        break;

                    case 1:
                        if (pto == 11)
                            tcoAsIA1 = true;

                        chkPto(pto, i);

                        ptoIA1 += pto;

                        break;

                    case 2:
                        if (pto == 11)
                            tcoAsIA2 = true;

                        chkPto(pto, i);

                        ptoIA2 += pto;

                        break;

                    case 3:
                        if (pto == 11)
                        {
                            chkPto(pto, 8);

                            picCardPlayerAs.Visible = true;

                            tcoAsPlayer = true;
                        }

                        else
                            chkPto(pto, i);

                        ptoPlayer += pto;

                        break;
                }
            }

            jgoIniciado = true;
        }

        private void chkPto(byte pto, int cta)
        {
            try
            {
                switch (pto) // Otra instrucción Switch para evaluar cuánto vale la carta recibida y establecer la imagen correcta.
                {
                    case 2:
                        //picBoxArray[cta].Image = Get2Card();
                        if (picBoxArray[cta].InvokeRequired)
                            Invoke(() => picBoxArray[cta].Image = Get2Card());

                        else
                            picBoxArray[cta].Image = Get2Card();

                        break;

                    case 3:
                        //picBoxArray[cta].Image = Get3Card();
                        if (picBoxArray[cta].InvokeRequired)
                            Invoke(() => picBoxArray[cta].Image = Get3Card());

                        else
                            picBoxArray[cta].Image = Get3Card();

                        break;

                    case 4:
                        //picBoxArray[cta].Image = Get4Card();
                        if (picBoxArray[cta].InvokeRequired)
                            Invoke(() => picBoxArray[cta].Image = Get4Card());

                        else
                            picBoxArray[cta].Image = Get4Card();

                        break;

                    case 5:
                        //picBoxArray[cta].Image = Get5Card();
                        if (picBoxArray[cta].InvokeRequired)
                            Invoke(() => picBoxArray[cta].Image = Get5Card());

                        else
                            picBoxArray[cta].Image = Get5Card();

                        break;

                    case 6:
                        //picBoxArray[cta].Image = Get6Card();
                        if (picBoxArray[cta].InvokeRequired)
                            Invoke(() => picBoxArray[cta].Image = Get6Card());

                        else
                            picBoxArray[cta].Image = Get6Card();

                        break;

                    case 7:
                        //picBoxArray[cta].Image = Get7Card();
                        if (picBoxArray[cta].InvokeRequired)
                            Invoke(() => picBoxArray[cta].Image = Get7Card());

                        else
                            picBoxArray[cta].Image = Get7Card();

                        break;

                    case 8:
                        //picBoxArray[cta].Image = Get8Card();
                        if (picBoxArray[cta].InvokeRequired)
                            Invoke(() => picBoxArray[cta].Image = Get8Card());

                        else
                            picBoxArray[cta].Image = Get8Card();

                        break;

                    case 9:
                        //picBoxArray[cta].Image = Get9Card();
                        if (picBoxArray[cta].InvokeRequired)
                            Invoke(() => picBoxArray[cta].Image = Get9Card());

                        else
                            picBoxArray[cta].Image = Get9Card();

                        break;

                    case 10:
                        //picBoxArray[cta].Image = Get10Cards();
                        if (picBoxArray[cta].InvokeRequired)
                            Invoke(() => picBoxArray[cta].Image = Get10Cards());

                        else
                            picBoxArray[cta].Image = Get10Cards();

                        break;

                    case 11:
                        //picBoxArray[cta].Image = GetACard();
                        if (picBoxArray[cta].InvokeRequired)
                            Invoke(() => picBoxArray[cta].Image = GetACard());

                        else
                            picBoxArray[cta].Image = GetACard();

                        break;
                }
            }

            catch (FileNotFoundException)
            {
                MessageBox.Show("No se ha podido encontrar un archivo necesario en la carpeta \"textures\".", "Error de acceso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
            }

            if (!jgoIniciado)
            {
                if (cta == 1)
                    turno = 1;

                else if (cta == 3)
                    turno = 2;

                else if (cta == 5)
                    turno = 3;
            }
        }

        private byte getPtoCarta(byte crdRequester)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] rngArray = new byte[128];

                rng.GetBytes(rngArray);

                byte rngArraySel = (byte)rndGen.Next(0, 127);

                if (rngArray[rngArraySel] >= 0 && rngArray[rngArraySel] <= 24)
                    return 2;

                else if (rngArray[rngArraySel] >= 25 && rngArray[rngArraySel] <= 49)
                    return 3;

                else if (rngArray[rngArraySel] >= 50 && rngArray[rngArraySel] <= 74)
                    return 4;

                else if (rngArray[rngArraySel] >= 75 && rngArray[rngArraySel] <= 99)
                    return 5;

                else if (rngArray[rngArraySel] >= 100 && rngArray[rngArraySel] <= 124)
                    return 6;

                else if (rngArray[rngArraySel] >= 125 && rngArray[rngArraySel] <= 149)
                    return 7;

                else if (rngArray[rngArraySel] >= 150 && rngArray[rngArraySel] <= 174)
                    return 8;

                else if (rngArray[rngArraySel] >= 175 && rngArray[rngArraySel] <= 199)
                    return 9;

                else if (rngArray[rngArraySel] >= 200 && rngArray[rngArraySel] <= 224)
                    return 10;

                else if (crdRequester == 0 && !tcoAsBanca)
                    return 11;

                else if (crdRequester == 1 && !tcoAsIA1)
                    return 11;

                else if (crdRequester == 2 && !tcoAsIA2)
                    return 11;

                else if (crdRequester == 3 && !tcoAsPlayer)
                    return 11;

                else
                    return 2;
            }
        }

        private Image Get2Card() => Image.FromFile(cdsFolder + "\\2 Card.png");

        private Image Get3Card() => Image.FromFile(cdsFolder + "\\3 Card.png");

        private Image Get4Card() => Image.FromFile(cdsFolder + "\\4 Card.png");

        private Image Get5Card() => Image.FromFile(cdsFolder + "\\5 Card.png");

        private Image Get6Card() => Image.FromFile(cdsFolder + "\\6 Card.png");

        private Image Get7Card() => Image.FromFile(cdsFolder + "\\7 Card.png");

        private Image Get8Card() => Image.FromFile(cdsFolder + "\\8 Card.png");

        private Image Get9Card() => Image.FromFile(cdsFolder + "\\9 Card.png");

        private Image Get10Cards()
        {
            double rndHolder = rndGen.NextDouble();

            if (rndHolder >= 0 && rndHolder <= 0.25)
                return Image.FromFile(cdsFolder + "\\10 Card.png");

            else if (rndHolder >= 0.25 && rndHolder <= 0.50)
                return Image.FromFile(cdsFolder + "\\J Card.png");

            else if (rndHolder >= 0.50 && rndHolder < 0.75)
                return Image.FromFile(cdsFolder + "\\Q Card.png");

            else if (rndHolder >= 0.75 && rndHolder <= 1)
                return Image.FromFile(cdsFolder + "\\K Card.png");

            else
            {
                Debug.WriteLine("Valor inesperado de rndHolder: " + rndHolder);

                return Image.FromFile(cdsFolder + "\\Upside down card.png");
            }
        }

        private Image GetACard() => Image.FromFile(cdsFolder + "\\A Card.png");

        private Image GetUSDCard() => Image.FromFile(cdsFolder + "\\Upside down card.png");

        private void setPicBoxArray()
        {
            picBoxArray[0] = picCardBancaL; // Carta izquierda de la banca.
            picBoxArray[1] = picCardBancaR; // Carta derecha de la banca.
            picBoxArray[2] = picCardIA1L; // Carta izquierda de la IA 1.
            picBoxArray[3] = picCardIA1R; // Carta derecha de la IA 1.
            picBoxArray[4] = picCardIA2L; // Carta izquierda de la IA 2.
            picBoxArray[5] = picCardIA2R; // Carta derecha de la IA 2.
            picBoxArray[6] = picCardPlayerL; // Carta izquierda del jugador.
            picBoxArray[7] = picCardPlayerR; // Carta derecha del jugador.
            picBoxArray[8] = picCardPlayerAs; // Carta As del jugador.
        }

        private void picCardPlayerAs_Click(object sender, EventArgs e)
        {
            if (!btnIniciar.Visible)
            {
                camValorCartaAs();

                lblPuntosPlayer.Text = "Puntos: " + ptoPlayer;
            }
        }

        private void camValorCartaAs()
        {
            if (valCtas[8] == 11)
            {
                ptoPlayer -= 10;

                valCtas[8] = 1;
            }

            else
            {
                ptoPlayer += 10;

                valCtas[8] = 11;
            }
        }

        private sbyte pdrCartaJugador()
        {
            byte pto = getPtoCarta(3);

            if (pto != 11)
            {
                if (ctaLORPlayer)
                {
                    chkPto(pto, 6);

                    ptoPlayer += pto;

                    valCtas[6] = pto;

                    ctaLORPlayer = false;
                }

                else
                {
                    chkPto(pto, 7);

                    ptoPlayer += pto;

                    valCtas[7] = pto;

                    ctaLORPlayer = true;
                }
            }

            else
            {
                chkPto(pto, 8);

                ptoPlayer += pto;

                valCtas[8] = pto;

                tcoAsPlayer = true;

                picCardPlayerAs.Visible = true;
            }

            try
            {
                if (ptoPlayer > 21 && tcoAsPlayer && valCtas[8] == 11)
                {
                    camValorCartaAs();

                    Debug.WriteLine("Cambiando el valor del As a 1 para no pasarse de 21...");
                }

                if (ptoPlayer > 21)
                {
                    lblPuntosPlayer.Text = "Puntos: " + ptoPlayer + " (Te pasaste)";

                    lblMonto.Text = "Monto: $" + mtoPlayer + " (-" + nudApuesta.Value + ")";

                    btnPedir.Enabled = false;

                    btnQuedarse.Enabled = false;

                    picBoxArray[8].Enabled = false;

                    Debug.WriteLine("El jugador se pasó de 21.");

                    dinPer += Convert.ToUInt32(nudApuesta.Value);
                    ptdPer++;
                    ptoObt += ptoPlayer;
                    tpoTot += clock.Elapsed;

                    clock.Reset();
                    stopWatchUpdTimer.Stop();

                    GdrEstadisticasNuevas();

                    btnReiniciar.Visible = true;

                    return 0;
                }

                else
                {
                    lblPuntosPlayer.Text = "Puntos: " + ptoPlayer;

                    Debug.WriteLine("El jugador NO se pasó de 21.");

                    return 0;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
        }

        private sbyte pdrCartaIAs()
        {
            /*
            Una manera sería generar un número aleatorio entre 1 y 100, y preguntar si ese número está en cierto rango dependiendo
            del puntaje de la IA, por ejemplo, si tiene entre 12 y 14 puntos, preguntamos si el número generado está
            entre 1 y 75, habiendo un 75% de posibilidades de que la IA "elija" pedir carta, después, si la IA tiene entre
            15 y 17 puntos preguntar si el número generado está entre 1 y 50, habiendo solo un 50% de posibilidades de que
            "elija", y así ir bajando el rango preguntado hasta llegar a 20 puntos que la posibilidad sería de 1%, porque se preguntaría
            si el número generado vale exactamente 1, cuando puede valer de forma aleatoria entre 1 y 100.
            Si la IA tiene 11 puntos o menos, siempre pediría carta ya que no hay forma de que se pase de 21.
            Si la IA tiene 21 puntos, obviamente no tendría que pedir carta, OBVIAMENTE.

            Una forma de "aleatorizar" incluso más las elecciones de las IAs, sería generar de forma aleatoria el número
            máximo que se utiliza en los rangos preguntados, por ejemplo:

            if (rndNum >= 1 && rndNum <= max)
            {
                ...
            }

            Siendo max generado de forma aleatoria, para el caso de que la IA tenga entre 12 y 14 puntos, que
            max valga entre 75 y 80, en vez de siempre 75, después para cuando tenga entre 15 y 17 puntos
            que valga entre 50 y 55, en vez de siempre 50, y así para los demas rangos preguntados, los cuales
            dependen del puntaje de las IAs.
            */

            byte rndNum;
            byte maxRange;

            if ((ptoIA1 == 17 || ptoIA1 == 18) && !noPdeMasIA1)
            {
                rndNum = (byte)rndGen.Next(1, 100);
                maxRange = (byte)rndGen.Next(70, 80);

                if (rndNum >= 1 && rndNum <= maxRange)
                {
                    noPdeMasIA1 = true;

                    Debug.WriteLine("La IA1 no pedirá más cartas. Tiene 17 o 18 puntos.");
                }
            }

            else if (ptoIA1 >= 19 && !noPdeMasIA1)
            {
                noPdeMasIA1 = true;

                Debug.WriteLine("LA IA1 no pedirá no pedirá más cartas. Tiene entre 19 puntos o más.");
            }

            if ((ptoIA2 == 17 || ptoIA2 == 18) && !noPdeMasIA2)
            {
                rndNum = (byte)rndGen.Next(1, 100);
                maxRange = (byte)rndGen.Next(70, 80);

                if (rndNum >= 1 && rndNum <= maxRange)
                {
                    noPdeMasIA2 = true;

                    Debug.WriteLine("La IA2 no pedirá más cartas. Tiene 17 o 18 puntos.");
                }
            }

            else if (ptoIA2 >= 19 && !noPdeMasIA2)
            {
                noPdeMasIA2 = true;

                Debug.WriteLine("LA IA2 no pedirá no pedirá más cartas. Tiene entre 19 puntos o más.");
            }

            if (ptoIA1 <= 21 && !noPdeMasIA1)
            {
                // Primer IA.

                rndNum = Convert.ToByte(rndGen.Next(1, 100));
                maxRange = Convert.ToByte(rndGen.Next(75, 80));

                if (ptoIA1 > 11 && ptoIA1 <= 14 && rndNum >= 1 && rndNum <= maxRange)
                    chgCardValuesIA1();

                else if (ptoIA1 > 14 && ptoIA1 <= 17 && rndNum >= 1 && rndNum <= maxRange - 25)
                    chgCardValuesIA1();

                else if (ptoIA1 == 18 && rndNum >= 1 && rndNum <= maxRange - 50)
                    chgCardValuesIA1();

                else if (ptoIA1 < 12)
                    chgCardValuesIA1();

                if (ptoIA1 > 21 && tcoAsIA1 && !camValorAsIA1)
                {
                    ptoIA1 -= 10;

                    camValorAsIA1 = true;

                    Debug.WriteLine("Cambiando el valor de la As de la IA1 a 1 para no pasarse de 21...");
                }

                lblPuntosIA1.Text = "Puntos: " + ptoIA1;

                if (noPdeMasIA2)
                    return 0;
            }

            if (ptoIA2 <= 21 && !noPdeMasIA2)
            {
                // Segunda IA.

                rndNum = Convert.ToByte(rndGen.Next(1, 100));
                maxRange = Convert.ToByte(rndGen.Next(75, 80));

                if (ptoIA2 > 11 && ptoIA2 <= 14 && rndNum >= 1 && rndNum <= maxRange)
                    chgCardValuesIA2();

                else if (ptoIA2 > 14 && ptoIA2 <= 17 && rndNum >= 1 && rndNum <= maxRange - 25)
                    chgCardValuesIA2();

                else if (ptoIA2 == 18 && rndNum >= 1 && rndNum <= maxRange - 50)
                    chgCardValuesIA2();

                else if (ptoIA2 < 12)
                    chgCardValuesIA2();

                if (ptoIA2 > 21 && tcoAsIA2 && !camValorAsIA2)
                {
                    ptoIA2 -= 10;

                    camValorAsIA2 = true;

                    Debug.WriteLine("Cambiando el valor de la As de la IA2 a 1 para no pasarse de 21...");
                }

                lblPuntosIA2.Text = "Puntos: " + ptoIA2;

                return 0;
            }

            return -1;
        }

        private void chgCardValuesIA1()
        {
            byte pto = getPtoCarta(1);

            if (pto == 11)
                tcoAsIA1 = true;

            if (ctaLORIA1)
            {
                chkPto(pto, 2);

                ptoIA1 += pto;

                valCtas[2] = pto;

                ctaLORIA1 = false;
            }

            else
            {
                chkPto(pto, 3);

                ptoIA1 += pto;

                valCtas[3] = pto;

                ctaLORIA1 = true;
            }
        }

        private void chgCardValuesIA2()
        {
            byte pto = getPtoCarta(2);

            if (pto == 11)
                tcoAsIA2 = true;

            if (ctaLORIA2)
            {
                chkPto(pto, 4);

                ptoIA2 += pto;

                valCtas[4] = pto;

                ctaLORIA2 = false;
            }

            else
            {
                chkPto(pto, 5);

                ptoIA2 += pto;

                valCtas[5] = pto;

                ctaLORIA2 = true;
            }
        }

        private void pdrCartaBanca()
        {
            byte pto = getPtoCarta(0);

            if (pto == 11)
                tcoAsBanca = true;

            if (ctaLORBanca)
            {
                chkPto(pto, 0);

                ptoBanca += pto;

                valCtas[0] = pto;

                ctaLORBanca = false;
            }

            else
            {
                chkPto(pto, 1);

                ptoBanca += pto;

                valCtas[1] = pto;

                ctaLORBanca = true;
            }

            if (ptoBanca > 21 && tcoAsBanca && !camValorAsBanca)
            {
                ptoBanca -= 10;

                camValorAsBanca = true;

                Debug.WriteLine("Cambiando el valor de la As de la banca para no pasarse de 21...");
            }
        }

        private void updBcaPicBoxes()
        {
            picBoxArray[0].Invalidate();
            picBoxArray[0].Update();

            picBoxArray[1].Invalidate();
            picBoxArray[1].Update();
        }

        private void updBcaPtosLbl()
        {
            lblPuntosBanca.Text = "Puntos: " + ptoBanca;

            lblPuntosBanca.Invalidate();
            lblPuntosBanca.Update();

            // Solución de Internet para actualizar el label durante el bucle while en vez de al final del bucle.
            // Esto se debe a que todo el código se ejecuta en un mismo hilo. Se debe finalizar este bucle entero
            // antes de que el flujo de ejecución pase al código que actualiza el label. Estos dos métodos fuerzan
            // la actualización haciendo que el flujo vuelva al código que actualiza el label.
            // Supuestamente no es muy eficiente.
        }

        private void updLblClockMethod(object sender, ElapsedEventArgs e)
        {
            if (lblClock.InvokeRequired)
            {
                var dlg = new delUpdClockLbl(updLblClockString);

                try
                {
                    Invoke(dlg, new string[] { GetClkStr() });
                }

                catch (ObjectDisposedException)
                {
                    // Nada.
                }
            }

            else
                lblClock.Text = GetClkStr();
        }

        private void updLblClockString(string time)
        {
            lblClock.Text = time;
        }

        private string GetClkStr() => string.Format("{0:00}", clock.Elapsed.Hours) + " : " + string.Format("{0:00}", clock.Elapsed.Minutes)
                    + " : " + string.Format("{0:00}", clock.Elapsed.Seconds);

        private void updLblMto(int mto)
        {
            lblMonto.Text = "Monto: $" + mto;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBlackjack_KeyPress(object sender, KeyPressEventArgs e)
        {
            //strBlrCheats.Append(char.ToLower(e.KeyChar));

            //if (strBlrCheats.ToString() == "soyrico")
            //{
            //    mtoPlayer += 500;
            //    updLblMto(mtoPlayer);

            //    strBlrCheats.Clear();

            //    Debug.WriteLine("Agregados $500");
            //}

            //else if (strBlrCheats.Length > 7)
            //    strBlrCheats.Clear();

            //Debug.WriteLine(strBlrCheats.ToString());

            strBlrCheats.Append(e.KeyChar);
            char[] chIngArray = strBlrCheats.ToString().ToLower().ToArray();
            char[] chChtArray = "soyrico".ToArray();

            Debug.WriteLine(e.KeyChar);

            for (int i = 0; i < chIngArray.Length; i++)
            {
                if (chIngArray[i] == chChtArray[i] && chIngArray.Length == chChtArray.Length)
                {
                    mtoPlayer += 500;
                    updLblMto(mtoPlayer);

                    Debug.WriteLine(strBlrCheats.ToString().ToLower());
                    strBlrCheats.Clear();

                    Debug.WriteLine("Agregados $500");

                    break;
                }

                else if (chIngArray[i] != chChtArray[i])
                {
                    strBlrCheats.Clear();

                    break;
                }
            }
        }

        private void frmBlackjack_Load(object sender, EventArgs e)
        {
            frmPerfiles objPerfiles = new frmPerfiles();

            try
            {
                DialogResult res = objPerfiles.ShowDialog();

                if (res == DialogResult.Cancel)
                    Close();

                else
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(Globales.DBCon())) // La conexión a la BDD tiene que estar en un try-catch.
                        {
                            con.Open();

                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "SEL_ESTADISTICAS_PERFIL";

                                cmd.Parameters.AddWithValue("CODJUG", (int)codJug);

                                var rdr = cmd.ExecuteReader(); // TODO: Meter todo esto en un try-catch.

                                if (rdr.HasRows)
                                {
                                    rdr.Read();

                                    mtoPlayer = Convert.ToInt32(rdr[0]);

                                    dinGan = Convert.ToUInt32(rdr[1]);
                                    dinPer = Convert.ToUInt32(rdr[2]);
                                    ptdGan = Convert.ToUInt32(rdr[3]);
                                    ptdPer = Convert.ToUInt32(rdr[4]);
                                    ctaPed = Convert.ToUInt32(rdr[5]);
                                    vceQue = Convert.ToUInt32(rdr[6]);
                                    ptoObt = Convert.ToUInt32(rdr[7]);
                                    blkJck = Convert.ToUInt32(rdr[8]);
                                    tpoTot = TimeSpan.FromTicks(Convert.ToInt64(rdr[9]));

                                    rdr.Close();

                                    Debug.WriteLine("Datos de estadísticas cargados desde la BDD.");
                                }

                                else
                                {
                                    rdr.Close();

                                    mtoPlayer = 100;
                                    dinGan = 0;
                                    dinPer = 0;
                                    ptdGan = 0;
                                    ptdPer = 0;
                                    ctaPed = 0;
                                    vceQue = 0;
                                    ptoObt = 0;
                                    blkJck = 0;
                                    tpoTot = TimeSpan.FromTicks(0);

                                    cmd.CommandText = "INS_ESTADISTICAS_PERFIL";

                                    cmd.Parameters.AddWithValue("DINJUG", mtoPlayer);
                                    cmd.Parameters.AddWithValue("DINGAN", (int)dinGan);
                                    cmd.Parameters.AddWithValue("DINPER", (int)dinPer);
                                    cmd.Parameters.AddWithValue("PTDGAN", (int)ptdGan);
                                    cmd.Parameters.AddWithValue("PTDPER", (int)ptdPer);
                                    cmd.Parameters.AddWithValue("CTAPED", (int)ctaPed);
                                    cmd.Parameters.AddWithValue("VCEQUE", (int)vceQue);
                                    cmd.Parameters.AddWithValue("PTOOBT", (int)ptoObt);
                                    cmd.Parameters.AddWithValue("BLKJCK", (int)blkJck);
                                    cmd.Parameters.AddWithValue("TPOTOT", tpoTot.Ticks);

                                    cmd.ExecuteNonQuery(); // Tiene que estar en un try-catch.

                                    Debug.WriteLine("No hay datos de estadísticas en la BDD para este jugador.\nRegistro creado.");
                                }

                                updLblMto(mtoPlayer);
                            }

                            con.Close();
                        }
                    }

                    catch
                    {
                        MessageBox.Show("Se ha producido un error al recuperar los datos desde el servidor.\nEl servidor no está disponible en este momento.", "Error de acceso",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            catch (ObjectDisposedException)
            {
                Close();
            }

            //objPerfiles.Dispose();
        }

        private void GdrEstadisticasNuevas()
        {
            //bool hayEstadisticas = SelEstadisticasPerfil();

            //if (hayEstadisticas)
            //{

            //}

            try
            {
                using (var con = new SqlConnection(Globales.DBCon())) // La conexión a la BDD tiene que estar en un try-catch.
                {
                    con.Open();

                    using (var cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "UPD_ESTADISTICAS_PERFIL";

                        cmd.Parameters.AddWithValue("CODJUG", (int)codJug);
                        cmd.Parameters.AddWithValue("DINJUG", mtoPlayer);
                        cmd.Parameters.AddWithValue("DINGAN", (int)dinGan);
                        cmd.Parameters.AddWithValue("DINPER", (int)dinPer);
                        cmd.Parameters.AddWithValue("PTDGAN", (int)ptdGan);
                        cmd.Parameters.AddWithValue("PTDPER", (int)ptdPer);
                        cmd.Parameters.AddWithValue("CTAPED", (int)ctaPed);
                        cmd.Parameters.AddWithValue("VCEQUE", (int)vceQue);
                        cmd.Parameters.AddWithValue("PTOOBT", (int)ptoObt);
                        cmd.Parameters.AddWithValue("BLKJCK", (int)blkJck);
                        cmd.Parameters.AddWithValue("TPOTOT", tpoTot.Ticks);

                        cmd.ExecuteNonQuery(); // Tiene que estar en un try-catch.

                        Debug.WriteLine("Estadisticas de jugador existente guardadas.");
                    }

                    con.Close();
                }
            }

            catch
            {
                MessageBox.Show("Se ha producido un error al enviar datos al servidor.\nEl servidor no está disponible en este momento.", "Error de acceso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private bool SelEstadisticasPerfil() Este método ya no es necesario.
        //{
        //    using (var con = new SqlConnection(Globales.DBCon())) La conexión a la BDD tiene que estar en un try-catch.
        //    {
        //        con.Open();

        //        using (var cmd = new SqlCommand())
        //        {
        //            cmd.Connection = con;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandText = "SEL_ESTADISTICAS_PERFIL";

        //            cmd.Parameters.AddWithValue("CODJUG", (int)codJug);

        //            var rdr = cmd.ExecuteReader(); Tiene que estar en un try-catch.

        //            if (rdr.HasRows)
        //            {
        //                rdr.Close();
        //                con.Close();

        //                return true;
        //            }

        //            else
        //            {
        //                rdr.Close();
        //                con.Close();

        //                return false;
        //            }
        //        }
        //    }
        //}

        private void frmBlackjack_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (jgoIniciado)
            {
                DialogResult res = MessageBox.Show("¿Estás seguro que querés cerrar el juego? (Partida en curso).", "Cerrar juego",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res == DialogResult.No)
                    e.Cancel = true;
            }
        }

        public static void SetCodJug(ushort arg)
        {
            codJug = arg;

            Debug.WriteLine("Código de jugador: " + codJug);
        }

        public static ushort GetCodJug() => codJug;

        private void estadísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadisticas objEstadisticas = new frmEstadisticas();
            objEstadisticas.ShowDialog();
        }

        private void loopPdrCartasBanca()
        {
            pdrCartaBancaClock.Start();

            while (ptoBanca < 17)
            {
                if (pdrCartaBancaClock.Elapsed >= TimeSpan.FromMilliseconds(1000))
                {
                    pdrCartaBanca();
                    //updBcaPicBoxes();

                    //updBcaPtosLbl();
                    if (lblPuntosBanca.InvokeRequired)
                        Invoke(() => lblPuntosBanca.Text = "Puntos: " + ptoBanca);
                    else
                        lblPuntosBanca.Text = "Puntos: " + ptoBanca;

                    pdrCartaBancaClock.Restart();

                    Debug.WriteLine("Puntos de la banca: " + ptoBanca);
                }
            }

            pdrCartaBancaClock.Stop();
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Enter && ActiveControl.Name == "nudApuesta")
        //    {


        //        return true;
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
    }
}