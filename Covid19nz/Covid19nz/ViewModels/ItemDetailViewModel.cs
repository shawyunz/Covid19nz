using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Covid19nz.Models;
using Xamarin.Forms;

namespace Covid19nz.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public CovidLocation Item { get; set; }
        public ObservableCollection<CovidCase> AllCases { get; set; }
        public ObservableCollection<CovidCase> DisplayCases { get; set; }
        public Command LoadItemsCommand { get; set; }
        public ItemDetailViewModel(CovidLocation item = null)
        {
            Title = item?.LocationName;
            Item = item;
            AllCases = new ObservableCollection<CovidCase>();
            LoadItemsCommand = new Command(() => ExecuteLoadCasesCommand());

            ExecuteLoadCasesCommand();
        }

        void ExecuteLoadCasesCommand()
        {
            IsBusy = true;

            try
            {
                AllCases.Clear();
                //var items = await LocationData.GetItemsAsync(true);

                var locationJson = new WebClient().DownloadString("https://nzcovid19api.xerra.nz/cases/json");
                var items = CovidCase.FromJson(locationJson).ToList();

                foreach (var item in items)
                {
                    AllCases.Add(item);
                }

                //filter with location
                DisplayCases = new ObservableCollection<CovidCase>(
                    AllCases.Where(s => s.LocationName.Equals(Item.LocationName)));
                OnPropertyChanged(nameof(DisplayCases));
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
