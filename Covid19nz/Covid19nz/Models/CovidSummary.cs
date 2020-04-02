using System.Collections.Generic;
using Newtonsoft.Json;

namespace Covid19nz.Models
{
    public partial class CovidSummary
    {
        public CovidSummary(Dictionary<string, int> SummaryData)
        {
            ConfirmedCasesTotal     = SummaryData["ConfirmedCasesTotal"];
            ConfirmedCasesNew24h    = SummaryData["ConfirmedCasesNew24h"];
            ProbableCasesTotal      = SummaryData["ProbableCasesTotal"];
            ProbableCasesNew24h     = SummaryData["ProbableCasesNew24h"];
            RecoveredCasesTotal     = SummaryData["RecoveredCasesTotal"];
            RecoveredCasesNew24h    = SummaryData["RecoveredCasesNew24h"];
            HospitalisedCasesTotal  = SummaryData["HospitalisedCasesTotal"];
            HospitalisedCasesCurrent = SummaryData["HospitalisedCasesCurrent"];
            DeathCasesTotal         = SummaryData["DeathCasesTotal"];
            DeathCasesNew24h        = SummaryData["DeathCasesNew24h"];
        }

        public int ConfirmedCasesTotal { get; set; }
        public int ConfirmedCasesNew24h { get; set; }
        public int ProbableCasesTotal { get; set; }
        public int ProbableCasesNew24h { get; set; }
        public int RecoveredCasesTotal { get; set; }
        public int RecoveredCasesNew24h { get; set; }
        public int HospitalisedCasesTotal { get; set; }
        public int HospitalisedCasesCurrent { get; set; }
        public int DeathCasesTotal { get; set; }
        public int DeathCasesNew24h { get; set; }
        public int CasesAmount => ConfirmedCasesTotal + ProbableCasesTotal;
        public int CasesAmountNew24h => ConfirmedCasesNew24h + ProbableCasesNew24h;
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
