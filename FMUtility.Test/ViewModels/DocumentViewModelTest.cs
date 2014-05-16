using System;
using FMUtility.Commands;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class DocumentViewModelTest
    {
        [SetUp]
        public void Setup()
        {
            _documentViewModel = new Mock<DocumentViewModel>
            {
                CallBase = true
            };
        }

        private Mock<DocumentViewModel> _documentViewModel;

        [Test]
        public void CloseCanExecuteShouldBeFalse()
        {
            _documentViewModel = new Mock<DocumentViewModel>(false);
            Assert.IsFalse(_documentViewModel.Object.Close.CanExecute(null));
        }

        [Test]
        public void CloseShouldBeCloseDocumentCommand()
        {
            Assert.IsInstanceOf<CloseDocumentCommand>(_documentViewModel.Object.Close);
        }

        [Test]
        public void IdShouldBeGuid()
        {
            Assert.AreNotEqual(Guid.Empty, _documentViewModel.Object.Id);
        }

        [Test]
        public void TitleShouldBeNull()
        {
            Assert.IsNull(_documentViewModel.Object.Title);
        }
    }
}