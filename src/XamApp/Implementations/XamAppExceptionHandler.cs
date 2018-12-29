using System;
using System.Collections.Generic;
using Bit.ViewModel;
using Microsoft.AppCenter.Crashes;

namespace XamApp.Implementations
{
    public class XamAppExceptionHandler : BitExceptionHandler
    {
        public override void OnExceptionReceived(Exception exp, IDictionary<string, string> properties = null)
        {
#if DEBUG

            System.Diagnostics.Debugger.Break();

#endif

            Crashes.TrackError(exp, properties);

            base.OnExceptionReceived(exp, properties);
        }
    }
}
