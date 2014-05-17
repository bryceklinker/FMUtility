using FMUtility.Data;
using FMUtility.Data.Gateways;
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
        public void ChairmanStatusShouldBeChairmanStatus()
        {
            _clubModel.ChairmanStatus = 89;

            Assert.AreEqual(_clubModel.ChairmanStatus, _clubViewModel.ChairmanStatus);
        }

        [Test]
        public void BalanceShouldBeFinancesBalance()
        {
            _clubModel.Finances = new FinancesModel
            {
                Balance = new CurrencyValueModel()
            };

            Assert.AreSame(_clubModel.Finances.Balance, _clubViewModel.Balance);
        }

        [Test]
        public void CorpFacilitiesShouldBeFinancesCorpFacilities()
        {
            _clubModel.Finances = new FinancesModel
            {
                CorpFacilities = 500
            };

            Assert.AreEqual(_clubModel.Finances.CorpFacilities, _clubViewModel.CorpFacilities);
        }

        [Test]
        public void MaximumWageShouldBeFinancesMaximumWage()
        {
            _clubModel.Finances = new FinancesModel
            {
                MaximumWage = new WageModel()
            };

            Assert.AreSame(_clubModel.Finances.MaximumWage, _clubViewModel.MaximumWage);
        }

        [Test]
        public void PayrollBudgetShouldBeFinancesPayrollBudget()
        {
            _clubModel.Finances = new FinancesModel
            {
                PayrollBudget = new WageModel()
            };

            Assert.AreSame(_clubModel.Finances.PayrollBudget, _clubViewModel.PayrollBudget);
        }

        [Test]
        public void TransferBudgetShouldBeFinancesTransferBudget()
        {
            _clubModel.Finances = new FinancesModel
            {
                TransferBudget = new CurrencyValueModel()
            };

            Assert.AreSame(_clubModel.Finances.TransferBudget, _clubViewModel.TransferBudget);
        }

        [Test]
        public void TransferBudgetRemainingShouldBeFinancesTransferBudgetRemaining()
        {
            _clubModel.Finances = new FinancesModel
            {
                TransferBudgetRemaining = new CurrencyValueModel()
            };

            Assert.AreSame(_clubModel.Finances.TransferBudgetRemaining, _clubViewModel.TransferBudgetRemaining);
        }
    }
}
