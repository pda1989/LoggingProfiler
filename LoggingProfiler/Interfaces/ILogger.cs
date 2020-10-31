using System;

namespace LoggingProfiler.Interfaces
{
    internal interface ILogger
    {
        void Debug(string message);

        void Debug(Exception exception, string message);

        void Error(string message);

        void Error(Exception exception, string message);

        void Information(string message);

        void Verbose(string message);

        void Wanring(Exception exception, string message);

        void Warning(string message);
    }
}