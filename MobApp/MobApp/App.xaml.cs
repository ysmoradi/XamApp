using Autofac;
using Bit;
using Bit.ViewModel.Contracts;
using Bit.ViewModel.Implementations;
using Prism;
using Prism.Autofac;
using Prism.Ioc;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Navigation;
using MobApp.Views;
using MobApp.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace MobApp
{
    public partial class App : BitApplication
    {
        public new static App Current
        {
            get { return (App)Application.Current; }
        }

        public App()
            : this(null)
        {
        }

        public App(IPlatformInitializer platformInitializer)
            : base(platformInitializer)
        {
#if DEBUG
            LiveReload.Init();
#endif
        }

        protected async override Task OnInitializedAsync()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/Nav/HelloWorld", animated: false);

            await base.OnInitializedAsync();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ContainerBuilder containerBuilder = containerRegistry.GetBuilder();

            containerRegistry.RegisterForNav<NavigationPage>("Nav");
            containerRegistry.RegisterForNav<HelloWorldView, HelloWorldViewModel>("HelloWorld");

            containerBuilder.Register<IClientAppProfile>(c => new DefaultClientAppProfile
            {
                AppName = "MobApp",
            }).SingleInstance();

            containerBuilder.RegisterRequiredServices();

            base.RegisterTypes(containerRegistry);
        }
    }
}
