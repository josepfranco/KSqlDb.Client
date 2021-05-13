namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Text.Json.Serialization;

    public record ExplainResponse : KsqlResponse
    {
        [JsonPropertyName("queryDescription")]
        public QueryDescription? QueryDescription { get; init; }
    }
}
