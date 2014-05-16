using FMUtility.Eventing;
using FMUtility.Eventing.Args;
using FMUtility.ViewModels;
using Moq;
using NUnit.Framework;

namespace FMUtility.Test.ViewModels
{
    [TestFixture]
    public class StatusViewModelTest
    {
        private StatusViewModel _statusViewModel;
        private Mock<IEventBus> _eventBusMock;

        [SetUp]
        public void Setup()
        {
            _eventBusMock = new Mock<IEventBus>();
            _statusViewModel = new StatusViewModel(_eventBusMock.Object);
        }

        [Test]
        public void ConstructorShouldSubscribeToStatusArgs()
        {
            _eventBusMock.Verify(s => s.Subscribe<StatusArgs>(_statusViewModel), Times.Once());
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
