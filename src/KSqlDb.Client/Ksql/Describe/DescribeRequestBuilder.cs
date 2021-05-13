namespace KSqlDb.Client.Ksql.Describe
{
    using System.Collections.Generic;
    using System.Text;
    using ApiModels.Requests;
    using Builders.Describe;

    public class DescribeRequestBuilder : IDescribeRequestBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal DescribeRequestBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public DescribeRequest Build(IDictionary<string, string>? streamsProperties = null,
                                    long? commandSequenceNumber = null) =>
            DescribeRequest.WithKsql(this.BuildAsKsql(), streamsProperties, commandSequenceNumber);
        public string BuildAsKsql()
        {
            this.sqlExpressionBuilder.Append(";");
            return this.sqlExpressionBuilder.ToString();
        }
    }
}
