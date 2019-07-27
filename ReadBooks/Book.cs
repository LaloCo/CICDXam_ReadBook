using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Crashes;
using SQLite;

namespace ReadBooks
{
    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public DateTime FinishedDate { get; set; }

        public bool SaveBook()
        {
            // save to some db
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Book>();
                int rowsInserted = conn.Insert(this);

                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
                {
                    { "book_info", ToString() },
                    { "network", "Cellular" }
                };
                AppCenterHelper.TrackEvent("book_saved", keyValuePairs);

                return rowsInserted > 0;
            }
        }

        public static List<Book> ReadBooks()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Book>();
                return conn.Table<Book>().OrderByDescending(b => b.FinishedDate).ToList();
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Author}";
        }
    }
}
