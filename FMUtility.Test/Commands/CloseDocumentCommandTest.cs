﻿using System;
using System.ComponentModel;
using FMUtility.Commands;
using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.Commands
{
    [TestFixture]
    public class CloseDocumentCommandTest
    {
        [SetUp]
        public void Setup()
        {
            _documentViewModelMock = new Mock<IDocumentViewModel>();
            _eventBusMock = new Mock<IEventBus>();
            _closeDocumentCommand = new CloseDocumentCommand(_eventBusMock.Object, _documentViewModelMock.Object);
        }

        private Mock<IDocumentViewModel> _documentViewModelMock;
        private Mock<IEventBus> _eventBusMock;
        private CloseDocumentCommand _closeDocumentCommand;

        [Test]
        public void CanExecuteChangedShouldConnectToPropertyChanged()
        {
            var canExecuteChangedCount = 0;
            _closeDocumentCommand.CanExecuteChanged += (o, e) => canExecuteChangedCount++;
            _documentViewModelMock.Raise(d => d.PropertyChanged += null, new PropertyChangedEventArgs(string.Empty));

            Assert.AreEqual(1, canExecuteChangedCount);
        }

        [Test]
        public void CanExecuteShouldReturnTrue()
        {
            _documentViewModelMock.Setup(s => s.CanClose).Returns(true);

            var canExecute = _closeDocumentCommand.CanExecute(null);
            Assert.IsTrue(canExecute);
        }

        [Test]
        public void ExecuteShouldPublishCloseDocumentArgs()
        {
            var documentId = Guid.NewGuid();
            _documentViewModelMock.Setup(s => s.Id).Returns(documentId);

            _closeDocumentCommand.Execute(null);
            _eventBusMock.Verify(s => s.Publish(Match.Create<CloseDocumentArgs>(c => c.DocumentId == documentId)),
                Times.Once());
        }
    }
}