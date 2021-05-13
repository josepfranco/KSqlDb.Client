namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public record QueryDescription
    {
        [JsonPropertyName("id")]
        public string? Id { get; init; }

        [JsonPropertyName("state")]
        public string? State { get; init; }

        [JsonPropertyName("statementText")]
        public string? StatementText { get; init; }

        [JsonPropertyName("fields")]
        public IList<Field> Fields { get; init; } = new List<Field>();

        [JsonPropertyName("sources")]
        public IList<string> Sources { get; init; } = new List<string>();

        [JsonPropertyName("sinks")]
        public IList<string> Sinks { get; init; } = new List<string>();

        [JsonPropertyName("executionPlan")]
        public string? ExecutionPlan { get; init; }

        [JsonPropertyName("topology")]
        public string? Topology { get; init; }

        [JsonPropertyName("overriddenProperties")]
        public IDictionary<string, string> OverriddenProperties { get; init; } = new Dictionary<string, string>();
    }
}
