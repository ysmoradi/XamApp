using Bit.ViewModel;
using System;
using System.Threading.Tasks;
using XamApp.Implementations;
using Xamarin.Forms;

namespace XamApp.ViewModels
{
    public class HelloWorldMultiLanguageViewModel : BitViewModelBase
    {
        public DateTimeOffset DateSample { get; set; } = DateTimeOffset.Now;

        public int StepsCount { get; set; }

        public BitDelegateCommand IncreaseStepsCountCommand { get; set; }
        public BitDelegateCommand SetCurrentCultureToEnCommand { get; set; }
        public BitDelegateCommand SetCurrentCultureToFaCommand { get; set; }

        public CultureManager CultureManager { get; set; }

        public HelloWorldMultiLanguageViewModel()
        {
            IncreaseStepsCountCommand = new BitDelegateCommand(IncreaseStepsCount);
            SetCurrentCultureToEnCommand = new BitDelegateCommand(SetCurrentCultureToEn);
            SetCurrentCultureToFaCommand = new BitDelegateCommand(SetCurrentCultureToFa);
        }

        async Task IncreaseStepsCount()
        {
            StepsCount += 1;
        }

        async Task SetCurrentCultureToEn()
        {
            CultureManager.SetCurrentCulture("En");
            await NavigationService.NavigateAsync("/Nav/HelloWorldMultiLanguage");
        }

        async Task SetCurrentCultureToFa()
        {
            CultureManager.SetCurrentCulture("Fa");
            await NavigationService.NavigateAsync("/Nav/HelloWorldMultiLanguage");
        }
    }
}
