using System;
using System.ComponentModel;
using Xamarin.Forms;

using Covid19nz.Controls;
using Covid19nz.ViewModels;
using Covid19nz.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Covid19nz.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CasesPage : ContentPage
    {
        public CasesPage(CasesViewModel viewModel) : this()
        {
            BindingContext = viewModel;
        }

        public CasesPage()
        {
            InitializeComponent();
            BindingContext = new CasesViewModel(null);

            CovidCaseList.Scrolled += Scrollview_Scrolled;

            SubscribeMsgFromSearch();
        }

        private void SubscribeMsgFromSearch()
        {
            MessagingCenter.Subscribe<SearchHandler, CovidCase>(this, "FindLine", async (sender, e) =>
            {
                if (CovidCaseList.ItemsSource is ObservableCollection<CovidCase> list)
                {
                    if (list.Contains(e))
                    {
                        //CovidCaseList.SelectedItem = e;
                        await CovidCaseList.FadeTo(0.5, 200, Easing.CubicIn);
                        CovidCaseList.ScrollTo(e, ScrollToPosition.MakeVisible, false);
                        await CovidCaseList.FadeTo(1, 200, Easing.CubicOut);
                    }
                }
            });
        }

        double previousOffset;

        private async void Scrollview_Scrolled(object sender, ScrolledEventArgs e)
        {
            double translation;
            bool visibility;

            if (previousOffset < e.ScrollY - 45)
            {
                translation = -40;
                visibility = false;
            }
            else if (previousOffset > e.ScrollY + 45)
            {
                translation = 0;
                visibility = true;
            }
            else
            {
                return;
            }

            await LytFilter.TranslateTo(LytFilter.TranslationX, translation, 300);
            await Task.Delay(100);
            LytFilter.IsVisible = visibility;
            previousOffset = e.ScrollY;
        }


    }
}