using Autofac;
using Bit.ViewModel.Implementations;
using Prism.Autofac;
using Prism.Ioc;

namespace MobApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadApplication(new MobApp.App(new MobAppPlatformInitializer()));
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
