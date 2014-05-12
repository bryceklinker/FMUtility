using System.Collections.Generic;
using System.Linq;
using FMUtility.Commands;
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

        [SetUp]
        public void Setup()
        {
            _playerGatewayMock = new Mock<IPlayerGateway>();
            _playerSearchViewModel = new PlayerSearchViewModel(_playerGatewayMock.Object);
        }

        [Test]
        public void TitleShouldBeSearch()
        {
            Assert.AreEqual("FirstName Search", _playerSearchViewModel.Title);
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
            _playerGatewayMock.Setup(s => s.Get(It.IsAny<PlayerSearchQuery>())).Returns(players);

            _playerSearchViewModel.Handle(new PlayerSearchArgs());
            Assert.Contains(players.First(), _playerSearchViewModel.Players);
        }
    }
}
