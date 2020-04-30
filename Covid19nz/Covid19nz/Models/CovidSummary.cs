using Newtonsoft.Json;
using System.Collections.Generic;

namespace Covid19nz.Models
{
    public partial class CovidSummary
    {
        public CovidSummary(Dictionary<string, int> SummaryData)
        {
            ConfirmedCasesTotal = SummaryData["ConfirmedCasesTotal"];
            ConfirmedCasesNew24h = FormatNumber24h(SummaryData["ConfirmedCasesNew24h"]);

            ProbableCasesTotal = SummaryData["ProbableCasesTotal"];
            ProbableCasesNew24h = FormatNumber24h(SummaryData["ProbableCasesNew24h"]);

            RecoveredCasesTotal = SummaryData["RecoveredCasesTotal"];
            RecoveredCasesNew24h = FormatNumber24h(SummaryData["RecoveredCasesNew24h"]);

            HospitalisedCasesTotal = SummaryData["HospitalisedCasesTotal"];
            HospitalisedCasesNew24h = FormatNumber24h(SummaryData["HospitalisedCasesNew24h"]);

            DeathCasesTotal = SummaryData["DeathCasesTotal"];
            DeathCasesNew24h = FormatNumber24h(SummaryData["DeathCasesNew24h"]);

            CasesAmount = ConfirmedCasesTotal + ProbableCasesTotal;
            CasesAmountNew24h = FormatNumber24h(SummaryData["ConfirmedCasesNew24h"] + SummaryData["ProbableCasesNew24h"]);
        }

        public int CasesAmount { get; set; }
        public string CasesAmountNew24h { get; set; }

        public string ConfirmedCasesNew24h { get; set; }
        public int ConfirmedCasesTotal { get; set; }

        public string DeathCasesNew24h { get; set; }
        public int DeathCasesTotal { get; set; }

        public string HospitalisedCasesNew24h { get; set; }
        public int HospitalisedCasesTotal { get; set; }

        public string ProbableCasesNew24h { get; set; }
        public int ProbableCasesTotal { get; set; }

        public string RecoveredCasesNew24h { get; set; }
        public int RecoveredCasesTotal { get; set; }

        private string FormatNumber24h(int number)
        {
            return number > 0 ? $"(+{number})" : $"({number})";
        }
    }

    public partial class CovidSummary
    {
        public static Dictionary<string, int> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, int>>(json, Converter.Settings);

        //mock data on 31/03
        //{
        //  "ConfirmedCasesTotal": 600,
        //  "ConfirmedCasesNew24h": 48,
        //  "ProbableCasesTotal": 47,
        //  "ProbableCasesNew24h": 10,
        //  "RecoveredCasesTotal": 74,
        //  "RecoveredCasesNew24h": 11,
        //  "HospitalisedCasesTotal": 14,
        //  "HospitalisedCasesCurrent": 14,
        //  "DeathCasesTotal": 1,
        //  "DeathCasesNew24h": 0
        //}
    }
}