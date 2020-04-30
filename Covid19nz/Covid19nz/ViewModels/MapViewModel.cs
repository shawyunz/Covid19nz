using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Covid19nz.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        public MapViewModel()
        {
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
            OpenAlertPDFCommand = new Command(async () => await Browser.OpenAsync("https://covid19.govt.nz/assets/COVID_Alert-levels_v2.pdf"));
            ShowCopyrightCommand = new Command(() => ExecuteShowCopyright());
        }

        public string ImageUrl => "https://tinyurl.com/covid19nz-stats";

        public ICommand OpenAlertPDFCommand { get; }

        public ICommand OpenWebCommand { get; }

        public bool ShowCopyright { get; set; } = false;

        public Command ShowCopyrightCommand { get; set; }

        public string WebsiteUrl => "http://shawyunz.c1.biz/";

        //public string WebSourceUrl => "https://covid19map.nz/stats";
        public string WebSourceUrl => "https://www.health.govt.nz/our-work/diseases-and-conditions/covid-19-novel-coronavirus/covid-19-current-cases#summary";

        private void ExecuteShowCopyright()
        {
            ShowCopyright = !ShowCopyright;
            OnPropertyChanged(nameof(ShowCopyright));
        }
    }
}