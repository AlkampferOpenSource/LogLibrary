using System;
using System.IO;

namespace LogLibrary
{
    public class FileLogDestination : ILogDestination
    {
        private readonly StreamWriter _streamWriter;

        public FileLogDestination(String fileName)
        {
            var _fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            _fileStream.Seek(0, SeekOrigin.End);
            _streamWriter = new StreamWriter(_fileStream);
        }
        public void AddLog(LogMessage message)
        {
            _streamWriter.Write($"{message.Level}[{message.Timestamp}] - {message.RenderedMessage}");
        }
    }
}
