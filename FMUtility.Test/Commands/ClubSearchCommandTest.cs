using System.ComponentModel;
using FMUtility.Commands;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.Commands
{
    [TestFixture]
    public class ClubSearchCommandTest
    {
        private ClubSearchCommand _clubSearchCommand;
        private Mock<IEventBus> _eventBusMock;
        private Mock<IClubSearchViewModel> _clubSearchViewModelMock;

        [SetUp]
        public void Setup()
        {
            _eventBusMock = new Mock<IEventBus>();
            _clubSearchViewModelMock = new Mock<IClubSearchViewModel>();

            _clubSearchCommand = new ClubSearchCommand(_clubSearchViewModelMock.Object, _eventBusMock.Object);
        }

        [Test]
        public void CanExecuteChangedShouldBeRaised()
        {
            var canExecuteCount = 0;
            _clubSearchCommand.CanExecuteChanged += (o, e) => canExecuteCount++;
            _clubSearchViewModelMock.Raise(v => v.PropertyChanged += null, new PropertyChangedEventArgs(string.Empty));

            Assert.AreEqual(1, canExecuteCount);
        }

        [Test]
        public void CanExecuteShouldBeTrue()
        {
            _clubSearchViewModelMock.Setup(s => s.HasCriteria).Returns(true);
            Assert.IsTrue(_clubSearchCommand.CanExecute(null));
        }

        [Test]
        public void ExecuteShouldPublishArgsWithName()
        {
            _clubSearchViewModelMock.Setup(s => s.Name).Returns("Stuff");
            ClubSearchArgs args = null;
            _eventBusMock.Setup(s => s.Publish(It.IsAny<ClubSearchArgs>())).Callback((ClubSearchArgs a) => args = a);

            _clubSearchCommand.Execute(null);
            Assert.AreEqual("Stuff", args.Name);
        }

        [Test]
        public void ExecuteShouldPublishArgsWithReputation()
        {
            _clubSearchViewModelMock.Setup(s => s.Reputation).Returns(300);
            ClubSearchArgs args = null;
            _eventBusMock.Setup(s => s.Publish(It.IsAny<ClubSearchArgs>())).Callback((ClubSearchArgs a) => args = a);

            _clubSearchCommand.Execute(null);
            Assert.AreEqual(300, args.Reputation);
        }
    }
}
