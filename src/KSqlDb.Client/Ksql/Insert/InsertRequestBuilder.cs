namespace KSqlDb.Client.Ksql.Insert
{
    using System.Collections.Generic;
    using System.Text;
    using ApiModels.Requests;
    using Builders.Insert;

    public class InsertRequestBuilder : IInsertRequestBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal InsertRequestBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public InsertRequest Build(IDictionary<string, string>? streamsProperties = null,
                                   long? commandSequenceNumber = null) =>
            InsertRequest.WithKsql(this.BuildAsKsql(), streamsProperties, commandSequenceNumber);

        public string BuildAsKsql()
        {
            this.sqlExpressionBuilder.Append(";");
            return this.sqlExpressionBuilder.ToString();
        }
    }
}
