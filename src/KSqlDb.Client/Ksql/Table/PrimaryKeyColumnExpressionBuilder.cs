namespace KSqlDb.Client.Ksql.Table
{
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Table;
    using Types;

    public class PrimaryKeyColumnExpressionBuilder : IPrimaryKeyColumnExpressionBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal PrimaryKeyColumnExpressionBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public IRegularColumnExpressionBuilder ColumnWithPrimaryKey(string name, ColumnType type)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.Null(type, nameof(type));

            this.sqlExpressionBuilder.AppendFormat("( `{0}` {1} PRIMARY KEY", name, type);
            return new RegularColumnExpressionBuilder(this.sqlExpressionBuilder);
        }

        public IWithKafkaTopicExpressionBuilder AndColumnWithPrimaryKey(string name, ColumnType type)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.Null(type, nameof(type));

            this.sqlExpressionBuilder.AppendFormat("( `{0}` {1} PRIMARY KEY ) ", name, type);
            return new WithKafkaTopicExpressionBuilder(this.sqlExpressionBuilder);
        }
    }
}
