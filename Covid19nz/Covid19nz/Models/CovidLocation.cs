using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xamarin.Forms.Maps;

namespace Covid19nz.Models
{
    //convert json to csharp class from:
    //https://app.quicktype.io/
    public partial class CovidLocation
    {
        [JsonProperty("LocationName")]
        public string LocationName { get; set; }

        [JsonProperty("LocationCentrePoint")]
        public LocationCentrePoint LocationCentrePoint { get; set; }

        [JsonProperty("CaseCount")]
        public long CaseCount { get; set; }
    }

    public partial class LocationCentrePoint
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public enum TypeEnum { Point };

    public partial class CovidLocation
    {
        public static Dictionary<string, CovidLocation> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, CovidLocation>>(json, Covid19nz.Models.Converter.Settings);

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
    }

    public static class Serialize
    {
        public static string ToJson(this Dictionary<string, CovidLocation> self) => JsonConvert.SerializeObject(self, Covid19nz.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypeEnumConverter : JsonConverter
    {
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

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
