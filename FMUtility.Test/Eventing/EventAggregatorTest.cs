using System;
using FMUtility.Eventing;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.Eventing
{
    [TestFixture]
    public class EventAggregatorTest
    {
        private EventBus _eventBus;
        private Mock<IHandler<object>> _handlerMock;

        [SetUp]
        public void Setup()
        {
            _handlerMock = new Mock<IHandler<object>>();
            _eventBus = new EventBus();
        }

        [Test]
        public void PublishShouldSendEventToSubscribers()
        {
            _eventBus.Subscribe(_handlerMock.Object);
            var args = new object();
            _eventBus.Publish(args);
            _handlerMock.Verify(s => s.Handle(args), Times.Once());
        }

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
    }
}
