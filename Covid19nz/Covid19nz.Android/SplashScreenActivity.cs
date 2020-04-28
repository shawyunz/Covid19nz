
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Covid19nz.Droid;
using System.Threading.Tasks;

namespace Covid19nz.Droid
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, Immersive = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashScreen);
            FindViewById<TextView>(Resource.Id.txtAppVersion).Text = $"Covid-19 NZ v{PackageManager.GetPackageInfo(PackageName, 0).VersionName}";
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        async void SimulateStartup()
        {
            await Task.Delay(3000);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}