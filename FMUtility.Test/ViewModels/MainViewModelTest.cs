using System;
using System.Collections.Generic;
using System.Linq;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;
using FMUtility.Gateways;
using FMUtility.Models;
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
        private MainViewModel _mainViewModel;

        [SetUp]
        public void Setup()
        {
            _eventBusMock = new Mock<IEventBus>();
            _searchViewModelMock = new Mock<IPlayerSearchViewModel>();
            _mainViewModel = new MainViewModel(_eventBusMock.Object, _searchViewModelMock.Object);
        }

        [Test]
        public void GetAnchoredDocumentsShouldHaveSearchViewModel()
        {
            var documents = _mainViewModel.AnchoredDocuments;
            Assert.Contains(_searchViewModelMock.Object, documents);
        }

        [Test]
        public void GetDocumentsShouldNotBeNull()
        {
            Assert.IsNotNull(_mainViewModel.Documents);
        }

        [Test]
        public void PublisingCloseShouldRemoveItemFromDocuments()
        {
            _eventBusMock.Verify(s => s.Subscribe<CloseDocumentArgs>(_mainViewModel), Times.Once());
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
            var args = new ViewPlayerArgs(4);
            _mainViewModel.Handle(args);
            var playerDocuments = _mainViewModel.Documents.OfType<PlayerViewModel>();
            Assert.AreEqual(1, playerDocuments.Count());
        }

        [Test]
        public void ConstructionShouldSubscribeToViewPlayerArgs()
        {
            _eventBusMock.Verify(s => s.Subscribe<ViewPlayerArgs>(_mainViewModel), Times.Once());
        }
    }
}
