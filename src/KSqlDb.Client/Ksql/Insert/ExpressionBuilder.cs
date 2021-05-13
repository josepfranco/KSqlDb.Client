namespace KSqlDb.Client.Ksql.Insert
{
    using System.Collections.Generic;
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Insert;

    public class ExpressionBuilder : IInsertExpressionBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal ExpressionBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public IColumnValueExpressionBuilder Insert(string tableOrStreamName)
        {
            Guard.Against.NullOrEmpty(tableOrStreamName, nameof(tableOrStreamName));

            this.sqlExpressionBuilder.AppendFormat("INSERT INTO {0} ", tableOrStreamName);
            return new ColumnValueExpressionBuilder(this.sqlExpressionBuilder,
                                                    new List<(string, string)>());
        }
    }
}
