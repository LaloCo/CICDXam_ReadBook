using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace ReadBooks.Tests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            // TODO: If the iOS or Android app being tested is included in the solution 
            // then open the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            //
            // The iOS project should have the Xamarin.TestCloud.Agent NuGet package
            // installed. To start the Test Cloud Agent the following code should be
            // added to the FinishedLaunching method of the AppDelegate:
            //
            //    #if ENABLE_TEST_CLOUD
            //    Xamarin.Calabash.Start();
            //    #endif
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    // TODO: Update this path to point to your Android app and uncomment the
                    // code if the app is not included in the solution.
                    .ApkFile ("../../../ReadBooks.Android/bin/Debug/com.lalorosas.readbooks-Signed.apk")
                    //.InstalledApp("com.lalorosas.readbooks")
                    .PreferIdeSettings()
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                // TODO: Update this path to point to your iOS app and uncomment the
                // code if the app is not included in the solution.
                .AppBundle ("../../../ReadBooks.iOS/bin/iPhoneSimulator/Debug/ReadBooks.iOS.app")
                .DeviceIdentifier("D6B5F3F0-ED71-470F-837D-0C49672EB489")
                .StartApp();
        }
    }
}
