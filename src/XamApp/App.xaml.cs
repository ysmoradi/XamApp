using Acr.UserDialogs;
using Autofac;
using Bit;
using Bit.ViewModel.Contracts;
using Bit.ViewModel.Implementations;
using Prism;
using Prism.Autofac;
using Prism.Ioc;
using System;
using System.Globalization;
using System.Threading.Tasks;
using XamApp.Resources;
using XamApp.ViewModels;
using XamApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Bit.View
{
    public class OnPlatform<T>
    {
        public T Value { get; set; }

        public static implicit operator T(OnPlatform<T> value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return value.Value;
        }
    }
}

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

            Strings.Culture = CultureInfo.CurrentUICulture = new CultureInfo("en");

            // await NavigationService.NavigateAsync("/Login");
            await NavigationService.NavigateAsync("/Nav/HelloWorld");

            await base.OnInitializedAsync();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ContainerBuilder containerBuilder = containerRegistry.GetBuilder();

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

            base.RegisterTypes(containerRegistry);
        }
    }
}
