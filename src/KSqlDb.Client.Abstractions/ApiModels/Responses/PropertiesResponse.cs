namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public record PropertiesResponse : KsqlResponse
    {
        [JsonPropertyName("properties")]
        public IDictionary<string, string> Properties { get; init; } = new Dictionary<string, string>();

        [JsonPropertyName("overwrittenProperties")]
        public IList<string> OverwrittenProperties { get; init; } = new List<string>();

        [JsonPropertyName("defaultProperties")]
        public IList<string> DefaultProperties { get; init; } = new List<string>();
    }
}
