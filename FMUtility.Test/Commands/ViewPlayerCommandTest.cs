using FMUtility.Commands;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;
using FMUtility.Models;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.Commands
{
    [TestFixture]
    public class ViewPlayerCommandTest
    {
        [SetUp]
        public void Setup()
        {
            _eventBusMock = new Mock<IEventBus>();
            _viewPlayerCommand = new ViewPlayerCommand(_eventBusMock.Object);
        }

        private ViewPlayerCommand _viewPlayerCommand;
        private Mock<IEventBus> _eventBusMock;

        [Test]
        public void CanExecuteShouldBeTrue()
        {
            bool canExecute = _viewPlayerCommand.CanExecute(new PlayerModel());
            Assert.IsTrue(canExecute);
        }

        [Test]
        public void ExecuteShouldNotPublishViewPlayerArgs()
        {
            _viewPlayerCommand.Execute(new object());
            _eventBusMock.Verify(s => s.Publish(It.IsAny<ViewPlayerArgs>()), Times.Never());
        }

        [Test]
        public void ExecuteShouldPublishViewPlayerArgs()
        {
            var playerModel = new PlayerModel
            {
                Id = 4
            };

            _viewPlayerCommand.Execute(playerModel);
            _eventBusMock.Verify(s => s.Publish(Match.Create<ViewPlayerArgs>(a => a.PlayerId == 4)), Times.Once());
        }
    }
}