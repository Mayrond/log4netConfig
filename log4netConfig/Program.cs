using log4net;

namespace log4netConfig
{
    public static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(nameof(Program));

        static Program()
        {
            Logger.ConfigureLogging();
        }

        static void Main()
        {
            Log.Info("info");
            Log.Warn("warn");
        }
    }
}