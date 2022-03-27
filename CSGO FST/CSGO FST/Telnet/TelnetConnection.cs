using System;
using System.Net.Sockets;
using System.Text;

namespace CSGOTelnet
{
    internal class TelnetConnection
    {
        private TcpClient _tcpSocket;

        private const int TimeOutMs = 100;
        private const string Hostname = "localhost";

        public bool Connected => _tcpSocket != null && _tcpSocket.Connected && TestConnection();

        public TelnetConnection()
        {
            Connect();
        }

        private bool Connect()
        {
            try
            {
                _tcpSocket = new TcpClient(Hostname, 2121);
                return _tcpSocket.Connected;
            }
            catch
            {
                return false;
            }
        }

        private bool TestConnection()
        {
            var tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(Hostname, 2121);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void WriteLine(string cmd)
        {
            var utf8 = Encoding.UTF8;
            var buf = utf8.GetBytes((cmd + "\n").Replace("\0xFF", "\0xFF\0xFF"));

            _tcpSocket.GetStream().Write(buf, 0, buf.Length);
        }

        public string Read()
        {
            if (!_tcpSocket.Connected) return null;
            var sb = new StringBuilder();
            do
            {
                ParseTelnet(sb);
                System.Threading.Thread.Sleep(TimeOutMs);
            } while (_tcpSocket.Available > 0);
            return sb.ToString();
        }

        private void ParseTelnet(StringBuilder sb)
        {
            while (_tcpSocket.Available > 0)
            {
                var input = _tcpSocket.GetStream().ReadByte();
                switch (input)
                {
                    case -1:
                        break;
                    default:
                        sb.Append((char)input);
                        break;
                }
            }
        }
    }
}