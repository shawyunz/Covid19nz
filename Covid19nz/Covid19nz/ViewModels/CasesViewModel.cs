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
    public class CasesViewModel : BaseViewModel
    {
        public CovidLocation Item { get; set; }
        public ObservableCollection<CovidCase> AllCases { get; set; }
        public ObservableCollection<CovidCase> DisplayCases { get; set; }
        public Command LoadItemsCommand { get; set; }
        public CasesViewModel(CovidLocation item = null)
        {
            Title = item is null ? "All Cases" : item?.LocationName + " (" + item?.CaseCount + ")";
            Item = item;
            AllCases = new ObservableCollection<CovidCase>();
            LoadItemsCommand = new Command(() => ExecuteLoadCasesCommand());

            ExecuteLoadCasesCommand();
        }

        private void ExecuteLoadCasesCommand()
        {
            IsBusy = true;

            try
            {
                //App.Current.GetCases();

                AllCases.Clear();
                AllCases = new ObservableCollection<CovidCase>(App.AppCases);

                //filter with location
                DisplayCases = Item is null ? AllCases : 
                     new ObservableCollection<CovidCase>(
                        AllCases.Where(s => s.LocationName.Equals(Item.LocationName)));
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
