using System;
using log4net.Appender;
using log4net.Core;

namespace log4netConfig
{
    public class CustomAppender : IAppender
    {
        public string Name { get; set; } = "CustomAppender";

        public void DoAppend(LoggingEvent loggingEvent)
        {
            Console.WriteLine($"From custom appender: {loggingEvent.RenderedMessage}");
        }

        public void Close() { }
    }
}