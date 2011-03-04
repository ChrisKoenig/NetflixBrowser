using System;
using System.Collections.ObjectModel;
using System.Data.Services.Client;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NetflixBrowser.Model;

namespace NetflixBrowser.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand UpperCommand { get; private set; }

        public RelayCommand LowerCommand { get; private set; }

        public MainViewModel()
        {
            UpperCommand = new RelayCommand(() =>
            {
                foreach (var item in _items)
                {
                    item.Name = item.Name.ToUpper();
                }
            });

            LowerCommand = new RelayCommand(() =>
            {
                foreach (var item in _items)
                {
                    item.Name = item.Name.ToLower();
                }
            });

            if (IsInDesignMode)
            {
            }
            else
            {
                LoadRuntimeData();
            }
        }

        private void LoadRuntimeData()
        {
            NetflixCatalog catalog = new NetflixCatalog(new Uri("http://odata.netflix.com/Catalog", UriKind.Absolute));
            _items = new DataServiceCollection<Title>(catalog);
            _items.LoadAsync(new Uri("/Titles?$top=25&$filter=Rating eq 'PG' and ReleaseYear eq 1983&$orderby=AverageRating desc", UriKind.Relative));
        }

        #region Items property

        public const string ItemsPropertyName = "Items";

        private DataServiceCollection<Title> _items = new DataServiceCollection<Title>();

        public DataServiceCollection<Title> Items
        {
            get
            {
                return _items;
            }

            set
            {
                if (_items == value)
                {
                    return;
                }

                var oldValue = _items;
                _items = value;
                RaisePropertyChanged(ItemsPropertyName);
            }
        }

        #endregion Items property

        #region SelectedItem property

        /// <summary>
        /// The <see cref="SelectedItem" /> property's name.
        /// </summary>
        public const string SelectedItemPropertyName = "SelectedItem";

        private Title _SelectedItem = null;

        /// <summary>
        /// Gets the SelectedItem property.
        /// TODO Update documentation:
        /// Changes to that property's value raise the PropertyChanged event.
        /// This property's value is broadcasted by the Messenger's default instance when it changes.
        /// </summary>
        public Title SelectedItem
        {
            get
            {
                return _SelectedItem;
            }

            set
            {
                if (_SelectedItem == value)
                {
                    return;
                }

                var oldValue = _SelectedItem;
                _SelectedItem = value;
                RaisePropertyChanged(SelectedItemPropertyName, oldValue, value, true);
            }
        }

        #endregion SelectedItem property
    }
}