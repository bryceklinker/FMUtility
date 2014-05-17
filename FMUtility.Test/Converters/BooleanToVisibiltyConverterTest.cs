using System.Windows;
using FMUtility.Converters;
using NUnit.Framework;

namespace FMUtility.Test.Converters
{
    [TestFixture]
    public class BooleanToVisibiltyConverterTest
    {
        [SetUp]
        public void Setup()
        {
            _booleanToVisibilityConverter = new BooleanToVisibilityConverter();
        }

        private BooleanToVisibilityConverter _booleanToVisibilityConverter;

        [Test]
        public void ConvertBackGivenCollapsedShouldBeFalse()
        {
            var value = _booleanToVisibilityConverter.ConvertBack(Visibility.Collapsed, null, null, null);
            Assert.AreEqual(false, value);
        }

        [Test]
        public void ConvertBackGivenHiddenShouldBeFalse()
        {
            var value = _booleanToVisibilityConverter.ConvertBack(Visibility.Hidden, null, null, null);
            Assert.AreEqual(false, value);
        }

        [Test]
        public void ConvertBackGivenVisibleShouldBeTrue()
        {
            var value = _booleanToVisibilityConverter.ConvertBack(Visibility.Visible, null, null, null);
            Assert.AreEqual(true, value);
        }

        [Test]
        public void ConvertGivenFalseShouldBeCollapsed()
        {
            var visibility = _booleanToVisibilityConverter.Convert(false, null, null, null);
            Assert.AreEqual(Visibility.Collapsed, visibility);
        }

        [Test]
        public void ConvertGivenNullShouldBeCollapsed()
        {
            var visibility = _booleanToVisibilityConverter.Convert(null, null, null, null);
            Assert.AreEqual(Visibility.Collapsed, visibility);
        }

        [Test]
        public void ConvertGivenTrueShouldBeVisible()
        {
            var visibility = _booleanToVisibilityConverter.Convert(true, null, null, null);
            Assert.AreEqual(Visibility.Visible, visibility);
        }
    }
}