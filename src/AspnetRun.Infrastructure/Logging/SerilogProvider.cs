using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Logging
{
    internal static class SerilogProvider
    {
        private static Logger GetLoggerConfiguration(string filePath)
        {
            // Configure Serilog here
            // For example, you can set up file logging, console logging, etc.
            return new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(filePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void Error(string message, string filePath)
        {
            var logger = GetLoggerConfiguration(filePath);
            logger.Error(message);
            logger.Dispose();
        }

        public static void Information(string message, string filePath)
        {
            var logger = GetLoggerConfiguration(filePath);
            logger.Information(message);
            logger.Dispose();
        }
        public static void Warning(string message, string filePath)
        {
            var logger = GetLoggerConfiguration(filePath);
            logger.Warning(message);
            logger.Dispose();
        }
    }
}
