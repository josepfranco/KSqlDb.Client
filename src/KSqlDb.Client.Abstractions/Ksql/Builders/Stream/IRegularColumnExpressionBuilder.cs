namespace KSqlDb.Client.Ksql.Builders.Stream
{
    using Types;

    public interface IRegularColumnExpressionBuilder
    {
        IRegularColumnExpressionBuilder Column(string name, ColumnType type);

        IWithKafkaTopicExpressionBuilder AndColumn(string name, ColumnType type);
    }
}
