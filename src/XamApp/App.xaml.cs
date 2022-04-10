using Acr.UserDialogs;
using Autofac;
using Bit;
using Bit.Core.Contracts;
using Bit.Core.Implementations;
using Bit.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Prism;
using Prism.Ioc;
using System.Threading.Tasks;
using XamApp.Implementations;
using XamApp.ViewModels;
using XamApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

[assembly: ExportFont("Vazir-Light-FD-WOL.ttf", Alias = "Vazir")]
[assembly: ExportFont("OpenSansBold.ttf", Alias = "OpenSansBold")]
[assembly: ExportFont("OpenSansItalic.ttf", Alias = "OpenSansItalic")]
[assembly: ExportFont("OpenSansRegular.ttf", Alias = "OpenSansRegular")]

namespace XamApp
{
    public partial class App : BitApplication
    {
        public static new App Current
        {
            get { return (App)Application.Current; }
        }

        public App()
            : this(null)
        {
            BitCSharpClientControls.XamlInit();
        }

        public App(IPlatformInitializer platformInitializer)
            : base(platformInitializer)
        {
        }

        protected override async Task OnInitializedAsync()
        {
            InitializeComponent();

            Container.Resolve<CultureManager>().UseCurrentCulture();

            await NavigationService.NavigateAsync("/Nav/HelloWorldMultiLanguage"); // Simple tap counter sample

            // await NavigationService.NavigateAsync("/MasterDetail/Nav/HelloWorld"); // Simple tap counter sample in master detail
            // await NavigationService.NavigateAsync("/Nav/HelloWorld/Intro"); // Popup page
            // await NavigationService.NavigateAsync("/Nav/Login"); // Simple login form sample
            // await NavigationService.NavigateAsync("/Nav/Products"); // List view sample
            // await NavigationService.NavigateAsync("/Nav/PlatformSpecificSamples"); // Platform specific sample
            // await NavigationService.NavigateAsync("/Nav/Animations"); // Animations
            // await NavigationService.NavigateAsync("/Nav/RestSamples"); // rest api call sample

            await base.OnInitializedAsync();
        }

        protected override void RegisterTypes(IDependencyManager dependencyManager, IContainerRegistry containerRegistry, ContainerBuilder containerBuilder, IServiceCollection services)
        {
            containerRegistry.RegisterForNav<NavigationPage>("Nav");
            containerRegistry.RegisterForNav<XamAppMasterDetailView, XamAppMasterDetailViewModel>("MasterDetail");
            containerRegistry.RegisterForNav<HelloWorldView, HelloWorldViewModel>("HelloWorld");
            containerRegistry.RegisterForNav<HelloWorldMultiLanguageView, HelloWorldMultiLanguageViewModel>("HelloWorldMultiLanguage");
            containerRegistry.RegisterForNav<LoginView, LoginViewModel>("Login");
            containerRegistry.RegisterForNav<IntroView, IntroViewModel>("Intro");
            containerRegistry.RegisterForNav<ProductsView, ProductsViewModel>("Products");
            containerRegistry.RegisterForNav<PlatformSpecificSamplesView, PlatformSpecificSamplesViewModel>("PlatformSpecificSamples");
            containerRegistry.RegisterForNav<AnimationsView, AnimationsViewModel>("Animations");
            containerRegistry.RegisterForNav<RestSamplesView, RestSamplesViewModel>("RestSamples");

            containerBuilder.Register<IClientAppProfile>(c => new DefaultClientAppProfile
            {
                AppName = "XamApp",
            }).SingleInstance();

            dependencyManager.RegisterRequiredServices();
            dependencyManager.RegisterHttpClient();
            dependencyManager.RegisterIdentityClient();

            containerBuilder.RegisterInstance(UserDialogs.Instance);

            dependencyManager.Register<CultureManager>(lifeCycle: DependencyLifeCycle.SingleInstance);
#if DEBUG
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddDebug();
            });
#endif

            base.RegisterTypes(dependencyManager, containerRegistry, containerBuilder, services);
        }
    }
}
