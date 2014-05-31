using FMUtility.Data.Mappers;
using FMUtility.Models;
using NUnit.Framework;

namespace FMUtility.Data.Test.Mappers
{
    [TestFixture]
    public class ClubSimpleMapperTest
    {
        private ClubModel _clubModel;
        private ClubSimpleMapper _clubSimpleMapper;

        [SetUp]
        public void Setup()
        {
            _clubModel = new ClubModel();
            _clubSimpleMapper = new ClubSimpleMapper();
        }

        [Test]
        public void MapShouldSetId()
        {
            _clubModel.Id = 4;
            var simple = _clubSimpleMapper.Map(_clubModel);
            Assert.AreEqual(4, simple.Id);
        }

        [Test]
        public void MapShouldSetName()
        {
            _clubModel.Name = "name";
            var simple = _clubSimpleMapper.Map(_clubModel);
            Assert.AreEqual("name", simple.Name);
        }

        [Test]
        public void MapShouldSetReputation()
        {
            _clubModel.Reputation = 600;
            var simple = _clubSimpleMapper.Map(_clubModel);
            Assert.AreEqual(600, simple.Reputation);
        }

        [Test]
        public void MapShouldSetMorale()
        {
            _clubModel.Morale = 60;
            var simple = _clubSimpleMapper.Map(_clubModel);
            Assert.AreEqual(60, simple.Morale);
        }

        [Test]
        public void MapShouldSetYearFounded()
        {
            _clubModel.YearFounded = 700;
            var simple = _clubSimpleMapper.Map(_clubModel);
            Assert.AreEqual(700, simple.YearFounded);
        }
    }
}
