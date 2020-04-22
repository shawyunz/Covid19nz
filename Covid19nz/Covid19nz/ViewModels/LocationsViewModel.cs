using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

using Xamarin.Forms;

using Covid19nz.Models;
using System.Threading.Tasks;

namespace Covid19nz.ViewModels
{
    public class LocationsViewModel : BaseViewModel
    {
        public bool ExpandHeader { get; set; } = true;
        public CovidLocation SelectedLocation { get; set; }
        public CovidSummary SummaryData { get; set; }
        public ObservableCollection<CovidLocation> Items { get; set; }

        public Command ExpandHeaderCommand { get; set; }
        public Command LoadItemsCommand { get; set; }

        public LocationsViewModel()
        {
            Title = "Covid-19 NZ";
            Items = new ObservableCollection<CovidLocation>();
            ExpandHeaderCommand = new Command(() => ExecuteExpandCommand());
            //Todo:replace with AsyncCommand from MvvmHelpers
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        private void ExecuteExpandCommand()
        {
            ExpandHeader = !ExpandHeader;
            OnPropertyChanged(nameof(ExpandHeader));
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                await App.Current.InitializeDataFromAPI();

                SummaryData = App.AppSummary;
                OnPropertyChanged(nameof(SummaryData));

                Items.Clear();
                Items = new ObservableCollection<CovidLocation>(App.AppLocations);
                OnPropertyChanged(nameof(Items));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}