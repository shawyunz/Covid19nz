using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace Covid19nz.Models
{
    public enum TypeEnum { Point };

    //convert json to csharp class from:
    //https://app.quicktype.io/
    public partial class CovidLocation
    {
        [JsonProperty("CaseCount")]
        public int CaseCount { get; set; }

        [JsonProperty("LocationCentrePoint")]
        public LocationCentrePoint LocationCentrePoint { get; set; }

        [JsonProperty("LocationName")]
        public string LocationName { get; set; }
    }

    public partial class CovidLocation
    {
        public Position Coordinate
        {
            get
            {
                var coordinates = LocationCentrePoint.Coordinates;
                if (coordinates?.Count > 1)
                    return new Position(coordinates[1], coordinates[0]);
                return new Position(0, 0);
            }
        }

        public int CountConfirmed { get; set; }

        public int CountProbable { get; set; }

        public string CovidType { get; set; }

        public static Dictionary<string, CovidLocation> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, CovidLocation>>(json, Converter.Settings);
    }

    public partial class LocationCentrePoint
    {
        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();

        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Point")
            {
                return TypeEnum.Point;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            if (value == TypeEnum.Point)
            {
                serializer.Serialize(writer, "Point");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }
    }
}