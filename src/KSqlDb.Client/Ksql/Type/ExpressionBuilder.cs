namespace KSqlDb.Client.Ksql.Type
{
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Type;
    using Types;

    public class ExpressionBuilder : ITypeExpressionBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        public ExpressionBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public ITypeRequestBuilder Create(string name, ColumnType type)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.Null(type, nameof(type));
            this.sqlExpressionBuilder.AppendFormat("CREATE TYPE `{0}` as `{1}`", name, type);
            return new TypeRequestBuilder(this.sqlExpressionBuilder);
        }
    }
}
