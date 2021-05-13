namespace KSqlDb.Client.Ksql.Builders.Explain
{
    public interface IExplainExpressionBuilder
    {
        IExplainRequestBuilder Explain(string queryId);
    }
}
