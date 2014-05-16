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

        [SetUp]
        public void Setup()
        {
            _attributeModel = new AttributeModel();
            _attributeColorConverter = new AttributeColorConverter();
        }

        private AttributeModel _attributeModel;
        private AttributeColorConverter _attributeColorConverter;

        [Test]
        public void ConvertShouldBeBlackForNegativeNormalValues()
        {
            _attributeModel.Value = 12;
            _attributeModel.IsNegative = true;
            object brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.Black, brush);
        }

        [Test]
        public void ConvertShouldBeBlackForNormalValues()
        {
            _attributeModel.Value = 12;
            object brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.Black, brush);
        }

        [Test]
        public void ConvertShouldBeDarkGreenForHigherValues()
        {
            _attributeModel.Value = 16;
            object brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.DarkGreen, brush);
        }

        [Test]
        public void ConvertShouldBeDarkGreenForNegativeHigherValues()
        {
            _attributeModel.Value = 8;
            _attributeModel.IsNegative = true;
            object brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.DarkGreen, brush);
        }

        [Test]
        public void ConvertShouldBeLimeGreenForHighestValues()
        {
            _attributeModel.Value = 20;
            object brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.LimeGreen, brush);
        }

        [Test]
        public void ConvertShouldBeLimeGreenForNegativeHighestValues()
        {
            _attributeModel.Value = 4;
            _attributeModel.IsNegative = true;
            object brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.LimeGreen, brush);
        }

        [Test]
        public void ConvertShouldBeNormalForNullValue()
        {
            object brush = _attributeColorConverter.Convert(null, null, null, null);
            Assert.AreEqual(Brushes.Black, brush);
        }

        [Test]
        public void ConvertShouldBeOrangeForLowerValues()
        {
            _attributeModel.Value = 8;
            object brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.Orange, brush);
        }

        [Test]
        public void ConvertShouldBeOrangeForNegativeLowerValues()
        {
            _attributeModel.Value = 16;
            _attributeModel.IsNegative = true;
            object brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.Orange, brush);
        }

        [Test]
        public void ConvertShouldBeRedForLowestValues()
        {
            _attributeModel.Value = 4;
            object brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.Red, brush);
        }

        [Test]
        public void ConvertShouldBeRedForNegativeLowestValues()
        {
            _attributeModel.Value = 20;
            _attributeModel.IsNegative = true;
            object brush = _attributeColorConverter.Convert(_attributeModel, null, null, null);
            Assert.AreEqual(Brushes.Red, brush);
        }
    }
}