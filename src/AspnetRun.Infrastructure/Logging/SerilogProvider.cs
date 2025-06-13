using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Logging
{
    public static class SerilogProvider
    {
        private static Logger GetLoggerConfiguration(string filePath)
        {
            return new LoggerConfiguration()
                .Enrich.FromLogContext() // Thêm metadata vào log
                .WriteTo.Console()
                .WriteTo.Async(a => a.File(filePath, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7,
                    buffered: true, flushToDiskInterval: TimeSpan.FromSeconds(5))) // Ghi log bất đồng bộ
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
