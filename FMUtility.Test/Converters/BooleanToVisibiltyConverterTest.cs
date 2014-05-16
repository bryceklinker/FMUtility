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
            object value = _booleanToVisibilityConverter.ConvertBack(Visibility.Collapsed, null, null, null);
            Assert.AreEqual(false, value);
        }

        [Test]
        public void ConvertBackGivenHiddenShouldBeFalse()
        {
            object value = _booleanToVisibilityConverter.ConvertBack(Visibility.Hidden, null, null, null);
            Assert.AreEqual(false, value);
        }

        [Test]
        public void ConvertBackGivenVisibleShouldBeTrue()
        {
            object value = _booleanToVisibilityConverter.ConvertBack(Visibility.Visible, null, null, null);
            Assert.AreEqual(true, value);
        }

        [Test]
        public void ConvertGivenFalseShouldBeCollapsed()
        {
            object visibility = _booleanToVisibilityConverter.Convert(false, null, null, null);
            Assert.AreEqual(Visibility.Collapsed, visibility);
        }

        [Test]
        public void ConvertGivenNullShouldBeCollapsed()
        {
            object visibility = _booleanToVisibilityConverter.Convert(null, null, null, null);
            Assert.AreEqual(Visibility.Collapsed, visibility);
        }

        [Test]
        public void ConvertGivenTrueShouldBeVisible()
        {
            object visibility = _booleanToVisibilityConverter.Convert(true, null, null, null);
            Assert.AreEqual(Visibility.Visible, visibility);
        }
    }
}