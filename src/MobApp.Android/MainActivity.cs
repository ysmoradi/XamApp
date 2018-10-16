using Android.App;
using Android.Content.PM;
using Android.OS;
using Autofac;
using Bit.ViewModel;
using Bit.ViewModel.Implementations;
using MobApp.Implementations;
using Prism.Autofac;
using Prism.Ioc;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace MobApp.Droid
{
    [Activity(Label = "MobApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            BitExceptionHandler.Current = new MobAppExceptionHandler();

            VersionTracking.Track();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.SetFlags("FastRenderers_Experimental");
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            Forms.Init(this, bundle);

            LoadApplication(new App(new MobAppPlatformInitializer(this)));
        }
    }

    public class MobAppPlatformInitializer : BitPlatformInitializer
    {
        public MobAppPlatformInitializer(Activity activity)
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
