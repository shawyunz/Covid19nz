using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Covid19nz.Models;
using Newtonsoft.Json;

namespace Covid19nz.Services
{
    public class LocationStore : IDataStore<CovidLocation>
    {
        readonly List<CovidLocation> locations;

        public LocationStore()
        {
            locations = new List<CovidLocation>()
            {
                new CovidLocation { LocationName = "First item", CaseCount=12 },
                new CovidLocation { LocationName = "Second item", CaseCount=13 },
                new CovidLocation { LocationName = "Third item", CaseCount=15 },
                new CovidLocation { LocationName = "Fourth item", CaseCount=16 },
                new CovidLocation { LocationName = "Fifth item", CaseCount=12 },
                new CovidLocation { LocationName = "Sixth item", CaseCount=12 }
            };
        }

        public async Task<bool> AddItemAsync(CovidLocation item)
        {
            locations.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(CovidLocation item)
        {
            var oldItem = locations.Where((CovidLocation arg) => arg.LocationName == item.LocationName).FirstOrDefault();
            locations.Remove(oldItem);
            locations.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string locationName)
        {
            var oldItem = locations.Where((CovidLocation arg) => arg.LocationName == locationName).FirstOrDefault();
            locations.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<CovidLocation> GetItemAsync(string locationName)
        {
            return await Task.FromResult(locations.FirstOrDefault(s => s.LocationName == locationName));
        }

        public async Task<IEnumerable<CovidLocation>> GetItemsAsync(bool forceRefresh = false)
        {
            //var locationJson = new WebClient().DownloadString("https://nzcovid19api.xerra.nz/locations/json");

            //var list = CovidLocation.FromJson(locationJson);
            //var result = list.Values.ToList();
            var staticJson = "{\n  \"Auckland\": {\n    \"LocationName\": \"Auckland\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        174.7633,\n        -36.8485\n      ]\n    },\n    \"CaseCount\": 79\n  },\n  \"Bay of Plenty\": {\n    \"LocationName\": \"Bay of Plenty\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        177.1423,\n        -37.6893\n      ]\n    },\n    \"CaseCount\": 2\n  },\n  \"Blenheim\": {\n    \"LocationName\": \"Blenheim\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        173.8977,\n        -41.529\n      ]\n    },\n    \"CaseCount\": 1\n  },\n  \"Canterbury\": {\n    \"LocationName\": \"Canterbury\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        171.1637,\n        -43.7542\n      ]\n    },\n    \"CaseCount\": 8\n  },\n  \"Christchurch\": {\n    \"LocationName\": \"Christchurch\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        172.6362,\n        -43.5321\n      ]\n    },\n    \"CaseCount\": 5\n  },\n  \"Dunedin\": {\n    \"LocationName\": \"Dunedin\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        170.5028,\n        -45.8788\n      ]\n    },\n    \"CaseCount\": 11\n  },\n  \"Hamilton\": {\n    \"LocationName\": \"Hamilton\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        175.2793,\n        -37.787\n      ]\n    },\n    \"CaseCount\": 5\n  },\n  \"Hawke's Bay\": {\n    \"LocationName\": \"Hawke's Bay\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        176.7416,\n        -39.109\n      ]\n    },\n    \"CaseCount\": 3\n  },\n  \"Invercargill\": {\n    \"LocationName\": \"Invercargill\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        168.3538,\n        -46.4132\n      ]\n    },\n    \"CaseCount\": 1\n  },\n  \"Kapiti Coast\": {\n    \"LocationName\": \"Kapiti Coast\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        175.3136,\n        -40.8233\n      ]\n    },\n    \"CaseCount\": 3\n  },\n  \"Manawatu\": {\n    \"LocationName\": \"Manawatu\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        175.4376,\n        -39.7273\n      ]\n    },\n    \"CaseCount\": 3\n  },\n  \"Marlborough\": {\n    \"LocationName\": \"Marlborough\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        173.4217,\n        -41.5727\n      ]\n    },\n    \"CaseCount\": 5\n  },\n  \"Nelson\": {\n    \"LocationName\": \"Nelson\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        173.284,\n        -41.2706\n      ]\n    },\n    \"CaseCount\": 5\n  },\n  \"New Plymouth\": {\n    \"LocationName\": \"New Plymouth\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        174.0752,\n        -39.0556\n      ]\n    },\n    \"CaseCount\": 1\n  },\n  \"Northland\": {\n    \"LocationName\": \"Northland\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        173.7624,\n        -35.5795\n      ]\n    },\n    \"CaseCount\": 2\n  },\n  \"Otago\": {\n    \"LocationName\": \"Otago\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        170.1548,\n        -45.4791\n      ]\n    },\n    \"CaseCount\": 2\n  },\n  \"Queenstown\": {\n    \"LocationName\": \"Queenstown\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        168.6626,\n        -45.0312\n      ]\n    },\n    \"CaseCount\": 2\n  },\n  \"Rotorua\": {\n    \"LocationName\": \"Rotorua\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        176.2497,\n        -38.1368\n      ]\n    },\n    \"CaseCount\": 1\n  },\n  \"Southern DHB\": {\n    \"LocationName\": \"Southern DHB\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        170.5086,\n        -45.8694\n      ]\n    },\n    \"CaseCount\": 2\n  },\n  \"TBC\": {\n    \"LocationName\": \"TBC\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        173.655098,\n        -40.2257029\n      ]\n    },\n    \"CaseCount\": 2\n  },\n  \"Taranaki\": {\n    \"LocationName\": \"Taranaki\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        174.4383,\n        -39.3538\n      ]\n    },\n    \"CaseCount\": 4\n  },\n  \"Tasman\": {\n    \"LocationName\": \"Tasman\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        172.7347,\n        -41.2122\n      ]\n    },\n    \"CaseCount\": 1\n  },\n  \"Taupo\": {\n    \"LocationName\": \"Taupo\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        176.0702,\n        -38.6857\n      ]\n    },\n    \"CaseCount\": 1\n  },\n  \"Upper Hutt\": {\n    \"LocationName\": \"Upper Hutt\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        175.0708,\n        -41.1244\n      ]\n    },\n    \"CaseCount\": 1\n  },\n  \"Waikato\": {\n    \"LocationName\": \"Waikato\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        175.1894,\n        -37.4558\n      ]\n    },\n    \"CaseCount\": 11\n  },\n  \"Wairarapa\": {\n    \"LocationName\": \"Wairarapa\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        175.6574,\n        -40.9511\n      ]\n    },\n    \"CaseCount\": 2\n  },\n  \"Waitaki\": {\n    \"LocationName\": \"Waitaki\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        170.6015,\n        -44.9874\n      ]\n    },\n    \"CaseCount\": 1\n  },\n  \"Waitemata\": {\n    \"LocationName\": \"Waitemata\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        174.5222,\n        -36.7423\n      ]\n    },\n    \"CaseCount\": 4\n  },\n  \"Wanaka\": {\n    \"LocationName\": \"Wanaka\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        169.1321,\n        -44.7032\n      ]\n    },\n    \"CaseCount\": 1\n  },\n  \"Wellington\": {\n    \"LocationName\": \"Wellington\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        174.7762,\n        -41.2865\n      ]\n    },\n    \"CaseCount\": 34\n  },\n  \"Wellington Region\": {\n    \"LocationName\": \"Wellington Region\",\n    \"LocationCentrePoint\": {\n      \"type\": \"Point\",\n      \"coordinates\": [\n        175.4376,\n        -41.0299\n      ]\n    },\n    \"CaseCount\": 2\n  }\n}";
            return await Task.FromResult(CovidLocation.FromJson(staticJson).Values.ToList());

        }
    }
}