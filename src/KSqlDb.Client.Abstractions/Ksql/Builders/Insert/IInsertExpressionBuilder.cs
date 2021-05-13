namespace KSqlDb.Client.Ksql.Builders.Insert
{
    public interface IInsertExpressionBuilder
    {
        IColumnValueExpressionBuilder Insert(string tableOrStreamName);
    }
}
