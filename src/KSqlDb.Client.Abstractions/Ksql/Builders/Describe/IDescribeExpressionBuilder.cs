namespace KSqlDb.Client.Ksql.Builders.Describe
{
    public interface IDescribeExpressionBuilder
    {
        IDescribeRequestBuilder Describe(string streamOrTableName);

        IDescribeRequestBuilder DescribeExtended(string streamOrTableName);

        IDescribeRequestBuilder DescribeStreams();

        IDescribeRequestBuilder DescribeStreamsExtended();

        IDescribeRequestBuilder DescribeTables();

        IDescribeRequestBuilder DescribeTablesExtended();

        IDescribeRequestBuilder DescribeConnector(string connectorName);

        IDescribeRequestBuilder DescribeFunction(string functionName);
    }
}
