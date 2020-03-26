using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Covid19nz.Models;
using Covid19nz.Views;

namespace Covid19nz.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<CovidLocation> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public CovidLocation SelectedLocation { get; set; }

        public ItemsViewModel()
        {
            Title = "Covid-19 NZ";
            Items = new ObservableCollection<CovidLocation>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await LocationData.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
                //OnPropertyChanged(nameof(Items));
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