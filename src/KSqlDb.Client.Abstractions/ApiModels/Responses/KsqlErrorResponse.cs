namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public record KsqlErrorResponse
    {
        [JsonPropertyName("@type")]
        public string? Type { get; init; }

        [JsonPropertyName("error_code")]
        public int? ErrorCode { get; init; }

        [JsonPropertyName("statementText")]
        public string? StatementText { get; init; }

        [JsonPropertyName("entities")]
        public IList<string> Entities { get; init; } = new List<string>();
    }
}
