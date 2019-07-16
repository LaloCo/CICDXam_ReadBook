using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;

namespace ReadBooks
{
    public class AppCenterHelper
    {
        public static void TrackError(Exception exception, Dictionary<string, string> properties = null)
        {
            Crashes.TrackError(exception, properties);
        }
    }
}
