using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AppCenter.Crashes;
using Microsoft.WindowsAzure.MobileServices;
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

        public static MobileServiceClient client = new MobileServiceClient("https://readbooks7.azurewebsites.net");

        public async Task<bool> SaveBook()
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


            //try
            //{
            //    await client.GetTable<Book>().InsertAsync(this);
            //    return true;
            //}
            //catch(MobileServiceInvalidOperationException msioe)
            //{
            //    var response = await msioe.Response.Content.ReadAsStringAsync();
            //    return false;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }

        public static async Task<List<Book>> ReadBooks()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Book>();
                return conn.Table<Book>().OrderByDescending(b => b.FinishedDate).ToList();
            }

            //return await client.GetTable<Book>().ToListAsync();
        }

        public override string ToString()
        {
            return $"{Name} - {Author}";
        }
    }
}
