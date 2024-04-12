using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using it3048_group3_final.Models;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace it3048_group3_final.Views
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            var calendarItem = new CalendarItem
            {
                Date = datePicker.Date,
                Title = titleEntry.Text,
                Time = timePicker.Time
            };

            // Save the new calendar item to the database
            await App.Database.SaveItemAsync(calendarItem);

            // Log the saved item ID for debugging
            Console.WriteLine("Saved item ID: " + calendarItem.ID);

            // Navigate back to the CalendarView page
            await Navigation.PopAsync();
        }


        async void OnSaveClicked(object sender, EventArgs e)
        {
            var calendarItem = (CalendarItem)BindingContext;
            await App.Database.SaveItemAsync(calendarItem);
            await Navigation.PopAsync();
        }


        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
