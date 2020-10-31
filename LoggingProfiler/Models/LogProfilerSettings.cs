namespace LoggingProfiler.Models
{
    public class LogProfilerSettings
    {
        public LogProfilerSettings(string logFilePath = null)
        {
            if (!string.IsNullOrWhiteSpace(logFilePath))
                LogFilePath = logFilePath;
        }

        public string LogFilePath { get; protected set; } = "ProfilerLog.log";
    }
}