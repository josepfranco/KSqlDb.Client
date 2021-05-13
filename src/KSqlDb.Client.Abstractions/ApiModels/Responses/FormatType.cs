namespace KSqlDb.Client.ApiModels.Responses
{
    using System.Runtime.Serialization;

    public enum FormatType
    {
        [EnumMember(Value = "AVRO")]
        Avro,

        [EnumMember(Value = "DELIMITED")]
        Delimited,

        [EnumMember(Value = "JSON")]
        Json
    }
}
