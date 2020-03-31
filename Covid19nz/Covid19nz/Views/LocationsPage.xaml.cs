using System;
using System.ComponentModel;
using Xamarin.Forms;

using Covid19nz.ViewModels;

namespace Covid19nz.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class LocationsPage : ContentPage
    {
        LocationsViewModel viewModel;

        public LocationsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new LocationsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CasesPage(new CasesViewModel(viewModel.SelectedLocation)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}