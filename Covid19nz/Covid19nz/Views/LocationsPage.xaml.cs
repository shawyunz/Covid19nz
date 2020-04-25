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

        bool IsDistrictExpanded = false;
        bool IsClusterExpanded = false;

        private void TappedDistrict(object sender, EventArgs e)
        {
            if (!IsDistrictExpanded)
            {
                IsDistrictExpanded = true;
                LytDistrict.LayoutTo(new Rectangle(LytSummary.Bounds.X + 20, LytSummary.Bounds.Y + 100, LytDistrict.Bounds.Width + 20, LytSummary.Bounds.Height), 300, Easing.CubicOut);
            }
            else
            {
                IsClusterExpanded = false;
                LytCluster.LayoutTo(new Rectangle(LytSummary.Bounds.X + 80, LytSummary.Bounds.Height - 110, LytCluster.Bounds.Width - 40, 160), 300, Easing.CubicIn);

                IsDistrictExpanded = false;
                LytDistrict.LayoutTo(new Rectangle(LytSummary.Bounds.X + 40, LytSummary.Bounds.Height - 220, LytDistrict.Bounds.Width - 20, 270), 300, Easing.CubicIn); //110+110+50
            }
        }

        private void TappedCluster(object sender, EventArgs e)
        {
            if (!IsClusterExpanded)
            {
                IsDistrictExpanded = true;
                LytDistrict.LayoutTo(new Rectangle(LytSummary.Bounds.X + 20, LytSummary.Bounds.Y + 100, LytDistrict.Bounds.Width + 20, LytSummary.Bounds.Height), 300, Easing.CubicOut);

                IsClusterExpanded = true;
                LytCluster.LayoutTo(new Rectangle(LytSummary.Bounds.X + 40, LytSummary.Bounds.Y + 220, LytCluster.Bounds.Width + 40, LytSummary.Bounds.Height - 110), 300, Easing.CubicOut);
            }
            else
            {
                IsClusterExpanded = false;
                LytCluster.LayoutTo(new Rectangle(LytSummary.Bounds.X + 80, LytSummary.Bounds.Height - 110, LytCluster.Bounds.Width - 40, 160), 300, Easing.CubicIn);
            }
        }
    }
}