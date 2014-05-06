using FMUtility.Eventing.Args;
using FMUtility.Gateways;
using FMUtility.Models;
using NUnit.Framework;

namespace FMUtility.Test.Gateways
{
    [TestFixture]
    public class PlayerSearchQueryTest
    {
        private PlayerSearchArgs _playerSearchArgs;
        private PlayerModel _playerModel;
        private PlayerSearchQuery _playerSearchQuery;

        [SetUp]
        public void Setup()
        {
            _playerModel = new PlayerModel();
            _playerSearchArgs = new PlayerSearchArgs();
            _playerSearchQuery = new PlayerSearchQuery(_playerSearchArgs);
        }

        [Test]
        public void IsMatchShouldBeFalseIfCurrentAbilityIsTooLow()
        {
            _playerModel.CurrentAbility = 99;
            _playerSearchArgs.CurrentAbility = 100;

            var isMatch = _playerSearchQuery.IsMatch(_playerModel);
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void IsMatchShouldBeFalseIfPotentialAbilityIsTooLow()
        {
            _playerModel.PotentialAbility = 149;
            _playerSearchArgs.PotentialAbility = 150;

            var isMatch = _playerSearchQuery.IsMatch(_playerModel);
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void IsMatchShouldBeFalseIfFirstAndLastNameDoNotContainName()
        {
            _playerModel.FirstName = "First";
            _playerModel.LastName = "Last";
            _playerSearchArgs.Name = "Stuff";

            var isMatch = _playerSearchQuery.IsMatch(_playerModel);
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void IsMatchShouldBeTrueIfCurrentAbilityMatchesWithNoOtherCriteria()
        {
            _playerModel.CurrentAbility = 100;
            _playerSearchArgs.CurrentAbility = 100;
            _playerSearchArgs.PotentialAbility = null;
            _playerSearchArgs.Name = null;

            var isMatch = _playerSearchQuery.IsMatch(_playerModel);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void IsMatchShouldBeTrueIfPotentialAbilityMatchesWithNoOtherCriteria()
        {
            _playerModel.PotentialAbility = 125;
            _playerSearchArgs.CurrentAbility = null;
            _playerSearchArgs.PotentialAbility = 125;
            _playerSearchArgs.Name = null;

            var isMatch = _playerSearchQuery.IsMatch(_playerModel);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void IsMatchShouldBeTrueIfFirstNameContainsNameWithNoOtherCriteria()
        {
            _playerModel.FirstName = "First";
            _playerSearchArgs.CurrentAbility = null;
            _playerSearchArgs.Name = "fi";
            _playerSearchArgs.PotentialAbility = null;

            var isMatch = _playerSearchQuery.IsMatch(_playerModel);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void IsMatchShouldBeTrueIfLastNameContainsNameWithNoOtherCriteria()
        {
            _playerModel.LastName = "Last";
            _playerSearchArgs.CurrentAbility = null;
            _playerSearchArgs.Name = "st";
            _playerSearchArgs.PotentialAbility = null;

            var isMatch = _playerSearchQuery.IsMatch(_playerModel);
            Assert.IsTrue(isMatch);
        }
    }
}
