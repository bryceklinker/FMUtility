using System.Security.RightsManagement;
using System.Windows.Media;
using FMUtility.Converters;
using FMUtility.Models;
using NUnit.Framework;

namespace FMUtility.Test.Converters
{
    [TestFixture]
    public class AttributeColorConverterTest
    {
        /*
         *         Good    | Negative
         * Highest 20 - 17 | 4 - 1
         * Higher  16 - 13 | 8 - 5
         * Normal  12 - 9  | 12 - 9
         * Lower    8 - 5  | 16 - 13
         * Lowest   4 - 1  | 20 - 17
         */
        private AttributeModel _attributeModel;
        private AttributeColorConverter _attributeColorConverter;

        [SetUp]
        public void Setup()
        {
            _attributeModel = new AttributeModel();
            _attributeColorConverter = new AttributeColorConverter();
        }

        [Test]
        public void ConvertShouldBeRedForLowestValues()
        {
            _attributeModel.Value = 4;
            var brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.Red, brush);
        }

        [Test]
        public void ConvertShouldBeOrangeForLowerValues()
        {
            _attributeModel.Value = 8;
            var brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.Orange, brush);
        }

        [Test]
        public void ConvertShouldBeBlackForNormalValues()
        {
            _attributeModel.Value = 12;
            var brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.Black, brush);
        }

        [Test]
        public void ConvertShouldBeDarkGreenForHigherValues()
        {
            _attributeModel.Value = 16;
            var brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.DarkGreen, brush);
        }

        [Test]
        public void ConvertShouldBeLimeGreenForHighestValues()
        {
            _attributeModel.Value = 20;
            var brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.LimeGreen, brush);
        }

        [Test]
        public void ConvertShouldBeLimeGreenForNegativeHighestValues()
        {
            _attributeModel.Value = 4;
            _attributeModel.IsNegative = true;
            var brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.LimeGreen, brush);
        }

        [Test]
        public void ConvertShouldBeDarkGreenForNegativeHigherValues()
        {
            _attributeModel.Value = 8;
            _attributeModel.IsNegative = true;
            var brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.DarkGreen, brush);
        }

        [Test]
        public void ConvertShouldBeBlackForNegativeNormalValues()
        {
            _attributeModel.Value = 12;
            _attributeModel.IsNegative = true;
            var brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.Black, brush);
        }

        [Test]
        public void ConvertShouldBeOrangeForNegativeLowerValues()
        {
            _attributeModel.Value = 16;
            _attributeModel.IsNegative = true;
            var brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.Orange, brush);
        }

        [Test]
        public void ConvertShouldBeRedForNegativeLowestValues()
        {
            _attributeModel.Value = 20;
            _attributeModel.IsNegative = true;
            var brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.Red, brush);
        }

        [Test]
        public void ConvertShouldBeNormalForNullValue()
        {
            var brush = _attributeColorConverter.Convert(null, null, null, null);
            Assert.AreEqual(Brushes.Black, brush);
        }
    }
}
