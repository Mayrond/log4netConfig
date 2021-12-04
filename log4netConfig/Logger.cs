using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace log4netConfig
{
    public class Logger
    {
        public static void ConfigureLogging()
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository();

            var patternLayout = new PatternLayout
            {
                ConversionPattern = "%date [%thread] %-5level %logger - %message%newline",
            };
            patternLayout.ActivateOptions(); //apply options

            var roller = new RollingFileAppender
            {
                AppendToFile = true,
                Threshold = Level.Debug,
                File = @"Logs\log_",
                DatePattern = "yyyyMMdd",
                Layout = patternLayout,
                RollingStyle = RollingFileAppender.RollingMode.Date,
                StaticLogFileName = false
            };
            roller.ActivateOptions(); //apply options
            hierarchy.Root.AddAppender(roller);

            var consoleAppender = new ConsoleAppender()
            {
                Layout = patternLayout,
                Threshold = Level.Debug,
                Target = "Console.Out"
            };
            consoleAppender.ActivateOptions(); //apply options
            hierarchy.Root.AddAppender(consoleAppender);

            var customAppender = new CustomAppender();
            hierarchy.Root.AddAppender(customAppender);

            hierarchy.Root.Level = Level.Debug;
            hierarchy.Configured = true;
        }
    }
}