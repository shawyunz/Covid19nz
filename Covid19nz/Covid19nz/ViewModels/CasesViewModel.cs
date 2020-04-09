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

        public CovidLocation SelectedLocation { get; set; }
        public Command LoadFilterCommand { get; set; }
        public Command LoadItemsCommand { get; set; }
        public ObservableCollection<CovidCase> AllCases { get; set; }
        public ObservableCollection<CovidCase> DisplayCases { get; set; }

        public CasesViewModel(CovidLocation location = null)
        {
            Title = location is null ? "All Cases" : location?.LocationName + " (" + location?.CaseCount + ")";
            SelectedLocation = location;

            AllCases = new ObservableCollection<CovidCase>();
            DisplayCases = new ObservableCollection<CovidCase>();

            LoadFilterCommand = new Command(() => LoadFilterCases());
            LoadItemsCommand = new Command(() => ExecuteLoadCasesCommand());

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
                    new ObservableCollection<CovidCase>(App.AppCases.Where(s => s.LocationName.Equals(SelectedLocation.LocationName)));

                LoadFilterCases();

                OnPropertyChanged(nameof(DisplayCases));
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
            DisplayCases = AllCases;

            if (HasFlight)
            {
                DisplayCases = new ObservableCollection<CovidCase>
                    (DisplayCases.Where(s => !s.FlightNumber.Equals(CovidCase.CASEPLACEHOLDER)));
            }

            if (IsConfirmed && IsProbable)
            {
                DisplayCases = new ObservableCollection<CovidCase>
                    (DisplayCases.Where(s => s.CaseType.Equals(CovidCase.CONFIRMEDCASE) || s.CaseType.Equals(CovidCase.PROBABLECASE)));
            }
            if (IsConfirmed && !IsProbable)
            {
                DisplayCases = new ObservableCollection<CovidCase>
                    (DisplayCases.Where(s => s.CaseType.Equals(CovidCase.CONFIRMEDCASE)));
            }
            if (!IsConfirmed && IsProbable)
            {
                DisplayCases = new ObservableCollection<CovidCase>
                    (DisplayCases.Where(s => s.CaseType.Equals(CovidCase.PROBABLECASE)));
            }

            OnPropertyChanged(nameof(DisplayCases));
        }
    }
}
