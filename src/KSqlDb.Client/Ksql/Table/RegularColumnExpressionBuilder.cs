namespace KSqlDb.Client.Ksql.Table
{
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Table;
    using Constraints;
    using Types;

    public class RegularColumnExpressionBuilder : IRegularColumnExpressionBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal RegularColumnExpressionBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public IRegularColumnExpressionBuilder Column(string name, ColumnType type)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.Null(type, nameof(type));

            this.sqlExpressionBuilder.AppendFormat(", `{0}` {1}", name, type);
            return new RegularColumnExpressionBuilder(this.sqlExpressionBuilder);
        }

        public IWithKafkaTopicExpressionBuilder AndColumn(string name, ColumnType type)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.Null(type, nameof(type));

            this.sqlExpressionBuilder.AppendFormat(", `{0}` {1} ) ", name, type);
            return new WithKafkaTopicExpressionBuilder(this.sqlExpressionBuilder);
        }

        public IRegularColumnExpressionBuilder ColumnWithConstraint(string name,
                                                                    ColumnType type,
                                                                    ConstraintType constraint)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.Null(type, nameof(type));

            this.sqlExpressionBuilder.AppendFormat(", `{0}` {1} {2}", name, type, constraint);
            return new RegularColumnExpressionBuilder(this.sqlExpressionBuilder);
        }

        public IWithKafkaTopicExpressionBuilder AndColumnWithConstraint(string name,
                                                                        ColumnType type,
                                                                        ConstraintType constraint)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Guard.Against.Null(type, nameof(type));

            this.sqlExpressionBuilder.AppendFormat(", `{0}` {1} {2} ) ", name, type, constraint);
            return new WithKafkaTopicExpressionBuilder(this.sqlExpressionBuilder);
        }
    }
}
