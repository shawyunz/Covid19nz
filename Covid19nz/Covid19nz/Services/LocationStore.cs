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
            var locationJson = new WebClient().DownloadString("https://nzcovid19api.xerra.nz/locations/json");

            //var list = CovidLocation.FromJson(locationJson);
            //var result = list.Values.ToList();

            return await Task.FromResult(CovidLocation.FromJson(locationJson).Values.ToList());

        }
    }
}