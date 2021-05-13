namespace KSqlDb.Client.Ksql.Builders.Table
{
    public interface IWithKafkaTopicExpressionBuilder
    {
        IWithExpressionBuilder WithKafkaTopic(string topicName);

        ITableRequestBuilder AndWithKafkaTopic(string topicName);
    }
}
