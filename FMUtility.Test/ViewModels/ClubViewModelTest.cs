using FMUtility.Data;
using FMUtility.Models;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class ClubViewModelTest
    {
        private const int ClubId = 5;
        private ClubViewModel _clubViewModel;
        private ClubModel _clubModel;
        private Mock<IClubGateway> _clubGatewayMock;

        [SetUp]
        public void Setup()
        {
            _clubModel = new ClubModel
            {
                Id = ClubId
            };

            _clubGatewayMock = new Mock<IClubGateway>();
            _clubGatewayMock.Setup(s => s.Get(ClubId)).ReturnsAsync(_clubModel);

            _clubViewModel = new ClubViewModel(ClubId, _clubGatewayMock.Object);
        }

        [Test]
        public void TitleShouldBeName()
        {
            _clubModel.Name = "Stuff";

            Assert.AreEqual(_clubModel.Name, _clubViewModel.Title);
        }

        [Test]
        public void NameShouldBeName()
        {
            _clubModel.Name = "Arsenal";

            Assert.AreEqual(_clubModel.Name, _clubViewModel.Name);
        }

        [Test]
        public void ReputationShouldBeReputation()
        {
            _clubModel.Reputation = 456;

            Assert.AreEqual(_clubModel.Reputation, _clubViewModel.Reputation);
        }

        [Test]
        public void TrainingFacilitiesShouldBeTrainingFacilities()
        {
            _clubModel.TrainingFacilities = 4;

            Assert.AreEqual(_clubModel.TrainingFacilities, _clubViewModel.TrainingFacilities);
        }

        [Test]
        public void YouthRecruitmentShouldBeYouthRecruitment()
        {
            _clubModel.YouthRecruitment = 6;

            Assert.AreEqual(_clubModel.YouthRecruitment, _clubViewModel.YouthRecruitment);
        }

        [Test]
        public void YouthFacilitiesShouldBeYouthFacilities()
        {
            _clubModel.YouthFacilities = 8;

            Assert.AreEqual(_clubModel.YouthFacilities, _clubViewModel.YouthFacilities);
        }

        [Test]
        public void MaximumAttendanceShouldBeMaximumAttendance()
        {
            _clubModel.MaximumAttendance = 7;

            Assert.AreEqual(_clubModel.MaximumAttendance, _clubViewModel.MaximumAttendance);
        }

        [Test]
        public void MinimumAttendanceShouldBeMinimumAttendance()
        {
            _clubModel.MinimumAttendance = 78;

            Assert.AreEqual(_clubModel.MinimumAttendance, _clubViewModel.MinimumAttendance);
        }

        [Test]
        public void AverageAttendanceShouldBeAverageAttendance()
        {
            _clubModel.AverageAttendance = 89;

            Assert.AreEqual(_clubModel.AverageAttendance, _clubViewModel.AverageAttendance);
        }

        [Test]
        public void MoraleShouldBeMorale()
        {
            _clubModel.Morale = 67;

            Assert.AreEqual(_clubModel.Morale, _clubViewModel.Morale);
        }

        [Test]
        public void YearFoundedShouldBeYearFounded()
        {
            _clubModel.YearFounded = 89;

            Assert.AreEqual(_clubModel.YearFounded, _clubViewModel.YearFounded);
        }

        [Test]
        public void ChairmanStatusShouldBeCharmanStatus()
        {
            _clubModel.ChairmanStatus = 89;

            Assert.AreEqual(_clubModel.ChairmanStatus, _clubViewModel.ChairmanStatus);
        }
    }
}
