using System;
using System.ComponentModel;
using Xamarin.Forms;

using Covid19nz.Controls;
using Covid19nz.ViewModels;
using Covid19nz.Models;
using System.Collections.ObjectModel;

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
    }
}