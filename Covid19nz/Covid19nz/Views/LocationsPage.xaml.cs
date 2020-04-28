using Covid19nz.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Covid19nz.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class LocationsPage : ContentPage
    {
        private const int TIMESPAN = 250;
        private bool IsClusterExpanded = false;
        private bool IsDistrictExpanded = false;
        private LocationsViewModel viewModel;

        public LocationsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new LocationsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.ListLocation?.Count == 0)
                viewModel.IsBusy = true;
        }

        private async void OnItemSelected(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CasesPage(new CasesViewModel(viewModel.SelectedLocation)));
        }

        private void TappedCluster(object sender, EventArgs e)
        {
            var heightSummary = LytSummary.Bounds.Height;
            var widthSummary = LytSummary.Bounds.Width;

            if (!IsClusterExpanded)
            {
                IsDistrictExpanded = true;
                LytDistrict.LayoutTo(new Rectangle(20, 100, widthSummary, heightSummary), TIMESPAN, Easing.CubicOut);

                IsClusterExpanded = true;
                LytCluster.LayoutTo(new Rectangle(40, 200, widthSummary, heightSummary), TIMESPAN, Easing.CubicOut);
            }
            else
            {
                IsClusterExpanded = false;
                LytCluster.LayoutTo(new Rectangle(80, heightSummary - 100, widthSummary, 200), TIMESPAN, Easing.CubicIn);
            }
        }

        private void TappedDistrict(object sender, EventArgs e)
        {
            var heightSummary = LytSummary.Bounds.Height;
            var widthSummary = LytSummary.Bounds.Width;

            if (!IsDistrictExpanded)
            {
                IsDistrictExpanded = true;
                LytDistrict.LayoutTo(new Rectangle(20, 100, widthSummary, heightSummary), TIMESPAN, Easing.CubicOut);
            }
            else
            {
                if (IsClusterExpanded)
                {
                    IsClusterExpanded = false;
                    LytCluster.LayoutTo(new Rectangle(80, heightSummary - 100, widthSummary, 200), TIMESPAN, Easing.CubicIn);
                }
                else
                {
                    IsDistrictExpanded = false;
                    LytDistrict.LayoutTo(new Rectangle(40, heightSummary - 200, widthSummary, 300), TIMESPAN, Easing.CubicIn);
                }
            }
        }

        private void TappedSummary(object sender, EventArgs e)
        {
            var heightSummary = LytSummary.Bounds.Height;
            var widthSummary = LytSummary.Bounds.Width;

            if (IsClusterExpanded)
            {
                IsClusterExpanded = false;
                LytCluster.LayoutTo(new Rectangle(80, heightSummary - 100, widthSummary, 200), TIMESPAN, Easing.CubicIn);
            }

            if (IsDistrictExpanded)
            {
                IsDistrictExpanded = false;
                LytDistrict.LayoutTo(new Rectangle(40, heightSummary - 200, widthSummary, 300), TIMESPAN, Easing.CubicIn);
            }
        }
    }
}