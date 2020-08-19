using NSubstitute;
using NUnit.Framework;

#pragma warning disable S2699 // Tests should include assertions

namespace LogLibrary.Tests
{
    [TestFixture]
    public class LoggerFixture
    {
        private Logger _sut;
        ILogDestination _logDestination;

        [SetUp]
        public void SetUp()
        {
            _logDestination = Substitute.For<ILogDestination>();
        }

        private void CreateLogger(LogLevel level)
        {
            _sut = new Logger(level, _logDestination);
        }

        [Test]
        public void Verify_debug_log_not_logged_if_level_is_info()
        {
            CreateLogger(LogLevel.Info);
            _sut.Log(LogLevel.Debug, "This should not be logged");
            _logDestination.DidNotReceive().AddLog(Arg.Any<LogMessage>());
        }

        [Test]
        public void Verify_info_log_is_logged_if_level_is_info()
        {
            CreateLogger(LogLevel.Info);
            _sut.Log(LogLevel.Info, "This should not be logged");
            _logDestination.Received().AddLog(Arg.Any<LogMessage>());
        }

        [Test]

        public void Verify_warn_log_is_logged_if_level_is_info()
        {
            CreateLogger(LogLevel.Info);
            _sut.Log(LogLevel.Warn, "This should not be logged");
            _logDestination.Received().AddLog(Arg.Any<LogMessage>());
        }

        [Test]
        public void Verify_log_formatting()
        {
            CreateLogger(LogLevel.Info);
            _sut.Log(LogLevel.Info, "This have a parameter {0}", "value");
            _logDestination.Received().AddLog(Arg.Do<LogMessage>(m =>
            {
                Assert.That(m.RenderedMessage, Is.EqualTo("This have a parameter value"));
            }));
        }
    }
}

#pragma warning restore S2699 // Tests should include assertions
