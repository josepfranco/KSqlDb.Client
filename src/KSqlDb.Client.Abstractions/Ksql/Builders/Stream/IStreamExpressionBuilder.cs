namespace KSqlDb.Client.Ksql.Builders.Stream
{
    public interface IStreamExpressionBuilder
    {
        IKeyColumnExpressionBuilder Create(string name);
        IKeyColumnExpressionBuilder CreateOrReplace(string name);
        IKeyColumnExpressionBuilder CreateIfNotExists(string name);
        IKeyColumnExpressionBuilder CreateOrReplaceIfNotExists(string name);
    }
}
