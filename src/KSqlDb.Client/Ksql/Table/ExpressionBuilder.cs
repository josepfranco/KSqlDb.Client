namespace KSqlDb.Client.Ksql.Table
{
    using System;
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Table;

    public class ExpressionBuilder : ITableExpressionBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal ExpressionBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;

        public IPrimaryKeyColumnExpressionBuilder Create(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            this.sqlExpressionBuilder.AppendFormat("CREATE TABLE `{0}` ", name);
            return new PrimaryKeyColumnExpressionBuilder(this.sqlExpressionBuilder);
        }

        public IPrimaryKeyColumnExpressionBuilder CreateOrReplace(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            this.sqlExpressionBuilder.AppendFormat("CREATE OR REPLACE TABLE `{0}` ", name);
            return new PrimaryKeyColumnExpressionBuilder(this.sqlExpressionBuilder);
        }

        public IPrimaryKeyColumnExpressionBuilder CreateIfNotExists(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            this.sqlExpressionBuilder.AppendFormat("CREATE TABLE IF NOT EXISTS `{0}` ", name);
            return new PrimaryKeyColumnExpressionBuilder(this.sqlExpressionBuilder);
        }

        public IPrimaryKeyColumnExpressionBuilder CreateOrReplaceIfNotExists(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));
            this.sqlExpressionBuilder.AppendFormat("CREATE OR REPLACE TABLE IF NOT EXISTS `{0}` ", name);
            return new PrimaryKeyColumnExpressionBuilder(this.sqlExpressionBuilder);
        }

        public ITableSelectExpressionBuilder CreateAsSelect(string name) => throw new NotImplementedException();

        public ITableSelectExpressionBuilder CreateOrReplaceAsSelect(string name) =>
            throw new NotImplementedException();
    }
}
