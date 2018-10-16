using Autofac;
using Bit.ViewModel.Implementations;
using Prism.Autofac;
using Prism.Ioc;

namespace XamApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadApplication(new XamApp.App(new XamAppPlatformInitializer()));
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
