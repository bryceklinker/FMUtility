using System.Collections.Generic;
using System.Linq;
using FMUtility.Gateways;
using FMUtility.Models;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.Gateways
{
    [TestFixture]
    public class PlayerGatewayTest
    {
        private PlayerGateway _playerGateway;
        private Mock<IFmContext> _fmContextMock;
        private List<PlayerModel> _players;

        [SetUp]
        public void Setup()
        {
            _players = new List<PlayerModel>();
            _fmContextMock = new Mock<IFmContext>();
            _fmContextMock.Setup(s => s.Players).Returns(_players);
            _playerGateway = new PlayerGateway(_fmContextMock.Object);
        }

        [Test]
        public void QueryShouldReturnResults()
        {
            var matchingPlayer = new PlayerModel();
            var notMatchingPlayer = new PlayerModel();
            _players.Add(matchingPlayer);
            _players.Add(notMatchingPlayer);

            var queryMock = new Mock<IQuery<PlayerModel>>();
            queryMock.Setup(s => s.IsMatch(matchingPlayer)).Returns(true);
            queryMock.Setup(s => s.IsMatch(notMatchingPlayer)).Returns(false);

            var result = _playerGateway.Get(queryMock.Object).ToList();
            Assert.Contains(matchingPlayer, result);
        }

        [Test]
        public void GetShouldGetPlayerWithId()
        {
            var matchingPlayer = new PlayerModel
            {
                Id = 3
            };
            _players.Add(matchingPlayer);

            var result = _playerGateway.Get(3);
            Assert.AreSame(matchingPlayer, result);
        }
    }
}
