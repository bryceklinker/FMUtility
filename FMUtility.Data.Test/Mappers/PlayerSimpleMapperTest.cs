using FMUtility.Data.Mappers;
using FMUtility.Models;
using NUnit.Framework;

namespace FMUtility.Data.Test.Mappers
{
    [TestFixture]
    public class PlayerSimpleMapperTest
    {
        private PlayerSimpleMapper _playerSimpleMapper;
        private PlayerModel _playerModel;

        [SetUp]
        public void Setup()
        {
            _playerModel = new PlayerModel();
            _playerSimpleMapper = new PlayerSimpleMapper();
        }

        [Test]
        public void MapShouldSetId()
        {
            _playerModel.Id = 5;
            var simple = _playerSimpleMapper.Map(_playerModel);
            Assert.AreEqual(5, simple.Id);
        }

        [Test]
        public void MapShouldSetFirstName()
        {
            _playerModel.FirstName = "name";
            var simple = _playerSimpleMapper.Map(_playerModel);
            Assert.AreEqual("name", simple.FirstName);
        }

        [Test]
        public void MapShouldSetLastName()
        {
            _playerModel.LastName = "name";
            var simple = _playerSimpleMapper.Map(_playerModel);
            Assert.AreEqual("name", simple.LastName);
        }

        [Test]
        public void MapShouldSetClubId()
        {
            _playerModel.ClubId = 6;
            var simple = _playerSimpleMapper.Map(_playerModel);
            Assert.AreEqual(6, simple.ClubId);
        }

        [Test]
        public void MapShouldSetClubName()
        {
            _playerModel.ClubName = "name";
            var simple = _playerSimpleMapper.Map(_playerModel);
            Assert.AreEqual("name", simple.ClubName);
        }

        [Test]
        public void MapShouldSetCurrentAbility()
        {
            _playerModel.CurrentAbility = 6;
            var simple = _playerSimpleMapper.Map(_playerModel);
            Assert.AreEqual(6, simple.CurrentAbility);
        }

        [Test]
        public void MapShouldSetPotentialAbility()
        {
            _playerModel.PotentialAbility = 7;
            var simple = _playerSimpleMapper.Map(_playerModel);
            Assert.AreEqual(7, simple.PotentialAbility);
        }
    }
}
