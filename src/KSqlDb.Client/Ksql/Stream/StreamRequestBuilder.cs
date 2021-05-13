namespace KSqlDb.Client.Ksql.Stream
{
    using System.Collections.Generic;
    using System.Text;
    using ApiModels.Requests;
    using Builders.Stream;

    public class StreamRequestBuilder : IStreamRequestBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal StreamRequestBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public StreamRequest Build(IDictionary<string, string>? streamsProperties = null,
                                   long? commandSequenceNumber = null) =>
            StreamRequest.WithKsql(this.BuildAsKsql(), streamsProperties, commandSequenceNumber);

        public string BuildAsKsql()
        {
            this.sqlExpressionBuilder.Append(";");
            return this.sqlExpressionBuilder.ToString();
        }
    }
}
