using Acr.UserDialogs;
using Bit.ViewModel;
using Prism.AppModel;
using Prism.Services;
using System.Threading.Tasks;
using XamApp.Contracts;
using Xamarin.Forms;

namespace XamApp.ViewModels
{
    public class PlatformSpecificSamplesViewModel : BitViewModelBase
    {
        public IAppVersionService AppVersionService { get; set; }

        public IUserDialogs UserDialogs { get; set; }

        public IDeviceService DeviceService { get; set; }

        public BitDelegateCommand ShowAppVersionCommand { get; set; }
        public BitDelegateCommand ShowSomeAlertToAndroidPhoneUsersOnlyCommand { get; set; }

        public PlatformSpecificSamplesViewModel()
        {
            ShowAppVersionCommand = new BitDelegateCommand(ShowAppVersion);
            ShowSomeAlertToAndroidPhoneUsersOnlyCommand = new BitDelegateCommand(ShowSomeAlertToAndroidPhoneUsersOnly);
        }

        async Task ShowAppVersion()
        {
            await UserDialogs.AlertAsync(AppVersionService.GetAppVersion(), "AppVersion");
        }

        async Task ShowSomeAlertToAndroidPhoneUsersOnly()
        {
            if (DeviceService.RuntimePlatform == RuntimePlatform.Android && DeviceService.Idiom == TargetIdiom.Phone)
            {
                await UserDialogs.AlertAsync("Some alert to android phone users only!", "Test");
            }
        }
    }
}
