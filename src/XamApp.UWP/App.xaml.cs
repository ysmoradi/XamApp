using Bit;
using Bit.ViewModel;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Syncfusion.ListView.XForms.UWP;
using System.Linq;
using System.Reflection;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using XamApp.Implementations;
using XamApp.Views;

namespace XamApp.UWP
{
    sealed partial class App : Bit.UWP.BitApplication
    {
        static App()
        {
            AppCenter.Start("3d9d3c01-e9d8-4251-a578-aa57f8f98d5e", typeof(Crashes), typeof(Analytics));

            BitExceptionHandler.Current = new XamAppExceptionHandler();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncfusionLicense.Product_Key);
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

                BitCSharpClientControls.Init();

                Xamarin.Forms.Forms.Init(e, new Assembly[]
                {
                    typeof(BitCSharpClientControls).GetTypeInfo().Assembly,
                    typeof(SfListViewRenderer).GetTypeInfo().Assembly
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
