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

namespace it3048_group3_final.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalendarView : ContentPage, INotifyPropertyChanged
	{
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
			CurrentDate = DateTime.Today;
			BindingContext = this;
		}

		private void PreviousMonthClicked(object sender, EventArgs e)
		{
			CurrentDate = CurrentDate.AddMonths(-1);
		}
		
		private void NextMonthClicked(object sender, EventArgs e) 
		{ 
			CurrentDate = CurrentDate.AddMonths(1);
		}

	}
}