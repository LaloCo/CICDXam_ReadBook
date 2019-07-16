using System;
using Microsoft.AppCenter.Crashes;

namespace ReadBooks
{
    public class AppCenterHelper
    {
        public static void TrackError(Exception exception)
        {
            Crashes.TrackError(exception);
        }
    }
}
