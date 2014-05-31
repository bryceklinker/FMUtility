using System.Collections.Generic;
using System.Linq;
using FMUtility.Data.Gateways;
using FMUtility.Data.Mappers;
using FMUtility.Data.Queries;
using FMUtility.Data.Test.Fakes;
using FMUtility.Models;
using FMUtility.Models.Dtos;
using Moq;
using NUnit.Framework;

namespace FMUtility.Data.Test.Gateways
{
    [TestFixture]
    public class PlayerGatewayTest
    {
        private PlayerGateway _playerGateway;
        private Mock<IFmContext> _fmContextMock;
        private FakeTaskFactory _taskFactoryMock;
        private List<PlayerModel> _players;
        private Mock<IPlayerSimpleMapper> _playerSimpleMapperMock;

        [SetUp]
        public void Setup()
        {
            _players = new List<PlayerModel>();
            _fmContextMock = new Mock<IFmContext>();
            _fmContextMock.Setup(s => s.Players).Returns(_players);

            _taskFactoryMock = new FakeTaskFactory();

            _playerSimpleMapperMock = new Mock<IPlayerSimpleMapper>();
            _playerGateway = new PlayerGateway(_fmContextMock.Object, _playerSimpleMapperMock.Object, _taskFactoryMock);
        }

        [Test]
        public async void GetShouldGetPlayerWithId()
        {
            var matchingPlayer = new PlayerModel
            {
                Id = 3
            };
            _players.Add(matchingPlayer);

            var result = await _playerGateway.Get(3);
            Assert.AreSame(matchingPlayer, result);
        }

        [Test]
        public async void QueryShouldReturnResults()
        {
            var matchingPlayer = new PlayerModel();
            var notMatchingPlayer = new PlayerModel();
            _players.Add(matchingPlayer);
            _players.Add(notMatchingPlayer);

            var queryMock = new Mock<IQuery<PlayerModel>>();
            queryMock.Setup(s => s.IsMatch(matchingPlayer)).Returns(true);
            queryMock.Setup(s => s.IsMatch(notMatchingPlayer)).Returns(false);

            var simplePlayer = new PlayerSimple();
            _playerSimpleMapperMock.Setup(s => s.Map(matchingPlayer)).Returns(simplePlayer);

            var result = await _playerGateway.Get(queryMock.Object);
            Assert.Contains(simplePlayer, result.ToList());
        }
    }
}