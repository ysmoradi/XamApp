using Autofac;
using Bit.ViewModel.Implementations;
using Prism.Autofac;
using Prism.Ioc;
using Syncfusion.ListView.XForms.UWP;
using XamApp.Contracts;
using XamApp.UWP.Implementations;

namespace XamApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            SfListViewRenderer.Init();

            LoadApplication(new XamApp.App(new XamAppPlatformInitializer()));
        }
    }

    public class XamAppPlatformInitializer : BitPlatformInitializer
    {
        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ContainerBuilder containerBuilder = containerRegistry.GetBuilder();

            containerBuilder.RegisterType<UWPAppVersionService>()
                .As<IAppVersionService>()
                .PropertiesAutowired(PropertyWiringOptions.PreserveSetValues);

            base.RegisterTypes(containerRegistry);
        }
    }
}
