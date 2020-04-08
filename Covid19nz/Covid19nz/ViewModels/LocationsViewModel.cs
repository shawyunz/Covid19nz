using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

using Xamarin.Forms;

using Covid19nz.Models;

namespace Covid19nz.ViewModels
{
    public class LocationsViewModel : BaseViewModel
    {
        public bool ExpandHeader { get; set; }
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
            LoadItemsCommand = new Command(() => ExecuteLoadItemsCommand());
        }

        private void ExecuteExpandCommand()
        {
            ExpandHeader = !ExpandHeader;
            OnPropertyChanged(nameof(ExpandHeader));
        }

        private void ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                App.Current.GetAlertLevel();
                App.Current.GetCases();
                App.Current.GetLocations();
                App.Current.GetSummary();

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