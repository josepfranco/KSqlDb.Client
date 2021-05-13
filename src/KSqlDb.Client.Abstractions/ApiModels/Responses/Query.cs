namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public record Query
    {
        [JsonPropertyName("queryString")]
        public string? QueryString { get; init; }

        [JsonPropertyName("sinks")]
        public IList<string> Sinks { get; init; } = new List<string>();

        [JsonPropertyName("id")]
        public string? Id { get; init; }
    }
}
