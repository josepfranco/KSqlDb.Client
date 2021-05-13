namespace KSqlDb.Client.Ksql.Stream
{
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Stream;
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

        public IStreamRequestBuilder AndWith(WithProperty property)
        {
            Guard.Against.Null(property, nameof(property));

            this.sqlExpressionBuilder.AppendFormat(", {0} )", property);
            return new StreamRequestBuilder(this.sqlExpressionBuilder);
        }
    }
}
