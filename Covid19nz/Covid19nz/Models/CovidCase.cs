using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Covid19nz.Models
{
    public partial class CovidCaseData
    {
        [JsonProperty("confirmed")]
        public List<CovidCase> Confirmed { get; set; }

        [JsonProperty("probable")]
        public List<CovidCase> Probable { get; set; }
    }

    public partial class CovidCase
    {
        [JsonProperty("Date of report")]
        public string DateOfReport { get; set; }

        [JsonProperty("Sex")]
        public string Sex { get; set; } //, NullValueHandling = NullValueHandling.Ignore)

        [JsonProperty("Age group")]
        public string AgeGroup { get; set; }

        [JsonProperty("DHB")]
        public string Dhb { get; set; }

        [JsonProperty("Overseas travel")]
        public string OverseasTravel { get; set; }

        [JsonProperty("Last country before return")]
        public string LastCountryBeforeReturn { get; set; }

        [JsonProperty("Arrival date")]
        public string ArrivalDate { get; set; }

        [JsonProperty("Flight departure date")]
        public string FlightDepartureDate { get; set; }

        [JsonProperty("Flight number")]
        public string FlightNumber { get; set; }
    }

    public partial class CovidCaseData
    {
        public static CovidCaseData FromJson(string json) => JsonConvert.DeserializeObject<CovidCaseData>(json, Converter.Settings);
    }

    public partial class CovidCase
    {
        public string AgeLower => AgeGroup?.Substring(0,2) ?? CASEPLACEHOLDER;
        public string DisplayArrDate => FormatFlightDate(ArrivalDate);
        public string DisplayDepDate => FormatFlightDate(FlightDepartureDate);
        public string DisplayReportedDate => DateOfReport;
        public string GenderChar => Sex?.Substring(0, 1) ?? CASEPLACEHOLDER;

        public string GenderImage => Sex.Equals("Male") ? "icn_male.png" : "icn_female.png";
        //public string TypeConfirmImage => CaseType.Equals(CONFIRMEDCASE) ? "icn_type_cfm1.png" : "icn_type_cfm0.png";
        //public string TypeProbableImage => CaseType.Equals(PROBABLECASE) ? "icn_type_prb1.png" : "icn_type_prb0.png";
        public string TypeConfirmImage { get; set; }
        public string TypeProbableImage { get; set; }

        public static string CONFIRMEDCASE = "confirmed";
        public static string PROBABLECASE = "probable";
        public static string CASEPLACEHOLDER = " N/A ";

        private string FormatFlightDate(string date)
        {
            return string.IsNullOrEmpty(date) ? CASEPLACEHOLDER : date.Substring(5, 10);
        }

        ////sample data
        //{"Date of report":"07/04/2020",
        //"Sex":"Female",
        //"Age group":"20 to 29",
        //"DHB":"Waitemata",
        //"Overseas travel":"Yes",
        //"Last country before return":"Australia",
        //"Flight number":"NZ102",
        //"Flight departure date":"2020-03-27T12:00:00.000Z",
        //"Arrival date":"2020-03-28T12:00:00.000Z"}
    }
}