namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SourceType
    {
        [EnumMember(Value = "TABLE")]
        Table,

        [EnumMember(Value = "STREAM")]
        Stream
    }
}
