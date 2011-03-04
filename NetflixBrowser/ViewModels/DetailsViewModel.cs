using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using NetflixBrowser.Model;

namespace NetflixBrowser.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        public DetailsViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
                Messenger.Default.Register<PropertyChangedMessage<Title>>(this, (message) =>
                {
                    this.Item = message.NewValue;
                });
            }
        }

        /// <summary>
        /// The <see cref="Item" /> property's name.
        /// </summary>
        public const string ItemPropertyName = "Item";

        private Title _item = null;

        /// <summary>
        /// Gets the Item property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event.
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public Title Item
        {
            get
            {
                return _item;
            }

            set
            {
                if (_item == value)
                {
                    return;
                }

                var oldValue = _item;
                _item = value;
                RaisePropertyChanged(ItemPropertyName);
            }
        }
    }
}