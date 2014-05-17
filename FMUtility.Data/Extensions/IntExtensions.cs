using FMEditorLive.Framework;
using FMUtility.Models;

namespace FMUtility.Data.Extensions
{
    public static class IntExtensions
    {
        private static readonly ICurrencyManager _currencyManager;

        static IntExtensions()
        {
            _currencyManager = CurrencyManager.Instance;
        }

        public static CurrencyValueModel AsCurrencyValue(this int value)
        {
            return new CurrencyValueModel
            {  
                Name = _currencyManager.SelectedCurrency.Name,
                Symbol = _currencyManager.SelectedCurrency.Symbol,
                Value = _currencyManager.ToCurrency(value)
            };
        }

        public static WageModel AsWageModel(this int value)
        {
            return new WageModel
            {
                Name = _currencyManager.SelectedCurrency.Name,
                Symbol = _currencyManager.SelectedCurrency.Symbol,
                Value = _currencyManager.ToCurrency(value),
                WageType = _currencyManager.SelectedWageType
            };
        }
    }
}
