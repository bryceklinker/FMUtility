using FMUtility.Commands;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;
using FMUtility.Models;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.Commands
{
    [TestFixture]
    public class ViewClubCommandTest
    {
        private ViewClubCommand _viewClubCommand;
        private Mock<IEventBus> _eventBusMock;

        [SetUp]
        public void Setup()
        {
            _eventBusMock = new Mock<IEventBus>();
            _viewClubCommand = new ViewClubCommand(_eventBusMock.Object);
        }

        [Test]
        public void CanExecuteShouldBeFalse()
        {
            var canExecute = _viewClubCommand.CanExecute(null);
            Assert.IsFalse(canExecute);
        }

        [Test]
        public void CanExecuteShouldBeTrue()
        {
            var canExecute = _viewClubCommand.CanExecute(new ClubModel());
            Assert.IsTrue(canExecute);
        }

        [Test]
        public void ExecuteShouldPublishViewPlayerArgs()
        {
            var club = new ClubModel
            {
                Id = 3
            };
            ViewClubArgs args = null;
            _eventBusMock.Setup(s => s.Publish(It.IsAny<ViewClubArgs>())).Callback((ViewClubArgs a) => args = a);

            _viewClubCommand.Execute(club);
            Assert.AreEqual(3, args.ClubId);
        }

        [Test]
        public void ExecuteShouldNotPublishViewPlayerArgs()
        {
            _viewClubCommand.Execute(null);
            _eventBusMock.Verify(s => s.Publish(It.IsAny<ViewPlayerArgs>()), Times.Never());
        }
    }
}
