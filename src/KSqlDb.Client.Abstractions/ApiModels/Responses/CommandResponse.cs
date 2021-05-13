namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Text.Json.Serialization;

    public record CommandResponse : KsqlResponse
    {
        [JsonPropertyName("commandId")]
        public string? CommandId { get; init; }

        [JsonPropertyName("commandStatus")]
        public CommandStatus? CommandStatus { get; init; }

        [JsonPropertyName("commandSequenceNumber")]
        public long? CommandSequenceNumber { get; init; }
    }
}
