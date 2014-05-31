using System.Collections.Generic;
using FMUtility.Core.Eventing.Args;
using FMUtility.Data.Gateways;
using FMUtility.Data.Queries;
using FMUtility.Models;
using FMUtility.Models.Dtos;
using FMUtility.Server.Controllers;
using Moq;
using NUnit.Framework;

namespace FMUtility.Server.Test.Controllers
{
    [TestFixture]
    public class PlayerControllerTest
    {
        private Mock<IPlayerGateway> _playerGatwayMock;
        private PlayerController _playerController;

        [SetUp]
        public void Setup()
        {
            _playerGatwayMock = new Mock<IPlayerGateway>();
            _playerController = new PlayerController(_playerGatwayMock.Object);
        }

        [Test]
        public void GetGivenIdShouldGetPlayerFromGateway()
        {
            var player = new PlayerModel();
            _playerGatwayMock.Setup(s => s.Get(45)).ReturnsAsync(player);

            var result = _playerController.Get(45);
            Assert.AreEqual(player, result.Content);
        }

        [Test]
        public void SearchShouldSearchPlayerGateway()
        {
            var players = new List<PlayerSimple>
            {
                new PlayerSimple()
            };
            _playerGatwayMock.Setup(s => s.Get(It.IsAny<PlayerSearchQuery>())).ReturnsAsync(players);

            var args = new PlayerSearchArgs();
            var result = _playerController.Search(args);
            Assert.AreSame(players, result.Content);
        }
    }
}
