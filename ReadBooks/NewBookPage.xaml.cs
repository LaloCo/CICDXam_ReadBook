using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ReadBooks
{
    public partial class NewBookPage : ContentPage
    {
        public NewBookPage()
        {
            InitializeComponent();
        }

        void SaveButton_Clicked(object sender, System.EventArgs e)
        {
            Book book = new Book
            {
                Author = "",
                ISBN = "",
                Name = "",
                Publisher = ""
            };
            book.SaveBook();
        }
    }
}
