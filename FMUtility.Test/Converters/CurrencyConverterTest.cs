using FMUtility.Converters;
using FMUtility.Models;
using NUnit.Framework;

namespace FMUtility.Test.Converters
{
    [TestFixture]
    public class CurrencyConverterTest
    {
        private CurrencyConverter _currencyConverter;
        private CurrencyValueModel _currencyModel;

        [SetUp]
        public void Setup()
        {
            _currencyModel = new CurrencyValueModel();
            _currencyConverter = new CurrencyConverter();
        }

        [Test]
        public void ConvertShouldHaveCurrencySymbol()
        {
            _currencyModel.Symbol = "$";
            var currency = (string)_currencyConverter.Convert(_currencyModel, null, null, null);
            Assert.IsTrue(currency.StartsWith("$"));
        }

        [Test]
        public void ConvertShouldFormatValueAsCurrency()
        {
            _currencyModel.Value = 123456789;
            var currency = (string)_currencyConverter.Convert(_currencyModel, null, null, null);
            Assert.AreEqual(" 123,456,789.00", currency);
        }

        [Test]
        public void ConvertShouldBeNull()
        {
            var currency = _currencyConverter.Convert(null, null, null, null);
            Assert.IsNull(currency);
        }
    }
}
