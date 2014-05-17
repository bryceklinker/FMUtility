using FMUtility.Core.Eventing;
using Moq;
using NUnit.Framework;

namespace FMUtility.Core.Test.Eventing
{
    [TestFixture]
    public class EventBusTest
    {
        [SetUp]
        public void Setup()
        {
            _handlerMock = new Mock<IHandle<object>>();
            _eventBus = new EventBus();
        }

        private EventBus _eventBus;
        private Mock<IHandle<object>> _handlerMock;

        [Test]
        public void PublishShouldSendEventToManySubscribers()
        {
            _eventBus.Subscribe(_handlerMock.Object);
            _eventBus.Subscribe(_handlerMock.Object);
            _eventBus.Subscribe(_handlerMock.Object);

            var args = new object();
            _eventBus.Publish(args);
            _handlerMock.Verify(s => s.Handle(args), Times.Exactly(3));
        }

        [Test]
        public void PublishShouldSendEventToSubscribers()
        {
            _eventBus.Subscribe(_handlerMock.Object);
            var args = new object();
            _eventBus.Publish(args);
            _handlerMock.Verify(s => s.Handle(args), Times.Once());
        }
    }
}