using Covid19nz.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Covid19nz.Controls
{
    class CaseSearchHandler : SearchHandler
    {
        public List<CovidCase> CaseList { get; set; }


        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                if (CaseList != null)
                {
                    ItemsSource = CaseList
                        .Where(cc => cc.FlightNumber.ToLower().Contains(newValue.ToLower()) 
                            || cc.LastCityBeforeNz.ToLower().Contains(newValue.ToLower())).ToList();
                }
            }
        }

        protected override void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            MessagingCenter.Send<SearchHandler, CovidCase>(this, "FindLine", item as CovidCase);
        }
    }
}
