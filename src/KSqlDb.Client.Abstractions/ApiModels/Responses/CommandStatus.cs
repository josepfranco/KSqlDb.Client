namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Text.Json.Serialization;

    public record CommandStatus
    {
        [JsonPropertyName("status")]
        public string? Status { get; init; }

        [JsonPropertyName("message")]
        public string? Message { get; init; }
    }
}
