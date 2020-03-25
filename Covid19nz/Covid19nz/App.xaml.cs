using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Covid19nz.Services;
using Covid19nz.Views;

namespace Covid19nz
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<LocationStore>();
            MainPage = new AppShell();
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
