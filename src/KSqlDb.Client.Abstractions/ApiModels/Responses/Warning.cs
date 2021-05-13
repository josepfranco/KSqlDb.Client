namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Text.Json.Serialization;

    public record Warning
    {
        [JsonPropertyName("message")]
        public string? Message { get; init; }
    }
}
