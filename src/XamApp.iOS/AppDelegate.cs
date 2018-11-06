using Autofac;
using Bit.iOS;
using Bit.ViewModel;
using Bit.ViewModel.Implementations;
using Foundation;
using Prism.Autofac;
using Prism.Ioc;
using UIKit;
using XamApp.Implementations;
using Xamarin.Forms;

namespace XamApp.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : BitFormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            BitExceptionHandler.Current = new XamAppExceptionHandler();

            UseDefaultConfiguration();
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
