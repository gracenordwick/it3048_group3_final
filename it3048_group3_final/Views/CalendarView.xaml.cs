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
using Xamarin.Forms.Internals;

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

        private async void LoadItems(bool filterByDate = true)
        {
            // Fetch calendar items from the database
            var items = await App.Database.GetItemsAsync();

            // Clear existing items
            CalendarItems.Clear();

            // Filter items based on the selected date if filterByDate is true
            if (filterByDate)
            {
                DateTime selectedDate = myDatePicker.Date;
                foreach (var item in items)
                {
                    if (item.Date.Date == selectedDate.Date)
                    {
                        CalendarItems.Add(item);
                    }
                }
            }
            else // Add all items to CalendarItems if filterByDate is false
            {
                foreach (var item in items)
                {
                    CalendarItems.Add(item);
                }
            }
        }

        private CalendarItem _selectedItem;
        public CalendarItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private async void OnAddTaskClicked(object sender, EventArgs e)
        {
            // Navigate to the AddItemPage
            await Navigation.PushAsync(new AddItemPage());
        }

        private async void OnDeleteTaskClicked(object sender, EventArgs e)
        {
            if (SelectedItem != null)
            {
                await App.Database.DeleteItemAsync(SelectedItem);
                LoadItems();
            }
        }

        private void OnFilterClicked(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void OnDisplayAllClicked(object sender, EventArgs e)
        {
            LoadItems(filterByDate: false); // Load all items without filtering by date
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadItems();
        }

    }
}
