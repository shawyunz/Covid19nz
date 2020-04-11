using System.Collections.Generic;
using Newtonsoft.Json;

namespace Covid19nz.Models
{
    public partial class CovidSummary
    {
        public CovidSummary(Dictionary<string, int> SummaryData)
        {
            ConfirmedCasesTotal  = SummaryData["ConfirmedCasesTotal"];
            var cfm24            = SummaryData["ConfirmedCasesNew24h"];
            ConfirmedCasesNew24h = cfm24 > 0 ? $"(+{cfm24})" : $"({cfm24})";    //need refactor

            ProbableCasesTotal   = SummaryData["ProbableCasesTotal"];
            var prb24            = SummaryData["ProbableCasesNew24h"];
            ProbableCasesNew24h  = prb24 > 0 ? $"(+{prb24})" : $"({prb24})";

            RecoveredCasesTotal  = SummaryData["RecoveredCasesTotal"];
            var rcv24            = SummaryData["RecoveredCasesNew24h"];
            RecoveredCasesNew24h = rcv24 > 0 ? $"(+{rcv24})" : $"({rcv24})";

            HospitalisedCasesTotal  = SummaryData["HospitalisedCasesTotal"];
            var hsp24               = SummaryData["HospitalisedCasesNew24h"];
            HospitalisedCasesNew24h = hsp24 > 0 ? $"(+{hsp24})" : $"({hsp24})";

            DeathCasesTotal      = SummaryData["DeathCasesTotal"];
            var dth24            = SummaryData["DeathCasesNew24h"];
            DeathCasesNew24h     = dth24 > 0 ? $"(+{dth24})" : $"({dth24})";

            CasesAmount          = ConfirmedCasesTotal + ProbableCasesTotal;
            var amt24            = cfm24 + prb24;
            CasesAmountNew24h    = amt24 > 0 ? $"(+{amt24})" : $"({amt24})";
        }

        public int ConfirmedCasesTotal { get; set; }
        public string ConfirmedCasesNew24h { get; set; }
        public int ProbableCasesTotal { get; set; }
        public string ProbableCasesNew24h { get; set; }
        public int RecoveredCasesTotal { get; set; }
        public string RecoveredCasesNew24h { get; set; }
        public int HospitalisedCasesTotal { get; set; }
        public string HospitalisedCasesNew24h { get; set; }
        public int DeathCasesTotal { get; set; }
        public string DeathCasesNew24h { get; set; }
        public int CasesAmount { get; set; }
        public string CasesAmountNew24h { get; set; }
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
