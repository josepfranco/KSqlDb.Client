namespace KSqlDb.Client.Ksql.Builders.Stream
{
    public interface IWithKafkaTopicExpressionBuilder
    {
        IWithExpressionBuilder WithKafkaTopic(string topicName);

        IStreamRequestBuilder AndWithKafkaTopic(string topicName);
    }
}
