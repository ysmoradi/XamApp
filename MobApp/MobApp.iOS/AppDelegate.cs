using Autofac;
using Bit.ViewModel;
using Bit.ViewModel.Implementations;
using Foundation;
using MobApp.Implementations;
using Prism.Autofac;
using Prism.Ioc;
using UIKit;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace MobApp.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            BitExceptionHandler.Current = new MobAppExceptionHandler();

            VersionTracking.Track();

            Forms.Init();

            LoadApplication(new App(new MobAppPlatformInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class MobAppPlatformInitializer : BitPlatformInitializer
    {
        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ContainerBuilder containerBuilder = containerRegistry.GetBuilder();

            base.RegisterTypes(containerRegistry);
        }
    }
}
