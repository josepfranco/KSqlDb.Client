namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Text.Json.Serialization;

    public record DescribeResponse : KsqlResponse
    {
        [JsonPropertyName("sourceDescription")]
        public SourceDescription? SourceDescription { get; init; }
    }
}
