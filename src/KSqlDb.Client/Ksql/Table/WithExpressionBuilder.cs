namespace KSqlDb.Client.Ksql.Table
{
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Table;
    using Properties;

    public class WithExpressionBuilder : IWithExpressionBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal WithExpressionBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public IWithExpressionBuilder With(WithProperty property)
        {
            Guard.Against.Null(property, nameof(property));

            this.sqlExpressionBuilder.AppendFormat(", {0}", property);
            return new WithExpressionBuilder(this.sqlExpressionBuilder);
        }

        public ITableRequestBuilder AndWith(WithProperty property)
        {
            Guard.Against.Null(property, nameof(property));

            this.sqlExpressionBuilder.AppendFormat(", {0} )", property);
            return new TableRequestBuilder(this.sqlExpressionBuilder);
        }
    }
}
