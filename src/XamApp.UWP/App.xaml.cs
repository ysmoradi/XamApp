using Bit.ViewModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using XamApp.Implementations;

namespace XamApp.UWP
{
    sealed partial class App : Bit.UWP.BitApplication
    {
        static App()
        {
            BitExceptionHandler.Current = new XamAppExceptionHandler();
        }

        public App()
        {
            InitializeComponent();
            UnhandledException += App_UnhandledException; // ToDo: Remove this line.
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (!(Window.Current.Content is Frame rootFrame))
            {
                rootFrame = new Frame();

                UseDefaultConfiguration();
                Xamarin.Forms.Forms.Init(e);

                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }

            Window.Current.Activate();
        }

        private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            BitExceptionHandler.Current.OnExceptionReceived(e.Exception);
        }
    }
}
