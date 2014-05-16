using System.Windows;
using FMUtility.Converters;
using NUnit.Framework;

namespace FMUtility.Test.Converters
{
    [TestFixture]
    public class InverseVisibilityToBooleanConverterTest
    {
        [SetUp]
        public void Setup()
        {
            _inverseVisibilityToBooleanConverter = new InverseVisibilityToBooleanConverter();
        }

        private InverseVisibilityToBooleanConverter _inverseVisibilityToBooleanConverter;

        [Test]
        public void ConvertGivenCollapsedShouldBeTrue()
        {
            object value = _inverseVisibilityToBooleanConverter.Convert(Visibility.Collapsed, null, null, null);
            Assert.AreEqual(true, value);
        }

        [Test]
        public void ConvertGivenHiddenShouldBeTrue()
        {
            object value = _inverseVisibilityToBooleanConverter.Convert(Visibility.Hidden, null, null, null);
            Assert.AreEqual(true, value);
        }

        [Test]
        public void ConvertGivenVisibleShouldBeFalse()
        {
            object value = _inverseVisibilityToBooleanConverter.Convert(Visibility.Visible, null, null, null);
            Assert.AreEqual(false, value);
        }
    }
}