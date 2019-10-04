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

            finishDatePicker.MaximumDate = DateTime.Now;
        }

        async void SaveButton_Clicked(object sender, System.EventArgs e)
        {
            Book book = new Book
            {
                Author = bookAuthorEntry.Text,
                Name = bookNameEntry.Text,
                FinishedDate = finishDatePicker.Date
            };

            bool result = await book.SaveBook();
            if(result)
            {
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "We had problems saving this book, please try again", "Ok");
            }
        }
    }
}
