using FMUtility.ViewModels;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class SearchViewModelTest
    {
        private SearchViewModel _searchViewModel;

        [SetUp]
        public void Setup()
        {
            _searchViewModel = new SearchViewModel();
        }

        [Test]
        public void TitleShouldBeSearch()
        {
            Assert.AreEqual("Search", _searchViewModel.Title);
        }

        [Test]
        public void CloseCanExecuteShouldBeFalse()
        {
            Assert.IsFalse(_searchViewModel.Close.CanExecute(null));
        }
    }
}
