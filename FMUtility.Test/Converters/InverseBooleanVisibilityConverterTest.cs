using System.Windows;
using FMUtility.Converters;
using NUnit.Framework;

namespace FMUtility.Test.Converters
{
    [TestFixture]
    public class InverseBooleanVisibilityConverterTest
    {
        [SetUp]
        public void Setup()
        {
            _inverseBooleanVisibiltyConverter = new InverseBooleanVisibiltyConverter();
        }

        private InverseBooleanVisibiltyConverter _inverseBooleanVisibiltyConverter;

        [Test]
        public void ConvertGivenFalseShouldReturnVisible()
        {
            var visibility = _inverseBooleanVisibiltyConverter.Convert(false, null, null, null);
            Assert.AreEqual(Visibility.Visible, visibility);
        }

        [Test]
        public void ConvertGivenNullShouldReturnCollapsed()
        {
            var visibility = _inverseBooleanVisibiltyConverter.Convert(null, null, null, null);
            Assert.AreEqual(Visibility.Collapsed, visibility);
        }

        [Test]
        public void ConvertGivenTrueShouldReturnCollapsed()
        {
            var visibility = _inverseBooleanVisibiltyConverter.Convert(true, null, null, null);
            Assert.AreEqual(Visibility.Collapsed, visibility);
        }
    }
}