using Autofac;
using Bit.ViewModel;
using Bit.ViewModel.Implementations;
using Foundation;
using XamApp.Implementations;
using Prism.Autofac;
using Prism.Ioc;
using UIKit;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace XamApp.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            BitExceptionHandler.Current = new XamAppExceptionHandler();

            VersionTracking.Track();

            Forms.Init();

            LoadApplication(new App(new XamAppPlatformInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class XamAppPlatformInitializer : BitPlatformInitializer
    {
        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ContainerBuilder containerBuilder = containerRegistry.GetBuilder();

            base.RegisterTypes(containerRegistry);
        }
    }
}
