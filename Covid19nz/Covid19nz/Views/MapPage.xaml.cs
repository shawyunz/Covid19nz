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
    public partial class MapPage : ContentPage
    {
        MapViewModel viewModel;

        public MapPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new MapViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var uri = new Uri(viewModel.WebSourceUrl);

            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}