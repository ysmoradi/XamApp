using Bit.ViewModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using XamApp.Implementations;
using Xamarin.Essentials;

namespace XamApp.UWP
{
    sealed partial class App : Application
    {
        static App()
        {
            BitExceptionHandler.Current = new XamAppExceptionHandler();

            VersionTracking.Track();
        }

        public App()
        {
            InitializeComponent();
            UnhandledException += App_UnhandledException;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (!(Window.Current.Content is Frame rootFrame))
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                Rg.Plugins.Popup.Popup.Init();

                Xamarin.Forms.Forms.Init(e);

                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }

            Window.Current.Activate();
        }

        void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            BitExceptionHandler.Current.OnExceptionReceived(e.Exception);
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            BitExceptionHandler.Current.OnExceptionReceived(e.Exception);
            e.Handled = true;
        }
    }
}
