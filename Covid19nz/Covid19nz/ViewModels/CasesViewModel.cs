using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Covid19nz.Models;
using Xamarin.Forms;

namespace Covid19nz.ViewModels
{
    public class CasesViewModel : BaseViewModel
    {
        public bool IsConfirmed { get; set; } = true;
        public bool IsProbable { get; set; } = true;
        public bool HasFlight { get; set; } = false;
        public bool ShowHelpInfo { get; set; } = false;

        public CovidLocation SelectedLocation { get; set; }
        public Command LoadFilterCommand { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command ShowHelpCommand { get; set; }
        public ObservableCollection<CovidCase> AllCases { get; set; }

        ObservableCollection<CovidCase> displayCases;
        public ObservableCollection<CovidCase> DisplayCases
        {
            get { return displayCases; }
            set { SetProperty(ref displayCases, value); }
        }

        public CasesViewModel(CovidLocation location = null)
        {
            Title = location is null ? "All Cases" : location?.LocationName + " (" + location?.CaseCount + ")";
            SelectedLocation = location;

            AllCases = new ObservableCollection<CovidCase>();
            DisplayCases = new ObservableCollection<CovidCase>();

            LoadFilterCommand = new Command(() => LoadFilterCases());
            LoadItemsCommand = new Command(() => ExecuteLoadCasesCommand());
            ShowHelpCommand = new Command(() => ShowHelp());

            ExecuteLoadCasesCommand();
        }

        private void ExecuteLoadCasesCommand()
        {
            IsBusy = true;

            try
            {
                AllCases.Clear();
                AllCases = SelectedLocation is null ?
                    new ObservableCollection<CovidCase>(App.AppCases) :
                    new ObservableCollection<CovidCase>(App.AppCases.Where(s => s.Dhb.Equals(SelectedLocation.LocationName)));

                LoadFilterCases();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void LoadFilterCases()
        {
            IsBusy = true;

            try
            {
                DisplayCases = AllCases;

                if (IsConfirmed && IsProbable)
                {
                    DisplayCases = new ObservableCollection<CovidCase>(App.AppCases);
                }
                if (IsConfirmed && !IsProbable)
                {
                    DisplayCases = new ObservableCollection<CovidCase>(App.AppCaseData.Confirmed);
                }
                if (!IsConfirmed && IsProbable)
                {
                    DisplayCases = new ObservableCollection<CovidCase>(App.AppCaseData.Probable);
                }
                if (!IsConfirmed && !IsProbable)
                {
                    DisplayCases = null;
                }

                if (HasFlight && DisplayCases != null)
                {
                    DisplayCases = new ObservableCollection<CovidCase>
                        (DisplayCases.Where(s => !string.IsNullOrEmpty(s.FlightNumber)));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void ShowHelp()
        {
            ShowHelpInfo = !ShowHelpInfo;
            OnPropertyChanged(nameof(ShowHelpInfo));
        }
    }
}
