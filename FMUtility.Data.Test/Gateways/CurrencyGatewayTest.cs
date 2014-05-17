using System.Collections.Generic;
using System.Linq;
using FMUtility.Data.Gateways;
using FMUtility.Data.Test.Fakes;
using FMUtility.Models;
using Moq;
using NUnit.Framework;

namespace FMUtility.Data.Test.Gateways
{
    [TestFixture]
    public class CurrencyGatewayTest
    {
        private Mock<ICurrencyManager> _currencyManagerMock;
        private FakeTaskFactory _taskFactory;
        private CurrencyGateway _currencyGateway;
        private List<CurrencyModel> _currencies;

        [SetUp]
        public void Setup()
        {
            _currencies = new List<CurrencyModel>();

            _currencyManagerMock = new Mock<ICurrencyManager>();
            _currencyManagerMock.Setup(s => s.AvailableCurrencies).Returns(_currencies);

            _taskFactory = new FakeTaskFactory();
            _currencyGateway = new CurrencyGateway(_currencyManagerMock.Object, _taskFactory);
        }

        [Test]
        public async void GetShouldReturnAllCurrencies()
        {
            _currencies.Add(new CurrencyModel());

            var currencies = await _currencyGateway.Get();
            Assert.Contains(_currencies.First(), currencies);
        }

        [Test]
        public async void GetCurrentCurrencyShouldGetSelectedCurrency()
        {
            var selectedCurrency = new CurrencyModel();
            _currencyManagerMock.Setup(s => s.SelectedCurrency).Returns(selectedCurrency);

            var currency = await _currencyGateway.GetCurrentCurrency();
            Assert.AreSame(selectedCurrency, currency);
        }

        [Test]
        public async void GetWageTypeShouldGetSelectedWageType()
        {
            const WageType selectedWageType = WageType.Yearly;
            _currencyManagerMock.Setup(s => s.SelectedWageType).Returns(selectedWageType);

            var wageType = await _currencyGateway.GetCurrentWageType();
            Assert.AreEqual(selectedWageType, wageType);
        }

        [Test]
        public async void SetCurrencyShouldSetCurrency()
        {
            var currencyModel = new CurrencyModel();
            await _currencyGateway.Set(currencyModel);
            _currencyManagerMock.VerifySet(s => s.SelectedCurrency = currencyModel, Times.Once());
        }

        [Test]
        public async void SetWageTypeShouldSetWageType()
        {
            const WageType wageType = WageType.Yearly;
            await _currencyGateway.Set(wageType);
            _currencyManagerMock.VerifySet(s => s.SelectedWageType = wageType, Times.Once());
        }
    }
}
