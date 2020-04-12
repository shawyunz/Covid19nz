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

        private async void OpenMoh(object sender, EventArgs e)
        {
            var uri = new Uri(viewModel.WebSourceUrl);

            if (await Launcher.CanOpenAsync(uri))
                await Launcher.OpenAsync(uri);
        }

        private async void OpenCopyright(object sender, EventArgs e)
        {
            var uri = "https://creativecommons.org/licenses/by/4.0/";
            if (await Launcher.CanOpenAsync(uri))
                await Launcher.OpenAsync(uri);
        }
    }
}