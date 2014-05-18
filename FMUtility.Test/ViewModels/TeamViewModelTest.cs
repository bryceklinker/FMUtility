using System.Collections.Generic;
using FMUtility.Commands;
using FMUtility.Models;
using FMUtility.ViewModels;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class TeamViewModelTest
    {
        private TeamModel _teamModel;
        private TeamViewModel _teamViewModel;

        [SetUp]
        public void Setup()
        {
            _teamModel = new TeamModel();
            _teamViewModel = new TeamViewModel(_teamModel);
        }

        [Test]
        public void ViewPlayerShouldBeViewPlayerCommnad()
        {
            Assert.IsInstanceOf<ViewPlayerCommand>(_teamViewModel.ViewPlayer);
        }

        [Test]
        public void NameShouldBeTeamName()
        {
            _teamModel.Name = "Stuff";

            Assert.AreEqual(_teamModel.Name, _teamViewModel.Name);
        }

        [Test]
        public void PlayersShouldBeTeamPlayers()
        {
            _teamModel.Players = new List<PlayerModel>
            {
                new PlayerModel()
            };

            Assert.AreSame(_teamModel.Players, _teamViewModel.Players);
        }
    }
}
