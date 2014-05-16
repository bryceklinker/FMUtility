using System.Collections.Generic;
using FMUtility.Data;
using FMUtility.Models;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class PlayerViewModelTest
    {
        [SetUp]
        public void Setup()
        {
            _player = new PlayerModel();
            _playerGatewayMock = new Mock<IPlayerGateway>();
            _playerGatewayMock.Setup(s => s.Get(Id)).ReturnsAsync(_player);

            _playerViewModel = new PlayerViewModel(Id, _playerGatewayMock.Object);
        }

        private const int Id = 3;
        private Mock<IPlayerGateway> _playerGatewayMock;
        private PlayerViewModel _playerViewModel;
        private PlayerModel _player;

        [Test]
        public void CurrentAbility_ShouldBePlayerCurrentAbility()
        {
            _player.CurrentAbility = 100;
            Assert.AreEqual(_player.CurrentAbility, _playerViewModel.CurrentAbility);
        }

        [Test]
        public void FirstName_ShouldBePlayerFirstName()
        {
            _player.FirstName = "John";
            Assert.AreEqual(_player.FirstName, _playerViewModel.FirstName);
        }

        [Test]
        public void GoalKeepingShouldBePlayerGoalkeepingAttributes()
        {
            _player.GoalKeeping = new List<AttributeModel>
            {
                new AttributeModel()
            };
            Assert.AreSame(_player.GoalKeeping, _playerViewModel.Goalkeeping);
        }

        [Test]
        public void HiddenShouldBePlayerHiddenAttributes()
        {
            _player.Hidden = new List<AttributeModel>
            {
                new AttributeModel()
            };
            Assert.AreSame(_player.Hidden, _playerViewModel.Hidden);
        }

        [Test]
        public void IsGoalKeeperShouldBeTrue()
        {
            _player.Positions = new List<Position>
            {
                new Position
                {
                    Area = Area.Goalkeeping,
                    Value = 2
                }
            };

            Assert.IsTrue(_playerViewModel.IsGoalKeeper);
        }

        [Test]
        public void LastName_ShouldBePlayerLastName()
        {
            _player.LastName = "Bo";
            Assert.AreEqual(_player.LastName, _playerViewModel.LastName);
        }

        [Test]
        public void MentalShouldBePlayerMentalAttributes()
        {
            _player.Mental = new List<AttributeModel>
            {
                new AttributeModel()
            };
            Assert.AreSame(_player.Mental, _playerViewModel.Mental);
        }

        [Test]
        public void PhysicalShouldBePlayerPhysicalAttributes()
        {
            _player.Physical = new List<AttributeModel>
            {
                new AttributeModel()
            };
            Assert.AreSame(_player.Physical, _playerViewModel.Physical);
        }

        [Test]
        public void PotentialAbility_ShouldBePlayerPotentialAbility()
        {
            _player.PotentialAbility = 23;
            Assert.AreEqual(_player.PotentialAbility, _playerViewModel.PotentialAbility);
        }

        [Test]
        public void TechnicalShouldBePlayerTechnicalAttributes()
        {
            _player.Techincal = new List<AttributeModel>
            {
                new AttributeModel()
            };
            Assert.AreSame(_player.Techincal, _playerViewModel.Technical);
        }

        [Test]
        public void Title_ShouldBePlayerFirstAndLastName()
        {
            _player.FirstName = "John";
            _player.LastName = "Doe";

            Assert.AreEqual("John Doe", _playerViewModel.Title);
        }
    }
}