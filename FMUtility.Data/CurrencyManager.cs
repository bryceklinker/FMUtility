using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using FMUtility.Data.Extensions;
using FMUtility.Models;

namespace FMUtility.Data
{
    public interface ICurrencyManager
    {
        IEnumerable<CurrencyModel> AvailableCurrencies { get; }
        CurrencyModel SelectedCurrency { get; set; }
        WageType SelectedWageType { get; set; }
        int ToCurrency(int value);
    }

    public class CurrencyManager : ICurrencyManager
    {
        private static CurrencyManager _instance;
        private readonly FMEditorLive.Framework.CurrencyManager _currencyManager;
        private List<CurrencyModel> _availableCurrencies;

        public static CurrencyManager Instance
        {
            get { return _instance ?? (_instance = new CurrencyManager()); }
        }

        public IEnumerable<CurrencyModel> AvailableCurrencies
        {
            get { return _availableCurrencies ?? (_availableCurrencies = MapCurrencies()); }
        }

        public CurrencyModel SelectedCurrency
        {
            get { return AvailableCurrencies.Single(c => c.Name == _currencyManager.SelectedCurrency.CurrencyName); }
            set { _currencyManager.SetCurrency(value.Name); }
        }

        public WageType SelectedWageType
        {
            get { return _currencyManager.SelectedSalaryView.AsWageType(); }
            set { _currencyManager.SetSalaryView(value.AsSalaryView()); }
        }

        private CurrencyManager()
        {
            _currencyManager = new FMEditorLive.Framework.CurrencyManager();
        }

        public int ToCurrency(int value)
        {
            return _currencyManager.ToCurrency(value);
        }

        private List<CurrencyModel> MapCurrencies()
        {
            return _currencyManager.AvailableCurrencies.Select(c => new CurrencyModel
            {
                Name = c.CurrencyName,
                Symbol = c.CurrencySymbol
            }).ToList();
        }
    }
}
