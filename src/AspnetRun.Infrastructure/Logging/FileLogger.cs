namespace AspnetRun.Infrastructure.Logging
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.IO;

    public class FileLogger : ILogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public IDisposable? BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            string message = $"{DateTime.UtcNow} [{logLevel}] {formatter(state, exception)}";
            if (exception != null)
            {
                message += $" Exception: {exception}";
            }

            //// Ghi log vào file
            //File.AppendAllText(_filePath, message + Environment.NewLine);
            SerilogProvider.Information(message, _filePath);
        }
    }
}