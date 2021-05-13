namespace KSqlDb.Client.Ksql.Types
{
    public record ColumnType
    {
        private readonly string value;

        protected ColumnType(string value) => this.value = value;

        public override string ToString() => this.value;
    }
}
