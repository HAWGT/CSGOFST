using CSGOTelnet;

namespace CSGOFST.Helpers
{
    public static class TelnetHelper
    {
        private static TelnetConnection _telnetConnection;

        public static bool Connected => (_telnetConnection != null && _telnetConnection.Connected);

        public static bool Connect()
        {
            _telnetConnection = new TelnetConnection();
            return _telnetConnection.Connected;
        }

        public static bool ExecuteCsgoCommand(string command)
        {
            if (!Connected) return false;

            _telnetConnection.WriteLine(command);
            
            return true;
        }
    }
}
