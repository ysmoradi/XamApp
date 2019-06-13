using Acr.UserDialogs;
using Autofac;
using Bit;
using Bit.View;
using Bit.ViewModel.Contracts;
using Bit.ViewModel.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Prism;
using Prism.Ioc;
using System.Globalization;
using System.Threading.Tasks;
using XamApp.Resources;
using XamApp.ViewModels;
using XamApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

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
#if DEBUG
            LiveReload.Init();
#endif
        }

        protected override async Task OnInitializedAsync()
        {
            InitializeComponent();

            Strings.Culture = CultureInfo.CurrentUICulture = new CultureInfo("en");

            await NavigationService.NavigateAsync("/Nav/HelloWorld"); // Simple tap counter sample

            // await NavigationService.NavigateAsync("/MasterDetail/Nav/HelloWorld"); // Simple tap counter sample in master detail
            // await NavigationService.NavigateAsync("/Nav/HelloWorld/Intro"); // Popup page
            // await NavigationService.NavigateAsync("/Nav/Login"); // Simple login form sample
            // await NavigationService.NavigateAsync("/Nav/Products"); // List view sample
            // await NavigationService.NavigateAsync("/Nav/PlatformSpecificSamples"); // Platform specific sample
            // await NavigationService.NavigateAsync("/Nav/Animations"); // Animations
            // await NavigationService.NavigateAsync("/Nav/RestSamples"); // rest api call sample

            await base.OnInitializedAsync();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry, ContainerBuilder containerBuilder, IServiceCollection services)
        {
            containerRegistry.RegisterForNav<NavigationPage>("Nav");
            containerRegistry.RegisterForNav<XamAppMasterDetailView, XamAppMasterDetailViewModel>("MasterDetail");
            containerRegistry.RegisterForNav<HelloWorldView, HelloWorldViewModel>("HelloWorld");
            containerRegistry.RegisterForNav<HelloWorldMultiLanguageView, HelloWorldViewModel>("HelloWorldMultiLanguage");
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

            containerBuilder.RegisterRequiredServices();
            containerBuilder.RegisterHttpClient();
            containerBuilder.RegisterIdentityClient();

            containerBuilder.RegisterInstance(UserDialogs.Instance);

#if DEBUG
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddDebug();
            });
#endif

            base.RegisterTypes(containerRegistry, containerBuilder, services);
        }
    }
}
