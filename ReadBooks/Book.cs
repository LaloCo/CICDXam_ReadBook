using System;
using Microsoft.AppCenter.Crashes;

namespace ReadBooks
{
    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }

        public bool SaveBook()
        {
            // save to some db
            AppCenterHelper.TrackEvent("book_saved");
            return true;
        }
    }
}
