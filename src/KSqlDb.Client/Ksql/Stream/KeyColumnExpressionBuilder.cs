namespace KSqlDb.Client.Ksql.Stream
{
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Stream;
    using Types;

    public class KeyColumnExpressionBuilder : IKeyColumnExpressionBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal KeyColumnExpressionBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public IRegularColumnExpressionBuilder ColumnWithKey(string name, ColumnType type)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.Null(type, nameof(type));

            this.sqlExpressionBuilder.AppendFormat("( `{0}` {1} KEY", name, type);
            return new RegularColumnExpressionBuilder(this.sqlExpressionBuilder);
        }

        public IWithKafkaTopicExpressionBuilder AndColumnWithKey(string name, ColumnType type)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.Null(type, nameof(type));

            this.sqlExpressionBuilder.AppendFormat("( `{0}` {1} KEY ) ", name, type);
            return new WithKafkaTopicExpressionBuilder(this.sqlExpressionBuilder);
        }
    }
}
