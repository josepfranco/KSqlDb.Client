namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Text.Json.Serialization;

    public record Field
    {
        [JsonPropertyName("name")]
        public string? Name { get; init; }

        [JsonPropertyName("schema")]
        public Schema? Schema { get; init; }
    }
}
