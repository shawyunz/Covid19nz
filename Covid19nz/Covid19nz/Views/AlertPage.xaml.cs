using Covid19nz.Models;
using System.ComponentModel;
using Xamarin.Forms;

namespace Covid19nz.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AlertPage : ContentPage
    {
        public AlertLevel CurrentLevel { get; private set; }

        public AlertPage()
        {
            InitializeComponent();
            CurrentLevel = App.AppAlertLevel;
            BindingContext = this;
        }
    }
}