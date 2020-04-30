using Newtonsoft.Json;

namespace Covid19nz.Models
{
    public partial class AlertLevel
    {
        [JsonProperty("Level")]
        public int Level { get; set; }

        [JsonProperty("LevelName")]
        public string LevelName { get; set; }
    }

    public partial class AlertLevel
    {
        public static AlertLevel FromJson(string json) => JsonConvert.DeserializeObject<AlertLevel>(json, Converter.Settings);
    }

    //Sample data:
    //{
    //  "Level": 4,
    //  "LevelName": "Eliminate"
    //}
}