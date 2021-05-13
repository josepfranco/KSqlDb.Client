namespace KSqlDb.Client.Ksql.Builders.Stream
{
    using Types;

    public interface IKeyColumnExpressionBuilder
    {
        IRegularColumnExpressionBuilder ColumnWithKey(string name, ColumnType type);

        IWithKafkaTopicExpressionBuilder AndColumnWithKey(string name, ColumnType type);
    }
}
