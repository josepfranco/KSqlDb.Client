namespace KSqlDb.Client.Ksql.Stream
{
    using System.Text;
    using Ardalis.GuardClauses;
    using Builders.Stream;

    public class ExpressionBuilder : IStreamExpressionBuilder
    {
        private readonly StringBuilder sqlExpressionBuilder;

        internal ExpressionBuilder(StringBuilder sqlExpressionBuilder) =>
            this.sqlExpressionBuilder = sqlExpressionBuilder;


        public IKeyColumnExpressionBuilder Create(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));

            this.sqlExpressionBuilder.AppendFormat("CREATE STREAM `{0}` ", name);
            return new KeyColumnExpressionBuilder(this.sqlExpressionBuilder);
        }

        public IKeyColumnExpressionBuilder CreateOrReplace(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));

            this.sqlExpressionBuilder.AppendFormat("CREATE OR REPLACE STREAM `{0}` ", name);
            return new KeyColumnExpressionBuilder(this.sqlExpressionBuilder);
        }

        public IKeyColumnExpressionBuilder CreateIfNotExists(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));

            this.sqlExpressionBuilder.AppendFormat("CREATE STREAM IF NOT EXISTS `{0}` ", name);
            return new KeyColumnExpressionBuilder(this.sqlExpressionBuilder);
        }

        public IKeyColumnExpressionBuilder CreateOrReplaceIfNotExists(string name)
        {
            Guard.Against.NullOrWhiteSpace(name, nameof(name));

            this.sqlExpressionBuilder.AppendFormat("CREATE OR REPLACE STREAM IF NOT EXISTS `{0}` ", name);
            return new KeyColumnExpressionBuilder(this.sqlExpressionBuilder);
        }
    }
}
