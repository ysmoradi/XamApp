using Bit.ViewModel;
using MobApp.Implementations;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Essentials;

namespace MobApp.UWP
{
    sealed partial class App : Application
    {
        static App()
        {
            BitExceptionHandler.Current = new MobAppExceptionHandler();

            VersionTracking.Track();
        }

        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (!(Window.Current.Content is Frame rootFrame))
            {
                rootFrame = new Frame();

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
    }
}
