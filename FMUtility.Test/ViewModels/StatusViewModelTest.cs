using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class StatusViewModelTest
    {
        [SetUp]
        public void Setup()
        {
            _eventBusMock = new Mock<IEventBus>();
            _statusViewModel = new StatusViewModel(_eventBusMock.Object);
        }

        private StatusViewModel _statusViewModel;
        private Mock<IEventBus> _eventBusMock;

        [Test]
        public void ConstructorShouldSubscribeToStatusArgs()
        {
            _eventBusMock.Verify(s => s.Subscribe(_statusViewModel), Times.Once());
        }

        [Test]
        public void HandleShouldSetIsBusytoArgsIsBusy()
        {
            var args = new StatusArgs
            {
                IsBusy = true
            };
            _statusViewModel.Handle(args);
            Assert.AreEqual(true, _statusViewModel.IsBusy);
        }

        [Test]
        public void HandleShouldSetTextToArgsText()
        {
            var args = new StatusArgs
            {
                Text = "Hello"
            };
            _statusViewModel.Handle(args);
            Assert.AreEqual("Hello", _statusViewModel.Text);
        }
    }
}