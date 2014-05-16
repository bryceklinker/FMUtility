using System.Collections.Generic;
using System.Linq;
using FMUtility.Commands;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;
using FMUtility.Gateways;
using FMUtility.Models;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class PlayerSearchViewModelTest
    {
        private PlayerSearchViewModel _playerSearchViewModel;
        private Mock<IPlayerGateway> _playerGatewayMock;
        private Mock<IEventBus> _eventBusMock;

        [SetUp]
        public void Setup()
        {
            _playerGatewayMock = new Mock<IPlayerGateway>();
            _eventBusMock = new Mock<IEventBus>();
            _playerSearchViewModel = new PlayerSearchViewModel(_eventBusMock.Object, _playerGatewayMock.Object);
        }

        [Test]
        public void TitleShouldBeSearch()
        {
            Assert.AreEqual("Search", _playerSearchViewModel.Title);
        }

        [Test]
        public void CloseCanExecuteShouldBeFalse()
        {
            Assert.IsFalse(_playerSearchViewModel.Close.CanExecute(null));
        }

        [Test]
        public void SearchShouldBePlayerSearchCommand()
        {
            Assert.IsInstanceOf<PlayerSearchCommand>(_playerSearchViewModel.Search);
        }

        [Test]
        public void ViewPlayerShouldBeViewPlayerCommand()
        {
            Assert.IsInstanceOf<ViewPlayerCommand>(_playerSearchViewModel.ViewPlayer);
        }

        [Test]
        public void HasCriteriaShouldBeFalse()
        {
            _playerSearchViewModel.CurrentAbility = null;
            _playerSearchViewModel.PotentialAbility = null;
            _playerSearchViewModel.Name = null;

            Assert.IsFalse(_playerSearchViewModel.HasCriteria);
        }

        [Test]
        public void HasCriteriaShouldBeTrueIfNameIsNotNull()
        {
            _playerSearchViewModel.Name = "n";

            Assert.IsTrue(_playerSearchViewModel.HasCriteria);
        }

        [Test]
        public void HasCriteriaShouldBeTrueIfPotentialAbilityIsNotNull()
        {
            _playerSearchViewModel.PotentialAbility = 2;

            Assert.IsTrue(_playerSearchViewModel.HasCriteria);
        }

        [Test]
        public void HasCriteriaShouldBeTrueIfCurrentAbilityIsNotNull()
        {
            _playerSearchViewModel.CurrentAbility = 7;
            Assert.IsTrue(_playerSearchViewModel.HasCriteria);
        }

        [Test]
        public void HandleShouldGetPlayersFromGateway()
        {
            var players = new List<PlayerModel>
            {
                new PlayerModel()
            };
            _playerGatewayMock.Setup(s => s.Get(It.IsAny<PlayerSearchQuery>())).ReturnsAsync(players);

            _playerSearchViewModel.Handle(new PlayerSearchArgs());
            Assert.Contains(players.First(), _playerSearchViewModel.Players);
        }

        [Test]
        public void ConstructionShouldSubscribeToPlayerSearchArgs()
        {
            _eventBusMock.Verify(s => s.Subscribe(_playerSearchViewModel), Times.Once());
        }
    }
}
