using Bit.ViewModel;
using System.Linq;
using System.Reflection;
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
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (!(Window.Current.Content is Frame rootFrame))
            {
                rootFrame = new Frame();

                UseDefaultConfiguration();
                Xamarin.Forms.Forms.Init(e, new Assembly[]
                {

                }.Union(Rg.Plugins.Popup.Popup.GetExtraAssemblies()));

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
