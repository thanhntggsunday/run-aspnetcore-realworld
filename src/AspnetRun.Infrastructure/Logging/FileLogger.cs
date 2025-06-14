namespace AspnetRun.Infrastructure.Logging
{
    using System;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;

    public class FileLogger : ILogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new LogScope(state);
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            string message = $"{formatter(state, exception)}";
            if (exception != null)
            {
                message += $" Exception: {exception}";
            }

            switch (logLevel)
            {
                case LogLevel.Trace:
                    SerilogProvider.Information(message, _filePath);
                    break;

                case LogLevel.Debug:
                    SerilogProvider.Information(message, _filePath);
                    break;

                case LogLevel.Information:
                    SerilogProvider.Information(message, _filePath);
                    break;

                case LogLevel.Warning:
                    SerilogProvider.Warning(message, _filePath);
                    break;

                case LogLevel.Error:
                    SerilogProvider.Error(message, _filePath);
                    break;

                case LogLevel.Critical:
                    SerilogProvider.Information(message, _filePath);
                    break;

                case LogLevel.None:
                    SerilogProvider.Information(message, _filePath);
                    break;

                default:
                    break;
            }
        }

        private class LogScope : IDisposable
        {
            private readonly object _state;

            public LogScope(object state)
            {
                _state = state;
                LogContext.Push(_state);
            }

            public void Dispose()
            {
                LogContext.Pop();
            }
        }
    }

    // Helper class for managing log context
    public static class LogContext
    {
        private static readonly Stack<object> _contextStack = new Stack<object>();

        public static void Push(object state) => _contextStack.Push(state);

        public static void Pop()
        {
            if (_contextStack.Count <= 0)
            {
                return;
            }
            _contextStack.Pop();
        }
    }
}