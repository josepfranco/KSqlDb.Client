namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public record TablesResponse : KsqlResponse
    {
        [JsonPropertyName("tables")]
        public IList<Table> Tables { get; init; } = new List<Table>();
    }
}
