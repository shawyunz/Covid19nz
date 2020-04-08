using Covid19nz.Models;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Covid19nz.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AlertPage : ContentPage
    {
        public AlertLevel CurrentLevel { get; private set; }
        public string UriCovidNZ => "https://covid19.govt.nz";
        public string UriMohNZ => "https://www.health.govt.nz/our-work/diseases-and-conditions/covid-19-novel-coronavirus/covid-19-current-situation/covid-19-current-cases";
        public string UriGlobalStats => "https://ncov2019.live/data";
        public string UriMapNZ => "https://covid19map.nz/";
        public string UriNZAlertLevel => "https://covid19.govt.nz/assets/COVID_Alert-levels_v2.pdf";

        public AlertPage()
        {
            InitializeComponent();
            CurrentLevel = App.AppAlertLevel;
            BindingContext = this;
        }

        private async void OpenUriCovidNZ(object sender, System.EventArgs e)
        {
            if (await Launcher.CanOpenAsync(UriCovidNZ))
                await Launcher.OpenAsync(UriCovidNZ);
        }

        private async void OpenUriMohNZ(object sender, System.EventArgs e)
        {
            if (await Launcher.CanOpenAsync(UriMohNZ))
                await Launcher.OpenAsync(UriMohNZ);
        }

        private async void OpenUriGlobalStats(object sender, System.EventArgs e)
        {
            if (await Launcher.CanOpenAsync(UriGlobalStats))
                await Launcher.OpenAsync(UriGlobalStats);
        }

        private async void OpenUriMapNZ(object sender, System.EventArgs e)
        {
            if (await Launcher.CanOpenAsync(UriMapNZ))
                await Launcher.OpenAsync(UriMapNZ);
        }

        private async void OpenNZAlertLevel(object sender, System.EventArgs e)
        {
            if (await Launcher.CanOpenAsync(UriNZAlertLevel))
                await Launcher.OpenAsync(UriNZAlertLevel);
        }
    }
}