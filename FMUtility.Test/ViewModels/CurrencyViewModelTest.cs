using System.Collections.Generic;
using System.Linq;
using FMUtility.Data.Gateways;
using FMUtility.Models;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class CurrencyViewModelTest
    {
        private List<CurrencyModel> _currencies; 
        private CurrencyViewModel _currencyViewModel;
        private Mock<ICurrencyGateway> _currencyGatewayMock;

        [SetUp]
        public void Setup()
        {
            _currencies = new List<CurrencyModel>
            {
                new CurrencyModel()
            };

            _currencyGatewayMock = new Mock<ICurrencyGateway>();
            _currencyGatewayMock.Setup(s => s.Get()).ReturnsAsync(_currencies);

            _currencyViewModel = new CurrencyViewModel(_currencyGatewayMock.Object);
        }

        [Test]
        public void TitleShouldBeCurrencySettings()
        {
            Assert.AreEqual("Currency Settings", _currencyViewModel.Title);
        }
        
        [Test]
        public void CurrenciesShouldHaveGetCurrencies()
        {
            Assert.Contains(_currencies.First(), _currencyViewModel.Currencies);
        }

        [Test]
        public void SelectedCurrencyShouldGetCurrentCurrency()
        {
            var currency = new CurrencyModel();
            _currencyGatewayMock.Setup(s => s.GetCurrentCurrency()).ReturnsAsync(currency);

            var selectedCurrency = _currencyViewModel.SelectedCurrency;
            Assert.AreSame(currency, selectedCurrency);
        }

        [Test]
        public void SelectedWageTypeShouldGetCurrentWageType()
        {
            const WageType wageType = WageType.Yearly;
            _currencyGatewayMock.Setup(s => s.GetCurrentWageType()).ReturnsAsync(wageType);

            var selectedWageType = _currencyViewModel.SelectedWageType;
            Assert.AreEqual(wageType, selectedWageType);
        }

        [Test]
        public void SetSelectedCurrencyShouldSetCurrency()
        {
            var currency = new CurrencyModel();

            _currencyViewModel.SelectedCurrency = currency;
            _currencyGatewayMock.Verify(s => s.Set(currency), Times.Once());
        }

        [Test]
        public void SetSelectedWageTypeShouldSetWageType()
        {
            const WageType wageType = WageType.Yearly;
            _currencyViewModel.SelectedWageType = wageType;
            _currencyGatewayMock.Verify(s => s.Set(wageType), Times.Once());
        }

        [Test]
        public void WageTypesShouldContainAllWageTypes()
        {
            var wageTypes = _currencyViewModel.WageTypes;
            Assert.Contains(WageType.Monthly, wageTypes);
            Assert.Contains(WageType.Weekly, wageTypes);
            Assert.Contains(WageType.Yearly, wageTypes);
        }
    }
}
