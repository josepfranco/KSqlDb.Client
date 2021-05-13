namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public record SourceDescription
    {
        [JsonPropertyName("name")]
        public string? Name { get; init; }

        [JsonPropertyName("readQueries")]
        public IList<Query> ReadQueries { get; init; } = new List<Query>();

        [JsonPropertyName("writeQueries")]
        public IList<Query> WriteQueries { get; init; } = new List<Query>();

        [JsonPropertyName("fields")]
        public IList<Field> Fields { get; init; } = new List<Field>();

        [JsonPropertyName("type")]
        public SourceType? Type { get; init; }

        [JsonPropertyName("key")]
        public string? Key { get; init; }

        [JsonPropertyName("timestamp")]
        public string? Timestamp { get; init; }

        [JsonPropertyName("format")]
        public FormatType? Format { get; init; }

        [JsonPropertyName("topic")]
        public string? Topic { get; init; }

        [JsonPropertyName("extended")]
        public bool? IsExtended { get; init; }

        [JsonPropertyName("statistics")]
        public string? Statistics { get; init; }

        [JsonPropertyName("errorStats")]
        public string? ErrorStats { get; init; }

        [JsonPropertyName("replication")]
        public int? Replication { get; init; }

        [JsonPropertyName("partitions")]
        public int? Partitions { get; init; }
    }
}
