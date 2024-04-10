using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using it3048_group3_final.Models;

namespace it3048_group3_final.Views
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var calendarItem = (CalendarItem)BindingContext;
            await App.Database.SaveItemAsync(calendarItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var calendarItem = (CalendarItem)BindingContext;
            await App.Database.DeleteItemAsync(calendarItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}