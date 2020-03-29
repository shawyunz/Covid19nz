using System;
using System.ComponentModel;
using Xamarin.Forms;

using Covid19nz.Models;
using Covid19nz.ViewModels;
using System.Collections.ObjectModel;

namespace Covid19nz.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MapPage : ContentPage
    {
        ItemsViewModel viewModel;

        public MapPage()
        {
            InitializeComponent();

            viewModel = new ItemsViewModel
            {
                Items = new ObservableCollection<CovidLocation>(App.AppLocations)
            };
            BindingContext = viewModel;
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (CovidLocation)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }
    }
}