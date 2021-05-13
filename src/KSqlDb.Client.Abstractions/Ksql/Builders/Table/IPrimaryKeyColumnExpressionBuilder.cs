namespace KSqlDb.Client.Ksql.Builders.Table
{
    using Types;

    public interface IPrimaryKeyColumnExpressionBuilder
    {
        IRegularColumnExpressionBuilder ColumnWithPrimaryKey(string name, ColumnType type);

        IWithKafkaTopicExpressionBuilder AndColumnWithPrimaryKey(string name, ColumnType type);
    }
}
