﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Autofac;
using Bit.Droid;
using Bit.ViewModel;
using Bit.ViewModel.Implementations;
using Prism.Autofac;
using Prism.Ioc;
using XamApp.Implementations;
using Xamarin.Forms;

namespace XamApp.Droid
{
    [Activity(Label = "XamApp", Icon = "@mipmap/icon", Theme = "@style/SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : BitFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            BitExceptionHandler.Current = new XamAppExceptionHandler();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            SetTheme(Resource.Style.MainTheme);

            base.OnCreate(savedInstanceState);

            UseDefaultConfiguration(savedInstanceState);
            Forms.Init(this, savedInstanceState);

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
