using Bit.ViewModel;

namespace XamApp.ViewModels
{
    public class XamAppViewModelBase : BitViewModelBase
    {
        /// <summary>
        /// Temporary workaround for Bit 1.6.0 issue.
        /// </summary>
        public override void OnPropertyChanged(string propertyName, object before, object after)
        {
            base.OnPropertyChanged(propertyName, before, after);

            RaisePropertyChanged(propertyName);
        }
    }
}
