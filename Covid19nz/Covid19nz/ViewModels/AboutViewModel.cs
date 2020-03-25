using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Covid19nz.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        public ICommand OpenWebCommand { get; }

        public const string DiceD20Outline = "\U000f05ea";
        public const string CarEstate = "\U000f07a8";
        public const string CarHatchback = "\U000f07a9";
        public const string CarPickup = "\U000f07aa";
        public const string CarSide = "\U000f07ab";
        public const string CarSports = "\U000f07ac";
    }
}