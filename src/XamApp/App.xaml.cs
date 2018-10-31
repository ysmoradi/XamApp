using Autofac;
using Bit;
using Bit.ViewModel.Contracts;
using Bit.ViewModel.Implementations;
using Prism;
using Prism.Autofac;
using Prism.Ioc;
using Prism.Navigation;
using System.Threading.Tasks;
using XamApp.ViewModels;
using XamApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace XamApp
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

            await NavigationService.NavigateAsync("/Login", animated: false);

            await base.OnInitializedAsync();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ContainerBuilder containerBuilder = containerRegistry.GetBuilder();

            containerRegistry.RegisterForNav<NavigationPage>("Nav");
            containerRegistry.RegisterForNav<HelloWorldView, HelloWorldViewModel>("HelloWorld");
            containerRegistry.RegisterForNav<LoginView, LoginViewModel>("Login");

            containerBuilder.Register<IClientAppProfile>(c => new DefaultClientAppProfile
            {
                AppName = "XamApp",
            }).SingleInstance();

            containerBuilder.RegisterRequiredServices();

            base.RegisterTypes(containerRegistry);
        }
    }
}
