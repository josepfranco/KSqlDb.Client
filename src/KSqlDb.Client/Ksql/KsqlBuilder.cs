namespace KSqlDb.Client.Ksql
{
    using System.Text;
    using Builders.Describe;
    using Builders.Explain;
    using Builders.Insert;
    using Builders.Stream;
    using Builders.Table;
    using Builders.Type;

    public static class KsqlBuilder
    {
        public static ITableExpressionBuilder ForTableRequest =>
            new Table.ExpressionBuilder(new StringBuilder());

        public static IStreamExpressionBuilder ForStreamRequest =>
            new Stream.ExpressionBuilder(new StringBuilder());

        public static ITypeExpressionBuilder ForTypeRequest =>
            new Type.ExpressionBuilder(new StringBuilder());

        public static IExplainExpressionBuilder ForExplainRequest =>
            new Explain.ExpressionBuilder(new StringBuilder());

        public static IDescribeExpressionBuilder ForDescribeRequest =>
            new Describe.ExpressionBuilder(new StringBuilder());

        public static IInsertExpressionBuilder ForInsertRequest =>
            new Insert.ExpressionBuilder(new StringBuilder());
    }
}
