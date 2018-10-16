using Android.App;
using Android.Content.PM;
using Android.OS;
using Autofac;
using Bit.ViewModel;
using Bit.ViewModel.Implementations;
using XamApp.Implementations;
using Prism.Autofac;
using Prism.Ioc;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace XamApp.Droid
{
    [Activity(Label = "XamApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            BitExceptionHandler.Current = new XamAppExceptionHandler();

            VersionTracking.Track();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.SetFlags("FastRenderers_Experimental");
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            Forms.Init(this, bundle);

            LoadApplication(new App(new XamAppPlatformInitializer(this)));
        }
    }

    public class XamAppPlatformInitializer : BitPlatformInitializer
    {
        public XamAppPlatformInitializer(Activity activity)
            : base(activity)
        {
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ContainerBuilder containerBuilder = containerRegistry.GetBuilder();

            base.RegisterTypes(containerRegistry);
        }
    }
}
