using System;

namespace LogLibrary
{
    public class ConsoleLogDestination : ILogDestination
    {
        public void AddLog(LogMessage message)
        {
            Console.WriteLine(message.RenderedMessage);
        }
    }
}
