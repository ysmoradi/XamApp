using Autofac;
using Bit.Core.Contracts;
using Bit.ViewModel.Implementations;
using Microsoft.Extensions.DependencyInjection;
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
        public override void RegisterTypes(IDependencyManager dependencyManager, IContainerRegistry containerRegistry, ContainerBuilder containerBuilder, IServiceCollection services)
        {
            containerBuilder.RegisterType<UWPAppVersionService>()
                .As<IAppVersionService>()
                .PropertiesAutowired(PropertyWiringOptions.PreserveSetValues);

            base.RegisterTypes(dependencyManager, containerRegistry, containerBuilder, services);
        }
    }
}
