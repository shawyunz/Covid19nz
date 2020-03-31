using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Covid19nz.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        public StatsViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
            OpenAlertPDFCommand = new Command(async () => await Browser.OpenAsync("https://covid19.govt.nz/assets/COVID_Alert-levels_v2.pdf"));
        }

        public ICommand OpenWebCommand { get; }
        public ICommand OpenAlertPDFCommand { get; }
        //public string WebSourceUrl => "https://covid19map.nz/stats";
        public string WebSourceUrl => "https://www.health.govt.nz/our-work/diseases-and-conditions/covid-19-novel-coronavirus/covid-19-current-cases";

        public string ImageUrl => "https://www.health.govt.nz/sites/default/files/images/our-work/diseases-conditions/covid19/hp7357_-_covid_confirmed_and_probable_cases_by_dhb-merged-300320.jpg";

    }
}