using Covid19nz.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19nz.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class StatsPage : ContentPage
    {
        public StatsPage()
        {
            InitializeComponent();

            BindingContext = new StatsViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = new StatsViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var uri = new Uri("https://www.health.govt.nz/our-work/diseases-and-conditions/covid-19-novel-coronavirus/covid-19-current-situation/covid-19-current-cases");

            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}