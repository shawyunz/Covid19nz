using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Covid19nz.Models
{

    public partial class CovidCase
    {
        [JsonProperty("CaseNumber")]
        public long CaseNumber { get; set; }

        [JsonProperty("LocationName")]
        public string LocationName { get; set; }

        [JsonProperty("LocationCentrePoint")]
        public LocationCentrePoint LocationCentrePoint { get; set; }

        [JsonProperty("Age")]
        public Age Age { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("TravelDetailsUnstructured")]
        public string TravelDetailsUnstructured { get; set; }

        [JsonProperty("CaseType")]
        public CaseType CaseType { get; set; }
    }

    public partial class Age
    {
        [JsonProperty("Valid")]
        public bool Valid { get; set; }

        [JsonProperty("OlderOrEqualToAge")]
        public long OlderOrEqualToAge { get; set; }

        [JsonProperty("YoungerOrEqualToAge")]
        public long YoungerOrEqualToAge { get; set; }
    }

    public enum CaseType { Confirmed, Probable };

    public enum Gender { Female, Male, UnknownOrUndisclosed };

    public partial class CovidCase
    {
        public static List<CovidCase> FromJson(string json) => JsonConvert.DeserializeObject<List<CovidCase>>(json, Covid19nz.Models.Converter.Settings);

        public string PersonalInfo => Gender + ", " + Age.OlderOrEqualToAge + "+";
        public string GenderChar => Gender.Substring(0, 1);

    }

    public static class SerializeCovidCase
    {
        public static string ToJson(this List<CovidCase> self) => JsonConvert.SerializeObject(self, Covid19nz.Models.Converter.Settings);
    }

    internal static class ConverterCovidCase
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CaseTypeConverter.Singleton,
                GenderConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CaseTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CaseType) || t == typeof(CaseType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "confirmed":
                    return CaseType.Confirmed;
                case "probable":
                    return CaseType.Probable;
            }
            throw new Exception("Cannot unmarshal type CaseType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CaseType)untypedValue;
            switch (value)
            {
                case CaseType.Confirmed:
                    serializer.Serialize(writer, "confirmed");
                    return;
                case CaseType.Probable:
                    serializer.Serialize(writer, "probable");
                    return;
            }
            throw new Exception("Cannot marshal type CaseType");
        }

        public static readonly CaseTypeConverter Singleton = new CaseTypeConverter();
    }

    internal class GenderConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Gender) || t == typeof(Gender?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Female":
                    return Gender.Female;
                case "Male":
                    return Gender.Male;
                case "Unknown or undisclosed":
                    return Gender.UnknownOrUndisclosed;
            }
            throw new Exception("Cannot unmarshal type Gender");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Gender)untypedValue;
            switch (value)
            {
                case Gender.Female:
                    serializer.Serialize(writer, "Female");
                    return;
                case Gender.Male:
                    serializer.Serialize(writer, "Male");
                    return;
                case Gender.UnknownOrUndisclosed:
                    serializer.Serialize(writer, "Unknown or undisclosed");
                    return;
            }
            throw new Exception("Cannot marshal type Gender");
        }

        public static readonly GenderConverter Singleton = new GenderConverter();
    }

}
