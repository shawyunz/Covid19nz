﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Covid19nz.Models
{

    public partial class CovidCluster
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        [JsonProperty("Cases")]
        public int Cases { get; set; }

        [JsonProperty("CasesNew24h")]
        public int CasesNew24H { get; set; }
    }

    public partial class CovidCluster
    {
        public static List<CovidCluster> FromJson(string json) => JsonConvert.DeserializeObject<List<CovidCluster>>(json, Converter.Settings);

        //////sample data
        ////{
        ////  "Name": "Aged residential care facility (1)",
        ////  "Location": "Christchurch",
        ////  "Cases": 54,
        ////  "CasesNew24h": 2
        ////},
    }
}
