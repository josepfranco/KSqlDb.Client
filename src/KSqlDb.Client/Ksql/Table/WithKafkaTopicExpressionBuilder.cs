namespace KSqlDb.Client.Ksql.Table
{
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Table;

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

        public ITableRequestBuilder AndWithKafkaTopic(string topicName)
        {
            Guard.Against.NullOrWhiteSpace(topicName, nameof(topicName));

            this.sqlExpressionBuilder.AppendFormat("WITH ( KAFKA_TOPIC='{0}' )", topicName);
            return new TableRequestBuilder(this.sqlExpressionBuilder);
        }
    }
}
