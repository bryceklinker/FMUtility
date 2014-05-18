using System.Collections.Generic;
using NUnit.Framework;

namespace FMUtility.Models.Test
{
    [TestFixture]
    public class PlayerModelTest
    {
        private PlayerModel _playerModel;

        [SetUp]
        public void Setup()
        {
            _playerModel = new PlayerModel();
        }

        [Test]
        public void PositionShouldContainAllPositionsGreaterThan15()
        {
            _playerModel.Positions = new List<Position>
            {
                new Position
                {
                    Value = 13,
                    Name = "P"
                },
                new Position
                {
                    Value = 15,
                    Name = "G"
                },
                new Position
                {
                    Value = 20,
                    Name = "H"
                }
            };

            Assert.IsTrue(_playerModel.Position.Contains("G"));
            Assert.IsTrue(_playerModel.Position.Contains("H"));
            Assert.IsFalse(_playerModel.Position.Contains("P"));
        }

        public void PositionShouldBeNullWhenNullPositions()
        {
            _playerModel.Positions = null;

            Assert.IsNull(_playerModel.Position);
        }
    }
}
