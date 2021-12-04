using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace log4netConfig
{
    public static class Logger
    {
        public static void ConfigureLogging()
        {
            var patternLayout = new PatternLayout
            {
                ConversionPattern = "%date [%thread] %-5level %logger - %message%newline",
            };
            patternLayout.ActivateOptions(); //apply options

            var fileAppender = new RollingFileAppender
            {
                AppendToFile = true,
                Threshold = Level.Debug,
                File = @"Logs\log_",
                DatePattern = "yyyyMMdd",
                Layout = patternLayout,
                RollingStyle = RollingFileAppender.RollingMode.Date,
                StaticLogFileName = false
            };
            fileAppender.ActivateOptions(); //apply options

            var consoleAppender = new ConsoleAppender()
            {
                Layout = patternLayout,
                Threshold = Level.Debug,
                Target = "Console.Out"
            };
            consoleAppender.ActivateOptions(); //apply options

            var customAppender = new CustomAppender();
            
            BasicConfigurator.Configure(fileAppender, consoleAppender, customAppender);
        }
    }
}