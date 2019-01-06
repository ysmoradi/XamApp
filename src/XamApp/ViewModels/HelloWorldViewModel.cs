using Bit.ViewModel;
using System.Threading.Tasks;

namespace XamApp.ViewModels
{
    public class HelloWorldViewModel : XamAppViewModelBase
    {
        public int StepsCount { get; set; }

        public BitDelegateCommand IncreaseStepsCountCommand { get; set; }

        public HelloWorldViewModel()
        {
            IncreaseStepsCountCommand = new BitDelegateCommand(IncreaseStepsCount);
        }

        async Task IncreaseStepsCount()
        {
            StepsCount += 1;
        }
    }
}
