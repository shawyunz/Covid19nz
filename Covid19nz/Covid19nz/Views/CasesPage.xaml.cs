using System;
using System.ComponentModel;
using Xamarin.Forms;

using Covid19nz.ViewModels;

namespace Covid19nz.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CasesPage : ContentPage
    {
        CasesViewModel viewModel;

        public CasesPage(CasesViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        public CasesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CasesViewModel(null);
        }

        //public ItemDetailPage()
        //{
        //    InitializeComponent();

        //    var item = new Item
        //    {
        //        Text = "Item 1",
        //        Description = "This is an item description."
        //    };

        //    viewModel = new ItemDetailViewModel(item);
        //    BindingContext = viewModel;
        //}
    }
}