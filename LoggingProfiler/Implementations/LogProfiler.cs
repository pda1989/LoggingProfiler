using LoggingProfiler.Interfaces;

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

            public static ILogProfiler Create()
            {
                // Resolve dependencies
                var logger = _containerManager.Resolve<ILogger>();

                // Create an instance
                return new LogProfiler(logger);
            }
        }
    }
}