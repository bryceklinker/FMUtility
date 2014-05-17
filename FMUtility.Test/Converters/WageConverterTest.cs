using FMUtility.Converters;
using FMUtility.Models;
using NUnit.Framework;

namespace FMUtility.Test.Converters
{
    [TestFixture]
    public class WageConverterTest
    {
        private WageModel _wageModel;
        private WageConverter _wageConverter;

        [SetUp]
        public void Setup()
        {
            _wageModel = new WageModel();
            _wageConverter = new WageConverter();
        }

        [Test]
        public void ConvertShouldStartWithSymbol()
        {
            _wageModel.Symbol = "S";

            var wage = (string)_wageConverter.Convert(_wageModel, null, null, null);
            Assert.IsTrue(wage.StartsWith("S"));
        }

        [Test]
        public void ConvertShouldFormatValue()
        {
            _wageModel.Value = 123456789;

            var wage = (string)_wageConverter.Convert(_wageModel, null, null, null);
            Assert.IsTrue(wage.Contains(" 123,456,789.00 "));
        }

        [Test]
        public void ConvertShouldEndWithWageType()
        {
            _wageModel.WageType = WageType.Weekly;

            var wage = (string)_wageConverter.Convert(_wageModel, null, null, null);
            Assert.IsTrue(wage.EndsWith("Weekly"));
        }

        [Test]
        public void ConvertShouldBeNull()
        {
            var wage = _wageConverter.Convert(null, null, null, null);
            Assert.IsNull(wage);
        }
    }
}
