using System.Collections.ObjectModel;
using System.Linq;
using FMUtility.Data.Gateways;
using FMUtility.Models;

namespace FMUtility.ViewModels
{
    public class CurrencyViewModel : DocumentViewModel
    {
        private readonly ICurrencyGateway _currencyGateway;
        private bool _isLoading;
        private readonly ObservableCollection<CurrencyModel> _currencies;
        private readonly ObservableCollection<WageType> _wageTypes; 

        public CurrencyViewModel() : this(new CurrencyGateway())
        {
            
        }

        public CurrencyViewModel(ICurrencyGateway currencyGateway)
        {
            _currencyGateway = currencyGateway;
            _currencies = new ObservableCollection<CurrencyModel>();
            _wageTypes = new ObservableCollection<WageType>
            {
                WageType.Monthly,
                WageType.Weekly,
                WageType.Yearly
            };
        }

        public override string Title
        {
            get { return "Currency Settings"; }
        }

        public ObservableCollection<CurrencyModel> Currencies
        {
            get
            {
                EnsureCurrencies();
                return _isLoading ? null : _currencies;
            }
        }

        public CurrencyModel SelectedCurrency
        {
            get { return _currencyGateway.GetCurrentCurrency().Result; }
            set
            {
                _currencyGateway.Set(value).Wait();
                RaisePropertyChanged(() => SelectedCurrency);
            }
        }

        public WageType SelectedWageType
        {
            get { return _currencyGateway.GetCurrentWageType().Result; }
            set
            {
                _currencyGateway.Set(value).Wait();
                RaisePropertyChanged(() => SelectedWageType);
            }
        }

        public ObservableCollection<WageType> WageTypes
        {
            get { return _wageTypes; }
        }

        private async void EnsureCurrencies()
        {
            if (!_isLoading && !_currencies.Any())
            {
                _isLoading = true;

                var currencies = await _currencyGateway.Get();
                foreach (var currency in currencies)
                    _currencies.Add(currency);

                FinishLoadingCurrencies();
            }
        }

        private void FinishLoadingCurrencies()
        {
            _isLoading = false;
            RaisePropertyChanged(() => Currencies);
        }
    }
}
