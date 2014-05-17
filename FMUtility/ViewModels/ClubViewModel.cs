using FMUtility.Data;
using FMUtility.Data.Gateways;
using FMUtility.Models;

namespace FMUtility.ViewModels
{
    public class ClubViewModel : DocumentViewModel
    {
        private readonly int _clubId;
        private readonly IClubGateway _clubGateway;
        private ClubModel _clubModel;
        private bool _isLoading;

        public override string Title
        {
            get
            {
                EnsureClub();
                return _isLoading ? "Loading..." : _clubModel.Name;
            }
        }

        public string Name
        {
            get
            {
                EnsureClub();
                return _isLoading ? null : _clubModel.Name;
            }
        }

        public int Reputation
        {
            get
            {
                EnsureClub();
                return _isLoading ? 0 : _clubModel.Reputation;
            }
        }

        public int MaximumAttendance
        {
            get
            {
                EnsureClub();
                return _isLoading ? 0 : _clubModel.MaximumAttendance;
            }
        }

        public int MinimumAttendance
        {
            get
            {
                EnsureClub();
                return _isLoading ? 0 : _clubModel.MinimumAttendance;
            }
        }

        public int AverageAttendance
        {
            get
            {
                EnsureClub();
                return _isLoading ? 0 : _clubModel.AverageAttendance;
            }
        }

        public int TrainingFacilities
        {
            get
            {
                EnsureClub();
                return _isLoading ? 0 : _clubModel.TrainingFacilities;
            }
        }

        public int YouthRecruitment
        {
            get
            {
                EnsureClub();
                return _isLoading ? 0 : _clubModel.YouthRecruitment;
            }
        }

        public int YouthFacilities
        {
            get
            {
                EnsureClub();
                return _isLoading ? 0 : _clubModel.YouthFacilities;
            }
        }

        public int Morale
        {
            get
            {
                EnsureClub();
                return _isLoading ? 0 : _clubModel.Morale;
            }
        }

        public int YearFounded
        {
            get
            {
                EnsureClub();
                return _isLoading ? 0 : _clubModel.YearFounded;
            }
        }

        public int ChairmanStatus
        {
            get
            {
                EnsureClub();
                return _isLoading ? 0 : _clubModel.ChairmanStatus;
            }
        }

        public CurrencyModel Balance
        {
            get
            {
                EnsureClub();
                return _isLoading ? null : _clubModel.Finances.Balance;
            }
        }

        public int CorpFacilities
        {
            get
            {
                EnsureClub();
                return _isLoading ? 0 : _clubModel.Finances.CorpFacilities;
            }
        }

        public WageModel MaximumWage
        {
            get
            {
                EnsureClub();
                return _isLoading ? null : _clubModel.Finances.MaximumWage;
            }
        }

        public WageModel PayrollBudget
        {
            get
            {
                EnsureClub();
                return _isLoading ? null : _clubModel.Finances.PayrollBudget;
            }
        }

        public CurrencyModel TransferBudget
        {
            get
            {
                EnsureClub();
                return _isLoading ? null : _clubModel.Finances.TransferBudget;
            }
        }

        public CurrencyModel TransferBudgetRemaining
        {
            get
            {
                EnsureClub();
                return _isLoading ? null : _clubModel.Finances.TransferBudgetRemaining;
            }
        }

        public ClubViewModel(int clubId) : this(clubId, new ClubGateway())
        {
            
        }

        public ClubViewModel(int clubId, IClubGateway clubGateway)
        {
            _clubId = clubId;
            _clubGateway = clubGateway;
        }

        private async void EnsureClub()
        {
            if (_clubModel == null
                && !_isLoading)
            {
                _isLoading = true;
                _clubModel = await _clubGateway.Get(_clubId);
                FinishLoadingClub();
            }
        }

        private void FinishLoadingClub()
        {
            _isLoading = false;
            RaisePropertyChanged(() => Title);
            RaisePropertyChanged(() => Name);
            RaisePropertyChanged(() => Reputation);
            RaisePropertyChanged(() => MaximumAttendance);
            RaisePropertyChanged(() => MinimumAttendance);
            RaisePropertyChanged(() => AverageAttendance);
            RaisePropertyChanged(() => TrainingFacilities);
            RaisePropertyChanged(() => YouthRecruitment);
            RaisePropertyChanged(() => YouthFacilities);
            RaisePropertyChanged(() => Morale);
            RaisePropertyChanged(() => YearFounded);
            RaisePropertyChanged(() => ChairmanStatus);
        }
    }
}
