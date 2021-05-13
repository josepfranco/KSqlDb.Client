namespace KSqlDb.Client.Ksql.Explain
{
    using System.Collections.Generic;
    using System.Text;
    using ApiModels.Requests;
    using Builders.Explain;

    public class ExplainRequestBuilder : IExplainRequestBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal ExplainRequestBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public ExplainRequest Build(IDictionary<string, string>? streamsProperties = null,
                                   long? commandSequenceNumber = null) =>
            ExplainRequest.WithKsql(this.BuildAsKsql(), streamsProperties, commandSequenceNumber);
        public string BuildAsKsql()
        {
            this.sqlExpressionBuilder.Append(";");
            return this.sqlExpressionBuilder.ToString();
        }
    }
}
