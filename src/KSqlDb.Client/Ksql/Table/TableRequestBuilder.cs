namespace KSqlDb.Client.Ksql.Table
{
    using System.Collections.Generic;
    using System.Text;
    using ApiModels.Requests;
    using Builders.Table;

    public class TableRequestBuilder : ITableRequestBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal TableRequestBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public TableRequest Build(IDictionary<string, string>? streamsProperties = null,
                                  long? commandSequenceNumber = null) =>
            TableRequest.WithKsql(this.BuildAsKsql(), streamsProperties,commandSequenceNumber);

        public string BuildAsKsql()
        {
            this.sqlExpressionBuilder.Append(";");
            return this.sqlExpressionBuilder.ToString();
        }
    }
}
