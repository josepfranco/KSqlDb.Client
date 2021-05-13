namespace KSqlDb.Client.Ksql.Builders.Table
{
    public interface ITableExpressionBuilder
    {
        IPrimaryKeyColumnExpressionBuilder Create(string name);
        IPrimaryKeyColumnExpressionBuilder CreateOrReplace(string name);
        IPrimaryKeyColumnExpressionBuilder CreateIfNotExists(string name);
        IPrimaryKeyColumnExpressionBuilder CreateOrReplaceIfNotExists(string name);

        ITableSelectExpressionBuilder CreateAsSelect(string name);
        ITableSelectExpressionBuilder CreateOrReplaceAsSelect(string name);
    }
}
