using Moq;
using NUnit.Framework;

namespace FMUtility.Server.Test
{
    [TestFixture]
    public class ProgramTest
    {
        private Program _program;
        private Mock<IServer> _serverMock;

        [SetUp]
        public void Setup()
        {
            _serverMock = new Mock<IServer>();
            _program = new Program(_serverMock.Object);
        }

        [Test]
        public void StartShouldStartServer()
        {
            _program.Start();
            _serverMock.Verify(s => s.Start(), Times.Once());
        }

        [Test]
        public void StopShouldStopServer()
        {
            _program.Stop();
            _serverMock.Verify(s => s.Stop(), Times.Once());
        }

        [Test]
        public void StopShouldDisposeOfServer()
        {
            _program.Stop();
            _serverMock.Verify(s => s.Dispose(), Times.Once());
        }
    }
}
