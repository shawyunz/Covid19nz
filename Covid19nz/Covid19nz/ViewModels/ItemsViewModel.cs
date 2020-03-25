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
            Title = "Covid19 Locations";
            Items = new ObservableCollection<CovidLocation>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, CovidLocation>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as CovidLocation;
                Items.Add(newItem);
                await LocationData.AddItemAsync(newItem);
            });
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