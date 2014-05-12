using FMUtility.Gateways;
using FMUtility.Models;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class PlayerViewModelTest
    {
        private const int Id = 3;
        private Mock<IPlayerGateway> _playerGatewayMock;
        private PlayerViewModel _playerViewModel;
        private PlayerModel _player;

        [SetUp]
        public void Setup()
        {
            _player = new PlayerModel();
            _playerGatewayMock = new Mock<IPlayerGateway>();
            _playerGatewayMock.Setup(s => s.Get(Id)).Returns(_player);
            _playerViewModel = new PlayerViewModel(Id, _playerGatewayMock.Object);
        }

        [Test]
        public void FirstName_ShouldBePlayerFirstName()
        {
            _player.FirstName = "John";
            Assert.AreEqual(_player.FirstName, _playerViewModel.FirstName);
        }

        [Test]
        public void LastName_ShouldBePlayerLastName()
        {
            _player.LastName = "Bo";
            Assert.AreEqual(_player.LastName, _playerViewModel.LastName);
        }

        [Test]
        public void CurrentAbility_ShouldBePlayerCurrentAbility()
        {
            _player.CurrentAbility = 100;
            Assert.AreEqual(_player.CurrentAbility, _playerViewModel.CurrentAbility);
        }

        [Test]
        public void PotentialAbility_ShouldBePlayerPotentialAbility()
        {
            _player.PotentialAbility = 23;
            Assert.AreEqual(_player.PotentialAbility, _playerViewModel.PotentialAbility);
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
