namespace KSqlDb.Client.ApiModels.Requests
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public record KsqlRequest
    {
        protected KsqlRequest() { }

        [JsonPropertyName("ksql")]
        public string? Ksql { get; init; }

        [JsonPropertyName("streamsProperties")]
        public IDictionary<string, string>? StreamsProperties { get; init; } = new Dictionary<string, string>();

        [JsonPropertyName("commandSequenceNumber")]
        public long? CommandSequenceNumber { get; init; }
    }
}
