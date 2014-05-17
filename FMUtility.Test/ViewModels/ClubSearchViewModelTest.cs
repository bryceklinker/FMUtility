using System.Collections.Generic;
using System.Linq;
using FMUtility.Commands;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;
using FMUtility.Data;
using FMUtility.Data.Queries;
using FMUtility.Models;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class ClubSearchViewModelTest
    {
        private ClubSearchViewModel _clubSearchViewModel;
        private Mock<IClubGateway> _clubGatewayMock;
        private Mock<IEventBus> _eventBusMock;

        [SetUp]
        public void Setup()
        {
            _clubGatewayMock = new Mock<IClubGateway>();
            _eventBusMock = new Mock<IEventBus>();
            _clubSearchViewModel = new ClubSearchViewModel(_eventBusMock.Object, _clubGatewayMock.Object);
        }

        [Test]
        public void ConstructorShouldSubscribeToSearchClubArgs()
        {
            _eventBusMock.Verify(s => s.Subscribe(_clubSearchViewModel), Times.Once());
        }

        [Test]
        public void CanCloseShouldBeFalse()
        {
            Assert.IsFalse(_clubSearchViewModel.CanClose);
        }

        [Test]
        public void TitleShouldBeClubSearch()
        {
            Assert.AreEqual("Club Search", _clubSearchViewModel.Title);
        }

        [Test]
        public void SearchShouldBeClubSearchCommand()
        {
            Assert.IsInstanceOf<ClubSearchCommand>(_clubSearchViewModel.Search);
        }

        [Test]
        public void ViewClubShouldBeViewClubCommand()
        {
            Assert.IsInstanceOf<ViewClubCommand>(_clubSearchViewModel.ViewClub);
        }

        [Test]
        public void SetNameShouldRaisePropertyChanged()
        {
            var changed = 0;
            _clubSearchViewModel.PropertyChanged += (s, e) => changed++;

            _clubSearchViewModel.Name = "Stuff";
            Assert.AreEqual(1, changed);
        }

        [Test]
        public void SetReputationShouldRaisePropertyChanged()
        {
            var changed = 0;
            _clubSearchViewModel.PropertyChanged += (s, e) => changed++;

            _clubSearchViewModel.Reputation = 23;
            Assert.AreEqual(1, changed);
        }

        [Test]
        public void HasCriteriaGivenNameShouldBeTrue()
        {
            _clubSearchViewModel.Name = "stuff";

            Assert.IsTrue(_clubSearchViewModel.HasCriteria);
        }

        [Test]
        public void HasCriteriaGivenReputationShouldBeTrue()
        {
            _clubSearchViewModel.Reputation = 5;

            Assert.IsTrue(_clubSearchViewModel.HasCriteria);
        }

        [Test]
        public void HasCriteriaShouldBeFalse()
        {
            _clubSearchViewModel.Name = null;
            _clubSearchViewModel.Reputation = null;

            Assert.IsFalse(_clubSearchViewModel.HasCriteria);
        }

        [Test]
        public void HandleShouldQueryGatewayForClubs()
        {
            var clubs = new List<ClubModel>
            {
                new ClubModel()
            };
            _clubGatewayMock.Setup(s => s.Get(It.IsAny<ClubSearchQuery>())).ReturnsAsync(clubs);

            _clubSearchViewModel.Handle(new ClubSearchArgs());
            Assert.Contains(clubs.First(), _clubSearchViewModel.Clubs);
        }
    }
}
