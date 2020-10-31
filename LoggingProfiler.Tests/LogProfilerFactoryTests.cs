using FluentAssertions;
using LoggingProfiler.Implementations;
using LoggingProfiler.Models;
using Xunit;

namespace LoggingProfiler.Tests
{
    public class LogProfilerFactoryTests
    {
        [Fact]
        public void Create_WithDefaultSettings_ReturnsProfiler()
        {
            // Act
            var profiler = LogProfiler.Factory.Create(null);

            // Assert
            profiler.Should().NotBeNull();
        }

        [Fact]
        public void Create_WithDefinedLogFilePath_ReturnsProfiler()
        {
            // Arrange
            const string LogFilePath = "Test.log";
            var settings = new LogProfilerSettings(logFilePath: LogFilePath);

            // Act
            var profiler = LogProfiler.Factory.Create(settings);

            // Assert
            profiler.Should().NotBeNull();
            settings.LogFilePath.Should().Be(LogFilePath);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Create_WithEmptyLogFilePath_ReturnsProfilerWithDefaultPath(string logFilePath)
        {
            // Arrange
            var settings = new LogProfilerSettings(logFilePath: logFilePath);

            // Act
            var profiler = LogProfiler.Factory.Create(settings);

            // Assert
            profiler.Should().NotBeNull();
            settings.LogFilePath.Should().Be("ProfilerLog.log");
        }
    }
}