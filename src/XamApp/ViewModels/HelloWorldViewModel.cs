using Bit.ViewModel;
using System.Threading.Tasks;

namespace XamApp.ViewModels
{
    public class HelloWorldViewModel : BitViewModelBase
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
