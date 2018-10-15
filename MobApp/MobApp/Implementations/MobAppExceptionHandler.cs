using System;
using System.Collections.Generic;
using Bit.ViewModel;

namespace MobApp.Implementations
{
    public class MobAppExceptionHandler : BitExceptionHandler
    {
        public override void OnExceptionReceived(Exception exp, IDictionary<string, string> properties = null)
        {
#if DEBUG

            System.Diagnostics.Debugger.Break();

#endif

            base.OnExceptionReceived(exp, properties);
        }
    }
}
