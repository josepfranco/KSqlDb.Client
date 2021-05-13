namespace KSqlDb.Client.Ksql.Describe
{
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Describe;

    public class ExpressionBuilder : IDescribeExpressionBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal ExpressionBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public IDescribeRequestBuilder Describe(string streamOrTableName)
        {
            Guard.Against.NullOrWhiteSpace(streamOrTableName, nameof(streamOrTableName));

            this.sqlExpressionBuilder.AppendFormat("DESCRIBE {0}", streamOrTableName);
            return new DescribeRequestBuilder(this.sqlExpressionBuilder);
        }

        public IDescribeRequestBuilder DescribeExtended(string streamOrTableName)
        {
            Guard.Against.NullOrWhiteSpace(streamOrTableName, nameof(streamOrTableName));

            this.sqlExpressionBuilder.AppendFormat("DESCRIBE {0} EXTENDED", streamOrTableName);
            return new DescribeRequestBuilder(this.sqlExpressionBuilder);
        }

        public IDescribeRequestBuilder DescribeStreams()
        {
            this.sqlExpressionBuilder.Append("DESCRIBE STREAMS");
            return new DescribeRequestBuilder(this.sqlExpressionBuilder);
        }

        public IDescribeRequestBuilder DescribeStreamsExtended()
        {
            this.sqlExpressionBuilder.Append("DESCRIBE STREAMS EXTENDED");
            return new DescribeRequestBuilder(this.sqlExpressionBuilder);
        }

        public IDescribeRequestBuilder DescribeTables()
        {
            this.sqlExpressionBuilder.Append("DESCRIBE TABLES");
            return new DescribeRequestBuilder(this.sqlExpressionBuilder);
        }

        public IDescribeRequestBuilder DescribeTablesExtended()
        {
            this.sqlExpressionBuilder.Append("DESCRIBE TABLES EXTENDED");
            return new DescribeRequestBuilder(this.sqlExpressionBuilder);
        }

        public IDescribeRequestBuilder DescribeConnector(string connectorName)
        {
            Guard.Against.NullOrWhiteSpace(connectorName, nameof(connectorName));

            this.sqlExpressionBuilder.AppendFormat(@"DESCRIBE CONNECTOR ""{0}""", connectorName);
            return new DescribeRequestBuilder(this.sqlExpressionBuilder);
        }

        public IDescribeRequestBuilder DescribeFunction(string functionName)
        {
            Guard.Against.NullOrWhiteSpace(functionName, nameof(functionName));

            this.sqlExpressionBuilder.AppendFormat("DESCRIBE FUNCTION {0}", functionName);
            return new DescribeRequestBuilder(this.sqlExpressionBuilder);
        }
    }
}
