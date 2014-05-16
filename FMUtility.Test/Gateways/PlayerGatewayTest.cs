﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMUtility.Gateways;
using FMUtility.Models;
using FMUtility.Test.Fakes;
using FMUtility.Threading;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.Gateways
{
    [TestFixture]
    public class PlayerGatewayTest
    {
        private PlayerGateway _playerGateway;
        private Mock<IFmContext> _fmContextMock;
        private FakeTaskFactory _taskFactoryMock;
        private List<PlayerModel> _players;

        [SetUp]
        public void Setup()
        {
            _players = new List<PlayerModel>();
            _fmContextMock = new Mock<IFmContext>();
            _fmContextMock.Setup(s => s.Players).Returns(_players);

            _taskFactoryMock = new FakeTaskFactory();

            _playerGateway = new PlayerGateway(_fmContextMock.Object, _taskFactoryMock);
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

            var result = await _playerGateway.Get(queryMock.Object);
            Assert.Contains(matchingPlayer, result.ToList());
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
    }
}
