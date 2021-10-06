using Autofac;
using Bit.Core.Contracts;
using Bit.iOS;
using Bit.ViewModel;
using Bit.ViewModel.Implementations;
using Foundation;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Extensions.DependencyInjection;
using Prism.Autofac;
using Prism.Ioc;
using Syncfusion.ListView.XForms.iOS;
using UIKit;
using XamApp.Contracts;
using XamApp.Implementations;
using XamApp.iOS.Implementations;
using XamApp.Views;
using Xamarin.Forms;

namespace XamApp.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : BitFormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            AppCenterTelemetryService.Current.Init("054753be-db82-424c-a6d1-19129c151a7a", typeof(Crashes), typeof(Analytics));

            BitExceptionHandler.Current = new XamAppExceptionHandler();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncfusionLicense.Product_Key);

            UseDefaultConfiguration();
            Forms.Init();

            SfListViewRenderer.Init();

            LoadApplication(new App(new XamAppPlatformInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class XamAppPlatformInitializer : BitPlatformInitializer
    {
        public override void RegisterTypes(IDependencyManager dependencyManager, IContainerRegistry containerRegistry, ContainerBuilder containerBuilder, IServiceCollection services)
        {
            containerBuilder.RegisterType<iOSAppVersionService>()
                .As<IAppVersionService>()
                .PropertiesAutowired(PropertyWiringOptions.PreserveSetValues);

            base.RegisterTypes(dependencyManager, containerRegistry, containerBuilder, services);
        }
    }
}
