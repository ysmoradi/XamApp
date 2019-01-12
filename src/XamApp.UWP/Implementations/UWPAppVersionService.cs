using Windows.ApplicationModel;
using XamApp.Contracts;

namespace XamApp.UWP.Implementations
{
    public class UWPAppVersionService : IAppVersionService
    {
        public string GetAppVersion()
        {
            return $"{Package.Current.Id.Version.Major}.{Package.Current.Id.Version.Minor}";
        }
    }
}
