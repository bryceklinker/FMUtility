using FMUtility.Commands;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;
using FMUtility.Models;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.Commands
{
    [TestFixture]
    public class ViewPlayerCommandTest
    {
        private ViewPlayerCommand _viewPlayerCommand;
        private Mock<IEventBus> _eventBusMock;

        [SetUp]
        public void Setup()
        {
            _eventBusMock = new Mock<IEventBus>();
            _viewPlayerCommand = new ViewPlayerCommand(_eventBusMock.Object);
        }

        [Test]
        public void CanExecuteShouldBeTrue()
        {
            var canExecute = _viewPlayerCommand.CanExecute(new PlayerModel());
            Assert.IsTrue(canExecute);
        }

        [Test]
        public void ExecuteShouldPublishViewPlayerArgs()
        {
            var playerModel = new PlayerModel
            {
                Id = 4
            };

            _viewPlayerCommand.Execute(playerModel);
            _eventBusMock.Verify(s => s.Publish(Match.Create<ViewPlayerArgs>(a => a.Id == 4)), Times.Once());
        }

        [Test]
        public void ExecuteShouldNotPublishViewPlayerArgs()
        {
            _viewPlayerCommand.Execute(new object());
            _eventBusMock.Verify(s => s.Publish(It.IsAny<ViewPlayerArgs>()), Times.Never());
        }
    }
}
