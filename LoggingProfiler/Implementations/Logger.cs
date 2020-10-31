using Serilog;
using Serilog.Events;
using System;
using ILogger = LoggingProfiler.Interfaces.ILogger;

namespace LoggingProfiler.Implementations
{
    internal sealed class Logger : ILogger
    {
        public Logger(Models.LoggerConfiguration loggerConfiguration)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(loggerConfiguration.Path)
                .CreateLogger();
        }

        public void Debug(string message)
        {
            if (Log.IsEnabled(LogEventLevel.Debug))
                Log.Debug(message);
        }

        public void Debug(Exception exception, string message)
        {
            if (Log.IsEnabled(LogEventLevel.Debug))
                Log.Debug(exception, message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Error(Exception exception, string message)
        {
            Log.Error(exception, message);
        }

        public void Information(string message)
        {
            if (Log.IsEnabled(LogEventLevel.Information))
                Log.Information(message);
        }

        public void Verbose(string message)
        {
            if (Log.IsEnabled(LogEventLevel.Verbose))
                Log.Verbose(message);
        }

        public void Verbose(Exception exception, string message)
        {
            if (Log.IsEnabled(LogEventLevel.Verbose))
                Log.Verbose(exception, message);
        }

        public void Wanring(Exception exception, string message)
        {
            Log.Warning(exception, message);
        }

        public void Warning(string message)
        {
            Log.Warning(message);
        }
    }
}