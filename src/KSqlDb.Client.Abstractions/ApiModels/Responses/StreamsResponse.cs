namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public record StreamsResponse : KsqlResponse
    {
        [JsonPropertyName("streams")]
        public IList<Stream> Streams { get; init; } = new List<Stream>();
    }
}
