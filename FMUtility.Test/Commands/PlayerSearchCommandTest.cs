using System.ComponentModel;
using FMUtility.Commands;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.Commands
{
    [TestFixture]
    public class PlayerSearchCommandTest
    {
        private PlayerSearchCommand _playerSearchCommand;
        private Mock<IPlayerSearchViewModel> _playerSearchViewModelMock;
        private Mock<IEventBus> _eventBusMock;

        [SetUp]
        public void Setup()
        {
            _playerSearchViewModelMock = new Mock<IPlayerSearchViewModel>();
            _eventBusMock = new Mock<IEventBus>();
            _playerSearchCommand = new PlayerSearchCommand(_playerSearchViewModelMock.Object, _eventBusMock.Object);
        }

        [Test]
        public void ExecuteShouldPublishPlayerSearchArgs()
        {
            _playerSearchCommand.Execute(null);
            _eventBusMock.Verify(s => s.Publish(It.IsAny<PlayerSearchArgs>()), Times.Once());
        }

        [Test]
        public void CanExecuteChangedShouldBeRaised()
        {
            var canExecuteCount = 0;
            _playerSearchCommand.CanExecuteChanged += (o, e) => canExecuteCount++;
            _playerSearchViewModelMock.Raise(v => v.PropertyChanged += null, new PropertyChangedEventArgs(string.Empty));

            Assert.AreEqual(1, canExecuteCount);
        }

        [Test]
        public void CanExecuteShouldBeTrue()
        {
            _playerSearchViewModelMock.Setup(s => s.HasCriteria).Returns(true);
            Assert.IsTrue(_playerSearchCommand.CanExecute(null));
        }
    }
}
