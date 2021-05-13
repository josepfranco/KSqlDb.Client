namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public record QueriesResponse : KsqlResponse
    {
        [JsonPropertyName("queries")]
        public IList<Query> Queries { get; init; } = new List<Query>();
    }
}
