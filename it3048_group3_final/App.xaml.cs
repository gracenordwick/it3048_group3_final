using it3048_group3_final.Data;
using it3048_group3_final.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace it3048_group3_final
{
    public partial class App : Application
    {
        private static CalendarItemDatabase database;
        internal static CalendarItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CalendarItemDatabase(Path.Combine(Environment.GetFolderPath
                    (Environment.SpecialFolder.LocalApplicationData), "CalendarItems.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CalendarView());
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
