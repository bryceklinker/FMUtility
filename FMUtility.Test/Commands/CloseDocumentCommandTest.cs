using System;
using FMUtility.Commands;
using FMUtility.Eventing;
using FMUtility.Eventing.Args;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.Commands
{
    [TestFixture]
    public class CloseDocumentCommandTest
    {
        private Mock<IDocumentViewModel> _documentViewModelMock;
        private Mock<IEventBus> _eventBusMock;
        private CloseDocumentCommand _closeDocumentCommand;

        [SetUp]
        public void Setup()
        {
            _documentViewModelMock = new Mock<IDocumentViewModel>();
            _eventBusMock = new Mock<IEventBus>();
            _closeDocumentCommand = new CloseDocumentCommand(_eventBusMock.Object, _documentViewModelMock.Object);
        }

        [Test]
        public void ExecuteShouldPublishCloseDocumentArgs()
        {
            var documentId = Guid.NewGuid();
            _documentViewModelMock.Setup(s => s.Id).Returns(documentId);

            _closeDocumentCommand.Execute(null);
            _eventBusMock.Verify(s => s.Publish(Match.Create<CloseDocumentArgs>(c => c.DocumentId == documentId)), Times.Once());
        }

        [Test]
        public void CanExecuteShouldReturnTrueIfNotSpecified()
        {
            var canExecute = _closeDocumentCommand.CanExecute(null);
            Assert.IsTrue(canExecute);
        }

        [Test]
        public void CanExecuteShouldReturnFalse()
        {
            _closeDocumentCommand = new CloseDocumentCommand(_eventBusMock.Object, _documentViewModelMock.Object, false);
            Assert.IsFalse(_closeDocumentCommand.CanExecute(null));
        }
    }
}
