using FMUtility.Commands;
using FMUtility.ViewModels;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class PlayerSearchViewModelTest
    {
        private PlayerSearchViewModel _playerSearchViewModel;

        [SetUp]
        public void Setup()
        {
            _playerSearchViewModel = new PlayerSearchViewModel();
        }

        [Test]
        public void TitleShouldBeSearch()
        {
            Assert.AreEqual("Player Search", _playerSearchViewModel.Title);
        }

        [Test]
        public void CloseCanExecuteShouldBeFalse()
        {
            Assert.IsFalse(_playerSearchViewModel.Close.CanExecute(null));
        }

        [Test]
        public void SearchShouldBePlayerSearchCommand()
        {
            Assert.IsInstanceOf<PlayerSearchCommand>(_playerSearchViewModel.Search);
        }

        [Test]
        public void HasCriteriaShouldBeFalse()
        {
            _playerSearchViewModel.CurrentAbility = null;
            _playerSearchViewModel.PotentialAbility = null;
            _playerSearchViewModel.Name = null;

            Assert.IsFalse(_playerSearchViewModel.HasCriteria);
        }

        [Test]
        public void HasCriteriaShouldBeTrueIfNameIsNotNull()
        {
            _playerSearchViewModel.Name = "n";

            Assert.IsTrue(_playerSearchViewModel.HasCriteria);
        }

        [Test]
        public void HasCriteriaShouldBeTrueIfPotentialAbilityIsNotNull()
        {
            _playerSearchViewModel.PotentialAbility = 2;

            Assert.IsTrue(_playerSearchViewModel.HasCriteria);
        }

        [Test]
        public void HasCriteriaShouldBeTrueIfCurrentAbilityIsNotNull()
        {
            _playerSearchViewModel.CurrentAbility = 7;
            Assert.IsTrue(_playerSearchViewModel.HasCriteria);
        }
    }
}
