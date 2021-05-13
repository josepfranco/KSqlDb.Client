namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public record Schema
    {
        [JsonPropertyName("type")]
        public string? Type { get; init; }

        [JsonPropertyName("memberSchema")]
        public Schema? MemberSchema { get; init; }

        [JsonPropertyName("fields")]
        public IList<Field> Fields { get; init; } = new List<Field>();
    }
}
