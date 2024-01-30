using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace File_Uploader
{
    public class Server : IDisposable
    {
        private static ushort _sIAmount;

        public static ushort SIAmount
        {
            get { return _sIAmount; }

            private set { _sIAmount = value; }
        }

        private TcpListener server;
        protected TcpClient client;
        protected NetworkStream stream;

        private Stopwatch clock = new Stopwatch();
        private System.Timers.Timer timer = new System.Timers.Timer();

        private bool disposedValue;

        private string _ipString;

        public string IpString
        {
            get { return _ipString; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(value);

                if (!IPAddress.TryParse(value, out _))
                    throw new FormatException(value);

                _ipString = value;
            }
        }

        public ushort Port
        { get; set; }

        public Server()
        {
            if (this is not Client)
                SIAmount++;

            IpString = "127.0.0.1";
            Port = 5001;
        }

        public Server(string IpString, ushort Port)
        {
            if (this is not Client)
                SIAmount++;

            this.IpString = IpString;
            this.Port = Port;

            timer.AutoReset = true;
            timer.Interval = 1000;
            timer.Elapsed += new ElapsedEventHandler(TimerMethod);
        }

        public virtual bool StartListening()
        {
            if (server == null && this is not Client)
            {
                IPAddress ip = IPAddress.Parse(IpString);

                server = new TcpListener(ip, Port);
                server.Start();

                return true;
            }

            else if (this is not Server)
                throw new InvalidOperationException("Client is already connected.");

            throw new InvalidOperationException("Server is already listening.");
        }

        public bool AcceptConnection()
        {
            if (client == null && stream == null && server != null)
            {
                client = server.AcceptTcpClient();
                stream = client.GetStream();

                stream.ReadTimeout = 300;
                stream.WriteTimeout = 3000;

                return true;
            }

            else if (server == null && this is not Client)
                throw new InvalidOperationException("Server has not started listening yet.");

            throw new InvalidOperationException("Connection has already been established.");
        }

        public async Task<bool> WriteData(byte[] dataBuffer)
        {
            if (stream != null && stream.Socket.Connected)
            {
                stream.Write(dataBuffer, 0, dataBuffer.Length);

                await stream.FlushAsync();

                return true;
            }

            else if (!stream.Socket.Connected)
            {
                if (this is not Client)
                    throw new IOException("Connection has been lost to the client.");

                else
                    throw new IOException("Connection has been lost to the server.");
            }

            if (this is Server)
                throw new InvalidOperationException("This instance is not connected to the client yet.");

            else
                throw new InvalidOperationException("This instance is not connected to the server yet.");
        }

        public async Task<byte[]?> ReadData()
        {
            if (clock.Elapsed > TimeSpan.FromMilliseconds(0))
                clock.Reset();

            if (timer.Enabled)
                timer.Stop();

            if (stream != null && stream.DataAvailable)
            {
                clock.Start();
                timer.Start();

                int pgrBarValue = 1;

                List<byte> dataBuffer = new List<byte>();
                byte[] bytes = new byte[0x10000];
                int bytesRead;

                while (stream.DataAvailable)
                {
                    while (stream.DataAvailable)
                    {
                        while (stream.DataAvailable)
                        {
                            while (stream.DataAvailable)
                            {
                                while (stream.DataAvailable)
                                {
                                    bytesRead = await stream.ReadAsync(bytes, 0, bytes.Length);

                                    while (true)
                                    {
                                        Program.ChangePgrBarValue(pgrBarValue);

                                        if (pgrBarValue < 80)
                                            pgrBarValue++;

                                        for (int i = 0; i < bytesRead; i++)
                                            dataBuffer.Add(bytes[i]);

                                        if (!stream.DataAvailable)
                                            break;

                                        bytesRead = await stream.ReadAsync(bytes, 0, bytes.Length); // No está devolviendo 0 al no haber más datos para leer.
                                    }

                                    await Task.Delay(250);
                                }

                                await Task.Delay(750);
                            }

                            await Task.Delay(2000);
                        }

                        await Task.Delay(5000);
                    }

                    await Task.Delay(7000);
                }

                if (pgrBarValue <= 99)
                    Program.ChangePgrBarValue(100);

                // No se ejecutarán las instrucciones de abajo (que paran los relojes) si se produce una excepción más arriba mientras se leen datos,
                // por lo que los If que están arriba de todo van a encargarse de eso, además de reestablecer el reloj en 0.

                clock.Stop();
                timer.Stop();

                return dataBuffer.ToArray();
            }

            else if (stream == null)
            {
                if (this is not Client)
                    throw new InvalidOperationException("This instance is not connected to the client yet.");

                else
                    throw new InvalidOperationException("This instance is not connected to the server yet.");
            }

            return null;
        }

        private void TimerMethod(object sender, ElapsedEventArgs e)
        {
            Program.ChangeStripLbl("Estado: Recibiendo archivo... | " + GetClkElsdTime);
        }

        private string GetClkElsdTime => string.Format("{0:00}", clock.Elapsed.Hours) + " : " + string.Format("{0:00}", clock.Elapsed.Minutes) +
            " : " + string.Format("{0:00}", clock.Elapsed.Seconds);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _ipString = null;
                    Port = 0;
                }

                if (server != null)
                {
                    server.Stop();
                    server = null;
                }

                if (client != null)
                {
                    client.Close();
                    client = null;
                }

                if (stream != null)
                {
                    stream.Close();
                    stream = null;
                }
                
                disposedValue = true;
            }
        }

        ~Server()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}