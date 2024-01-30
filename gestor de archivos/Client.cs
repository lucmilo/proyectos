using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace File_Uploader
{
    public class Client : Server
    {
        //private bool disposedValue;

        private static ushort _cIAmount;

        public static ushort CIAmount
        {
            get { return _cIAmount; }

            private set { _cIAmount = value; }
        }

        public Client() : base()
        {
            CIAmount++;
        }

        public Client(string Ipstring, ushort Port) : base(Ipstring, Port)
        {
            CIAmount++;
        }

        public override bool StartListening()
        {
            if (client == null && stream == null)
            {
                client = new TcpClient(IpString, Port);
                stream = client.GetStream();

                stream.ReadTimeout = 300;
                stream.WriteTimeout = 3000;

                return true;
            }

            return base.StartListening();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (!disposedValue)
        //    {
        //        if (disposing)
        //        {
        //            IpString = null;
        //            Port = 0;
        //        }

        //        if (client != null)
        //            client.Close();

        //        if (stream != null)
        //            stream.Close();

        //        client = null; // Si se llama al método (Dispose) antes de que client referencie a un objeto TcpClient será nulo ya antes de establecerlo como tal.
        //                       // Puede pasar cuando falla la conexión desde el cliente al servidor, client no referenciará un objeto TcpClient en ese caso.
        //        stream = null; // Lo mismo acá.

        //        disposedValue = true;
        //    }
        //}

        ~Client()
        {
            Dispose(false);
        }
    }
}