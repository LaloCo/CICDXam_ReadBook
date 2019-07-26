using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace ReadBooks.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppNavigatesToNewBook()
        {
            app.Tap(c => c.Text("Add"));
            // app.Repl();

            app.WaitForElement(c => c.Marked("SaveButton"),
                "Did not see the save button",
                new TimeSpan(0, 0, 2));
            var result = app.Query(c => c.Marked("SaveButton"));
            Assert.IsTrue(result.Any(), "Navigation to New Book Page didn't happen");
        }
    }
}
