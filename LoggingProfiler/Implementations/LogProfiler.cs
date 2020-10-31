using LoggingProfiler.Interfaces;
using LoggingProfiler.Models;
using System;

namespace LoggingProfiler.Implementations
{
    public class LogProfiler : ILogProfiler
    {
        private readonly ILogger _logger;

        internal LogProfiler(ILogger logger)
        {
            _logger = logger;
        }

        public static class Factory
        {
            private static readonly IoCContainerManager _containerManager = new IoCContainerManager();

            public static ILogProfiler Create(LogProfilerSettings settings = null)
            {
                if (settings is null)
                    settings = new LogProfilerSettings();

                // Resolve dependencies
                var logger = InitLogger(settings);
                if (logger is null)
                    throw new ArgumentException("It's not possible to initialize an instance of a logger");

                // Create an instance
                return new LogProfiler(logger);
            }

            private static ILogger InitLogger(LogProfilerSettings settings)
            {
                var logger = _containerManager.Resolve<ILogger>();

                if (string.IsNullOrWhiteSpace(settings.LogFilePath))
                    throw new ArgumentException("Settings' LogFilePath cannot be null or empty");

                logger?.Init(new LoggerConfiguration
                {
                    Path = settings.LogFilePath
                });

                return logger;
            }
        }
    }
}