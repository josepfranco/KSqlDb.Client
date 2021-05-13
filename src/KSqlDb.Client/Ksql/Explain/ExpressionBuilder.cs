namespace KSqlDb.Client.Ksql.Explain
{
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Explain;

    public class ExpressionBuilder : IExplainExpressionBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal ExpressionBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public IExplainRequestBuilder Explain(string queryId)
        {
            Guard.Against.NullOrEmpty(queryId, nameof(queryId));

            this.sqlExpressionBuilder.AppendFormat("EXPLAIN {0}", queryId);
            return new ExplainRequestBuilder(this.sqlExpressionBuilder);
        }
    }
}
