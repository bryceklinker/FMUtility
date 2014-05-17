using System;
using System.Linq;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class MainViewModelTest
    {
        private Mock<IEventBus> _eventBusMock;
        private Mock<IPlayerSearchViewModel> _searchViewModelMock;
        private Mock<IClubSearchViewModel> _clubSearchViewModelMock;
        private MainViewModel _mainViewModel;

        [SetUp]
        public void Setup()
        {
            _eventBusMock = new Mock<IEventBus>();
            _searchViewModelMock = new Mock<IPlayerSearchViewModel>();
            _clubSearchViewModelMock = new Mock<IClubSearchViewModel>();
            _mainViewModel = new MainViewModel(_eventBusMock.Object, _searchViewModelMock.Object, _clubSearchViewModelMock.Object);
        }

        [Test]
        public void ConstructionShouldSubscribeToViewPlayerArgs()
        {
            _eventBusMock.Verify(s => s.Subscribe<ViewPlayerArgs>(_mainViewModel), Times.Once());
        }

        [Test]
        public void ConstructionShouldSubscribeToViewClubArgs()
        {
            _eventBusMock.Verify(s => s.Subscribe<ViewClubArgs>(_mainViewModel), Times.Once());
        }

        [Test]
        public void GetAnchoredDocumentsShouldHavePlayerSearchViewModel()
        {
            var documents = _mainViewModel.AnchoredDocuments;
            Assert.Contains(_searchViewModelMock.Object, documents);
        }

        [Test]
        public void GetAnchoredDocumentsShouldHaveClubSearchViewModel()
        {
            var documents = _mainViewModel.AnchoredDocuments;
            Assert.Contains(_clubSearchViewModelMock.Object, documents);
        }

        [Test]
        public void GetDocumentsShouldNotBeNull()
        {
            Assert.IsNotNull(_mainViewModel.Documents);
        }

        [Test]
        public void HandleCloseDocumentArgsShouldRemoveDocument()
        {
            var documentId = Guid.NewGuid();
            _searchViewModelMock.Setup(s => s.Id).Returns(documentId);
            _mainViewModel.Handle(new CloseDocumentArgs(documentId));

            Assert.IsFalse(_mainViewModel.Documents.Contains(_searchViewModelMock.Object));
        }

        [Test]
        public void HandleViewPlayerArgsShouldAddPlayerDocument()
        {
            var args = new ViewPlayerArgs
            {
                PlayerId = 4
            };
            _mainViewModel.Handle(args);
            var playerDocuments = _mainViewModel.Documents.OfType<PlayerViewModel>();
            Assert.AreEqual(1, playerDocuments.Count());
        }

        [Test]
        public void HandleViewClubArgsShouldAddClubDocument()
        {
            var args = new ViewClubArgs
            {
                ClubId = 5
            };
            _mainViewModel.Handle(args);
            var clubDocuments = _mainViewModel.Documents.OfType<ClubViewModel>();
            Assert.AreEqual(1, clubDocuments.Count());
        }

        [Test]
        public void PublisingCloseShouldRemoveItemFromDocuments()
        {
            _eventBusMock.Verify(s => s.Subscribe<CloseDocumentArgs>(_mainViewModel), Times.Once());
        }
    }
}