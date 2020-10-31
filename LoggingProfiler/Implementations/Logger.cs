using Serilog;
using Serilog.Events;
using System;
using ILogger = LoggingProfiler.Interfaces.ILogger;

namespace LoggingProfiler.Implementations
{
    internal sealed class Logger : ILogger
    {
        private bool _initialized;

        public void Debug(string message)
        {
            Message(LogEventLevel.Debug, message);
        }

        public void Debug(Exception exception, string message)
        {
            Message(LogEventLevel.Debug, message, exception);
        }

        public void Error(string message)
        {
            Message(LogEventLevel.Error, message);
        }

        public void Error(Exception exception, string message)
        {
            Message(LogEventLevel.Error, message, exception);
        }

        public void Information(string message)
        {
            Message(LogEventLevel.Information, message);
        }

        public void Init(Models.LoggerConfiguration loggerConfiguration)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(loggerConfiguration.Path)
                .CreateLogger();

            _initialized = true;
        }

        public void Verbose(string message)
        {
            Message(LogEventLevel.Verbose, message);
        }

        public void Verbose(Exception exception, string message)
        {
            Message(LogEventLevel.Verbose, message, exception);
        }

        public void Wanring(Exception exception, string message)
        {
            Message(LogEventLevel.Warning, message, exception);
        }

        public void Warning(string message)
        {
            Message(LogEventLevel.Warning, message);
        }

        private void Message(LogEventLevel level, string message, Exception exception = null)
        {
            if (!_initialized)
                throw new InvalidOperationException("Logger is not initialized. Please call the Init method before");

            if (!Log.IsEnabled(level))
                return;

            switch (level)
            {
                case LogEventLevel.Verbose:
                    Log.Verbose(exception, message);
                    break;

                case LogEventLevel.Debug:
                    Log.Debug(exception, message);
                    break;

                case LogEventLevel.Information:
                    Log.Information(exception, message);
                    break;

                case LogEventLevel.Warning:
                    Log.Warning(exception, message);
                    break;

                case LogEventLevel.Error:
                    Log.Error(exception, message);
                    break;

                default:
                    throw new ArgumentException($"The log event level '{level}' is not supported");
            }
        }
    }
}