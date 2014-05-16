using FMUtility.Core.Eventing;
using FMUtility.Core.Eventing.Args;

namespace FMUtility.ViewModels
{
    public class StatusViewModel : ViewModelBase, IHandler<StatusArgs>
    {
        private bool? _isBusy;
        private string _text;

        public StatusViewModel() : this(EventBus.Instance)
        {
        }

        public StatusViewModel(IEventBus eventBus)
        {
            eventBus.Subscribe(this);
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                RaisePropertyChanged(() => Text);
            }
        }

        public bool? IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public void Handle(StatusArgs args)
        {
            Text = args.Text;
            IsBusy = args.IsBusy;
        }
    }
}