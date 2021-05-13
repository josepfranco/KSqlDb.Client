namespace KSqlDb.Client.Ksql.Stream
{
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Stream;

    public class WithKafkaTopicExpressionBuilder : IWithKafkaTopicExpressionBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal WithKafkaTopicExpressionBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public IWithExpressionBuilder WithKafkaTopic(string topicName)
        {
            Guard.Against.NullOrWhiteSpace(topicName, nameof(topicName));

            this.sqlExpressionBuilder.AppendFormat("WITH ( KAFKA_TOPIC='{0}'", topicName);
            return new WithExpressionBuilder(this.sqlExpressionBuilder);
        }

        public IStreamRequestBuilder AndWithKafkaTopic(string topicName)
        {
            Guard.Against.NullOrWhiteSpace(topicName, nameof(topicName));

            this.sqlExpressionBuilder.AppendFormat("WITH ( KAFKA_TOPIC='{0}' )", topicName);
            return new StreamRequestBuilder(this.sqlExpressionBuilder);
        }
    }
}
