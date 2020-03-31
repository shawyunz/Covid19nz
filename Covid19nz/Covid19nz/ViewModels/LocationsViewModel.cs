using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

using Xamarin.Forms;

using Covid19nz.Models;

namespace Covid19nz.ViewModels
{
    public class LocationsViewModel : BaseViewModel
    {
        public ObservableCollection<CovidLocation> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CovidLocation SelectedLocation { get; set; }

        public LocationsViewModel()
        {
            Title = "Covid-19 NZ";
            Items = new ObservableCollection<CovidLocation>();
            LoadItemsCommand = new Command(() => ExecuteLoadItemsCommand());
        }

        private void ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                App.Current.GetLocations();

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