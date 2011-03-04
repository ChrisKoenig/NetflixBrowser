/*
  In App.xaml:
  <Application.Resources>
      <vm:GlobalViewModelLocator xmlns:vm="clr-namespace:NetflixBrowser.ViewModels"
                                   x:Key="Locator" />
  </Application.Resources>

  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

namespace NetflixBrowser.ViewModels
{
    public class GlobalViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the GlobalViewModelLocator class.
        /// </summary>
        public GlobalViewModelLocator()
        {
            CreateMainViewModel();
            CreateDetailsViewModel();
        }

        #region MainViewModel

        private static MainViewModel _main;

        /// <summary>
        /// Gets the MainViewModel property.
        /// </summary>
        public static MainViewModel MainViewModelStatic
        {
            get
            {
                if (_main == null)
                {
                    CreateMainViewModel();
                }

                return _main;
            }
        }

        /// <summary>
        /// Gets the MainViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel MainViewModel
        {
            get
            {
                return MainViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the MainViewModel property.
        /// </summary>
        public static void ClearMainViewModel()
        {
            _main.Cleanup();
            _main = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the MainViewModel property.
        /// </summary>
        public static void CreateMainViewModel()
        {
            if (_main == null)
            {
                _main = new MainViewModel();
            }
        }

        #endregion MainViewModel

        #region DetailsViewModel

        private static DetailsViewModel _details;

        /// <summary>
        /// Gets the DetailsViewModel property.
        /// </summary>
        public static DetailsViewModel DetailsViewModelStatic
        {
            get
            {
                if (_details == null)
                {
                    CreateDetailsViewModel();
                }

                return _details;
            }
        }

        /// <summary>
        /// Gets the DetailsViewModel property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public DetailsViewModel DetailsViewModel
        {
            get
            {
                return DetailsViewModelStatic;
            }
        }

        /// <summary>
        /// Provides a deterministic way to delete the DetailsViewModel property.
        /// </summary>
        public static void ClearDetailsViewModel()
        {
            _details.Cleanup();
            _details = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the DetailsViewModel property.
        /// </summary>
        public static void CreateDetailsViewModel()
        {
            if (_details == null)
            {
                _details = new DetailsViewModel();
            }
        }

        #endregion DetailsViewModel

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            ClearDetailsViewModel();
            ClearMainViewModel();
        }
    }
}