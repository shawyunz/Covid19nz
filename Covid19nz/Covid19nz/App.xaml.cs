using Covid19nz.Models;
using Covid19nz.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Covid19nz
{
    public partial class App : Application
    {
        private readonly HttpClient httpClient;

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            //contructor should empty to utilize NativeHandlers
            httpClient = new HttpClient();

            //InitializeDataFromAPI();
        }

        public static AlertLevel AppAlertLevel { get; set; }
        public static CovidCaseData AppCaseData { get; set; }
        public static List<CovidCase> AppCases { get; set; }
        public static List<CovidCluster> AppClusters { get; set; }
        public static List<CovidLocation> AppLocations { get; set; }
        public static CovidSummary AppSummary { get; set; }
        public new static App Current => Application.Current as App;

        public async Task InitializeDataFromAPI()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                //run methods in parallel as they are independent
                await Task.WhenAll(GetSummary(), GetCases(), GetCluster(), GetAlertLevel());
            }
            else
            {
                await MainPage.DisplayAlert("Error", "Connection failure", "OK");
            }
        }

        protected override void OnResume()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnStart()
        {
        }

        private async Task GetAlertLevel()
        {
            var levelJson = await httpClient.DownloadStringAsync("https://nzcovid19api.xerra.nz/alertlevel/json");
            AppAlertLevel = AlertLevel.FromJson(levelJson);
        }

        private async Task GetCases()
        {
            ////(deprecated)
            ////static data
            //AppCases = CovidCase.FromJson(JsonCases0325);
            ////live data
            //var casesJson = await httpClient.DownloadStringAsync("https://nzcovid19api.xerra.nz/cases/json");

            //live data
            var casesJson = await httpClient.DownloadStringAsync("https://raw.githubusercontent.com/philiprenich/nz-covid19-data/master/nz-covid-cases.json");
            AppCaseData = CovidCaseData.FromJson(casesJson);

            var confirmedList = AppCaseData.Confirmed.Select(c => { c.TypeConfirmImage = "icn_type_cfm1.png"; c.TypeProbableImage = "icn_type_prb0.png"; return c; }).ToList();
            var probableList = AppCaseData.Probable.Select(p => { p.TypeConfirmImage = "icn_type_cfm0.png"; p.TypeProbableImage = "icn_type_prb1.png"; return p; }).ToList();
            AppCases = confirmedList.Concat(probableList).ToList();

            var result1 = confirmedList.GroupBy(n => n.Dhb)
                .Select(group => new CovidLocation { LocationName = group.Key, CaseCount = group.Count() })
                .ToList();

            var result2 = probableList.GroupBy(n => n.Dhb)
                .Select(group => new CovidLocation { LocationName = group.Key, CaseCount = group.Count() })
                .ToList();

            AppLocations = result1.OrderBy(l => l.LocationName).ToList();
            foreach (var district in AppLocations)
            {
                district.CountConfirmed = district.CaseCount;
                district.CountProbable = result2.Single(s => s.LocationName.Equals(district.LocationName))?.CaseCount ?? 0;
                district.CaseCount = district.CountConfirmed + district.CountProbable;
            }
        }

        private async Task GetCluster()
        {
            var locationsJson = await httpClient.DownloadStringAsync("https://nzcovid19api.xerra.nz/clusters/json");
            AppClusters = CovidCluster.FromJson(locationsJson);
        }

        //private async Task GetLocations()
        //{
        //    //how to catch exception or timeout if api unavailable??
        //    var locationsJson = await httpClient.DownloadStringAsync("https://nzcovid19api.xerra.nz/locations/json");
        //    AppLocations = CovidLocation.FromJson(locationsJson).Values.ToList();
        //}

        private async Task GetSummary()
        {
            var locationsJson = await httpClient.DownloadStringAsync("https://nzcovid19api.xerra.nz/casestats/json");
            AppSummary = new CovidSummary(CovidSummary.FromJson(locationsJson));
        }
    }
}