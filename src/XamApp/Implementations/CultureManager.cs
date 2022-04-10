using Bit.View.Controls;
using System;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamApp.Implementations
{
    public class CultureManager
    {
        public void UseCurrentCulture()
        {
            var culture = Preferences.Get("Culture", "En" /*You can get current culture from OS*/);

            CultureInfo cultureInfo = CultureInfoProvider.Current.GetCultureInfo(culture);

            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            foreach (Type resource in Assembly.Load("XamApp").GetTypes().Where(t => t.IsPublic && t.GetCustomAttribute<GeneratedCodeAttribute>()?.Tool == "System.Resources.Tools.StronglyTypedResourceBuilder"))
            {
                resource
                    .GetField("resourceMan", BindingFlags.Static | BindingFlags.NonPublic)
                    .SetValue(null, new ResourceManager(resource.FullName.Replace("Server", "Client"), resource.Assembly));

                resource.GetProperty("Culture").SetValue(null, cultureInfo);
            }

            if (culture == "En")
            {
                App.Current.Resources["AppRegularFont"] = "OpenSansRegular";
                App.Current.Resources["AppBoldFont"] = "OpenSansBold";
                App.Current.Resources["AppItalicFont"] = "OpenSansItalic";

                App.Current.Resources["AppFlowDirection"] = FlowDirection.LeftToRight;
            }
            else
            {
                App.Current.Resources["AppRegularFont"] = App.Current.Resources["AppBoldFont"] = App.Current.Resources["AppItalicFont"] = "Vazir";

                App.Current.Resources["AppFlowDirection"] = FlowDirection.RightToLeft;
            }
        }

        public void SetCurrentCulture(string culture)
        {
            Preferences.Set("Culture", culture);
            UseCurrentCulture();
        }
    }
}
