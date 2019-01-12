namespace XamApp.Contracts
{
    /// <summary>
    /// It's just a sample which demonstrates how to develop a cross platform code.
    /// Use Xamarin Essential's Version Tracking feature in production. https://docs.microsoft.com/en-us/xamarin/essentials/version-tracking
    /// </summary>
    public interface IAppVersionService
    {
        string GetAppVersion();
    }
}
