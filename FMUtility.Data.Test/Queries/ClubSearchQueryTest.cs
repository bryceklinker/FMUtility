using FMUtility.Core.Eventing.Args;
using FMUtility.Data.Queries;
using FMUtility.Models;
using NUnit.Framework;

namespace FMUtility.Data.Test.Queries
{
    [TestFixture]
    public class ClubSearchQueryTest
    {
        private ClubSearchArgs _clubSearchArgs;
        private ClubModel _clubModel;
        private ClubSearchQuery _clubSearchQuery;

        [SetUp]
        public void Setup()
        {
            _clubModel = new ClubModel();
            _clubSearchArgs = new ClubSearchArgs();
            _clubSearchQuery = new ClubSearchQuery(_clubSearchArgs);
        }

        [Test]
        public void IsMatchSholdBeFalseIfReputationIsTooLow()
        {
            _clubSearchArgs.Reputation = 2000;
            _clubModel.Reputation = 1000;

            var isMatch = _clubSearchQuery.IsMatch(_clubModel);
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void IsMatchShouldBeTrueIfReputationIsHighEnough()
        {
            _clubSearchArgs.Reputation = 300;
            _clubModel.Reputation = 1000;

            var isMatch = _clubSearchQuery.IsMatch(_clubModel);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void IsMatchShouldBeFalseIfNameDoesNotContainName()
        {
            _clubSearchArgs.Name = "S";
            _clubModel.Name = "blue";

            var isMatch = _clubSearchQuery.IsMatch(_clubModel);
            Assert.IsFalse(isMatch);
        }

        [Test]
        public void IsMatchShouldBeTrueIfNameContainsName()
        {
            _clubSearchArgs.Name = "S";
            _clubModel.Name = "stuff";

            var isMatch = _clubSearchQuery.IsMatch(_clubModel);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void IsMatchShouldBeTrueIfNameAndReputationMatch()
        {
            _clubSearchArgs.Name = "S";
            _clubSearchArgs.Reputation = 100;

            _clubModel.Name = "stuff";
            _clubModel.Reputation = 500;

            var isMatch = _clubSearchQuery.IsMatch(_clubModel);
            Assert.IsTrue(isMatch);
        }
    }
}
