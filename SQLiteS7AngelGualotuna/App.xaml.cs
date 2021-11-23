using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteS7AngelGualotuna
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new login1());
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
