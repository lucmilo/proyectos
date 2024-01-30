using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPComs
{
    public class Server : IDisposable
    {
        protected bool disposed;

        private ushort cltIndex;

        public ushort GetIndex => cltIndex;

        private TcpListener? server;
        protected TcpClient[]? client = new TcpClient[5];
        protected NetworkStream[]? stream = new NetworkStream[5];

        //public string IpString { get; set; }

        protected string _ipString;

        public string IpString
        {
            get
            {
                return _ipString;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value));

                if (IPAddress.TryParse(value, out _))
                    _ipString = value;

                else
                    throw new FormatException(nameof(value));
            }
        }

        public ushort Port { get; set; }

        public Server()
        {
            IpString = "127.0.0.1";

            Port = 5001;
        }

        public Server(string IpString, ushort Port)
        {
            this.IpString = IpString;

            this.Port = Port;
        }

        public virtual bool StartListening()
        {
            if (server == null)
            {
                IPAddress ip = IPAddress.Parse(IpString);

                server = new TcpListener(ip, Port);
                server.Start();

                return true;
            }

            throw new InvalidOperationException("Esta instancia ya está escuchando.");
        }

        public bool AcceptConnection()
        {
            if (client[cltIndex] == null && stream[cltIndex] == null && server != null && cltIndex <= 4)
            {
                client[cltIndex] = server.AcceptTcpClient();
                stream[cltIndex] = client[cltIndex].GetStream();

                cltIndex++;

                return true;
            }

            else if (this is not Server)
                throw new NotSupportedException("Esta instancia no puede aceptar conexiones entrantes.");

            else if (server == null)
                throw new InvalidOperationException("La instancia no está escuchando conexiones entrantes.");

            return false;
        }

        public bool CheckStreamCon(int index)
        {
            if (stream[index] != null)
                return stream[index].Socket.Connected;

            throw new IOException("Esta conexión no existe.");
        }

        public bool CheckAllStreamCons()
        {
            if (this is not Client)
            {
                if (client[0] == null)
                    throw new IOException("Esta conexión no existe.");

                int aux = cltIndex;

                for (int i = 0; i < cltIndex; i++)
                {
                    if (!client[i].Connected)
                        aux--;
                }

                if (aux == 0)
                    return false;

                else
                    return true;
            }

            throw new NotSupportedException();
        }

        public string? ReadData(int index)
        {
            if (stream[index] != null && stream[index].DataAvailable)
            {
                string response;
                byte[] dataBuffer = new byte[1024];

                int bytesRead = stream[index].Read(dataBuffer, 0, dataBuffer.Length);
                response = Encoding.UTF8.GetString(dataBuffer, 0, bytesRead);

                return response;
            }

            else if (stream[index] == null)
                throw new IOException("Esta conexión no existe.");

            return null;
        }

        public bool WriteData(string msg, int index)
        {
            if (stream[index] != null && !string.IsNullOrWhiteSpace(msg))
            {
                byte[] dataBuffer = Encoding.UTF8.GetBytes(msg);

                stream[index].Write(dataBuffer, 0, dataBuffer.Length);

                return true;
            }

            else if (string.IsNullOrWhiteSpace(msg))
                throw new ArgumentNullException(msg);

            throw new IOException("Esta conexión no existe.");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
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

                for (int i = 0; i < cltIndex; i++)
                {
                    if (client[i] != null && stream[i] != null)
                    {
                        client[i].Dispose();
                        stream[i].Dispose();

                        client[i] = null;
                        stream[i] = null;
                    }
                }

                disposed = true;
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