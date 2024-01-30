using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TCPComs
{
    public class Client : Server
    {
        public Client() : base()
        {

        }

        public Client(string IpString, ushort Port) : base(IpString, Port)
        {

        }

        public override bool StartListening()
        {
            if (client[0] == null && stream[0] == null)
            {
                client[0] = new TcpClient(IpString, Port);
                stream[0] = client[0].GetStream();

                return true;
            }

            throw new InvalidOperationException("Esta instancia ya está conectada al servidor.");
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _ipString = null;
                    Port = 0;
                }

                if (client[0] != null && stream[0] != null)
                {
                    client[0].Dispose();
                    stream[0].Dispose();

                    client[0] = null;
                    stream[0] = null;
                }

                disposed = true;
            }
        }

        ~Client()
        {
            Dispose(false);
        }
    }
}