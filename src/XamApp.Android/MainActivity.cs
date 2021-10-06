﻿using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Autofac;
using Bit.Android;
using Bit.Core.Contracts;
using Bit.ViewModel;
using Bit.ViewModel.Implementations;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Extensions.DependencyInjection;
using Prism.Autofac;
using Prism.Ioc;
using XamApp.Contracts;
using XamApp.Droid.Implementations;
using XamApp.Implementations;
using XamApp.Views;
using Xamarin.Forms;

namespace XamApp.Droid
{
    [Activity(Label = "XamApp", Icon = "@mipmap/icon", Theme = "@style/SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : BitFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppCenterTelemetryService.Current.Init(appSecret: "ee74db97-563c-48cd-a1a3-aaf403fe1cc4", typeof(Crashes), typeof(Analytics));

            BitExceptionHandler.Current = new XamAppExceptionHandler();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncfusionLicense.Product_Key);

            SetTheme(Resource.Style.MainTheme);

            base.OnCreate(savedInstanceState);

            UseDefaultConfiguration(savedInstanceState);
            UserDialogs.Init(this);
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

        public override void RegisterTypes(IDependencyManager dependencyManager, IContainerRegistry containerRegistry, ContainerBuilder containerBuilder, IServiceCollection services)
        {
            containerBuilder.RegisterType<AndroidAppVersionService>()
                .As<IAppVersionService>()
                .PropertiesAutowired(PropertyWiringOptions.PreserveSetValues);

            base.RegisterTypes(dependencyManager, containerRegistry, containerBuilder, services);
        }
    }
}
