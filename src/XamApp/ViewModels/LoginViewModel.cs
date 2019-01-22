using Acr.UserDialogs;
using Bit.ViewModel;
using System;
using System.Threading.Tasks;

namespace XamApp.ViewModels
{
    public class LoginViewModel : BitViewModelBase
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public BitDelegateCommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new BitDelegateCommand(Login);
        }

        public IUserDialogs UserDialogs { get; set; }

        public async Task Login()
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                await UserDialogs.AlertAsync(message: "Please provide UserName and Password!", title: ")-:", okText: "Ok!");
                return;
            }

            using (UserDialogs.Loading("Logging in...", maskType: MaskType.Black))
            {
                // Login implementation ...
                await Task.Delay(TimeSpan.FromSeconds(3));
            }

            //await NavigationService.NavigateAsync("/Intro");
            //await NavigationService.NavigateAsync("/Nav/HelloWorld");
            await NavigationService.NavigateAsync("/MasterDetail/Nav/HelloWorld");
        }
    }
}
