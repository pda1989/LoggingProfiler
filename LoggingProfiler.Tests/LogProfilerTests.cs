using FluentAssertions;
using LoggingProfiler.Implementations;
using Xunit;

namespace LoggingProfiler.Tests
{
    public class LogProfilerTests
    {
        [Fact]
        public void Test1()
        {
            // Act
            var profiler = LogProfiler.Factory.Create();

            // Assert
            profiler.Should().NotBeNull();
        }
    }
}