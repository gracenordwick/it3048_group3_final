using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using it3048_group3_final.Data;
using it3048_group3_final.Models;
using it3048_group3_final.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace it3048_group3_final.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalendarView : ContentPage, INotifyPropertyChanged
	{
        public ObservableCollection<CalendarItem> CalendarItems { get; set; }

        private DateTime _currentDate;

		public DateTime CurrentDate 
		{
			 get { return _currentDate; }
			set
			{
				if (_currentDate != value)
				{
					_currentDate = value;
					OnPropertyChanged(nameof(CurrentDate));
				}
			}
		}

        public CalendarView()
        {
            InitializeComponent();
            CalendarItems = new ObservableCollection<CalendarItem>();
            BindingContext = this;
            LoadItems();
        }

        private async void LoadItems()
        {
            // Fetch calendar items from the database
            var items = await App.Database.GetItemsAsync();

            // Clear existing items and add fetched items
            CalendarItems.Clear();
            foreach (var item in items)
            {
                CalendarItems.Add(item);
                /*if (item.Date.Date == CurrentDate.Date) // Comparing only the date part
                {
                    CalendarItems.Add(item);
                }*/
            }
        }

        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            // Navigate to the AddItemPage
            await Navigation.PushAsync(new AddItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadItems();
        }

    }
}