using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Quiz_app
{
    public partial class App : Application
    {
        public static string DB_path = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Quiz_app.MainPage());
        }

        public App(string dbPath)
        {
            InitializeComponent();
            DB_path = dbPath;
            MainPage = new NavigationPage(new Quiz_app.MainPage());
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
