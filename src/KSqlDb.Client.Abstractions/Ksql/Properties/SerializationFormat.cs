namespace KSqlDb.Client.Ksql.Properties
{
    public enum SerializationFormat
    {
        None,
        Delimited,
        Json,

        // ReSharper disable once InconsistentNaming
        Json_Sr,
        Avro,
        Kafka,
        Protobuf
    }
}
