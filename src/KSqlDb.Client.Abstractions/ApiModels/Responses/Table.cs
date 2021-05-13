namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Text.Json.Serialization;

    public record Table
    {
        [JsonPropertyName("name")]
        public string? Name { get; init; }

        [JsonPropertyName("topic")]
        public string? Topic { get; init; }

        [JsonPropertyName("format")]
        public FormatType? Format { get; init; }

        [JsonPropertyName("type")]
        public SourceType? Type { get; init; }

        [JsonPropertyName("isWindowed")]
        public bool? IsWindowed { get; init; }
    }
}
