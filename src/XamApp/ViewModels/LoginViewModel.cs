using Bit.ViewModel;
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

        public async Task Login()
        {
            // Login implementation ...
        }
    }
}
