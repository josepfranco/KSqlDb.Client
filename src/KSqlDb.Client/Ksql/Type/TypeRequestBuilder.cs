namespace KSqlDb.Client.Ksql.Type
{
    using System.Collections.Generic;
    using System.Text;
    using ApiModels.Requests;
    using Builders.Type;

    public class TypeRequestBuilder : ITypeRequestBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal TypeRequestBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public TypeRequest Build(IDictionary<string, string>? streamsProperties = null,
                                 long? commandSequenceNumber = null) =>
            TypeRequest.WithKsql(this.BuildAsKsql(), streamsProperties, commandSequenceNumber);

        public string BuildAsKsql()
        {
            this.sqlExpressionBuilder.Append(";");
            return this.sqlExpressionBuilder.ToString();
        }
    }
}
