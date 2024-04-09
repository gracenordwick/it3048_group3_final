﻿using it3048_group3_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace it3048_group3_final.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddItemPage : ContentPage
	{
		public AddItemPage ()
		{
			InitializeComponent ();
		}
        async void OnSaveClicked()
        {
            var calendarItem = (CalendarItem)BindingContext;
            await App.Database.SaveItemsAsync(calendarItem);
            await Navigation.PopAsync();
        }
        async void OnDeleteClicked()
        {
            var calendarItem = (CalendarItem)BindingContext;
            await App.Database.DeleteItemsAsync(calendarItem);
            await Navigation.PopAsync();
        }
        async void OnCancelClicked()
        {
            await Navigation.PopAsync();
        }
    }
}