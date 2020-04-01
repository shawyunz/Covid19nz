using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Covid19nz.Models
{
    public partial class CovidCase
    {
        [JsonProperty("CaseNumber")]
        public long CaseNumber { get; set; }

        [JsonProperty("ReportedDate")]
        public DateTimeOffset ReportedDate { get; set; }

        [JsonProperty("LocationName")]
        public string LocationName { get; set; }

        [JsonProperty("Age")]
        public Age Age { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("IsTravelRelated")]
        public IsTravelRelated IsTravelRelated { get; set; }

        [JsonProperty("DepartureDate")]
        public Date DepartureDate { get; set; }

        [JsonProperty("ArrivalDate")]
        public Date ArrivalDate { get; set; }

        private string lastCityBeforeNz;

        [JsonProperty("LastCityBeforeNZ")]
        public string LastCityBeforeNz
        {
            get { return lastCityBeforeNz; }
            set => lastCityBeforeNz = string.IsNullOrWhiteSpace(value) ? " == " : value;
        }

        private string flightNumber;

        [JsonProperty("FlightNumber")]
        public string FlightNumber
        {
            get { return flightNumber; }
            set => flightNumber = string.IsNullOrWhiteSpace(value) ? " == " : value;
        }

        [JsonProperty("CaseType")]
        public string CaseType { get; set; }
    }

    public partial class Age
    {
        [JsonProperty("Valid")]
        public bool Valid { get; set; }

        [JsonProperty("OlderOrEqualToAge")]
        public long OlderOrEqualToAge { get; set; }

        [JsonProperty("YoungerThanAge")]
        public long YoungerThanAge { get; set; }
    }

    public partial class Date
    {
        [JsonProperty("Valid")]
        public bool Valid { get; set; }

        [JsonProperty("Value")]
        public DateTimeOffset Value { get; set; }
    }

    public partial class IsTravelRelated
    {
        [JsonProperty("Valid")]
        public bool Valid { get; set; }

        [JsonProperty("Value")]
        public bool Value { get; set; }
    }

    public partial class CovidCase
    {
        public static List<CovidCase> FromJson(string json) => JsonConvert.DeserializeObject<List<CovidCase>>(json, Converter.Settings);

        public string GenderChar => Gender.Substring(0, 1);
        public string DisplayReportedDate => ReportedDate.ToString("dd/MM/yyyy");
        public string DisplayDepDate => DepartureDate.Valid ? DepartureDate.Value.ToString("dd/MM/yyyy") : " - ";
        public string DisplayArrDate => ArrivalDate.Valid ? ArrivalDate.Value.ToString("dd/MM/yyyy") : " - ";

        //sample data 31/03
        //[
        //  {
        //    "CaseNumber": 600,
        //    "ReportedDate": "2020-03-31T00:00:00+13:00",
        //    "LocationName": "Southern",
        //    "Age": {
        //      "Valid": true,
        //      "OlderOrEqualToAge": 20,
        //      "YoungerThanAge": 29
        //    },
        //    "Gender": "Female",
        //    "IsTravelRelated": {
        //      "Valid": false,
        //      "Value": false
        //    },
        //    "DepartureDate": {
        //      "Valid": false,
        //      "Value": "0001-01-01T00:00:00Z"
        //    },
        //    "ArrivalDate": {
        //      "Valid": false,
        //      "Value": "0001-01-01T00:00:00Z"
        //    },
        //    "LastCityBeforeNZ": " ",
        //    "FlightNumber": " ",
        //    "CaseType": "confirmed"
        //  }
        //]
    }
}