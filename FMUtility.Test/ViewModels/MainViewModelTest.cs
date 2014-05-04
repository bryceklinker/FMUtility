﻿using System;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class MainViewModelTest
    {
        private Mock<IEventBus> _eventBusMock;
        private Mock<ISearchViewModel> _searchViewModelMock;
        private MainViewModel _mainViewModel;

        [SetUp]
        public void Setup()
        {
            _eventBusMock = new Mock<IEventBus>();
            _searchViewModelMock = new Mock<ISearchViewModel>();
            _mainViewModel = new MainViewModel(_eventBusMock.Object, _searchViewModelMock.Object);
        }

        [Test]
        public void GetDocumentsShouldHaveSearchViewModel()
        {
            var documents = _mainViewModel.Documents;
            Assert.Contains(_searchViewModelMock.Object, documents);
        }

        [Test]
        public void PublisingCloseShouldRemoveItemFromDocuments()
        {
            _eventBusMock.Verify(s => s.Subscribe(_mainViewModel));
        }

        [Test]
        public void HandleCloseDocumentArgsShouldRemoveDocument()
        {
            var documentId = Guid.NewGuid();
            _searchViewModelMock.Setup(s => s.Id).Returns(documentId);
            _mainViewModel.Handle(new CloseDocumentArgs(documentId));

            Assert.IsFalse(_mainViewModel.Documents.Contains(_searchViewModelMock.Object));
        }
    }
}