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

        [Test]
        public void ExecuteShouldPublishArgsWithName()
        {
            _playerSearchViewModelMock.Setup(s => s.Name).Returns("Johnny");
            PlayerSearchArgs args = null;
            _eventBusMock.Setup(s => s.Publish(It.IsAny<PlayerSearchArgs>())).Callback((PlayerSearchArgs a) => args = a);

            _playerSearchCommand.Execute(null);
            Assert.AreEqual("Johnny", args.Name);
        }

        [Test]
        public void ExecuteShouldPublishArgsWithCurrentAbility()
        {
            _playerSearchViewModelMock.Setup(s => s.CurrentAbility).Returns(123);
            PlayerSearchArgs args = null;
            _eventBusMock.Setup(s => s.Publish(It.IsAny<PlayerSearchArgs>())).Callback((PlayerSearchArgs a) => args = a);

            _playerSearchCommand.Execute(null);
            Assert.AreEqual(123, args.CurrentAbility);
        }

        [Test]
        public void ExecuteShouldPublishArgsWithPotentialAbility()
        {
            _playerSearchViewModelMock.Setup(s => s.PotentialAbility).Returns(456);
            PlayerSearchArgs args = null;
            _eventBusMock.Setup(s => s.Publish(It.IsAny<PlayerSearchArgs>())).Callback((PlayerSearchArgs a) => args = a);

            _playerSearchCommand.Execute(null);
            Assert.AreEqual(456, args.PotentialAbility);
        }
    }
}
