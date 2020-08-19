using System;

namespace LogLibrary
{
    /// <summary>
    /// Commento fatto su feature branch
    /// commentod
    /// XXXXXXXXXXXXX
    /// </summary>
    public class Logger
    {
        public Logger(LogLevel level, ILogDestination destination)
        {
            Destination = destination;
            Level = level;
        }
        public ILogDestination Destination { get; private set; }

        public LogLevel Level { get; set; }

        public void Log(LogLevel level, string message, params string[] parameters)
        {
            if (level > Level) return;
            String renderedMessage = String.Format(message, parameters);
            Log(level, renderedMessage);
        }

        public void Log(LogLevel level, string message)
        {
            if (level > Level) return;
            Destination.AddLog(new LogMessage(level, message, DateTime.UtcNow));
        }
    }

    public enum LogLevel
    {
        Error,
        Warn,
        Info,
        Debug,
        UltraVerbose
    }
}
